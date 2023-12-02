using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class CommunicationCenterContext : DbContext
    {
      //   public DbSet<CommunicationCenter> CommunicationCenters { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
       public CommunicationCenterContext(DbContextOptions options)//*
         :base(options){ }//*
    public CommunicationCenterContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            var connectionString = "server=localhost;port=3306;database=SDT;user=root;password=8032Mtkachen";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }
    }
}
