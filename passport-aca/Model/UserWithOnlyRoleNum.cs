using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class UserWithOnlyRoleNum
    {
        public UserWithOnlyRoleNum()
        {
            this.Listrole = new List<string>();
        }
        public AdministratorDto Administrator { get; set; }
        public List<string> Listrole { get; set; }

    }
}
