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
    public class PreparosController : BaseController
    {

        public IConfiguration Configuration { get; }

        public PreparosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: Ingredientes/5
        [Route("Preparos/Listar/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Preparos/Listar/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                List<ReceitaModoPreparo> preparo = JsonConvert.DeserializeObject<List<ReceitaModoPreparo>>(json);
                ViewBag.ReceitaId = id;
                return View(preparo);
            }

            return StatusResult(retorno);
        }

        // GET: Preparos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Preparos/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                ReceitaModoPreparo preparo = JsonConvert.DeserializeObject<ReceitaModoPreparo>(json);
                return View(preparo);
            }

            return StatusResult(retorno);
        }

        public IActionResult Create(int Id)
        {
            return View(new ReceitaIngrediente() { ReceitaId = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceitaId, Descricao")] ReceitaModoPreparo preparo)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Preparos";
                var response = PostBase(preparo, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index", "Login");

                return RedirectToAction(nameof(Index), new { id = preparo.ReceitaId });
            }

            return View(preparo);
        }

        // POST: Preparos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceitaId,Descricao")] ReceitaModoPreparo preparo)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Preparos/" + id;
                var response = PutBase(preparo, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index", "Login");

                return RedirectToAction(nameof(Index), new { id = preparo.ReceitaId });
            }

            return View(preparo);
        }

        // GET: Preparos/Delete/5
        public IActionResult Delete(int? id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Preparos/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = retorno.Content.ReadAsStringAsync().Result;
                ReceitaModoPreparo preparo = JsonConvert.DeserializeObject<ReceitaModoPreparo>(json);
                return View(preparo);
            }

            return StatusResult(retorno);
        }

        // POST: Preparos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, int receitaid)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Preparos/" + id;
            var response = SendDelete(caminhourl);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return RedirectToAction("Index", "Login");

            return RedirectToAction(nameof(Index), new { id = receitaid });
        }
    }
}