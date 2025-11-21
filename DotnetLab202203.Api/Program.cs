using System.ComponentModel.DataAnnotations;
using DotnetLab202203.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.Services.AddSingleton<IStarshipRepository, InMemoryStarshipRepository>();

var app = builder.Build();

app.MapGet("/api/starship", (IStarshipRepository repository) =>
{
    var starships = repository.GetAll();
    return Results.Ok(starships);
})
.WithName("GetStarships")
.Produces<IReadOnlyList<Starship>>(StatusCodes.Status200OK);

app.MapGet("/api/starship/{index:int}", (int index, IStarshipRepository repository) =>
{
    if (!repository.TryGet(index, out var starship))
    {
        return Results.NotFound();
    }

    return Results.Ok(starship);
})
.WithName("GetStarshipByIndex")
.Produces<Starship>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPost("/api/starship", (Starship starship, IStarshipRepository repository) =>
{
    //if (!MinimalValidation.TryValidate(starship, out var errors))
    //{
    //    return Results.ValidationProblem(errors);
    //}

    var index = repository.Add(starship);
    return Results.Created($"/api/starship/{index}", starship);
})
.WithName("CreateStarship")
.Produces<Starship>(StatusCodes.Status201Created);
//.ProducesValidationProblem();

app.Run();

internal interface IStarshipRepository
{
    IReadOnlyList<Starship> GetAll();
    bool TryGet(int index, out Starship starship);
    int Add(Starship starship);
}

internal sealed class InMemoryStarshipRepository : IStarshipRepository
{
    private readonly List<Starship> _starships = new()
    {
        new Starship
        {
            Name = "Millennium Falcon",
            Model = "YT-1300f",
            Manufacturer = "Corellian Engineering Corporation",
            StarshipClass = "Light Freighter",
            Destination = new ShipDestination
            {
                Description = "Deliver cargo to Cloud City",
                Planet = "Bespin"
            }
        },
    };

    public IReadOnlyList<Starship> GetAll() => _starships;

    public bool TryGet(int index, out Starship starship)
    {
        if (index < 0 || index >= _starships.Count)
        {
            starship = default!;
            return false;
        }

        starship = _starships[index];
        return true;
    }

    public int Add(Starship starship)
    {
        _starships.Add(starship);
        return _starships.Count - 1;
    }
}

internal static class MinimalValidation
{
    public static bool TryValidate<T>(T instance, out Dictionary<string, string[]> errors)
    {
        var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        var context = new ValidationContext(instance!);
        var isValid = Validator.TryValidateObject(instance!, context, validationResults, validateAllProperties: true);

        errors = validationResults
            .SelectMany(result =>
            {
                var members = result.MemberNames.Any() ? result.MemberNames : new[] { string.Empty };
                return members.Select(member => (member, Message: result.ErrorMessage ?? "Validation error."));
            })
            .GroupBy(item => item.member, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => group.Select(item => item.Message).ToArray(),
                StringComparer.OrdinalIgnoreCase);

        return isValid;
    }
}
