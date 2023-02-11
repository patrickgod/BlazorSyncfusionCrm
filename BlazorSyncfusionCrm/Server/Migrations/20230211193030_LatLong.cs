using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorSyncfusionCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class LatLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Contacts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Contacts",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 2, 11, 20, 30, 29, 943, DateTimeKind.Local).AddTicks(4206), null, null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 2, 11, 20, 30, 29, 943, DateTimeKind.Local).AddTicks(4264), null, null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 2, 11, 20, 30, 29, 943, DateTimeKind.Local).AddTicks(4267), null, null });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 11, 20, 30, 29, 943, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 11, 20, 30, 29, 943, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 11, 20, 30, 29, 943, DateTimeKind.Local).AddTicks(4395));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 10, 21, 33, 11, 294, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 10, 21, 33, 11, 294, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 10, 21, 33, 11, 294, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 10, 21, 33, 11, 294, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 10, 21, 33, 11, 294, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 10, 21, 33, 11, 294, DateTimeKind.Local).AddTicks(6678));
        }
    }
}
