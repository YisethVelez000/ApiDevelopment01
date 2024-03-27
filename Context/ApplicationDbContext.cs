using Microsoft.EntityFrameworkCore;

namespace ApiDevelopment.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Models.Rol> Roles { get; set; }
        public DbSet<Models.Usuario> Usuarios { get; set; }
        public DbSet<Models.Cliente> Clientes { get; set; }
        public DbSet<Models.Empleado> Empleados { get; set; }
        public DbSet<Models.Estampado> Estampados { get; set; }
    
        public DbSet<Models.ProductoTerminado> ProductosTerminados { get; set; }
        public DbSet<Models.FichaTecnica> FichasTecnicas { get; set; }
        public DbSet<Models.FichaTecnicaInsumos> FichasTecnicasInsumos { get; set; }
        public DbSet<Models.Insumos> Insumos { get; set; }
        
        public DbSet<Models.Venta> Ventas { get; set; }
        public DbSet<Models.CatalogoProducto> catalogoProductos { get; set; }
        public DbSet<Models.EstampadoProducto> EstampadoProductos { get; set; }
        public DbSet<Models.FichaTecnicaInsumos> FichaTecnicaInsumos { get; set; }
        public DbSet<Models.ProductoTerminado> ProductoTerminados { get; set; }
        public DbSet<Models.OrdenProduccion> ordenProduccions { get; set; }
        public DbSet<Models.Pedido> Pedido { get; set; }
        public DbSet<Models.Compra> compras { get; set; }
        public DbSet<Models.ComprasInsumo> ComprasInsumos { get; set; }
        public DbSet<Models.DetalleOrdenProduccion> detalleOrdenProduccion { get; set; }
        public DbSet<Models.Proveedores> proveedores { get; set;}

    }
}
