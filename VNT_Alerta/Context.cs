using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Microsoft.EntityFrameworkCore;

namespace VNT_CentralDeNotificacao
{
    public partial class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dataBasePath = Environment.CurrentDirectory + "\\DB\\bd.sqlite";
                string caminho = "Data Source= " + dataBasePath;
                optionsBuilder.UseSqlite(caminho);
            }
        }

        public DbSet<DaoEstado> estado { get; set; }
        public DbSet<DaoCidade> cidade { get; set; }
        public DbSet<DaoEmpresa> empresa { get; set; }
        public DbSet<DaoCfgEmpresa> cfgEmpresa { get; set; }
        public DbSet<DaoCfgNotificacao> cfgNotificacao { get; set; }
        public DbSet<DaoNotificacao> notificacao { get; set; }
        public DbSet<DaoTipoRegistro> tipoRegistro { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DaoEstado>().HasKey(t => t.Id);
            builder.Entity<DaoCidade>().HasKey(t => t.Id);
            builder.Entity<DaoEmpresa>().HasKey(t => t.Id);
            builder.Entity<DaoCfgEmpresa>().HasKey(t => t.Id);
            builder.Entity<DaoCfgNotificacao>().HasKey(t => t.Id);
            builder.Entity<DaoNotificacao>().HasKey(t => t.Id);
            builder.Entity<DaoTipoRegistro>().HasKey(t => t.Id);
        }

    }
}
