using System.ComponentModel.DataAnnotations;

namespace ApiPetsion.Models.Dto
{
    public class UsuarioDuenoDto
    {

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public DateTime FechadeNacimiento { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        public string NombreDeUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
