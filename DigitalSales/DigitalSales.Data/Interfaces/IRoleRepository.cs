using DigitalSales.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> ObtainRolesAsync();
        Task<Role> ObtainRoleAsync(int id);
        Task<bool> UpdateRole(Role role);
        Task<Role> AddRole(Role role);
        Task<bool> Delete(int id);
        Task<bool> Activate(int id);
        Task<bool> Deactivate(int id);
    }
}
