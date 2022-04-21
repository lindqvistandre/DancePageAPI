using DancePage.Model;
using System.Collections.Generic;

namespace DancePage.DataAccessUI
{
    public interface IUsersDataAccess
    {
        //USER
        IEnumerable<User> GetUsers();
        User GetEById(int userid);
        void AddE(User user);
        void SaveEAsync(User user);
        void DeleteEAsync(int userid);
    }
}