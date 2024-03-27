namespace ApiDevelopment.Models
{
    public class DetalleOrdenProduccion
    {
        public int Id { get; set; }
        public OrdenProduccion IdOrdenProduccion { get; set; }
        public enum Talla
        {
            S,
            M,
            L,
            XL,
            XXL
        }
        public int Cantidad { get; set; }
        public enum Color
        {
            Blanco,
            Rojo,
            Azul,
            Verde,
            Rosa,
            Morado,
            Amarillo,
            Cafe
        }

        public List<ProductoTerminado> ProductoTerminado { get; set; }
    }
}
