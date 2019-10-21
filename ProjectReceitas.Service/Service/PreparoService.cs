using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Domain.Interface;
using ProjectReceitas.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Service.Service
{
    public class PreparoService : BaseService<ReceitaModoPreparo>, IPreparoService
    {
        private IPreparoRepository repository;
        public PreparoService(IPreparoRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
