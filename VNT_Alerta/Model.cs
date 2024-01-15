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
        public DaoCfgNotificacao GetCfgNotificao()
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
        public List<DaoCidade> GetAllCidades()
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
        internal void SetNotificacao(DaoNotificacao d)
        {
            try
            {
                Context db = new();
                db.notificacao.Add(d);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        internal void AlterNotificacao(DaoNotificacao dados)
        {
            try
            {
                Context db = new();
                DaoNotificacao d = db.notificacao.FirstOrDefault(p => p.Id == dados.Id);

                d.Descricao = dados.Descricao;
                d.IdEmpresa = dados.IdEmpresa;
                d.IdTipoRegistro = dados.IdTipoRegistro;
                d.DataInicalProcesso = dados.DataInicalProcesso;
                d.DataFinalProcesso = dados.DataFinalProcesso;
                d.DataNotificacao = dados.DataNotificacao;
                d.Observacao = dados.Observacao;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        internal void DeleteNotificacao(int id)
        {
            try
            {
                Context db = new();
                DaoNotificacao d = db.notificacao.FirstOrDefault(p => p.Id == id);
                db.notificacao.Remove(d);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        internal List<DaoNotificacao> GetListNotificacaoNome(string texto)
        {
            Context db = new Context();
            var q = from t in db.notificacao
                    where t.Descricao.Contains(texto)
                    select new DaoNotificacao
                    {
                        Id = t.Id,
                        Descricao = t.Descricao,
                        IdEmpresa = t.IdEmpresa
                    };
            return q.ToList();
        }
        public List<DaoTipoRegistro> GetListTipoRegistroAll()
        {
            Context db = new Context();
            var q = from t in db.tipoRegistro
                    select new DaoTipoRegistro
                    {
                        Id = t.Id,
                        Descricao = t.Descricao
                    };
            return q.ToList();
        }

        internal List<DaoEmpresa> GetListEmpresaAll()
        {
            Context db = new Context();
            var q = from t in db.empresa
                    select new DaoEmpresa
                    {
                        Id = t.Id,
                        RazaoSocial = t.RazaoSocial
                    };
            return q.ToList();
        }

        internal DaoNotificacao GetNotificacaoId(int id)
        {
            Context db = new Context();
            return db.notificacao.FirstOrDefault(p => p.Id == id);
        }

        internal List<DtoNotificacao> GetNotificacaoAll()
        {
            Context db = new Context();
            var q = from n in db.notificacao
                    join e in db.empresa
                    on n.IdEmpresa equals e.Id
                    join t in db.tipoRegistro
                    on n.IdTipoRegistro equals t.Id
                    select new DtoNotificacao
                    {
                        Id = t.Id,
                        NomeEmpresa = e.RazaoSocial,
                        TipoRegistro = t.Descricao,
                        Descricao = n.Descricao,
                        DataNotificacao = n.DataNotificacao
                    };
            return q.ToList();
        }
        internal void EnviaNotificacao()
        {
            DateTime data = DateTime.Now.AddDays(30);
            Context db = new Context();

            DaoCfgNotificacao cfgNotificacao = db.cfgNotificacao.FirstOrDefault();

            var qNotificacao = from n in db.notificacao
                               join e in db.empresa
                               on n.IdEmpresa equals e.Id
                               join t in db.tipoRegistro
                               on n.IdTipoRegistro equals t.Id
                               where n.notificacaoFinalizada == null
                               && n.DataNotificacao <= data
                               select new DtoNotificacao
                               {
                                   Id = t.Id,
                                   NomeEmpresa = e.RazaoSocial,
                                   TipoRegistro = t.Descricao,
                                   Descricao = n.Descricao,
                                   DataFinalProcesso = n.DataFinalProcesso,
                                   Observacao = n.Observacao
                               };

            foreach (var list in qNotificacao)
            {
                if (cfgNotificacao.notificacaoWindows == "S")
                {
                    Util.NotificacaoWindow(list);
                }
                if (cfgNotificacao.notificacaoEmail == "S")
                {
                    Util.EnviaEmail(list, cfgNotificacao);
                }
            }
        }
    }
}
