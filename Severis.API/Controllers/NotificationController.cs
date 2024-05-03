using Severis.API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Severis.Shared.Model;
namespace Severis.API.Controllers
{
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly IHubContext<NotifyHub> hubContext;
        public NotificationController(ILogger<NotificationController> logger, IHubContext<NotifyHub> hubContext)
        {
            _logger = logger;
            this.hubContext = hubContext;
        }
        //TODO uncomment below for the service to be called from Worker service.
        //[HttpPost]
        //[Route("Notification/PushMessage")]
        //public async Task NotifyMessage(PushNotification message)
        //{
        //    await this.hubContext.Clients.All.SendAsync("PushMessage", "test");
        //}
        [HttpPost]
        [Route("Notification/Test")]
        public void Test(string test)
        {
            var message = test;
        }
    }
}
