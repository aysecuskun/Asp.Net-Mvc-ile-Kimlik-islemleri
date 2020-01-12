using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
        public DbSet<Neden> Nedens { get; set; }
        public DbSet<Il> Ils { get; set; }
        public DbSet<Ilce> Ilces { get; set; }
        public DbSet<Saat> Saats { get; set; }
        public DbSet<Kart> Karts { get; set; }
        //public DbSet<Tarih> Tarihs { get; set; }

        public DataBaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
   
}
