using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Service.Service.Interface;

namespace ProjectReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly IIngredienteService ingredienteService;

        public IngredientesController(IIngredienteService service)
        {
            ingredienteService = service;
        }

        // GET: api/Ingredientes/Listar/5
        [HttpGet("Listar/{id}")]
        [Authorize]
        public ActionResult<IEnumerable<ReceitaIngrediente>> GetIngredientes(int id)
        {
           return ingredienteService.ObterTodos().Where(x => x.ReceitaId == id).ToList();
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ReceitaIngrediente> GetIngrediente(int id)
        {
            var ingrediente = ingredienteService.ObterPorId(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        // PUT: api/Ingredientes/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutIngrediente(int id, [FromBody] ReceitaIngrediente ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return BadRequest();
            }

            try
            {
                ingredienteService.Atualizar(ingrediente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ingredientes
        [HttpPost]
        [Authorize]
        public ActionResult<ReceitaIngrediente> PostReceita([FromBody] ReceitaIngrediente ingrediente)
        {
            ingredienteService.Adicionar(ingrediente);

            return CreatedAtAction("GetIngrediente", new { id = ingrediente.Id }, ingrediente);
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<ReceitaIngrediente> DeleteIngrediente(int id)
        {
            var ingrediente = ingredienteService.ObterPorId(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            ingredienteService.Remover(ingrediente);
            return ingrediente;
        }

        private bool ReceitaExists(int id)
        {
            return ingredienteService.ObterTodos().Any(e => e.Id == id);
        }
    }
}