using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Data.SQLite;
using System.IO;
using System.Xml.Linq;

namespace VNT_Alerta
{
    public partial class FormPrincipal : Form
    {
        private static SQLiteConnection sqliteConnection;
        string dbName = "bd.sqlite";
        string startupPath = Environment.CurrentDirectory + "\\DB\\";
        string dataBasePath = string.Empty;

        private static SQLiteConnection DbConnection(string dataBasePath)
        {
            string caminho = "Data Source= " + dataBasePath + "; Version=3;";

            sqliteConnection = new SQLiteConnection(caminho);
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public FormPrincipal()
        {
            InitializeComponent();
            CriaBancoDados();
            CriarTabelaSQlite();
        }

        private void CriaBancoDados()
        {
            try
            {
                try
                {
                    if (!Directory.Exists(startupPath))
                        Directory.CreateDirectory(startupPath);

                    dataBasePath = startupPath + dbName;


                    SQLiteConnection.CreateFile(dataBasePath);
                }
                catch
                {
                    MessageBox.Show("Failed to create database", "DB Creator");
                }
            }
            catch
            {
                throw;
            }
        }

        private void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection(dataBasePath).CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS cfgNotificacao(id integer not null primary key autoincrement," +
                                                                                " emailFrom  VarChar(100)," +
                                                                                " emailTo VarChar(300)," +
                                                                                " emailSubject  VarChar(100)," +
                                                                                " emailBody  VarChar(500)," +
                                                                                " smtp  VarChar(100)," +
                                                                                " notificacaoWindows char(1)," +
                                                                                " diasNotificacao)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS notificacao(id integer not null primary key autoincrement," +
                                                            " descricao  VarChar(200)," +
                                                            " dataNotificacao)";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void Application_Startup()
        {
            new ToastContentBuilder()
         .AddArgument("conversationId", 9813)
         .AddText("teste")
         .AddText("teste")
         .Show(toast =>
         {
             toast.ExpirationTime = DateTime.Now.AddDays(1);
         });
        }

    }
}
