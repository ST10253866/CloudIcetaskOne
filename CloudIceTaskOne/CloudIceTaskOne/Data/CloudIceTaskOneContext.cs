using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CloudIceTaskOne.Models;

namespace CloudIceTaskOne.Data
{
    public class CloudIceTaskOneContext : DbContext
    {
        public CloudIceTaskOneContext (DbContextOptions<CloudIceTaskOneContext> options)
            : base(options)
        {
        }

        public DbSet<CloudIceTaskOne.Models.CarModels> CarModels { get; set; } = default!;
    }
}
