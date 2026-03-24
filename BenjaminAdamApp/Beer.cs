using System.Text.Json.Serialization;

namespace BenjaminAdamApp;

public class Beer
{
    [JsonPropertyName("name")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public string ImageUrl { get; set; } = string.Empty;
}
