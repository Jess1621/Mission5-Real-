﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission4.Models;

namespace Mission4.Migrations
{
    [DbContext(typeof(MovieApplicationContext))]
    [Migration("20220202000519_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Mission4.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ApplicationID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            ApplicationID = 1,
                            CategoryID = 1,
                            Director = "Doug Liman",
                            Edited = false,
                            LentTo = "",
                            Notes = "Awesome Movie!",
                            Rating = "PG-13",
                            Title = "Jason Bourne: Bourne Identity",
                            Year = 2002
                        },
                        new
                        {
                            ApplicationID = 2,
                            CategoryID = 3,
                            Director = "Gavin O'Conner",
                            Edited = false,
                            LentTo = "",
                            Notes = "Watch alone, makes me emotional",
                            Rating = "PG-13",
                            Title = "Warrior",
                            Year = 2011
                        },
                        new
                        {
                            ApplicationID = 3,
                            CategoryID = 4,
                            Director = "Denis Villeneuve",
                            Edited = false,
                            LentTo = "",
                            Notes = "Super Awesome Movie, should read the book too...",
                            Rating = "PG-13",
                            Title = "Dune",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("Mission4.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Fantasy"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Horror"
                        },
                        new
                        {
                            CategoryID = 6,
                            CategoryName = "Mystery"
                        },
                        new
                        {
                            CategoryID = 7,
                            CategoryName = "Romance"
                        },
                        new
                        {
                            CategoryID = 8,
                            CategoryName = "Thriller"
                        },
                        new
                        {
                            CategoryID = 9,
                            CategoryName = "Other"
                        });
                });

            modelBuilder.Entity("Mission4.Models.ApplicationResponse", b =>
                {
                    b.HasOne("Mission4.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}