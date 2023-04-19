namespace JoeyRcgTryOut.Infrastructure.WebMessages.Requests
{
    using Newtonsoft.Json;

    public class EncodingViaHubWebRequest
    {
        [JsonProperty]
        public string ConnectionId { get; set; } = string.Empty;

        [JsonProperty]
        public string Message { get; set; } = string.Empty;
    }
}
