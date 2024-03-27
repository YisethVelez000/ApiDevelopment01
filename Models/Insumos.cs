namespace ApiDevelopment.Models
{
    public class Insumos
    {
        public int Id { get; set; }
        public string NombreInsumo { get; set; }
        public int StockInsumo { get; set; }
        public int Cantidadinsumo { get; set; }
        public string UnidadMedida { get; set; }
        public int IVA { get; set; }
        public double Precio { get; set; }
        public bool EstadoInsumo { get; set; }
    }
}
