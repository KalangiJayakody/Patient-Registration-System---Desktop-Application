using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentt1
{
    public class Bill
    {
        [Key]
        public int ID {  get; set; }    
        public string Date { get; set; }

        public double Amount { get; set; }

        public Bill() { 

        }


    }
}
