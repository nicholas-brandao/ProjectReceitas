using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectReceitas.Api.Model;
using ProjectReceitas.Api.Security;
using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Service.Service.Interface;

namespace ProjectReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUsuarioService usuarioService;
        private readonly JwtService jwt;

        public LoginController(IConfiguration config, IUsuarioService service, JwtService jwt)
        {
            _config = config;
            usuarioService = service;
            this.jwt = jwt;
        }

        /// <summary>
        /// Efetua o Login
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost, AllowAnonymous]
        [Route("SignIn")]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SignIn([FromBody]UserLogin user)
        {
            try
            {
                if (user == null)
                    return Unauthorized(new { message = "Usuário e/ou senha inválidos" });

                var retorno = usuarioService.AutenticarUsuario(new Usuario()
                {
                    Login = user.User,
                    Senha = user.Password
                });

                if (!retorno)
                    return Unauthorized(new { message = "Usuário ou senha inválidos" });


                return Ok(jwt.AutenticarUsuarioJwt(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}