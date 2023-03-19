namespace Tickets.Models.Options;

public class ImageOptions
{
    public int Size { get; set; }
    public string? FolderPath { get; set; }
    public string[]? Allowed { get; set; }
}
