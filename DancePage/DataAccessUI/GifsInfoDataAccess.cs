using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DancePage.Data;
using DancePage.Model;

namespace DancePage.DataAccessUI
{
    public class GifsInfoDataAccess : IGifsInfoDataAccess
    {
        private readonly DanceDbContext _danceDbContext;

        public GifsInfoDataAccess(DanceDbContext danceDbContext)
        {
            _danceDbContext = danceDbContext;
        }

        //TIMEREPORT    
        public IEnumerable<GifsInfo> GetGifsInfos()
        {
            return _danceDbContext.Gifsinfos.ToList();
        }

        public GifsInfo GetTById(int gifsInfoid)
        {
            return _danceDbContext.Gifsinfos.AsNoTracking().Single(e => e.GifsInfoId == gifsInfoid);
        }

        public void SaveTAsync(GifsInfo gifsInfo)
        {
            //Retrieve the object first, then update it!
            var b = _danceDbContext.Gifsinfos.SingleOrDefault(p => p.GifsInfoId == gifsInfo.GifsInfoId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(gifsInfo);

            //_tDbContext.Entry(book).State = EntityState.Modified;
            _danceDbContext.SaveChanges();
        }

        public void DeleteTAsync(int gifsInfoId)
        {
            var b = _danceDbContext.Gifsinfos.SingleOrDefault(p => p.GifsInfoId == gifsInfoId);

            _danceDbContext.Gifsinfos.Remove(b);
            _danceDbContext.SaveChanges();
        }

        public void AddT(GifsInfo gifInfo)
        {
            _danceDbContext.Gifsinfos.Add(gifInfo);

            var b = _danceDbContext.Gifsinfos.SingleOrDefault(p => p.GifsInfoId == gifInfo.GifsInfoId);

            _danceDbContext.SaveChanges();
        }
    }
}
