namespace ApiDevelopment.Models
{
    public class ProductoTerminado
    {
        public int Id { get; set; }
        public FichaTecnica IdFichaTecnica { get; set; }
        public Estampado Estampado { get; set; }
        public Estampado tipoEstampado { get; set; }
    }
}
