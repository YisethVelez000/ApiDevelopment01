namespace ApiDevelopment.Models
{
    public class FichaTecnica
    {
        public int Id { get; set; }
        public string NombreFichaTecnica { get; set; }
        public string Talla { get; set; }
        public string Imagen { get; set; }
        public string Color { get; set; }
        public bool EstadoFicha { get; set; }
    }
}
