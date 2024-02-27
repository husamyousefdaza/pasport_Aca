using passport_aca.Model;
using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Data
{
    public interface IAdministratorInterface
    {
        Task<UserWithOnlyRoleNum> login(Login user);
        Task<List<RoleDto>> GetAllRoles();
        Task<MassageInfo> AddAdministrator(UserWithOnlyRoleNum user);

        Task<List<Administrator>> GetAllAdministrator();
  
        Task<MassageInfo> UpdateAdministrator(UserAddORUpdate user);

        Task<MassageInfo> DeleteAdministrator(int id);

        Task<UserView> GetAdministrator(int id);
        Task<List<AdministratorDto>> GetAllAdministrators();
        Task<PageintoinAdmin> GetAdministrator(int page, int pageSize);

    }
}
