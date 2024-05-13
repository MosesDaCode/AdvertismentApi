using AdvertismentApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class AdsDbContext : DbContext
    {

        public AdsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Advertise> Advertisement { get; set; }

    }
}
