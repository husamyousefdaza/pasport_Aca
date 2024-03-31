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

        public DbSet<Historyes> History { get; set; }

        public DbSet<HistortyName> HistortyName { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public AppDbCont(DbContextOptions<AppDbCont> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<HistortyName>().HasData(new HistortyName {ID =1, name = "≈÷«›… „⁄«„·…" },
                new HistortyName {ID =2, name = " ⁄œÌ· „⁄«„·…" }


            );

            mb.Entity<Role>().HasData(new Role { RoleId = 1 ,Name = "·ÊÕ… «· Õﬂ„ " ,state=true,code= "dash" },
              new Role {RoleId=2, Name = "«·„” Œœ„Ì‰  ", state = true, code = "user" },
              new Role { RoleId = 3, Name = "ÿ»«⁄…  ", state = true, code = "print" },
              new Role { RoleId = 4, Name = "„‰ ÿ—› „‰  ", state = true, code = "who" },
              new Role { RoleId = 5, Name = " «· ”·Ì„ ", state = true, code = "dil" },
              new Role { RoleId = 6, Name = "«·≈÷«›… Ê«· ⁄œÌ·  ", state = true, code = "add" }


           );
            base.OnModelCreating(mb);
        }
        
    }
}