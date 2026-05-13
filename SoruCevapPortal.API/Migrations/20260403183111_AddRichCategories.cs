using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoruCevapPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRichCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");
            
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Yazılım dilleri, donanım, yapay zeka ve güncel teknolojiler.", "Teknoloji & Yazılım" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Üniversite, akademik kadro ve sınav hazırlıkları.", "Eğitim & Sınavlar" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "ParentCategoryId" },
                values: new object[] { "İş bulma, mülakatlar, CV hazırlama ve ofis yaşamı.", "Kariyer & İş Hayatı", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Sinema, müzik, edebiyat, oyunlar ve hobiler.", "Kültür & Sanat" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 5, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayata dair tavsiyeler, yemek mekanları, seyahat ve sohbet.", true, "Gündelik Yaşam", null },
                    { 6, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core, React, HTML/CSS projeleri.", true, "Web Geliştirme", 1 },
                    { 7, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#, Delphi, Flutter, React Native.", true, "Masaüstü & Mobil", 1 },
                    { 8, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Server, MySQL, PostgreSQL.", true, "Veritabanı Yönetimi", 1 },
                    { 9, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "DGS hazırlık süreci, kontenjanlar ve mühendislik geçişleri.", true, "DGS (Dikey Geçiş Sınavı)", 2 },
                    { 10, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yurtdışı staj, dil sınavları ve Avrupa'da eğitim.", true, "Erasmus & Yurtdışı", 2 },
                    { 11, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite dersleri, proje ödevleri ve sunumlar.", true, "Vize & Final Haftası", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Programlama dilleri ve mimariler.", "Yazılım" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Bilgisayar parçaları ve donanım sorunları.", "Donanım" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "ParentCategoryId" },
                values: new object[] { "ASP.NET, React, HTML gibi teknolojiler.", "Web Geliştirme", 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Yazılım dışı, hayata dair sorular.", "Gündelik" });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
