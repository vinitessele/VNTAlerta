using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    public class DaoEmpresa
    {
        public int Id { get; set; }

        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? Cnpj { get; set; }
        public string? Atividade { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public int? IdCidade { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public DateTime? DataAbertura { get; set; }
        public string? Observacao { get; set; }

    }
}
