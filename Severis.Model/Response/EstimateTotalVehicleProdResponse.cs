using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Model.Response
{
    public class EstimateTotalVehicleProdResponse
    {
        public string UploadFileId { get; set; }
        public int Year { get; set; }
        public int Version { get; set; }
        public List<VehicleProductionResponse> VehicleProds { get; set; }
    }
}
