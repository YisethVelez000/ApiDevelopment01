namespace ApiDevelopment.Models
{
    public class OrdenProduccion
    {
        public int Id { get; set; }
        public int NumeroOrdenProduccion { get; set; }
        public DateOnly FechaEstimada { get; set; }
        public enum EstadoOrdenProduccion
        {
            EnProceso,
            Finalizado
        }
        
    }
}
