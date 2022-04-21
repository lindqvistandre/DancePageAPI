using Microsoft.EntityFrameworkCore;

namespace DancePage.Model
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GifsInfo>().HasData(
                new GifsInfo { GifsInfoId = 1, Artist = "hej", Comment = "Comment Test", Link = "http://jalla.se", UserId = 1, },
                new GifsInfo { GifsInfoId = 2, Artist = "artist2", Comment = "Comment Test2", Link = "http://jalla2.se", UserId = 2, }
                
                );
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "Andre", LastName = "Lindqvist", Email = "Test@test.se", Password = "332211" },
                new User { UserId = 2, FirstName = "Andre2", LastName = "Lindqvist", Email = "Test2@test.se", Password = "332211" }
                );
        }
    }
}
