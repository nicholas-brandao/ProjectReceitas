using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectReceitas.Data.Context;
using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Service.Service.Interface;

namespace ProjectReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        //    private readonly IReceitaService receitaService;

        //    public ReceitasController(IReceitaService service)
        //    {
        //        receitaService = service;
        //    }

        //    // GET: api/Receitas
        //    [HttpGet]
        //    public ActionResult<IEnumerable<Receita>> GetReceita()
        //    {
        //        return receitaService.ObterTodos();
        //    }

        //    // GET: api/Receitas/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Receita>> GetReceita(int id)
        //    {
        //        var receita = await _context.Receita.FindAsync(id);

        //        if (receita == null)
        //        {
        //            return NotFound();
        //        }

        //        return receita;
        //    }

        //    // PUT: api/Receitas/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutReceita(int id, Receita receita)
        //    {
        //        if (id != receita.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(receita).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReceitaExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Receitas
        //    [HttpPost]
        //    public async Task<ActionResult<Receita>> PostReceita(Receita receita)
        //    {
        //        _context.Receita.Add(receita);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        //    }

        //    // DELETE: api/Receitas/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<Receita>> DeleteReceita(int id)
        //    {
        //        var receita = await _context.Receita.FindAsync(id);
        //        if (receita == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Receita.Remove(receita);
        //        await _context.SaveChangesAsync();

        //        return receita;
        //    }

        //    private bool ReceitaExists(int id)
        //    {
        //        return _context.Receita.Any(e => e.Id == id);
        //    }
    }
}
