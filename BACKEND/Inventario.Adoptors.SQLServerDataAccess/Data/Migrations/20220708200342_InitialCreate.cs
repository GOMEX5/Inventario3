using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventario.Adoptors.SQLServerDataAccess.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_Laboratorios",
                columns: table => new
                {
                    lab_id = table.Column<Guid>(nullable: false),
                    num_pc = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Laboratorios", x => x.lab_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_repuestos",
                columns: table => new
                {
                    repuesto_id = table.Column<Guid>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    serie = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    cantidad = table.Column<int>(nullable: false),
                    info = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_repuestos", x => x.repuesto_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuarios",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    cargo = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuarios", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pc",
                columns: table => new
                {
                    pc_id = table.Column<Guid>(nullable: false),
                    modelo = table.Column<string>(nullable: true),
                    lab_id1 = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pc", x => x.pc_id);
                    table.ForeignKey(
                        name: "FK_tb_pc_tab_Laboratorios_lab_id1",
                        column: x => x.lab_id1,
                        principalTable: "tab_Laboratorios",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_herramientas",
                columns: table => new
                {
                    herramienta_id = table.Column<Guid>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    cantidad = table.Column<int>(nullable: false),
                    usuariosuser_id = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_herramientas", x => x.herramienta_id);
                    table.ForeignKey(
                        name: "FK_tb_herramientas_tb_Usuarios_usuariosuser_id",
                        column: x => x.usuariosuser_id,
                        principalTable: "tb_Usuarios",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_mantenimiento",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    lab_id = table.Column<Guid>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mantenimiento", x => new { x.user_id, x.lab_id });
                    table.ForeignKey(
                        name: "FK_tb_mantenimiento_tab_Laboratorios_lab_id",
                        column: x => x.lab_id,
                        principalTable: "tab_Laboratorios",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_mantenimiento_tb_Usuarios_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_Usuarios",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_componentes",
                columns: table => new
                {
                    componenete_id = table.Column<Guid>(nullable: false),
                    tipo = table.Column<string>(nullable: true),
                    marca = table.Column<string>(nullable: true),
                    modelo = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    pc_id = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_componentes", x => x.componenete_id);
                    table.ForeignKey(
                        name: "FK_tb_componentes_tb_pc_pc_id",
                        column: x => x.pc_id,
                        principalTable: "tb_pc",
                        principalColumn: "pc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_diagnostico_pc",
                columns: table => new
                {
                    diagnostico_pc_id = table.Column<Guid>(nullable: false),
                    pc_id = table.Column<Guid>(nullable: true),
                    detalle = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    fecha_hora = table.Column<DateTime>(nullable: false),
                    soluccion_asignada = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_diagnostico_pc", x => x.diagnostico_pc_id);
                    table.ForeignKey(
                        name: "FK_tb_diagnostico_pc_tb_pc_pc_id",
                        column: x => x.pc_id,
                        principalTable: "tb_pc",
                        principalColumn: "pc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_componentes_pc_id",
                table: "tb_componentes",
                column: "pc_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_diagnostico_pc_pc_id",
                table: "tb_diagnostico_pc",
                column: "pc_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_herramientas_usuariosuser_id",
                table: "tb_herramientas",
                column: "usuariosuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_mantenimiento_lab_id",
                table: "tb_mantenimiento",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pc_lab_id1",
                table: "tb_pc",
                column: "lab_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_componentes");

            migrationBuilder.DropTable(
                name: "tb_diagnostico_pc");

            migrationBuilder.DropTable(
                name: "tb_herramientas");

            migrationBuilder.DropTable(
                name: "tb_mantenimiento");

            migrationBuilder.DropTable(
                name: "tb_repuestos");

            migrationBuilder.DropTable(
                name: "tb_pc");

            migrationBuilder.DropTable(
                name: "tb_Usuarios");

            migrationBuilder.DropTable(
                name: "tab_Laboratorios");
        }
    }
}
