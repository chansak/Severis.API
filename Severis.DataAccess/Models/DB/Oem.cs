using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Severis.DataAccess.Models.DB
{
    [Table("OEM")]
    public partial class Oem
    {
        public Oem()
        {
            EstimateTotalVehicleProductions = new HashSet<EstimateTotalVehicleProduction>();
        }

        [Key]
        [Column("OEM_ID")]
        public Guid OemId { get; set; }
        [Column("OEM_Code")]
        [StringLength(50)]
        public string OemCode { get; set; }
        [Column("OEM_Name")]
        [StringLength(50)]
        public string OemName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }

        [InverseProperty(nameof(EstimateTotalVehicleProduction.Oem))]
        public virtual ICollection<EstimateTotalVehicleProduction> EstimateTotalVehicleProductions { get; set; }
    }
}
