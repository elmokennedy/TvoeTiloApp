using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvoeTiloApp.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedBasicStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.CreateTable(
                name: "TrainingType",
                columns: table => new
                {
                    TrainingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingType", x => x.TrainingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTraining",
                columns: table => new
                {
                    ScheduledTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTraining", x => x.ScheduledTrainingId);
                    table.ForeignKey(
                        name: "FK_ScheduledTraining_TrainingType_TrainingTypeId",
                        column: x => x.TrainingTypeId,
                        principalTable: "TrainingType",
                        principalColumn: "TrainingTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProfile",
                columns: table => new
                {
                    ClientProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfile", x => x.ClientProfileId);
                    table.ForeignKey(
                        name: "FK_ClientProfile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachProfile",
                columns: table => new
                {
                    CoachProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachProfile", x => x.CoachProfileId);
                    table.ForeignKey(
                        name: "FK_CoachProfile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProfileScheduledTraining",
                columns: table => new
                {
                    ClientProfilesClientProfileId = table.Column<int>(type: "int", nullable: false),
                    ScheduledTrainingsScheduledTrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfileScheduledTraining", x => new { x.ClientProfilesClientProfileId, x.ScheduledTrainingsScheduledTrainingId });
                    table.ForeignKey(
                        name: "FK_ClientProfileScheduledTraining_ClientProfile_ClientProfilesClientProfileId",
                        column: x => x.ClientProfilesClientProfileId,
                        principalTable: "ClientProfile",
                        principalColumn: "ClientProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientProfileScheduledTraining_ScheduledTraining_ScheduledTrainingsScheduledTrainingId",
                        column: x => x.ScheduledTrainingsScheduledTrainingId,
                        principalTable: "ScheduledTraining",
                        principalColumn: "ScheduledTrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachProfileTrainingType",
                columns: table => new
                {
                    CoachProfilesCoachProfileId = table.Column<int>(type: "int", nullable: false),
                    TrainingTypesTrainingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachProfileTrainingType", x => new { x.CoachProfilesCoachProfileId, x.TrainingTypesTrainingTypeId });
                    table.ForeignKey(
                        name: "FK_CoachProfileTrainingType_CoachProfile_CoachProfilesCoachProfileId",
                        column: x => x.CoachProfilesCoachProfileId,
                        principalTable: "CoachProfile",
                        principalColumn: "CoachProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachProfileTrainingType_TrainingType_TrainingTypesTrainingTypeId",
                        column: x => x.TrainingTypesTrainingTypeId,
                        principalTable: "TrainingType",
                        principalColumn: "TrainingTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfile_UserId",
                table: "ClientProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfileScheduledTraining_ScheduledTrainingsScheduledTrainingId",
                table: "ClientProfileScheduledTraining",
                column: "ScheduledTrainingsScheduledTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachProfile_UserId",
                table: "CoachProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoachProfileTrainingType_TrainingTypesTrainingTypeId",
                table: "CoachProfileTrainingType",
                column: "TrainingTypesTrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTraining_TrainingTypeId",
                table: "ScheduledTraining",
                column: "TrainingTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientProfileScheduledTraining");

            migrationBuilder.DropTable(
                name: "CoachProfileTrainingType");

            migrationBuilder.DropTable(
                name: "ClientProfile");

            migrationBuilder.DropTable(
                name: "ScheduledTraining");

            migrationBuilder.DropTable(
                name: "CoachProfile");

            migrationBuilder.DropTable(
                name: "TrainingType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });
        }
    }
}
