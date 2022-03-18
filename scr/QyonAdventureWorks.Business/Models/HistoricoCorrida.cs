using System;

namespace QyonAdventureWorks.Business.Models
{
    public class HistoricoCorrida : Entity
    {
        public int CompetidorId { get; set; }
        public int PistaCorridaId { get; set; }
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }
        public PistaCorrida PistaCorrida { get; set; }
        public Competidor Competidor { get; set; }
    }
}
