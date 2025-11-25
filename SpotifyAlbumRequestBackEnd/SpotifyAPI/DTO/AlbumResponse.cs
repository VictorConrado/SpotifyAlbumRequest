using System.Text.Json.Serialization;

public class AlbumResponse
{
    [JsonPropertyName("albums")]
    public AlbumWrapper Albums { get; set; }
}
