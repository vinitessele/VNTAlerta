using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao

{
    public class DtoNotificacao
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int? IdTipoRegistro { get; set; }
        public int? IdEmpresa { get; set; }
        public string? NomeEmpresa { get; set; }
        public string? TipoRegistro { get; set; }
        public DateTime? DataInicalProcesso { get; set; }
        public DateTime? DataFinalProcesso { get; set; }
        public DateTime? DataNotificacao { get; set; }
        public string? Observacao { get; set; }
        public string? notificacaoFinalizada { get; set; }
        
    }
}
