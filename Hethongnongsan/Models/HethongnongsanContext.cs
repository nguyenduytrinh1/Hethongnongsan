using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Hethongnongsan.Models
{
    public partial class HethongnongsanContext : DbContext
    {
        public HethongnongsanContext()
        {
        }

        public HethongnongsanContext(DbContextOptions<HethongnongsanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BanTin> BanTin { get; set; }
        public virtual DbSet<Forum> Forum { get; set; }
        public virtual DbSet<Nguoidung> Nguoidung { get; set; }
        public virtual DbSet<SanPhamDaBan> SanPhamDaBan { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Shopcart> Shopcart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=NGUYENDUYTRINH\\DUYTRINH;Initial Catalog=Hethongnongsan;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanTin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Idnguoidung).HasColumnName("idnguoidung");

                entity.Property(e => e.TieuDe).HasMaxLength(50);
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.HasKey(e => e.Iddiendang)
                    .HasName("PK__Forum__EABFAFFA26D6B55E");

                entity.Property(e => e.Iddiendang).HasColumnName("iddiendang");

                entity.Property(e => e.Context)
                    .HasColumnName("context")
                    .HasColumnType("text");

                entity.Property(e => e.Ngaydang)
                    .HasColumnName("ngaydang")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Idnguoidung)
                    .HasName("PK__nguoidun__7C500195049778F3");

                entity.ToTable("nguoidung");

                entity.Property(e => e.Idnguoidung).HasColumnName("idnguoidung");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(255);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("gioitinh")
                    .HasMaxLength(10);

                entity.Property(e => e.Idshop).HasColumnName("idshop");

                entity.Property(e => e.Idshopcart).HasColumnName("idshopcart");

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("date");

                entity.Property(e => e.Roles).HasMaxLength(50);

                entity.Property(e => e.Sodienthoai)
                    .HasColumnName("sodienthoai")
                    .HasMaxLength(20);

                entity.Property(e => e.TaiKhoan).HasMaxLength(50);

                entity.Property(e => e.Tennguoidung)
                    .HasColumnName("tennguoidung")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SanPhamDaBan>(entity =>
            {
                entity.HasKey(e => e.Idsanphamdaban)
                    .HasName("PK__SanPhamD__9B35B4979F7790AD");

                entity.Property(e => e.Idsanphamdaban).HasColumnName("idsanphamdaban");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(200);

                entity.Property(e => e.Idnguoimua).HasColumnName("idnguoimua");

                entity.Property(e => e.Idshop)
                    .HasColumnName("idshop")
                    .HasMaxLength(250);

                entity.Property(e => e.Idshopcart)
                    .HasColumnName("idshopcart")
                    .HasMaxLength(250);

                entity.Property(e => e.Idsp)
                    .HasColumnName("idsp")
                    .HasMaxLength(150);

                entity.Property(e => e.Ngayban)
                    .HasColumnName("ngayban")
                    .HasColumnType("date");

                entity.Property(e => e.Tensanpham)
                    .HasColumnName("tensanpham")
                    .HasMaxLength(250);

                entity.Property(e => e.Tongtien).HasColumnName("tongtien");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Idsanpham)
                    .HasName("PK__sanpham__C5FDB0E50AEC000B");

                entity.ToTable("sanpham");

                entity.Property(e => e.Idsanpham).HasColumnName("idsanpham");

                entity.Property(e => e.Gia)
                    .HasColumnName("gia")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Gioithieu).HasColumnName("gioithieu");

                entity.Property(e => e.Idshop).HasColumnName("idshop");

                entity.Property(e => e.Linkhinhanh)
                    .HasColumnName("linkhinhanh")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenloai)
                    .HasColumnName("tenloai")
                    .HasMaxLength(50);

                entity.Property(e => e.Tensanpham)
                    .HasColumnName("tensanpham")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.Idshop)
                    .HasName("PK__shop__D048E4DAFE85B93C");

                entity.ToTable("shop");

                entity.Property(e => e.Idshop).HasColumnName("idshop");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasMaxLength(255);

                entity.Property(e => e.Gioithieu).HasColumnName("gioithieu");

                entity.Property(e => e.Idchusohuu).HasColumnName("idchusohuu");

                entity.Property(e => e.Instagram)
                    .HasColumnName("instagram")
                    .HasMaxLength(255);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaythanhlap)
                    .HasColumnName("ngaythanhlap")
                    .HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasColumnName("sdt")
                    .HasMaxLength(20);

                entity.Property(e => e.Tenshop)
                    .HasColumnName("tenshop")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Shopcart>(entity =>
            {
                entity.HasKey(e => e.Idshopcart)
                    .HasName("PK__shopcart__9EC0A4ADA8DC73CA");

                entity.ToTable("shopcart");

                entity.Property(e => e.Idshopcart).HasColumnName("idshopcart");

                entity.Property(e => e.Idnguoidung).HasColumnName("idnguoidung");

                entity.Property(e => e.Idsanpham).HasColumnName("idsanpham");

                entity.Property(e => e.Idshop).HasColumnName("idshop");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
