using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pegov.Nasvyazi.Persistence.Postgres.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Email_Address = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<string>(nullable: true),
                    AccountStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountStatus_AccountStatusId",
                        column: x => x.AccountStatusId,
                        principalTable: "AccountStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Inn = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Kpp = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    EntityStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_EntityStatus_EntityStatusId",
                        column: x => x.EntityStatusId,
                        principalTable: "EntityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EntityStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_EntityStatus_EntityStatusId",
                        column: x => x.EntityStatusId,
                        principalTable: "EntityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    GroupTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_GroupType_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountOrganization",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOrganization", x => new { x.AccountId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_AccountOrganization_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOrganization_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountPosition",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    PositionId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPosition", x => new { x.AccountId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_AccountPosition_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPosition_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPosition_Positions_PositionId1",
                        column: x => x.PositionId1,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    ChatStatusId = table.Column<int>(nullable: false),
                    ChatTypeId = table.Column<int>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_ChatType_ChatTypeId",
                        column: x => x.ChatTypeId,
                        principalTable: "ChatType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_ChatStatus_ChatStatusId",
                        column: x => x.ChatStatusId,
                        principalTable: "ChatStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountChat",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    ChatId = table.Column<Guid>(nullable: false),
                    AccountId1 = table.Column<Guid>(nullable: true),
                    ChatId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChat", x => new { x.AccountId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_AccountChat_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountChat_Accounts_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountChat_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountChat_Chats_ChatId1",
                        column: x => x.ChatId1,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountChat_AccountId1",
                table: "AccountChat",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChat_ChatId",
                table: "AccountChat",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChat_ChatId1",
                table: "AccountChat",
                column: "ChatId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOrganization_OrganizationId",
                table: "AccountOrganization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPosition_PositionId",
                table: "AccountPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPosition_PositionId1",
                table: "AccountPosition",
                column: "PositionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountStatusId",
                table: "Accounts",
                column: "AccountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatTypeId",
                table: "Chats",
                column: "ChatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_GroupId",
                table: "Chats",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Name",
                table: "Chats",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatStatusId",
                table: "Chats",
                column: "ChatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AccountId",
                table: "Groups",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupTypeId",
                table: "Groups",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_EntityStatusId",
                table: "Organizations",
                column: "EntityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_EntityStatusId",
                table: "Positions",
                column: "EntityStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountChat");

            migrationBuilder.DropTable(
                name: "AccountOrganization");

            migrationBuilder.DropTable(
                name: "AccountPosition");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ChatType");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ChatStatus");

            migrationBuilder.DropTable(
                name: "EntityStatus");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "GroupType");

            migrationBuilder.DropTable(
                name: "AccountStatus");
        }
    }
}
