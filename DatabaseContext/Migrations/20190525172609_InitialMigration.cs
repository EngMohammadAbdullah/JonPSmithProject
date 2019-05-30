using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNo = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Specialist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DepartAddress = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 320, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressKey",
                        column: x => x.AddressKey,
                        principalTable: "Addresses",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factor",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factor", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Factor_Addresses_AddressKey",
                        column: x => x.AddressKey,
                        principalTable: "Addresses",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    DepartmentKey = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentKey",
                        column: x => x.DepartmentKey,
                        principalTable: "Departments",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    ClientKey = table.Column<Guid>(nullable: false),
                    EmployeeKey = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeliveryType = table.Column<int>(nullable: false),
                    AddressKey = table.Column<Guid>(nullable: true),
                    SoftDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressKey",
                        column: x => x.AddressKey,
                        principalTable: "Addresses",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientKey",
                        column: x => x.ClientKey,
                        principalTable: "Clients",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employees",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    width = table.Column<double>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    OrderKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderKey",
                        column: x => x.OrderKey,
                        principalTable: "Orders",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemToBeFactored",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    ItemKey = table.Column<Guid>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    FactorKey = table.Column<Guid>(nullable: false),
                    OrderKey = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemToBeFactored", x => x.Key);
                    table.ForeignKey(
                        name: "FK_ItemToBeFactored_Factor_FactorKey",
                        column: x => x.FactorKey,
                        principalTable: "Factor",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemToBeFactored_Orders_OrderKey",
                        column: x => x.OrderKey,
                        principalTable: "Orders",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JourneyOrder",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    OrderKey = table.Column<Guid>(nullable: false),
                    JourneyKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyOrder", x => x.Key);
                    table.ForeignKey(
                        name: "FK_JourneyOrder_Journey_JourneyKey",
                        column: x => x.JourneyKey,
                        principalTable: "Journey",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JourneyOrder_Orders_OrderKey",
                        column: x => x.OrderKey,
                        principalTable: "Orders",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressKey",
                table: "Employees",
                column: "AddressKey");

            migrationBuilder.CreateIndex(
                name: "IX_Factor_AddressKey",
                table: "Factor",
                column: "AddressKey");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderKey",
                table: "Items",
                column: "OrderKey");

            migrationBuilder.CreateIndex(
                name: "IX_ItemToBeFactored_FactorKey",
                table: "ItemToBeFactored",
                column: "FactorKey");

            migrationBuilder.CreateIndex(
                name: "IX_ItemToBeFactored_OrderKey",
                table: "ItemToBeFactored",
                column: "OrderKey");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyOrder_JourneyKey",
                table: "JourneyOrder",
                column: "JourneyKey");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyOrder_OrderKey",
                table: "JourneyOrder",
                column: "OrderKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressKey",
                table: "Orders",
                column: "AddressKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientKey",
                table: "Orders",
                column: "ClientKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeKey",
                table: "Orders",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentKey",
                table: "Students",
                column: "DepartmentKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemToBeFactored");

            migrationBuilder.DropTable(
                name: "JourneyOrder");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Factor");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
