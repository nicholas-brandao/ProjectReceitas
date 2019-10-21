using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Domain.Interface;
using ProjectReceitas.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Service.Service
{
    public class IngredienteService : BaseService<ReceitaIngrediente>, IIngredienteService
    {
        private IIngredienteRepository repository;
        public IngredienteService(IIngredienteRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
