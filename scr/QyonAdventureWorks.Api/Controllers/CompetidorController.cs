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
    public class CompetidorController : MainController
    {
        private readonly ICompetidorRepository _competidorRepository;
        private readonly ICompetidorService _competidorService;
        private readonly IMapper _mapper;

        public CompetidorController(ICompetidorRepository competidorRepository,
                                      IMapper mapper,
                                      ICompetidorService competidorService,
                                      INotificador notificador) : base(notificador)
        {
            _competidorRepository = competidorRepository;
            _mapper = mapper;
            _competidorService = competidorService;
        }

        [AllowAnonymous]
        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<CompetidorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CompetidorViewModel>>(await _competidorRepository.ObterTodos());
        }

        [HttpGet("ObterCompetidoresSemCorrida")]
        public async Task<IEnumerable<CompetidorViewModel>> ObterCompetidoresSemCorrida()
        {
            return _mapper.Map<IEnumerable<CompetidorViewModel>>(await _competidorRepository.ObterCompetidoresSemCorrida());
        }

        [HttpGet("ObterCompetidoresTempoMedioGasto")]
        public async Task<IEnumerable<object>> ObterCompetidoresTempoMedioGasto()
        {
            return await _competidorRepository.ObterCompetidoresHistoricoCorridas();
        }

        [HttpGet("ObterPorId/{id:int}")]

        public async Task<ActionResult<CompetidorViewModel>> ObterPorId(int id)
        {
            var competidor = await ObterCompetidor(id);

            if (competidor == null) return NotFound();

            return competidor;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<CompetidorViewModel>> Adicionar(CompetidorViewModel competidorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _competidorService.Adicionar(_mapper.Map<Competidor>(competidorViewModel));

            return CustomResponse(competidorViewModel);
        }

        [HttpPut("Atualizar/{id:int}")]
        public async Task<ActionResult<CompetidorViewModel>> Atualizar(int id, CompetidorViewModel competidorViewModel)
        {
            if (id != competidorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(competidorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _competidorService.Atualizar(_mapper.Map<Competidor>(competidorViewModel));

            return CustomResponse(competidorViewModel);
        }

        [HttpDelete("Excluir/{id:int}")]
        public async Task<ActionResult<CompetidorViewModel>> Excluir(int id)
        {
            var competidor = await ObterCompetidor(id);

            if (competidor == null) return NotFound();

            await _competidorService.Remover(id);

            return CustomResponse(competidor);
        }

        private async Task<CompetidorViewModel> ObterCompetidor(int id)
        {
            return _mapper.Map<CompetidorViewModel>(await _competidorRepository.ObterPorId(id));
        }
    }
}

