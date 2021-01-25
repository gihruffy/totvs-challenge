﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TOTVSChallenge.Respository.Database.Context;

namespace TOTVSChallenge.Respository.Database.Migrations
{
    [DbContext(typeof(TOTVSChallengeContext))]
    [Migration("20210125132336_EntityReference")]
    partial class EntityReference
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TOTVSChallenge.Domain.Entities.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Used")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("TOTVSChallenge.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Password = "123456",
                            Role = "Admin",
                            Username = "giovanni"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Password = "654321",
                            Role = "Admin",
                            Username = "teste"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = false,
                            Password = "123456",
                            Role = "User",
                            Username = "outro"
                        });
                });

            modelBuilder.Entity("TOTVSChallenge.Domain.Entities.Auction", b =>
                {
                    b.HasOne("TOTVSChallenge.Domain.Entities.User", "UserReference")
                        .WithOne("AuctionReference")
                        .HasForeignKey("TOTVSChallenge.Domain.Entities.Auction", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserReference");
                });

            modelBuilder.Entity("TOTVSChallenge.Domain.Entities.User", b =>
                {
                    b.Navigation("AuctionReference");
                });
#pragma warning restore 612, 618
        }
    }
}
