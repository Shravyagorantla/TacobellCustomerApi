using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class TacobellProjectContext : DbContext
    {
        public TacobellProjectContext()
        {
        }

        public TacobellProjectContext(DbContextOptions<TacobellProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<FoodDetails> FoodDetails { get; set; }
        public virtual DbSet<Nutrition> Nutrition { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<PayementDetails> PayementDetails { get; set; }
        public virtual DbSet<RegisterDetails> RegisterDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=TacobellProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.FeedbackId).ValueGeneratedNever();

                entity.Property(e => e.Feedback1)
                    .HasColumnName("Feedback")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__Feedback__FoodId__47DBAE45");
            });

            modelBuilder.Entity<FoodDetails>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__FoodDeta__856DB3EB9D49C67D");

                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imageurl)
                    .HasColumnName("imageurl")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.HasKey(e => e.NuytritionId)
                    .HasName("PK__Nutritio__121FD7A77C9627D4");

                entity.Property(e => e.NuytritionId).ValueGeneratedNever();

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Dairy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FruitorVegetable)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grain)
                    .HasColumnName("grain")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.ProteinClassification)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sodium).HasColumnName("sodium");

                entity.Property(e => e.Totalsugar).HasColumnName("totalsugar");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Nutrition)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__Nutrition__FoodI__403A8C7D");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BCF58326990");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__OrderDeta__FoodI__3C69FB99");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.RegisterId)
                    .HasConstraintName("FK__OrderDeta__Regis__3D5E1FD2");
            });

            modelBuilder.Entity<PayementDetails>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Payement__9B556A38D24FE68D");

                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.Paymentmode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.PayementDetails)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__PayementD__FoodI__4316F928");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PayementDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__PayementD__Order__440B1D61");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.PayementDetails)
                    .HasForeignKey(d => d.RegisterId)
                    .HasConstraintName("FK__PayementD__Regis__44FF419A");
            });

            modelBuilder.Entity<RegisterDetails>(entity =>
            {
                entity.HasKey(e => e.RegisterId)
                    .HasName("PK__Register__B91FAB7966E7C616");

                entity.Property(e => e.RegisterId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
