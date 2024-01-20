using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    public class Model
    {
        Context db = new();
        public int SetTipoRegistro(DaoTipoRegistro dados)
        {
            try
            {               
                if (dados.Descricao != null)
                    db.tipoRegistro.Add(dados);
                db.SaveChanges();
                return dados.Id;
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
            string descricao = db.tipoRegistro.FirstOrDefault(p => p.Id == int.Parse(id)).Descricao;
            return descricao;
        }
        public int SetCfgNotificacao(DaoCfgNotificacao dados)
        {
            try
            {
                db.cfgNotificacao.Add(dados);
                db.SaveChanges();
                return dados.Id;
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
                DaoCfgNotificacao t = db.cfgNotificacao.FirstOrDefault();
                return t;
            }
            catch
            {
                throw;
            }
        }
        public int SetEmpresa(DaoEmpresa dados)
        {
            try
            {
                db.empresa.Add(dados);
                db.SaveChanges();
                return dados.Id;
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
                DaoEmpresa d = db.empresa.FirstOrDefault(p => p.Id == dados.Id);

                d.RazaoSocial = dados.RazaoSocial;
                d.NomeFantasia = dados.NomeFantasia;
                d.Cnpj = dados.Cnpj;
                d.Endereco = dados.Endereco;
                d.Atividade = dados.Atividade;
                d.Bairro = dados.Bairro;
                d.Cep = dados.Cep;
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
            return db.empresa.Where(p => p.Id == id).FirstOrDefault();
        }
        internal int SetNotificacao(DaoNotificacao dados)
        {
            try
            {
                db.notificacao.Add(dados);
                db.SaveChanges();
                return dados.Id;
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
            return db.notificacao.FirstOrDefault(p => p.Id == id);
        }

        internal List<DtoNotificacao> GetNotificacaoAll()
        {
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

        internal List<DaoSocios> GetSociosEmpresa(int id)
        {
            return db.socios.Where(p=>p.IdEmpresa == id).ToList();
        }

        internal int SetSocios(DaoSocios dados)
        {
            try
            {
                db.socios.Add(dados);
                db.SaveChanges();
                return dados.Id;
            }
            catch
            {
                throw;
            }
        }
        internal void DeleteSocios(int id)
        {
            try
            {
                DaoSocios d = db.socios.FirstOrDefault(p => p.Id == id);
                db.socios.Remove(d);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        internal void AlteraRegistroEmpresa(string identificadorEmpresa, string vencimento, string serial)
        {
            try
            {
                DaoCfgEmpresa d = db.cfgEmpresa.FirstOrDefault();
                if (d.identificacaoCliente != null)
                {
                    if (d.identificacaoCliente == "Test0000")
                    {
                        d.identificacaoCliente = identificadorEmpresa;
                    }
                    else if(d.identificacaoCliente != identificadorEmpresa)
                    {
                        throw new Exception("Erro na identificação da empresa");
                    }
                    d.dataFimAtivacao = DateTime.Parse(vencimento);
                    d.statusAtivacao = "A";
                    d.chaveAcesso = serial;
                }                
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Erro na identificação da empresa");
            }
        }
        internal void SetDadosEmpresa(DaoCfgEmpresa e)
        {
            DaoCfgEmpresa d = db.cfgEmpresa.FirstOrDefault();
            if (d != null)
            {
                d.NomeEmpresa = e.NomeEmpresa;
                d.Cnpj = e.Cnpj;
                d.chaveAcesso = e.chaveAcesso;
                d.statusAtivacao = e.statusAtivacao;
                d.idCidade = e.idCidade;
                d.dataInicioAtivacao = e.dataInicioAtivacao;
                d.dataFimAtivacao = e.dataFimAtivacao;
                d.identificacaoCliente = e. identificacaoCliente;
            }
            else
            {
                db.cfgEmpresa.Add(d);
            }            
            db.SaveChanges();
        }
    }
}
