﻿// <auto-generated />
using System;
using Linkup.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Linkup.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201021194714_changeCorpIdToEmail")]
    partial class changeCorpIdToEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("ApplicationUserProject", b =>
                {
                    b.Property<string>("ParticipantsEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsEmail", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("ApplicationUserProject");
                });

            modelBuilder.Entity("Linkup.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Linkup.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Linkup.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApplicationUserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserEmail");

                    b.HasIndex("ProjectId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ApplicationUserProject", b =>
                {
                    b.HasOne("Linkup.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Linkup.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Linkup.Models.Skill", b =>
                {
                    b.HasOne("Linkup.Models.ApplicationUser", null)
                        .WithMany("Skills")
                        .HasForeignKey("ApplicationUserEmail");

                    b.HasOne("Linkup.Models.Project", null)
                        .WithMany("NeededSkills")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Linkup.Models.ApplicationUser", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Linkup.Models.Project", b =>
                {
                    b.Navigation("NeededSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
