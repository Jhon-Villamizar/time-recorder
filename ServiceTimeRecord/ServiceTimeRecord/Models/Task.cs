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
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Time> Times { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}