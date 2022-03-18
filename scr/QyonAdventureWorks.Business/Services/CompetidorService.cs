using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using QyonAdventureWorks.Business.Models.Validations;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Services
{
    public class CompetidorService : BaseService, ICompetidorService
    {
        private readonly ICompetidorRepository _competidorRepository;

        public CompetidorService(ICompetidorRepository competidorRepository,
                              INotificador notificador) : base(notificador)
        {
            _competidorRepository = competidorRepository;

        }

        public async Task Adicionar(Competidor competidor)
        {
            if (!ExecutarValidacao(new CompetidorValidation(), competidor)) return;

            await _competidorRepository.Adicionar(competidor);
        }

        public async Task Atualizar(Competidor competidor)
        {
            if (!ExecutarValidacao(new CompetidorValidation(), competidor)) return;

            await _competidorRepository.Atualizar(competidor);
        }

        public async Task Remover(int id)
        {
            await _competidorRepository.Remover(id);
        }

        public void Dispose()
        {
            _competidorRepository?.Dispose();
        }
    }
}
