using DigitalSales.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> ObtainUsersAsync();

        Task<User> ObtainUserAsync(int id);
        Task<bool> Update(User user);
        Task<User> AddUser(User user);
        Task<bool> Delete(int id);
        Task<bool> Deactivate(int id);
        Task<bool> Activate(int id);
        Task<Tuple<byte[], byte[]>> CrearPasswordHash(string password);
        Task<bool> CheckEmail(string email);
        Task<User> ObtainUserByEmail(string email);
        Task<bool> Verify(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt);
    }
}
