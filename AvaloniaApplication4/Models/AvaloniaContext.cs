using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication4.Models;

public partial class AvaloniaContext : DbContext
{
    public AvaloniaContext()
    {
    }

    public AvaloniaContext(DbContextOptions<AvaloniaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buytype> Buytypes { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Carmodel> Carmodels { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purсhase> Purсhases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=avalonia;Username=postgres;Password=784512bf3X");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buytype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("buytype_pkey");

            entity.ToTable("buytype");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_pkey");

            entity.ToTable("car");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CarName).HasColumnName("car_name");
            entity.Property(e => e.MoedlId).HasColumnName("moedl_id");

            entity.HasOne(d => d.Moedl).WithMany(p => p.Cars)
                .HasForeignKey(d => d.MoedlId)
                .HasConstraintName("car_moedl_id_fkey");
        });

        modelBuilder.Entity<Carmodel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carmodel_pkey");

            entity.ToTable("carmodel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Model).HasColumnName("model");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.ClientLastname).HasColumnName("client_lastname");
            entity.Property(e => e.ClientName).HasColumnName("client_name");
            entity.Property(e => e.ClientSurname).HasColumnName("client_surname");
            entity.Property(e => e.PassportId).HasColumnName("passport_id");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(11)
                .HasColumnName("telephone_number");

            entity.HasOne(d => d.Passport).WithMany(p => p.Clients)
                .HasForeignKey(d => d.PassportId)
                .HasConstraintName("client_passport_id_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_pkey");

            entity.ToTable("country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passport_pkey");

            entity.ToTable("passport");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(4)
                .HasColumnName("number");
            entity.Property(e => e.Series)
                .HasMaxLength(4)
                .HasColumnName("series");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.Car).WithMany(p => p.Products)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("product_car_id_fkey");

            entity.HasOne(d => d.Country).WithMany(p => p.Products)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("product_country_id_fkey");
        });

        modelBuilder.Entity<Purсhase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purсhase_pkey");

            entity.ToTable("purсhase");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BuyTypeYd).HasColumnName("buy_type_yd");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");

            entity.HasOne(d => d.BuyTypeYdNavigation).WithMany(p => p.Purсhases)
                .HasForeignKey(d => d.BuyTypeYd)
                .HasConstraintName("purсhase_buy_type_yd_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Purсhases)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("purсhase_product_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
