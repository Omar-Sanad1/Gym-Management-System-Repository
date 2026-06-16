using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Context.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    OperatingHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentOperationalStatus = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPlans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPlans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    Certifications = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainers_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FitnessClasses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MaximumCapacity = table.Column<int>(type: "int", nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTrainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessClasses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FitnessClasses_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FitnessClasses_Trainers_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PaswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Members_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Members_Trainers_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AttendenceRecords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttendanceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FitnessClassID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendenceRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttendenceRecords_FitnessClasses_FitnessClassID",
                        column: x => x.FitnessClassID,
                        principalTable: "FitnessClasses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AttendenceRecords_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Member_FitnessClass_Enroll",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    FitnessClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member_FitnessClass_Enroll", x => new { x.MemberID, x.FitnessClassID });
                    table.ForeignKey(
                        name: "FK_Member_FitnessClass_Enroll_FitnessClasses_FitnessClassID",
                        column: x => x.FitnessClassID,
                        principalTable: "FitnessClasses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Member_FitnessClass_Enroll_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MembershipSubscriptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    MembershipPlanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipSubscriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MembershipSubscriptions_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MembershipSubscriptions_MembershipPlans_MembershipPlanID",
                        column: x => x.MembershipPlanID,
                        principalTable: "MembershipPlans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FitnessClassID = table.Column<int>(type: "int", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_FitnessClasses_FitnessClassID",
                        column: x => x.FitnessClassID,
                        principalTable: "FitnessClasses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reviews_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reviews_Trainers_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TransactionReferenceNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RelatedMembershipSubscription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MembershipSubscriptionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_MembershipSubscriptions_MembershipSubscriptionID",
                        column: x => x.MembershipSubscriptionID,
                        principalTable: "MembershipSubscriptions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendenceRecords_FitnessClassID",
                table: "AttendenceRecords",
                column: "FitnessClassID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendenceRecords_MemberID",
                table: "AttendenceRecords",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClasses_BranchID",
                table: "FitnessClasses",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClasses_TrainerID",
                table: "FitnessClasses",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_FitnessClass_Enroll_FitnessClassID",
                table: "Member_FitnessClass_Enroll",
                column: "FitnessClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_BranchID",
                table: "Members",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TrainerID",
                table: "Members",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipSubscriptions_MemberID",
                table: "MembershipSubscriptions",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipSubscriptions_MembershipPlanID",
                table: "MembershipSubscriptions",
                column: "MembershipPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MembershipSubscriptionID",
                table: "Payments",
                column: "MembershipSubscriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FitnessClassID",
                table: "Reviews",
                column: "FitnessClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MemberID",
                table: "Reviews",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TrainerID",
                table: "Reviews",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_BranchID",
                table: "Trainers",
                column: "BranchID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendenceRecords");

            migrationBuilder.DropTable(
                name: "Member_FitnessClass_Enroll");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "MembershipSubscriptions");

            migrationBuilder.DropTable(
                name: "FitnessClasses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MembershipPlans");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
