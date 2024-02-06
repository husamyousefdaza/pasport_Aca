using Microsoft.EntityFrameworkCore;
using passport_aca.Model;
using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace passport_aca.Model
{
    public class AppDbCont : DbContext
    {

        public DbSet<TransactionInfo> transactions { get; set; }

        public DbSet<Administrator> Administrator { get; set; }

        public AppDbCont(DbContextOptions<AppDbCont> option) : base(option)
        {

        }
        
    }
}