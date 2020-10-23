﻿// <auto-generated />
using System;
using Linkup.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Linkup.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("ApplicationUserInterest", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InterestsId", "UsersEmail");

                    b.HasIndex("UsersEmail");

                    b.ToTable("ApplicationUserInterest");
                });

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

            modelBuilder.Entity("ApplicationUserSkill", b =>
                {
                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SkillsId", "UsersEmail");

                    b.HasIndex("UsersEmail");

                    b.ToTable("ApplicationUserSkill");
                });

            modelBuilder.Entity("InterestProject", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedInterestsId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsId", "RelatedInterestsId");

                    b.HasIndex("RelatedInterestsId");

                    b.ToTable("InterestProject");
                });

            modelBuilder.Entity("Linkup.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Linkup.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ProjectSkill", b =>
                {
                    b.Property<int>("NeededSkillsId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("NeededSkillsId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("ProjectSkill");
                });

            modelBuilder.Entity("ApplicationUserInterest", b =>
                {
                    b.HasOne("Linkup.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Linkup.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UsersEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("ApplicationUserSkill", b =>
                {
                    b.HasOne("Linkup.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Linkup.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UsersEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InterestProject", b =>
                {
                    b.HasOne("Linkup.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Linkup.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("RelatedInterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectSkill", b =>
                {
                    b.HasOne("Linkup.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("NeededSkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Linkup.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
