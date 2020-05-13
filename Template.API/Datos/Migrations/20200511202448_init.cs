using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clienteid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProductos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoID = table.Column<int>(nullable: false),
                    carritoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProductos", x => x.id);
                    table.ForeignKey(
                        name: "FK_CarritoProductos_Carritos_carritoID",
                        column: x => x.carritoID,
                        principalTable: "Carritos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProductos_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carritoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ventas_Carritos_carritoId",
                        column: x => x.carritoId,
                        principalTable: "Carritos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_carritoID",
                table: "CarritoProductos",
                column: "carritoID");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_productoID",
                table: "CarritoProductos",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_Clienteid",
                table: "Carritos",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_carritoId",
                table: "Ventas",
                column: "carritoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProductos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
