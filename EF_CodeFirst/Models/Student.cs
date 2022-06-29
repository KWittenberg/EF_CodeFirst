using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirst.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [DisplayName("Student Name")]
        [Column(TypeName = "nchar(100)")]
        public string StudentName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public decimal Height { get; set; }
        public float Weight { get; set; }
    }
}
