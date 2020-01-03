using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public Task<bool> Activate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deactivate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> ObtainRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> ObtainRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
