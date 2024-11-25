

using GameStore.Entities;

namespace GameStore.GameStoreEndpoints;

public static class RouteEndpoints
{
    // initialize the name of the routers
    const string GetGameEndpointName = "GetGameById";


    // create new entities game objects
    static List<Game> games = new() {
    new Game { Id = 1, Name = "Game 1", Relasedate =DateTime.Now, Price = 100  , Genre = "Action" , Imageurl = "https://placehold.co/400"},
    new Game { Id = 2, Name = "Game 2", Relasedate = DateTime.Now, Price = 200 , Genre = "Action" , Imageurl = "https://placehold.co/400" },
    new Game { Id = 3, Name = "Game 3", Relasedate = DateTime.Now, Price = 300 , Genre = "Action" , Imageurl = "https://placehold.co/400" }
};


    // create new router endpoints
    public static RouteGroupBuilder routeGroupBuilder(this IEndpointRouteBuilder routes)
    {

        routes.MapGet("/", () => "home page is here...");

        // group all the routes

        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", () => games);
        group.MapGet("/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

        // post request
        routes.MapPost("/Addgames", (Game game) =>
        {
            // make the id dynmic 
            game.Id = games.Max(game => game.Id) + 1;

            // add the new game to the list of games
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { Id = game.Id }, game);
        }).WithParameterValidation();
        // put request

        routes.MapPut("/UpdateGames/{id}", (int id, Game game) =>
        {
            var existingGame = games.Find(game => game.Id == id);
            if (existingGame != null)
            {
                existingGame.Name = game.Name;
                existingGame.Relasedate = game.Relasedate;
                existingGame.Price = game.Price;
                existingGame.Genre = game.Genre;
                existingGame.Imageurl = game.Imageurl;
                return Results.NoContent();
            }
            else
            {
                return Results.NotFound();
            }
        }).WithParameterValidation();

        // delete request

        routes.MapDelete("/DeleteGames/{id}", (int id) =>
        {
            Game? existingGame = games.Find(game => game.Id == id);
            if (existingGame != null)
            {
                games.Remove(existingGame);
                return Results.NoContent();
            }
            else
            {
                return Results.NotFound();
            }
        });
        return group;
    }

}
