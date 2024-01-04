using Microsoft.Toolkit.Uwp.Notifications;
using System.Data.SQLite;
using System.Net;
using System.Net.Mail;
using Windows.Media.Protection.PlayReady;

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
            EnviaEmail();
            Application_Startup();
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
                    MessageBox.Show("Falha ao criar o banco de dados", "DB Creator");
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
        private void EnviaEmail()
        {
            // Configurações do servidor SMTP
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "vntnotificacao@gmail.com";
            string smtpPassword = "sifw qwdn xbmc gebh";

            // Endereço de email do remetente
            string fromEmail = "vntnotificacao@gmail.com";

            // Endereço de email do destinatário
            string toEmail = "vinicius_tessele@hotmail.com";

            // Criar objeto de mensagem
            MailMessage message = new MailMessage(fromEmail, toEmail);
            message.Subject = "Assunto do email";
            message.Body = "Conteúdo do email";

            // Configurar cliente SMTP
            SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true; // Use SSL para conexão segura
            smtp.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            try
            {
                // Enviar email
                smtp.Send(message);
                Console.WriteLine("Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar o email: " + ex.Message);
            }
        }

    }
}
