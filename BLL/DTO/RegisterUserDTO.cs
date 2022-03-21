using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.DTO
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; } // add validation
    }
}
