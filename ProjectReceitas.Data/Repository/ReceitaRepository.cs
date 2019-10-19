using Microsoft.EntityFrameworkCore;
using ProjectReceitas.Data.Context;
using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Domain.Interface;
using ProjectReceitas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectReceitas.Data.Repository
{
    public class ReceitaRepository : BaseRepository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(SqlServerContext context) : base(context)
        {
        }

        public override IEnumerable<Receita> ObterTodos()
        {
            return this.dbSet.Include(r => r.Ingredientes).Include(r => r.ModosPreparo);
        }

        public override Receita ObterPorId(int id)
        {
            return this.dbSet.Include(r => r.Ingredientes).Include(r => r.ModosPreparo).Where(r => r.Id == id).FirstOrDefault();
        }

    }
}
