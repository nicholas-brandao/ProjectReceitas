using ProjectReceitas.Domain.Domain;
using ProjectReceitas.Domain.Interface;
using ProjectReceitas.Service.Service.Interface;

namespace ProjectReceitas.Service.Service
{
    public class ReceitaService : BaseService<Receita>, IReceitaService
    {
        private IReceitaRepository repository;
        public ReceitaService(IReceitaRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
