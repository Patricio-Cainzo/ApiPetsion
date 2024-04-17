using ApiPetsion.DTOs;
using ApiPetsion.Models;
using ApiPetsion.Models.Dto;
using ApiPetsion.Models.Repositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPetsion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnfitrionController : ControllerBase
    {
        private readonly IAnfitrionRepositorio _repository;
        private readonly IMapper _mapper;

        // Constructor que recibe las dependencias necesarias mediante inyección de dependencias
        public AnfitrionController(IAnfitrionRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // HTTP GET para obtener todos los Anfitriones
        [HttpGet]
        public ActionResult<IEnumerable<AnfitrionDto>> ObtenerTodos()
        {
            // Asi obtengo los datos del repositorio
            var anfitrions = _repository.ObtenerTodos();

            // Con esto mapeamos la lista de Anfitriones hacia una lista de Anfitriones
            var anfitrionsDto = _mapper.Map<IEnumerable<AnfitrionDto>>(anfitrions);

            // Me devuelve los datos en formato json
            return Ok(anfitrionsDto);
        }

        // HTTP GET para obtener un Anfitrion por su ID
        [HttpGet("{id}")]
        public ActionResult<AnfitrionDto> ObtenerPorId(int id)
        {
            // obtengo el Anfitrion con el ID proporcionado desde el repositorio
            var anfitrion = _repository.ObtenerPorId(id);

            // Verificar si el anfitrion no fue encontrado
            if (anfitrion == null)
            {
                // Devolver una respuesta 404 (Not Found) si el gasto no existe
                return NotFound();
            }

            // Mapear el gasto a un AnfitrionDto y devolverlo en formato JSON
            var anfitrionDto = _mapper.Map<AnfitrionDto>(anfitrion);
            return Ok(anfitrionDto);
        }

        // Endpoint HTTP POST para agregar un nuevo anfitrion
        [HttpPost]
        public ActionResult<AgregarAnfitrionDto> AgregarAnfitrion(AnfitrionDto anfitrionDto)
        {
            // Mapear el AnfitrionDto recibido a un objeto Anfitrion
            var anfitrion = _mapper.Map<Anfitrion>(anfitrionDto);

            // Agregar el nuevo anfitrion al repositorio
            _repository.Agregar(anfitrion);

            // Crear un objeto de respuesta con el ID del Anfitrion agregado y un mensaje
            var responseDto = new AgregarAnfitrionDto
            {
                Id = anfitrion.Id,
                Mensaje = "Anfitrion agregado exitosamente."
            };

            // Devolver la respuesta en formato JSON
            return Ok(responseDto);
        }

        // Endpoint HTTP PUT para actualizar un anfitrion existente por su ID
        [HttpPut("{id}")]
        public ActionResult<ActualizarAnfitrionDto> ActualizarAnfitrion(int id, AnfitrionDto anfitrionDto)
        {
            // Obtener el anfitrion existente con el ID proporcionado desde el repositorio
            var existingAnfitrion = _repository.ObtenerPorId(id);

            // Verificar si el anfitrion no fue encontrado
            if (existingAnfitrion == null)
            {
                // Devolver una respuesta 404 (Not Found) si el gasto no existe
                return NotFound();
            }

            // Aplicar las actualizaciones desde el Anfitrion al gasto existente
            _mapper.Map(anfitrionDto, existingAnfitrion);

            // Actualizar el anfitrion en el repositorio
            _repository.Actualizar(existingAnfitrion);

            // Crear un objeto de respuesta con un mensaje
            var responseDto = new ActualizarAnfitrionDto
            {
                Mensaje = "Gasto actualizado exitosamente."
            };

            return Ok(responseDto);
        }

        // Endpoint HTTP DELETE para eliminar un anfitrion por su ID
        [HttpDelete("{id}")]
        public ActionResult<EliminarAnfitrionDto> EliminarAnfitrion(int id)
        {
            // Obtener el anfitrion existente con el ID proporcionado desde el repositorio
            var existingAnfitrion = _repository.ObtenerPorId(id);

            // Verificar si el anfitrion no fue encontrado
            if (existingAnfitrion == null)
            {
                // Devolver una respuesta 404 (Not Found) si el anfitrion no existe
                return NotFound();
            }

            // Eliminar el anfitrion del repositorio
            _repository.Eliminar(id);

            // Crear un objeto de respuesta con un mensaje
            var responseDto = new EliminarAnfitrionDto
            {
                Mensaje = "Anfitrion eliminado exitosamente."
            };


            return Ok(responseDto);
        }

        [HttpPost("buscar")]
        public IActionResult BuscarAnfitriones([FromBody] BusquedaAnfitrionDTO busquedaDTO)
        {
            if (busquedaDTO == null)
            {
                return BadRequest("Los datos de búsqueda no pueden estar vacíos");
            }

            var anfitriones = _repository.BuscarAnfitriones(busquedaDTO);

            if (anfitriones == null || !anfitriones.Any())
            {
                return NotFound("No se encontraron anfitriones que cumplan con los criterios de búsqueda");
            }

            return Ok(anfitriones);
        }
    }
}
