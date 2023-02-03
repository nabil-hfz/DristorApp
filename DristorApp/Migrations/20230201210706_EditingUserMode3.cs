using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DristorApp.Migrations
{
    /// <inheritdoc />
    public partial class EditingUserMode3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Coupons_CouponId",
                table: "OrderItems");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Coupons_CouponId",
                table: "OrderItems",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Coupons_CouponId",
                table: "OrderItems");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Coupons_CouponId",
                table: "OrderItems",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");
        }
    }
}
