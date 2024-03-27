using System.ComponentModel.DataAnnotations;

namespace ApiDevelopment.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required]
        [MinLength(3)]
        public string Correo { get; set; }
        public string Password { get; set; }
        public Rol idRol { get; set; }
        public bool Estado { get; set; }
    }
}
