using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextDigitalSales _context;
        private readonly IRoleRepository _roleRepository;

        public UserRepository(DbContextDigitalSales context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }
        public async Task<bool> Activate(int id)
        {
            var resultUser = await ObtainUserAsync(id);
            resultUser.Condition = true;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<User> AddUser(User user)
        {
            user.Condition = true;
             
      
            

            _context.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;

            }

            var role = await _roleRepository.ObtainRoleAsync(user.idRole);
            user.Role = role;
            return user;
            

            
        }

        public async Task<bool> CheckEmail(string email)
        {
            var resultEmail = email.ToLower();

            return await  _context.Users.AnyAsync(e => e.Email == resultEmail);
        }

        public async  Task<Tuple<byte[], byte[]>> CrearPasswordHash(string password)
        {
             byte[] passwordSalt , passwordHash;

            using(var hmac  =  new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));


            }
            return  new Tuple<byte[], byte[]>(passwordHash, passwordSalt);
            
            
        }

        public async  Task<bool> Deactivate(int id)
        {
            var resultUser = await ObtainUserAsync(id);
            resultUser.Condition = false;

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

        public async Task<User> ObtainUserAsync(int id)
        {
            return await _context.Users
                            .Include(c => c.Role)
                            .SingleOrDefaultAsync(c => c.IdUser == id);
        }

        public async Task<List<User>> ObtainUsersAsync()
        {
            return await _context.Users.Include(c => c.Role)
                            .ToListAsync();
        }

        public async Task<bool> Update(User user)
        {
            var resultUser = await ObtainUserAsync(user.IdUser);
            resultUser.idRole = user.idRole;
            resultUser.Name = user.Name;
            resultUser.Type_Document = user.Type_Document;
            resultUser.Num_Document = user.Num_Document;
            resultUser.Address = user.Address;
            resultUser.Phone = user.Phone;
            resultUser.Email = user.Email;
            resultUser.Password_Hash = user.Password_Hash;
            resultUser.Password_Salt = user.Password_Salt;


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
