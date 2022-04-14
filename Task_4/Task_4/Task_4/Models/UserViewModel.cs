using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_4.Models
{
    public class UserViewModel
    {
        public string Status { get; set; }

        public string UserName { get; set; }

        public DateTime DateReg { get; set; }

        public DateTime DateLog { get; set; }

    }
}
