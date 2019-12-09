using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiceTimeRecord.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(40)]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public ICollection<Time> times { get; set; }
        public Employee employee { get; set; }
        public int employeeId { get; set; }
    }
}