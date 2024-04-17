namespace ApiPetsion.DTOs
{
    public class BusquedaAnfitrionDTO
    {
        public string TipoVivienda { get; set; }
        public bool Patio { get; set; }
        public bool AdmiteGato { get; set; }
        public bool AdmitePerroGrande { get; set; }
        public bool AdmitePerroMediano { get; set; }
        public bool AdmitePerroPequeno { get; set; }
        public bool PaseoMascota { get; set; }
        public bool OfreceAlojamiento { get; set; }
        public bool GuarderiaDiurna { get; set; }
        public bool DisponibleLunes { get; set; }
        public bool DisponibleMartes { get; set; }
        public bool DisponibleMiercoles { get; set; }
        public bool DisponibleJueves { get; set; }
        public bool DisponibleViernes { get; set; }
        public bool DisponibleSabado { get; set; }
        public bool DisponibleDomingo { get; set; }
        public int CantidadMascotaAdmite { get; set; }
    }
}
