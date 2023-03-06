using Core.Dto;
using Core.Entities;
using Infraestructure.Data;
using Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private Utilities.Utilities _utilities;
        public UserRepository(Utilities.Utilities utils, ApplicationDbContext db)
        {
            _db = db;
            _utilities = utils;
        }
        public async Task<User> insertUser(User user)
        {
            //Encriptar password
            string pass = user.password;
            string passhash = _utilities.encriptarPassword(pass);
            user.password = passhash;

            //Agregar a la base de datos
            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }

        //Validar si el usuario existe en la base de datos
        public async Task<bool> valitateUser(UserDto user)
        {
            
            var userValid = await _db.User.FirstOrDefaultAsync(u => u.userName.ToLower() == user.userName.ToLower() && u.email.ToLower() == user.email.ToLower());

            if (userValid == null)
            {
                return false;
            }

            return true;
        }
    }
}
