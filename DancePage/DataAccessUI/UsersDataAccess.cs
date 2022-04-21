using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DancePage.Data;
using DancePage.Model;

namespace DancePage.DataAccessUI
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private readonly DanceDbContext _danceDbContext;

        public UsersDataAccess(DanceDbContext danceDbContext)
        {
            _danceDbContext = danceDbContext;
        }

        //EMPLOYEE
        public IEnumerable<User> GetUsers()
        {
            return _danceDbContext.Users.ToList();
        }

        public User GetEById(int userid)
        {
            return _danceDbContext.Users.AsNoTracking().Single(e => e.UserId == userid);
        }

        public void SaveEAsync(User user)
        {
            //Retrieve the object first, then update it!
            var b = _danceDbContext.Users.SingleOrDefault(p => p.UserId == user.UserId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(user);

            //_tDbContext.Entry(book).State = EntityState.Modified;
            _danceDbContext.SaveChanges();
        }

        public void DeleteEAsync(int userid)
        {
            var b = _danceDbContext.Users.SingleOrDefault(p => p.UserId == userid);

            _danceDbContext.Users.Remove(b);
            _danceDbContext.SaveChanges();
        }

        public void AddE(User user)
        {
            _danceDbContext.Users.Add(user);

            var b = _danceDbContext.Users.SingleOrDefault(p => p.UserId == user.UserId);

            _danceDbContext.SaveChanges();
        }
    }
}
