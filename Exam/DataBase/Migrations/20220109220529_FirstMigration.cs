using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBase.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(500)", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifier = table.Column<int>(type: "integer", nullable: false),
                    AttackPerRound = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false),
                    Weapon = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.CheckConstraint("CK_Monsters_ArmorClass_Range", "\"ArmorClass\" >= 0 AND \"ArmorClass\" <= 100");
                    table.CheckConstraint("CK_Monsters_AttackModifier_Range", "\"AttackModifier\" >= 0 AND \"AttackModifier\" <= 2147483647");
                    table.CheckConstraint("CK_Monsters_AttackPerRound_Range", "\"AttackPerRound\" >= 0 AND \"AttackPerRound\" <= 2147483647");
                    table.CheckConstraint("CK_Monsters_Damage_Range", "\"Damage\" >= 0 AND \"Damage\" <= 2147483647");
                    table.CheckConstraint("CK_Monsters_DamageModifier_Range", "\"DamageModifier\" >= 0 AND \"DamageModifier\" <= 2147483647");
                    table.CheckConstraint("CK_Monsters_HitPoints_Range", "\"HitPoints\" >= 0 AND \"HitPoints\" <= 2147483647");
                    table.CheckConstraint("CK_Monsters_Weapon_Range", "\"Weapon\" >= 0 AND \"Weapon\" <= 2147483647");
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "HitPoints", "Name", "Weapon" },
                values: new object[,]
                {
                    { 1, 15, 3, 1, 23, 6, 92, "Tree Blight", 9 },
                    { 2, 12, 2, 1, 6, 2, 58, "Banshee", 12 },
                    { 3, 15, 2, 1, 14, 21, 45, "Hell Hound", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
