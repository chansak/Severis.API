using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Severis.DataAccess.Models.DB
{
    [Table("Model")]
    public partial class Model
    {
        [Key]
        [Column("Model_ID")]
        public Guid ModelId { get; set; }
        [Column("OEM_ID")]
        public Guid? OemId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "numeric(4, 0)")]
        public decimal? Year { get; set; }
        [Column("CarGroup_ID")]
        public Guid? CarGroupId { get; set; }
        public bool? Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }
    }
}
