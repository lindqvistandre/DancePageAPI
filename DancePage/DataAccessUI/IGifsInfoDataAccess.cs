using DancePage.Model;
using System.Collections.Generic;

namespace DancePage.DataAccessUI
{
    public interface IGifsInfoDataAccess
    {
        //Gifs Info
        IEnumerable<GifsInfo> GetGifsInfos();
        GifsInfo GetTById(int gifsInfotid);
        void AddT(GifsInfo gifsInfo);
        void SaveTAsync(GifsInfo gifsInfo);
        void DeleteTAsync(int gifsInfoid);
    }
}