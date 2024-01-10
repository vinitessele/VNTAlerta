using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    public class DaoCfgEmpresa
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string? Atividade { get; set; }
        public string? Endereco { get; set; }
        public string? bairro { get; set; }
        public string? cep { get; set; }
        public int idCidade { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public string chaveAcesso { get; set; }
        public string statusAtivacao { get; set; }
        public DateTime dataInicioAtivacao { get; set; }
        public DateTime dataFimAtivacao { get; set; }
        public string identificacaoCliente { get; set; }
    }
}
