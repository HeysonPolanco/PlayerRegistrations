using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PlayerRegistrations.Models;
using PlayerRegistrations.DAL;
using System.Linq.Expressions;

namespace PlayerRegistrations.Services;

public class MovementsServices
{
    private readonly IDbContextFactory<Context> _dbFactory;

    public MovementsServices(IDbContextFactory<Context> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    private async Task<bool> Exists(int movementId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Movements.AnyAsync(m => m.MovementId == movementId);
    }

    public async Task<bool> Insert(Movements movement)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Movements.Add(movement);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modify(Movements movement)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Movements.Update(movement);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Save(Movements movement)
    {
        if (!await Exists(movement.MovementId))
            return await Insert(movement);
        else
            return await Modify(movement);
    }

    public async Task<Movements?> Search(int movementId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Movements.FirstOrDefaultAsync(m => m.MovementId == movementId);
    }

    public async Task<bool> Delete(int movementId)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Movements
            .Where(m => m.MovementId == movementId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Movements>> GetList(Expression<Func<Movements, bool>> criteria)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        return await context.Movements
            .Where(criteria)
            .AsNoTracking()
            .ToListAsync();
    }
}
