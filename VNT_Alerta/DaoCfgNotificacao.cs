using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_Alerta
{ 
    public class DaoCfgNotificacao
    {
        public int IdCfgNotigicacao {get;set;}
        public string emailFrom { get; set; }
        public string emailTo { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public string smtp {  get; set; }
        public string notificacaoWindows { get; set; }
        public int DiasNotificacao { get; set; }
    }
}
