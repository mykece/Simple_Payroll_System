using CSProjeDemo2.Model.Models.BaseModel;
using CSProjeDemo2.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.DataAccess.AppDbContext
{
    public class PersonelDbContext : DbContext
    {
        //TPH YAPILDI - DİSCRİMİNATÖRE GÖRE AYIRT EDİLECEK.
        public DbSet<Personel> Personeller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connecitonString = "Server=DESKTOP-15U9NLA\\SQLEXPRESS;Database=PersonelDB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connecitonString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yonetici>().HasBaseType<Personel>();
            modelBuilder.Entity<Memur>().HasBaseType<Personel>();
        }
    }
}
