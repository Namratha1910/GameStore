using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddGameStoreDb();

builder.Services.AddValidation();

var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
