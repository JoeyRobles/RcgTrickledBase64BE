namespace JoeyRcgTryOut.Services.Encoding.Tests.Stubs
{
    using Microsoft.AspNetCore.SignalR;

    public class StubIClientProxy : IClientProxy
    {
        public Task SendCoreAsync(string method, object[] args, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(0);
        }
    }
}
