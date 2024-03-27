using ApiDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDevelopment.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estampado> Estampados { get; set; }
    
        public DbSet<ProductoTerminado> ProductosTerminados { get; set; }
        public DbSet<FichaTecnica> FichasTecnicas { get; set; }
        public DbSet<FichaTecnicaInsumos> FichasTecnicasInsumos { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<CatalogoProducto> catalogoProductos { get; set; }
        public DbSet<EstampadoProducto> EstampadoProductos { get; set; }
        public DbSet<FichaTecnicaInsumos> FichaTecnicaInsumos { get; set; }
        public DbSet<ProductoTerminado> ProductoTerminados { get; set; }
        public DbSet<OrdenProduccion> ordenProduccions { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<ComprasInsumo> ComprasInsumos { get; set; }
        public DbSet<DetalleOrdenProduccion> detalleOrdenProduccion { get; set; }
        public DbSet<Proveedores> proveedores { get; set;}

    }
}
