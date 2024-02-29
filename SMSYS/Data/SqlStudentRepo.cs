using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SMSYS.Dtos;
using SMSYS.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace SMSYS.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        

        public SqlStudentRepo(StudentContext context) 
        {

            _context = context;

            getMaleStudent();
        
        }

        public void getMaleStudent() {

            var maleStudent = _context.Student.Where(std => std.Sex == "male");
            if (maleStudent != null) 
            {
                foreach (var item in maleStudent)
                {

                   var student1 =  item.Sex;
                    Console.WriteLine(student1);
                }


            }
            
            

        
        
        }


        

        public IEnumerable<Student> GetStudents()
        {
           return _context.Student.ToList();
        }
        public Student GetStudentById(int id)
        {
            return _context.Student.FirstOrDefault(p => p.Student_ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
          
        }

        public void CreateStudent(Student student)
        {
           if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Student.Add(student);

        }
        public void UpdateStudent(Student student)
        {

        }

        public void DeleteStudent(Student student) 
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
           
            var studentResultDto = GetStudentResultByStudentID(student.Student_ID);
            if (studentResultDto != null)
            {
                foreach (var item in studentResultDto)
                {
                    _context.Result.Remove(item);
                }
            }
            _context.Student.Remove(student);


            _context.SaveChanges();

        }

        public IEnumerable<Result> GetStudentResultByStudentID(int stdId)
        {

            var studentResultDto = (from student in _context.Student
                                    join result in _context.Result on student.Student_ID equals result.Student_ID
                                    where result.Student_ID == stdId
                                    select new Result
                                    {
                                        Student_ID = student.Student_ID,
                                        Obtain_marks = result.Obtain_marks,
                                        Total_marks = result.Total_marks
                                    }).ToList();
            return studentResultDto;

        }

        public IEnumerable<StudentResultDto> GetStudentResults() {

            var studentResultDto = (from student in _context.Student
                                    join result in _context.Result on student.Student_ID equals result.Student_ID
                                    join exam in _context.Exam on result.Exam_ID equals exam.Exam_ID
                                    select new StudentResultDto
                                    {
                                        Percentage = result.Total_marks != 0 ? Math.Round((double)result.Obtain_marks / result.Total_marks * 100, 2).ToString("0.00") + "%" : "0.00%",
                                        Obtain_marks = result.Obtain_marks,
                                        Total_marks = result.Total_marks
                                    }).ToList();
            return studentResultDto;

        }


    }
}
