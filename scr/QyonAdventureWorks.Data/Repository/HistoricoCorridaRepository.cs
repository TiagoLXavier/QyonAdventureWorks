using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using QyonAdventureWorks.Data.Context;

namespace QyonAdventureWorks.Data.Repository
{
   public class HistoricoCorridaRepository : Repository<HistoricoCorrida>, IHistoricoCorridaRepository
    {
        public HistoricoCorridaRepository(MeuDbContext context) : base(context) { }
    }
}
