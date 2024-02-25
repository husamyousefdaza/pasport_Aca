using passport_aca.Model;
using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Data
{
     public interface IRoleInterface
    {
        Task<List<RoleDto>> GetAll();
    }
}
