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
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Hours { get; set; }
        public Task Task { get; set; }
    }
}