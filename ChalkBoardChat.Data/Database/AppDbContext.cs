using ChalkBoardChat.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkBoardChat.Data.Database
{
    public class AppDbContext : DbContext
    {

        // DbSet för MessageModel

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        { 

        }
}

    }
}
