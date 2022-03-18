using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Api.ViewModels
{
    public class PistaCorridaViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
       // public HistoricoCorridaViewModel HistoricoCorrida { get; set; }
    }
}
