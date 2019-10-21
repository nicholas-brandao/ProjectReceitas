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
    public class PreparosController : ControllerBase
    {
        private readonly IPreparoService preparoService;

        public PreparosController(IPreparoService service)
        {
            preparoService = service;
        }

        // GET: api/Preparos/Listar/5
        [HttpGet("Listar/{id}")]
        [Authorize]
        public ActionResult<IEnumerable<ReceitaModoPreparo>> GetPreparos(int id)
        {
           return preparoService.ObterTodos().Where(x => x.ReceitaId == id).ToList();
        }

        // GET: api/Preparos/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ReceitaModoPreparo> GetPreparo(int id)
        {
            var preparo = preparoService.ObterPorId(id);

            if (preparo == null)
            {
                return NotFound();
            }

            return preparo;
        }

        // PUT: api/Preparos/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutPreparo(int id, [FromBody] ReceitaModoPreparo preparo)
        {
            if (id != preparo.Id)
            {
                return BadRequest();
            }

            try
            {
                preparoService.Atualizar(preparo);
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

        // POST: api/Preparos
        [HttpPost]
        [Authorize]
        public ActionResult<ReceitaModoPreparo> PostReceita([FromBody] ReceitaModoPreparo preparo)
        {
            preparoService.Adicionar(preparo);

            return CreatedAtAction("GetPreparo", new { id = preparo.Id }, preparo);
        }

        // DELETE: api/Preparos/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<ReceitaModoPreparo> DeletePreparo(int id)
        {
            var preparo = preparoService.ObterPorId(id);
            if (preparo == null)
            {
                return NotFound();
            }

            preparoService.Remover(preparo);
            return preparo;
        }

        private bool ReceitaExists(int id)
        {
            return preparoService.ObterTodos().Any(e => e.Id == id);
        }
    }
}