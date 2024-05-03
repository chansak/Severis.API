using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Severis.DataAccess.Models.DB
{
    [Table("EstimateTotalVehicleProduction")]
    public partial class EstimateTotalVehicleProduction
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("OEM_ID")]
        public Guid? OemId { get; set; }
        [Column("UploadFile_ID")]
        public Guid? UploadFileId { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Year { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }

        [ForeignKey(nameof(OemId))]
        [InverseProperty("EstimateTotalVehicleProductions")]
        public virtual Oem Oem { get; set; }
    }
}
