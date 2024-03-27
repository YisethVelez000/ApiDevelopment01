namespace ApiDevelopment.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public string NombreInsumo { get; set; }
        public string Recibo { get; set; }
        public double IVA { get; set; }
        public string Total { get; set; }
        public Proveedores idProveedor { get; set; }



    }
}
