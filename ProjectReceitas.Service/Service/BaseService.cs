using ProjectReceitas.Domain.Interface.Services;
using ProjectReceitas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectReceitas.Service.Service
{
    public class BaseService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Adicionar(T obj)
        {
            this.repository.Adicionar(obj);
        }

        public virtual void Atualizar(T obj)
        {
            this.repository.Atualizar(obj);
        }

        public virtual void Remover(T id)
        {
            this.repository.Remover(id);
        }

        public virtual T ObterPorId(int id)
        {
            return repository.ObterPorId(id);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return repository.ObterTodos();
        }

        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return this.repository.Pesquisar(predicate);
        }
    }
}
