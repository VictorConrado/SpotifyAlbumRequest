using System.Text.Json.Serialization;

public class Album
{
    public string Id { get; set; }
    public string Name { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
}
