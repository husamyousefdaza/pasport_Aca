using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class UserAddORUpdate
    {
        public Administrator Administrator { get; set; }
        public List<int> Listrole { get; set; }

        public int currentUser { get; set; }
    }
}
