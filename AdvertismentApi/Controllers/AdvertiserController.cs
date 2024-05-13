using AdvertismentApi.Models;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertismentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdvertiserController : ControllerBase
    {
        private readonly AdsDbContext _dbContext;

        public AdvertiserController(AdsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static List<Advertise> Ads = new List<Advertise>
        {
            new Advertise
            {
                Id = 1,
                Name = "Google",
                Description = "This is a GoogleAd"
            },
            new Advertise
            {
                Id = 2,
                Name = "Instagram",
                Description = "This is a InstagramAd"
            },
            new Advertise
            {
                Id=3,
                Name = "TikTok",
                Description = "This is a TiktokAd"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Advertise>>> GetAll()
        {
            return Ok( await _dbContext.Advertisement.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Advertise>> GetOne(int id)
        {
            var OneAd = _dbContext.Advertisement.Find(id);
            if (OneAd == null)
            {
                return BadRequest("Ad was not found");
            }
            return Ok(OneAd);
        }

        [HttpPost]
        public async Task<ActionResult<Advertise>> PostAd(Advertise postingAd)
        {
            _dbContext.Advertisement.Add(postingAd);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisement.ToListAsync());
        }

        [HttpPut]
        [Route("id")]
        public async Task<ActionResult<Advertise>> UpdateWholeAd(Advertise updateAd)
        {
            var adToUpdate = await _dbContext.Advertisement.FindAsync(updateAd.Id);

            if (adToUpdate == null)
            {
                return BadRequest("Ad was not found");
            }

            adToUpdate.Name = updateAd.Name;
            adToUpdate.Description = updateAd.Description;

            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisement.ToListAsync());
        }
        [HttpDelete]
        [Route("id")]
        public async Task<ActionResult<Advertise>> RemoveAd(int id)
        {
            var adToRemove = await _dbContext.Advertisement.FindAsync(id);

            if (adToRemove == null)
            {
                return BadRequest("Ad was not found");
            }

            _dbContext.Remove(adToRemove);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisement.ToListAsync());
        }
    }
}
