using Microsoft.Toolkit.Uwp.Notifications;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.Xml;
using System.Text;
using Windows.Media.Protection.PlayReady;

namespace VNT_CentralDeNotificacao
{
    public partial class FormAtivacao : Form
    {
        const string Ativo = "A";
        const string Inativo = "I";
        const string Bloqueado = "B";
        const string Teste = "T";

        private static SQLiteConnection sqliteConnection;
        private string dbName = "bd.sqlite";
        private string startupPath = Environment.CurrentDirectory + "\\DB\\";
        private string dataBasePath = string.Empty;

        private string chave = "Ajasklskeoessinmieosiusfoiweuwww";
        private string empresa = "Empresa Teste";
        private string cnpj = "12.123.123/0001-00";
        private string chaveAcesso = "111-222-333-444-555-666-777-888-999";
        private  string statusAtivacao = Teste;
        int idCidade = 4127700;
        DateTime dataInicioAtivacao = DateTime.Now;
        DateTime expira = DateTime.Now.AddDays(30);
        private string identificacaoCliente = "Teste0000";

        public FormAtivacao()
        {
            InitializeComponent();
            CriaBancoDados();
            CriarTabelaSQlite();
            AdicionaEstados();
            AdicionaCidades();
            VerificaLicenca();

            labelVersao.Text = "Versão: 24.1.0";

            FrmMenu fr = new();
            fr.Show();
            this.Hide();
        }
        private static SQLiteConnection DbConnection(string dataBasePath)
        {
            string caminho = "Data Source= " + dataBasePath + "; Version=3;";

            sqliteConnection = new SQLiteConnection(caminho);
            sqliteConnection.Open();
            return sqliteConnection;
        }
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "vnt files (*.vnt)|*.vnt";
            openFileDialog.Title = "Selecione o arquivo de licença";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                FiletextBox.Text = selectedFilePath;
            }
        }
        private void VerificaLicenca()
        {
            string pathLicenca = Environment.CurrentDirectory + "\\Licença\\";
            string arquivoLicenca = pathLicenca + "\\reg.vnt";

            try
            {
                Crypt crypt = new();

                if (!Directory.Exists(pathLicenca))
                    Directory.CreateDirectory(pathLicenca);

                if (!File.Exists(arquivoLicenca))
                {
                    StreamWriter arquivo;
                    // Criptografar
                    arquivo = File.CreateText(arquivoLicenca);
                    arquivo.WriteLine(crypt.Encrypt(empresa, chave));
                    arquivo.WriteLine(crypt.Encrypt(cnpj, chave));
                    arquivo.WriteLine(crypt.Encrypt(chaveAcesso, chave));
                    arquivo.WriteLine(crypt.Encrypt(statusAtivacao, chave));
                    arquivo.WriteLine(crypt.Encrypt(idCidade.ToString(), chave));
                    arquivo.WriteLine(crypt.Encrypt(dataInicioAtivacao.ToString(), chave));
                    arquivo.WriteLine(crypt.Encrypt(expira.ToString(), chave));
                    arquivo.WriteLine(crypt.Encrypt(identificacaoCliente.ToString(), chave));
                    arquivo.Close();
                    AddDadosEmpresaNova();
                }
                else
                {
                    string msg = "Ops Algo de errado com sua licença entre em contato com a VNT - Sistemas";
                    using (var db = new Context())
                    {                        
                        DaoCfgEmpresa e = db.cfgEmpresa.FirstOrDefault();

                        string line;
                        StreamReader sr = new(arquivoLicenca);
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            try
                            {
                                string textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.NomeEmpresa)
                                {
                                    line = sr.ReadLine();
                                    labelEmpresa.Text = "Empresa: " + textoDescriptografado;
                                }
                                else
                                {
                                    throw new System.InvalidOperationException();
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.Cnpj)
                                {
                                    line = sr.ReadLine();
                                    labelCnpj.Text = "CNPJ: " + textoDescriptografado;
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.chaveAcesso)
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.statusAtivacao)
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.idCidade.ToString())
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.dataInicioAtivacao.ToString())
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.dataFimAtivacao.ToString())
                                {
                                    line = sr.ReadLine();
                                    labelExpira.Text = "Expira em: " + textoDescriptografado;
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.identificacaoCliente)
                                {
                                    line = sr.ReadLine();
                                    labelIdentificacao.Text = "Identificação da Empresa: " + textoDescriptografado;
                                }
                                else
                                {
                                    throw new System.InvalidOperationException(msg);
                                }
                                line = sr.ReadLine();
                            }
                            catch
                            {
                                MessageBox.Show(msg, "VNT - Sistemas");
                                throw;
                            }
                        }
                        sr.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Falha ao verificar Licença de uso do Software", "VNT - Sistemas");
                throw;
            }
        }
        private void AddDadosEmpresaNova()
        {
            using var db = new Context();
            DaoCfgEmpresa e = new();
            e.NomeEmpresa = empresa;
            e.Cnpj = cnpj;
            e.chaveAcesso = chaveAcesso;
            e.statusAtivacao = statusAtivacao;
            e.dataInicioAtivacao = dataInicioAtivacao;
            e.dataFimAtivacao = expira;
            e.idCidade = idCidade;
            e.identificacaoCliente = identificacaoCliente;
            db.cfgEmpresa.Add(e);
            db.SaveChanges();
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
                    if (!File.Exists(dataBasePath))
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
                using var cmd = DbConnection(dataBasePath).CreateCommand();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS estado(id integer not null primary key autoincrement," +
                                                                    " Nome  Varchar(200)," +
                                                                    " Uf char(2)," +
                                                                    " Regiao integer)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS cidade(id integer not null primary key autoincrement," +
                                                                    " Nome  Varchar(200)," +
                                                                    " idEstado integer," +
                                                                    " foreign key (idEstado) references estado(id) )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS cfgEmpresa(id integer not null primary key autoincrement," +
                                                                        " nomeEmpresa  Varchar(200)," +
                                                                        " cnpj Varchar(16)," +
                                                                        " atividade Varchar(200)," +
                                                                        " endereco Varchar(200)," +
                                                                        " bairro varchar(100)," +
                                                                        " cep varchar(9)," +
                                                                        " idCidade integer," +
                                                                        " telefone Varchar(15)," +
                                                                        " celular Varchar(15)," +
                                                                        " chaveAcesso Varchar(500)," +
                                                                        " statusAtivacao Varchar(100)," +
                                                                        " dataInicioAtivacao DATETEXT," +
                                                                        " dataFimAtivacao DATETEXT," +
                                                                        " identificacaoCliente Varchar(15)," +
                                                                        " foreign key (idCidade) references cidade(id))";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS empresa(id integer not null primary key autoincrement," +
                                                                        " razaoSocial Varchar(200)," +
                                                                        " nomeFantasia Varchar(200)," +
                                                                        " cnpj Varchar(16)," +
                                                                        " atividade Varchar(200)," +
                                                                        " endereco Varchar(200)," +
                                                                        " bairro varchar(100)," +
                                                                        " cep varchar(9)," +
                                                                        " idCidade integer not null," +
                                                                        " socios Varchar(500)," +
                                                                        " percentualSocios Varchar(500)," +
                                                                        " telefone Varchar(15)," +
                                                                        " celular Varchar(15)," +
                                                                        " dataAbertura DATETEXT," +
                                                                        " observacao Varchar(500)," +
                                                                        " foreign key (idCidade) references cidade(id))";

                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS cfgNotificacao(id integer not null primary key autoincrement," +
                                                                            " emailFrom  VarChar(100)," +
                                                                            " emailTo VarChar(300)," +
                                                                            " emailSubject  VarChar(100)," +
                                                                            " emailBody  VarChar(500)," +
                                                                            " smtp  VarChar(100)," +
                                                                            " notificacaoWindows char(1)," +
                                                                            " notificacaoEmail char(1)," +
                                                                            " diasNotificacao integer not null)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS tipoRegistro(id integer not null primary key autoincrement," +
                                                                           " descricao  VarChar(200))";

                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS notificacao(id integer not null primary key autoincrement," +
                                                                         " descricao  VarChar(200) not null," +
                                                                         " idTipoRegistro integer not null," +
                                                                         " idEmpesa integer not null," +
                                                                         " dataInicalProcesso DATETEXT," +
                                                                         " dataFinalProcesso DATETEXT, " +
                                                                         " dataNotificacao DATETEXT, " +
                                                                         " observacao Varchar(500)," +
                                                                         " notificacaoFinalizada char(1)," +
                                                                         " foreign key (idTipoRegistro) references TipoRegistro(id)," +
                                                                         " foreign key(idEmpesa) references Empresa(id))";

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AdicionaEstados()
        {
            int qteRegistros = 0;
            using (var db = new Context())
            {
                qteRegistros = db.estado.Count();
            }
            if (qteRegistros == 0)
            {
                try
                {
                    using var cmd = DbConnection(dataBasePath).CreateCommand();
                    cmd.CommandText = Util.InsertEstado();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao Inserir dados na Tabela estado: " + ex.Message);
                }
            }

        }
        private void AdicionaCidades()
        {
            int qteRegistros = 0;
            using (var db = new Context())
            {
                qteRegistros = db.cidade.Count();
            }
            if (qteRegistros == 0)
            {
                try
                {
                    using var cmd = DbConnection(dataBasePath).CreateCommand();
                    cmd.CommandText = Util.InsertCidades();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Já existem dados: " + ex.Message);
                }
            }

        }

    }
}
