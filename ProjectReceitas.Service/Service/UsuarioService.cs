using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Domain.Interfaces;
using ProjectReceitas.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Service.Service
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private IUsuarioRepository repository;
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public bool AutenticarUsuario(Usuario user)
        {
            user = repository.AutenticarUsuario(user);

            if (user == null)
                return false;
            else
                return true;
        }
    }
}
