using AutoMapper;
using QyonAdventureWorks.Api.ViewModels;
using QyonAdventureWorks.Business.Models;

namespace QyonAdventureWorks.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Competidor, CompetidorViewModel>().ReverseMap();
            CreateMap<HistoricoCorrida, HistoricoCorridaViewModel>().ReverseMap();
            CreateMap<PistaCorrida, PistaCorridaViewModel>().ReverseMap();
            CreateMap<PistaCorridaViewModel, PistaCorrida>();
        }

    }
}
