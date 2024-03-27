namespace ApiDevelopment.Models
{
    public class FichaTecnicaInsumos
    {
        public int Id { get; set; }
        public FichaTecnica IdFichaTecnica { get; set; }
        public Insumos IdInsumos { get; set; }
        public double Cantidad { get; set; }
    }
}
