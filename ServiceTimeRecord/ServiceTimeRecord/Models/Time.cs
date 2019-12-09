using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiceTimeRecord.Models
{
    [Table("Times")]
    public class Time
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int hours { get; set; }
        public Task task { get; set; }
        public int taskId { get; set; }
    }
}