using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Models;
using QyonAdventureWorks.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Data.Repository
{
    public class CompetidorRepository : Repository<Competidor>, ICompetidorRepository
    {
        public CompetidorRepository(MeuDbContext context) : base(context) { }
        public async Task<List<Competidor>> ObterCompetidoresSemCorrida()
        {
            return await Db.Competidores.AsNoTracking()
                .Include(h => h.HistoricoCorridas)
                .Where(x => !x.HistoricoCorridas.Any()).ToListAsync();
        }

        public async Task<List<object>> ObterCompetidoresHistoricoCorridas()
        {
            var ListaCompetidoresHistoricoCorridas =
             await Db.Competidores.AsNoTracking()
               .Include(h => h.HistoricoCorridas).ToListAsync();

            var lista = new object[] { }.ToList();

            List<decimal> media = new List<decimal>();

            foreach (var ItemCompetidoresHistoricoCorridas in ListaCompetidoresHistoricoCorridas)
            {
                media.Clear();

                foreach (var itemHistoricoCorridas in ItemCompetidoresHistoricoCorridas.HistoricoCorridas)
                {
                    media.Add(itemHistoricoCorridas.TempoGasto);
                }

                if (ItemCompetidoresHistoricoCorridas.HistoricoCorridas.Any())
                {
                    lista.Add(new
                    {
                        Nome = ItemCompetidoresHistoricoCorridas.Nome,
                        TempoMedioGasto = media.Average()
                    });
                }
            }

            return lista;
        }
    }
}
