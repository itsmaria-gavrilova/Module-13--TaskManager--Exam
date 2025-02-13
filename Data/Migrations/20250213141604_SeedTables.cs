using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager.Data.Migrations
{
    public partial class SeedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserID",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32b3bb9e-86af-4c1b-9dc1-cdb5425a01c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1beadd2-736c-4cce-a3e1-b8bba725b332");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "54f3067f-b159-40f0-a48e-aa1a18bf8ba5", 0, "05d137c1-70d1-4fb4-bc14-18eeb30c31db", null, false, false, null, null, "employee@mail.com", "AQAAAAEAACcQAAAAEDp2sYbXOHa1i55FSX7OOyaTDZTW9mQNH9Grwag1PN8n7g7bOcX/dSKqahI+BBno5g==", null, false, "f19aa4b1-9f45-45d1-a7b1-ceb7dc721f18", false, "employee@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4ec7487-3b43-479f-b367-871de98006ff", 0, "21f0a8ce-4dbd-46a9-8a90-9563c5fc8ebe", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEEUI8Z99o6YPMG9CDziNgK80CmR/9aR/+VnO83MS+gRTI68GigDTBMO2/AtyJimZ0g==", null, false, "61121ce4-c2b8-4734-b2da-eb878af73f37", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54f3067f-b159-40f0-a48e-aa1a18bf8ba5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4ec7487-3b43-479f-b367-871de98006ff");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32b3bb9e-86af-4c1b-9dc1-cdb5425a01c1", 0, "bb5309b0-0810-4f8f-a0fb-a63e0bb13305", null, false, false, null, null, "employee@mail.com", "AQAAAAEAACcQAAAAEH1MS4u5p1ZMWsTDeVMqQHrhElnPMOqf1yPnWy09Fhpf1399EU8FCrj1co68TNeM9g==", null, false, "8c66621f-2868-4078-a436-a63c0657cf9d", false, "employee@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d1beadd2-736c-4cce-a3e1-b8bba725b332", 0, "e19edf9e-98ae-40d7-9c76-a3d3fb31042c", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEGEva/iVoDHWEBU9PxQF3Kfhf1xbLlHvIK+GnXk02tD5fivvJ0i4K4yXBdzcEM5k2w==", null, false, "5c6beee3-2802-4d6d-b1bf-6d0864e02dd8", false, "admin@mail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserID",
                table: "Employees",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
