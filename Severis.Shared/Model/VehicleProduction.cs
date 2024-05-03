using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Shared.Model
{
    public static class VehicleProdColumn
    {
        public static int DOMEXP = 0;
        public static int Year0 = 1;
        public static int Year1 = 2;
        public static int Year2 = 3;
        public static int Year3 = 4;
        public static int Year4 = 5;
        public static int Year5 = 6;
        public static int Year6 = 7;
        public static int Year7 = 8;
        public static int Year8 = 9;
        public static int Year9 = 10;
    }
    public class VehicleProduction
    {
        public string UploadFileId { get; set; }
        [DisplayName("DOM/EXP")]
        public string DOMEXP { get; set; }
        [DisplayName("Year0")]
        public decimal Year0 { get; set; }
        [DisplayName("Year1")]
        public decimal Year1 { get; set; }
        [DisplayName("Year2")]
        public decimal Year2 { get; set; }
        [DisplayName("Year3")]
        public decimal Year3 { get; set; }
        [DisplayName("Year4")]
        public decimal Year4 { get; set; }
        [DisplayName("Year5")]
        public decimal Year5 { get; set; }
        [DisplayName("Year6")]
        public decimal Year6 { get; set; }
        [DisplayName("Year7")]
        public decimal Year7 { get; set; }
        [DisplayName("Year8")]
        public decimal Year8 { get; set; }
        [DisplayName("Year9")]
        public decimal Year9 { get; set; }
    }
}
