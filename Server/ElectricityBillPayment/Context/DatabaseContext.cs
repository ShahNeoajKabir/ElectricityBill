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

        public virtual DbSet<BillTable> BillTable { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<MeterAssign> MeterAssign { get; set; }
        public virtual DbSet<MeterReadingTable> MeterReadingTable { get; set; }
        public virtual DbSet<MeterTable> MeterTable { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Support> Support { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
        public virtual DbSet<ZoneAssign> ZoneAssign { get; set; }



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

                entity.HasOne(e => e.Zone)
               .WithOne(e => e.Customer)
               .HasForeignKey<Customer>(e => e.ZoneId);

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
        }
    }
}
