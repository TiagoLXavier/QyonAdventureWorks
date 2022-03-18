using QyonAdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Intefaces
{
    public interface ICompetidorRepository : IRepository<Competidor>
    {
        Task<List<Competidor>> ObterCompetidoresSemCorrida();
        Task<List<object>> ObterCompetidoresHistoricoCorridas();
    }
}
