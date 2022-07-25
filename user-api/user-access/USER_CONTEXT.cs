using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_data.types.Models;

namespace user_access
{
    public partial class USER_CONTEXT : DbContext
    {
        public USER_CONTEXT(DbContextOptions<USER_CONTEXT> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
