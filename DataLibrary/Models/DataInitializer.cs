using AdvertismentApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class DataInitializer
    {
        private readonly AdsDbContext _dbContext;

        public DataInitializer(AdsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Advertisement.Any(a => a.Id == 1))
            {
                _dbContext.Add(new Advertise
                {
                    Name = "Google",
                    Description = "This is a GoogleAd"
                });
            }
            
            if (!_dbContext.Advertisement.Any(a => a.Id == 2))
            {
                _dbContext.Add(new Advertise
                {
                    Name = "Facebook",
                    Description = "This is a FacebookAd"
                });
            }
            
            if (!_dbContext.Advertisement.Any(a => a.Id == 3))
            {
                _dbContext.Add(new Advertise
                {
                    Name = "Tiktok",
                    Description = "This is a TiktokAd"
                });
            }

        }
    }
}
