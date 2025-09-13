using PlayerRegistrations.Models;
using PlayerRegistrations.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace PlayerRegistrations.Services;

public class MatchService
{
    public async Task<List<Matches>> GetList(Expression<Func<Matches, bool>>? criteria = null)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();

        if (criteria != null)
            return await context.Matches.Where(criteria).ToListAsync();
        else
            return await context.Matches.ToListAsync();
    }

    private readonly IDbContextFactory<Context> _dbFactory;

    public MatchService(IDbContextFactory<Context> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Save(Matches Match)
    {
        if (!await Exists(Match.MatchId))
            return await Insert(Match);
        else
            return await Update(Match);
    }

    public async Task<bool> Exists(int MatchId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Matches.AnyAsync(p => p.MatchId == MatchId);
    }

    private async Task<bool> Insert(Matches Match)
    {
        if (await NameExists(Match.MatchId, Match.Matchstate))
            throw new Exception("A Match with the same name already exists.");

        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Matches.Add(Match);
        return await context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Update(Matches Match)
    {
        if (await NameExists(Match.MatchId, Match.Matchstate))
            throw new Exception("A Match with the same name already exists.");

        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Matches.Update(Match);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Matches?> GetById(int MatchId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Matches.FirstOrDefaultAsync(p => p.MatchId == MatchId);
    }

    public async Task<bool> Delete(int MatchId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Matches
            .AsNoTracking()
            .Where(p => p.MatchId == MatchId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Matches>> List(Expression<Func<Matches, bool>> criteria)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Matches.Where(criteria).AsNoTracking().ToListAsync();
    }

    public async Task<bool> NameExists(int MatchId, string name)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Matches.AnyAsync(p =>
            p.MatchId != MatchId && p.Matchstate.ToLower() == name.ToLower());
    }
}
