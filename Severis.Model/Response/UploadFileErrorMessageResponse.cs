using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Model.Response
{
    public class UploadFileErrorMessageResponse
    {
        public string UploadFileJobId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
