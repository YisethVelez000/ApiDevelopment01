namespace ApiDevelopment.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public Cliente IdCliente { get; set; }
        public Pedido IdPedido { get; set; }
        public DateOnly FechaVenta { get; set; }
        public double TotalVenta { get; set; }
        public bool EstadoVenta { get; set; }
    }
}
