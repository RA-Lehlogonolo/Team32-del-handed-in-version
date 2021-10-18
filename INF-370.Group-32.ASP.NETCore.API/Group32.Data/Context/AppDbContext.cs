
using Group32.Core.AnnouncementManagement;
using Group32.Core.AssociativeEntity;
using Group32.Core.AuditLogs;
using Group32.Core.CampusResidence;
using Group32.Core.DisciplinaryHearingManagement;
using Group32.Core.EventManagement;
using Group32.Core.Facility;
using Group32.Core.Identity;
using Group32.Core.ResidenceManagement;
using Group32.Core.Users;
using Group32.Core.VillageFreshManagement;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Data.Context
{
   public class AppDbContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _configuration;
        public  AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // configure 1-1 relationships for users 
            builder.Entity<AppUser>()
                .HasOne(a => a.HouseParent)
                .WithOne(b => b.AppUser)
                .HasForeignKey<HouseParent>(b => b.AppUserId);
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
           .HasOne(a => a.Student)
           .WithOne(b => b.AppUser)
           .HasForeignKey<Student>(b => b.AppUserId);

            builder.Entity<AppUser>()
          .HasOne(a => a.BuildingCoordinator)
          .WithOne(b => b.AppUser)
          .HasForeignKey<BuildingCoordinator>(b => b.AppUserId);

            builder.Entity<AppUser>()
         .HasOne(a => a.VillageFreshM)
         .WithOne(b => b.AppUser)
         .HasForeignKey<VillageFreshM>(b => b.AppUserId);

            builder.Entity<StudentRoom>()
         .HasKey(sc => new { sc.StudentId, sc.RoomId });

         //announcements configurations
          
            //village fresh entity relationships  configurations
      builder.Entity<MealItem>().HasKey(sc => new { sc.MealId, sc.ItemId });

            builder.Entity<MenuTypeDay>().HasKey(sc => new { sc.MenuTypeId, sc.DayId });

            builder.Entity<DayDate>().HasKey(sc => new { sc.DayId, sc.DateId });

            builder.Entity<MenuTypeDayMealType>().HasKey(sc => new { sc.MenuTypeId, sc.DayId, sc.MealTypeId, sc.MealId });


            base.OnModelCreating(builder);

        }

        public DbSet<AppUser>AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AnnouncementType> AnnouncementTypes { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<ResidenceType> ResidenceTypes { get; set; }
        public DbSet<MisconductType> MisconductTypes { get; set; }
        public DbSet<DisciplinaryHearing> DisciplinaryHearings { get; set; }
        public DbSet<StudentRole> StudentRoles { get; set; }
        public DbSet<MaintananceRequestType> MaintananceRequestTypes { get; set; }
        public DbSet<MaintananceRequestCategory> MaintananceRequestCategories { get; set; }
        public DbSet<MaintananceRequest> MaintananceRequests { get; set; }
        public DbSet<HouseParent> HouseParents { get; set; }
        public DbSet<BuildingCoordinator> buildingCoordinators { get; set; }
        public DbSet<VillageFreshM> villageFreshMs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRoom> StudentRooms { get; set; }
        public DbSet<ResidenceAllocationAuditLog> ResidenceAllocationAuditLogs { get; set; }
        public DbSet<MealItem> MealItems { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<EventType>  EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }




    }
}
