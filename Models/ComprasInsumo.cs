namespace ApiDevelopment.Models
{
    public class ComprasInsumo
    {
        public int Id { get; set; }
        public Insumos IdInsumo { get; set; }
        public Compra IdCompra { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }
        public double IVA { get; set; }
        public string FechaCompra { get; set; }
        
    }
}
