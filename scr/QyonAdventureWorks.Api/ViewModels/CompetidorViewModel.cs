using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Api.ViewModels
{
    public class CompetidorViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
    }
}
