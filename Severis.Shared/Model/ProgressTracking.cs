using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Shared.Model
{
    public class ProgressTracking
    {
        public string FileId { get; set; }
        public FileUploadErrorMessages FileUploadErrorMessages { get; set; }
    }
    public class FileUploadErrorMessages
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}
