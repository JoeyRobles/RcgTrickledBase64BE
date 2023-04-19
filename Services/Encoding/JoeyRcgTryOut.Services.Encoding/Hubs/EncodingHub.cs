namespace JoeyRcgTryOut.Services.Encoding.Hubs
{
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.AspNetCore.SignalR;

    [HubName("EncodingHub")]
    public class EncodingHub : Hub
    {
        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
