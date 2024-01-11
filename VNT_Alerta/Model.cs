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
        public List<DaoTipoRegistro> GetTipoRegistro(string texto)
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
        public string GetTipoRegistroID(string texto)
        {
            Context db = new Context();
            string descricao = db.tipoRegistro.FirstOrDefault(p => p.Id == int.Parse(texto)).Descricao;
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
    }
}
