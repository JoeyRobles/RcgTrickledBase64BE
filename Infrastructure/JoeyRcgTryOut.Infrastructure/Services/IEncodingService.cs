namespace JoeyRcgTryOut.Infrastructure.Services
{
    using JoeyRcgTryOut.Infrastructure.Messages.Requests;

    public interface IEncodingService
    {
        Task EncodeStringWithRandomDelayAsync(EncodingViaHubRequest request);
    }
}
