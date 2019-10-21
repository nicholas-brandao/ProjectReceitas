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
    public class PreparoRepository : BaseRepository<ReceitaModoPreparo>, IPreparoRepository
    {
        public PreparoRepository(SqlServerContext context) : base(context)
        {
        }
    }
}
