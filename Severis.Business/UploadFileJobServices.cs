using Severis.DataAccess;
using Severis.DataAccess.Models.DB;
using Severis.Model.Request;

namespace Severis.Business
{
    public interface IUploadFileJobServices
    {
        void UpadateStatus(Guid id, int status);
        void MarkAsDone(Guid id);
        void MarkAsDoneWithFailure(Guid id);
        UploadFileJob GetJobInfo(Guid id);

    }
    public class UploadFileJobServices : IUploadFileJobServices
    {
        private readonly IUnitOfWork unitOfWork;

        public UploadFileJobServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void MarkAsDoneWithFailure(Guid id)
        {
            var item = this.unitOfWork.UploadFileJob.GetById(id);
            item.IsDone = true;
            this.unitOfWork.Complete();
        }

        public void MarkAsDone(Guid id)
        {
            var item = this.unitOfWork.UploadFileJob.GetById(id);
            item.IsDone = true;
            this.unitOfWork.Complete();
        }

        public void UpadateStatus(Guid id, int status)
        {
            var item = this.unitOfWork.UploadFileJob.GetById(id);
            item.StatusId = status;
            this.unitOfWork.Complete();
        }

        public UploadFileJob GetJobInfo(Guid id)
        {
            return this.unitOfWork.UploadFileJob.GetById(id);
        }
    }
}