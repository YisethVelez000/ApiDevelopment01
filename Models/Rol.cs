using System.ComponentModel.DataAnnotations;

namespace ApiDevelopment.Models
{
    public class Rol
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        
        public string Nombre { get; set; }
        [Required]
        public int estadoRol { get; set; }

    }
}
