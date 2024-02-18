using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GroupAssignmentt1
{
    public class Patient
    {
        [Key]
        public int RegNo { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }   

        public string Date { get; set; }

       

        public double amount { get; set; }
    }
}