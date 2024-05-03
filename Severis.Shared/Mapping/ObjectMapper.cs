using Severis.Model.Response;
using Severis.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db = Severis.DataAccess.Models.DB;

namespace Severis.Shared.Mapping
{
    public static class ObjectMapper
    {
        //Manual model mapping
        #region "ToEntity"
        public static List<Db.EstimateTotalVehicleProduction> ToEntitiesByYear(this VehicleProduction item, int year)
        {
            var currentYear = year.Equals(0) ? DateTime.Now.Year : year;
            var oemId = new Guid(item.DOMEXP);
            var result = new List<Db.EstimateTotalVehicleProduction>();
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear,
                Amount = item.Year0
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 1,
                Amount = item.Year1
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 2,
                Amount = item.Year2
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 3,
                Amount = item.Year3
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 4,
                Amount = item.Year4
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 5,
                Amount = item.Year5
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 6,
                Amount = item.Year6
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 7,
                Amount = item.Year7
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 8,
                Amount = item.Year8
            });
            result.Add(new Db.EstimateTotalVehicleProduction
            {
                UploadFileId = new Guid(item.UploadFileId),
                OemId = oemId,
                Year = currentYear + 9,
                Amount = item.Year9
            });
            return result;
        }
        #endregion

        #region "ToViewModel"
        //TODO: group data by OemId and UploadFile_ID
        public static VehicleProductionResponse ToViewModelWithYear(this List<Db.EstimateTotalVehicleProduction> entities,int year)
        {
            var currentYear = DateTime.Now.Year;
            var mockup = new List<Db.EstimateTotalVehicleProduction>();
            return new VehicleProductionResponse
            {
                DOMEXP = entities.FirstOrDefault().Oem.OemName,
                Year0 = (decimal)entities.FirstOrDefault(i => i.Year == currentYear).Amount.Value,
                Year1 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 1)).Amount.Value,
                Year2 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 2)).Amount.Value,
                Year3 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 3)).Amount.Value,
                Year4 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 4)).Amount.Value,
                Year5 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 5)).Amount.Value,
                Year6 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 6)).Amount.Value,
                Year7 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 7)).Amount.Value,
                Year8 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 8)).Amount.Value,
                Year9 = (decimal)entities.FirstOrDefault(i => i.Year == (currentYear + 9)).Amount.Value,
            };
        }
        public static UploadedFileResponse ToViewModel(this Db.UploadFileJob item)
        {
            return new UploadedFileResponse
            {
                UploadFileId = item.UploadFileId,
                FileName = item.OriginalFileName,
                Year = item.Year,
                Version = item.Version,
                StatusId = item.StatusId,
                IsDone = item.IsDone,
                CreatedDate = item.CreatedDate
            };
        }
        public static List<UploadedFileResponse> ToViewModel(this List<Db.UploadFileJob> items)
        {
            var result = new List<UploadedFileResponse>();
            var models = items.Select(i => i.ToViewModel());
            result.AddRange(models);
            return result;
        }
        #endregion
    }
}
