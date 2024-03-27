using Microsoft.AspNetCore.Identity;

namespace ApiDevelopment.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string NombreEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool EstadoEmpleado { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public DateOnly FechaFinalizacion { get; set; }
        public Rol IdRol { get; set; }
        public Usuario IdUsuario { get; set; }
    }
}
