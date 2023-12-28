using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        private string Path { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organisations { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var userAdmin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adam",
                NormalizedUserName = "ADAM",
                Email = "adam@wsei.edu.pl",
                NormalizedEmail = "ADAM@WSEI.EDU.PL",
                EmailConfirmed = true
            };

            var viewer = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            userAdmin.PasswordHash = passwordHasher.HashPassword(userAdmin, "1234Qwe!");
            viewer.PasswordHash = passwordHasher.HashPassword(viewer, "1234Abc!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(userAdmin);
            modelBuilder.Entity<IdentityUser>()
                .HasData(viewer);

            //tworzenie roli
            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var viewerRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            viewerRole.ConcurrencyStamp = viewerRole.Id;
            
            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);
            modelBuilder.Entity<IdentityRole>()
                .HasData(viewerRole);

            //skojarzenie uzytkownika z rola
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = userAdmin.Id
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = viewerRole.Id,
                    UserId = viewer.Id
                }
            );

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                new OrganizationEntity()
                {
                    OrganizationId = 101,
                    Name = "WSEI",
                    Description = "Uczelnia wyższa"
                },
                new OrganizationEntity()
                {
                    OrganizationId = 102,
                    Name = "Comarch",
                    Description = "Przedsiębiorstwo IT"
                }
                );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() 
                { 
                    ContactId = 1, 
                    Name = "Adam", 
                    Email = "adam@wsei.edu.pl", 
                    Phone = "123456789", 
                    Birth =  DateTime.Now,
                    OrganizationId = 101
                },
                new ContactEntity() 
                { 
                    ContactId = 2, 
                    Name = "Ewa", 
                    Email = "ewa@wsei.edu.pl", 
                    Phone = "123456777", 
                    Birth =  DateTime.Now,
                    OrganizationId = 102,
                },
                new ContactEntity() 
                { 
                    ContactId = 3, 
                    Name = "Karol", 
                    Email = "karol@wsei.edu.pl", 
                    Phone = "123456788", 
                    Birth =  DateTime.Now
                }
                );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new
                    {
                        OrganizationEntityOrganizationId = 101,
                        City = "Kraków",
                        Street = "św. Filipa 17",
                        PostalCode = "31-150",
                        Country = "Polska"
                    },
                    new
                    {
                        OrganizationEntityOrganizationId = 102,
                        City = "Kraków",
                        Street = "Rozwoju 1/4",
                        PostalCode = "36-160",
                        Country = "Polska"
                    }
                );


            modelBuilder.Entity<CarEntity>()
                .HasOne(c => c.Manufacturer)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ManufacturerId);

            modelBuilder.Entity<CarEntity>()
                .HasOne(c => c.OwnerContact)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.ContactId);

            modelBuilder.Entity<ManufacturerEntity>()
                .HasData(
                new ManufacturerEntity()
                {
                    ManufacturerId = 1001,
                    Name = "Ford"
                },
                new ManufacturerEntity()
                {
                    ManufacturerId = 1002,
                    Name = "Honda"
                }
                );

            modelBuilder.Entity<ManufacturerEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new
                    {
                        ManufacturerEntityManufacturerId = 1001,
                        City = "Dearborn",
                        Street = "Ford Motor Company",
                        PostalCode = "MI 48126",
                        Country = "Unated States"
                    },
                    new
                    {
                        ManufacturerEntityManufacturerId = 1002,
                        City = "Tokyo",
                        Street = "2-1-1 Minami-Aoyama",
                        PostalCode = "107-8556",
                        Country = "Japan"
                    }
                );

            modelBuilder.Entity<CarEntity>().HasData(
               new CarEntity()
               {
                   Id = 1,
                   Model = "Fusion",
                   ManufacturerId = 1001,
                   Capacity = 4,
                   Power = 340,
                   EngineType = Engine.Hybrid,
                   RegistratioinNumber = 1362,
                   ContactId = 3
               },
               new CarEntity()
               {
                   Id = 2,
                   Model = "CR-V",
                   ManufacturerId = 1002,
                   Capacity = 3.5m,
                   Power = 190,
                   EngineType = Engine.Gasoline,
                   RegistratioinNumber = 0098,
                   ContactId = 2
               }
               );
        }
    }
}
