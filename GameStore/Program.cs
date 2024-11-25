using GameStore.GameStoreEndpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.routeGroupBuilder();

app.Run();
