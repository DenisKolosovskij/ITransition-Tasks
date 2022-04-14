using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_4.Models
{
    public class EditUserViewModel 
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public int Status { get; set; }

        public DateTime DateReg { get; set; }

        public DateTime DateLog { get; set; }
    }
}
