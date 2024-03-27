namespace ApiDevelopment.Models
{
    public class CatalogoProducto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public string TipoEstampado { get; set; }
        public string Color { get; set; }
        public int stock { get; set; }
        public string TamanoEstampado { get; set; }
        public string TipoCatalogo { get; set; }
        public string ImagenProducto { get; set; }
        public double Precio { get; set; }
        public int Estado { get; set; }
        public FichaTecnica IdFichaTecnica { get; set; }
    }
}
