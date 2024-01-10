using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    public class DaoEstado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public char Uf { get; set; }
        public int Regiao { get; set; }
    }
}
