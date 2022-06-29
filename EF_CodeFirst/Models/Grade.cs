using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EF_CodeFirst.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [DisplayName("Grade Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string GradeName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Section { get; set; }

        [ForeignKey("StudentId")]
        [ValidateNever]
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
