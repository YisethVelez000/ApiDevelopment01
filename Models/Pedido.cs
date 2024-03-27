namespace ApiDevelopment.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente IdCliente { get; set; }
        public double TotalPedido { get; set; }
        public string DireccionEntrega { get; set; }
        public DateOnly FechaPedido { get; set; }
        public DateOnly FechaEntrega { get; set; }
        public string FormaPago { get; set; }
        public double Precio { get; set; }
        public bool EstadoPedido { get; set; }
    }
}
