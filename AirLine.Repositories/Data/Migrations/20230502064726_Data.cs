using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirLine.Repositories.Data.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirCrafts",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfSeatClassA = table.Column<int>(type: "int", nullable: false),
                    NoOfSeatClassB = table.Column<int>(type: "int", nullable: false),
                    NoOfSeatClassC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCrafts", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    AirLineCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirLineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirLineImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirLinePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirLineContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.AirLineCode);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustPassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CustEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustCode);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceCategories",
                columns: table => new
                {
                    CategoryNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCategories", x => x.CategoryNumber);
                });

            migrationBuilder.CreateTable(
                name: "PortsFrom",
                columns: table => new
                {
                    PortIDNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortIDCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortsFrom", x => x.PortIDNumber);
                    table.ForeignKey(
                        name: "FK_PortsFrom_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortsTo",
                columns: table => new
                {
                    PortIDNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortIDCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortsTo", x => x.PortIDNumber);
                    table.ForeignKey(
                        name: "FK_PortsTo_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    emp_DeptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_emp_DeptID",
                        column: x => x.emp_DeptID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromPort = table.Column<int>(type: "int", nullable: false),
                    ToPort = table.Column<int>(type: "int", nullable: false),
                    AirLineCode = table.Column<int>(type: "int", nullable: false),
                    AirCraftCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_Flights_AirCrafts_AirCraftCode",
                        column: x => x.AirCraftCode,
                        principalTable: "AirCrafts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_AirLines_AirLineCode",
                        column: x => x.AirLineCode,
                        principalTable: "AirLines",
                        principalColumn: "AirLineCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_PortsFrom_FromPort",
                        column: x => x.FromPort,
                        principalTable: "PortsFrom",
                        principalColumn: "PortIDNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_PortsTo_ToPort",
                        column: x => x.ToPort,
                        principalTable: "PortsTo",
                        principalColumn: "PortIDNumber",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FlightID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightSchedules",
                columns: table => new
                {
                    FlightAutoNumberKEY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvalibleSiteClassA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvalibleSiteClassB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvalibleSiteClassC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedules", x => x.FlightAutoNumberKEY);
                    table.ForeignKey(
                        name: "FK_FlightSchedules_Flights_FlightNumber",
                        column: x => x.FlightNumber,
                        principalTable: "Flights",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerID",
                table: "Bookings",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightID",
                table: "Bookings",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_emp_DeptID",
                table: "Employees",
                column: "emp_DeptID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirCraftCode",
                table: "Flights",
                column: "AirCraftCode");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirLineCode",
                table: "Flights",
                column: "AirLineCode");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FromPort",
                table: "Flights",
                column: "FromPort");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ToPort",
                table: "Flights",
                column: "ToPort");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_FlightNumber",
                table: "FlightSchedules",
                column: "FlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PortsFrom_CountryCode",
                table: "PortsFrom",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_PortsTo_CountryCode",
                table: "PortsTo",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FlightSchedules");

            migrationBuilder.DropTable(
                name: "PriceCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "AirCrafts");

            migrationBuilder.DropTable(
                name: "AirLines");

            migrationBuilder.DropTable(
                name: "PortsFrom");

            migrationBuilder.DropTable(
                name: "PortsTo");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
