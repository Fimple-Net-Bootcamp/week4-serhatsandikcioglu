using System.Text.Json.Serialization;


namespace VirtualPetCare.Shared.DTOs;

public class ErrorDTO
{
    [JsonPropertyName("errorcode")] public int ErrorCode { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("details")] public List<string> Details { get; set; }

    [JsonPropertyName("stacktrace")] public string? StackTrace { get; set; }
}
