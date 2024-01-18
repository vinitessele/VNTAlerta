using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    public class DaoSocios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? PercentualSocios { get; set; }
        public int? IdEmpresa { get; set; }
    }
}
