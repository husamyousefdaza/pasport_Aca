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

        public AppDbCont _data { get; }
        
        public async Task<MassageInfo> AddAdministrator(Administrator user)
        {
            MassageInfo massageInfo = new MassageInfo();
            try
            {
                if(user!=null)
                {
                    user.state = true;
                    await _data.Administrator.AddAsync(user);
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




        public async Task<AdministratorDto> GetAdministrator(int id)
        {
            try
            {
                Administrator user = await _data.Administrator.FindAsync(id);
                var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                var maper = new Mapper(config);

                var userdto = maper.Map<Administrator, AdministratorDto>(user);

                return userdto;
            
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
                    { id = item.id, name = item.name, Password = item.Password, state = item.state, Username = item.Username, Validity = item.Validity

                    });


                }



                return pageing;
            }
            catch (Exception)
            {

                throw;
            }
        
      
        }


        public async Task<AdministratorDto> login(Login user1)
        {
            try
            {
          
                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x=>x.Username==user1.UserName && x.state==true);
               
                if (user != null) {
                    bool isValid = BCrypt.Net.BCrypt.Verify(user1.Password, user.Password);
                    if (isValid)
                    {
                    
                        var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                        var maper = new Mapper(config);

                        var userDto = maper.Map<Administrator, AdministratorDto>(user);

                        return userDto;


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

        public async Task<MassageInfo> UpdateAdministrator(Administrator user)
        {

            MassageInfo massageInfo = new MassageInfo();
            try
            {
                Administrator UpdateUser= await _data.Administrator.FindAsync(user.id);
            

                if (UpdateUser != null) {
                   
                    UpdateUser.name     = user.name;
                    UpdateUser.Password = user.Password;
                    UpdateUser.Username = user.Username;
                    UpdateUser.Validity = user.Validity;
                    _data.Administrator.Update(UpdateUser);
                    await _data.SaveChangesAsync();
                    massageInfo.Massage = "تمت عملية التحديث ";
                    massageInfo.statuscode = 200; 
                    return massageInfo;

                }
                else
                {
                    massageInfo.Massage = "لم تتم عملية التحديث ";
                    massageInfo.statuscode = 304;
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
