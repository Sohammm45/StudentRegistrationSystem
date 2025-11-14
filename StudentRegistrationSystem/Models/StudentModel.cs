using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public string PanNo { get; set; }
        public string AadharNo { get; set; }
        public string PassportNo { get; set; }
        public string VoterId { get; set; }
        public string DrivingNo { get; set; }
    }
}
