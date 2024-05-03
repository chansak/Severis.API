using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Severis.DataAccess.Models.DB
{
    [Table("UploadFileJob")]
    public partial class UploadFileJob
    {
        [Key]
        [Column("UploadFile_ID")]
        public Guid UploadFileId { get; set; }
        [StringLength(50)]
        public string OriginalFileName { get; set; }
        [StringLength(50)]
        public string NewFileName { get; set; }
        public int? StatusId { get; set; }
        public int? Year { get; set; }
        public int? Version { get; set; }
        public bool? IsActive { get; set; }
        public int? ApplicationModule { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }
        public bool IsDone { get; set; }
    }
}
