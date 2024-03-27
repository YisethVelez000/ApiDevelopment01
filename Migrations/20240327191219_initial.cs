using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDevelopment.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estampados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstampado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionEstampado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEstampado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estampados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichasTecnicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFichaTecnica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Talla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoFicha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasTecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInsumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockInsumo = table.Column<int>(type: "int", nullable: false),
                    Cantidadinsumo = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IVA = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    EstadoInsumo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordenProduccions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroOrdenProduccion = table.Column<int>(type: "int", nullable: false),
                    FechaEstimada = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenProduccions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalogoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoEstampado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: false),
                    TamanoEstampado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCatalogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdFichaTecnicaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogoProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catalogoProductos_FichasTecnicas_IdFichaTecnicaId",
                        column: x => x.IdFichaTecnicaId,
                        principalTable: "FichasTecnicas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FichaTecnicaInsumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFichaTecnicaId = table.Column<int>(type: "int", nullable: true),
                    IdInsumosId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnicaInsumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaTecnicaInsumos_FichasTecnicas_IdFichaTecnicaId",
                        column: x => x.IdFichaTecnicaId,
                        principalTable: "FichasTecnicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FichaTecnicaInsumos_Insumos_IdInsumosId",
                        column: x => x.IdInsumosId,
                        principalTable: "Insumos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "detalleOrdenProduccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdenProduccionId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleOrdenProduccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleOrdenProduccion_ordenProduccions_IdOrdenProduccionId",
                        column: x => x.IdOrdenProduccionId,
                        principalTable: "ordenProduccions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    NombreInsumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recibo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IVA = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idProveedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compras_proveedores_idProveedorId",
                        column: x => x.idProveedorId,
                        principalTable: "proveedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idRolId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_idRolId",
                        column: x => x.idRolId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstampadoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEstampadoId = table.Column<int>(type: "int", nullable: true),
                    IdCatalogoProductoId = table.Column<int>(type: "int", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstampadoProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstampadoProductos_Estampados_idEstampadoId",
                        column: x => x.idEstampadoId,
                        principalTable: "Estampados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstampadoProductos_catalogoProductos_IdCatalogoProductoId",
                        column: x => x.IdCatalogoProductoId,
                        principalTable: "catalogoProductos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoTerminado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFichaTecnicaId = table.Column<int>(type: "int", nullable: true),
                    EstampadoId = table.Column<int>(type: "int", nullable: true),
                    tipoEstampadoId = table.Column<int>(type: "int", nullable: true),
                    DetalleOrdenProduccionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTerminado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoTerminado_Estampados_EstampadoId",
                        column: x => x.EstampadoId,
                        principalTable: "Estampados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoTerminado_Estampados_tipoEstampadoId",
                        column: x => x.tipoEstampadoId,
                        principalTable: "Estampados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoTerminado_FichasTecnicas_IdFichaTecnicaId",
                        column: x => x.IdFichaTecnicaId,
                        principalTable: "FichasTecnicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoTerminado_detalleOrdenProduccion_DetalleOrdenProduccionId",
                        column: x => x.DetalleOrdenProduccionId,
                        principalTable: "detalleOrdenProduccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComprasInsumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInsumoId = table.Column<int>(type: "int", nullable: true),
                    IdCompraId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    IVA = table.Column<double>(type: "float", nullable: false),
                    FechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasInsumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasInsumos_Insumos_IdInsumoId",
                        column: x => x.IdInsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComprasInsumos_compras_IdCompraId",
                        column: x => x.IdCompraId,
                        principalTable: "compras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_IdUsuarioId",
                        column: x => x.IdUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFinalizacion = table.Column<DateOnly>(type: "date", nullable: false),
                    IdRolId = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_IdRolId",
                        column: x => x.IdRolId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_IdUsuarioId",
                        column: x => x.IdUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClienteId = table.Column<int>(type: "int", nullable: true),
                    TotalPedido = table.Column<double>(type: "float", nullable: false),
                    DireccionEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaEntrega = table.Column<DateOnly>(type: "date", nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    EstadoPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Clientes_IdClienteId",
                        column: x => x.IdClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClienteId = table.Column<int>(type: "int", nullable: true),
                    IdPedidoId = table.Column<int>(type: "int", nullable: true),
                    FechaVenta = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalVenta = table.Column<double>(type: "float", nullable: false),
                    EstadoVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_IdClienteId",
                        column: x => x.IdClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Pedido_IdPedidoId",
                        column: x => x.IdPedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_catalogoProductos_IdFichaTecnicaId",
                table: "catalogoProductos",
                column: "IdFichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdUsuarioId",
                table: "Clientes",
                column: "IdUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_compras_idProveedorId",
                table: "compras",
                column: "idProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasInsumos_IdCompraId",
                table: "ComprasInsumos",
                column: "IdCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasInsumos_IdInsumoId",
                table: "ComprasInsumos",
                column: "IdInsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleOrdenProduccion_IdOrdenProduccionId",
                table: "detalleOrdenProduccion",
                column: "IdOrdenProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdRolId",
                table: "Empleados",
                column: "IdRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdUsuarioId",
                table: "Empleados",
                column: "IdUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstampadoProductos_IdCatalogoProductoId",
                table: "EstampadoProductos",
                column: "IdCatalogoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstampadoProductos_idEstampadoId",
                table: "EstampadoProductos",
                column: "idEstampadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnicaInsumos_IdFichaTecnicaId",
                table: "FichaTecnicaInsumos",
                column: "IdFichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnicaInsumos_IdInsumosId",
                table: "FichaTecnicaInsumos",
                column: "IdInsumosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdClienteId",
                table: "Pedido",
                column: "IdClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTerminado_DetalleOrdenProduccionId",
                table: "ProductoTerminado",
                column: "DetalleOrdenProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTerminado_EstampadoId",
                table: "ProductoTerminado",
                column: "EstampadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTerminado_IdFichaTecnicaId",
                table: "ProductoTerminado",
                column: "IdFichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTerminado_tipoEstampadoId",
                table: "ProductoTerminado",
                column: "tipoEstampadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idRolId",
                table: "Usuarios",
                column: "idRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdClienteId",
                table: "Ventas",
                column: "IdClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdPedidoId",
                table: "Ventas",
                column: "IdPedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasInsumos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "EstampadoProductos");

            migrationBuilder.DropTable(
                name: "FichaTecnicaInsumos");

            migrationBuilder.DropTable(
                name: "ProductoTerminado");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "catalogoProductos");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Estampados");

            migrationBuilder.DropTable(
                name: "detalleOrdenProduccion");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "FichasTecnicas");

            migrationBuilder.DropTable(
                name: "ordenProduccions");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
