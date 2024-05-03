using System.Threading.Tasks;
using Severis.DataAccess;
using Severis.Shared.Model;
using Microsoft.AspNetCore.SignalR;
namespace Severis.API.Hubs
{
    public class NotifyHub : Hub
    {
        public int status = 0;
        private readonly IUnitOfWork unitOfWork;

        public NotifyHub(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task UploadFileTracking(string id, string connectionId)
        {
            var uploadFileJob = this.unitOfWork.UploadFileJob.GetById(new Guid(id));
            await Clients.Client(connectionId).SendAsync("UploadFileTracking",uploadFileJob);
        }
        public string GetConnectionId() => Context.ConnectionId;


    }
}
