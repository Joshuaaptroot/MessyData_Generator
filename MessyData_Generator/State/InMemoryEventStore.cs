using MessyData_Generator.Generator;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Messy Data Generator is running.");

app.MapGet("/events", (int count) =>
{
    var eventFactory = new EventFactory();
    var messyJsonEmitter = new MessyJsonEmitter();

    var messyEvents = new List<Dictionary<string, object?>>();

    for (int i = 0; i < count; i++)
    {
        var cleanEvent = eventFactory.CreateEvent();
        var messyEvent = messyJsonEmitter.Emit(cleanEvent);
        messyEvents.Add(messyEvent);
    }

    return Results.Ok(messyEvents);
});

app.Run();