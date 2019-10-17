using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Domain.Interface.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        bool AutenticarUsuario(Usuario user);
    }
}
