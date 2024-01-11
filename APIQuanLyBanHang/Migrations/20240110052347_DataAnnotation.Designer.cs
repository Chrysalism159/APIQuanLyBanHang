﻿// <auto-generated />
using System;
using APIQuanLyBanHang.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIQuanLyBanHang.Migrations
{
    [DbContext(typeof(QlbdaTtsContext))]
    [Migration("20240110052347_DataAnnotation")]
    partial class DataAnnotation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIQuanLyBanHang.Model.Anh", b =>
                {
                    b.Property<string>("Idanh")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDAnh");

                    b.Property<string>("FileAnh")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenAnh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idanh");

                    b.ToTable("Anh", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.ChiNhanh", b =>
                {
                    b.Property<string>("IdchiNhanh")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDChiNhanh");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenChiNhanh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ĐiaChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdchiNhanh");

                    b.ToTable("ChiNhanh", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.ChiTietHoaDon", b =>
                {
                    b.Property<string>("IdchiTietHoaDon")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDChiTietHoaDon")
                        .HasColumnOrder(0);

                    b.Property<decimal?>("ChietKhau")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("Dongia")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdhoaDon")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDHoaDon")
                        .HasColumnOrder(1);

                    b.Property<string>("IdphieuNhapHang")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDPhieuNhapHang")
                        .HasColumnOrder(3);

                    b.Property<string>("IdsanPham")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDSanPham")
                        .HasColumnOrder(2);

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdchiTietHoaDon");

                    b.HasIndex("IdhoaDon");

                    b.HasIndex("IdphieuNhapHang");

                    b.HasIndex("IdsanPham");

                    b.ToTable("ChiTietHoaDon", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.HoaDon", b =>
                {
                    b.Property<string>("IdhoaDon")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDHoaDon")
                        .HasColumnOrder(0);

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdchiNhanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDChiNhanh")
                        .HasColumnOrder(1);

                    b.Property<string>("IdnhanVien")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDNhanVien")
                        .HasColumnOrder(2);

                    b.Property<string>("IdtheThanhVien")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDTheThanhVien")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("NgayLapHoaDon")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("SoTienKhachTra")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("TongTienSauChietKhau")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdhoaDon");

                    b.HasIndex("IdchiNhanh");

                    b.HasIndex("IdnhanVien");

                    b.HasIndex("IdtheThanhVien");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.LoaiThe", b =>
                {
                    b.Property<string>("IdloaiThe")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDLoaiThe");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HanMuc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenLoaiThe")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdloaiThe");

                    b.ToTable("LoaiThe", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.NhaCungCap", b =>
                {
                    b.Property<string>("IdnhaCungCap")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDNhaCungCap");

                    b.Property<int?>("DiaChi")
                        .HasColumnType("int");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sdt")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("SDT")
                        .IsFixedLength();

                    b.Property<decimal?>("SoTienDaThanhToan")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("SoTienNhapHang")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("TenNguoiDaiDien")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenNhaCungCap")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdnhaCungCap");

                    b.ToTable("NhaCungCap", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.NhanVien", b =>
                {
                    b.Property<string>("IdnhanVien")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDNhanVien")
                        .HasColumnOrder(0);

                    b.Property<string>("Cccd")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CCCD");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("IdchiNhanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDChiNhanh")
                        .HasColumnOrder(1);

                    b.Property<string>("IdtaiKhoan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDTaiKhoan")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("NgayBatDauLamViec")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<string>("Sdt")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SDT");

                    b.Property<string>("TenNhanVien")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ĐiaChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdnhanVien");

                    b.HasIndex("IdchiNhanh");

                    b.HasIndex("IdtaiKhoan");

                    b.ToTable("NhanVien", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.PhieuChiTieu", b =>
                {
                    b.Property<string>("IdphieuChi")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDPhieuChi")
                        .HasColumnOrder(0);

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdchiNhanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDChiNhanh")
                        .HasColumnOrder(2);

                    b.Property<string>("IdnhanVien")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDNhanVien")
                        .HasColumnOrder(1);

                    b.Property<decimal?>("SoTienChi")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("TenPhieuChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ThoiGianLapPhieu")
                        .HasColumnType("datetime");

                    b.HasKey("IdphieuChi");

                    b.HasIndex("IdchiNhanh");

                    b.HasIndex("IdnhanVien");

                    b.ToTable("PhieuChiTieu", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.PhieuNhapHang", b =>
                {
                    b.Property<string>("IdphieuNhapHang")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDPhieuNhapHang")
                        .HasColumnOrder(0);

                    b.Property<decimal?>("ChietKhau")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Idanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDAnh")
                        .HasColumnOrder(3);

                    b.Property<string>("IdchiNhanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDChiNhanh")
                        .HasColumnOrder(4);

                    b.Property<string>("IdnhaCungCap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDNhaCungCap")
                        .HasColumnOrder(2);

                    b.Property<string>("IdnhanVien")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDNhanVien")
                        .HasColumnOrder(1);

                    b.Property<string>("TenHangNhap")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ThoiGianLapHoaDon")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TongTienSauChietKhau")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("TongTienThanhToan")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdphieuNhapHang");

                    b.HasIndex("Idanh");

                    b.HasIndex("IdchiNhanh");

                    b.HasIndex("IdnhaCungCap");

                    b.HasIndex("IdnhanVien");

                    b.ToTable("PhieuNhapHang", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.SanPham", b =>
                {
                    b.Property<string>("IdsanPham")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDSanPham")
                        .HasColumnOrder(0);

                    b.Property<string>("DonVi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("GiaBan")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("GiaVon")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Idanh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDAnh")
                        .HasColumnOrder(1);

                    b.Property<int?>("SoLuongHienCo")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdsanPham");

                    b.HasIndex("Idanh");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.TaiKhoan", b =>
                {
                    b.Property<string>("IdtaiKhoan")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDTaiKhoan");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhanQuyen")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdtaiKhoan");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.TheThanhVien", b =>
                {
                    b.Property<string>("IdtheThanhVien")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDTheThanhVien")
                        .HasColumnOrder(0);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("IdloaiThe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IDLoaiThe")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<string>("Sdt")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SDT");

                    b.Property<double?>("SoDiemDaSuDung")
                        .HasColumnType("float");

                    b.Property<double?>("SoDiemTichLuy")
                        .HasColumnType("float");

                    b.Property<decimal?>("SoTienDaSuDung")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("SoTienDaTichLuy")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("TenKhachHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ĐiaChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdtheThanhVien");

                    b.HasIndex("IdloaiThe");

                    b.ToTable("TheThanhVien", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.ChiTietHoaDon", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.HoaDon", "IdhoaDonNavigation")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("IdhoaDon")
                        .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

                    b.HasOne("APIQuanLyBanHang.Model.PhieuNhapHang", "IdphieuNhapHangNavigation")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("IdphieuNhapHang")
                        .HasConstraintName("FK_ChiTietHoaDon_PhieuNhapHang");

                    b.HasOne("APIQuanLyBanHang.Model.SanPham", "IdsanPhamNavigation")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("IdsanPham")
                        .HasConstraintName("FK_ChiTietHoaDon_SanPham");

                    b.Navigation("IdhoaDonNavigation");

                    b.Navigation("IdphieuNhapHangNavigation");

                    b.Navigation("IdsanPhamNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.HoaDon", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.ChiNhanh", "IdchiNhanhNavigation")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdchiNhanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HoaDon_ChiNhanh");

                    b.HasOne("APIQuanLyBanHang.Model.NhanVien", "IdnhanVienNavigation")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdnhanVien")
                        .HasConstraintName("FK_HoaDon_NhanVien");

                    b.HasOne("APIQuanLyBanHang.Model.TheThanhVien", "IdtheThanhVienNavigation")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdtheThanhVien")
                        .HasConstraintName("FK_HoaDon_TheThanhVien");

                    b.Navigation("IdchiNhanhNavigation");

                    b.Navigation("IdnhanVienNavigation");

                    b.Navigation("IdtheThanhVienNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.NhanVien", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.ChiNhanh", "IdchiNhanhNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdchiNhanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_NhanVien_ChiNhanh");

                    b.HasOne("APIQuanLyBanHang.Model.TaiKhoan", "IdtaiKhoanNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdtaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_NhanVien_TaiKhoan");

                    b.Navigation("IdchiNhanhNavigation");

                    b.Navigation("IdtaiKhoanNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.PhieuChiTieu", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.ChiNhanh", "IdchiNhanhNavigation")
                        .WithMany("PhieuChiTieus")
                        .HasForeignKey("IdchiNhanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhieuChiTieu_ChiNhanh");

                    b.HasOne("APIQuanLyBanHang.Model.NhanVien", "IdnhanVienNavigation")
                        .WithMany("PhieuChiTieus")
                        .HasForeignKey("IdnhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhieuChiTieu_NhanVien");

                    b.Navigation("IdchiNhanhNavigation");

                    b.Navigation("IdnhanVienNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.PhieuNhapHang", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.Anh", "IdanhNavigation")
                        .WithMany("PhieuNhapHangs")
                        .HasForeignKey("Idanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhieuNhapHang_Anh");

                    b.HasOne("APIQuanLyBanHang.Model.ChiNhanh", "IdchiNhanhNavigation")
                        .WithMany("PhieuNhapHangs")
                        .HasForeignKey("IdchiNhanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhieuNhapHang_ChiNhanh");

                    b.HasOne("APIQuanLyBanHang.Model.NhaCungCap", "IdnhaCungCapNavigation")
                        .WithMany("PhieuNhapHangs")
                        .HasForeignKey("IdnhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhieuNhapHang_NhaCungCap");

                    b.HasOne("APIQuanLyBanHang.Model.NhanVien", "IdnhanVienNavigation")
                        .WithMany("PhieuNhapHangs")
                        .HasForeignKey("IdnhanVien")
                        .IsRequired()
                        .HasConstraintName("FK_PhieuNhapHang_NhanVien");

                    b.Navigation("IdanhNavigation");

                    b.Navigation("IdchiNhanhNavigation");

                    b.Navigation("IdnhaCungCapNavigation");

                    b.Navigation("IdnhanVienNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.SanPham", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.Anh", "IdanhNavigation")
                        .WithMany("SanPhams")
                        .HasForeignKey("Idanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SanPham_Anh");

                    b.Navigation("IdanhNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.TheThanhVien", b =>
                {
                    b.HasOne("APIQuanLyBanHang.Model.LoaiThe", "IdloaiTheNavigation")
                        .WithMany("TheThanhViens")
                        .HasForeignKey("IdloaiThe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TheThanhVien_LoaiThe");

                    b.Navigation("IdloaiTheNavigation");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.Anh", b =>
                {
                    b.Navigation("PhieuNhapHangs");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.ChiNhanh", b =>
                {
                    b.Navigation("HoaDons");

                    b.Navigation("NhanViens");

                    b.Navigation("PhieuChiTieus");

                    b.Navigation("PhieuNhapHangs");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.LoaiThe", b =>
                {
                    b.Navigation("TheThanhViens");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.NhaCungCap", b =>
                {
                    b.Navigation("PhieuNhapHangs");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.NhanVien", b =>
                {
                    b.Navigation("HoaDons");

                    b.Navigation("PhieuChiTieus");

                    b.Navigation("PhieuNhapHangs");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.PhieuNhapHang", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.SanPham", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.TaiKhoan", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("APIQuanLyBanHang.Model.TheThanhVien", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
