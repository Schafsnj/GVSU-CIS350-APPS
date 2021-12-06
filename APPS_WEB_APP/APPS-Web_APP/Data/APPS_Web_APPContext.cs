using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APPS_Web_APP.Models;

namespace APPS_Web_APP.Data
{
    public class APPS_Web_APPContext : DbContext
    {
        public APPS_Web_APPContext (DbContextOptions<APPS_Web_APPContext> options)
            : base(options)
        {
        }

        public DbSet<APPS_Web_APP.Models.User> User { get; set; }

        public DbSet<APPS_Web_APP.Models.Task> Task { get; set; }
    }
}
