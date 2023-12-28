﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231228200000_ViewerRole")]
    partial class ViewerRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Capacity")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EngineType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Power")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegistratioinNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 4m,
                            ContactId = 3,
                            EngineType = 3,
                            ManufacturerId = 1001,
                            Model = "Fusion",
                            Power = 340m,
                            RegistratioinNumber = 1362
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 3.5m,
                            ContactId = 2,
                            EngineType = 0,
                            ManufacturerId = 1002,
                            Model = "CR-V",
                            Power = 190m,
                            RegistratioinNumber = 98
                        });
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Birth = new DateTime(2023, 12, 28, 21, 0, 0, 117, DateTimeKind.Local).AddTicks(5481),
                            Email = "adam@wsei.edu.pl",
                            Name = "Adam",
                            OrganizationId = 101,
                            Phone = "123456789"
                        },
                        new
                        {
                            ContactId = 2,
                            Birth = new DateTime(2023, 12, 28, 21, 0, 0, 117, DateTimeKind.Local).AddTicks(5545),
                            Email = "ewa@wsei.edu.pl",
                            Name = "Ewa",
                            OrganizationId = 102,
                            Phone = "123456777"
                        },
                        new
                        {
                            ContactId = 3,
                            Birth = new DateTime(2023, 12, 28, 21, 0, 0, 117, DateTimeKind.Local).AddTicks(5551),
                            Email = "karol@wsei.edu.pl",
                            Name = "Karol",
                            Phone = "123456788"
                        });
                });

            modelBuilder.Entity("Data.Entities.ManufacturerEntity", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1001,
                            Name = "Ford"
                        },
                        new
                        {
                            ManufacturerId = 1002,
                            Name = "Honda"
                        });
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organisations");

                    b.HasData(
                        new
                        {
                            OrganizationId = 101,
                            Description = "Uczelnia wyższa",
                            Name = "WSEI"
                        },
                        new
                        {
                            OrganizationId = 102,
                            Description = "Przedsiębiorstwo IT",
                            Name = "Comarch"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ebb32830-fe02-4dc7-8fc9-45e84886aa41",
                            ConcurrencyStamp = "ebb32830-fe02-4dc7-8fc9-45e84886aa41",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9",
                            ConcurrencyStamp = "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "baa447d2-63d2-46e3-8495-2940fb54a2b4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "75831d10-fd60-48f8-9d90-7e299986f85c",
                            Email = "adam@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADAM@WSEI.EDU.PL",
                            NormalizedUserName = "ADAM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPbKhBOqKW1p2WL8tyXT4TGENXuVRyhK+zVopsavYXg3LNQJwPJtN3GxLPemAN7+zg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d5ac1a0d-1d05-4d3d-807f-a813920a3a17",
                            TwoFactorEnabled = false,
                            UserName = "adam"
                        },
                        new
                        {
                            Id = "03b9d487-5008-4933-a504-5df09696f095",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ea283fe4-b91f-4f35-978e-239bc445e9c4",
                            Email = "user@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@WSEI.EDU.PL",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEJd765Q+Ah24TJLjSIsy6lU7aGl2qQiG1aI95ago7Jg3vWahwLyOyaEZx4Fb3UXXwQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "106e6ebd-690c-4093-b4a4-dabdabec1e87",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "baa447d2-63d2-46e3-8495-2940fb54a2b4",
                            RoleId = "ebb32830-fe02-4dc7-8fc9-45e84886aa41"
                        },
                        new
                        {
                            UserId = "03b9d487-5008-4933-a504-5df09696f095",
                            RoleId = "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.HasOne("Data.Entities.ContactEntity", "OwnerContact")
                        .WithMany("Cars")
                        .HasForeignKey("ContactId");

                    b.HasOne("Data.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("Cars")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("OwnerContact");
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.HasOne("Data.Entities.OrganizationEntity", "Organization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data.Entities.ManufacturerEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ManufacturerEntityManufacturerId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ManufacturerEntityManufacturerId");

                            b1.ToTable("Manufacturers");

                            b1.WithOwner()
                                .HasForeignKey("ManufacturerEntityManufacturerId");

                            b1.HasData(
                                new
                                {
                                    ManufacturerEntityManufacturerId = 1001,
                                    City = "Dearborn",
                                    Country = "Unated States",
                                    PostalCode = "MI 48126",
                                    Street = "Ford Motor Company"
                                },
                                new
                                {
                                    ManufacturerEntityManufacturerId = 1002,
                                    City = "Tokyo",
                                    Country = "Japan",
                                    PostalCode = "107-8556",
                                    Street = "2-1-1 Minami-Aoyama"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityOrganizationId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityOrganizationId");

                            b1.ToTable("Organisations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityOrganizationId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityOrganizationId = 101,
                                    City = "Kraków",
                                    Country = "Polska",
                                    PostalCode = "31-150",
                                    Street = "św. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityOrganizationId = 102,
                                    City = "Kraków",
                                    Country = "Polska",
                                    PostalCode = "36-160",
                                    Street = "Rozwoju 1/4"
                                });
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Data.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}