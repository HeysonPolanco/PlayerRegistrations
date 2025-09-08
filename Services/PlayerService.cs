using PlayerRegistrations.Models;
using PlayerRegistrations.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PlayerRegistrations.Services;

public class PlayersService
{
    public async Task<List<Players>> GetList(Expression<Func<Players, bool>>? criteria = null)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();

        if (criteria != null)
            return await context.Players.Where(criteria).ToListAsync();
        else
            return await context.Players.ToListAsync();
    }

    private readonly IDbContextFactory<Context> _dbFactory;

    public PlayersService(IDbContextFactory<Context> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Save(Players player)
    {
        if (!await Exists(player.PlayerId))
            return await Insert(player);
        else
            return await Update(player);
    }

    public async Task<bool> Exists(int playerId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Players.AnyAsync(p => p.PlayerId == playerId);
    }

    private async Task<bool> Insert(Players player)
    {
        if (await NameExists(player.PlayerId, player.Concept))
            throw new Exception("A player with the same name already exists.");

        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Players.Add(player);
        return await context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Update(Players player)
    {
        if (await NameExists(player.PlayerId, player.Concept))
            throw new Exception("A player with the same name already exists.");

        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Players.Update(player);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Players?> GetById(int playerId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
    }

    public async Task<bool> Delete(int playerId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Players
            .AsNoTracking()
            .Where(p => p.PlayerId == playerId)
            .ExecuteDeleteAsync() > 0;
    }


    public async Task<List<Players>> List(Expression<Func<Players, bool>> criteria)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Players.Where(criteria).AsNoTracking().ToListAsync();
    }

    public async Task<bool> NameExists(int playerId, string name)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Players.AnyAsync(p =>
            p.PlayerId != playerId && p.Concept.ToLower() == name.ToLower());
    }
}
