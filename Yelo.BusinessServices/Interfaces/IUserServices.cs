using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelo.BusinessEntities;

namespace Yelo.BusinessServices.Interfaces
{
    /// <summary>
    /// User Service Contract      
    /// </summary>
    public interface IUserServices
    {
        int Authenticate(string userName, string phoneNumber);
        UserEntity GetUserById(int productId);
        IEnumerable<UserEntity> GetAllUsers();
        int CreateUser(UserEntity userEntity);
        bool UpdateUser(int userId, UserEntity userEntity);
        bool DeleteUser(int userId);  
    }
}
