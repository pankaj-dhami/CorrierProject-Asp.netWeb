using CourrierBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierStorage.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        CourrierDataContext ctx;
        public AuthRepository()
        {
            ctx = new CourrierDataContext();
            // new CourrierDBInitializer().InitializeDatabase(ctx);
        }

        public async Task<UserModel> FindUser(string userName, string password)
        {
            UserModel userModel=new UserModel{Password=password,UserName=userName,ConfirmPassword=password};
            var user = ctx.Users.Where(a => a.UserName == userName && a.Password == password).FirstOrDefault();
            return user;
        }

        public async Task<UserModel> RegisterUserAsync(UserModel userModel)
        {
            ctx.Users.Add(userModel);
            await ctx.SaveChangesAsync();
            return userModel;
        }

        public List<UserModel> GetAllUser()
        {
            List<UserModel> users = ctx.Users.ToList();
            return users;
        }

    }
}
