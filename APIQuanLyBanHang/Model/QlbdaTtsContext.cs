using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.Model;

public partial class QlbdaTtsContext : DbContext
{
    public QlbdaTtsContext()
    {
    }

    public QlbdaTtsContext(DbContextOptions<QlbdaTtsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anh> Anhs { get; set; }

    public virtual DbSet<ChiNhanh> ChiNhanhs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<LoaiThe> LoaiThes { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuChiTieu> PhieuChiTieus { get; set; }

    public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamChiNhanh> SanPhamChiNhanhs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TheThanhVien> TheThanhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QLBDA_TTS;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anh>(entity =>
        {
            entity.HasKey(e => e.Idanh);

            entity.ToTable("Anh");

            entity.Property(e => e.Idanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDAnh");
            entity.Property(e => e.FileAnh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiNhanh>(entity =>
        {
            entity.HasKey(e => e.IdchiNhanh);

            entity.ToTable("ChiNhanh");

            entity.Property(e => e.IdchiNhanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiNhanh");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.TenChiNhanh).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.IdchiTietHoaDon);

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.IdchiTietHoaDon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiTietHoaDon");
            entity.Property(e => e.ChietKhau).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Dongia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.IdhoaDon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDHoaDon");
            entity.Property(e => e.IdphieuNhapHang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDPhieuNhapHang");
            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdhoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdhoaDon)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

            entity.HasOne(d => d.IdphieuNhapHangNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdphieuNhapHang)
                .HasConstraintName("FK_ChiTietHoaDon_PhieuNhapHang");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdsanPham)
                .HasConstraintName("FK_ChiTietHoaDon_SanPham");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdhoaDon);

            entity.ToTable("HoaDon");

            entity.Property(e => e.IdhoaDon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDHoaDon");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.IdchiNhanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiNhanh");
            entity.Property(e => e.IdnhanVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNhanVien");
            entity.Property(e => e.IdtheThanhVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDTheThanhVien");
            entity.Property(e => e.NgayLapHoaDon).HasColumnType("datetime");
            entity.Property(e => e.SoTienKhachTra).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TongTienSauChietKhau).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdchiNhanhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdchiNhanh)
                .HasConstraintName("FK_HoaDon_ChiNhanh");

            entity.HasOne(d => d.IdnhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdnhanVien)
                .HasConstraintName("FK_HoaDon_NhanVien");

            entity.HasOne(d => d.IdtheThanhVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdtheThanhVien)
                .HasConstraintName("FK_HoaDon_TheThanhVien");
        });

        modelBuilder.Entity<LoaiThe>(entity =>
        {
            entity.HasKey(e => e.IdloaiThe);

            entity.ToTable("LoaiThe");

            entity.Property(e => e.IdloaiThe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDLoaiThe");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.HanMuc).HasMaxLength(50);
            entity.Property(e => e.TenLoaiThe).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.IdnhaCungCap);

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.IdnhaCungCap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNhaCungCap");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.SoTienDaThanhToan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SoTienNhapHang).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenNguoiDaiDien).HasMaxLength(50);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdnhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.IdnhanVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNhanVien");
            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.IdchiNhanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiNhanh");
            entity.Property(e => e.IdtaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDTaiKhoan");
            entity.Property(e => e.NgayBatDauLamViec).HasColumnType("datetime");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
            entity.Property(e => e.ĐiaChi).HasMaxLength(50);

            entity.HasOne(d => d.IdchiNhanhNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdchiNhanh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_NhanVien_ChiNhanh");

            entity.HasOne(d => d.IdtaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdtaiKhoan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_NhanVien_TaiKhoan");
        });

        modelBuilder.Entity<PhieuChiTieu>(entity =>
        {
            entity.HasKey(e => e.IdphieuChi);

            entity.ToTable("PhieuChiTieu");

            entity.Property(e => e.IdphieuChi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDPhieuChi");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.IdchiNhanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiNhanh");
            entity.Property(e => e.IdnhanVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNhanVien");
            entity.Property(e => e.SoTienChi).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenPhieuChi).HasMaxLength(50);
            entity.Property(e => e.ThoiGianLapPhieu).HasColumnType("datetime");

            entity.HasOne(d => d.IdchiNhanhNavigation).WithMany(p => p.PhieuChiTieus)
                .HasForeignKey(d => d.IdchiNhanh)
                .HasConstraintName("FK_PhieuChiTieu_ChiNhanh");

            entity.HasOne(d => d.IdnhanVienNavigation).WithMany(p => p.PhieuChiTieus)
                .HasForeignKey(d => d.IdnhanVien)
                .HasConstraintName("FK_PhieuChiTieu_NhanVien");
        });

        modelBuilder.Entity<PhieuNhapHang>(entity =>
        {
            entity.HasKey(e => e.IdphieuNhapHang);

            entity.ToTable("PhieuNhapHang");

            entity.Property(e => e.IdphieuNhapHang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDPhieuNhapHang");
            entity.Property(e => e.ChietKhau).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.Idanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDAnh");
            entity.Property(e => e.IdchiNhanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiNhanh");
            entity.Property(e => e.IdnhaCungCap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNhaCungCap");
            entity.Property(e => e.IdnhanVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNhanVien");
            entity.Property(e => e.TenHangNhap).HasMaxLength(50);
            entity.Property(e => e.ThoiGianLapHoaDon).HasColumnType("datetime");
            entity.Property(e => e.TongTienSauChietKhau).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TongTienThanhToan).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdanhNavigation).WithMany(p => p.PhieuNhapHangs)
                .HasForeignKey(d => d.Idanh)
                .HasConstraintName("FK_PhieuNhapHang_Anh");

            entity.HasOne(d => d.IdchiNhanhNavigation).WithMany(p => p.PhieuNhapHangs)
                .HasForeignKey(d => d.IdchiNhanh)
                .HasConstraintName("FK_PhieuNhapHang_ChiNhanh");

            entity.HasOne(d => d.IdnhaCungCapNavigation).WithMany(p => p.PhieuNhapHangs)
                .HasForeignKey(d => d.IdnhaCungCap)
                .HasConstraintName("FK_PhieuNhapHang_NhaCungCap");

            entity.HasOne(d => d.IdnhanVienNavigation).WithMany(p => p.PhieuNhapHangs)
                .HasForeignKey(d => d.IdnhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuNhapHang_NhanVien");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdsanPham);

            entity.ToTable("SanPham");

            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.DonVi).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GiaVon).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Idanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDAnh");
            entity.Property(e => e.TenSanPham).HasMaxLength(50);

            entity.HasOne(d => d.IdanhNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.Idanh)
                .HasConstraintName("FK_SanPham_Anh");
        });

        modelBuilder.Entity<SanPhamChiNhanh>(entity =>
        {
            entity.HasKey(e => new { e.IdsanPham, e.IdchiNhanh });

            entity.ToTable("SanPhamChiNhanh");

            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.IdchiNhanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDChiNhanh");
            entity.Property(e => e.GhiChu).HasMaxLength(50);

            entity.HasOne(d => d.IdchiNhanhNavigation).WithMany(p => p.SanPhamChiNhanhs)
                .HasForeignKey(d => d.IdchiNhanh)
                .HasConstraintName("FK_SanPhamChiNhanh_ChiNhanh");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.SanPhamChiNhanhs)
                .HasForeignKey(d => d.IdsanPham)
                .HasConstraintName("FK_SanPhamChiNhanh_SanPham");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdtaiKhoan);

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.IdtaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDTaiKhoan");
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhanQuyen).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TheThanhVien>(entity =>
        {
            entity.HasKey(e => e.IdtheThanhVien);

            entity.ToTable("TheThanhVien");

            entity.Property(e => e.IdtheThanhVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDTheThanhVien");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.IdloaiThe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDLoaiThe");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.SoTienDaSuDung).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SoTienDaTichLuy).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
            entity.Property(e => e.ĐiaChi).HasMaxLength(50);

            entity.HasOne(d => d.IdloaiTheNavigation).WithMany(p => p.TheThanhViens)
                .HasForeignKey(d => d.IdloaiThe)
                .HasConstraintName("FK_TheThanhVien_LoaiThe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
