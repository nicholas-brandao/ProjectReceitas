using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectReceitas.Domain.Interface.Services
{
    public interface IService<T> where T : class
    {
        void Adicionar(T obj);

        void Atualizar(T obj);

        void Remover(T id);

        T ObterPorId(int id);

        IEnumerable<T> ObterTodos();

        IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate);
    }
}
