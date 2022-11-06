using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _NET_Office_Management_BackEnd.Migrations
{
    public partial class Tablecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    unit = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    count = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_login = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    is_superuser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    date_joined = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    supervisor_id = table.Column<int>(type: "int(11)", nullable: true),
                    can_approve_inventory = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_distribute_inventory = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_approve_leave = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_manage_asset = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "user_supervisor_id_479813ed_fk_user_id",
                        column: x => x.supervisor_id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    serial = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    purchase_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    warranty = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false),
                    status = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    next_user_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset", x => x.id);
                    table.ForeignKey(
                        name: "asset_next_user_id_0451c2dc_fk_user_id",
                        column: x => x.next_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "asset_user_id_54771fbb_fk_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "leave",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creation_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    approved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    approve_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    day_count = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    comment = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    approver_id = table.Column<int>(type: "int(11)", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave", x => x.id);
                    table.ForeignKey(
                        name: "leave_approver_id_7c2c50d7_fk_user_id",
                        column: x => x.approver_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "leave_user_id_b4b01ea9_fk_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "requisition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    approved = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    comment = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    approver_id = table.Column<int>(type: "int(11)", nullable: false),
                    inventory_id = table.Column<int>(type: "int(11)", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    distributed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    distributor_id = table.Column<int>(type: "int(11)", nullable: true),
                    approve_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    distribution_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    request_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisition", x => x.id);
                    table.ForeignKey(
                        name: "requisition_approver_id_46fa8cdf_fk_user_id",
                        column: x => x.approver_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "requisition_distributor_id_4f5e5642_fk_user_id",
                        column: x => x.distributor_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "requisition_inventory_id_115ab4a2_fk_inventory",
                        column: x => x.inventory_id,
                        principalTable: "inventory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "requisition_user_id_c6cdb914_fk_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "assethistory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creation_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    asset_id = table.Column<long>(type: "bigint(20)", nullable: false),
                    from_user_id = table.Column<int>(type: "int(11)", nullable: false),
                    to_user_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assethistory", x => x.id);
                    table.ForeignKey(
                        name: "assethistory_asset_id_3b133b1f_fk",
                        column: x => x.asset_id,
                        principalTable: "asset",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "assethistory_fromUser_id_59c10a11_fk_user_id",
                        column: x => x.from_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "assethistory_toUser_id_c48abf98_fk_user_id",
                        column: x => x.to_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "asset_next_user_id_0451c2dc_fk_user_id",
                table: "asset",
                column: "next_user_id");

            migrationBuilder.CreateIndex(
                name: "asset_user_id_54771fbb_fk_user_id",
                table: "asset",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "assethistory_asset_id_3b133b1f_fk",
                table: "assethistory",
                column: "asset_id");

            migrationBuilder.CreateIndex(
                name: "assethistory_fromUser_id_59c10a11_fk_user_id",
                table: "assethistory",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "assethistory_toUser_id_c48abf98_fk_user_id",
                table: "assethistory",
                column: "to_user_id");

            migrationBuilder.CreateIndex(
                name: "name",
                table: "inventory",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "leave_approver_id_7c2c50d7_fk_user_id",
                table: "leave",
                column: "approver_id");

            migrationBuilder.CreateIndex(
                name: "leave_user_id_b4b01ea9_fk_user_id",
                table: "leave",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "requisition_approver_id_46fa8cdf_fk_user_id",
                table: "requisition",
                column: "approver_id");

            migrationBuilder.CreateIndex(
                name: "requisition_distributor_id_4f5e5642_fk_user_id",
                table: "requisition",
                column: "distributor_id");

            migrationBuilder.CreateIndex(
                name: "requisition_inventory_id_115ab4a2_fk_inventory",
                table: "requisition",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "requisition_user_id_c6cdb914_fk_user_id",
                table: "requisition",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_supervisor_id_479813ed_fk_user_id",
                table: "user",
                column: "supervisor_id");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "user",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assethistory");

            migrationBuilder.DropTable(
                name: "leave");

            migrationBuilder.DropTable(
                name: "requisition");

            migrationBuilder.DropTable(
                name: "asset");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
