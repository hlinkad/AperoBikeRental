using System;
using System.Threading.Tasks;
using AperoRental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AperoRental.API.DataContexts
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DataContext _dbContext;

        public AuthRepository(DataContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Admin> Login(string username, string password ){
        
            var admin = await _dbContext.Admins.FirstOrDefaultAsync(arg => arg.UserName == username);

            if(admin != null){
                if(VerifyPassword(admin,password)){
                    return admin;
                }
            }
            return null;
        }

        public async Task<Admin> RegisterAdmin(Admin admin, string password){
            
            HashPassword(password, out var passwordHash, out var passwordSalt);
            admin.PasswordHash = passwordHash;
            admin.PassWordSalt = passwordSalt;
           
           await _dbContext.Admins.AddAsync(admin);
           await _dbContext.SaveChangesAsync();

           return admin;
            
        }


        public async Task<bool> AdminExists(string username){
        
           return await _dbContext.Admins.AnyAsync(x => x.UserName == username);
        }

        private static void HashPassword(string password,out byte[] passwordHash, out byte[] passwordSalt) {
            PasswordHasher hasher = new PasswordHasher(password);

            passwordHash = hasher.Hash;
            passwordSalt = hasher.Salt;
        }
        

        private static bool VerifyPassword(Admin admin, string password){
        
            PasswordHasher decrypt = new PasswordHasher(admin.PasswordHash, admin.PassWordSalt);
            if (decrypt.Verify(password)) {
                return true;
            }

            return false;
        }
    }
}