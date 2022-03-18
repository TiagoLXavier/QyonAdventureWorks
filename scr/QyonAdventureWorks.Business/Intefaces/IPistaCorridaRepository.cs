using QyonAdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Intefaces
{
    public interface IPistaCorridaRepository : IRepository<PistaCorrida>
    {
        Task<IEnumerable <PistaCorrida>> ObterPistasUtilizadas();
    }
}
