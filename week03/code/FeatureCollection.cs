public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    public Feature[] Features { get; set; } = Array.Empty<Feature>();
}

public class Feature
{
    public Properties Properties { get; set; } = new Properties();
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; } = string.Empty;
}