using GameStore.Entities;

// initialize the name of the routers
const string GetGameEndpointName = "GetGameById";


// create new entities game objects
List<Game> games = new() {
    new Game { Id = 1, Name = "Game 1", Relasedate =DateTime.Now, Price = 100  , Genre = "Action" , Imageurl = "https://placehold.co/400"},
    new Game { Id = 2, Name = "Game 2", Relasedate = DateTime.Now, Price = 200 , Genre = "Action" , Imageurl = "https://placehold.co/400" },
    new Game { Id = 3, Name = "Game 3", Relasedate = DateTime.Now, Price = 300 , Genre = "Action" , Imageurl = "https://placehold.co/400" }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "home page is here...");
app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

// post request

app.MapPost("/games", (Game newGame) =>
{
    // make the id dynmic 
    newGame.Id = games.Max(game => game.Id) + 1;

    // add the new game to the list of games
    games.Add(newGame);

    return Results.CreatedAtRoute(GetGameEndpointName);
});
app.Run();
