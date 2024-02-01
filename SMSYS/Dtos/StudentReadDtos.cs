using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class StudentReadDtos
    {
            public int Subject_ID { get; set; }

            public string Email { get; set; }
 
            public string Password { get; set; }
      
            public string Name { get; set; }
 
            public string DOB { get; set; }
   
            public string Sex { get; set; }
      
            public string Address { get; set; }
  
            public int Phone { get; set; }
      
        }
    }

