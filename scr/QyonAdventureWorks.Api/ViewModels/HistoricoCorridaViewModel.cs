using System;
using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Api.ViewModels
{
    public class HistoricoCorridaViewModel
    {
        [Key]
        public int Id { get; set; }
        public int CompetidorId { get; set; }
        public int PistaCorridaId { get; set; }
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }
    }
}
