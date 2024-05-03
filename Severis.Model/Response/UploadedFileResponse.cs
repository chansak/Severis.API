using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Model.Response
{
    public class UploadedFileResponse
    {
        public Guid UploadFileId { get; set; }
        public string FileName { get; set; }
        public int? StatusId { get; set; }
        public bool IsDone { get; set; }
        public string StatusText
        {
            get
            {
                var statusText = string.Empty;
                var doneText = string.Empty;
                this.StatusId = (this.StatusId) ?? 0;
                if (this.IsDone)
                {
                    if(this.StatusId.Value.Equals(6)) 
                        doneText = "Done";
                    else
                        doneText = "Done with error ({0})";
                }
                else {
                    doneText = "In Process ({0})";
                }
                switch (this.StatusId.Value)
                {
                    case 0:
                        {
                            statusText = "Undefined";
                            break;
                        }
                    case 1:
                        {
                            statusText = "File uploaded";
                            break;
                        }
                    case 2:
                        {
                            statusText = "Teamplate validation";
                            break;
                        }
                    case 3:
                        {
                            statusText = "Data validation";
                            break;
                        }
                    case 4:
                        {
                            statusText = "Data transformation";
                            break;
                        }
                    case 5:
                        {
                            statusText = "Email notification";
                            break;
                        }
                    case 6:
                        {
                            statusText = "";
                            break;
                        }
                }
                return string.Format(doneText,statusText);
            }
        }
        public int? Year { get; set; }
        public int? Version { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
