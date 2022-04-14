using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_4.Models
{
    public class User : IdentityUser
    {
        public int Status { get; set; }

        public DateTime DateReg { get; set; }

        public DateTime DateLog { get; set; }
    }
}
