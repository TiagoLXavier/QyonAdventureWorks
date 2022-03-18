using QyonAdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Intefaces
{
    public interface ICompetidorService : IDisposable
    {
        Task Adicionar(Competidor competidor);
        Task Atualizar(Competidor competidor);
        Task Remover(int id);
    }
}
