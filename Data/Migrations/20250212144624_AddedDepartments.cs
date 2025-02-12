using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager.Data.Migrations
{
    public partial class AddedDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "082cde8e-af01-4658-8dd4-b07462736b33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a382d7ed-c46c-4a98-9abe-6942638bf177");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "32b3bb9e-86af-4c1b-9dc1-cdb5425a01c1", 0, "bb5309b0-0810-4f8f-a0fb-a63e0bb13305", null, false, false, null, null, "employee@mail.com", "AQAAAAEAACcQAAAAEH1MS4u5p1ZMWsTDeVMqQHrhElnPMOqf1yPnWy09Fhpf1399EU8FCrj1co68TNeM9g==", null, false, "8c66621f-2868-4078-a436-a63c0657cf9d", false, "employee@mail.com" },
                    { "d1beadd2-736c-4cce-a3e1-b8bba725b332", 0, "e19edf9e-98ae-40d7-9c76-a3d3fb31042c", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEGEva/iVoDHWEBU9PxQF3Kfhf1xbLlHvIK+GnXk02tD5fivvJ0i4K4yXBdzcEM5k2w==", null, false, "5c6beee3-2802-4d6d-b1bf-6d0864e02dd8", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Software" },
                    { 2, "Hardware" },
                    { 3, "Engineering" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32b3bb9e-86af-4c1b-9dc1-cdb5425a01c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1beadd2-736c-4cce-a3e1-b8bba725b332");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "082cde8e-af01-4658-8dd4-b07462736b33", 0, "e768d1ba-1ba2-4c7f-98cc-5f0b91c68862", null, false, false, null, null, "employee@mail.com", "AQAAAAEAACcQAAAAEFC0pGSqlHIcfhzIP1nVWUBAkssNxZegDCv6jQw3yygHzFCQkQr4/yhHdervUMu/2w==", null, false, "da5113b9-63f6-431b-9f51-420f5d25bbff", false, "employee@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a382d7ed-c46c-4a98-9abe-6942638bf177", 0, "b5e68a24-bd88-4175-b3ce-58b2e5fe6aea", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEPv7Cw40lCYEiKjNQut4RIAM/a5e//PBSSuLAzjBBfn2joUM0MyZ7c2gG60JGNA2Gg==", null, false, "205bd372-e2e0-4747-bb8f-069c608aa786", false, "admin@mail.com" });
        }
    }
}
