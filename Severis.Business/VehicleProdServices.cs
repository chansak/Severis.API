using Severis.DataAccess;
using Severis.DataAccess.Models.DB;
using Severis.Model.Response;
using Severis.Shared;
using Severis.Shared.Mapping;
using Severis.Shared.Model;

namespace Severis.Business
{
    public interface IVehicleProdServices
    {
        void AddUploadFileJob(UploadFileJob entity);
        void AddEstimateTotalVehicleProd(List<EstimateTotalVehicleProduction> entities);
        void AddUploadFileErrorMessage(UploadFileErrorMessage entity);
        List<UploadedFileResponse> SearchFilesByYearAndVersion(string year, string version);
        UploadFileErrorMessage GetErrorMessage(Guid id);
        List<VehicleProductionResponse> GetEstimateTotalVehicleProdByYearAndVersion(string uploadFileId);
        int GetNextFileVersion(string year);
        Guid GetOemIdByName(string name);
    }
    public class VehicleProdServices : IVehicleProdServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITimeProvider timeProvider;

        public VehicleProdServices(IUnitOfWork unitOfWork, ITimeProvider timeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.timeProvider = timeProvider;
        }

        public void AddEstimateTotalVehicleProd(List<EstimateTotalVehicleProduction> entities)
        {
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedDate = this.timeProvider.Now;
                this.unitOfWork.EstimateTotalVehicleProduction.Add(entity);
            }
            this.unitOfWork.Complete();
        }

        public void AddUploadFileErrorMessage(UploadFileErrorMessage entity)
        {
            this.UpdateDoneStatus(entity.UploadFileJobId.Value, this.unitOfWork);
            this.unitOfWork.UploadFileErrorMessage.Add(entity);
            this.unitOfWork.Complete();
        }

        public void AddUploadFileJob(UploadFileJob entity)
        {
            entity.CreatedDate = this.timeProvider.Now;
            this.unitOfWork.UploadFileJob.Add(entity);
            this.unitOfWork.Complete();
        }

        public UploadFileErrorMessage GetErrorMessage(Guid id)
        {
            return this.unitOfWork.UploadFileErrorMessage.GetErrorMessagesByUploadFileJobId(id);
        }

        public List<VehicleProductionResponse> GetEstimateTotalVehicleProdByYearAndVersion(string uploadFileId)
        {
            var result = new List<VehicleProductionResponse>();
            var UploadFileId = new Guid(uploadFileId);
            var uploadFileInfo = this.unitOfWork.UploadFileJob.GetById(UploadFileId);
            var uploadData = this.unitOfWork.EstimateTotalVehicleProduction.SearchByUploadFileId(UploadFileId);
            var distinctOemIds = uploadData.Select(i => i.OemId).Distinct();
            foreach (var OemId in distinctOemIds)
            {
                result.Add(uploadData.Where(i => i.OemId == OemId.Value).OrderBy(o => o.Year).ToList().ToViewModelWithYear(uploadFileInfo.Year.Value));
            }
            return result;
        }

        public int GetNextFileVersion(string year)
        {
            var Year = int.Parse(year);
            var nextVersion = 0;
            var uploadFiles = this.unitOfWork.UploadFileJob.Find(i => i.Year == Year && i.IsDone);
            if (uploadFiles.Count() > 0)
            {
                nextVersion = uploadFiles.Select(i => i.Version.Value).Max() + 1;
            }
            else
            {
                nextVersion = 1;
            }
            return nextVersion;
        }

        public Guid GetOemIdByName(string name)
        {
            return this.unitOfWork.Oem.Find(i => i.OemName.Contains(name)).FirstOrDefault().OemId;
        }

        public List<UploadedFileResponse> SearchFilesByYearAndVersion(string year, string version)
        {
            return this.unitOfWork.UploadFileJob.SearchFilesByYearAndVersion(year, version).ToViewModel();
        }
        private void UpdateDoneStatus(Guid id, IUnitOfWork uow)
        {
            var uploadJob = uow.UploadFileJob.GetById(id);
            uploadJob.UpdatedDate = this.timeProvider.Now;
            uploadJob.IsDone = true;
        }
    }
}