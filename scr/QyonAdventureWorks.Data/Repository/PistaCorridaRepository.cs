using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using QyonAdventureWorks.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Data.Repository
{
    public class PistaCorridaRepository : Repository<PistaCorrida>, IPistaCorridaRepository
    {
        public PistaCorridaRepository(MeuDbContext context) : base(context) { }
        public async Task<IEnumerable<PistaCorrida>> ObterPistasUtilizadas()
        {
            return await Db.PistaCorridas.AsNoTracking().Include(h => h.HistoricoCorrida)
                  .Where(x => x.HistoricoCorrida != null).ToListAsync();
        }
    }
}
