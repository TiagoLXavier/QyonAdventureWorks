using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using QyonAdventureWorks.Business.Models.Validations;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Services
{
    public class PistaCorridaService : BaseService, IPistaCorridaService
    {
        private readonly IPistaCorridaRepository _pistaCorridaRepository;

        public PistaCorridaService(IPistaCorridaRepository pistaCorridaRepository,
                              INotificador notificador) : base(notificador)
        {
            _pistaCorridaRepository = pistaCorridaRepository;
        }

        public async Task Adicionar(PistaCorrida pistaCorrida)
        {
            if (!ExecutarValidacao(new PistaCorridaValidation(), pistaCorrida)) return;

            await _pistaCorridaRepository.Adicionar(pistaCorrida);
        }

        public async Task Atualizar(PistaCorrida pistaCorrida)
        {
            if (!ExecutarValidacao(new PistaCorridaValidation(), pistaCorrida)) return;

            await _pistaCorridaRepository.Atualizar(pistaCorrida);
        }

        public async Task Remover(int id)
        {
            await _pistaCorridaRepository.Remover(id);
        }

        public void Dispose()
        {
            _pistaCorridaRepository?.Dispose();
        }
    }
}

