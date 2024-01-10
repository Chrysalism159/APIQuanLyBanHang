using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIQuanLyBanHang.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anh",
                columns: table => new
                {
                    IDAnh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileAnh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anh", x => x.IDAnh);
                });

            migrationBuilder.CreateTable(
                name: "ChiNhanh",
                columns: table => new
                {
                    IDChiNhanh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenChiNhanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ĐiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanh", x => x.IDChiNhanh);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThe",
                columns: table => new
                {
                    IDLoaiThe = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenLoaiThe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HanMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThe", x => x.IDLoaiThe);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    IDNhaCungCap = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenNguoiDaiDien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    DiaChi = table.Column<int>(type: "int", nullable: true),
                    SoTienNhapHang = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SoTienDaThanhToan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.IDNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    IDTaiKhoan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhanQuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.IDTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    IDSanPham = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDAnh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GiaBan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GiaVon = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuongHienCo = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.IDSanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_Anh",
                        column: x => x.IDAnh,
                        principalTable: "Anh",
                        principalColumn: "IDAnh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheThanhVien",
                columns: table => new
                {
                    IDTheThanhVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDLoaiThe = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDiemTichLuy = table.Column<double>(type: "float", nullable: true),
                    SoDiemDaSuDung = table.Column<double>(type: "float", nullable: true),
                    SoTienDaTichLuy = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SoTienDaSuDung = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    ĐiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheThanhVien", x => x.IDTheThanhVien);
                    table.ForeignKey(
                        name: "FK_TheThanhVien_LoaiThe",
                        column: x => x.IDLoaiThe,
                        principalTable: "LoaiThe",
                        principalColumn: "IDLoaiThe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDChiNhanh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDTaiKhoan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NgayBatDauLamViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    CCCD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ĐiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IDNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChiNhanh",
                        column: x => x.IDChiNhanh,
                        principalTable: "ChiNhanh",
                        principalColumn: "IDChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_TaiKhoan",
                        column: x => x.IDTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "IDTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    IDHoaDon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDChiNhanh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IDTheThanhVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NgayLapHoaDon = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoTienKhachTra = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TongTienSauChietKhau = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.IDHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_ChiNhanh",
                        column: x => x.IDChiNhanh,
                        principalTable: "ChiNhanh",
                        principalColumn: "IDChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien");
                    table.ForeignKey(
                        name: "FK_HoaDon_TheThanhVien",
                        column: x => x.IDTheThanhVien,
                        principalTable: "TheThanhVien",
                        principalColumn: "IDTheThanhVien");
                });

            migrationBuilder.CreateTable(
                name: "PhieuChiTieu",
                columns: table => new
                {
                    IDPhieuChi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDChiNhanh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenPhieuChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoTienChi = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThoiGianLapPhieu = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChiTieu", x => x.IDPhieuChi);
                    table.ForeignKey(
                        name: "FK_PhieuChiTieu_ChiNhanh",
                        column: x => x.IDChiNhanh,
                        principalTable: "ChiNhanh",
                        principalColumn: "IDChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuChiTieu_NhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapHang",
                columns: table => new
                {
                    IDPhieuNhapHang = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDNhaCungCap = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDAnh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDChiNhanh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenHangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TongTienSauChietKhau = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TongTienThanhToan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThoiGianLapHoaDon = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapHang", x => x.IDPhieuNhapHang);
                    table.ForeignKey(
                        name: "FK_PhieuNhapHang_Anh",
                        column: x => x.IDAnh,
                        principalTable: "Anh",
                        principalColumn: "IDAnh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuNhapHang_ChiNhanh",
                        column: x => x.IDChiNhanh,
                        principalTable: "ChiNhanh",
                        principalColumn: "IDChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuNhapHang_NhaCungCap",
                        column: x => x.IDNhaCungCap,
                        principalTable: "NhaCungCap",
                        principalColumn: "IDNhaCungCap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuNhapHang_NhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    IDChiTietHoaDon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDHoaDon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IDSanPham = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IDPhieuNhapHang = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    Dongia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.IDChiTietHoaDon);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon",
                        column: x => x.IDHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "IDHoaDon");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_PhieuNhapHang",
                        column: x => x.IDPhieuNhapHang,
                        principalTable: "PhieuNhapHang",
                        principalColumn: "IDPhieuNhapHang");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_SanPham",
                        column: x => x.IDSanPham,
                        principalTable: "SanPham",
                        principalColumn: "IDSanPham");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IDHoaDon",
                table: "ChiTietHoaDon",
                column: "IDHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IDPhieuNhapHang",
                table: "ChiTietHoaDon",
                column: "IDPhieuNhapHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IDSanPham",
                table: "ChiTietHoaDon",
                column: "IDSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDChiNhanh",
                table: "HoaDon",
                column: "IDChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDNhanVien",
                table: "HoaDon",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDTheThanhVien",
                table: "HoaDon",
                column: "IDTheThanhVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDChiNhanh",
                table: "NhanVien",
                column: "IDChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDTaiKhoan",
                table: "NhanVien",
                column: "IDTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiTieu_IDChiNhanh",
                table: "PhieuChiTieu",
                column: "IDChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChiTieu_IDNhanVien",
                table: "PhieuChiTieu",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapHang_IDAnh",
                table: "PhieuNhapHang",
                column: "IDAnh");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapHang_IDChiNhanh",
                table: "PhieuNhapHang",
                column: "IDChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapHang_IDNhaCungCap",
                table: "PhieuNhapHang",
                column: "IDNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapHang_IDNhanVien",
                table: "PhieuNhapHang",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDAnh",
                table: "SanPham",
                column: "IDAnh");

            migrationBuilder.CreateIndex(
                name: "IX_TheThanhVien_IDLoaiThe",
                table: "TheThanhVien",
                column: "IDLoaiThe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "PhieuChiTieu");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "PhieuNhapHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "TheThanhVien");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Anh");

            migrationBuilder.DropTable(
                name: "LoaiThe");

            migrationBuilder.DropTable(
                name: "ChiNhanh");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}
