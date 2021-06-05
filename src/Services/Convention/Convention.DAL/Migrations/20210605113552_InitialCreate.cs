using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Convention.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Conventions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conventions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConventionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalSchema: "dbo",
                        principalTable: "Conventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConventionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpeakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AmountOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talks_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalSchema: "dbo",
                        principalTable: "Conventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Talks_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalSchema: "dbo",
                        principalTable: "Speaker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TalkParticipant",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TalkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalkParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalkParticipant_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "dbo",
                        principalTable: "Participant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TalkParticipant_Talks_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "dbo",
                        principalTable: "Talks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ConventionId",
                schema: "dbo",
                table: "Participant",
                column: "ConventionId");

            migrationBuilder.CreateIndex(
                name: "IX_TalkParticipant_ParticipantId",
                schema: "dbo",
                table: "TalkParticipant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_ConventionId",
                schema: "dbo",
                table: "Talks",
                column: "ConventionId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_SpeakerId",
                schema: "dbo",
                table: "Talks",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalkParticipant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Participant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Talks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Conventions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Speaker",
                schema: "dbo");
        }
    }
}
