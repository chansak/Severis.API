using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Severis.DataAccess.Models.DB
{
    [Table("CarGroup")]
    public partial class CarGroup
    {
        [Key]
        [Column("CarGroup_ID")]
        public Guid CarGroupId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }
    }
}
