namespace JoeyRcgTryOut.Infrastructure.Messages.Requests
{
    using Newtonsoft.Json;

    public class EncodingViaHubRequest
    {
        [JsonProperty]
        public string ConnectionId { get; set; } = string.Empty;

        [JsonProperty]
        public string Message { get; set; } = string.Empty;
    }
}
