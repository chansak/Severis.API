using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Severis.DataAccess.Models.DB
{
    [Table("UploadFileErrorMessage")]
    public partial class UploadFileErrorMessage
    {
        [Key]
        [Column("UploadFileErrorMessage_ID")]
        public Guid UploadFileErrorMessageId { get; set; }
        [Column("UploadFileJob_ID")]
        public Guid? UploadFileJobId { get; set; }
        [Column(TypeName = "text")]
        public string ErrorMessage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }
    }
}
