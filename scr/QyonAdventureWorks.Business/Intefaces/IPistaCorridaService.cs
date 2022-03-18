using QyonAdventureWorks.Business.Models;
using System;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Business.Intefaces
{
    public interface IPistaCorridaService : IDisposable
    {
        Task Adicionar(PistaCorrida competidor);
        Task Atualizar(PistaCorrida competidor);
        Task Remover(int id);
    }
}
