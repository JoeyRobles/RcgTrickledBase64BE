namespace JoeyRcgTryOut.Services.Encoding
{
    using JoeyRcgTryOut.Infrastructure.Exceptions;
    using JoeyRcgTryOut.Infrastructure.Messages.Requests;
    using JoeyRcgTryOut.Infrastructure.Services;
    using JoeyRcgTryOut.Services.Encoding.Hubs;
    using Microsoft.AspNetCore.SignalR;

    public class EncodingService : IEncodingService
    {
        private readonly IHubContext<EncodingHub> hubContext;

        public EncodingService(IHubContext<EncodingHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task EncodeStringWithRandomDelayAsync(EncodingViaHubRequest request)
        {
            try
            {
                var sampleBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(request.Message));
                var random = new Random();
                for (int i = 0; i < sampleBase64.Length; i++)
                {
                    var sampleLetter = sampleBase64[i];
                    await Task.Delay(random.Next(1000, 5000));
                    await this.hubContext.Clients.Client(request.ConnectionId).SendAsync("ReceiveMessage", sampleLetter);
                }

                await this.hubContext.Clients.Client(request.ConnectionId).SendAsync("ReceiveMessage", "end");
            }
            catch (Exception e) 
            {
                throw new EncodingException("Exception in Encoding Service", e);
            }
        }
    }
}