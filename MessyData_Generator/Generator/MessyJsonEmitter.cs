using MessyData_Generator.Models;

namespace MessyData_Generator.Generator;

public class MessyJsonEmitter
{
    private readonly Random _random = new();

    public Dictionary<string, object?> Emit(CanonicalEvent canonicalEvent)
    {
        int schemaVersion = _random.Next(1, 4);

        return schemaVersion switch
        {
            1 => EmitSchemaV1(canonicalEvent),
            2 => EmitSchemaV2(canonicalEvent),
            3 => EmitSchemaV3(canonicalEvent),
            _ => EmitSchemaV1(canonicalEvent)
        };
    }

    private Dictionary<string, object?> EmitSchemaV1(CanonicalEvent Event)
    {
        return new Dictionary<string, object?>
        {
            ["event_id"] = Event.EventId,
            ["order_id"] = Event.OrderId,
            ["customer_id"] = Event.CustomerId,
            ["event_type"] = Event.EventType.ToString(),
            ["amount"] = Event.Amount,
            ["currency"] = Event.Currency,
            ["created_at"] = Event.CreatedAt
        };
    }

    private Dictionary<string, object?> EmitSchemaV2(CanonicalEvent Event)
    {
        return new Dictionary<string, object?>
        {
            ["eventId"] = Event.EventId.ToString(),
            ["orderId"] = Event.OrderId,
            ["customerId"] = Event.CustomerId.ToString(),
            ["type"] = Event.EventType.ToString().ToUpper(),
            ["amount"] = Event.Amount.ToString(),
            ["currency"] = Event.Currency,
            ["timestamp"] = Event.CreatedAt.ToUnixTimeMilliseconds()
        };
    }

    private Dictionary<string, object?> EmitSchemaV3(CanonicalEvent Event)
    {
        return new Dictionary<string, object?>
        {
            ["event"] = new Dictionary<string, object?>
            {
                ["id"] = Event.EventId,
                ["type"] = Event.EventType.ToString()
            },
            ["order"] = new Dictionary<string, object?>
            {
                ["id"] = Event.OrderId,
                ["customerId"] = Event.CustomerId
            },
            ["amount"] = Event.Amount,
            ["currency"] = Event.Currency,
            ["createdAt"] = Event.CreatedAt.ToString("O"),
            ["source"] = "messy-data-generator"
        };
    }
}