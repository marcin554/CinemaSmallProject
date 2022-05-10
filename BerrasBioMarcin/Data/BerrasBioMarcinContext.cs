#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerrasBioMarcin.Models;

namespace BerrasBioMarcin.Data
{
    public class BerrasBioMarcinContext : DbContext
    {
        public BerrasBioMarcinContext (DbContextOptions<BerrasBioMarcinContext> options)
            : base(options)
        {
        }

        public DbSet<BerrasBioMarcin.Models.Movie> Movie { get; set; }

        public DbSet<BerrasBioMarcin.Models.Genre> Genres { get; set; }

        public DbSet<BerrasBioMarcin.Models.Customer> Customer { get; set; }

        public DbSet<BerrasBioMarcin.Models.Cinema> Cinema { get; set; }

        public DbSet<BerrasBioMarcin.Models.Salon> Salon { get; set; }

        public DbSet<BerrasBioMarcin.Models.Show> Show { get; set; }

        public DbSet<BerrasBioMarcin.Models.Spot> Spot { get; set; }

        public DbSet<BerrasBioMarcin.Models.Booking> Booking { get; set; }


    }
}
