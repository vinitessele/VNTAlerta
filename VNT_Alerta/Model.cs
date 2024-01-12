using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    public class Model
    {
        public void SetTipoRegistro(DaoTipoRegistro dados)
        {
            try
            {
                Context db = new();
                if (dados.Descricao != null)
                    db.tipoRegistro.Add(dados);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void AlterTipoRegistro(DaoTipoRegistro dados)
        {
            try
            {
                Context db = new();
                DaoTipoRegistro t = db.tipoRegistro.FirstOrDefault(p => p.Id == dados.Id);
                t.Descricao = dados.Descricao;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteTipoRegistro(int id)
        {
            try
            {
                Context db = new();
                DaoTipoRegistro t = db.tipoRegistro.FirstOrDefault(p => p.Id == id);
                db.tipoRegistro.Remove(t);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public List<DaoTipoRegistro> GetListTipoRegistro(string texto)
        {
            Context db = new Context();
            var q = from t in db.tipoRegistro
                    where t.Descricao.Contains(texto)
                    select new DaoTipoRegistro
                    {
                        Id = t.Id,
                        Descricao = t.Descricao
                    };
            return q.ToList();
        }
        public string GetTipoRegistroID(string id)
        {
            Context db = new Context();
            string descricao = db.tipoRegistro.FirstOrDefault(p => p.Id == int.Parse(id)).Descricao;
            return descricao;
        }
        public void SetCfgNotificacao(DaoCfgNotificacao dados)
        {
            try
            {
                Context db = new();
                db.cfgNotificacao.Add(dados);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void AlterCfgNotificacao(DaoCfgNotificacao dados)
        {
            try
            {
                Context db = new();
                DaoCfgNotificacao n = db.cfgNotificacao.FirstOrDefault(p => p.Id == dados.Id);
                n.emailTo = dados.emailTo;
                n.emailSubject = dados.emailSubject;
                n.emailBody = dados.emailBody;
                n.DiasNotificacao = dados.DiasNotificacao;
                n.notificacaoWindows = dados.notificacaoWindows;
                n.notificacaoEmail = dados.notificacaoEmail;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteCfgNotificacao(int id)
        {
            try
            {
                Context db = new();
                DaoCfgNotificacao t = db.cfgNotificacao.FirstOrDefault(p => p.Id == id);
                db.cfgNotificacao.Remove(t);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public DaoCfgNotificacao getCfgNotificao()
        {
            try
            {
                Context db = new();
                DaoCfgNotificacao t = db.cfgNotificacao.FirstOrDefault();
                return t;
            }
            catch
            {
                throw;
            }
        }
        public void setEmpresa(DaoEmpresa dados)
        {
            try
            {
                Context db = new();
                db.empresa.Add(dados);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AlterEmpresa(DaoEmpresa dados)
        {
            try
            {
                Context db = new();
                DaoEmpresa d = db.empresa.FirstOrDefault(p => p.Id == dados.Id);

                d.RazaoSocial = dados.RazaoSocial;
                d.NomeFantasia = dados.NomeFantasia;
                d.Cnpj = dados.Cnpj;
                d.Endereco = dados.Endereco;
                d.Atividade = dados.Atividade;
                d.bairro = dados.bairro;
                d.cep = dados.cep;
                d.Socios = dados.Socios;
                d.PercentualSocios = dados.PercentualSocios;
                d.Telefone = dados.Telefone;
                d.Celular = dados.Celular;
                d.DataAbertura = dados.DataAbertura;
                d.Observacao = dados.Observacao;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteEmpresa(int id)
        {
            try
            {
                Context db = new();
                DaoEmpresa t = db.empresa.FirstOrDefault(p => p.Id == id);
                db.empresa.Remove(t);
                db.SaveChanges();
            }
            catch
            {
                throw;

            }
        }
        public List<DaoEmpresa> GetListEmpresaNome(string texto)
        {
            Context db = new Context();
            var q = from t in db.empresa
                    where t.RazaoSocial.Contains(texto)
                    select new DaoEmpresa
                    {
                        Id = t.Id,
                        RazaoSocial = t.RazaoSocial,
                        NomeFantasia = t.NomeFantasia                        
                    };
            return q.ToList();
        }

        public List<DaoCidade> getAllCidades()
        {
            Context db = new Context();

            var q = (from c in db.cidade
                     join e in db.estado
                     on c.IdEstado equals e.Id into estado
                     from e in estado.DefaultIfEmpty()
                     select new DaoCidade()
                     {
                         Id = c.Id,
                         Nome = c.Nome + "/" + e.Uf,
                         IdEstado = c.Id
                     }).OrderBy(p => p.Nome);

            return q.ToList();
        }

        public DaoEmpresa GetEmpresaId(int id)
        {
            Context db = new Context();
            return db.empresa.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
