using QyonAdventureWorks.Business.Models;
using System;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Intefaces
{
    public interface IHistoricoCorridaService: IDisposable
    {
        Task Adicionar(HistoricoCorrida competidor);
        Task Atualizar(HistoricoCorrida competidor);
    }
}
