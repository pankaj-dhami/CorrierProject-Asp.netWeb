using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourrierWeb.Models
{
    public class DB
    {
    }
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        public string surname { get; set; }
    }

    public class CourrierDataContext : DbContext
    {
        public CourrierDataContext()
            : base("CourrierDataContext")
        {
            Database.SetInitializer<CourrierDataContext>(new CourrierDBInitializer());

        }
        //public DbSet<Ninja> Ninjas { get; set; }
        //public DbSet<Clan> Clans { get; set; }
        //public DbSet<NinjaEquipment> NinjaEquipments { get; set; }
        public DbSet<Person> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Ninja>().ToTable("Ninja");
            //  modelBuilder.Entity<Clan>().ToTable("Clan");
            //  modelBuilder.Entity<NinjaEquipment>().ToTable("NinjaEquipment");
        }

    }
    public class CourrierDBInitializer : DropCreateDatabaseAlways<CourrierDataContext>
    {
        protected override void Seed(CourrierDataContext context)
        {
            base.Seed(context);
        }
    }
}