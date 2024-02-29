using Microsoft.EntityFrameworkCore;
using SMSYS.Models;
namespace SMSYS.Data;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> opt) :base(opt)
    {
        
    }

    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Result> Result { get; set; }
    public DbSet<Exam> Exam { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<Classroom> Classroom { get; set; }
    public DbSet<Classroom_Student> Classroom_Student { get; set; }



}
