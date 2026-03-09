using MessyData_Generator.Models;
using MessyData_Generator.Generator;

namespace MessyData_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
           
            app.MapGet("/", () => "Messy Data Generator is running.");

            app.MapGet("/events", (int? count) =>
            {
                var eventFactory = new EventFactory();
                var messyJsonEmitter = new MessyJsonEmitter();

                var messyEvents = new List<Dictionary<string, object?>>();
                int numberOfEvents = count ?? 10;

                for (int i = 0; i < numberOfEvents; i++)
                {
                    var cleanEvent = eventFactory.CreateEvent();
                    var messyEvent = messyJsonEmitter.Emit(cleanEvent);
                    messyEvents.Add(messyEvent);
                }

                return Results.Ok(messyEvents);
            });

            app.MapControllers();

            app.Run();




        }
    }
}