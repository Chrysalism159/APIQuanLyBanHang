using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIQuanLyBanHang.Migrations.QlbdaTts
{
    /// <inheritdoc />
    public partial class tblSanPhamChiNhanhs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "SanPhamChiNhanhs",
                columns: table => new
                {
                    IdsanPham = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdchiNhanh = table.Column<string>(type: "varchar(50)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiNhanhs", x => new { x.IdchiNhanh, x.IdsanPham });
                    table.ForeignKey(
                        name: "FK_SanPhamChiNhanhs_ChiNhanh_IdchiNhanh",
                        column: x => x.IdchiNhanh,
                        principalTable: "ChiNhanh",
                        principalColumn: "IDChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiNhanhs_SanPham_IdsanPham",
                        column: x => x.IdsanPham,
                        principalTable: "SanPham",
                        principalColumn: "IDSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiNhanhs_IdsanPham",
                table: "SanPhamChiNhanhs",
                column: "IdsanPham");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "SanPhamChiNhanhs");

        }
    }
}
