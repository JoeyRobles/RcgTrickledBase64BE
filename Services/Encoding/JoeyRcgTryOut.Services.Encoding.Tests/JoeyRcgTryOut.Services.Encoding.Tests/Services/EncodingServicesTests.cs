namespace JoeyRcgTryOut.Services.Encoding.Tests.Services
{
    using JoeyRcgTryOut.Infrastructure.Exceptions;
    using JoeyRcgTryOut.Infrastructure.Messages.Requests;
    using JoeyRcgTryOut.Services.Encoding.Hubs;
    using JoeyRcgTryOut.Services.Encoding.Tests.Stubs;
    using Microsoft.AspNetCore.SignalR;
    using Moq;


    [TestClass]
    public class EncodingServicesTests
    {
        private Mock<IHubContext<EncodingHub>> hubContext;
        private EncodingService service;

        [TestInitialize] 
        public void Initialize() 
        {
            this.hubContext = new Mock<IHubContext<EncodingHub>>();
            this.service = new EncodingService(this.hubContext.Object);
        }

        [TestMethod]
        public async Task EncodeStringWithRandomDelayAsync_ValidInput_DoesNotThrowException()
        {
            var request = new EncodingViaHubRequest()
            {
                ConnectionId = "test",
                Message = "t"
            };
            this.hubContext.Setup(x => x.Clients).Returns(new StubIHubClient());
            await this.service.EncodeStringWithRandomDelayAsync(request);
        }

        [TestMethod]
        [ExpectedException(typeof(EncodingException))]
        public async Task EncodeStringWithRandomDelayAsync_InvalidInput_ThrowsException()
        {
            var request = new EncodingViaHubRequest()
            {
                ConnectionId = "test",
                Message = ""
            };
            this.hubContext.Setup(x => x.Clients).Throws(new EncodingException());
            await this.service.EncodeStringWithRandomDelayAsync(request);
        }
    }
}