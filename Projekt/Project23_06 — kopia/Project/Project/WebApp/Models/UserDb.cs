using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Web.Models
{
    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}