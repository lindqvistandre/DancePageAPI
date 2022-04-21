using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DancePage.Model;
using DancePage.DataAccessUI;

namespace DancePage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GifsInfosController : ControllerBase
    {
        private readonly IGifsInfoDataAccess dataAccess;

        public GifsInfosController(IGifsInfoDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<List<GifsInfo>>> Get()
        {
            return Ok(dataAccess.GetGifsInfos());
        }

        [HttpGet("{gifsInfosId}")]
        public async Task<ActionResult<GifsInfo>> GetTById(int gifsInfosId)
        {
            var gifInfo = dataAccess.GetTById(gifsInfosId);
            if (gifInfo == null)
                return NotFound("Gif not found");
            return Ok(gifInfo);
        }

        [HttpPost]
        public async Task<ActionResult<List<GifsInfo>>> AddTimeReport(GifsInfo gifsInfo)
        {
            dataAccess.AddT(gifsInfo);
            return Ok(dataAccess.GetGifsInfos());
        }

        [HttpPut]
        public async Task<ActionResult<List<GifsInfo>>> UpdateGifsInfo(GifsInfo t)
        {
            var gifsInfo = dataAccess.GetTById(t.GifsInfoId);
            if (gifsInfo == null)
                return NotFound("Gif not found");

            dataAccess.SaveTAsync(t);

            return Ok(dataAccess.GetGifsInfos());
        }

        [HttpDelete("{gifsInfoId}")]
        public async Task<ActionResult<List<GifsInfo>>> Delete(int gifsInfoId)
        {
            var gifsInfo = dataAccess.GetTById(gifsInfoId);
            if (gifsInfo == null)
                return NotFound("Gif not found");

            dataAccess.DeleteTAsync(gifsInfoId);

            return Ok(dataAccess.GetGifsInfos());
        }
    }
}
