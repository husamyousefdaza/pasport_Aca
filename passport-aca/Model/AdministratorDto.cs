using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class AdministratorDto
    {
        public int id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string Validity { get; set; }

        public string name { get; set; }
        public bool state { get; set; }

    }
}
