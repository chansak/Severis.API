using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Shared.Model
{
    public class BaseNotification
    {
        public ProcessType ProcessType { get; set; }
        public ProcessStatus ProcessStatus { get; set; }
        public int TotalRows { get; set; }
        public int CompletedRows { get; set; }
        public double PercentageOfWork { get; set; }
    }
    public class PushNotification {
        public string ProcessType { get; set; }
        public string ProcessStatus { get; set; }
        public string TotalRows { get; set; }
        public string CompletedRows { get; set; }
        public string PercentageOfWork { get; set; }
    }
}
