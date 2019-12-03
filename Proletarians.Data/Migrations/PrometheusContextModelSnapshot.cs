﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proletarians.Data;

namespace Proletarians.Data.Migrations
{
    [DbContext(typeof(PrometheusContext))]
    partial class PrometheusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview3.19554.8");

            modelBuilder.Entity("Proletarians.Data.Models.AgeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("From")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("To")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AgeCategorys");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Assign", b =>
                {
                    b.Property<Guid>("ManagerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResponsrbleFieldId")
                        .HasColumnType("TEXT");

                    b.HasKey("ManagerId", "ResponsrbleFieldId");

                    b.HasIndex("ResponsrbleFieldId");

                    b.ToTable("Assigns");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Conferense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Conferenses");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventType")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ResponsrbleFieldId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResponsrbleFieldId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TargetId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("Proletarians.Data.Models.InvitationProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InvitationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Round")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InvitationId");

                    b.HasIndex("PersonId");

                    b.ToTable("InvitationProfiles");
                });

            modelBuilder.Entity("Proletarians.Data.Models.InvitationProfileResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CallerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discription")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InvitationProfileId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Result")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CallerId");

                    b.HasIndex("InvitationProfileId");

                    b.ToTable("InvitationProfileResults");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("Proletarians.Data.Models.OrganizationProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OutreachGroupId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OutreachGroupId");

                    b.HasIndex("PersonId");

                    b.ToTable("OrganizationProfiles");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Outreach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Outreachs");
                });

            modelBuilder.Entity("Proletarians.Data.Models.OutreachGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OutreachId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResponsibleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("OutreachId");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("OutreachGroups");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Finish")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalInformations")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AgeCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Relation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SotialStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AgeCategoryId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Proletarians.Data.Models.RequestResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OperatorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("OperatorId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestResults");
                });

            modelBuilder.Entity("Proletarians.Data.Models.ResponsrbleField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrganizerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("ResponsrbleFields");
                });

            modelBuilder.Entity("Proletarians.Data.Models.Assign", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Manager", "Manager")
                        .WithMany("Assigns")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.ResponsrbleField", "ResponsrbleField")
                        .WithMany("Assigns")
                        .HasForeignKey("ResponsrbleFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Conferense", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Event", b =>
                {
                    b.HasOne("Proletarians.Data.Models.ResponsrbleField", "ResponsrbleField")
                        .WithMany()
                        .HasForeignKey("ResponsrbleFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Invitation", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.Event", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Proletarians.Data.Models.ReasonForCall", "ReasonForCall", b1 =>
                        {
                            b1.Property<Guid>("InvitationId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Reason")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("InvitationId");

                            b1.ToTable("ReasonForCalls");

                            b1.WithOwner()
                                .HasForeignKey("InvitationId");
                        });
                });

            modelBuilder.Entity("Proletarians.Data.Models.InvitationProfile", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Invitation", "Invitation")
                        .WithMany("InvitationProfiles")
                        .HasForeignKey("InvitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.Profile", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.InvitationProfileResult", b =>
                {
                    b.HasOne("Proletarians.Data.Models.OrganizationProfile", "Caller")
                        .WithMany()
                        .HasForeignKey("CallerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.InvitationProfile", "InvitationProfile")
                        .WithMany()
                        .HasForeignKey("InvitationProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Lecture", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Manager", b =>
                {
                    b.HasOne("Proletarians.Data.Models.OrganizationProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Meeting", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.OrganizationProfile", b =>
                {
                    b.HasOne("Proletarians.Data.Models.OutreachGroup", null)
                        .WithMany("Group")
                        .HasForeignKey("OutreachGroupId");

                    b.HasOne("Proletarians.Data.Models.Profile", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.Outreach", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.OutreachGroup", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.Outreach", null)
                        .WithMany("Groups")
                        .HasForeignKey("OutreachId");

                    b.HasOne("Proletarians.Data.Models.OrganizationProfile", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Proletarians.Data.Models.Interval", "Interval", b1 =>
                        {
                            b1.Property<Guid>("OutreachGroupId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("From")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("To")
                                .HasColumnType("TEXT");

                            b1.HasKey("OutreachGroupId");

                            b1.ToTable("OutreachGroups");

                            b1.WithOwner()
                                .HasForeignKey("OutreachGroupId");
                        });
                });

            modelBuilder.Entity("Proletarians.Data.Models.Profile", b =>
                {
                    b.HasOne("Proletarians.Data.Models.AgeCategory", "AgeCategory")
                        .WithMany()
                        .HasForeignKey("AgeCategoryId");

                    b.OwnsOne("Proletarians.Data.Models.Acquaintance", "Acquaintance", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Discription")
                                .HasColumnType("TEXT");

                            b1.Property<Guid?>("LocationId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("PeriodId")
                                .HasColumnType("TEXT");

                            b1.HasKey("ProfileId");

                            b1.HasIndex("LocationId");

                            b1.HasIndex("PeriodId");

                            b1.ToTable("Profiles");

                            b1.HasOne("Proletarians.Data.Models.Location", "Location")
                                .WithMany()
                                .HasForeignKey("LocationId");

                            b1.HasOne("Proletarians.Data.Models.Period", "Period")
                                .WithMany()
                                .HasForeignKey("PeriodId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.OwnsOne("Proletarians.Data.Models.Contacts", "Contacts", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("TEXT");

                            b1.HasKey("ProfileId");

                            b1.ToTable("Profiles");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");

                            b1.OwnsOne("Proletarians.Data.Models.Address", "Address", b2 =>
                                {
                                    b2.Property<Guid>("ContactsProfileId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Build")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("City")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Country")
                                        .HasColumnType("TEXT");

                                    b2.Property<int?>("PostIndex")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("Region")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Room")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Street")
                                        .HasColumnType("TEXT");

                                    b2.HasKey("ContactsProfileId");

                                    b2.ToTable("Profiles");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactsProfileId");
                                });

                            b1.OwnsOne("Proletarians.Data.Models.Email", "Email", b2 =>
                                {
                                    b2.Property<Guid>("ContactsProfileId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Alias")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Host")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("ContactsProfileId");

                                    b2.ToTable("Profiles");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactsProfileId");
                                });

                            b1.OwnsOne("Proletarians.Data.Models.PhoneNumber", "Phone", b2 =>
                                {
                                    b2.Property<Guid>("ContactsProfileId")
                                        .HasColumnType("TEXT");

                                    b2.Property<int>("ContryCode")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("Number")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("RegionCode")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("ContactsProfileId");

                                    b2.ToTable("Profiles");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactsProfileId");
                                });
                        });
                });

            modelBuilder.Entity("Proletarians.Data.Models.Request", b =>
                {
                    b.HasOne("Proletarians.Data.Models.OrganizationProfile", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Proletarians.Data.Models.Interval", "Interval", b1 =>
                        {
                            b1.Property<Guid>("RequestId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("From")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("To")
                                .HasColumnType("TEXT");

                            b1.HasKey("RequestId");

                            b1.ToTable("Requests");

                            b1.WithOwner()
                                .HasForeignKey("RequestId");
                        });
                });

            modelBuilder.Entity("Proletarians.Data.Models.RequestResult", b =>
                {
                    b.HasOne("Proletarians.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.OrganizationProfile", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proletarians.Data.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proletarians.Data.Models.ResponsrbleField", b =>
                {
                    b.HasOne("Proletarians.Data.Models.OrganizationProfile", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
