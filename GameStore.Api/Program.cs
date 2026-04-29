using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddGameStoreDb();

builder.Services.AddValidation();

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndPoints();

app.MigrateDb();

app.Run();
