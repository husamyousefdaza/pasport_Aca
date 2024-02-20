using Microsoft.AspNetCore.Mvc;
using passport_aca.Data;
using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace passport_aca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoleController : ControllerBase
    {

        public RoleController(GenericInterface<Role, RoleDto> Roles)
        {
            _data = Roles;

        }
        private readonly GenericInterface<Role, RoleDto> _data;



        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _data.GetAll();
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound(new Result() { message = "لا يوجد صلاحيات مخزنة مسبقاً", statusCode = 404 });

            }
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _data.Get(id);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound(new Result() { message = "الصلاحية غير موجودة", statusCode = 404 });
            }
        }

    }
}
