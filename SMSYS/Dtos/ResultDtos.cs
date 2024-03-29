﻿using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class ResultCreateDto
    {
        [Required]
        public int Student_ID { get; set; }
        [Required]
        public int Subject_ID { get; set; }
        [Required]
        public int Exam_ID { get; set; }
        [Required]
        public int Obtain_marks { get; set; }

        [Required]
        public int Total_marks { get; set; }
    }


    public class ResultReadDto
    {
        [Required]
        public int Student_ID { get; set; }
        [Required]
        public int Subject_ID { get; set; }
        [Required]
        public int Exam_ID { get; set; }
        [Required]
        public int Obtain_marks { get; set; }

        [Required]
        public int Total_marks { get; set; }
    }

    public class ResultUpdateDto
    {
        [Required]
        public int Student_ID { get; set; }
        [Required]
        public int Subject_ID { get; set; }
        [Required]
        public int Exam_ID { get; set; }
        [Required]
        public int Obtain_marks { get; set; }

        [Required]
        public int Total_marks { get; set; }
    }



}
