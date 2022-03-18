using System.Collections.Generic;

namespace QyonAdventureWorks.Business.Models
{
    public class Competidor : Entity
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public IEnumerable<HistoricoCorrida> HistoricoCorridas { get; set; }
    }
}
