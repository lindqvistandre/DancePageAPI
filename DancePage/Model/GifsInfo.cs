using System.ComponentModel.DataAnnotations;

namespace DancePage.Model
{
    public class GifsInfo
    {
        [Key]
        public int GifsInfoId { get; set; }

        public string? Comment { get; set; }
        public string? Artist { get; set; }
        public string Link { get; set; }

        public void CloneIt(GifsInfo gifsInfo)
        {
            Comment = gifsInfo.Comment; 
            Artist = gifsInfo.Artist;
            Link = gifsInfo.Link;
        }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
