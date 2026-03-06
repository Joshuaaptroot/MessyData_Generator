namespace MessyData_Generator.Generator;

public class MessConfig
{
    public double SchemaV1Rate { get; set; } = 0.4;
    public double SchemaV2Rate { get; set; } = 0.35;
    public double SchemaV3Rate { get; set; } = 0.25;

    public double MissingFieldRate { get; set; } = 0.1;
    public double InvalidValueRate { get; set; } = 0.1;
    public double TypeDriftRate { get; set; } = 0.2;
    public double DuplicateRate { get; set; } = 0.05;
}
