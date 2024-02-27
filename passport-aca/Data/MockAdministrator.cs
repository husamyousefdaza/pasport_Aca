using AutoMapper;
using Microsoft.EntityFrameworkCore;
using passport_aca.Model;
using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;

namespace passport_aca.Data
{

    public class MockAdministrator : IAdministratorInterface
    {

        public MockAdministrator(AppDbCont data)
        {
            _data = data;

     
        }

        private AppDbCont _data { get; }
        private IMapper _mapper { get; }
     
        
        public async Task<MassageInfo> AddAdministrator(UserWithOnlyRoleNum user)
        {
            MassageInfo massageInfo = new MassageInfo();
            try
            {
                if(user!=null)
                {
                   
                    user.Administrator.state = true;
                    await _data.Administrator.AddAsync(user.Administrator);
                    await _data.SaveChangesAsync();

                    massageInfo.Massage = "تمت عملية الأضافة ";
                    massageInfo.statuscode = 201;
                    return massageInfo;
                }
                else
                {
                  
                  massageInfo.statuscode = 404;
                    return massageInfo;
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<MassageInfo> DeleteAdministrator(int id)
        {
            MassageInfo massageInfo = new MassageInfo();
            try
            {   
                    Administrator FIndUsers = await _data.Administrator.FindAsync(id);
                
                    if (FIndUsers != null)
                    {

                    FIndUsers.state = false;
                    _data.Administrator.Update(FIndUsers);
                    await _data.SaveChangesAsync();
                    massageInfo.Massage = "تمت عملية المسح ";
                    massageInfo.statuscode = 202;
                    return massageInfo;

                    }
                    else
                    {
                        massageInfo.Massage = "لم تتم عملية المسح هذا المستخدم غير موجود ";
                       massageInfo.statuscode = 404;
                       return massageInfo;

                    }
             
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<Administrator>> GetAllAdministrator()
        {
            try
            {
                List<Administrator> users = await _data.Administrator.OrderByDescending(x=>x.id).Where(x=>x.state==true).ToListAsync();
              

             

                
              return users;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<AdministratorDto>> GetAllAdministrators()
        {

            try
            {
                var listOfuser = await GetAllAdministrator();

             
                var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                var maper = new Mapper(config);

                var list = maper.Map<List<Administrator>, List<AdministratorDto>>(listOfuser);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
          

        
            

        }


        public async Task<List<RoleDto>> GetAllRoles()
        {
            try
            {
                List<Role> listOfRole = await _data.Role.OrderBy(x => x.RoleId).Where(x => x.state == true).ToListAsync();

                List<RoleDto> list = new List<RoleDto>();

                list.Add(new RoleDto
                {
                    Name = "الكل",
                    RoleId = 100,
                    state = true
                });

                foreach (var item in listOfRole)
                {

                    list.Add(new RoleDto
                    {
                        Name = item.Name,
                        RoleId = item.RoleId,
                        state = true
                    });


                }
                list = _mapper.Map<List<Role>, List<RoleDto>>(listOfRole);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserView> GetAdministrator(int id)
        {

            try
            {
                UserView view = new UserView();

                var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                var maper = new Mapper(config);

                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.id == id);


                view.Administrator = maper.Map<Administrator, AdministratorDto>(user);

                view.Listrole = await (from userrole in _data.UserRoles.Where(x => x.UserId == user.id)
                                       join
                                       role in _data.Role on userrole.RoleId equals role.RoleId
                                       select role).ToListAsync();



                return view;

            }
            catch (Exception)
            {

                throw;
            }

        }
       


        public async Task<PageintoinAdmin> GetAdministrator(int page, int pageSize) {

            try
            {


                PageintoinAdmin pageing = new PageintoinAdmin();



                List<Administrator> d = await _data.Administrator.OrderByDescending(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                pageing.total = _data.Administrator.Count();

                foreach (var item in d)
                {
                    pageing.listofUser.Add(new AdministratorDto()
                    { id = item.id, Password = item.Password, state = item.state, Username = item.Username 

                    });


                }



                return pageing;
            }
            catch (Exception)
            {

                throw;
            }
        
      
        }


        public async Task<UserWithOnlyRoleNum> login(Login user1)
        {
            try
            {
                UserWithOnlyRoleNum view = new UserWithOnlyRoleNum();

                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x=>x.Username==user1.UserName && x.state==true);
               
                if (user != null) {
                    bool isValid = BCrypt.Net.BCrypt.Verify(user1.Password, user.Password);
                 
                    if (isValid)
                    {
                    
                        var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                        var maper = new Mapper(config);

                        view.Administrator = user;

                        view.Listrole = await (from userrole in _data.UserRoles.Where(x => x.UserId == user.id)
                                              join
                                              role in _data.Role on userrole.RoleId equals role.RoleId
                                               select role.code).ToListAsync();

                        return view;


                    }
                    else
                    {
                        return null;

                    }

                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MassageInfo> UpdateAdministrator(UserAddORUpdate user)
        {

            MassageInfo massageInfo = new MassageInfo();
            try
            {
                UserRoles role = new UserRoles();

                UserAddORUpdate view = new UserAddORUpdate();

                view.Administrator = await _data.Administrator.FindAsync(user.Administrator.id);


                if (view.Administrator != null)
                {

                    view.Administrator.Username = user.Administrator.Username;
                    if (view.Administrator.Password != user.Administrator.Password)
                    {
                        view.Administrator.Password = BCrypt.Net.BCrypt.HashPassword(user.Administrator.Password);
                    }

                    view.Administrator.state = user.Administrator.state;
                    _data.Administrator.Update(view.Administrator);
                    await _data.SaveChangesAsync();


                    List<UserRoles> Listrol = await _data.UserRoles.Where(x => x.UserId == user.Administrator.id).ToListAsync();

                    foreach (var item in Listrol)
                    {
                        _data.UserRoles.Remove(item);
                        await _data.SaveChangesAsync();
                    }


                    if (user.Listrole.Count > 0)
                    {
                        foreach (var item in user.Listrole)
                        {

                            await _data.UserRoles.AddAsync(new UserRoles
                            {
                                RoleId = item,
                                UserId = user.Administrator.id
                            });
                            await _data.SaveChangesAsync();
                        }
                     

                    }
                   
                    massageInfo.Massage = "تمت عملية التعديل ";
                    massageInfo.statuscode = 202;
                    return massageInfo;

                }
                else
                {
                    massageInfo.Massage = "لم تتم عملية التعديل هذا المستخدم غير موجود ";
                    massageInfo.statuscode = 404;
                    return massageInfo;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
