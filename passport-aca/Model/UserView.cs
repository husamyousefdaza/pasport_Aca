using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class UserView
    {
        public UserView()
        {
            this.Listrole = new List<Role>();
        }
        public AdministratorDto Administrator { get; set; }
        public List<Role> Listrole { get; set; }
    }
}
