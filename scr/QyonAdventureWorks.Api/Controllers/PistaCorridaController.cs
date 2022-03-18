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
    public class PistaCorridaController : MainController
    {
        private readonly IPistaCorridaRepository _pistaCorridaRepository;
        private readonly IPistaCorridaService  _pistaCorridaService;
        private readonly IMapper _mapper;

        public PistaCorridaController(IPistaCorridaRepository pistaCorridaRepository,
                                      IMapper mapper,
                                      IPistaCorridaService pistaCorridaService,
                                      INotificador notificador) : base(notificador)
        {
            _pistaCorridaRepository = pistaCorridaRepository;
            _mapper = mapper;
            _pistaCorridaService = pistaCorridaService;
        }

        [AllowAnonymous]
        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<PistaCorridaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PistaCorridaViewModel>>(await _pistaCorridaRepository.ObterTodos());
        }

        [AllowAnonymous]
        [HttpGet("ObterPistasUtilizadas")]
        public async Task<IEnumerable<PistaCorridaViewModel>> ObterPistasUtilizadas()
        {
            return _mapper.Map<IEnumerable<PistaCorridaViewModel>>(await _pistaCorridaRepository.ObterPistasUtilizadas());
        }

        [HttpGet("ObterPorId/{id:int}")]
        public async Task<ActionResult<PistaCorridaViewModel>> ObterPorId(int id)
        {
            var pistaCorrida = await ObterPistaCorrida(id);

            if (pistaCorrida == null) return NotFound();

            return pistaCorrida;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<PistaCorridaViewModel>> Adicionar(PistaCorridaViewModel pistaCorridaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pistaCorridaService.Adicionar(_mapper.Map<PistaCorrida>(pistaCorridaViewModel));

            return CustomResponse(pistaCorridaViewModel);
        }

        [HttpPut("Atualizar/{id:int}")]
        public async Task<ActionResult<PistaCorridaViewModel>> Atualizar(int id, PistaCorridaViewModel  pistaCorridaViewModel)
        {
            if (id != pistaCorridaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(pistaCorridaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pistaCorridaService.Atualizar(_mapper.Map<PistaCorrida>(pistaCorridaViewModel));

            return CustomResponse(pistaCorridaViewModel);
        }

        [HttpDelete("Excluir/{id:int}")]
        public async Task<ActionResult<PistaCorridaViewModel>> Excluir(int id)
        {
            var fornecedorViewModel = await ObterPistaCorrida(id);

            if (fornecedorViewModel == null) return NotFound();

            await _pistaCorridaService.Remover(id);

            return CustomResponse(fornecedorViewModel);
        }

        private async Task<PistaCorridaViewModel> ObterPistaCorrida(int id)
        {
            return _mapper.Map<PistaCorridaViewModel>(await _pistaCorridaRepository.ObterPorId(id));
        }
    }
}