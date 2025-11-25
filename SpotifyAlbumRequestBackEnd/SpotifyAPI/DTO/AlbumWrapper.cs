using System.Text.Json.Serialization;

public class AlbumWrapper
{
    [JsonPropertyName("items")]
    public List<Album> Items { get; set; }
}
