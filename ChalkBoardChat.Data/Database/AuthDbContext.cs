using ChalkBoardChat.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkBoardChat.Data.Database
{
    public class AuthDbContext : IdentityDbContext

    {

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        
    }
}
