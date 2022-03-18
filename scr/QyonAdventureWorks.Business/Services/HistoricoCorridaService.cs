using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using QyonAdventureWorks.Business.Models.Validations;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Services
{

    public class HistoricoCorridaService : BaseService, IHistoricoCorridaService
    {
        private readonly IHistoricoCorridaRepository _historicoCorridaRepository;

        public HistoricoCorridaService(IHistoricoCorridaRepository historicoCorridaRepository,
                              INotificador notificador) : base(notificador)
        {
            _historicoCorridaRepository = historicoCorridaRepository;
        }

        public async Task Adicionar(HistoricoCorrida historicoCorrida)
        {
            if (!ExecutarValidacao(new HistoricoCorridaValidation(), historicoCorrida)) return;

            await _historicoCorridaRepository.Adicionar(historicoCorrida);
        }

        public async Task Atualizar(HistoricoCorrida historicoCorrida)
        {
            if (!ExecutarValidacao(new HistoricoCorridaValidation(), historicoCorrida)) return;

            await _historicoCorridaRepository.Atualizar(historicoCorrida);
        }

        public async Task Remover(int id)
        {
            await _historicoCorridaRepository.Remover(id);
        }

        public void Dispose()
        {
            _historicoCorridaRepository?.Dispose();
        }
    }
}
