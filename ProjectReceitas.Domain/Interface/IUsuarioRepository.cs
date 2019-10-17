using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario AutenticarUsuario(Usuario user);
    }
}
