using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentt1
{
    public class Service
    {
        [Key]
        public  int serviceid { get; set; }
        public string ServiceName { get; set; }
        public double cost { get; set; }

        public double quantity { get; set; }

        public Service()
        {
            
        }

    }
}
