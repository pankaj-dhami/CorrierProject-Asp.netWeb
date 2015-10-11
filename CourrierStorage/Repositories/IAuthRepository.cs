using CourrierBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierStorage.Repositories
{
    public interface IAuthRepository
    {
        Task<UserModel> FindUser(string userName, string password);
        Task<UserModel> RegisterUserAsync(UserModel userModel);
        List<UserModel> GetAllUser();

    }
}
