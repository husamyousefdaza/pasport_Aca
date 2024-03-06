using Microsoft.AspNetCore.Mvc;
using passport_aca.Data;
using passport_aca.Model;
using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public AuthController(IAdministratorInterface users)
        {
            _data = users;
        }
        public IAdministratorInterface _data { get; }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<ActionResult<UserWithOnlyRoleNum>> LoginUser([FromBody] Login user)
        {
            MassageInfo massages = new MassageInfo();
            var find = await _data.login(user);

            if (find != null)
            {

                return Ok(find);
            }
            else
            {
                massages.Massage = "رقم المستخدم او كلمة المرور غير صحيحة";
                massages.statuscode = 404;
                return NotFound(massages);
            }
        }
    }
}
