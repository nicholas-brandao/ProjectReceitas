using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace ProjectReceitas.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult StatusResult(HttpResponseMessage requestMessage)
        {
            switch (requestMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK: return Ok();
                case System.Net.HttpStatusCode.Unauthorized: return Unauthorized();
                case System.Net.HttpStatusCode.NotFound: return NotFound();
                default:
                    return NotFound();
            }
        }

        public HttpResponseMessage GetValues(string caminhourl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.gToken);
                var responseMessage = client.GetAsync(caminhourl).Result;

                return responseMessage;
            }
        }

        public HttpResponseMessage PostBase(object dados, string caminho)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(Program.gToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.gToken);

                var responseMessage = client.PostAsJsonAsync(caminho, dados).Result;

                return responseMessage;
            }
        }

        public HttpResponseMessage PutBase(object dados, string caminho)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(Program.gToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.gToken);

                var responseMessage = client.PutAsJsonAsync(caminho, dados).Result;

                return responseMessage;
            }
        }

        public HttpResponseMessage SendDelete(string caminho)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.gToken);
                var responseMessage = client.DeleteAsync(caminho).Result;

                return responseMessage;
            }
        }
    }
}
