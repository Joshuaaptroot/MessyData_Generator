using MessyData_Generator.Models;

namespace MessyData_Generator.Generator;

public class EventFactory
{
    private readonly Random _random = new Random();

    public CanonicalEvent CreateEvent()
    {
        return new CanonicalEvent
        {
            EventId = Guid.NewGuid(),
            OrderId = $"ORD-{_random.Next(1000, 9999)}",
            CustomerId = _random.Next(1, 100),
            EventType = (EventType)_random.Next(Enum.GetValues<EventType>().Length),
            Amount = Math.Round((decimal)(_random.NextDouble() * 1000), 2),
            Currency = "GBP",
            CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-_random.Next(0, 60))
        };
    }
}