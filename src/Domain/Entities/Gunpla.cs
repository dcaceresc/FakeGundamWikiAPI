namespace Domain.Entities;
public class Gunpla
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string japaneseName { get; set; } = null!;
    public string subtitle { get; set; } = null!;
    public DateTime releaseDate { get; set; }
    public int lineupNumber { get; set; }
}
