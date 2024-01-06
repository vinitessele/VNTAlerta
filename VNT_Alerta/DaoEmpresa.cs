using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VNT_Alerta
{
    public class DaoEmpresa
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string Atividade { get; set; }
        public string Endereco { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public int idCidade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Obs { get; set; }

    }
}
