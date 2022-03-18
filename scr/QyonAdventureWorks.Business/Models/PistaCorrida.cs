namespace QyonAdventureWorks.Business.Models
{
    public class PistaCorrida : Entity
    {
        public string Descricao { get; set; }
        public HistoricoCorrida HistoricoCorrida { get; set; }
    }
}
