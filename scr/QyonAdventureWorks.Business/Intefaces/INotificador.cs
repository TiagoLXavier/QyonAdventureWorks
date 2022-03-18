using QyonAdventureWorks.Business.Notificacoes;
using System.Collections.Generic;

namespace QyonAdventureWorks.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
