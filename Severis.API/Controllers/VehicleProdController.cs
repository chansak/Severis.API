using Severis.Business;
using Severis.DataAccess.Models.DB;
using Severis.Model.Request;
using Severis.Model.Response;
using Severis.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Severis.API.Controllers
{
    public class VehicleProdController : ControllerBase
    {
        private readonly IOptions<AppSettings>? settings;
        private readonly ILogger<VehicleProdController> logger;
        private readonly IWebHostEnvironment environment;
        private readonly IUploadFileJobServices uploadFileJobServices;
        private readonly IVehicleProdServices services;

        public VehicleProdController(
            IOptions<AppSettings>? settings,
            ILogger<VehicleProdController> logger,
            IWebHostEnvironment _environment,
            IUploadFileJobServices _uploadFileJobServices,
            IVehicleProdServices _services)
        {
            this.settings = settings;
            this.logger = logger;
            environment = _environment;
            uploadFileJobServices = _uploadFileJobServices;
            services = _services;
        }

        [HttpPost]
        [Route("VehicleProd/UploadFiles")]
        public async Task<IActionResult> UploadFiles(UploadFileInfoRequest uploadFileInfo, List<IFormFile> files)
        {
            var path = this.settings.Value.Step1_InputFolder;
            var successedDir = Path.Combine(path, "successed");
            var failedDir = Path.Combine(path, "failed");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(successedDir))
            {
                Directory.CreateDirectory(successedDir);
            }
            if (!Directory.Exists(failedDir))
            {
                Directory.CreateDirectory(failedDir);
            }
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileExtension = System.IO.Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(path, $"{uploadFileInfo.NewFileName}{fileExtension}");
                    this.services.AddUploadFileJob(new UploadFileJob
                    {
                        UploadFileId = new Guid(uploadFileInfo.NewFileName),
                        OriginalFileName = file.FileName,
                        NewFileName = $"{uploadFileInfo.NewFileName}{fileExtension}",
                        ApplicationModule = (int)ProcessType.VehicleProduction,
                        StatusId = (int)UploadFileSteps.Upload,
                        Year = uploadFileInfo.Year,
                        Version = uploadFileInfo.Version
                    });
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                }
            }
            return Ok(new { });
        }
        [HttpGet]
        [Route("VehicleProd/UploadFileJobTracking")]
        public object UploadFileJobTracking(string uploadFileId)
        {
            var data = this.services.GetErrorMessage(new Guid(uploadFileId));
            return data == null ? string.Empty : data.ErrorMessage;
        }
        [HttpPost]
        [Route("VehicleProd/SearchFilesByYearAndVersion")]
        public List<UploadedFileResponse> SearchFilesByYearAndVersion(string year, string version)
        {
            var data = this.services.SearchFilesByYearAndVersion(year, version).OrderByDescending(o => o.CreatedDate).ToList();
            return data;
        }
        [HttpGet]
        [Route("VehicleProd/GetEstimateTotalVehicleProd")]
        public EstimateTotalVehicleProdResponse GetEstimateTotalVehicleProdByYearAndVersion(string uploadFileId)
        {
            var jobInfo = this.uploadFileJobServices.GetJobInfo(new Guid(uploadFileId));
            var vehicleProds = this.services.GetEstimateTotalVehicleProdByYearAndVersion(uploadFileId);
            return new EstimateTotalVehicleProdResponse
            {
                UploadFileId = uploadFileId,
                Year = jobInfo.Year.Value,
                Version = jobInfo.Version.Value,
                VehicleProds = vehicleProds
            };
        }
        [HttpGet]
        [Route("VehicleProd/GetNextFileVersion")]
        public int GetNextFileVersion(string year)
        {
            return this.services.GetNextFileVersion(year);
        }
    }
}
