using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjectReceitas.Models;

namespace ProjectReceitas.Controllers
{
    public class IngredientesController : BaseController
    {

        public IConfiguration Configuration { get; }

        public IngredientesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: Ingredientes/5
        [Route("Ingredientes/Listar/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Ingredientes/Listar/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                List<ReceitaIngrediente> ingredientes = JsonConvert.DeserializeObject<List<ReceitaIngrediente>>(json);
                return View(ingredientes);
            }

            return StatusResult(retorno);
        }

        // GET: Ingredientes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Ingredientes/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                ReceitaIngrediente ingrediente = JsonConvert.DeserializeObject<ReceitaIngrediente>(json);
                return View(ingrediente);
            }

            return StatusResult(retorno);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceitaId, Descricao")] ReceitaIngrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Ingredientes";
                var response = PostBase(ingrediente, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index", "Login");

                return RedirectToAction(nameof(Index), new { id = ingrediente.ReceitaId });
            }

            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceitaId,Descricao")] ReceitaIngrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Ingredientes/" + id;
                var response = PutBase(ingrediente, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index", "Login");

                return RedirectToAction(nameof(Index), new { id = ingrediente.ReceitaId });
            }

            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public IActionResult Delete(int? id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Ingredientes/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = retorno.Content.ReadAsStringAsync().Result;
                ReceitaIngrediente ingrediente = JsonConvert.DeserializeObject<ReceitaIngrediente>(json);
                return View(ingrediente);
            }

            return StatusResult(retorno);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, int receitaid)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Ingredientes/" + id;
            var response = SendDelete(caminhourl);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return RedirectToAction("Index", "Login");

            return RedirectToAction(nameof(Index), new { id = receitaid });
        }
    }
}