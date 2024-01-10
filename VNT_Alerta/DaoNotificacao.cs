using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao

{
    public class DaoNotificacao
    {
        public int Id { get; set; }
        public string? DescricaoNotificacao { get; set; }
        public DateTime? DateNotificacao { get; set; }
    }
}
