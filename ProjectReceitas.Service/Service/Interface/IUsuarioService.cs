using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Service.Service.Interface
{
    public interface IUsuarioService : IService<Usuario>
    {
        bool AutenticarUsuario(Usuario user);
    }
}
