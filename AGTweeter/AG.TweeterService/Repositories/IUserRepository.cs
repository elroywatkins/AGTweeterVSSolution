using AG.Common;
using System.Collections.Generic;
namespace AG.TweeterBLL
{
    public interface IUserRepository 
    {
        IList<User> GetAllUsers();
        IList<User> GetUsersByName(string userName);
        User GetUserByName(string userName);
    }
}