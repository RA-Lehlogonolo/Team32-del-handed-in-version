using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Group32.Data.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AnnouncementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MisconductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MisconductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementTypeId = table.Column<int>(type: "int", nullable: false),
                    ResidenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_AnnouncementTypes_AnnouncementTypeId",
                        column: x => x.AnnouncementTypeId,
                        principalTable: "AnnouncementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Residences_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayDate",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayDate", x => new { x.DayId, x.DateId });
                    table.ForeignKey(
                        name: "FK_DayDate_Date_DateId",
                        column: x => x.DateId,
                        principalTable: "Date",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayDate_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuTypeDay",
                columns: table => new
                {
                    MenuTypeId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTypeDay", x => new { x.MenuTypeId, x.DayId });
                    table.ForeignKey(
                        name: "FK_MenuTypeDay_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuTypeDay_MenuTypes_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "MenuTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaryHearings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desscription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MisconductTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryHearings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaryHearings_MisconductTypes_MisconductTypeId",
                        column: x => x.MisconductTypeId,
                        principalTable: "MisconductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaryHearings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealItems",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealItems", x => new { x.MealId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_MealItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealItems_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuTypeDayMealType",
                columns: table => new
                {
                    MenuTypeId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    MealTypeId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    MenuTypeDayDayId = table.Column<int>(type: "int", nullable: true),
                    MenuTypeDayMenuTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTypeDayMealType", x => new { x.MenuTypeId, x.DayId, x.MealTypeId, x.MealId });
                    table.ForeignKey(
                        name: "FK_MenuTypeDayMealType_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuTypeDayMealType_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuTypeDayMealType_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuTypeDayMealType_MenuTypeDay_MenuTypeDayMenuTypeId_MenuTypeDayDayId",
                        columns: x => new { x.MenuTypeDayMenuTypeId, x.MenuTypeDayDayId },
                        principalTable: "MenuTypeDay",
                        principalColumns: new[] { "MenuTypeId", "DayId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuTypeDayMealType_MenuTypes_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "MenuTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementTypeId",
                table: "Announcements",
                column: "AnnouncementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ResidenceId",
                table: "Announcements",
                column: "ResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_DayDate_DateId",
                table: "DayDate",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryHearings_MisconductTypeId",
                table: "DisciplinaryHearings",
                column: "MisconductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryHearings_StudentId",
                table: "DisciplinaryHearings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealItems_ItemId",
                table: "MealItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypeDay_DayId",
                table: "MenuTypeDay",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypeDayMealType_DayId",
                table: "MenuTypeDayMealType",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypeDayMealType_MealId",
                table: "MenuTypeDayMealType",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypeDayMealType_MealTypeId",
                table: "MenuTypeDayMealType",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypeDayMealType_MenuTypeDayMenuTypeId_MenuTypeDayDayId",
                table: "MenuTypeDayMealType",
                columns: new[] { "MenuTypeDayMenuTypeId", "MenuTypeDayDayId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "DayDate");

            migrationBuilder.DropTable(
                name: "DisciplinaryHearings");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MealItems");

            migrationBuilder.DropTable(
                name: "MenuTypeDayMealType");

            migrationBuilder.DropTable(
                name: "AnnouncementTypes");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "MisconductTypes");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "MenuTypeDay");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "MenuTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
