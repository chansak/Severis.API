using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Shared.Model
{
    public enum ProcessType
    {
        Undefined,
        VehicleProduction,
        TireDemand,
        SalesDemand
    }
    public enum ProcessStatus
    {
        Undefined,
        Start,
        Terminate,
        DoneWithfailure,
        DoneSuccess
    }
    public enum UploadFileSteps
    {
        Undefined,
        Upload,
        HeaderValidation,
        DataValidation,
        DataTransformation,
        Notification,
        Done
    }
}
