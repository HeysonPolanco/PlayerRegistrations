using Microsoft.EntityFrameworkCore;
using PlayerRegistrations.DAL;
using PlayerRegistrations.Models;

namespace PlayerRegistrations.Services;

public class MovementsServices
{
    private readonly IDbContextFactory<Context> _dbFactory;

    public MovementsServices(IDbContextFactory<Context> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Save(Movements movement)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Movements.Add(movement);
        return await context.SaveChangesAsync() > 0;
    }
}
