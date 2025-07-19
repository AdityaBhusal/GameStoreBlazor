<<<<<<< HEAD
using GameStoreApi.Data;
using GameStoreApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
//when addsqllite is called, gamestorecontext is injected into the services collection as a scoped service
//scoped service means that it is created once per request and disposed of when the request is done
//this is the default lifetime of a service

var app = builder.Build();
app.MapGamesEndpoints();
app.MapGenresEndpoints();
await app.MigrateDbAsync();
=======
using Gamestore.Frontend.Clients;
using Gamestore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);
// comment
// Add services to the container.
builder.Services.AddRazorComponents().
            AddInteractiveServerComponents();

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
    throw new Exception("GameStoreApiUrl is required in appsettings.json or is not set to a valid URL.");

builder.Services.AddHttpClient<GamesClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl));

builder.Services.AddHttpClient<GenresClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
>>>>>>> 043185c (Initial commit)

app.Run();
