using System.Threading.Tasks;
using AperoRental.API.Models;

namespace AperoRental.API.DataContexts {

    public interface IAuthRepository {
    
         Task<Admin> RegisterAdmin(Admin admin, string password);

         Task<Admin> Login(string username,string password);

         Task<bool> AdminExists(string username);
    }
}