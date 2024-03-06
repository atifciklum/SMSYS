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

       public IEnumerable<ClassroomResultDto> getStudentResultsByClassroomId(int classId)
        {

            var studentResults = (from result in _context.Result
                                  join student in _context.Student on result.Student_ID equals student.Student_ID
                                  join exam in _context.Exam on result.Exam_ID equals exam.Exam_ID
                                  join subject in _context.Subject on result.Subject_ID equals subject.Subject_ID
                                  where _context.Classroom_Student
                                        .Where(cs => cs.Classroom_ID == classId)
                                        .Select(cs => cs.Student_ID)
                                        .Contains(result.Student_ID)
                                  group new  { result, student, exam } by new { student.Student_ID, student.Name, student.Email, student.DOB, student.Address } into studentGroup
                                  select new ClassroomResultDto
                                  {
                                      Classroom_ID = classId,
                                      StudentDetails = studentGroup.Select(sg => new ClassStudentsDtos
                                      {
                                          Student_ID = sg.student.Student_ID,
                                          Name = sg.student.Name,
                                          Email = sg.student.Email,
                                          DOB = sg.student.DOB,
                                          Address = sg.student.Address,
                                          studentResult = studentGroup.Select(s => new StudentResultDto
                                          {
                                              Result_ID = s.result.Result_ID,
                                              ExamDetail = new ExamReadDtos
                                              {
                                                  Exam_ID = s.exam.Exam_ID,
                                                  Date = s.exam.Date,
                                                  Name = s.exam.Name,
                                                  Type = s.exam.Type
                                              },
                                            
                                              Obtain_marks = s.result.Obtain_marks,
                                              Total_marks = s.result.Total_marks
                                          }).Distinct().ToList(),
                                      }).ToList(),
                                  }).ToList();

            return studentResults;

        }
    }
}
