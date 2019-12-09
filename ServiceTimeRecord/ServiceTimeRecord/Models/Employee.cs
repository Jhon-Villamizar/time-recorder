using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiceTimeRecord.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(40)]
        public string name { get; set; }
        [Required]
        [MaxLength(10)]
        public string password { get; set; }
        public ICollection<Task> tasks { get; set; }
    }
}