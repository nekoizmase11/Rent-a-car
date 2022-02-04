using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RentacarApi.Data.Models.Enums;

namespace RentacarApi.Data.Models
{
    public partial class ReantacarContext : DbContext
    {
        public ReantacarContext()
        {
        }

        public ReantacarContext(DbContextOptions<ReantacarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\dumi\\source\\repos\\RentacarApi\\RentacarApi.Data\\Data\\RentacarDb.mdf;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.BodyType).HasMaxLength(50);

                entity.Property(e => e.Brand).HasConversion(c => c.ToString(), c => Enum.Parse<EBrand>(c));

                entity.Property(e => e.Type).HasConversion(c => c.ToString(), c => Enum.Parse<EType>(c));

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.ManifactureDate).HasColumnType("date");
            });

            modelBuilder.Entity<BrandType>(entity =>
            {
                entity.ToTable("BrandType");

                entity.HasNoKey();

                entity.Property(e => e.BrandId);

                entity.Property(e => e.BrandId);

            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservedFrom).HasColumnType("date");

                entity.Property(e => e.ReservedTo).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_To_Car");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_To_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
