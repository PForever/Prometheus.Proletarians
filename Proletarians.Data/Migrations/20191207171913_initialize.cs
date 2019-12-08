using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proletarians.Data.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeCategorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    From = table.Column<int>(nullable: false),
                    To = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    Finish = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    Contacts_Phone_ContryCode = table.Column<int>(nullable: true),
                    Contacts_Phone_RegionCode = table.Column<int>(nullable: true),
                    Contacts_Phone_Number = table.Column<int>(nullable: true),
                    Contacts_Email_Alias = table.Column<string>(nullable: true),
                    Contacts_Email_Host = table.Column<string>(nullable: true),
                    Contacts_Address_Country = table.Column<string>(nullable: true),
                    Contacts_Address_Region = table.Column<string>(nullable: true),
                    Contacts_Address_City = table.Column<string>(nullable: true),
                    Contacts_Address_Street = table.Column<string>(nullable: true),
                    Contacts_Address_Build = table.Column<string>(nullable: true),
                    Contacts_Address_Room = table.Column<string>(nullable: true),
                    Contacts_Address_PostIndex = table.Column<int>(nullable: true),
                    AgeCategoryId = table.Column<Guid>(nullable: true),
                    AdditionalInformations = table.Column<string>(nullable: true),
                    Acquaintance_PeriodId = table.Column<Guid>(nullable: true),
                    Acquaintance_LocationId = table.Column<Guid>(nullable: true),
                    Acquaintance_Discription = table.Column<string>(nullable: true),
                    SotialStatus = table.Column<int>(nullable: false),
                    Relation = table.Column<int>(nullable: false),
                    OrganizationStatus = table.Column<int>(nullable: false),
                    ParticipantStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Locations_Acquaintance_LocationId",
                        column: x => x.Acquaintance_LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_Periods_Acquaintance_PeriodId",
                        column: x => x.Acquaintance_PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_AgeCategorys_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conferenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    TargetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvitationProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: true),
                    Round = table.Column<int>(nullable: false),
                    InvitationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitationProfiles_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvitationProfiles_Profiles_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReasonForCalls",
                columns: table => new
                {
                    InvitationId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonForCalls", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_ReasonForCalls_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Outreachs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outreachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequestId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    OperatorId = table.Column<Guid>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvitationProfileResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvitationProfileId = table.Column<Guid>(nullable: true),
                    CallerId = table.Column<Guid>(nullable: true),
                    Result = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationProfileResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitationProfileResults_InvitationProfiles_InvitationProfileId",
                        column: x => x.InvitationProfileId,
                        principalTable: "InvitationProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutreachGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Interval_From = table.Column<DateTime>(nullable: true),
                    Interval_To = table.Column<DateTime>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    ResponsibleId = table.Column<Guid>(nullable: true),
                    OutreachId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutreachGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutreachGroups_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutreachGroups_Outreachs_OutreachId",
                        column: x => x.OutreachId,
                        principalTable: "Outreachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    OutreachGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationProfiles_OutreachGroups_OutreachGroupId",
                        column: x => x.OutreachGroupId,
                        principalTable: "OutreachGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationProfiles_Profiles_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_OrganizationProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "OrganizationProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Interval_From = table.Column<DateTime>(nullable: true),
                    Interval_To = table.Column<DateTime>(nullable: true),
                    CandidateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_OrganizationProfiles_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "OrganizationProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponsrbleFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrganizerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsrbleFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsrbleFields_OrganizationProfiles_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "OrganizationProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assigns",
                columns: table => new
                {
                    ManagerId = table.Column<Guid>(nullable: false),
                    ResponsrbleFieldId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigns", x => new { x.ManagerId, x.ResponsrbleFieldId });
                    table.ForeignKey(
                        name: "FK_Assigns_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assigns_ResponsrbleFields_ResponsrbleFieldId",
                        column: x => x.ResponsrbleFieldId,
                        principalTable: "ResponsrbleFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    ResponsrbleFieldId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_ResponsrbleFields_ResponsrbleFieldId",
                        column: x => x.ResponsrbleFieldId,
                        principalTable: "ResponsrbleFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Discription", "Name" },
                values: new object[] { new Guid("d69c5900-8f59-49de-8cbf-f3444bf58b39"), null, "Политех" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Discription", "Name" },
                values: new object[] { new Guid("c06dea75-2535-44cd-b0eb-b661d61a8276"), null, "Мужесво" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Discription", "Name" },
                values: new object[] { new Guid("c8d75d8c-a9c1-4265-910a-c395928a1682"), null, "Девяткино" });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "Finish", "Start" },
                values: new object[] { new Guid("9e8b1df0-993b-47ef-9a14-99c1469d37c7"), new DateTime(2019, 1, 7, 20, 19, 13, 92, DateTimeKind.Local).AddTicks(1136), new DateTime(2018, 12, 7, 20, 19, 13, 90, DateTimeKind.Local).AddTicks(2304) });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "AdditionalInformations", "AgeCategoryId", "Alias", "FirstName", "LastName", "MiddleName", "OrganizationStatus", "ParticipantStatus", "Relation", "SotialStatus", "Acquaintance_Discription", "Acquaintance_LocationId", "Acquaintance_PeriodId" },
                values: new object[] { new Guid("50ae9655-27c5-456f-8f4e-4a6e949a2f44"), null, null, null, "Олег", "Крузенштейн", "Леонидович", 0, 0, 0, 0, null, new Guid("c06dea75-2535-44cd-b0eb-b661d61a8276"), new Guid("9e8b1df0-993b-47ef-9a14-99c1469d37c7") });

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_ResponsrbleFieldId",
                table: "Assigns",
                column: "ResponsrbleFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Conferenses_EventId",
                table: "Conferenses",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResponsrbleFieldId",
                table: "Events",
                column: "ResponsrbleFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationProfileResults_CallerId",
                table: "InvitationProfileResults",
                column: "CallerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationProfileResults_InvitationProfileId",
                table: "InvitationProfileResults",
                column: "InvitationProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationProfiles_InvitationId",
                table: "InvitationProfiles",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationProfiles_PersonId",
                table: "InvitationProfiles",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_EventId",
                table: "Invitations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_TargetId",
                table: "Invitations",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_EventId",
                table: "Lectures",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_ProfileId",
                table: "Managers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_EventId",
                table: "Meetings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProfiles_OutreachGroupId",
                table: "OrganizationProfiles",
                column: "OutreachGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProfiles_PersonId",
                table: "OrganizationProfiles",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OutreachGroups_LocationId",
                table: "OutreachGroups",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OutreachGroups_OutreachId",
                table: "OutreachGroups",
                column: "OutreachId");

            migrationBuilder.CreateIndex(
                name: "IX_OutreachGroups_ResponsibleId",
                table: "OutreachGroups",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Outreachs_EventId",
                table: "Outreachs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Acquaintance_LocationId",
                table: "Profiles",
                column: "Acquaintance_LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Acquaintance_PeriodId",
                table: "Profiles",
                column: "Acquaintance_PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AgeCategoryId",
                table: "Profiles",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestResults_EventId",
                table: "RequestResults",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestResults_OperatorId",
                table: "RequestResults",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestResults_RequestId",
                table: "RequestResults",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CandidateId",
                table: "Requests",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsrbleFields_OrganizerId",
                table: "ResponsrbleFields",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferenses_Events_EventId",
                table: "Conferenses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Events_EventId",
                table: "Invitations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Events_TargetId",
                table: "Invitations",
                column: "TargetId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Events_EventId",
                table: "Lectures",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Events_EventId",
                table: "Meetings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Outreachs_Events_EventId",
                table: "Outreachs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestResults_Events_EventId",
                table: "RequestResults",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestResults_OrganizationProfiles_OperatorId",
                table: "RequestResults",
                column: "OperatorId",
                principalTable: "OrganizationProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestResults_Requests_RequestId",
                table: "RequestResults",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationProfileResults_OrganizationProfiles_CallerId",
                table: "InvitationProfileResults",
                column: "CallerId",
                principalTable: "OrganizationProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutreachGroups_OrganizationProfiles_ResponsibleId",
                table: "OutreachGroups",
                column: "ResponsibleId",
                principalTable: "OrganizationProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ResponsrbleFields_ResponsrbleFieldId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Outreachs_Events_EventId",
                table: "Outreachs");

            migrationBuilder.DropForeignKey(
                name: "FK_OutreachGroups_OrganizationProfiles_ResponsibleId",
                table: "OutreachGroups");

            migrationBuilder.DropTable(
                name: "Assigns");

            migrationBuilder.DropTable(
                name: "Conferenses");

            migrationBuilder.DropTable(
                name: "InvitationProfileResults");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "ReasonForCalls");

            migrationBuilder.DropTable(
                name: "RequestResults");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "InvitationProfiles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "ResponsrbleFields");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "OrganizationProfiles");

            migrationBuilder.DropTable(
                name: "OutreachGroups");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Outreachs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "AgeCategorys");
        }
    }
}
