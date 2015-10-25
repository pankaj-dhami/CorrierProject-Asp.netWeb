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

        public DbSet<AddressInformation> AddressInformation { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<ParcelDetails> ParcelDetails { get; set; }
        public DbSet<ParcelType> ParcelType { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<TrackingInformation> TrackingInformation { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
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
