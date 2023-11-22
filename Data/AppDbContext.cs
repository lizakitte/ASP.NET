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
            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adam",
                NormalizedUserName = "ADAM",
                Email = "adam@wsei.edu.pl",
                NormalizedEmail = "ADAM@WSEI.EDU.PL",
                EmailConfirmed = true
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "1234Qwe!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(user);

            //tworzenie admina
            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            
            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);

            //skojarzenie uzytkownika z rola admina
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id
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
                    Id = 101,
                    Name = "WSEI",
                    Description = "Uczelnia wyższa"
                },
                new OrganizationEntity()
                {
                    Id = 102,
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
                        OrganizationEntityId = 101,
                        City = "Kraków",
                        Street = "św. Filipa 17",
                        PostalCode = "31-150"
                    },
                    new
                    {
                        OrganizationEntityId = 102,
                        City = "Kraków",
                        Street = "Rozwoju 1/4",
                        PostalCode = "36-160"
                    }
                );
        }
    }
}
