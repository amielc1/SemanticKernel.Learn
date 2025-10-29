using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BethanysPieShop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PieRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieRecipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPieOfTheWeek = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PieId = table.Column<int>(type: "int", nullable: true),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    CustomerSentimentScore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PieId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Pies_PieId",
                        column: x => x.PieId,
                        principalTable: "Pies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSupportMessage = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketMessageSentiment = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketMessages_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderPlaced" },
                values: new object[,]
                {
                    { 1, 342, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 721, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 104, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 587, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 913, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 482, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 951, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 215, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 692, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 812, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 523, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 341, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 782, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 699, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 208, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 945, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 134, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 673, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 287, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 495, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 219, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 327, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 721, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 589, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 814, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 312, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 637, new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 476, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 589, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 971, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 742, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 145, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 634, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 958, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 281, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 374, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 543, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 189, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 624, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 731, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 441, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 368, new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 984, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 591, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 347, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 862, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 539, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 281, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 104, new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 413, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 632, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 891, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 356, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 531, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 289, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 613, new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 746, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 294, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 729, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 882, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 549, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 412, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 101, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 908, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 305, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 479, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 226, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 347, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 688, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 351, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 978, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 715, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 813, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 147, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 624, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 912, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 739, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 332, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 831, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 521, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 488, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 607, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 879, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 734, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 188, new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 297, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 698, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 846, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 193, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 657, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 321, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 829, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 551, new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 399, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 664, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 257, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 498, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 144, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 796, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 216, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PieRecipes",
                columns: new[] { "Id", "Ingredients", "Name", "Steps" },
                values: new object[,]
                {
                    { 1, "6 cups apples, 1/2 cup sugar, 1/4 cup brown sugar, 1/4 cup flour, 1 tsp cinnamon, 1/4 tsp nutmeg, pinch of salt, 2 tbsp butter, pie crust", "Classic Apple Pie", "1. Preheat oven to 425°F (220°C). Prepare a 9-inch pie dish with a bottom crust. 2. Peel, core, and slice 6 cups of apples (a mix of Granny Smith and Honeycrisp recommended). 3. In a bowl, mix apples with 1/2 cup sugar, 1/4 cup brown sugar, 1/4 cup flour, 1 tsp cinnamon, 1/4 tsp nutmeg, and a pinch of salt. 4. Pour the apple mixture into the prepared pie crust. Dot with 2 tbsp of butter. 5. Cover with top crust, seal edges, and make a few slits for steam to escape. 6. Bake for 45-50 minutes or until the crust is golden and filling is bubbly. Let it cool before serving." },
                    { 2, "1 can (15 oz) pumpkin puree, 3/4 cup sugar, 1/2 tsp salt, 1 tsp cinnamon, 1/2 tsp ginger, 1/4 tsp cloves, 2 eggs, 1 can (12 oz) evaporated milk, pie crust", "Pumpkin Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 1 can (15 oz) of pumpkin puree, 3/4 cup sugar, 1/2 tsp salt, 1 tsp cinnamon, 1/2 tsp ginger, 1/4 tsp cloves, and 2 eggs. 3. Gradually stir in 1 can (12 oz) evaporated milk. 4. Pour the mixture into the pie crust. 5. Bake for 55-60 minutes or until a knife inserted near the center comes out clean. Cool on a wire rack for 2 hours." },
                    { 3, "4 cups pitted tart cherries, 1 cup sugar, 1/4 cup cornstarch, 1/4 tsp almond extract, pinch of salt, 2 tbsp butter, pie crust", "Cherry Pie", "1. Preheat oven to 400°F (200°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups pitted tart cherries, 1 cup sugar, 1/4 cup cornstarch, 1/4 tsp almond extract, and a pinch of salt. 3. Pour the cherry mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust and crimp the edges. 5. Bake for 45-50 minutes until the filling is bubbly and the crust is golden. Cool before serving." },
                    { 4, "3 eggs, 1 cup corn syrup, 1 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, 1 1/2 cups pecan halves, pie crust", "Pecan Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup corn syrup, 1 cup sugar, 2 tbsp melted butter, and 1 tsp vanilla extract. 3. Stir in 1 1/2 cups pecan halves. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing." },
                    { 5, "3 egg yolks, 1 can (14 oz) sweetened condensed milk, 1/2 cup fresh key lime juice, 1 tsp lime zest, graham cracker crust", "Key Lime Pie", "1. Preheat oven to 350°F (175°C). Prepare a 9-inch graham cracker crust. 2. In a bowl, mix 3 egg yolks and 1 can (14 oz) sweetened condensed milk until smooth. 3. Stir in 1/2 cup fresh key lime juice and 1 tsp lime zest. 4. Pour the filling into the crust. 5. Bake for 15-20 minutes or until the filling is set. Cool, then chill in the refrigerator for at least 2 hours before serving." },
                    { 6, "4 oz semisweet chocolate, 1 cup softened butter, 1 cup sugar, 3 eggs, pie crust", "Chocolate Silk Pie", "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. Melt 4 oz semisweet chocolate and let it cool slightly. 3. In a bowl, cream 1 cup softened butter with 1 cup sugar until light and fluffy. Mix in the cooled chocolate. 4. Add 3 eggs one at a time, beating on high speed for 5 minutes each time. 5. Pour the mixture into the cooled pie crust. 6. Refrigerate for at least 4 hours or until set. Top with whipped cream before serving." },
                    { 7, "6 cups sliced peaches, 3/4 cup sugar, 1/4 cup flour, 1/2 tsp cinnamon, pinch of nutmeg, 2 tbsp butter, pie crust", "Peach Pie", "1. Preheat oven to 425°F (220°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 6 cups sliced peaches, 3/4 cup sugar, 1/4 cup flour, 1/2 tsp cinnamon, and a pinch of nutmeg. 3. Pour the peach mixture into the pie crust. Dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 45-50 minutes until golden brown and bubbly. Cool slightly before serving." },
                    { 8, "1 cup sugar, 2 tbsp flour, 3 tbsp cornstarch, pinch of salt, 1 1/2 cups water, 2 tbsp butter, 1/4 cup lemon juice, 3 egg yolks, 3 egg whites, 6 tbsp sugar, pie crust", "Lemon Meringue Pie", "1. Preheat oven to 350°F (175°C). Prepare a pre-baked pie crust. 2. In a saucepan, mix 1 cup sugar, 2 tbsp flour, 3 tbsp cornstarch, and a pinch of salt. Gradually stir in 1 1/2 cups water, 2 tbsp butter, and 1/4 cup lemon juice. Cook over medium heat until thickened. 3. Whisk 3 egg yolks in a bowl, then slowly add a portion of the hot mixture, stirring constantly. Return to the pan and cook for 2 more minutes. 4. Pour filling into the pie crust. 5. Beat 3 egg whites with 6 tbsp sugar until stiff peaks form. Spread over the pie. 6. Bake for 10-12 minutes until meringue is golden. Cool before serving." },
                    { 9, "4 cups fresh blueberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, pinch of salt, 2 tbsp butter, pie crust", "Blueberry Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups fresh blueberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 10, "3/4 cup sugar, 1/3 cup flour, pinch of salt, 2 1/2 cups milk, 3 egg yolks, 2 tbsp butter, 1 tsp vanilla extract, 2-3 bananas, pie crust", "Banana Cream Pie", "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, combine 3/4 cup sugar, 1/3 cup flour, and a pinch of salt. Gradually whisk in 2 1/2 cups milk. 3. Cook over medium heat, stirring constantly until thickened. Remove from heat. 4. In a bowl, beat 3 egg yolks. Slowly whisk in a portion of the hot milk mixture, then return to the saucepan and cook for 2 more minutes. 5. Remove from heat and stir in 2 tbsp butter and 1 tsp vanilla extract. Let it cool slightly. 6. Slice 2-3 bananas and arrange them on the pie crust. Pour the custard over bananas. 7. Chill in the refrigerator for at least 2 hours before serving. Top with whipped cream." },
                    { 11, "4 oz unsweetened chocolate, 1 cup softened butter, 1 cup sugar, 4 eggs, pie crust, whipped cream, chocolate shavings", "French Silk Pie", "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. Melt 4 oz unsweetened chocolate and let it cool slightly. 3. In a bowl, cream 1 cup softened butter with 1 cup sugar until light and fluffy. Mix in the cooled chocolate. 4. Add 4 eggs one at a time, beating on high speed for 5 minutes each time. 5. Pour the mixture into the cooled pie crust. 6. Refrigerate for at least 4 hours or until set. Top with whipped cream and chocolate shavings before serving." },
                    { 12, "2 cups mashed sweet potatoes, 1 cup sugar, 1/2 cup milk, 2 eggs, 1/2 tsp ground cinnamon, 1/4 tsp ground nutmeg, 1/4 tsp ground ginger, 1/2 tsp vanilla extract, pie crust", "Sweet Potato Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 2 cups mashed sweet potatoes, 1 cup sugar, 1/2 cup milk, 2 eggs, 1/2 tsp ground cinnamon, 1/4 tsp ground nutmeg, 1/4 tsp ground ginger, and 1/2 tsp vanilla extract. 3. Pour the mixture into the pie crust. 4. Bake for 55-60 minutes or until a knife inserted near the center comes out clean. Let it cool before serving." },
                    { 13, "1/2 cup sugar, 1/4 cup cornstarch, pinch of salt, 2 cups milk, 3 egg yolks, 1 tbsp butter, 1 tsp vanilla extract, 1 cup shredded coconut, pie crust, whipped cream, toasted coconut", "Coconut Cream Pie", "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, combine 1/2 cup sugar, 1/4 cup cornstarch, and a pinch of salt. Gradually whisk in 2 cups milk. 3. Cook over medium heat, stirring constantly until thickened. 4. In a bowl, beat 3 egg yolks. Slowly whisk in a portion of the hot milk mixture, then return to the saucepan and cook for 2 more minutes. 5. Remove from heat and stir in 1 tbsp butter and 1 tsp vanilla extract. Fold in 1 cup shredded coconut. 6. Pour the mixture into the cooled pie crust. Chill for at least 4 hours before serving. Top with whipped cream and toasted coconut." },
                    { 14, "2 1/2 cups sliced strawberries, 2 1/2 cups chopped rhubarb, 1 cup sugar, 1/4 cup cornstarch, 1/4 tsp cinnamon, 2 tbsp butter, pie crust", "Strawberry Rhubarb Pie", "1. Preheat oven to 400°F (200°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 2 1/2 cups sliced strawberries, 2 1/2 cups chopped rhubarb, 1 cup sugar, 1/4 cup cornstarch, and 1/4 tsp cinnamon. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 45-50 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 15, "3 eggs, 1 cup pure maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 1/2 cups pecan halves, pie crust", "Maple Pecan Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup pure maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 1/2 cups pecan halves. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing." },
                    { 16, "1/2 cup butter, 1 cup brown sugar, 1/4 cup cornstarch, 2 cups milk, 3 egg yolks, 1 tsp vanilla extract, pie crust, whipped cream, butterscotch chips", "Butterscotch Pie", "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, melt 1/2 cup butter over medium heat. Stir in 1 cup brown sugar and cook for 2 minutes. 3. Gradually stir in 1/4 cup cornstarch and 2 cups milk, whisking constantly until thickened. 4. In a bowl, beat 3 egg yolks. Slowly whisk in a portion of the hot mixture, then return to the saucepan and cook for 2 more minutes. 5. Remove from heat and stir in 1 tsp vanilla extract. 6. Pour the mixture into the cooled pie crust. Chill for at least 4 hours before serving. Top with whipped cream and butterscotch chips." },
                    { 17, "4 cups blackberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, pinch of salt, 2 tbsp butter, pie crust", "Blackberry Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups blackberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 18, "3/4 cup sugar, 1/4 cup cornstarch, pinch of salt, 2 cups milk, 4 oz chopped chocolate, 1 tsp vanilla extract, pie crust, whipped cream, chocolate shavings", "Chocolate Cream Pie", "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, combine 3/4 cup sugar, 1/4 cup cornstarch, and a pinch of salt. Gradually whisk in 2 cups milk. 3. Cook over medium heat, stirring constantly until thickened. 4. Stir in 4 oz chopped chocolate and 1 tsp vanilla extract until smooth. 5. Pour the mixture into the cooled pie crust. Chill for at least 4 hours before serving. Top with whipped cream and chocolate shavings." },
                    { 19, "3 eggs, 3/4 cup sugar, 1/4 tsp salt, 1 tsp vanilla extract, 2 cups whole milk, pie crust", "Custard Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 3/4 cup sugar, 1/4 tsp salt, 1 tsp vanilla extract, and 2 cups whole milk. 3. Pour the mixture into the pie crust. 4. Bake for 45-50 minutes or until a knife inserted near the center comes out clean. Let it cool before serving." },
                    { 20, "4 cups raspberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, 2 tbsp butter, pie crust", "Raspberry Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups raspberries, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 21, "2 cups minced meat, 1/2 cup raisins, 1/4 cup currants, 1/4 cup chopped apples, 1/4 cup brown sugar, 1/4 cup brandy, 1 tsp cinnamon, 1/2 tsp allspice, 1/4 tsp nutmeg, pinch of salt, 2 tbsp butter, pie crust", "Mince Pie", "1. Preheat oven to 400°F (200°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 2 cups minced meat, 1/2 cup raisins, 1/4 cup currants, 1/4 cup chopped apples, 1/4 cup brown sugar, 1/4 cup brandy, 1 tsp cinnamon, 1/2 tsp allspice, 1/4 tsp nutmeg, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 30-35 minutes until golden brown and bubbly. Let it cool before serving." },
                    { 22, "3 cups chopped pineapple, 1 cup sugar, 1/4 cup cornstarch, 1 tsp lemon juice, 2 tbsp butter, pie crust", "Pineapple Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 3 cups chopped pineapple, 1 cup sugar, 1/4 cup cornstarch, and 1 tsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 45-50 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 23, "3 eggs, 1 cup corn syrup, 1/2 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 cup chopped pecans, 1/2 cup chocolate chips, pie crust", "Chocolate Pecan Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup corn syrup, 1/2 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 cup chopped pecans and 1/2 cup chocolate chips. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing." },
                    { 24, "4 cups sliced mangoes, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lime juice, 2 tbsp butter, pie crust", "Mango Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups sliced mangoes, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lime juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 25, "1 cup ground almonds, 1/2 cup sugar, 1/4 cup butter, 1 egg, 1/2 tsp almond extract, 3 pears, tart crust", "Pear and Almond Tart", "1. Preheat oven to 350°F (175°C). Prepare a tart pan with a bottom crust. 2. In a bowl, mix 1 cup ground almonds, 1/2 cup sugar, 1/4 cup butter, 1 egg, and 1/2 tsp almond extract. 3. Spread the almond mixture over the crust. 4. Arrange 3 sliced pears over the almond mixture. 5. Bake for 40-45 minutes or until the tart is golden and the pears are tender. Let it cool before serving." },
                    { 26, "1 1/2 cups sugar, 2 tbsp cornmeal, 1 tbsp flour, 1/4 tsp salt, 1/2 cup melted butter, 3/4 cup lemon juice, 4 eggs, pie crust", "Lemon Chess Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 1 1/2 cups sugar, 2 tbsp cornmeal, 1 tbsp flour, 1/4 tsp salt, 1/2 cup melted butter, 3/4 cup lemon juice, and 4 eggs. 3. Pour the mixture into the pie crust. 4. Bake for 40-45 minutes or until the filling is set and golden. Let it cool before serving." },
                    { 27, "2 cups milk, 3 eggs, 3/4 cup sugar, 1 tbsp cornstarch, 1 tbsp vanilla extract, pie crust", "Vanilla Custard Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a saucepan, heat 2 cups milk until just simmering. 3. In a bowl, whisk together 3 eggs, 3/4 cup sugar, 1 tbsp cornstarch, and 1 tbsp vanilla extract. 4. Slowly pour the hot milk into the egg mixture, whisking constantly. 5. Pour the mixture into the pie crust. 6. Bake for 40-45 minutes or until the filling is set. Let it cool before serving." },
                    { 28, "1 cup pumpkin puree, 1/2 cup sugar, 1/2 tsp cinnamon, 1/4 tsp nutmeg, 1/4 tsp ginger, 1 cup whipped cream, graham cracker crust", "Pumpkin Cream Pie", "1. Bake a graham cracker crust according to package instructions; let it cool. 2. In a bowl, whisk together 1 cup pumpkin puree, 1/2 cup sugar, 1/2 tsp cinnamon, 1/4 tsp nutmeg, 1/4 tsp ginger, and 1 cup whipped cream. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with additional whipped cream." },
                    { 29, "4 cups fresh cranberries, 1 1/2 cups sugar, 1/4 cup flour, 1/4 tsp salt, 1/2 tsp cinnamon, 2 tbsp butter, pie crust", "Cranberry Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups fresh cranberries, 1 1/2 cups sugar, 1/4 cup flour, 1/4 tsp salt, and 1/2 tsp cinnamon. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-55 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 30, "1 cup chocolate chips, 1/2 cup hazelnut spread, pie crust, whipped cream, chopped hazelnuts", "Hazelnut Chocolate Pie", "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. In a saucepan, melt 1 cup chocolate chips with 1/2 cup hazelnut spread over low heat, stirring until smooth. 3. Pour the mixture into the cooled pie crust. 4. Chill in the refrigerator for at least 4 hours or until set. Top with whipped cream and chopped hazelnuts before serving." },
                    { 31, "4 cups sliced apricots, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, 2 tbsp butter, pie crust", "Apricot Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups sliced apricots, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 32, "6 cups sliced apples, 1/2 cup caramel sauce, 1/4 cup sugar, 1/4 cup flour, 1/2 tsp cinnamon, 2 tbsp butter, pie crust", "Caramel Apple Pie", "1. Preheat oven to 425°F (220°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 6 cups sliced apples, 1/2 cup caramel sauce, 1/4 cup sugar, 1/4 cup flour, and 1/2 tsp cinnamon. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 45-50 minutes until golden brown and bubbly. Let it cool before serving." },
                    { 33, "1 cup creamy peanut butter, 8 oz cream cheese, 1 cup powdered sugar, 1 cup whipped cream, graham cracker crust, whipped cream, chocolate drizzle", "Peanut Butter Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 cup creamy peanut butter, 8 oz cream cheese, 1 cup powdered sugar, and 1 cup whipped cream until smooth. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with whipped cream and chocolate drizzle." },
                    { 34, "4 oz semisweet chocolate, 1 tbsp butter, 1/2 cup sugar, 3 tbsp cornstarch, pinch of salt, 2 cups milk, 3 egg yolks, 1 tsp vanilla extract, pie crust, whipped cream", "Black Bottom Pie", "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. In a saucepan, melt 4 oz semisweet chocolate with 1 tbsp butter over low heat, stirring until smooth. 3. Pour the chocolate mixture into the cooled pie crust and chill until set. 4. In a bowl, whisk together 1/2 cup sugar, 3 tbsp cornstarch, and a pinch of salt. Gradually whisk in 2 cups milk and 3 egg yolks. 5. Cook over medium heat, stirring constantly until thickened. 6. Remove from heat and stir in 1 tsp vanilla extract. 7. Pour the custard over the chocolate layer. Chill for at least 4 hours before serving. Top with whipped cream." },
                    { 35, "1 envelope unflavored gelatin, 1/4 cup cold water, 1/2 cup sugar, 3 egg yolks, 1/2 cup fruit juice (lemon, orange, or lime), 1 cup whipped cream, graham cracker crust", "Chiffon Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, dissolve 1 envelope unflavored gelatin in 1/4 cup cold water. 3. In a saucepan, whisk together 1/2 cup sugar, 3 egg yolks, and 1/2 cup fruit juice (lemon, orange, or lime). 4. Cook over low heat, stirring constantly until thickened. 5. Remove from heat and stir in the dissolved gelatin until fully incorporated. 6. Fold in 1 cup whipped cream. 7. Pour the mixture into the cooled crust. Chill for at least 4 hours before serving. Top with additional whipped cream." },
                    { 36, "1 cup raisins, 1/4 cup rum, 3 eggs, 1 cup sugar, 1/2 cup melted butter, 1/4 cup flour, 1 tsp vanilla extract, pie crust", "Rum Raisin Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 1 cup raisins with 1/4 cup rum and let it sit for 30 minutes. 3. In another bowl, whisk together 3 eggs, 1 cup sugar, 1/2 cup melted butter, 1/4 cup flour, and 1 tsp vanilla extract. 4. Stir in the rum-soaked raisins. 5. Pour the mixture into the pie crust. 6. Bake for 40-45 minutes or until the filling is set. Let it cool before serving." },
                    { 37, "4 cups pitted cherries, 3/4 cup sugar, 1/4 cup cornstarch, 1/2 tsp almond extract, pinch of salt, 2 tbsp butter, pie crust", "Cherry Almond Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups pitted cherries, 3/4 cup sugar, 1/4 cup cornstarch, 1/2 tsp almond extract, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 38, "3 eggs, 1 cup light corn syrup, 1 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 1/2 cups chopped macadamia nuts, pie crust", "Macadamia Nut Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup light corn syrup, 1 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 1/2 cups chopped macadamia nuts. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing." },
                    { 39, "3 eggs, 1 1/2 cups sugar, 1/4 cup melted butter, 3 tbsp flour, 1 cup buttermilk, 1 tsp vanilla extract, 1/4 tsp salt, pie crust", "Buttermilk Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 1/2 cups sugar, 1/4 cup melted butter, 3 tbsp flour, 1 cup buttermilk, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Pour the mixture into the pie crust. 4. Bake for 40-45 minutes or until the filling is set. Let it cool before serving." },
                    { 40, "4 cups blackberries, 3/4 cup sugar, 1 tbsp lemon juice, 3/4 cup sugar, 1/4 cup flour, 1/4 tsp salt, 2 eggs, pie crust", "Blackberry Custard Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups blackberries, 3/4 cup sugar, and 1 tbsp lemon juice. 3. In another bowl, whisk together 3/4 cup sugar, 1/4 cup flour, 1/4 tsp salt, and 2 eggs. 4. Pour the blackberry mixture into the pie crust. 5. Pour the custard mixture over the blackberries. 6. Bake for 50-55 minutes or until the filling is set. Let it cool before serving." },
                    { 41, "8 oz cream cheese, 1 cup powdered sugar, 1/2 cup creamy peanut butter, 1/4 cup milk, 1 cup whipped cream, 1/2 cup chocolate chips, graham cracker crust", "Chocolate Peanut Butter Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, beat 8 oz cream cheese, 1 cup powdered sugar, 1/2 cup creamy peanut butter, and 1/4 cup milk until smooth. 3. Fold in 1 cup whipped cream. 4. Pour the mixture into the cooled crust. 5. Melt 1/2 cup chocolate chips and drizzle over the pie. 6. Chill in the refrigerator for at least 4 hours before serving." },
                    { 42, "1 can (14 oz) sweetened condensed milk, 1/2 cup lemon juice, 1 tbsp lemon zest, 2 egg yolks, graham cracker crust, whipped cream", "Lemon Icebox Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, whisk together 1 can (14 oz) sweetened condensed milk, 1/2 cup lemon juice, 1 tbsp lemon zest, and 2 egg yolks. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with whipped cream." },
                    { 43, "1 1/2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, 1/2 cup milk, 1 tsp vanilla extract, pie crust", "Tropical Coconut Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 1 1/2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, 1/2 cup milk, and 1 tsp vanilla extract. 3. Pour the mixture into the pie crust. 4. Bake for 45-50 minutes or until the filling is set and golden. Let it cool before serving." },
                    { 44, "4 cups sliced apples, 2 cups fresh cranberries, 1 cup sugar, 1/4 cup flour, 1 tsp cinnamon, 1/4 tsp nutmeg, 2 tbsp butter, pie crust", "Apple Cranberry Pie", "1. Preheat oven to 425°F (220°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups sliced apples, 2 cups fresh cranberries, 1 cup sugar, 1/4 cup flour, 1 tsp cinnamon, and 1/4 tsp nutmeg. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 45-50 minutes until golden brown and bubbly. Let it cool before serving." },
                    { 45, "1 cup chocolate chips, 1/2 cup heavy cream, 2 cups mini marshmallows, graham cracker crust", "S'mores Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. Melt 1 cup chocolate chips with 1/2 cup heavy cream over low heat, stirring until smooth. 3. Pour the chocolate mixture into the cooled crust. 4. Top with 2 cups mini marshmallows. 5. Broil for 1-2 minutes until the marshmallows are toasted. Chill before serving." },
                    { 46, "1 1/2 cups shredded coconut, 1/2 cup sugar, 2 eggs, 1/4 cup melted butter, 1 tsp almond extract, 1/2 cup chocolate chips, 1/2 cup chopped almonds, graham cracker crust", "Almond Joy Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 1/2 cups shredded coconut, 1/2 cup sugar, 2 eggs, 1/4 cup melted butter, and 1 tsp almond extract. 3. Pour the mixture into the cooled crust. 4. Top with 1/2 cup chocolate chips and 1/2 cup chopped almonds. 5. Bake at 350°F (175°C) for 30-35 minutes until set. Let it cool before serving." },
                    { 47, "2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, 1 tsp vanilla extract, pie crust", "Coconut Macaroon Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, and 1 tsp vanilla extract. 3. Pour the mixture into the pie crust. 4. Bake for 40-45 minutes or until the filling is set and golden. Let it cool before serving." },
                    { 48, "1 can (14 oz) sweetened condensed milk, 1/2 cup key lime juice, 1/2 cup shredded coconut, 2 egg yolks, graham cracker crust, whipped cream, toasted coconut", "Key Lime Coconut Pie", "1. Preheat oven to 350°F (175°C). Prepare a graham cracker crust. 2. In a bowl, mix 1 can (14 oz) sweetened condensed milk, 1/2 cup key lime juice, 1/2 cup shredded coconut, and 2 egg yolks. 3. Pour the mixture into the crust. 4. Bake for 15-20 minutes until the filling is set. Let it cool, then chill in the refrigerator for at least 2 hours before serving. Top with whipped cream and toasted coconut." },
                    { 49, "1 pie crust, 1/4 cup softened butter, 1/2 cup brown sugar, 2 tsp cinnamon, 1/4 cup chopped pecans", "Cinnamon Roll Pie", "1. Preheat oven to 375°F (190°C). Roll out pie crust into a 9-inch pie dish. 2. In a bowl, mix 1/4 cup softened butter, 1/2 cup brown sugar, 2 tsp cinnamon, and 1/4 cup chopped pecans. 3. Spread the mixture over the pie crust. 4. Roll up the crust and cut into 1-inch slices. Arrange the slices in the pie dish. 5. Bake for 25-30 minutes until golden brown. Let it cool slightly before serving." },
                    { 50, "2 cups blueberries, 1/2 cup sugar, 1 tbsp lemon juice, 1 cup whipped cream, 1/2 cup cream cheese, graham cracker crust", "Blueberry Cream Pie", "1. Bake a graham cracker crust according to package instructions; let it cool. 2. In a saucepan, cook 2 cups blueberries with 1/2 cup sugar and 1 tbsp lemon juice over medium heat until thickened. 3. Pour the mixture into the crust. 4. In a bowl, mix 1 cup whipped cream with 1/2 cup cream cheese. Spread over the blueberry mixture. 5. Chill in the refrigerator for at least 4 hours before serving." },
                    { 51, "2 cups sliced strawberries, 1/2 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, pretzel crust", "Strawberry Pretzel Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a pretzel crust. 2. In a bowl, mix 2 cups sliced strawberries, 1/2 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust. 4. Bake for 30-35 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 52, "3 eggs, 1 cup maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 1/2 cups chopped walnuts, pie crust", "Maple Walnut Pie", "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 1/2 cups chopped walnuts. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing." },
                    { 53, "1/2 cup sliced bananas, 1/2 cup chopped strawberries, 1/2 cup crushed pineapple, 1 cup whipped cream, graham cracker crust, chocolate sauce, chopped nuts", "Banana Split Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1/2 cup sliced bananas, 1/2 cup chopped strawberries, 1/2 cup crushed pineapple, and 1 cup whipped cream. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with chocolate sauce and chopped nuts." },
                    { 54, "1/4 cup butter, 1/2 cup brown sugar, 1/4 cup cornstarch, 2 cups milk, 1 tsp vanilla extract, graham cracker crust, whipped cream", "Butterscotch Pudding Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a saucepan, melt 1/4 cup butter over medium heat. Stir in 1/2 cup brown sugar and cook for 2 minutes. 3. Gradually stir in 1/4 cup cornstarch and 2 cups milk, whisking constantly until thickened. 4. Remove from heat and stir in 1 tsp vanilla extract. 5. Pour the mixture into the cooled crust. Chill for at least 4 hours before serving. Top with whipped cream." },
                    { 55, "1 cup whipped cream, 1/2 cup coffee-flavored liqueur, 1/2 cup chocolate pudding mix, chocolate cookie crust, chocolate shavings", "Mocha Cream Pie", "1. Prepare a chocolate cookie crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 cup whipped cream, 1/2 cup coffee-flavored liqueur, and 1/2 cup chocolate pudding mix. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with chocolate shavings." },
                    { 56, "3 cups sliced peaches, 1 cup raspberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, 2 tbsp butter, pie crust", "Peach Melba Pie", "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 3 cups sliced peaches, 1 cup raspberries, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving." },
                    { 57, "2 cups fresh raspberries, 1/2 cup sugar, 1 tbsp cornstarch, 1 tbsp lemon juice, 1 cup whipped cream, 1/2 cup cream cheese, graham cracker crust", "Raspberry Cream Pie", "1. Bake a graham cracker crust according to package instructions; let it cool. 2. In a bowl, mix 2 cups fresh raspberries, 1/2 cup sugar, 1 tbsp cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust. 4. In another bowl, mix 1 cup whipped cream with 1/2 cup cream cheese. Spread over the raspberry mixture. 5. Chill in the refrigerator for at least 4 hours before serving." },
                    { 58, "1 cup caramel sauce, 1 cup chopped pecans, 1 cup whipped cream, chocolate cookie crust, chocolate ganache", "Turtle Pie", "1. Prepare a chocolate cookie crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 cup caramel sauce, 1 cup chopped pecans, and 1 cup whipped cream. 3. Pour the mixture into the cooled crust. 4. Top with chocolate ganache and chill in the refrigerator for at least 4 hours before serving." },
                    { 59, "6 oz white chocolate, 1 cup whipped cream, 1/2 cup fresh raspberries, graham cracker crust", "White Chocolate Raspberry Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. Melt 6 oz white chocolate and let it cool slightly. 3. In a bowl, mix 1 cup whipped cream with the cooled white chocolate. 4. Pour the mixture into the crust. 5. Top with 1/2 cup fresh raspberries. Chill in the refrigerator for at least 4 hours before serving." },
                    { 60, "1 can (14 oz) sweetened condensed milk, 1/2 cup orange juice concentrate, 2 egg yolks, graham cracker crust, whipped cream", "Orange Cream Pie", "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, whisk together 1 can (14 oz) sweetened condensed milk, 1/2 cup orange juice concentrate, and 2 egg yolks. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with whipped cream." }
                });

            migrationBuilder.InsertData(
                table: "Pies",
                columns: new[] { "Id", "AltText", "ImageUrl", "IsPieOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/caramelpopcorncheesecake.jpg", false, "Experience the perfect balance of rich cheesecake and the nostalgic crunch of caramel popcorn. This unique combination will have your taste buds dancing with joy.", "Caramel Popcorn Cheese Cake", 22.95m, "A delightful fusion of caramel popcorn and cheesecake." },
                    { 2, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/chocolatecheesecake.jpg", true, "Indulge in the creamy, rich taste of our Chocolate Cheese Cake, where smooth cheesecake meets luscious layers of chocolate. Perfect for chocolate lovers!", "Chocolate Cheese Cake", 18.95m, "A heavenly blend of chocolate and cheesecake." },
                    { 3, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/pistachecheesecake.jpg", false, "Our Pistache Cheese Cake is a delicate blend of creamy cheesecake with a hint of pistachio flavor, offering a smooth and nutty experience in every bite.", "Pistache Cheese Cake", 17.95m, "A nutty delight with a cheesecake twist." },
                    { 4, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/pecanpie.jpg", false, "Savor the traditional taste of Pecan Pie with its rich, buttery filling topped with crunchy pecans. It's the perfect dessert for any occasion.", "Pecan Pie", 14.95m, "A classic American favorite, rich with pecans." },
                    { 5, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/birthdaypie.jpg", false, "Make any birthday special with our Birthday Pie, featuring colorful sprinkles, a sweet crust, and a deliciously creamy filling that's perfect for any celebration.", "Birthday Pie", 15.95m, "Celebrate with our festive Birthday Pie!" },
                    { 6, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/applepie.jpg", true, "Enjoy a slice of comfort with our Apple Pie, filled with fresh, juicy apples and a hint of cinnamon, all wrapped in a golden, flaky crust.", "Apple Pie", 12.95m, "Our famous apple pies!" },
                    { 7, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/cheesecake.jpg", false, "Delight in the rich and creamy texture of our traditional Cheese Cake, a timeless dessert that's perfect for any sweet tooth craving.", "Cheese Cake", 13.95m, "Classic and creamy cheesecake." },
                    { 8, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/cherrypie.jpg", false, "Our Cherry Pie is packed with juicy cherries in a flaky crust, delivering a perfect balance of tartness and sweetness in every bite.", "Cherry Pie", 14.95m, "A tart and sweet cherry delight." },
                    { 9, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/christmasapplepie.jpg", false, "Enjoy the warmth of the holidays with our Christmas Apple Pie, featuring spiced apples, a hint of nutmeg, and a buttery crust, perfect for winter celebrations.", "Christmas Apple Pie", 16.95m, "A festive twist on the classic apple pie." },
                    { 10, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/cranberrypie.jpg", false, "Our Cranberry Pie offers a refreshing burst of tart cranberries balanced with a sweet filling, making it a unique and flavorful dessert.", "Cranberry Pie", 13.95m, "A tart treat with a cranberry kick." },
                    { 11, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/peachpie.jpg", false, "Savor the taste of summer with our Peach Pie, made with fresh, ripe peaches and a golden, buttery crust that melts in your mouth.", "Peach Pie", 14.95m, "A sweet slice of summer." },
                    { 12, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/pumpkinpie.jpg", false, "Enjoy the flavors of fall with our Pumpkin Pie, featuring a spiced pumpkin filling in a flaky crust. It's a must-have for any autumn gathering.", "Pumpkin Pie", 12.95m, "A seasonal favorite, perfect for autumn." },
                    { 13, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/rhubarbpie.jpg", false, "Our Rhubarb Pie combines a tangy filling with a sweet, buttery crust, creating a delightful contrast of flavors that's sure to please.", "Rhubarb Pie", 14.95m, "A tangy twist on a traditional pie." },
                    { 14, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/strawberrypie.jpg", false, "Taste the freshness of summer with our Strawberry Pie, featuring a luscious filling made from ripe strawberries, all encased in a flaky crust.", "Strawberry Pie", 14.95m, "A burst of fresh strawberry flavor." },
                    { 15, "", "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/strawberrycheesecake.jpg", false, "Indulge in the creamy goodness of our Strawberry Cheese Cake, combining the rich flavors of cheesecake with the fresh, sweet taste of strawberries.", "Strawberry Cheese Cake", 15.95m, "A delicious blend of strawberries and cheesecake." }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "Amount", "OrderId", "PieId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 1, 5 },
                    { 3, 1, 1, 8 },
                    { 4, 3, 2, 3 },
                    { 5, 1, 2, 7 },
                    { 6, 2, 2, 12 },
                    { 7, 1, 2, 14 },
                    { 8, 2, 3, 1 },
                    { 9, 1, 3, 4 },
                    { 10, 1, 3, 11 },
                    { 11, 2, 3, 15 },
                    { 12, 1, 4, 6 },
                    { 13, 2, 4, 9 },
                    { 14, 1, 5, 10 },
                    { 15, 3, 5, 13 },
                    { 16, 2, 5, 2 },
                    { 17, 2, 6, 3 },
                    { 18, 1, 6, 1 },
                    { 19, 2, 7, 5 },
                    { 20, 1, 7, 6 },
                    { 21, 1, 7, 8 },
                    { 22, 1, 7, 12 },
                    { 23, 4, 8, 7 },
                    { 24, 1, 8, 14 },
                    { 25, 1, 9, 11 },
                    { 26, 3, 9, 10 },
                    { 27, 2, 9, 4 },
                    { 28, 1, 10, 9 },
                    { 29, 2, 10, 13 },
                    { 30, 1, 10, 2 },
                    { 31, 1, 10, 15 },
                    { 32, 1, 10, 3 },
                    { 33, 2, 11, 5 },
                    { 34, 1, 11, 7 },
                    { 35, 1, 12, 1 },
                    { 36, 2, 12, 3 },
                    { 37, 1, 12, 6 },
                    { 38, 1, 13, 8 },
                    { 39, 3, 13, 12 },
                    { 40, 2, 14, 2 },
                    { 41, 1, 14, 11 },
                    { 42, 2, 14, 14 },
                    { 43, 1, 14, 9 },
                    { 44, 1, 15, 10 },
                    { 45, 2, 15, 5 },
                    { 46, 1, 15, 15 },
                    { 47, 3, 15, 13 },
                    { 48, 2, 16, 4 },
                    { 49, 1, 17, 9 },
                    { 50, 3, 17, 7 },
                    { 51, 1, 18, 6 },
                    { 52, 2, 18, 8 },
                    { 53, 1, 18, 12 },
                    { 54, 2, 19, 14 },
                    { 55, 1, 19, 3 },
                    { 56, 1, 19, 1 },
                    { 57, 2, 19, 13 },
                    { 58, 3, 20, 11 },
                    { 59, 1, 21, 13 },
                    { 60, 2, 21, 2 },
                    { 61, 1, 22, 5 },
                    { 62, 1, 22, 6 },
                    { 63, 3, 22, 8 },
                    { 64, 2, 23, 10 },
                    { 65, 1, 23, 15 },
                    { 66, 3, 24, 3 },
                    { 67, 1, 24, 9 },
                    { 68, 1, 24, 12 },
                    { 69, 2, 25, 14 },
                    { 70, 1, 25, 11 },
                    { 71, 2, 25, 8 },
                    { 72, 1, 26, 2 },
                    { 73, 3, 26, 4 },
                    { 74, 1, 26, 13 },
                    { 75, 2, 27, 7 },
                    { 76, 1, 27, 14 },
                    { 77, 2, 27, 9 },
                    { 78, 1, 27, 5 },
                    { 79, 2, 28, 8 },
                    { 80, 1, 28, 15 },
                    { 81, 1, 29, 10 },
                    { 82, 2, 29, 13 },
                    { 83, 3, 29, 1 },
                    { 84, 1, 30, 6 },
                    { 85, 2, 30, 4 },
                    { 86, 2, 30, 12 },
                    { 87, 1, 30, 3 },
                    { 88, 1, 31, 11 },
                    { 89, 2, 31, 9 },
                    { 90, 3, 31, 7 },
                    { 91, 1, 32, 2 },
                    { 92, 2, 32, 5 },
                    { 93, 3, 33, 10 },
                    { 94, 1, 33, 15 },
                    { 95, 2, 33, 8 },
                    { 96, 1, 34, 3 },
                    { 97, 2, 34, 14 },
                    { 98, 2, 35, 5 },
                    { 99, 1, 35, 7 },
                    { 100, 3, 35, 6 },
                    { 101, 1, 35, 13 },
                    { 102, 1, 36, 2 },
                    { 103, 2, 36, 4 },
                    { 104, 3, 37, 11 },
                    { 105, 1, 37, 3 },
                    { 106, 2, 38, 9 },
                    { 107, 1, 38, 10 },
                    { 108, 1, 38, 8 },
                    { 109, 2, 39, 12 },
                    { 110, 1, 39, 5 },
                    { 111, 1, 40, 1 },
                    { 112, 2, 40, 2 },
                    { 113, 1, 40, 15 },
                    { 114, 3, 40, 13 },
                    { 115, 1, 41, 14 },
                    { 116, 2, 41, 7 },
                    { 117, 3, 42, 6 },
                    { 118, 1, 42, 12 },
                    { 119, 2, 42, 8 },
                    { 120, 1, 43, 9 },
                    { 121, 2, 43, 14 },
                    { 122, 1, 43, 3 },
                    { 123, 1, 44, 4 },
                    { 124, 1, 44, 11 },
                    { 125, 2, 44, 5 },
                    { 126, 3, 44, 13 },
                    { 127, 1, 45, 2 },
                    { 128, 2, 45, 1 },
                    { 129, 3, 46, 7 },
                    { 130, 1, 46, 6 },
                    { 131, 2, 46, 10 },
                    { 132, 1, 47, 15 },
                    { 133, 2, 47, 9 },
                    { 134, 1, 47, 3 },
                    { 135, 1, 48, 13 },
                    { 136, 1, 48, 8 },
                    { 137, 3, 48, 12 },
                    { 138, 2, 49, 5 },
                    { 139, 1, 49, 4 },
                    { 140, 1, 49, 2 },
                    { 141, 2, 49, 7 },
                    { 142, 3, 50, 9 },
                    { 143, 1, 51, 14 },
                    { 144, 2, 51, 6 },
                    { 145, 1, 51, 12 },
                    { 146, 2, 52, 1 },
                    { 147, 1, 52, 4 },
                    { 148, 1, 53, 5 },
                    { 149, 2, 53, 7 },
                    { 150, 1, 53, 10 },
                    { 151, 2, 53, 14 },
                    { 152, 1, 54, 8 },
                    { 153, 1, 54, 3 },
                    { 154, 3, 55, 11 },
                    { 155, 2, 55, 15 },
                    { 156, 1, 56, 13 },
                    { 157, 1, 56, 9 },
                    { 158, 3, 56, 4 },
                    { 159, 1, 57, 6 },
                    { 160, 2, 57, 2 },
                    { 161, 1, 57, 14 },
                    { 162, 3, 58, 7 },
                    { 163, 1, 58, 5 },
                    { 164, 2, 59, 8 },
                    { 165, 1, 59, 12 },
                    { 166, 1, 59, 3 },
                    { 167, 1, 60, 4 },
                    { 168, 3, 60, 10 },
                    { 169, 2, 60, 6 },
                    { 170, 1, 60, 15 },
                    { 171, 1, 61, 13 },
                    { 172, 2, 61, 11 },
                    { 173, 2, 62, 5 },
                    { 174, 1, 62, 2 },
                    { 175, 1, 62, 3 },
                    { 176, 1, 63, 9 },
                    { 177, 3, 63, 7 },
                    { 178, 2, 64, 1 },
                    { 179, 1, 64, 4 },
                    { 180, 1, 65, 12 },
                    { 181, 2, 65, 15 },
                    { 182, 1, 65, 10 },
                    { 183, 3, 66, 13 },
                    { 184, 1, 66, 11 },
                    { 185, 1, 66, 8 },
                    { 186, 2, 67, 6 },
                    { 187, 1, 67, 14 },
                    { 188, 1, 68, 2 },
                    { 189, 3, 68, 5 },
                    { 190, 2, 68, 3 },
                    { 191, 2, 69, 9 },
                    { 192, 1, 69, 7 },
                    { 193, 1, 69, 12 },
                    { 194, 3, 70, 10 },
                    { 195, 1, 70, 15 },
                    { 196, 2, 70, 14 },
                    { 197, 1, 70, 6 },
                    { 198, 2, 71, 8 },
                    { 199, 1, 71, 4 },
                    { 200, 1, 72, 11 },
                    { 201, 3, 72, 3 },
                    { 202, 1, 72, 1 },
                    { 203, 2, 73, 5 },
                    { 204, 1, 73, 13 },
                    { 205, 1, 73, 9 },
                    { 206, 1, 73, 2 },
                    { 207, 1, 74, 4 },
                    { 208, 2, 74, 7 },
                    { 209, 2, 75, 12 },
                    { 210, 1, 75, 14 },
                    { 211, 3, 75, 6 },
                    { 212, 1, 76, 10 },
                    { 213, 2, 76, 13 },
                    { 214, 1, 77, 15 },
                    { 215, 2, 77, 9 },
                    { 216, 1, 77, 3 },
                    { 217, 3, 78, 8 },
                    { 218, 1, 79, 1 },
                    { 219, 2, 79, 6 },
                    { 220, 1, 79, 12 },
                    { 221, 2, 79, 5 },
                    { 222, 2, 80, 9 },
                    { 223, 1, 80, 14 },
                    { 224, 1, 81, 11 },
                    { 225, 2, 81, 13 },
                    { 226, 1, 81, 7 },
                    { 227, 3, 81, 10 },
                    { 228, 1, 82, 2 },
                    { 229, 2, 82, 5 },
                    { 230, 1, 83, 8 },
                    { 231, 3, 83, 12 },
                    { 232, 2, 83, 3 },
                    { 233, 1, 84, 14 },
                    { 234, 1, 84, 6 },
                    { 235, 2, 84, 1 },
                    { 236, 2, 85, 5 },
                    { 237, 1, 85, 13 },
                    { 238, 3, 85, 4 },
                    { 239, 1, 86, 3 },
                    { 240, 1, 86, 15 },
                    { 241, 1, 86, 9 },
                    { 242, 2, 86, 10 },
                    { 243, 1, 87, 8 },
                    { 244, 2, 87, 12 },
                    { 245, 1, 87, 7 },
                    { 246, 2, 88, 6 },
                    { 247, 1, 88, 11 },
                    { 248, 1, 89, 14 },
                    { 249, 2, 89, 5 },
                    { 250, 3, 89, 1 },
                    { 251, 1, 90, 3 },
                    { 252, 2, 90, 15 },
                    { 253, 1, 91, 9 },
                    { 254, 2, 91, 12 },
                    { 255, 3, 91, 4 },
                    { 256, 1, 92, 8 },
                    { 257, 1, 92, 5 },
                    { 258, 2, 93, 2 },
                    { 259, 1, 93, 7 },
                    { 260, 1, 93, 11 },
                    { 261, 3, 94, 13 },
                    { 262, 1, 94, 15 },
                    { 263, 1, 94, 9 },
                    { 264, 1, 95, 4 },
                    { 265, 2, 95, 10 },
                    { 266, 2, 96, 6 },
                    { 267, 1, 96, 1 },
                    { 268, 1, 96, 3 },
                    { 269, 2, 96, 5 },
                    { 270, 1, 97, 14 },
                    { 271, 1, 97, 9 },
                    { 272, 3, 97, 7 },
                    { 273, 1, 98, 2 },
                    { 274, 1, 98, 12 },
                    { 275, 2, 98, 11 },
                    { 276, 3, 99, 5 },
                    { 277, 1, 99, 8 },
                    { 278, 1, 100, 3 },
                    { 279, 2, 100, 10 },
                    { 280, 1, 100, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PieId",
                table: "OrderDetails",
                column: "PieId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessages_TicketId",
                table: "TicketMessages",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PieRecipes");

            migrationBuilder.DropTable(
                name: "TicketMessages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pies");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
