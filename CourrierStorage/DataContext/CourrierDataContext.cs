using CourrierBO;
using CourrierBO.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CourrierStorage
{

    public class CourrierDataContext : DbContext
    {
        public CourrierDataContext()
            : base("CourrierDataContext")
        {
          //  Database.SetInitializer<CourrierDataContext>(new CourrierDBInitializer());

        }
      
        public DbSet<UserModel> Users { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //   // modelBuilder.Entity<Ninja>().ToTable("Ninja");
        //  //  modelBuilder.Entity<Clan>().ToTable("Clan");
        //  //  modelBuilder.Entity<NinjaEquipment>().ToTable("NinjaEquipment");
        //}

    }
    public class CourrierDBInitializer : DropCreateDatabaseAlways<CourrierDataContext>
    {
        protected override void Seed(CourrierDataContext context)
        {
            base.Seed(context);
        }
    }
}
