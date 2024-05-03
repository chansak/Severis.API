using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Model.Request
{
    public class UploadFileInfoRequest
    {
        public int Year { get; set; }
        public int Version { get; set; }
        public string NewFileName { get; set; }
    }
}
