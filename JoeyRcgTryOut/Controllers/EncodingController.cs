namespace JoeyRcgTryOut.Controllers
{
    using JoeyRcgTryOut.Infrastructure.Messages.Requests;
    using JoeyRcgTryOut.Infrastructure.Services;
    using JoeyRcgTryOut.Infrastructure.WebMessages.Requests;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/encoding")]
    public class EncodingController : Controller
    {
        private readonly IEncodingService encodingService;


        public EncodingController(IEncodingService encodingService)
        {
            this.encodingService = encodingService;
        }

        [HttpPost]
        public async Task<IActionResult> EncodeViaHub([FromBody] EncodingViaHubWebRequest webRequest)
        {
            await this.encodingService.EncodeStringWithRandomDelayAsync(new EncodingViaHubRequest()
            {
                ConnectionId = webRequest.ConnectionId,
                Message = webRequest.Message,
            });

            return Ok();
        }
    }
}
