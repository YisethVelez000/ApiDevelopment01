namespace ApiDevelopment.Models
{
    public class EstampadoProducto
    {
        public int Id { get; set; }
        public Estampado idEstampado { get; set; }
        public CatalogoProducto IdCatalogoProducto { get; set; }
        public string Ubicacion { get; set; }
        public double Precio { get; set; }
    }
}
