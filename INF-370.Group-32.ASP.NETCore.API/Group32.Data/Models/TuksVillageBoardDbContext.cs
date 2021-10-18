using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Group32.Data.Models
{
    public partial class TuksVillageBoardDbContext : DbContext
    {
        public TuksVillageBoardDbContext()
        {
        }

        public TuksVillageBoardDbContext(DbContextOptions<TuksVillageBoardDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<AnnouncementType> AnnouncementTypes { get; set; }
        public virtual DbSet<BlockFloor> BlockFloors { get; set; }
        public virtual DbSet<BuildingCoordinator> BuildingCoordinators { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartLine> CartLines { get; set; }
        public virtual DbSet<CollectionReminder> CollectionReminders { get; set; }
        public virtual DbSet<Date> Dates { get; set; }
        public virtual DbSet<DateSlot> DateSlots { get; set; }
        public virtual DbSet<DateTimeSlot> DateTimeSlots { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<DayDate> DayDates { get; set; }
        public virtual DbSet<DisciplinaryHearing> DisciplinaryHearings { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<HealthInspection> HealthInspections { get; set; }
        public virtual DbSet<HealthInspectionStatus> HealthInspectionStatuses { get; set; }
        public virtual DbSet<HealthInspectionType> HealthInspectionTypes { get; set; }
        public virtual DbSet<HouseParent> HouseParents { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<MaintananceRequest> MaintananceRequests { get; set; }
        public virtual DbSet<MaintananceRequestCategory> MaintananceRequestCategories { get; set; }
        public virtual DbSet<MaintananceRequestType> MaintananceRequestTypes { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<MealItem> MealItems { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<MenuRotation> MenuRotations { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<MenuTypeDay> MenuTypeDays { get; set; }
        public virtual DbSet<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PriceChangeLock> PriceChangeLocks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Relationship34> Relationship34s { get; set; }
        public virtual DbSet<Residence> Residences { get; set; }
        public virtual DbSet<ResidenceDateTimeSlot> ResidenceDateTimeSlots { get; set; }
        public virtual DbSet<ResidenceType> ResidenceTypes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomInspection> RoomInspections { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentEvent> StudentEvents { get; set; }
        public virtual DbSet<StudentRole> StudentRoles { get; set; }
        public virtual DbSet<StudentVisitation> StudentVisitations { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SystemRole> SystemRoles { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VillageFreshManager> VillageFreshManagers { get; set; }
        public virtual DbSet<VisitationApplicationStatus> VisitationApplicationStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TuksVillageBoard-Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("Announcement");

                entity.HasComment("Announcement");

                entity.HasIndex(e => e.AnnouncementType, "RELATIONSHIP_25_FK");

                entity.Property(e => e.AnnouncementId)
                    .ValueGeneratedNever()
                    .HasColumnName("Announcement_ID")
                    .HasComment("Announcement_ID");

                entity.Property(e => e.AnnouncementDescription)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("AnnouncementDescription");

                entity.Property(e => e.AnnouncementName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("AnnouncementName");

                entity.Property(e => e.AnnouncementType).HasComment("AnnouncementType");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Date");

                entity.HasOne(d => d.AnnouncementTypeNavigation)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.AnnouncementType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANNOUNCE_RELATIONS_ANNOUNCE");
            });

            modelBuilder.Entity<AnnouncementType>(entity =>
            {
                entity.HasKey(e => e.AnnouncementType1)
                    .HasName("PK_ANNOUNCEMENTTYPE");

                entity.ToTable("AnnouncementType");

                entity.HasComment("AnnouncementType");

                entity.Property(e => e.AnnouncementType1)
                    .ValueGeneratedNever()
                    .HasColumnName("AnnouncementType")
                    .HasComment("AnnouncementType");

                entity.Property(e => e.AnnouncementTypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("AnnouncementTypeName");
            });

            modelBuilder.Entity<BlockFloor>(entity =>
            {
                entity.HasKey(e => e.BlockId)
                    .HasName("PK_BLOCK_FLOOR");

                entity.ToTable("Block_Floor");

                entity.HasComment("Block/Floor");

                entity.HasIndex(e => e.ResidenceId, "RELATIONSHIP_15_FK");

                entity.Property(e => e.BlockId)
                    .ValueGeneratedNever()
                    .HasColumnName("Block_ID")
                    .HasComment("Block_ID");

                entity.Property(e => e.BlockName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("BlockName");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.BlockFloors)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BLOCK_FL_RELATIONS_RESIDENC");
            });

            modelBuilder.Entity<BuildingCoordinator>(entity =>
            {
                entity.ToTable("BuildingCoordinator");

                entity.HasComment("BuildingCoordinator");

                entity.HasIndex(e => e.ResidenceId, "RELATIONSHIP_22_FK");

                entity.Property(e => e.BuildingCoordinatorId)
                    .ValueGeneratedNever()
                    .HasColumnName("BuildingCoordinator_ID")
                    .HasComment("BuildingCoordinator_ID");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.BuildingCoordinators)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUILDING_RELATIONS_RESIDENC");
            });

            modelBuilder.Entity<Campus>(entity =>
            {
                entity.ToTable("Campus");

                entity.HasComment("Campus");

                entity.Property(e => e.CampusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Campus_ID")
                    .HasComment("Campus_ID");

                entity.Property(e => e.CampusName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("CampusName");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasComment("Cart");

                entity.HasIndex(e => e.OrderId, "RELATIONSHIP_51_FK");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("CartID")
                    .HasComment("CartID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .HasComment("Order_ID");

                entity.Property(e => e.Total).HasComment("Total");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_CART_RELATIONS_ORDER");
            });

            modelBuilder.Entity<CartLine>(entity =>
            {
                entity.ToTable("CartLine");

                entity.HasComment("CartLine");

                entity.HasIndex(e => e.CartId, "RELATIONSHIP_52_FK");

                entity.Property(e => e.CartLineId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CartLineID")
                    .IsFixedLength(true)
                    .HasComment("CartLineID");

                entity.Property(e => e.CartId)
                    .HasColumnName("CartID")
                    .HasComment("CartID");

                entity.Property(e => e.LineTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("LineTotal");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasComment("ProductID");

                entity.Property(e => e.Quantity).HasComment("Quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartLines)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARTLINE_RELATIONS_CART");
            });

            modelBuilder.Entity<CollectionReminder>(entity =>
            {
                entity.ToTable("CollectionReminder");

                entity.HasComment("CollectionReminder");

                entity.HasIndex(e => e.OrderId, "RELATIONSHIP_49_FK");

                entity.Property(e => e.CollectionReminderId)
                    .ValueGeneratedNever()
                    .HasColumnName("CollectionReminderID")
                    .HasComment("CollectionReminderID");

                entity.Property(e => e.CollectionReminderDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("CollectionReminderDescription");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .HasComment("Order_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CollectionReminders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COLLECTI_RELATIONS_ORDER");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.ToTable("Date");

                entity.HasComment("Date");

                entity.Property(e => e.DateId)
                    .ValueGeneratedNever()
                    .HasColumnName("Date_ID")
                    .HasComment("Date_ID");

                entity.Property(e => e.Date1)
                    .HasColumnType("datetime")
                    .HasColumnName("Date")
                    .HasComment("Date");
            });

            modelBuilder.Entity<DateSlot>(entity =>
            {
                entity.HasKey(e => e.DateId)
                    .HasName("PK_DATESLOT");

                entity.ToTable("DateSlot");

                entity.HasComment("DateSlot");

                entity.Property(e => e.DateId)
                    .ValueGeneratedNever()
                    .HasColumnName("DateID")
                    .HasComment("DateID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasComment("Date");
            });

            modelBuilder.Entity<DateTimeSlot>(entity =>
            {
                entity.HasKey(e => new { e.DateId, e.TimeSlotId })
                    .HasName("PK_DATETIMESLOT");

                entity.ToTable("DateTimeSlot");

                entity.HasComment("DateTimeSlot");

                entity.HasIndex(e => e.DateId, "RELATIONSHIP_40_FK");

                entity.HasIndex(e => e.TimeSlotId, "RELATIONSHIP_41_FK");

                entity.Property(e => e.DateId)
                    .HasColumnName("DateID")
                    .HasComment("DateID");

                entity.Property(e => e.TimeSlotId)
                    .HasColumnName("TimeSlotID")
                    .HasComment("TimeSlotID");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.DateTimeSlots)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DATETIME_RELATIONS_DATESLOT");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.DateTimeSlots)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DATETIME_RELATIONS_TIMESLOT");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day");

                entity.HasComment("Day");

                entity.Property(e => e.DayId)
                    .ValueGeneratedNever()
                    .HasColumnName("Day_ID")
                    .HasComment("Day_ID");

                entity.Property(e => e.Day1)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Day")
                    .HasComment("Day");
            });

            modelBuilder.Entity<DayDate>(entity =>
            {
                entity.HasKey(e => new { e.DayId, e.DateId })
                    .HasName("PK_DAY_DATE");

                entity.ToTable("Day_Date");

                entity.HasComment("Day/Date");

                entity.HasIndex(e => e.DateId, "DAY_DATE2_FK");

                entity.HasIndex(e => e.DayId, "DAY_DATE_FK");

                entity.Property(e => e.DayId)
                    .HasColumnName("Day_ID")
                    .HasComment("Day_ID");

                entity.Property(e => e.DateId)
                    .HasColumnName("Date_ID")
                    .HasComment("Date_ID");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.DayDates)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DAY_DATE_DAY_DATE2_DATE");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.DayDates)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DAY_DATE_DAY_DATE_DAY");
            });

            modelBuilder.Entity<DisciplinaryHearing>(entity =>
            {
                entity.ToTable("Disciplinary_Hearing");

                entity.HasComment("Disciplinary Hearing");

                entity.HasIndex(e => e.UserId, "RELATIONSHIP_30_FK");

                entity.Property(e => e.DisciplinaryHearingId)
                    .ValueGeneratedNever()
                    .HasColumnName("DisciplinaryHearing_ID")
                    .HasComment("DisciplinaryHearing_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasComment("Date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Description");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.Property(e => e.Venue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Venue");

                entity.Property(e => e.YearId)
                    .HasColumnName("YearID")
                    .HasComment("YearID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DisciplinaryHearings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISCIPLI_RELATIONS_USER");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.HasComment("Event");

                entity.HasIndex(e => e.ResidenceId, "RELATIONSHIP_39_FK");

                entity.HasIndex(e => e.EventTypeId, "RELATIONSHIP_44_FK");

                entity.HasIndex(e => e.StatusId, "RELATIONSHIP_45_FK");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("Event_ID")
                    .HasComment("Event_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasComment("Date");

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("EventLocation");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("EventName");

                entity.Property(e => e.EventPoster)
                    .HasColumnType("image")
                    .HasComment("EventPoster");

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("EventType_ID")
                    .HasComment("EventType_ID");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasComment("StatusID");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student ID");

                entity.Property(e => e.TimeSlot)
                    .HasColumnType("datetime")
                    .HasComment("TimeSlot");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVENT_RELATIONS_EVENTTYP");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVENT_RELATIONS_RESIDENC");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVENT_RELATIONS_STATUS");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType");

                entity.HasComment("EventType");

                entity.Property(e => e.EventTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventType_ID")
                    .HasComment("EventType_ID");

                entity.Property(e => e.EventTypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("EventTypeDescription");

                entity.Property(e => e.EventTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("EventTypeName");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty");

                entity.HasComment("Faculty");

                entity.HasIndex(e => e.CampusId, "RELATIONSHIP_1_FK");

                entity.Property(e => e.FacultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("Faculty_ID")
                    .HasComment("Faculty_ID");

                entity.Property(e => e.CampusId)
                    .HasColumnName("Campus_ID")
                    .HasComment("Campus_ID");

                entity.Property(e => e.FacultyName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("FacultyName");

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.CampusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACULTY_RELATIONS_CAMPUS");
            });

            modelBuilder.Entity<HealthInspection>(entity =>
            {
                entity.ToTable("HealthInspection");

                entity.HasComment("HealthInspection");

                entity.HasIndex(e => e.HealthInspectionStatusId, "RELATIONSHIP_33_FK");

                entity.HasIndex(e => e.HealthInspectionTypeId, "RELATIONSHIP_36_FK");

                entity.Property(e => e.HealthInspectionId)
                    .ValueGeneratedNever()
                    .HasColumnName("HealthInspection_ID")
                    .HasComment("HealthInspection_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasComment("Date");

                entity.Property(e => e.DifficultyBreathing)
                    .HasColumnName("DifficultyBreathing_")
                    .HasComment("DifficultyBreathing?");

                entity.Property(e => e.HadContactWithAnyoneConfirmedCovid19)
                    .HasColumnName("Had_contact_with_anyone_confirmed_COVID_19_")
                    .HasComment("Had contact with anyone confirmed COVID-19?");

                entity.Property(e => e.HaveCough)
                    .HasColumnName("Have_Cough_")
                    .HasComment("Have Cough?");

                entity.Property(e => e.HaveFever)
                    .HasColumnName("Have_Fever_")
                    .HasComment("Have Fever?");

                entity.Property(e => e.HealthInspectionStatusId)
                    .HasColumnName("HealthInspectionStatusID")
                    .HasComment("HealthInspectionStatusID");

                entity.Property(e => e.HealthInspectionTypeId)
                    .HasColumnName("HealthInspectionType_ID")
                    .HasComment("HealthInspectionType_ID");

                entity.Property(e => e.RedEyes)
                    .HasColumnName("Red_Eyes_")
                    .HasComment("Red Eyes?");

                entity.Property(e => e.Result)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Result");

                entity.Property(e => e.SoreThrot)
                    .HasColumnName("Sore_throt_")
                    .HasComment("Sore throt?");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student ID");

                entity.Property(e => e.TravelledToDifferentProvince)
                    .HasColumnName("Travelled_to_different_province_")
                    .HasComment("Travelled to different province?");

                entity.Property(e => e.TravelledToHighRiskCountry)
                    .HasColumnName("Travelled_to_high_risk_country_")
                    .HasComment("Travelled to high-risk country?");

                entity.Property(e => e.YearId)
                    .HasColumnName("YearID")
                    .HasComment("YearID");

                entity.HasOne(d => d.HealthInspectionStatus)
                    .WithMany(p => p.HealthInspections)
                    .HasForeignKey(d => d.HealthInspectionStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HEALTHIN_RELATIONS_HEALTHIN");
            });

            modelBuilder.Entity<HealthInspectionStatus>(entity =>
            {
                entity.ToTable("HealthInspectionStatus");

                entity.HasComment("HealthInspectionStatus");

                entity.Property(e => e.HealthInspectionStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("HealthInspectionStatusID")
                    .HasComment("HealthInspectionStatusID");

                entity.Property(e => e.HealthInspectionStatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("HealthInspectionStatusDescription");

                entity.Property(e => e.HealthInspectionStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("HealthInspectionStatusName");
            });

            modelBuilder.Entity<HealthInspectionType>(entity =>
            {
                entity.ToTable("HealthInspectionType");

                entity.HasComment("HealthInspectionType");

                entity.Property(e => e.HealthInspectionTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("HealthInspectionType_ID")
                    .HasComment("HealthInspectionType_ID");

                entity.Property(e => e.HealthInspectionTypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("HealthInspectionTypeDescription");
            });

            modelBuilder.Entity<HouseParent>(entity =>
            {
                entity.ToTable("HouseParent");

                entity.HasComment("HouseParent");

                entity.HasIndex(e => e.UserId, "RELATIONSHIP_18_FK");

                entity.HasIndex(e => e.ResidenceId, "RELATIONSHIP_21_FK");

                entity.Property(e => e.HouseParentId)
                    .ValueGeneratedNever()
                    .HasColumnName("HouseParent_ID")
                    .HasComment("HouseParent_ID");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.HouseParents)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOUSEPAR_RELATIONS_RESIDENC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HouseParents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HOUSEPAR_RELATIONS_USER");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.HasComment("Item");

                entity.HasIndex(e => e.ItemTypeId, "HAS_FK");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("ItemID")
                    .HasComment("ItemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ItemName");

                entity.Property(e => e.ItemTypeId)
                    .HasColumnName("ItemTypeID")
                    .HasComment("ItemTypeID");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_HAS_ITEMTYPE");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.HasComment("ItemType");

                entity.Property(e => e.ItemTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ItemTypeID")
                    .HasComment("ItemTypeID");

                entity.Property(e => e.ItemTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ItemTypeName");
            });

            modelBuilder.Entity<MaintananceRequest>(entity =>
            {
                entity.ToTable("MaintananceRequest");

                entity.HasComment("MaintananceRequest");

                entity.HasIndex(e => e.RoomId, "RELATIONSHIP_19_FK");

                entity.HasIndex(e => e.MaintananceRequestTypeId, "RELATIONSHIP_26_FK");

                entity.HasIndex(e => e.MaintanceRequestCategoryId, "RELATIONSHIP_27_FK");

                entity.Property(e => e.MaintananceRequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("MaintananceRequest_ID")
                    .HasComment("MaintananceRequest_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasComment("Date");

                entity.Property(e => e.MaintananceRequestDescription)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("MaintananceRequestDescription");

                entity.Property(e => e.MaintananceRequestTypeId)
                    .HasColumnName("MaintananceRequestType_ID")
                    .HasComment("MaintananceRequestType_ID");

                entity.Property(e => e.MaintanceRequestCategoryId)
                    .HasColumnName("MaintanceRequestCategory_ID")
                    .HasComment("MaintanceRequestCategory_ID");

                entity.Property(e => e.RoomId)
                    .HasColumnName("Room_ID")
                    .HasComment("Room_ID");

                entity.HasOne(d => d.MaintananceRequestType)
                    .WithMany(p => p.MaintananceRequests)
                    .HasForeignKey(d => d.MaintananceRequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAINTANA_RELATIONS_MAINTANA");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.MaintananceRequests)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAINTANA_RELATIONS_ROOM");
            });

            modelBuilder.Entity<MaintananceRequestCategory>(entity =>
            {
                entity.HasKey(e => e.MaintanceRequestCategoryId)
                    .HasName("PK_MAINTANANCEREQUESTCATEGORY");

                entity.ToTable("MaintananceRequestCategory");

                entity.HasComment("MaintananceRequestCategory");

                entity.HasIndex(e => e.MaintananceRequestTypeId, "RELATIONSHIP_16_FK");

                entity.Property(e => e.MaintanceRequestCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("MaintanceRequestCategory_ID")
                    .HasComment("MaintanceRequestCategory_ID");

                entity.Property(e => e.MaintananceRequestCategoryName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("MaintananceRequestCategoryName");

                entity.Property(e => e.MaintananceRequestTypeId)
                    .HasColumnName("MaintananceRequestType_ID")
                    .HasComment("MaintananceRequestType_ID");
            });

            modelBuilder.Entity<MaintananceRequestType>(entity =>
            {
                entity.ToTable("MaintananceRequestType");

                entity.HasComment("MaintananceRequestType");

                entity.Property(e => e.MaintananceRequestTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("MaintananceRequestType_ID")
                    .HasComment("MaintananceRequestType_ID");

                entity.Property(e => e.MaintananceRequestTypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("MaintananceRequestTypeName");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("Meal");

                entity.HasComment("Meal");

                entity.Property(e => e.MealId)
                    .ValueGeneratedNever()
                    .HasColumnName("MealID")
                    .HasComment("MealID");
            });

            modelBuilder.Entity<MealItem>(entity =>
            {
                entity.HasKey(e => new { e.MealId, e.ItemId })
                    .HasName("PK_MEAL_ITEM");

                entity.ToTable("Meal_Item");

                entity.HasComment("Meal/Item");

                entity.HasIndex(e => e.ItemId, "MEAL_ITEM2_FK");

                entity.HasIndex(e => e.MealId, "MEAL_ITEM_FK");

                entity.Property(e => e.MealId)
                    .HasColumnName("MealID")
                    .HasComment("MealID");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasComment("ItemID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.MealItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEAL_ITE_MEAL_ITEM_ITEM");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.MealItems)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEAL_ITE_MEAL_ITEM_MEAL");
            });

            modelBuilder.Entity<MealType>(entity =>
            {
                entity.ToTable("MealType");

                entity.HasComment("MealType");

                entity.Property(e => e.MealTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("MealType_ID")
                    .HasComment("MealType_ID");

                entity.Property(e => e.MealTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("MealTypeName");
            });

            modelBuilder.Entity<MenuRotation>(entity =>
            {
                entity.ToTable("MenuRotation");

                entity.HasComment("MenuRotation");

                entity.HasIndex(e => new { e.MenuTypeId, e.DayId, e.MealTypeId }, "HAS5_FK");

                entity.Property(e => e.MenuRotationId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuRotationID")
                    .HasComment("MenuRotationID");

                entity.Property(e => e.DayId)
                    .HasColumnName("Day_ID")
                    .HasComment("Day_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("EndDate");

                entity.Property(e => e.MealTypeId)
                    .HasColumnName("MealType_ID")
                    .HasComment("MealType_ID");

                entity.Property(e => e.MenuTypeId)
                    .HasColumnName("MenuType_ID")
                    .HasComment("MenuType_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasComment("StartDate");

                entity.HasOne(d => d.MenuTypeDayMealType)
                    .WithMany(p => p.MenuRotations)
                    .HasForeignKey(d => new { d.MenuTypeId, d.DayId, d.MealTypeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUROTA_HAS5_MENUTYPE");
            });

            modelBuilder.Entity<MenuType>(entity =>
            {
                entity.ToTable("MenuType");

                entity.HasComment("MenuType");

                entity.Property(e => e.MenuTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuType_ID")
                    .HasComment("MenuType_ID");

                entity.Property(e => e.MenuTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("MenuTypeName");
            });

            modelBuilder.Entity<MenuTypeDay>(entity =>
            {
                entity.HasKey(e => new { e.MenuTypeId, e.DayId })
                    .HasName("PK_MENUTYPE_DAY");

                entity.ToTable("MenuType_Day");

                entity.HasComment("MenuType/Day");

                entity.HasIndex(e => e.MenuTypeId, "HAS2_FK");

                entity.HasIndex(e => e.DayId, "HAS3_FK");

                entity.Property(e => e.MenuTypeId)
                    .HasColumnName("MenuType_ID")
                    .HasComment("MenuType_ID");

                entity.Property(e => e.DayId)
                    .HasColumnName("Day_ID")
                    .HasComment("Day_ID");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.MenuTypeDays)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUTYPE_HAS3_DAY");

                entity.HasOne(d => d.MenuType)
                    .WithMany(p => p.MenuTypeDays)
                    .HasForeignKey(d => d.MenuTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUTYPE_HAS2_MENUTYPE");
            });

            modelBuilder.Entity<MenuTypeDayMealType>(entity =>
            {
                entity.HasKey(e => new { e.MenuTypeId, e.DayId, e.MealTypeId })
                    .HasName("PK_MENUTYPE_DAY_MEALTYPE");

                entity.ToTable("MenuType_Day_MealType");

                entity.HasComment("MenuType/Day/MealType");

                entity.HasIndex(e => e.MealId, "HAS4_FK");

                entity.HasIndex(e => e.MenuRotationId, "HAS6_FK");

                entity.HasIndex(e => e.MealTypeId, "HAVE2_FK");

                entity.HasIndex(e => new { e.MenuTypeId, e.DayId }, "HAVE_FK");

                entity.Property(e => e.MenuTypeId)
                    .HasColumnName("MenuType_ID")
                    .HasComment("MenuType_ID");

                entity.Property(e => e.DayId)
                    .HasColumnName("Day_ID")
                    .HasComment("Day_ID");

                entity.Property(e => e.MealTypeId)
                    .HasColumnName("MealType_ID")
                    .HasComment("MealType_ID");

                entity.Property(e => e.MealId)
                    .HasColumnName("MealID")
                    .HasComment("MealID");

                entity.Property(e => e.MenuRotationId)
                    .HasColumnName("MenuRotationID")
                    .HasComment("MenuRotationID");

                entity.Property(e => e.MenuTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("MenuTitle");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.MenuTypeDayMealTypes)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUTYPE_HAS4_MEAL");

                entity.HasOne(d => d.MealType)
                    .WithMany(p => p.MenuTypeDayMealTypes)
                    .HasForeignKey(d => d.MealTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUTYPE_HAVE2_MEALTYPE");

                entity.HasOne(d => d.MenuRotation)
                    .WithMany(p => p.MenuTypeDayMealTypes)
                    .HasForeignKey(d => d.MenuRotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUTYPE_HAS6_MENUROTA");

                entity.HasOne(d => d.MenuTypeDay)
                    .WithMany(p => p.MenuTypeDayMealTypes)
                    .HasForeignKey(d => new { d.MenuTypeId, d.DayId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENUTYPE_HAVE_MENUTYPE");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasComment("Order");

                entity.HasIndex(e => e.OrderStatusId, "RELATIONSHIP_46_FK");

                entity.HasIndex(e => e.CartId, "RELATIONSHIP_50_FK");

                entity.HasIndex(e => e.PaymentId, "RELATIONSHIP_54_FK");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("Order_ID")
                    .HasComment("Order_ID");

                entity.Property(e => e.CartId)
                    .HasColumnName("CartID")
                    .HasComment("CartID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasComment("OrderDate");

                entity.Property(e => e.OrderDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("OrderDescription");

                entity.Property(e => e.OrderNumber)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("OrderNumber");

                entity.Property(e => e.OrderStatusId)
                    .HasColumnName("OrderStatus_ID")
                    .HasComment("OrderStatus_ID");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("Payment_ID")
                    .HasComment("Payment_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_RELATIONS_CART");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_RELATIONS_ORDERSTA");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_ORDER_RELATIONS_PAYMENT");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId })
                    .HasName("PK_ORDERLINE");

                entity.ToTable("OrderLine");

                entity.HasComment("OrderLine");

                entity.HasIndex(e => e.OrderId, "ORDERLINE2_FK");

                entity.HasIndex(e => e.ProductId, "ORDERLINE_FK");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .HasComment("Product_ID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .HasComment("Order_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLIN_ORDERLINE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLIN_ORDERLINE_PRODUCT");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.HasComment("OrderStatus");

                entity.Property(e => e.OrderStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderStatus_ID")
                    .HasComment("OrderStatus_ID");

                entity.Property(e => e.OrderStatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("OrderStatusDescription");

                entity.Property(e => e.OrderStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("OrderStatusName");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.HasComment("Payment");

                entity.HasIndex(e => e.OrderId, "RELATIONSHIP_53_FK");

                entity.HasIndex(e => e.PaymentTypeId, "RELATIONSHIP_55_FK");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Payment_ID")
                    .HasComment("Payment_ID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .HasComment("Order_ID");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("money")
                    .HasComment("PaymentAmount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasComment("PaymentDate");

                entity.Property(e => e.PaymentStatusId)
                    .HasColumnName("PaymentStatus_ID")
                    .HasComment("PaymentStatus_ID");

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnName("PaymentType_ID")
                    .HasComment("PaymentType_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENT_RELATIONS_ORDER");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENT_RELATIONS_PAYMENTT");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.HasComment("PaymentType");

                entity.Property(e => e.PaymentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PaymentType_ID")
                    .HasComment("PaymentType_ID");

                entity.Property(e => e.PaymentTypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("PaymentTypeDescription");
            });

            modelBuilder.Entity<PriceChangeLock>(entity =>
            {
                entity.HasKey(e => e.PriceChangeLock1)
                    .HasName("PK_PRICECHANGELOCK");

                entity.ToTable("PriceChangeLock");

                entity.HasComment("PriceChangeLock");

                entity.HasIndex(e => e.ProductId, "RELATIONSHIP_32_FK");

                entity.Property(e => e.PriceChangeLock1)
                    .ValueGeneratedNever()
                    .HasColumnName("PriceChangeLock")
                    .HasComment("PriceChangeLock");

                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Price");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .HasComment("Product_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PriceChangeLocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRICECHA_RELATIONS_PRODUCT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasComment("Product");

                entity.HasIndex(e => e.ProductTypeId, "RELATIONSHIP_24_FK");

                entity.HasIndex(e => e.SizeId, "RELATIONSHIP_31_FK");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_ID")
                    .HasComment("Product_ID");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ProductDescription");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ProductImage");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ProductName");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("ProductType_ID")
                    .HasComment("ProductType_ID");

                entity.Property(e => e.SizeId)
                    .HasColumnName("SizeID")
                    .HasComment("SizeID");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_RELATIONS_PRODUCTT");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_RELATIONS_SIZE");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.HasComment("ProductType");

                entity.HasIndex(e => e.SupplierId, "RELATIONSHIP_23_FK");

                entity.Property(e => e.ProductTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductType_ID")
                    .HasComment("ProductType_ID");

                entity.Property(e => e.ProductTypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ProductTypeName");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("Supplier_ID")
                    .HasComment("Supplier_ID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTT_RELATIONS_SUPPLIER");
            });

            modelBuilder.Entity<Relationship34>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.HealthInspectionId })
                    .HasName("PK_RELATIONSHIP_34");

                entity.ToTable("Relationship_34");

                entity.HasComment("Relationship_34");

                entity.HasIndex(e => e.StudentId, "RELATIONSHIP_34_FK");

                entity.HasIndex(e => e.HealthInspectionId, "RELATIONSHIP_35_FK");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student_ID");

                entity.Property(e => e.HealthInspectionId)
                    .HasColumnName("HealthInspection_ID")
                    .HasComment("HealthInspection_ID");

                entity.HasOne(d => d.HealthInspection)
                    .WithMany(p => p.Relationship34s)
                    .HasForeignKey(d => d.HealthInspectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_RELATIONS_HEALTHIN");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Relationship34s)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_RELATIONS_STUDENT");
            });

            modelBuilder.Entity<Residence>(entity =>
            {
                entity.ToTable("Residence");

                entity.HasComment("Residence");

                entity.HasIndex(e => e.ResidenceTypeId, "RELATIONSHIP_2_FK");

                entity.HasIndex(e => e.CampusId, "RELATIONSHIP_3_FK");

                entity.Property(e => e.ResidenceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.Property(e => e.CampusId)
                    .HasColumnName("Campus_ID")
                    .HasComment("Campus_ID");

                entity.Property(e => e.ResidenceAddrress)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ResidenceAddrress");

                entity.Property(e => e.ResidenceName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ResidenceName");

                entity.Property(e => e.ResidenceTypeId)
                    .HasColumnName("ResidenceType_ID")
                    .HasComment("ResidenceType_ID");

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Residences)
                    .HasForeignKey(d => d.CampusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENC_RELATIONS_CAMPUS");

                entity.HasOne(d => d.ResidenceType)
                    .WithMany(p => p.Residences)
                    .HasForeignKey(d => d.ResidenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENC_RELATIONS_RESIDENC");
            });

            modelBuilder.Entity<ResidenceDateTimeSlot>(entity =>
            {
                entity.HasKey(e => new { e.DateId, e.TimeSlotId, e.ResidenceId })
                    .HasName("PK_RESIDENCE_DATETIMESLOT");

                entity.ToTable("Residence_DateTimeSlot");

                entity.HasComment("Residence/DateTimeSlot");

                entity.HasIndex(e => e.ResidenceId, "RESIDENCE_DATETIMESLOT2_FK");

                entity.HasIndex(e => new { e.DateId, e.TimeSlotId }, "RESIDENCE_DATETIMESLOT_FK");

                entity.Property(e => e.DateId)
                    .HasColumnName("DateID")
                    .HasComment("DateID");

                entity.Property(e => e.TimeSlotId)
                    .HasColumnName("TimeSlotID")
                    .HasComment("TimeSlotID");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.ResidenceDateTimeSlots)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENC_RESIDENCE_RESIDENC");

                entity.HasOne(d => d.DateTimeSlot)
                    .WithMany(p => p.ResidenceDateTimeSlots)
                    .HasForeignKey(d => new { d.DateId, d.TimeSlotId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESIDENC_RESIDENCE_DATETIME");
            });

            modelBuilder.Entity<ResidenceType>(entity =>
            {
                entity.ToTable("ResidenceType");

                entity.HasComment("ResidenceType");

                entity.Property(e => e.ResidenceTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ResidenceType_ID")
                    .HasComment("ResidenceType_ID");

                entity.Property(e => e.ResidenceTypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("ResidenceTypeName");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasComment("Room");

                entity.HasIndex(e => e.RoomInspectionId, "RELATIONSHIP_28_FK");

                entity.HasIndex(e => e.BlockId, "RELATIONSHIP_5_FK");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("Room_ID")
                    .HasComment("Room_ID");

                entity.Property(e => e.BlockId)
                    .HasColumnName("Block_ID")
                    .HasComment("Block_ID");

                entity.Property(e => e.Corridor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Corridor");

                entity.Property(e => e.RoomInspectionId)
                    .HasColumnName("RoomInspection_ID")
                    .HasComment("RoomInspection_ID");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("RoomNumber");

                entity.Property(e => e.RoomStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("RoomStatus");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("RoomType");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROOM_RELATIONS_BLOCK_FL");

                entity.HasOne(d => d.RoomInspection)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomInspectionId)
                    .HasConstraintName("FK_ROOM_RELATIONS_ROOMINSP");
            });

            modelBuilder.Entity<RoomInspection>(entity =>
            {
                entity.ToTable("RoomInspection");

                entity.HasComment("RoomInspection");

                entity.Property(e => e.RoomInspectionId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoomInspection_ID")
                    .HasComment("RoomInspection_ID");

                entity.Property(e => e.Ceiling)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Ceiling");

                entity.Property(e => e.Chair)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Chair");

                entity.Property(e => e.CurtainBlinds)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Curtain_Blinds")
                    .IsFixedLength(true)
                    .HasComment("Curtain/Blinds");

                entity.Property(e => e.CurtainRailHooks)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CurtainRail_Hooks")
                    .IsFixedLength(true)
                    .HasComment("CurtainRail/Hooks");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasComment("Date");

                entity.Property(e => e.DoorLock)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Door_Lock")
                    .IsFixedLength(true)
                    .HasComment("Door Lock");

                entity.Property(e => e.FloorCarpet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Floor_Carpet")
                    .IsFixedLength(true)
                    .HasComment("Floor/Carpet");

                entity.Property(e => e.Globes)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Globes");

                entity.Property(e => e.LightSwitehes)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("LightSwitehes");

                entity.Property(e => e.Mattress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Mattress");

                entity.Property(e => e.Mirror)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Mirror");

                entity.Property(e => e.Other)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Other");

                entity.Property(e => e.RoomDoor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Room_Door")
                    .IsFixedLength(true)
                    .HasComment("Room Door");

                entity.Property(e => e.StudyDesk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Study_Desk")
                    .IsFixedLength(true)
                    .HasComment("Study Desk");

                entity.Property(e => e.WallSockets)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wall_Sockets")
                    .IsFixedLength(true)
                    .HasComment("Wall Sockets");

                entity.Property(e => e.Walls)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Walls");

                entity.Property(e => e.WardrobeDoors)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wardrobe_Doors")
                    .IsFixedLength(true)
                    .HasComment("Wardrobe Doors");

                entity.Property(e => e.WardrobeShelves)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wardrobe_Shelves")
                    .IsFixedLength(true)
                    .HasComment("Wardrobe Shelves");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.HasComment("Size");

                entity.Property(e => e.SizeId)
                    .ValueGeneratedNever()
                    .HasColumnName("SizeID")
                    .HasComment("SizeID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("SizeName");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.HasComment("Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusID")
                    .HasComment("StatusID");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasComment("Event_ID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("StatusName");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasComment("Student");

                entity.HasIndex(e => e.UserId, "RELATIONSHIP_13_FK");

                entity.HasIndex(e => e.FacultyId, "RELATIONSHIP_17_FK");

                entity.HasIndex(e => e.ResidenceId, "RELATIONSHIP_7_FK");

                entity.HasIndex(e => e.StudentRoleId, "RELATIONSHIP_8_FK");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Student_ID")
                    .HasComment("Student_ID");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("Faculty_ID")
                    .HasComment("Faculty_ID");

                entity.Property(e => e.LevelOfStudy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("LevelOfStudy");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.Property(e => e.StudentRoleId)
                    .HasColumnName("StudentRole_ID")
                    .HasComment("StudentRole_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_RELATIONS_FACULTY");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_RELATIONS_RESIDENC");

                entity.HasOne(d => d.StudentRole)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_RELATIONS_STUDENTR");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_RELATIONS_USER");
            });

            modelBuilder.Entity<StudentEvent>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.StudentId })
                    .HasName("PK_STUDENTEVENT");

                entity.ToTable("StudentEvent");

                entity.HasComment("StudentEvent");

                entity.HasIndex(e => e.StudentId, "STUDENTEVENT2_FK");

                entity.HasIndex(e => e.EventId, "STUDENTEVENT_FK");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasComment("Event_ID");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student_ID");

                entity.Property(e => e.Rsvp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RSVP")
                    .IsFixedLength(true)
                    .HasComment("RSVP");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StudentEvents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTE_STUDENTEV_EVENT");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentEvents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTE_STUDENTEV_STUDENT");
            });

            modelBuilder.Entity<StudentRole>(entity =>
            {
                entity.ToTable("StudentRole");

                entity.HasComment("StudentRole");

                entity.HasIndex(e => e.ResidenceId, "RELATIONSHIP_10_FK");

                entity.HasIndex(e => e.StudentId, "RELATIONSHIP_9_FK");

                entity.Property(e => e.StudentRoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentRole_ID")
                    .HasComment("StudentRole_ID");

                entity.Property(e => e.ResidenceId)
                    .HasColumnName("Residence_ID")
                    .HasComment("Residence_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("RoleName");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student_ID");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.StudentRoles)
                    .HasForeignKey(d => d.ResidenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTR_RELATIONS_RESIDENC");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentRoles)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTR_RELATIONS_STUDENT");
            });

            modelBuilder.Entity<StudentVisitation>(entity =>
            {
                entity.ToTable("StudentVisitation");

                entity.HasComment("StudentVisitation");

                entity.HasIndex(e => e.StudentId, "RELATIONSHIP_37_FK");

                entity.HasIndex(e => e.VisitationApplicationStatusId, "RELATIONSHIP_38_FK");

                entity.Property(e => e.StudentVisitationId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentVisitation_ID")
                    .HasComment("StudentVisitation_ID");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Application_Date")
                    .HasComment("Application Date");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("EndDate");

                entity.Property(e => e.HostName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("HostName");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Reason");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasComment("StartDate");

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("StudentEmail");

                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_ID")
                    .HasComment("Student_ID");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("StudentName");

                entity.Property(e => e.StudentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("StudentNumber");

                entity.Property(e => e.StudentSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("StudentSurname");

                entity.Property(e => e.UseUserId)
                    .HasColumnName("Use_User_ID")
                    .HasComment("Use_User_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.Property(e => e.VisitAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("VisitAddress");

                entity.Property(e => e.VisitationApplicationStatusId)
                    .HasColumnName("VisitationApplicationStatus_ID")
                    .HasComment("VisitationApplicationStatus_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentVisitations)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTV_RELATIONS_STUDENT");

                entity.HasOne(d => d.VisitationApplicationStatus)
                    .WithMany(p => p.StudentVisitations)
                    .HasForeignKey(d => d.VisitationApplicationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTV_RELATIONS_VISITATI");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.HasComment("Supplier");

                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("Supplier_ID")
                    .HasComment("Supplier_ID");

                entity.Property(e => e.SupplierAddress)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("SupplierAddress");

                entity.Property(e => e.SupplierEmail)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("SupplierEmail");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("SupplierName");

                entity.Property(e => e.SupplierPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("SupplierPhoneNumber");
            });

            modelBuilder.Entity<SystemRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_SYSTEMROLE");

                entity.ToTable("SystemRole");

                entity.HasComment("SystemRole");

                entity.HasIndex(e => e.UserId, "RELATIONSHIP_12_FK");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_ID")
                    .HasComment("Role_ID");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("RoleDescription");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("RoleName");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SystemRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSTEMRO_RELATIONS_USER");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.HasComment("TimeSlot");

                entity.Property(e => e.TimeSlotId)
                    .ValueGeneratedNever()
                    .HasColumnName("TimeSlotID")
                    .HasComment("TimeSlotID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("EndTime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("StartTime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasComment("User");

                entity.HasIndex(e => e.RoleId, "RELATIONSHIP_11_FK");

                entity.HasIndex(e => e.AnnouncementId, "RELATIONSHIP_29_FK");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.Property(e => e.AnnouncementId)
                    .HasColumnName("Announcement_ID")
                    .HasComment("Announcement_ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("EmailAddress");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("PhoneNumber");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_ID")
                    .HasComment("Role_ID");

                entity.Property(e => e.Surname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Surname");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("UserName");

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AnnouncementId)
                    .HasConstraintName("FK_USER_RELATIONS_ANNOUNCE");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_RELATIONS_SYSTEMRO");
            });

            modelBuilder.Entity<VillageFreshManager>(entity =>
            {
                entity.ToTable("VillageFreshManager");

                entity.HasComment("VillageFreshManager");

                entity.HasIndex(e => e.UserId, "RELATIONSHIP_14_FK");

                entity.Property(e => e.VillageFreshManagerId)
                    .ValueGeneratedNever()
                    .HasColumnName("VillageFreshManager_ID")
                    .HasComment("VillageFreshManager_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasComment("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VillageFreshManagers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VILLAGEF_RELATIONS_USER");
            });

            modelBuilder.Entity<VisitationApplicationStatus>(entity =>
            {
                entity.ToTable("VisitationApplicationStatus");

                entity.HasComment("VisitationApplicationStatus");

                entity.Property(e => e.VisitationApplicationStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("VisitationApplicationStatus_ID")
                    .HasComment("VisitationApplicationStatus_ID");

                entity.Property(e => e.VisitationApplicationStatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("VisitationApplicationStatusDescription");

                entity.Property(e => e.VisitationApplicationStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("VisitationApplicationStatusName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
