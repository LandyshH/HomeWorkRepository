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
                    NumberOfThrows = table.Column<int>(type: "integer", nullable: false),
                    EdgeCount = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false),
                    Weapon = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.CheckConstraint("CK_Monsters_ArmorClass_Range", "\"ArmorClass\" >= 0 AND \"ArmorClass\" <= 100");
                    table.CheckConstraint("CK_Monsters_AttackModifier_Range", "\"AttackModifier\" >= 0 AND \"AttackModifier\" <= 300");
                    table.CheckConstraint("CK_Monsters_AttackPerRound_Range", "\"AttackPerRound\" >= 0 AND \"AttackPerRound\" <= 100");
                    table.CheckConstraint("CK_Monsters_DamageModifier_Range", "\"DamageModifier\" >= 0 AND \"DamageModifier\" <= 300");
                    table.CheckConstraint("CK_Monsters_EdgeCount_Range", "\"EdgeCount\" >= 0 AND \"EdgeCount\" <= 20");
                    table.CheckConstraint("CK_Monsters_HitPoints_Range", "\"HitPoints\" >= 0 AND \"HitPoints\" <= 500");
                    table.CheckConstraint("CK_Monsters_NumberOfThrows_Range", "\"NumberOfThrows\" >= 0 AND \"NumberOfThrows\" <= 10");
                    table.CheckConstraint("CK_Monsters_Weapon_Range", "\"Weapon\" >= 0 AND \"Weapon\" <= 300");
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackPerRound", "DamageModifier", "EdgeCount", "HitPoints", "Name", "NumberOfThrows", "Weapon" },
                values: new object[,]
                {
                    { 1, 15, 3, 2, 6, 8, 92, "Tree Blight", 1, 9 },
                    { 2, 12, 2, 1, 2, 8, 58, "Banshee", 1, 12 },
                    { 3, 15, 2, 1, 21, 6, 45, "Hell Hound", 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
