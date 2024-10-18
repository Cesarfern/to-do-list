using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using CrudAPI.Context;
using CrudAPI.DTOs;
using CrudAPI.Entities;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TareaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<TareaDTO>>> Get()
        {
            var listaDTO = new List<TareaDTO>();
            var listaDB = await _context.Tareas.Where(e => e.IsCompleted == false).ToListAsync();

            foreach (var item in listaDB)
            {
                listaDTO.Add(new TareaDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    IsCompleted = item.IsCompleted,
                    CreatedAt = item.CreatedAt
                });
            }
            return Ok(listaDTO);
        }

        [HttpGet]
        [Route("lista-completas")]
        public async Task<ActionResult<List<TareaDTO>>> Completas()
        {
            var listaDTO = new List<TareaDTO>();
            var listaDB = await _context.Tareas.Where(e => e.IsCompleted == true).ToListAsync();

            foreach (var item in listaDB)
            {
                listaDTO.Add(new TareaDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    IsCompleted = item.IsCompleted,
                    CreatedAt = item.CreatedAt
                });
            }
            return Ok(listaDTO);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<TareaDTO>> Get(int id)
        {
            var tareaDTO = new TareaDTO();
            var tareaDB = await _context.Tareas
                .Where(e => e.Id == id).FirstAsync();
            
            tareaDTO.Id = id;
            tareaDTO.Title = tareaDB.Title;
            tareaDTO.Description = tareaDB.Description;
            tareaDTO.IsCompleted = tareaDB.IsCompleted;
            tareaDTO.CreatedAt = tareaDB.CreatedAt;
            return Ok(tareaDTO);
        }

        [HttpPost]
        [Route("agregar")]
        public async Task<ActionResult<TareaDTO>> Guardar(TareaDTO tareaDTO)
        {
            var tareaDB = new Tarea
            {
                Title = tareaDTO.Title,
                Description = tareaDTO.Description,
                IsCompleted = tareaDTO.IsCompleted,
            };
            await _context.Tareas.AddAsync(tareaDB);
            await _context.SaveChangesAsync();
            return Ok("Tarea agregada");
        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<TareaDTO>> Editar(TareaDTO tareaDTO)
        {
            var tareaDB = await _context.Tareas
                .Where(e => e.Id == tareaDTO.Id).FirstAsync();

            tareaDB.Title = tareaDTO.Title;
            tareaDB.Description = tareaDTO.Description;
            tareaDB.IsCompleted = tareaDTO.IsCompleted;
            
            _context.Tareas.Update(tareaDB);
            await _context.SaveChangesAsync();
            return Ok("Tarea Modificada");
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<ActionResult<TareaDTO>> Eliminar(int id)
        {
            var tareaDB = await _context.Tareas.FindAsync(id);

            if(tareaDB is null) return NotFound("Tarea no encontrada");

            _context.Tareas.Remove(tareaDB);
            await _context.SaveChangesAsync();
            return Ok("Tarea Eliminada");
        }
    }
}
