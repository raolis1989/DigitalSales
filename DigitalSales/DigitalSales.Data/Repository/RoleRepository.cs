using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContextDigitalSales _context;

        public RoleRepository( DbContextDigitalSales context)
        {
            _context = context;

        }


        public async Task<bool> Activate(int id)
        {
            var resultRole = await  ObtainRoleAsync(id);
            resultRole.Condition = true;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async  Task<Role> AddRole(Role role)
        {
            role.Condition = true;

            _context.Add(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }

            return role;
        }

        public async Task<bool> Deactivate(int id)
        {
            var resultRole = await ObtainRoleAsync(id);
            resultRole.Condition = false;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> ObtainRoleAsync(int id)
        {
            return await _context.Roles
                .SingleOrDefaultAsync(c => c.idRole == id);
        }

        public async Task<List<Role>> ObtainRolesActiveAsync()
        {
            return await _context.Roles.Where(c => c.Condition == true)
                                        .OrderBy(c => c.Name)
                                         .ToListAsync();
        }

        public async Task<List<Role>> ObtainRolesAsync()
        {
            return await _context.Roles.
                ToListAsync();
        }

        public async Task<bool> UpdateRole(Role role)
        {
            var resultRole = await ObtainRoleAsync(role.idRole);
            resultRole.Name = role.Name;
            resultRole.Description = role.Description;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
