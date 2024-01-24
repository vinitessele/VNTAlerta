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
        private static string dbName = "bd.sqlite";
        private static string startupPath = Environment.CurrentDirectory + "\\DB\\";
        private static string dataBasePath = string.Empty;

        private static string chave = "Ajasklskeoessinmieosiusfoiweuwww";
        private static string empresa = "Empresa Teste";
        private static string cnpj = "12.123.123/0001-00";
        private static string chaveAcesso = "111-222-333-444-555-666-777-888-999";
        private static string statusAtivacao = Teste;
        int idCidade = 4127700;
        DateTime dataInicioAtivacao = DateTime.Now;
        DateTime expira = DateTime.Now.AddDays(30);
        private static string identificacaoCliente = "Test0000";
        private static string pathLicenca = startupPath + "\\Licença\\";
        private static string arquivoLicenca = startupPath + "\\Licença\\" + "\\reg.vnt";
        Model m = new();
        public FormAtivacao()
        {
            InitializeComponent();
            CriaBancoDados();
            CriarTabelaSQlite();
            AdicionaEstados();
            AdicionaCidades();
            CarregaDadosLicenca();
            labelVersao.Text = "Versão: 24.1.0";
        }

        private void CarregaDadosLicenca()
        {
            VerificaOuCriaArquivo();
            if (File.Exists(arquivoLicenca))
            {
                LerArquivoLicencaTela();
            }
        }

        private void LerArquivoLicencaTela()
        {
            string line;
            StreamReader sr = new(arquivoLicenca);
            line = sr.ReadLine();
            while (line != null)
            {
                try
                {
                    Crypt crypt = new();
                    string textoDescriptografado = crypt.Decrypt(line, chave);
                    labelEmpresa.Text = "Empresa: " + textoDescriptografado;
                    line = sr.ReadLine();
                    textoDescriptografado = crypt.Decrypt(line, chave);
                    labelCnpj.Text = "CNPJ: " + textoDescriptografado;
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    textoDescriptografado = crypt.Decrypt(line, chave);
                    labelExpira.Text = "Expira em: " + textoDescriptografado;
                    line = sr.ReadLine();
                    textoDescriptografado = crypt.Decrypt(line, chave);
                    labelIdentificacao.Text = "Identificação da Empresa: " + textoDescriptografado;
                    line = sr.ReadLine();
                }
                catch
                {
                    MessageBox.Show("Erro ao ler arquivo de licença", "VNT - Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw;
                }
            }
            sr.Close();
        }

        private DaoCfgEmpresa LerArquivoLicenca()
        {
            Crypt crypt = new();
            string line;
            string textoDescriptografado;
            DaoCfgEmpresa empresa = new DaoCfgEmpresa();
            StreamReader sr = new(arquivoLicenca);
            line = sr.ReadLine();
            while (line != null)
            {
                try
                {
                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.NomeEmpresa =  textoDescriptografado;
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.Cnpj = textoDescriptografado;
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.chaveAcesso = textoDescriptografado;
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.statusAtivacao = textoDescriptografado;
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.idCidade =int.Parse(textoDescriptografado);
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.dataInicioAtivacao = DateTime.Parse(textoDescriptografado);
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.dataFimAtivacao = DateTime.Parse(textoDescriptografado);
                    line = sr.ReadLine();

                    textoDescriptografado = crypt.Decrypt(line, chave);
                    empresa.identificacaoCliente = textoDescriptografado;
                    line = sr.ReadLine();
                }
                catch
                {
                    MessageBox.Show("Erro ao ler arquivo de licença", "VNT - Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw;
                }
            }
            sr.Close();
            return empresa;
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

                File.Delete(arquivoLicenca);
                
                FileInfo fi = new FileInfo(FiletextBox.Text);
                
                fi.MoveTo(arquivoLicenca);

                DaoCfgEmpresa empresa = LerArquivoLicenca();

                m.SetDadosEmpresa(empresa);

            }
        }
        public Boolean VerificaLicenca()
        {
            try
            {
                VerificaOuCriaArquivo();

                if (!File.Exists(arquivoLicenca))
                {
                    //Cria Licença de Demo
                    DaoCfgEmpresa e = new();
                    e.NomeEmpresa = empresa;
                    e.Cnpj = cnpj;
                    e.chaveAcesso = chaveAcesso;
                    e.statusAtivacao = statusAtivacao;
                    e.idCidade = idCidade;
                    e.dataInicioAtivacao = dataInicioAtivacao;
                    e.dataFimAtivacao = expira;
                    e.identificacaoCliente = identificacaoCliente;

                    CriaArquivo(e);
                    m.SetDadosEmpresa(e);
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
                            Crypt crypt = new();
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
                                    throw new InvalidOperationException();
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.Cnpj)
                                {
                                    line = sr.ReadLine();
                                    labelCnpj.Text = "CNPJ: " + textoDescriptografado;
                                }
                                else
                                {
                                    throw new InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.chaveAcesso)
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.statusAtivacao)
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado == e.idCidade.ToString())
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado.Substring(0, 10) == e.dataInicioAtivacao.ToString().Substring(0, 10))
                                {
                                    line = sr.ReadLine();
                                }
                                else
                                {
                                    throw new InvalidOperationException(msg);
                                }
                                textoDescriptografado = crypt.Decrypt(line, chave);
                                if (textoDescriptografado.Substring(0, 10) == e.dataFimAtivacao.ToString().Substring(0,10))
                                {
                                    line = sr.ReadLine();
                                    labelExpira.Text = "Expira em: " + textoDescriptografado;
                                }
                                else
                                {
                                    throw new InvalidOperationException(msg);
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
                                sr.Close();
                                MessageBox.Show(msg, "VNT - Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                throw;
                            }
                        }
                        sr.Close();
                    }
                }
            }
            catch
            {               
                MessageBox.Show("Falha ao verificar Licença de uso do Software", "VNT - Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
                throw;
            }
            return true;
        }
        private void VerificaOuCriaArquivo()
        {
            if (!Directory.Exists(pathLicenca))
                Directory.CreateDirectory(pathLicenca);
        }


        private void CriaBancoDados()
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
                                                                        " telefone Varchar(15)," +
                                                                        " celular Varchar(15)," +
                                                                        " dataAbertura DATETEXT," +
                                                                        " observacao Varchar(500)," +
                                                                        " foreign key (idCidade) references cidade(id))";

                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS socios(id integer not null primary key autoincrement," +
                                    " nome  Varchar(200)," +
                                    " percentualSocios numeric(10,2)," +
                                    " idEmpresa integer, " +
                                    " foreign key (idEmpresa) references empresa(id) )";
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
                                                                         " idEmpresa integer not null," +
                                                                         " dataInicalProcesso DATETEXT," +
                                                                         " dataFinalProcesso DATETEXT, " +
                                                                         " dataNotificacao DATETEXT, " +
                                                                         " observacao Varchar(500)," +
                                                                         " notificacaoFinalizada char(1)," +
                                                                         " foreign key (idTipoRegistro) references TipoRegistro(id)," +
                                                                         " foreign key(idEmpresa) references Empresa(id))";

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

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            string[] partes = textSerial.Text.Split('-');
            string identificadorEmpresa;
            string vencimento;
            identificadorEmpresa = partes[0].Substring(0, 1);
            identificadorEmpresa += partes[1].Substring(0, 1);
            identificadorEmpresa += partes[2].Substring(0, 1);
            identificadorEmpresa += partes[3].Substring(0, 1);
            identificadorEmpresa += partes[4].Substring(0, 4);

            vencimento = partes[0].Substring(3, 2) + "/";
            vencimento += partes[1].Substring(3, 2) + "/";
            vencimento += partes[2].Substring(3, 2);
            vencimento += partes[3].Substring(3, 2);

            m.AlteraRegistroEmpresa(identificadorEmpresa, vencimento, textSerial.Text);

            AlteraVntReg(identificadorEmpresa, vencimento, textSerial.Text);
        }

        private void AlteraVntReg(string identificadorEmpresa, string vencimento, string serial)
        {
            Context db = new();
            if (File.Exists(arquivoLicenca))
            {               
                File.Delete(arquivoLicenca);
                DaoCfgEmpresa d = db.cfgEmpresa.FirstOrDefault();
                
                if (d != null)
                {
                    CriaArquivo(d);
                }
            }
        }
        private void CriaArquivo(DaoCfgEmpresa e)
        {
            Crypt crypt = new();
            StreamWriter arquivo;
            // Criptografar
            arquivo = File.CreateText(arquivoLicenca);
            arquivo.WriteLine(crypt.Encrypt(e.NomeEmpresa, chave));
            arquivo.WriteLine(crypt.Encrypt(e.Cnpj, chave));
            arquivo.WriteLine(crypt.Encrypt(e.chaveAcesso, chave));
            arquivo.WriteLine(crypt.Encrypt(e.statusAtivacao, chave));
            arquivo.WriteLine(crypt.Encrypt(e.idCidade.ToString(), chave));
            arquivo.WriteLine(crypt.Encrypt(e.dataInicioAtivacao.ToString(), chave));
            arquivo.WriteLine(crypt.Encrypt(e.dataFimAtivacao.ToString(), chave));
            arquivo.WriteLine(crypt.Encrypt(e.identificacaoCliente, chave));
            arquivo.Close();
        }
    }
}
