using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TECAirDbAPI.Models;

#nullable disable

namespace TECAirDbAPI
{
    //DbContext file generated from scaffolding
    public partial class TECAirDbContext : DbContext
    {
        public TECAirDbContext()
        {
        }

        public TECAirDbContext(DbContextOptions<TECAirDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bag> Bags { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerInFlight> CustomerInFlights { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=tecairDb;Username=admin;Password=admin1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Bag>(entity =>
            {
                entity.ToTable("bag");

                entity.Property(e => e.Bagid)
                    .HasMaxLength(10)
                    .HasColumnName("bagid")
                    .IsFixedLength(true);

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Flightid)
                    .HasMaxLength(7)
                    .HasColumnName("flightid")
                    .IsFixedLength(true);

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Email, "customer_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Studentid, "customer_studentid_key")
                    .IsUnique();

                entity.Property(e => e.Customerid)
                    .ValueGeneratedNever()
                    .HasColumnName("customerid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("email");

                entity.Property(e => e.Lastnamecustomer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("lastnamecustomer");

                entity.Property(e => e.Miles)
                    .HasColumnName("miles")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Namecustomer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("namecustomer");

                entity.Property(e => e.Passcustomer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("passcustomer");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.University)
                    .HasMaxLength(20)
                    .HasColumnName("university");
            });

            modelBuilder.Entity<CustomerInFlight>(entity =>
            {
                entity.HasKey(e => new { e.Customerid, e.Flightid })
                    .HasName("customer_in_flight_pkey");

                entity.ToTable("customer_in_flight");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Flightid)
                    .HasMaxLength(7)
                    .HasColumnName("flightid")
                    .IsFixedLength(true);

                entity.Property(e => e.Seatnum)
                    .HasMaxLength(3)
                    .HasColumnName("seatnum")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.Property(e => e.Flightid)
                    .HasMaxLength(7)
                    .HasColumnName("flightid")
                    .IsFixedLength(true);

                entity.Property(e => e.Arrival).HasColumnName("arrival");

                entity.Property(e => e.Bagquantity)
                    .HasColumnName("bagquantity")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Departure).HasColumnName("departure");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("destination")
                    .IsFixedLength(true);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Gate).HasColumnName("gate");

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("origin")
                    .IsFixedLength(true);

                entity.Property(e => e.Planeid)
                    .HasMaxLength(6)
                    .HasColumnName("planeid")
                    .HasDefaultValueSql("0")
                    .IsFixedLength(true);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Stops).HasColumnName("stops");

                entity.Property(e => e.Userquantity)
                    .HasColumnName("userquantity")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Workerid)
                    .HasColumnName("workerid")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.ToTable("plane");

                entity.Property(e => e.Planeid)
                    .HasMaxLength(6)
                    .HasColumnName("planeid")
                    .IsFixedLength(true);

                entity.Property(e => e.Bagcap).HasColumnName("bagcap");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("model");

                entity.Property(e => e.Passengercap).HasColumnName("passengercap");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("worker");

                entity.Property(e => e.Workerid)
                    .ValueGeneratedNever()
                    .HasColumnName("workerid");

                entity.Property(e => e.Lastnameworker)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("lastnameworker");

                entity.Property(e => e.Nameworker)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("nameworker");

                entity.Property(e => e.Passworker)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("passworker");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
