using ApiPetsion.Models.Dto;
using ApiPetsion.Models.Repositorio;
using ApiPetsion.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPetsion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDuenoController : ControllerBase
    {

        private readonly IUsuarioDuenoRepositorio _repository;
        private readonly IMapper _mapper;

        // Constructor que recibe las dependencias necesarias mediante inyección de dependencias
        public UsuarioDuenoController(IUsuarioDuenoRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // HTTP GET para obtener todos los Usuarios
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDuenoDto>> ObtenerTodos()
        {
            // Asi obtengo los datos del repositorio
            var usuarioDuenos = _repository.ObtenerTodos();

            // Con esto mapeamos la lista de Anfitriones hacia una lista de Anfitriones
            var usuariosDtos = _mapper.Map<IEnumerable<UsuarioDuenoDto>>(usuarioDuenos);

            // Me devuelve los datos en formato json
            return Ok(usuariosDtos);
        }

        // HTTP GET para obtener un Usuario por su ID
        [HttpGet("{id}")]
        public ActionResult<UsuarioDuenoDto> ObtenerPorId(int id)
        {
            // obtengo el Usuario con el ID proporcionado desde el repositorio
            var usuarioDueno = _repository.ObtenerPorId(id);

            // Verificar si el usuario no fue encontrado
            if (usuarioDueno == null)
            {
                // Devolver una respuesta 404 (Not Found) si el usuario no existe
                return NotFound();
            }

            // Mapear el usuario a un UsuarioDto y devolverlo en formato JSON
            var usuaruioDto = _mapper.Map<UsuarioDuenoDto>(usuarioDueno);
            return Ok(usuaruioDto);
        }

        // Endpoint HTTP POST para agregar un nuevo Usuario
        [HttpPost]
        public ActionResult<AgreagarUsuarioDuenoDto> AgregarUsuarioDueno(UsuarioDuenoDto usuarioDuenoDto)
        {
            // Mapear el UsuarioDuenoDto recibido a un objeto usuarioDueno
            var usuarioDueno = _mapper.Map<UsuarioDueno>(usuarioDuenoDto);

            // Agregar el nuevo usuario al repositorio
            _repository.Agregar(usuarioDueno);

            // Crear un objeto de respuesta con el ID del Anfitrion agregado y un mensaje
            var responseDto = new AgreagarUsuarioDuenoDto
            {
                Id = usuarioDueno.Id,
                Mensaje = "Usuario agregado exitosamente."
            };

            // Devolver la respuesta en formato JSON
            return Ok(responseDto);
        }

        // Endpoint HTTP PUT para actualizar un usuario existente por su ID
        [HttpPut("{id}")]
        public ActionResult<AgreagarUsuarioDuenoDto> ActualizarUsuarioDueno(int id, UsuarioDuenoDto usuarioDuenoDto)
        {
            // Obtener el usuario existente con el ID proporcionado desde el repositorio
            var existingUsuario = _repository.ObtenerPorId(id);

            // Verificar si el usuario no fue encontrado
            if (existingUsuario == null)
            {
                // Devolver una respuesta 404 (Not Found) si el usuario no existe
                return NotFound();
            }

            // Aplicar las actualizaciones desde el usuario al usuario existente
            _mapper.Map(usuarioDuenoDto, existingUsuario);

            // Actualizar el anfitrion en el repositorio
            _repository.Actualizar(existingUsuario);

            // Crear un objeto de respuesta con un mensaje
            var responseDto = new ActualizarUsuarioDuenoDto
            {
                Mensaje = "Usuario actualizado exitosamente."
            };

            return Ok(responseDto);
        }

        // Endpoint HTTP DELETE para eliminar un usuario por su ID
        [HttpDelete("{id}")]
        public ActionResult<EliminarUsuarioDuenoDto> EliminarUsuarioDueno(int id)
        {
            // Obtener el usuario existente con el ID proporcionado desde el repositorio
            var existingUsuario = _repository.ObtenerPorId(id);

            // Verificar si el usuario no fue encontrado
            if (existingUsuario == null)
            {
                // Devolver una respuesta 404 (Not Found) si el usuario no existe
                return NotFound();
            }

            // Eliminar el usuario del repositorio
            _repository.Eliminar(id);

            // Crear un objeto de respuesta con un mensaje
            var responseDto = new EliminarUsuarioDuenoDto
            {
                Mensaje = "Usuario eliminado exitosamente."
            };


            return Ok(responseDto);
        }
    }
}
