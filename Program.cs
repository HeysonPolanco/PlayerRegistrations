using PlayerRegistrations.Components;
using Microsoft.EntityFrameworkCore;
using PlayerRegistrations.DAL;
using PlayerRegistrations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<Context>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<PlayersService>();
builder.Services.AddScoped<MatchService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
