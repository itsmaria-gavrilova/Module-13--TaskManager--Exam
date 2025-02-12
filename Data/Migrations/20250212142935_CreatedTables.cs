using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "082cde8e-af01-4658-8dd4-b07462736b33", 0, "e768d1ba-1ba2-4c7f-98cc-5f0b91c68862", null, false, false, null, null, "employee@mail.com", "AQAAAAEAACcQAAAAEFC0pGSqlHIcfhzIP1nVWUBAkssNxZegDCv6jQw3yygHzFCQkQr4/yhHdervUMu/2w==", null, false, "da5113b9-63f6-431b-9f51-420f5d25bbff", false, "employee@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a382d7ed-c46c-4a98-9abe-6942638bf177", 0, "b5e68a24-bd88-4175-b3ce-58b2e5fe6aea", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEPv7Cw40lCYEiKjNQut4RIAM/a5e//PBSSuLAzjBBfn2joUM0MyZ7c2gG60JGNA2Gg==", null, false, "205bd372-e2e0-4747-bb8f-069c608aa786", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "082cde8e-af01-4658-8dd4-b07462736b33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a382d7ed-c46c-4a98-9abe-6942638bf177");
        }
    }
}
