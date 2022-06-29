using EF_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grade { get; set; }





        /// <summary>
        /// Seed
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();


                //context.Database.Migrate();
                context.Database.EnsureCreated();



                // Student
                if (!context.Student.Any())
                {
                    context.Student.AddRange(new List<Student>()
                    {
                        new Student() { StudentName = "Ana Anić", DateOfBirth = DateTime.Now.AddYears(-20), Height = 160, Weight = 50 },
                        new Student() { StudentName = "Ivo Ivić", DateOfBirth = DateTime.Now.AddYears(-22), Height = 185, Weight = 85 },
                        new Student() { StudentName = "Kata Katić", DateOfBirth = DateTime.Now.AddYears(-23), Height = 179, Weight = 62 },
                        new Student() { StudentName = "Pero Perić", DateOfBirth = DateTime.Now.AddYears(-21), Height = 187, Weight = 92 },
                    });
                    context.SaveChanges();
                }

                // Grade
                if (!context.Grade.Any())
                {
                    context.Grade.AddRange(new List<Grade>()
                    {
                        new Grade() { GradeName = "A", Section = "C# i .NET Framework: osnovno korištenje", StudentId = 1 },
                        new Grade() { GradeName = "B", Section = "C# i .NET Framework: napredno korištenje", StudentId = 2 },
                        new Grade() { GradeName = "C", Section = "LINQ", StudentId = 3 },
                        new Grade() { GradeName = "D", Section = "ASP.NET Core MVC i Visual Studio", StudentId = 4 },
                        new Grade() { GradeName = "E", Section = "Unit Testing", StudentId = 2 },
                        new Grade() { GradeName = "F", Section = "ASP.NET Core MVC u praksi: Postavljanje projekta", StudentId = 3 },
                        new Grade() { GradeName = "G", Section = "ASP.NET Core MVC u praksi: Entity Framework", StudentId = 1 },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
