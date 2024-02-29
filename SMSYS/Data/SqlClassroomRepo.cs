using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SMSYS.Dtos;
using SMSYS.Models;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace SMSYS.Data
{
    public class SqlClassroomRepo : IClassroomRepo
    {
        private readonly  StudentContext _context;

        public SqlClassroomRepo(StudentContext context)
        {

            _context = context;

        }


        public static string calulateGrade(int marks) {

            if (marks > 90)

            { 
                return "A";
            }
            else if (marks > 80)
            {
                return "B";
            }
            else if (marks > 70)
            {
                return "C";
            }
            else if (marks > 50)
            {
                return "D";
            }
            else
            {
                return "F";
            }

        }

       public IEnumerable<ClassroomResultDto> getStudentResultsByClassroomId(int classroomId)
        {
            var classroomResultDto =(from std in _context.Student join )

       /*     var classroomResultDto = (from result in _context.Result
                                      join exam in _context.Exam on result.Exam_ID equals exam.Exam_ID
                                      join cls in _context.Classroom on exam.Classroom_ID equals cls.Classroom_ID
                                      join std in _context.Student on result.Student_ID equals std.Student_ID
                                      where exam.Classroom_ID == classroomId 
                                      orderby result.Student_ID
                                      group result by new { cls.Classroom_ID, cls.Name } into g
                                      select new ClassroomResultDto
                                      {
                                          Classroom_ID = g.Key.Classroom_ID,
                                          Classroom_Name = g.Key.Name,
                                          StudentDetails = g.Select(r => new ClassStudentsDtos
                                          {
                                              Student_ID = r.Student_ID,
                                              Name = r.Student.Name,
                                              Email = r.Student.Email,
                                              DOB = r.Student.DOB,
                                              Address = r.Student.Address,
                                              studentResult = g.Select(sr => new StudentResultDto 
                                              {
                                                  ExamDetail = new ExamReadDtos
                                                  {
                                                      Exam_ID = r.Exam_ID,
                                                      Date = r.Exam.Date,
                                                      Name = r.Exam.Name,
                                                      Type = r.Exam.Type,
                                                  },
                                                  Percentage = r.Total_marks != 0 ? Math.Round((double)r.Obtain_marks / r.Total_marks * 100, 2).ToString("0.00") + "%" : "0.00%",
                                                  Obtain_marks = r.Obtain_marks,
                                                  Total_marks = r.Total_marks


                                              }).ToList(),

                                        }).ToList()
                                      }).ToList();*/

            return classroomResultDto;

        }
    }
}
