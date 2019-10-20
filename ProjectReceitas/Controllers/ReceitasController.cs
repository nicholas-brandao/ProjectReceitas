using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjectReceitas.Models;

namespace ProjectReceitas.Controllers
{
    public class ReceitasController : BaseController
    {
        public IConfiguration Configuration { get; }

        public ReceitasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Receitas";

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                List<Receita> lstReceita = JsonConvert.DeserializeObject<List<Receita>>(json);
                return View(lstReceita);
            }

            return StatusResult(retorno);
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Receitas/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                Receita receita = JsonConvert.DeserializeObject<Receita>(json);
                return View(receita);
            }

            return StatusResult(retorno);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,HoraPreparo,MinutoPreparo,Rendimento")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Receitas";
                var response = PostBase(receita, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index", "Login");

                return RedirectToAction(nameof(Index));
            }

            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Receitas/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await retorno.Content.ReadAsStringAsync();
                Receita receita = JsonConvert.DeserializeObject<Receita>(json);
                return View(receita);
            }

            return StatusResult(retorno);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,HoraPreparo,MinutoPreparo,Rendimento")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Receitas/" + id;
                var response = PutBase(receita, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index", "Login");

                return RedirectToAction(nameof(Index));
            }

            return View(receita);
        }

        // GET: Receitas/Delete/5
        public IActionResult Delete(int? id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Receitas/" + id;

            var retorno = GetValues(caminhourl);
            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = retorno.Content.ReadAsStringAsync().Result;
                Receita receita = JsonConvert.DeserializeObject<Receita>(json);
                return View(receita);
            }

            return StatusResult(retorno);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var caminhourl = Configuration["ReceitaAPI"] + "/Receitas/" + id;
            var response = SendDelete(caminhourl);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return RedirectToAction("Index", "Login");

            return RedirectToAction(nameof(Index));
        }
    }
}
