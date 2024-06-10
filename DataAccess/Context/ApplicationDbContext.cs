using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =Localhost;Initial Catalog=ToTravelDb;Integrated Security=true;Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts {  get; set; }
        public DbSet<AboutCount> AboutCounts { get; set; }
        public DbSet<BusinessCat> BusinessCats { get; set; }
        public DbSet<CallMe> CallMes { get; set; }
        public DbSet<CallMeInterested> CallMeInteresteds { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Intro> İntroes { get; set; }
        public DbSet<IntroCat> İntroCategories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoCategory> PhotoCategories { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<ServicePackageDescription> ServicePackageDescriptions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

    }
}
