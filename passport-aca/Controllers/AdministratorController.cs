﻿using Microsoft.AspNetCore.Mvc;
using passport_aca.Data;
using passport_aca.Model;
using Passpport_Raqaba.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace passport_aca.Controllers
{

    [ApiController]
   // [Route("[controller]")]
    [Route("api/[controller]")]

    //public class AdministratorController : Controller
    public class AdministratorController :  ControllerBase
    {
        public AdministratorController(IAdministratorInterface users)
        {
            _data = users;
        }

        public IAdministratorInterface _data { get; }

        [HttpGet]
        [Route("GetAllAdministrators")]
        public async Task<ActionResult<List<Administrator>>> GetAllUsers()
        {
            var users = await _data.GetAllAdministrators();
            if (users != null)
            {
                //   return Json(users);
                return Ok(users);
            }
            else
            {
                return NotFound();
            }

            //var users = new Administrator
            //{
            //    id = 18,
            //    Username = "hus666",
            //    Password = "$2a$11$LuQKt4V35vWVMQUOfI7bueNMMkq4lGTgu1Pjn4d1J5wNMsA2JP8Y2",
            //    state = true
            //};
            //return Ok(users);

        }




        [HttpGet]
        [Route("GetAllAdministrator")]
        public async Task<ActionResult<PageintoinAdmin>> GetAllAdministrator(int page, int pageSize)
        {
            var users = await _data.GetAdministrator(page, pageSize);
            if (users != null)
            {
                //return Json(users);
                return Ok(users);
            }
            else
            {
                return NotFound();

            }
           
        }


        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
        {
            var roles = await _data.GetAllRoles();
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
        [Route("GetAdministrator/{id}")]
        public async Task<ActionResult<UserView>> GetUser(int id)
        {
            var user = await _data.GetAdministrator(id);

            
            if (user != null)
            {
                //return Json(user);
                return Ok(user);
            }
            else {
                return NotFound();
            
            }
        }
        [HttpPut]
        [Route("UpdateAdministrator")]
        public async Task<ActionResult<MassageInfo>> UpdateUser([FromBody] UserAddORUpdate user)
    {

           // user.Administrator.Password = BCrypt.Net.BCrypt.HashPassword(user.Administrator.Password);
            MassageInfo massages=  await _data.UpdateAdministrator(user);
            if (massages.statuscode == 202)
                return Ok(massages);
            else if(massages.statuscode == 300) {
                return StatusCode(304, massages);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("DeleteAdministrator/{id}")]
        public async Task<ActionResult<MassageInfo>> DeleteUser(int id)
        {
           MassageInfo massages= await _data.DeleteAdministrator(id);
            if(massages.statuscode== 202)
            return Accepted(massages);
            else if(massages.statuscode== 404) {
                return NotFound(massages);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("LoginAdministrator")]
        public async Task<ActionResult<UserWithOnlyRoleNum>> LoginUser([FromBody]Login user)
        {
            MassageInfo massages = new MassageInfo();
           UserWithOnlyRoleNum  find =  await _data.login(user);
          
            if (find!=null )
            {
                return Ok(find);
            }
            else {
                massages.Massage = "رقم المستخدم او كلمة المرور غير صحيحة";
                massages.statuscode = 404;
                return NotFound(massages);
            }
        }

        [HttpPost]
        [Route("AddAdministrator")]

        public async Task<ActionResult<MassageInfo>> Adduser([FromBody] UserAddORUpdate user) {
          //  var l = Securety.hash(user.Password);
            //user.Password = l;

          user.Administrator.Password = BCrypt.Net.BCrypt.HashPassword(user.Administrator.Password);

       

            //var c = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            MassageInfo massages = await _data.AddAdministrator(user);
            if (massages.statuscode==201)
            {

                return Created("AddAdministrator", massages);

            }
            else
            {
                return BadRequest(new MassageInfo()
                {
                    Massage = "قشل في عملية الاضافة  ",
                    statuscode = 400

                });
            }



        }

    }
}
