using System.ComponentModel.DataAnnotations;

namespace ApiPetsion.Models
{
    public class Anfitrion
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string CodigoPostal { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string TipoVivienda { get; set; }

        [Required]
        public bool Patio { get; set; }

        [Required]
        public bool AdmiteGato { get; set; }

        [Required]
        public bool AdmitePerroGrande { get; set; }

        [Required]
        public bool AdmitePerroMediano { get; set; }

        [Required]
        public bool AdmitePerroPequeno { get; set; }

        [Required]
        public bool PaseoMascota { get; set; }

        [Required]
        public string Horarios { get; set; }

        [Required]
        public bool OfreceAlojamiento { get; set; }

        [Required]
        public bool GuarderiaDiurna { get; set; }

        [Required]
        public bool DisponibleLunes { get; set; }

        [Required]
        public bool DisponibleMartes { get; set; }

        [Required]
        public bool DisponibleMiercoles { get; set; }

        [Required]
        public bool DisponibleJueves { get; set; }

        [Required]
        public bool DisponibleViernes { get; set; }

        [Required]
        public bool DisponibleSabado { get; set; }

        [Required]
        public bool DisponibleDomingo { get; set; }

        [Required]
        public int CantidadmascotaAdmite { get; set; }

        [Required]
        public bool MascotasdistDueño { get; set; }

        [Required]
        public bool AceptaCancelaciones { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
