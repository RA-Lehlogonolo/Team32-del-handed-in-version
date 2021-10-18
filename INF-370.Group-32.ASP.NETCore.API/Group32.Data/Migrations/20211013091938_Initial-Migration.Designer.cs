﻿// <auto-generated />
using System;
using Group32.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Group32.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211013091938_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Group32.Core.AssociativeEntity.StudentRoom", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("MoveInDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveOutDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("StudentRooms");
                });

            modelBuilder.Entity("Group32.Core.AuditLogs.ResidenceAllocationAuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Initiator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.HasIndex("StudentId");

                    b.ToTable("ResidenceAllocationAuditLogs");
                });

            modelBuilder.Entity("Group32.Core.CampusResidence.Campus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Campuses");
                });

            modelBuilder.Entity("Group32.Core.CampusResidence.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaintananceRequestCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MaintananceRequestTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentRoomRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentRoomStudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintananceRequestCategoryId");

                    b.HasIndex("MaintananceRequestTypeId");

                    b.HasIndex("StudentRoomStudentId", "StudentRoomRoomId");

                    b.ToTable("MaintananceRequests");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequestCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaintananceRequestTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MaintananceRequestTypeId");

                    b.ToTable("MaintananceRequestCategories");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("MaintananceRequestTypes");
                });

            modelBuilder.Entity("Group32.Core.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AutoAssignedPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Residence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CampusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ResidenceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.HasIndex("ResidenceTypeId");

                    b.ToTable("Residences");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.ResidenceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ResidenceTypes");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<string>("Corridor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RoomStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.StudentRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("StudentRoles");
                });

            modelBuilder.Entity("Group32.Core.Users.BuildingCoordinator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.HasIndex("ResidenceId");

                    b.ToTable("buildingCoordinators");
                });

            modelBuilder.Entity("Group32.Core.Users.HouseParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.HasIndex("ResidenceId");

                    b.ToTable("HouseParents");
                });

            modelBuilder.Entity("Group32.Core.Users.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AssignedToRoom")
                        .HasColumnType("bit");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelOfStudy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.Property<int>("StudentRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.HasIndex("FacultyId");

                    b.HasIndex("ResidenceId");

                    b.HasIndex("StudentRoleId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Group32.Core.Users.VillageFreshM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.ToTable("villageFreshMs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Group32.Core.Identity.AppRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasDiscriminator().HasValue("AppRole");
                });

            modelBuilder.Entity("Group32.Core.AssociativeEntity.StudentRoom", b =>
                {
                    b.HasOne("Group32.Core.ResidenceManagement.Room", "Room")
                        .WithMany("StudentRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.Users.Student", "Student")
                        .WithMany("StudentRooms")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Group32.Core.AuditLogs.ResidenceAllocationAuditLog", b =>
                {
                    b.HasOne("Group32.Core.ResidenceManagement.Residence", "Residence")
                        .WithMany("AllocationLog")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.Users.Student", "Student")
                        .WithMany("ResidenceAllocationLog")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Group32.Core.CampusResidence.Faculty", b =>
                {
                    b.HasOne("Group32.Core.CampusResidence.Campus", "Campus")
                        .WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequest", b =>
                {
                    b.HasOne("Group32.Core.Facility.MaintananceRequestCategory", "MaintananceRequestCategory")
                        .WithMany("MaintananceRequests")
                        .HasForeignKey("MaintananceRequestCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.Facility.MaintananceRequestType", "MaintananceRequestType")
                        .WithMany("MaintananceRequests")
                        .HasForeignKey("MaintananceRequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.AssociativeEntity.StudentRoom", "StudentRoom")
                        .WithMany("MaintananceRequests")
                        .HasForeignKey("StudentRoomStudentId", "StudentRoomRoomId");

                    b.Navigation("MaintananceRequestCategory");

                    b.Navigation("MaintananceRequestType");

                    b.Navigation("StudentRoom");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequestCategory", b =>
                {
                    b.HasOne("Group32.Core.Facility.MaintananceRequestType", "MaintananceRequestType")
                        .WithMany("MaintananceRequestCategories")
                        .HasForeignKey("MaintananceRequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintananceRequestType");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Block", b =>
                {
                    b.HasOne("Group32.Core.ResidenceManagement.Residence", "Residence")
                        .WithMany("Blocks")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Residence", b =>
                {
                    b.HasOne("Group32.Core.CampusResidence.Campus", "Campus")
                        .WithMany("Residences")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.ResidenceManagement.ResidenceType", "ResidenceType")
                        .WithMany("Residences")
                        .HasForeignKey("ResidenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");

                    b.Navigation("ResidenceType");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Room", b =>
                {
                    b.HasOne("Group32.Core.ResidenceManagement.Block", "Block")
                        .WithMany("Rooms")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.StudentRole", b =>
                {
                    b.HasOne("Group32.Core.ResidenceManagement.Residence", "Residence")
                        .WithMany("StudentRoles")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");
                });

            modelBuilder.Entity("Group32.Core.Users.BuildingCoordinator", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", "AppUser")
                        .WithOne("BuildingCoordinator")
                        .HasForeignKey("Group32.Core.Users.BuildingCoordinator", "AppUserId");

                    b.HasOne("Group32.Core.ResidenceManagement.Residence", "Residence")
                        .WithMany()
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Residence");
                });

            modelBuilder.Entity("Group32.Core.Users.HouseParent", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", "AppUser")
                        .WithOne("HouseParent")
                        .HasForeignKey("Group32.Core.Users.HouseParent", "AppUserId");

                    b.HasOne("Group32.Core.ResidenceManagement.Residence", "Residence")
                        .WithMany("HouseParents")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Residence");
                });

            modelBuilder.Entity("Group32.Core.Users.Student", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", "AppUser")
                        .WithOne("Student")
                        .HasForeignKey("Group32.Core.Users.Student", "AppUserId");

                    b.HasOne("Group32.Core.CampusResidence.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.ResidenceManagement.Residence", "Residence")
                        .WithMany("Students")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.ResidenceManagement.StudentRole", "StudentRole")
                        .WithMany("Students")
                        .HasForeignKey("StudentRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Faculty");

                    b.Navigation("Residence");

                    b.Navigation("StudentRole");
                });

            modelBuilder.Entity("Group32.Core.Users.VillageFreshM", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", "AppUser")
                        .WithOne("VillageFreshM")
                        .HasForeignKey("Group32.Core.Users.VillageFreshM", "AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group32.Core.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Group32.Core.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Group32.Core.AssociativeEntity.StudentRoom", b =>
                {
                    b.Navigation("MaintananceRequests");
                });

            modelBuilder.Entity("Group32.Core.CampusResidence.Campus", b =>
                {
                    b.Navigation("Residences");
                });

            modelBuilder.Entity("Group32.Core.CampusResidence.Faculty", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequestCategory", b =>
                {
                    b.Navigation("MaintananceRequests");
                });

            modelBuilder.Entity("Group32.Core.Facility.MaintananceRequestType", b =>
                {
                    b.Navigation("MaintananceRequestCategories");

                    b.Navigation("MaintananceRequests");
                });

            modelBuilder.Entity("Group32.Core.Identity.AppUser", b =>
                {
                    b.Navigation("BuildingCoordinator");

                    b.Navigation("HouseParent");

                    b.Navigation("Student");

                    b.Navigation("VillageFreshM");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Block", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Residence", b =>
                {
                    b.Navigation("AllocationLog");

                    b.Navigation("Blocks");

                    b.Navigation("HouseParents");

                    b.Navigation("StudentRoles");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.ResidenceType", b =>
                {
                    b.Navigation("Residences");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.Room", b =>
                {
                    b.Navigation("StudentRooms");
                });

            modelBuilder.Entity("Group32.Core.ResidenceManagement.StudentRole", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Group32.Core.Users.Student", b =>
                {
                    b.Navigation("ResidenceAllocationLog");

                    b.Navigation("StudentRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
