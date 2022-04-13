using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
{
    public partial class ECommerceContext : DbContext
    {
        public ECommerceContext()
        {
        }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductEntity> ProductEntities { get; set; }
        public virtual DbSet<ProductValue> ProductValues { get; set; }
        public virtual DbSet<ShoppingSession> ShoppingSessions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ECommerce; User Id=sdg258;password=1233;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateAT");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SessionId).HasColumnName("Session_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_abbcfa26_2edb_4bc1_9803_d8373c147098");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_efa9f501_bb18_4916_9f3e_e459e8e40044");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(1);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateAT");

                entity.Property(e => e.DeleteAt).HasColumnType("datetime");

                entity.Property(e => e.EndDay).HasColumnType("datetime");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.DeleteAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateAT");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_63ee6f0f_6fc6_43dd_8eb3_48cdeed11075");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_97bed54f_95ca_44ae_9478_ac7dc045a9b2");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ae0183c7_812e_4b8d_aac3_03e9eb1741c2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_db409b6e_6304_4076_bb42_abc0fa848ebe");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateAT");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("ProductAttribute");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(1);
            });

            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("ProductEntity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateAT");

                entity.Property(e => e.DeleteAt).HasColumnType("datetime");

                entity.Property(e => e.DiscountId).HasColumnName("Discount_ID");

                entity.Property(e => e.InventoryId).HasColumnName("Inventory_ID");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(1);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductEntities)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_e77fb657_594e_4cad_aec5_c933e4a665c1");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.ProductEntities)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_27e9eada_a5b7_408f_95d2_4cade4f51976");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.ProductEntities)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_ea99c28a_0753_4c33_95a3_961d2729c915");
            });

            modelBuilder.Entity<ProductValue>(entity =>
            {
                entity.ToTable("ProductValue");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttributeId).HasColumnName("Attribute_ID");

                entity.Property(e => e.AttributeValue)
                    .HasMaxLength(1)
                    .HasColumnName("Attribute_Value");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_591b0040_6113_4e54_b839_69da5ad79ef8");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductValues)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_2d9c6763_45f1_45cd_a39e_0ebe3e02033b");
            });

            modelBuilder.Entity<ShoppingSession>(entity =>
            {
                entity.ToTable("ShoppingSession");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateAT");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingSessions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_395888b7_8dc1_4d25_ac8a_a2dc9cea886f");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(1);

                entity.Property(e => e.LastName).HasMaxLength(1);

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("UserAddress");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddresssLine).HasMaxLength(1);

                entity.Property(e => e.City).HasMaxLength(1);

                entity.Property(e => e.District).HasMaxLength(1);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Wards).HasMaxLength(1);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_b8f0ea3d_74b4_4e3a_9b31_513450618a0e");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
