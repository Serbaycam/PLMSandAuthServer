using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthIdentity.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addRoleToMasterAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc09da4-fc92-4288-b4ef-b44d635041fd", "AQAAAAIAAYagAAAAEChYQoScbUWU/2Wsgij6KqNHAeBH3nKZyzrWHeRGez4V3vYwpChc9WJB8VjeU6S2BQ==", "428ca025-58b3-416d-a9c7-dc63f469491b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd24c922-b01f-4abd-8e55-5883db3bdd84", "AQAAAAIAAYagAAAAEOMDKWiIuOfksUxvdJym3yTpIPShjyaocDbnXRii7VO90Uga8Z++KfT2u8GJwVbNWg==", "92a0f449-8d8c-4f1e-b8f3-67431ec7f6c8" });
        }
    }
}
