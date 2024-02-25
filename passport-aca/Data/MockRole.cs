using AutoMapper;
using Microsoft.EntityFrameworkCore;
using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Data
{
    public class MockRole : GenericInterface<Role, RoleDto>
    {
        public MockRole(AppDbCont data, IMapper mapper)
        {
            _data = data;

            _mapper = mapper;

        }

        private AppDbCont _data { get; }
        private IMapper _mapper { get; }

        public Task<bool> Add(Role t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> GetAll()
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
                //list = _mapper.Map<List<Role>, List<RoleDto>>(listOfRole);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Update(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
