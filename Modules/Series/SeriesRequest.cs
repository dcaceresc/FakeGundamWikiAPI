namespace FakeGundamWikiAPI.Modules.Series;

public class CreateSeriesRequest
{
    public string SerieName { get; set; } = null!;
    public int UniverseId { get; set; }
}

public class UpdateSeriesRequest
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public int UniverseId { get; set; }
}