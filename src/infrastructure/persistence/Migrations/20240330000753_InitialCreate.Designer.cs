﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using persistence;

#nullable disable

namespace persistence.Migrations
{
    [DbContext(typeof(EmpContext))]
    [Migration("20240330000753_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("domain.AssignmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("domain.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("domain.GradeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("GradedDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("domain.ProfessorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("domain.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("domain.SubmissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeletedAt")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("SubmittedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("domain.AssignmentEntity", b =>
                {
                    b.HasOne("domain.CourseEntity", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.StudentEntity", "Student")
                        .WithMany("Assignments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("domain.CourseEntity", b =>
                {
                    b.HasOne("domain.ProfessorEntity", "Professor")
                        .WithMany("Courses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("domain.GradeEntity", b =>
                {
                    b.HasOne("domain.AssignmentEntity", "Assignment")
                        .WithMany("Grades")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.CourseEntity", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.StudentEntity", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("domain.StudentEntity", b =>
                {
                    b.HasOne("domain.CourseEntity", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("domain.SubmissionEntity", b =>
                {
                    b.HasOne("domain.AssignmentEntity", "Assignment")
                        .WithMany("Submissions")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.StudentEntity", "Student")
                        .WithMany("Submissions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("domain.AssignmentEntity", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("domain.CourseEntity", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Grades");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("domain.ProfessorEntity", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("domain.StudentEntity", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Grades");

                    b.Navigation("Submissions");
                });
#pragma warning restore 612, 618
        }
    }
}
