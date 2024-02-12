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

        Task<MassageInfo> AddAdministrator(Administrator user);

        Task<List<Administrator>> GetAllAdministrator();

        Task<MassageInfo> UpdateAdministrator(Administrator user);

        Task<MassageInfo> DeleteAdministrator(int id);

        Task<AdministratorDto> GetAdministrator(int id);
        Task<List<AdministratorDto>> GetAllAdministrators();
        Task<PageintoinAdmin> GetAdministrator(int page, int pageSize);

    }
}
