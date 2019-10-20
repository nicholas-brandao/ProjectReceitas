using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectReceitas.Models;
using System.Threading.Tasks;

namespace ProjectReceitas.Controllers
{
    public class LoginController : BaseController
    {
        public IConfiguration Configuration { get; }

        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("User, Password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                var caminhourl = Configuration["ReceitaAPI"] + "/Login/SignIn";
                var response = PostBase(userLogin, caminhourl);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Index");

                Program.gToken = await response.Content.ReadAsStringAsync();
                    return RedirectToAction("Index", "Receitas");
            }

            return RedirectToAction("Index");
        }
    }
}
