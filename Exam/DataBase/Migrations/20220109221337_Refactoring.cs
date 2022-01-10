using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_AttackModifier_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_AttackPerRound_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_Damage_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_DamageModifier_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_HitPoints_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_Weapon_Range",
                table: "Monsters");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_AttackModifier_Range",
                table: "Monsters",
                sql: "\"AttackModifier\" >= 0 AND \"AttackModifier\" <= 300");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_AttackPerRound_Range",
                table: "Monsters",
                sql: "\"AttackPerRound\" >= 0 AND \"AttackPerRound\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_Damage_Range",
                table: "Monsters",
                sql: "\"Damage\" >= 0 AND \"Damage\" <= 500");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_DamageModifier_Range",
                table: "Monsters",
                sql: "\"DamageModifier\" >= 0 AND \"DamageModifier\" <= 300");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_HitPoints_Range",
                table: "Monsters",
                sql: "\"HitPoints\" >= 0 AND \"HitPoints\" <= 500");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_Weapon_Range",
                table: "Monsters",
                sql: "\"Weapon\" >= 0 AND \"Weapon\" <= 300");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_AttackModifier_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_AttackPerRound_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_Damage_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_DamageModifier_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_HitPoints_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_Weapon_Range",
                table: "Monsters");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_AttackModifier_Range",
                table: "Monsters",
                sql: "\"AttackModifier\" >= 0 AND \"AttackModifier\" <= 2147483647");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_AttackPerRound_Range",
                table: "Monsters",
                sql: "\"AttackPerRound\" >= 0 AND \"AttackPerRound\" <= 2147483647");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_Damage_Range",
                table: "Monsters",
                sql: "\"Damage\" >= 0 AND \"Damage\" <= 2147483647");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_DamageModifier_Range",
                table: "Monsters",
                sql: "\"DamageModifier\" >= 0 AND \"DamageModifier\" <= 2147483647");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_HitPoints_Range",
                table: "Monsters",
                sql: "\"HitPoints\" >= 0 AND \"HitPoints\" <= 2147483647");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_Weapon_Range",
                table: "Monsters",
                sql: "\"Weapon\" >= 0 AND \"Weapon\" <= 2147483647");
        }
    }
}
