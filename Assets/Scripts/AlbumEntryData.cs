using Newtonsoft.Json;

public class AlbumEntryData
{
    [JsonProperty(Required = Required.Always)] public readonly int Id;
    [JsonProperty(Required = Required.Always)] public readonly int AlbumId;
    [JsonProperty(Required = Required.Always)] public readonly string Title;
    [JsonProperty(Required = Required.Always)] public readonly string Url;
    [JsonProperty(Required = Required.Always)] public readonly string ThumbnailUrl;
}
