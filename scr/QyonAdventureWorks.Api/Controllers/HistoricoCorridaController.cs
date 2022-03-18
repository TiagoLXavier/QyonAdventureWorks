using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Api.ViewModels;
using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoCorridaController : MainController
    {
        private readonly IHistoricoCorridaRepository _historicoCorridaRepository;
        private readonly IHistoricoCorridaService _historicoCorridaService;
        private readonly IMapper _mapper;

        public HistoricoCorridaController(IHistoricoCorridaRepository historicoCorridaRepository,
                                      IMapper mapper,
                                      IHistoricoCorridaService historicoCorridaService,
                                      INotificador notificador) : base(notificador)
        {
            _historicoCorridaRepository = historicoCorridaRepository;
            _mapper = mapper;
            _historicoCorridaService = historicoCorridaService;
        }

        [AllowAnonymous]
        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<HistoricoCorridaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<HistoricoCorridaViewModel>>(await _historicoCorridaRepository.ObterTodos());
        }

        [HttpGet("ObterPorId/{id:int}")]
        public async Task<ActionResult<HistoricoCorridaViewModel>> ObterPorId(int id)
        {
            var competidor = await ObterHistoricoCorrida(id);

            if (competidor == null) return NotFound();

            return competidor;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<HistoricoCorridaViewModel>> Adicionar(HistoricoCorridaViewModel historicoCorridaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _historicoCorridaService.Adicionar(_mapper.Map<HistoricoCorrida>(historicoCorridaViewModel));

            return CustomResponse(historicoCorridaViewModel);
        }

        [HttpPut("Atualizar/{id:int}")]
        public async Task<ActionResult<HistoricoCorridaViewModel>> Atualizar(int id, HistoricoCorridaViewModel historicoCorridaViewModel)
        {
            if (id != historicoCorridaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(historicoCorridaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _historicoCorridaService.Atualizar(_mapper.Map<HistoricoCorrida>(historicoCorridaViewModel));

            return CustomResponse(historicoCorridaViewModel);
        }

        private async Task<HistoricoCorridaViewModel> ObterHistoricoCorrida(int id)
        {
            return _mapper.Map<HistoricoCorridaViewModel>(await _historicoCorridaRepository.ObterPorId(id));
        }
    }
}
