using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentt1
{
   public class Doctor
    {
        [Key] 
        public int DoctorID { get; set; }
        public string Name { get; set; } 
        public string Speciality { get; set; }




    }
}
