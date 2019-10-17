using ProjectReceitas.Data.Context;
using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectReceitas.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SqlServerContext context) : base(context)
        { }

        public Usuario AutenticarUsuario(Usuario user)
        {
            return this.dbSet.FirstOrDefault(w => w.Login.Equals(user.Login) && w.Senha.Equals(user.Senha));
        }
    }
}
