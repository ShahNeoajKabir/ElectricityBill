using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public  DbSet<BillTable> BillTable { get; set; }
        public  DbSet<Notice> Notice { get; set; }
        public  DbSet<Customer> Customer { get; set; }
        public  DbSet<MeterAssign> MeterAssign { get; set; }
        public  DbSet<MeterReadingTable> MeterReadingTable { get; set; }
        public  DbSet<MeterTable> MeterTable { get; set; }
        public  DbSet<Payment> Payment { get; set; }
        public  DbSet<Role> Role { get; set; }
        public  DbSet<Support> Support { get; set; }
        public  DbSet<User> User { get; set; }
        public  DbSet<UserRole> UserRole { get; set; }
        public  DbSet<Zone> Zone { get; set; }
        public  DbSet<ZoneAssign> ZoneAssign { get; set; }
        public  DbSet<UnitPrice> UnitPrice { get; set; }
        public  DbSet<CardInformation> CardInformation { get; set; }
        public  DbSet<MobileBanking> MobileBanking { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(e => e.NoticeId);
                entity.Property(e => e.Notices);
            });
            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(e => e.ZoneId);
            });

            modelBuilder.Entity<ZoneAssign>(entity =>
            {
                entity.HasKey(e => e.ZoneAssignId);
                entity.HasOne(d => d.User)
                .WithMany(p => p.ZoneAssign)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Zone)
                .WithMany(p => p.ZoneAssign)
                .HasForeignKey(d => d.ZoneId)
                .OnDelete(DeleteBehavior.Cascade);
            });




            modelBuilder.Entity<BillTable>(entity =>
            {
                
                entity.HasKey(e => e.BillId);
                entity.Property(d => d.CustomerId);
                entity.Property(d => d.MeterId);
                entity.Property(d => d.BillStatus);
                entity.HasOne(e => e.MeterReadingTable)
                .WithOne(e => e.BillTable)
                .HasForeignKey<BillTable>(e => e.MeterReadingId);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(d => d.UserName);
                entity.Property(d => d.Email);
            });
            modelBuilder.Entity<UnitPrice>(entity =>
            {
                entity.HasKey(e => e.UnitPriceId);
                entity.Property(d => d.CustomerType);
                entity.Property(d => d.UnitperPrice);
            });


            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(d => d.RoleName);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);
                entity.HasOne(p => p.User)
                .WithMany(d => d.UserRole)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Role)
                .WithMany(d => d.UserRole)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<MeterTable>(entity =>
            {
                entity.HasKey(e => e.MeterId);
                entity.Property(e => e.MeterId);
            });

            modelBuilder.Entity<MeterAssign>(entity =>
            {
                entity.HasKey(e => e.MeterAssignId);
                entity.HasOne(d => d.Customer)
                .WithMany(p => p.MeterAssign)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.MeterTable)
                .WithMany(p => p.MeterAssign)
                .HasForeignKey(d => d.MeterId)
                .OnDelete(DeleteBehavior.Cascade);



            });


            modelBuilder.Entity<MeterReadingTable>(entity =>
            {
                entity.HasKey(e => e.MeterReadingId);



                entity.HasOne(d => d.MeterAssign)
                .WithMany(p => p.MeterReadingTable)
                .HasForeignKey(d => d.MeterAssignId)
                .OnDelete(DeleteBehavior.Restrict);


                entity.Property(e => e.CurrentUnit);
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.Property(d => d.Email);
                entity.Property(d => d.CustomerName);

                entity.Property(d => d.ZoneId);

            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                entity.Property(d => d.BillId);
                entity.Property(d => d.PaymentMethod);

                entity.HasOne(e => e.BillTable)
               .WithOne(e => e.Payment)
               .HasForeignKey<Payment>(e => e.BillId);
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.HasKey(e => e.SupportId);
                entity.Property(d => d.SupportSubject);
            });
            modelBuilder.Entity<CardInformation>(entity =>
            {
                entity.HasKey(e => e.CardInformationId);
                entity.Property(d => d.CardNumber);
                entity.Property(d => d.Balance);

            });
            modelBuilder.Entity<MobileBanking>(entity =>
            {
                entity.HasKey(e => e.MobileBankingId);
                entity.Property(d => d.MobileNo);
                entity.Property(d => d.Pin);
                entity.Property(d => d.Balance);
            });
        }
    }
}
