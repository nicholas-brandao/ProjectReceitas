using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjectReceitas.Data.Context;
using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Service.Service.Interface;

namespace ProjectReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaService receitaService;

        public ReceitasController(IReceitaService service)
        {
            receitaService = service;
        }

        // GET: api/Receitas
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Receita>> GetReceita()
        {
            return receitaService.ObterTodos().ToList();
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Receita> GetReceita(int id)
        {
            var receita = receitaService.ObterPorId(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/Receitas/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutReceita(int id, [FromBody] Receita receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            try
            {
                receitaService.Atualizar(receita);
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

        // POST: api/Receitas
        [HttpPost]
        [Authorize]
        public ActionResult<Receita> PostReceita([FromBody] Receita receita)
        {
            receitaService.Adicionar(receita);

            return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Receita> DeleteReceita(int id)
        {
            var receita = receitaService.ObterPorId(id);
            if (receita == null)
            {
                return NotFound();
            }

            receitaService.Remover(receita);
            return receita;
        }

        private bool ReceitaExists(int id)
        {
            return receitaService.ObterTodos().Any(e => e.Id == id);
        }
    }
}
