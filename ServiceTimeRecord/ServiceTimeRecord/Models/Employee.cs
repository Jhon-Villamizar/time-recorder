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
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}