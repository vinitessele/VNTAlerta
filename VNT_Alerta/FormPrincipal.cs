using Microsoft.Toolkit.Uwp.Notifications;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
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
        public FormPrincipal()
        {
            InitializeComponent();
            CriaBancoDados();
            CriarTabelaSQlite();
            AdicionaEstados();
            AdicionaCidades();
            EnviaEmail();
            Application_Startup();
        }

        private static SQLiteConnection DbConnection(string dataBasePath)
        {
            string caminho = "Data Source= " + dataBasePath + "; Version=3;";

            sqliteConnection = new SQLiteConnection(caminho);
            sqliteConnection.Open();
            return sqliteConnection;
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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS estado(CodigoUf integer not null primary key autoincrement," +
                                                                        " Nome  Varchar(200)," +
                                                                        " Uf char(2)," +
                                                                        " Regiao integer)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS cidade(id integer not null primary key autoincrement," +
                                                                        " Nome  Varchar(200)," +
                                                                        " id_estado integer)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS cfgEmpresa(id integer not null primary key autoincrement," +
                                                                            " NomeEmpresa  Varchar(200)," +
                                                                            " Cnpj Varchar(16)," +
                                                                            " Atividade Varchar(200)," +
                                                                            " Endereco Varchar(200)," +
                                                                            " Telefone Varchar(15)," +
                                                                            " DataAbertura DATETEXT," +
                                                                            " Observacao Varchar(500)," +
                                                                            " chaveAcesso Varchar(500)," +
                                                                            " statusAtivacao Varchar(100)," +
                                                                            " dataInicioAtivacao DATETEXT," +
                                                                            " dataFimAtivacao DATETEXT)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS cfgNotificacao(id integer not null primary key autoincrement," +
                                                                                " emailFrom  VarChar(100)," +
                                                                                " emailTo VarChar(300)," +
                                                                                " emailSubject  VarChar(100)," +
                                                                                " emailBody  VarChar(500)," +
                                                                                " smtp  VarChar(100)," +
                                                                                " notificacaoWindows char(1)," +
                                                                                " diasNotificacao integer)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS notificacao(id integer not null primary key autoincrement," +
                                                                            " descricao  VarChar(200)," +
                                                                            " dataNotificacao DATETEXT)";

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
            // Configura��es do servidor SMTP
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "vntnotificacao@gmail.com";
            string smtpPassword = "sifw qwdn xbmc gebh";

            // Endere�o de email do remetente
            string fromEmail = "vntnotificacao@gmail.com";

            // Endere�o de email do destinat�rio
            string toEmail = "vinicius_tessele@hotmail.com";

            // Criar objeto de mensagem
            MailMessage message = new MailMessage(fromEmail, toEmail);
            message.Subject = "Assunto do email";
            message.Body = "Conte�do do email";

            // Configurar cliente SMTP
            SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true; // Use SSL para conex�o segura
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
        private void AdicionaEstados()
        {
            try
            {
                using (var cmd = DbConnection(dataBasePath).CreateCommand())
                {
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (12, 'Acre', 'AC', 1)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (27, 'Alagoas', 'AL', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (16, 'Amap�', 'AP', 1)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (13, 'Amazonas', 'AM', 1)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (29, 'Bahia', 'BA', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (23, 'Cear�', 'CE', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (53, 'Distrito Federal', 'DF', 5)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (32, 'Esp�rito Santo', 'ES', 3)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (52, 'Goi�s', 'GO', 5)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (21, 'Maranh�o', 'MA', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (51, 'Mato Grosso', 'MT', 5)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (50, 'Mato Grosso do Sul', 'MS', 5)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (31, 'Minas Gerais', 'MG', 3)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (15, 'Par�', 'PA', 1)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (25, 'Para�ba', 'PB', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (41, 'Paran�', 'PR', 4)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (26, 'Pernambuco', 'PE', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (22, 'Piau�', 'PI', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (33, 'Rio de Janeiro', 'RJ', 3)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (24, 'Rio Grande do Norte', 'RN', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (43, 'Rio Grande do Sul', 'RS', 4)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (11, 'Rond�nia', 'RO', 1)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (14, 'Roraima', 'RR', 1)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (42, 'Santa Catarina', 'SC', 4)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (35, 'S�o Paulo', 'SP', 3)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (28, 'Sergipe', 'SE', 2)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Insert into Estado (CodigoUf, Nome, Uf, Regiao) values (17, 'Tocantins', 'TO', 1)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AdicionaCidades()
        {
            try
            {
                using (var cmd = DbConnection(dataBasePath).CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO cidade (id, id_estado, Nome) VALUES " +
                    "(1100015,11,'Alta Floresta Doeste')," +
                    "(1100023,11,'Ariquemes')," +
                    "(1100031,11,'Cabixi')," +
                    "(1100049,11,'Cacoal')," +
                    "(1100056,11,'Cerejeiras')," +
                    "(1100064,11,'Colorado do Oeste')," +
                    "(1100072,11,'Corumbiara')," +
                    "(1100080,11,'Costa Marques')," +
                    "(1100098,11,'Espig�o Doeste')," +
                    "(1100106,11,'Guajar�-Mirim')," +
                    "(1100114,11,'Jaru')," +
                    "(1100122,11,'Ji-Paran�')," +
                    "(1100130,11,'Machadinho Doeste')," +
                    "(1100148,11,'Nova Brasil�ndia Doeste')," +
                    "(1100155,11,'Ouro Preto do Oeste')," +
                    "(1100189,11,'Pimenta Bueno')," +
                    "(1100205,11,'Porto Velho')," +
                    "(1100254,11,'Presidente M�dici')," +
                    "(1100262,11,'Rio Crespo')," +
                    "(1100288,11,'Rolim de Moura')," +
                    "(1100296,11,'Santa Luzia Doeste')," +
                    "(1100304,11,'Vilhena')," +
                    "(1100320,11,'S�o Miguel do Guapor�')," +
                    "(1100338,11,'Nova Mamor�')," +
                    "(1100346,11,'Alvorada Doeste')," +
                    "(1100379,11,'Alto Alegre dos Parecis')," +
                    "(1100403,11,'Alto Para�so')," +
                    "(1100452,11,'Buritis')," +
                    "(1100502,11,'Novo Horizonte do Oeste')," +
                    "(1100601,11,'Cacaul�ndia')," +
                    "(1100700,11,'Campo Novo de Rond�nia')," +
                    "(1100809,11,'Candeias do Jamari')," +
                    "(1100908,11,'Castanheiras')," +
                    "(1100924,11,'Chupinguaia')," +
                    "(1100940,11,'Cujubim')," +
                    "(1101005,11,'Governador Jorge Teixeira')," +
                    "(1101104,11,'Itapu� do Oeste')," +
                    "(1101203,11,'Ministro Andreazza')," +
                    "(1101302,11,'Mirante da Serra')," +
                    "(1101401,11,'Monte Negro')," +
                    "(1101435,11,'Nova Uni�o')," +
                    "(1101450,11,'Parecis')," +
                    "(1101468,11,'Pimenteiras do Oeste')," +
                    "(1101476,11,'Primavera de Rond�nia')," +
                    "(1101484,11,'S�o Felipe Doeste')," +
                    "(1101492,11,'S�o Francisco do Guapor�')," +
                    "(1101500,11,'Seringueiras')," +
                    "(1101559,11,'Teixeir�polis')," +
                    "(1101609,11,'Theobroma')," +
                    "(1101708,11,'Urup�')," +
                    "(1101757,11,'Vale do Anari')," +
                    "(1101807,11,'Vale do Para�so')," +
                    "(1200013,12,'Acrel�ndia')," +
                    "(1200054,12,'Assis Brasil')," +
                    "(1200104,12,'Brasil�ia')," +
                    "(1200138,12,'Bujari')," +
                    "(1200179,12,'Capixaba')," +
                    "(1200203,12,'Cruzeiro do Sul')," +
                    "(1200252,12,'Epitaciol�ndia')," +
                    "(1200302,12,'Feij�')," +
                    "(1200328,12,'Jord�o')," +
                    "(1200336,12,'M�ncio Lima')," +
                    "(1200344,12,'Manoel Urbano')," +
                    "(1200351,12,'Marechal Thaumaturgo')," +
                    "(1200385,12,'Pl�cido de Castro')," +
                    "(1200393,12,'Porto Walter')," +
                    "(1200401,12,'Rio Branco')," +
                    "(1200427,12,'Rodrigues Alves')," +
                    "(1200435,12,'Santa Rosa do Purus')," +
                    "(1200450,12,'Senador Guiomard')," +
                    "(1200500,12,'Sena Madureira')," +
                    "(1200609,12,'Tarauac�')," +
                    "(1200708,12,'Xapuri')," +
                    "(1200807,12,'Porto Acre')," +
                    "(1300029,13,'Alvar�es')," +
                    "(1300060,13,'Amatur�')," +
                    "(1300086,13,'Anam�')," +
                    "(1300102,13,'Anori')," +
                    "(1300144,13,'Apu�')," +
                    "(1300201,13,'Atalaia do Norte')," +
                    "(1300300,13,'Autazes')," +
                    "(1300409,13,'Barcelos')," +
                    "(1300508,13,'Barreirinha')," +
                    "(1300607,13,'Benjamin Constant')," +
                    "(1300631,13,'Beruri')," +
                    "(1300680,13,'Boa Vista do Ramos')," +
                    "(1300706,13,'Boca do Acre')," +
                    "(1300805,13,'Borba')," +
                    "(1300839,13,'Caapiranga')," +
                    "(1300904,13,'Canutama')," +
                    "(1301001,13,'Carauari')," +
                    "(1301100,13,'Careiro')," +
                    "(1301159,13,'Careiro da V�rzea')," +
                    "(1301209,13,'Coari')," +
                    "(1301308,13,'Codaj�s')," +
                    "(1301407,13,'Eirunep�')," +
                    "(1301506,13,'Envira')," +
                    "(1301605,13,'Fonte Boa')," +
                    "(1301654,13,'Guajar�')," +
                    "(1301704,13,'Humait�')," +
                    "(1301803,13,'Ipixuna')," +
                    "(1301852,13,'Iranduba')," +
                    "(1301902,13,'Itacoatiara')," +
                    "(1301951,13,'Itamarati')," +
                    "(1302009,13,'Itapiranga')," +
                    "(1302108,13,'Japur�')," +
                    "(1302207,13,'Juru�')," +
                    "(1302306,13,'Juta�')," +
                    "(1302405,13,'L�brea')," +
                    "(1302504,13,'Manacapuru')," +
                    "(1302553,13,'Manaquiri')," +
                    "(1302603,13,'Manaus')," +
                    "(1302702,13,'Manicor�')," +
                    "(1302801,13,'Mara�')," +
                    "(1302900,13,'Mau�s')," +
                    "(1303007,13,'Nhamund�')," +
                    "(1303106,13,'Nova Olinda do Norte')," +
                    "(1303205,13,'Novo Air�o')," +
                    "(1303304,13,'Novo Aripuan�')," +
                    "(1303403,13,'Parintins')," +
                    "(1303502,13,'Pauini')," +
                    "(1303536,13,'Presidente Figueiredo')," +
                    "(1303569,13,'Rio Preto da Eva')," +
                    "(1303601,13,'Santa Isabel do Rio Negro')," +
                    "(1303700,13,'Santo Ant�nio do I��')," +
                    "(1303809,13,'S�o Gabriel da Cachoeira')," +
                    "(1303908,13,'S�o Paulo de Oliven�a')," +
                    "(1303957,13,'S�o Sebasti�o do Uatum�')," +
                    "(1304005,13,'Silves')," +
                    "(1304062,13,'Tabatinga')," +
                    "(1304104,13,'Tapau�')," +
                    "(1304203,13,'Tef�')," +
                    "(1304237,13,'Tonantins')," +
                    "(1304260,13,'Uarini')," +
                    "(1304302,13,'Urucar�')," +
                    "(1304401,13,'Urucurituba')," +
                    "(1400027,14,'Amajari')," +
                    "(1400050,14,'Alto Alegre')," +
                    "(1400100,14,'Boa Vista')," +
                    "(1400159,14,'Bonfim')," +
                    "(1400175,14,'Cant�')," +
                    "(1400209,14,'Caracara�')," +
                    "(1400233,14,'Caroebe')," +
                    "(1400282,14,'Iracema')," +
                    "(1400308,14,'Mucaja�')," +
                    "(1400407,14,'Normandia')," +
                    "(1400456,14,'Pacaraima')," +
                    "(1400472,14,'Rorain�polis')," +
                    "(1400506,14,'S�o Jo�o da Baliza')," +
                    "(1400605,14,'S�o Luiz')," +
                    "(1400704,14,'Uiramut�')," +
                    "(1500107,15,'Abaetetuba')," +
                    "(1500131,15,'Abel Figueiredo')," +
                    "(1500206,15,'Acar�')," +
                    "(1500305,15,'Afu�')," +
                    "(1500347,15,'�gua Azul do Norte')," +
                    "(1500404,15,'Alenquer')," +
                    "(1500503,15,'Almeirim')," +
                    "(1500602,15,'Altamira')," +
                    "(1500701,15,'Anaj�s')," +
                    "(1500800,15,'Ananindeua')," +
                    "(1500859,15,'Anapu')," +
                    "(1500909,15,'Augusto Corr�a')," +
                    "(1500958,15,'Aurora do Par�')," +
                    "(1501006,15,'Aveiro')," +
                    "(1501105,15,'Bagre')," +
                    "(1501204,15,'Bai�o')," +
                    "(1501253,15,'Bannach')," +
                    "(1501303,15,'Barcarena')," +
                    "(1501402,15,'Bel�m')," +
                    "(1501451,15,'Belterra')," +
                    "(1501501,15,'Benevides')," +
                    "(1501576,15,'Bom Jesus do Tocantins')," +
                    "(1501600,15,'Bonito')," +
                    "(1501709,15,'Bragan�a')," +
                    "(1501725,15,'Brasil Novo')," +
                    "(1501758,15,'Brejo Grande do Araguaia')," +
                    "(1501782,15,'Breu Branco')," +
                    "(1501808,15,'Breves')," +
                    "(1501907,15,'Bujaru')," +
                    "(1501956,15,'Cachoeira do Piri�')," +
                    "(1502004,15,'Cachoeira do Arari')," +
                    "(1502103,15,'Camet�')," +
                    "(1502152,15,'Cana� dos Caraj�s')," +
                    "(1502202,15,'Capanema')," +
                    "(1502301,15,'Capit�o Po�o')," +
                    "(1502400,15,'Castanhal')," +
                    "(1502509,15,'Chaves')," +
                    "(1502608,15,'Colares')," +
                    "(1502707,15,'Concei��o do Araguaia')," +
                    "(1502756,15,'Conc�rdia do Par�')," +
                    "(1502764,15,'Cumaru do Norte')," +
                    "(1502772,15,'Curion�polis')," +
                    "(1502806,15,'Curralinho')," +
                    "(1502855,15,'Curu�')," +
                    "(1502905,15,'Curu��')," +
                    "(1502939,15,'dom Eliseu')," +
                    "(1502954,15,'Eldorado do Caraj�s')," +
                    "(1503002,15,'Faro')," +
                    "(1503044,15,'Floresta do Araguaia')," +
                    "(1503077,15,'Garraf�o do Norte')," +
                    "(1503093,15,'Goian�sia do Par�')," +
                    "(1503101,15,'Gurup�')," +
                    "(1503200,15,'Igarap�-A�u')," +
                    "(1503309,15,'Igarap�-Miri')," +
                    "(1503408,15,'Inhangapi')," +
                    "(1503457,15,'Ipixuna do Par�')," +
                    "(1503507,15,'Irituia')," +
                    "(1503606,15,'Itaituba')," +
                    "(1503705,15,'Itupiranga')," +
                    "(1503754,15,'Jacareacanga')," +
                    "(1503804,15,'Jacund�')," +
                    "(1503903,15,'Juruti')," +
                    "(1504000,15,'Limoeiro do Ajuru')," +
                    "(1504059,15,'M�e do Rio')," +
                    "(1504109,15,'Magalh�es Barata')," +
                    "(1504208,15,'Marab�')," +
                    "(1504307,15,'Maracan�')," +
                    "(1504406,15,'Marapanim')," +
                    "(1504422,15,'Marituba')," +
                    "(1504455,15,'Medicil�ndia')," +
                    "(1504505,15,'Melga�o')," +
                    "(1504604,15,'Mocajuba')," +
                    "(1504703,15,'Moju')," +
                    "(1504752,15,'Moju� dos Campos')," +
                    "(1504802,15,'Monte Alegre')," +
                    "(1504901,15,'Muan�')," +
                    "(1504950,15,'Nova Esperan�a do Piri�')," +
                    "(1504976,15,'Nova Ipixuna')," +
                    "(1505007,15,'Nova Timboteua')," +
                    "(1505031,15,'Novo Progresso')," +
                    "(1505064,15,'Novo Repartimento')," +
                    "(1505106,15,'�bidos')," +
                    "(1505205,15,'Oeiras do Par�')," +
                    "(1505304,15,'Oriximin�')," +
                    "(1505403,15,'Our�m')," +
                    "(1505437,15,'Ouril�ndia do Norte')," +
                    "(1505486,15,'Pacaj�')," +
                    "(1505494,15,'Palestina do Par�')," +
                    "(1505502,15,'Paragominas')," +
                    "(1505536,15,'Parauapebas')," +
                    "(1505551,15,'Pau Darco')," +
                    "(1505601,15,'Peixe-Boi')," +
                    "(1505635,15,'Pi�arra')," +
                    "(1505650,15,'Placas')," +
                    "(1505700,15,'Ponta de Pedras')," +
                    "(1505809,15,'Portel')," +
                    "(1505908,15,'Porto de Moz')," +
                    "(1506005,15,'Prainha')," +
                    "(1506104,15,'Primavera')," +
                    "(1506112,15,'Quatipuru')," +
                    "(1506138,15,'Reden��o')," +
                    "(1506161,15,'Rio Maria')," +
                    "(1506187,15,'Rondon do Par�')," +
                    "(1506195,15,'Rur�polis')," +
                    "(1506203,15,'Salin�polis')," +
                    "(1506302,15,'Salvaterra')," +
                    "(1506351,15,'Santa B�rbara do Par�')," +
                    "(1506401,15,'Santa Cruz do Arari')," +
                    "(1506500,15,'Santa Izabel do Par�')," +
                    "(1506559,15,'Santa Luzia do Par�')," +
                    "(1506583,15,'Santa Maria das Barreiras')," +
                    "(1506609,15,'Santa Maria do Par�')," +
                    "(1506708,15,'Santana do Araguaia')," +
                    "(1506807,15,'Santar�m')," +
                    "(1506906,15,'Santar�m Novo')," +
                    "(1507003,15,'Santo Ant�nio do Tau�')," +
                    "(1507102,15,'S�o Caetano de Odivelas')," +
                    "(1507151,15,'S�o domingos do Araguaia')," +
                    "(1507201,15,'S�o domingos do Capim')," +
                    "(1507300,15,'S�o F�lix do Xingu')," +
                    "(1507409,15,'S�o Francisco do Par�')," +
                    "(1507458,15,'S�o Geraldo do Araguaia')," +
                    "(1507466,15,'S�o Jo�o da Ponta')," +
                    "(1507474,15,'S�o Jo�o de Pirabas')," +
                    "(1507508,15,'S�o Jo�o do Araguaia')," +
                    "(1507607,15,'S�o Miguel do Guam�')," +
                    "(1507706,15,'S�o Sebasti�o da Boa Vista')," +
                    "(1507755,15,'Sapucaia')," +
                    "(1507805,15,'Senador Jos� Porf�rio')," +
                    "(1507904,15,'Soure')," +
                    "(1507953,15,'Tail�ndia')," +
                    "(1507961,15,'Terra Alta')," +
                    "(1507979,15,'Terra Santa')," +
                    "(1508001,15,'Tom�-A�u')," +
                    "(1508035,15,'Tracuateua')," +
                    "(1508050,15,'Trair�o')," +
                    "(1508084,15,'Tucum�')," +
                    "(1508100,15,'Tucuru�')," +
                    "(1508126,15,'Ulian�polis')," +
                    "(1508159,15,'Uruar�')," +
                    "(1508209,15,'Vigia')," +
                    "(1508308,15,'Viseu')," +
                    "(1508357,15,'Vit�ria do Xingu')," +
                    "(1508407,15,'Xinguara')," +
                    "(1600055,16,'Serra do Navio')," +
                    "(1600105,16,'Amap�')," +
                    "(1600154,16,'Pedra Branca do Amapari')," +
                    "(1600204,16,'Cal�oene')," +
                    "(1600212,16,'Cutias')," +
                    "(1600238,16,'Ferreira Gomes')," +
                    "(1600253,16,'Itaubal')," +
                    "(1600279,16,'Laranjal do Jari')," +
                    "(1600303,16,'Macap�')," +
                    "(1600402,16,'Mazag�o')," +
                    "(1600501,16,'Oiapoque')," +
                    "(1600535,16,'Porto Grande')," +
                    "(1600550,16,'Pracu�ba')," +
                    "(1600600,16,'Santana')," +
                    "(1600709,16,'Tartarugalzinho')," +
                    "(1600808,16,'Vit�ria do Jari')," +
                    "(1700251,17,'Abreul�ndia')," +
                    "(1700301,17,'Aguiarn�polis')," +
                    "(1700350,17,'Alian�a do Tocantins')," +
                    "(1700400,17,'Almas')," +
                    "(1700707,17,'Alvorada')," +
                    "(1701002,17,'Anan�s')," +
                    "(1701051,17,'Angico')," +
                    "(1701101,17,'Aparecida do Rio Negro')," +
                    "(1701309,17,'Aragominas')," +
                    "(1701903,17,'Araguacema')," +
                    "(1702000,17,'Aragua�u')," +
                    "(1702109,17,'Aragua�na')," +
                    "(1702158,17,'Araguan�')," +
                    "(1702208,17,'Araguatins')," +
                    "(1702307,17,'Arapoema')," +
                    "(1702406,17,'Arraias')," +
                    "(1702554,17,'Augustin�polis')," +
                    "(1702703,17,'Aurora do Tocantins')," +
                    "(1702901,17,'Axix� do Tocantins')," +
                    "(1703008,17,'Baba�ul�ndia')," +
                    "(1703057,17,'Bandeirantes do Tocantins')," +
                    "(1703073,17,'Barra do Ouro')," +
                    "(1703107,17,'Barrol�ndia')," +
                    "(1703206,17,'Bernardo Say�o')," +
                    "(1703305,17,'Bom Jesus do Tocantins')," +
                    "(1703602,17,'Brasil�ndia do Tocantins')," +
                    "(1703701,17,'Brejinho de Nazar�')," +
                    "(1703800,17,'Buriti do Tocantins')," +
                    "(1703826,17,'Cachoeirinha')," +
                    "(1703842,17,'Campos Lindos')," +
                    "(1703867,17,'Cariri do Tocantins')," +
                    "(1703883,17,'Carmol�ndia')," +
                    "(1703891,17,'Carrasco Bonito')," +
                    "(1703909,17,'Caseara')," +
                    "(1704105,17,'Centen�rio')," +
                    "(1704600,17,'Chapada de Areia')," +
                    "(1705102,17,'Chapada da Natividade')," +
                    "(1705508,17,'Colinas do Tocantins')," +
                    "(1705557,17,'Combinado')," +
                    "(1705607,17,'Concei��o do Tocantins')," +
                    "(1706001,17,'Couto Magalh�es')," +
                    "(1706100,17,'Cristal�ndia')," +
                    "(1706258,17,'Crix�s do Tocantins')," +
                    "(1706506,17,'darcin�polis')," +
                    "(1707009,17,'Dian�polis')," +
                    "(1707108,17,'Divin�polis do Tocantins')," +
                    "(1707207,17,'dois Irm�os do Tocantins')," +
                    "(1707306,17,'Duer�')," +
                    "(1707405,17,'Esperantina')," +
                    "(1707553,17,'F�tima')," +
                    "(1707652,17,'Figueir�polis')," +
                    "(1707702,17,'Filad�lfia')," +
                    "(1708205,17,'Formoso do Araguaia')," +
                    "(1708254,17,'Fortaleza do Taboc�o')," +
                    "(1708304,17,'Goianorte')," +
                    "(1709005,17,'Goiatins')," +
                    "(1709302,17,'Guara�')," +
                    "(1709500,17,'Gurupi')," +
                    "(1709807,17,'Ipueiras')," +
                    "(1710508,17,'Itacaj�')," +
                    "(1710706,17,'Itaguatins')," +
                    "(1710904,17,'Itapiratins')," +
                    "(1711100,17,'Itapor� do Tocantins')," +
                    "(1711506,17,'Ja� do Tocantins')," +
                    "(1711803,17,'Juarina')," +
                    "(1711902,17,'Lagoa da Confus�o')," +
                    "(1711951,17,'Lagoa do Tocantins')," +
                    "(1712009,17,'Lajeado')," +
                    "(1712157,17,'Lavandeira')," +
                    "(1712405,17,'Lizarda')," +
                    "(1712454,17,'Luzin�polis')," +
                    "(1712504,17,'Marian�polis do Tocantins')," +
                    "(1712702,17,'Mateiros')," +
                    "(1712801,17,'Mauril�ndia do Tocantins')," +
                    "(1713205,17,'Miracema do Tocantins')," +
                    "(1713304,17,'Miranorte')," +
                    "(1713601,17,'Monte do Carmo')," +
                    "(1713700,17,'Monte Santo do Tocantins')," +
                    "(1713809,17,'Palmeiras do Tocantins')," +
                    "(1713957,17,'Muricil�ndia')," +
                    "(1714203,17,'Natividade')," +
                    "(1714302,17,'Nazar�')," +
                    "(1714880,17,'Nova Olinda')," +
                    "(1715002,17,'Nova Rosal�ndia')," +
                    "(1715101,17,'Novo Acordo')," +
                    "(1715150,17,'Novo Alegre')," +
                    "(1715259,17,'Novo Jardim')," +
                    "(1715507,17,'Oliveira de F�tima')," +
                    "(1715705,17,'Palmeirante')," +
                    "(1715754,17,'Palmeir�polis')," +
                    "(1716109,17,'Para�so do Tocantins')," +
                    "(1716208,17,'Paran�')," +
                    "(1716307,17,'Pau Darco')," +
                    "(1716505,17,'Pedro Afonso')," +
                    "(1716604,17,'Peixe')," +
                    "(1716653,17,'Pequizeiro')," +
                    "(1716703,17,'Colm�ia')," +
                    "(1717008,17,'Pindorama do Tocantins')," +
                    "(1717206,17,'Piraqu�')," +
                    "(1717503,17,'Pium')," +
                    "(1717800,17,'Ponte Alta do Bom Jesus')," +
                    "(1717909,17,'Ponte Alta do Tocantins')," +
                    "(1718006,17,'Porto Alegre do Tocantins')," +
                    "(1718204,17,'Porto Nacional')," +
                    "(1718303,17,'Praia Norte')," +
                    "(1718402,17,'Presidente Kennedy')," +
                    "(1718451,17,'Pugmil')," +
                    "(1718501,17,'Recursol�ndia')," +
                    "(1718550,17,'Riachinho')," +
                    "(1718659,17,'Rio da Concei��o')," +
                    "(1718709,17,'Rio dos Bois')," +
                    "(1718758,17,'Rio Sono')," +
                    "(1718808,17,'Sampaio')," +
                    "(1718840,17,'Sandol�ndia')," +
                    "(1718865,17,'Santa F� do Araguaia')," +
                    "(1718881,17,'Santa Maria do Tocantins')," +
                    "(1718899,17,'Santa Rita do Tocantins')," +
                    "(1718907,17,'Santa Rosa do Tocantins')," +
                    "(1719004,17,'Santa Tereza do Tocantins')," +
                    "(1720002,17,'Santa Terezinha do Tocantins')," +
                    "(1720101,17,'S�o Bento do Tocantins')," +
                    "(1720150,17,'S�o F�lix do Tocantins')," +
                    "(1720200,17,'S�o Miguel do Tocantins')," +
                    "(1720259,17,'S�o Salvador do Tocantins')," +
                    "(1720309,17,'S�o Sebasti�o do Tocantins')," +
                    "(1720499,17,'S�o Val�rio')," +
                    "(1720655,17,'Silvan�polis')," +
                    "(1720804,17,'S�tio Novo do Tocantins')," +
                    "(1720853,17,'Sucupira')," +
                    "(1720903,17,'Taguatinga')," +
                    "(1720937,17,'Taipas do Tocantins')," +
                    "(1720978,17,'Talism�')," +
                    "(1721000,17,'Palmas')," +
                    "(1721109,17,'Tocant�nia')," +
                    "(1721208,17,'Tocantin�polis')," +
                    "(1721257,17,'Tupirama')," +
                    "(1721307,17,'Tupiratins')," +
                    "(1722081,17,'Wanderl�ndia')," +
                    "(1722107,17,'Xambio�')," +
                    "(2100055,21,'A�ail�ndia')," +
                    "(2100105,21,'Afonso Cunha')," +
                    "(2100154,21,'�gua doce do Maranh�o')," +
                    "(2100204,21,'Alc�ntara')," +
                    "(2100303,21,'Aldeias Altas')," +
                    "(2100402,21,'Altamira do Maranh�o')," +
                    "(2100436,21,'Alto Alegre do Maranh�o')," +
                    "(2100477,21,'Alto Alegre do Pindar�')," +
                    "(2100501,21,'Alto Parna�ba')," +
                    "(2100550,21,'Amap� do Maranh�o')," +
                    "(2100600,21,'Amarante do Maranh�o')," +
                    "(2100709,21,'Anajatuba')," +
                    "(2100808,21,'Anapurus')," +
                    "(2100832,21,'Apicum-A�u')," +
                    "(2100873,21,'Araguan�')," +
                    "(2100907,21,'Araioses')," +
                    "(2100956,21,'Arame')," +
                    "(2101004,21,'Arari')," +
                    "(2101103,21,'Axix�')," +
                    "(2101202,21,'Bacabal')," +
                    "(2101251,21,'Bacabeira')," +
                    "(2101301,21,'Bacuri')," +
                    "(2101350,21,'Bacurituba')," +
                    "(2101400,21,'Balsas')," +
                    "(2101509,21,'Bar�o de Graja�')," +
                    "(2101608,21,'Barra do Corda')," +
                    "(2101707,21,'Barreirinhas')," +
                    "(2101731,21,'Bel�gua')," +
                    "(2101772,21,'Bela Vista do Maranh�o')," +
                    "(2101806,21,'Benedito Leite')," +
                    "(2101905,21,'Bequim�o')," +
                    "(2101939,21,'Bernardo do Mearim')," +
                    "(2101970,21,'Boa Vista do Gurupi')," +
                    "(2102002,21,'Bom Jardim')," +
                    "(2102036,21,'Bom Jesus das Selvas')," +
                    "(2102077,21,'Bom Lugar')," +
                    "(2102101,21,'Brejo')," +
                    "(2102150,21,'Brejo de Areia')," +
                    "(2102200,21,'Buriti')," +
                    "(2102309,21,'Buriti Bravo')," +
                    "(2102325,21,'Buriticupu')," +
                    "(2102358,21,'Buritirana')," +
                    "(2102374,21,'Cachoeira Grande')," +
                    "(2102408,21,'Cajapi�')," +
                    "(2102507,21,'Cajari')," +
                    "(2102556,21,'Campestre do Maranh�o')," +
                    "(2102606,21,'C�ndido Mendes')," +
                    "(2102705,21,'Cantanhede')," +
                    "(2102754,21,'Capinzal do Norte')," +
                    "(2102804,21,'Carolina')," +
                    "(2102903,21,'Carutapera')," +
                    "(2103000,21,'Caxias')," +
                    "(2103109,21,'Cedral')," +
                    "(2103125,21,'Central do Maranh�o')," +
                    "(2103158,21,'Centro do Guilherme')," +
                    "(2103174,21,'Centro Novo do Maranh�o')," +
                    "(2103208,21,'Chapadinha')," +
                    "(2103257,21,'Cidel�ndia')," +
                    "(2103307,21,'Cod�')," +
                    "(2103406,21,'Coelho Neto')," +
                    "(2103505,21,'Colinas')," +
                    "(2103554,21,'Concei��o do Lago-A�u')," +
                    "(2103604,21,'Coroat�')," +
                    "(2103703,21,'Cururupu')," +
                    "(2103752,21,'davin�polis')," +
                    "(2103802,21,'dom Pedro')," +
                    "(2103901,21,'Duque Bacelar')," +
                    "(2104008,21,'Esperantin�polis')," +
                    "(2104057,21,'Estreito')," +
                    "(2104073,21,'Feira Nova do Maranh�o')," +
                    "(2104081,21,'Fernando Falc�o')," +
                    "(2104099,21,'Formosa da Serra Negra')," +
                    "(2104107,21,'Fortaleza dos Nogueiras')," +
                    "(2104206,21,'Fortuna')," +
                    "(2104305,21,'Godofredo Viana')," +
                    "(2104404,21,'Gon�alves Dias')," +
                    "(2104503,21,'Governador Archer')," +
                    "(2104552,21,'Governador Edison Lob�o')," +
                    "(2104602,21,'Governador Eug�nio Barros')," +
                    "(2104628,21,'Governador Luiz Rocha')," +
                    "(2104651,21,'Governador Newton Bello')," +
                    "(2104677,21,'Governador Nunes Freire')," +
                    "(2104701,21,'Gra�a Aranha')," +
                    "(2104800,21,'Graja�')," +
                    "(2104909,21,'Guimar�es')," +
                    "(2105005,21,'Humberto de Campos')," +
                    "(2105104,21,'Icatu')," +
                    "(2105153,21,'Igarap� do Meio')," +
                    "(2105203,21,'Igarap� Grande')," +
                    "(2105302,21,'Imperatriz')," +
                    "(2105351,21,'Itaipava do Graja�')," +
                    "(2105401,21,'Itapecuru Mirim')," +
                    "(2105427,21,'Itinga do Maranh�o')," +
                    "(2105450,21,'Jatob�')," +
                    "(2105476,21,'Jenipapo dos Vieiras')," +
                    "(2105500,21,'Jo�o Lisboa')," +
                    "(2105609,21,'Josel�ndia')," +
                    "(2105658,21,'Junco do Maranh�o')," +
                    "(2105708,21,'Lago da Pedra')," +
                    "(2105807,21,'Lago do Junco')," +
                    "(2105906,21,'Lago Verde')," +
                    "(2105922,21,'Lagoa do Mato')," +
                    "(2105948,21,'Lago dos Rodrigues')," +
                    "(2105963,21,'Lagoa Grande do Maranh�o')," +
                    "(2105989,21,'Lajeado Novo')," +
                    "(2106003,21,'Lima Campos')," +
                    "(2106102,21,'Loreto')," +
                    "(2106201,21,'Lu�s domingues')," +
                    "(2106300,21,'Magalh�es de Almeida')," +
                    "(2106326,21,'Maraca�um�')," +
                    "(2106359,21,'Maraj� do Sena')," +
                    "(2106375,21,'Maranh�ozinho')," +
                    "(2106409,21,'Mata Roma')," +
                    "(2106508,21,'Matinha')," +
                    "(2106607,21,'Mat�es')," +
                    "(2106631,21,'Mat�es do Norte')," +
                    "(2106672,21,'Milagres do Maranh�o')," +
                    "(2106706,21,'Mirador')," +
                    "(2106755,21,'Miranda do Norte')," +
                    "(2106805,21,'Mirinzal')," +
                    "(2106904,21,'Mon��o')," +
                    "(2107001,21,'Montes Altos')," +
                    "(2107100,21,'Morros')," +
                    "(2107209,21,'Nina Rodrigues')," +
                    "(2107258,21,'Nova Colinas')," +
                    "(2107308,21,'Nova Iorque')," +
                    "(2107357,21,'Nova Olinda do Maranh�o')," +
                    "(2107407,21,'Olho D�gua das Cunh�s')," +
                    "(2107456,21,'Olinda Nova do Maranh�o')," +
                    "(2107506,21,'Pa�o do Lumiar')," +
                    "(2107605,21,'Palmeir�ndia')," +
                    "(2107704,21,'Paraibano')," +
                    "(2107803,21,'Parnarama')," +
                    "(2107902,21,'Passagem Franca')," +
                    "(2108009,21,'Pastos Bons')," +
                    "(2108058,21,'Paulino Neves')," +
                    "(2108108,21,'Paulo Ramos')," +
                    "(2108207,21,'Pedreiras')," +
                    "(2108256,21,'Pedro do Ros�rio')," +
                    "(2108306,21,'Penalva')," +
                    "(2108405,21,'Peri Mirim')," +
                    "(2108454,21,'Peritor�')," +
                    "(2108504,21,'Pindar�-Mirim')," +
                    "(2108603,21,'Pinheiro')," +
                    "(2108702,21,'Pio Xii')," +
                    "(2108801,21,'Pirapemas')," +
                    "(2108900,21,'Po��o de Pedras')," +
                    "(2109007,21,'Porto Franco')," +
                    "(2109056,21,'Porto Rico do Maranh�o')," +
                    "(2109106,21,'Presidente Dutra')," +
                    "(2109205,21,'Presidente Juscelino')," +
                    "(2109239,21,'Presidente M�dici')," +
                    "(2109270,21,'Presidente Sarney')," +
                    "(2109304,21,'Presidente Vargas')," +
                    "(2109403,21,'Primeira Cruz')," +
                    "(2109452,21,'Raposa')," +
                    "(2109502,21,'Riach�o')," +
                    "(2109551,21,'Ribamar Fiquene')," +
                    "(2109601,21,'Ros�rio')," +
                    "(2109700,21,'Samba�ba')," +
                    "(2109759,21,'Santa Filomena do Maranh�o')," +
                    "(2109809,21,'Santa Helena')," +
                    "(2109908,21,'Santa In�s')," +
                    "(2110005,21,'Santa Luzia')," +
                    "(2110039,21,'Santa Luzia do Paru�')," +
                    "(2110104,21,'Santa Quit�ria do Maranh�o')," +
                    "(2110203,21,'Santa Rita')," +
                    "(2110237,21,'Santana do Maranh�o')," +
                    "(2110278,21,'Santo Amaro do Maranh�o')," +
                    "(2110302,21,'Santo Ant�nio dos Lopes')," +
                    "(2110401,21,'S�o Benedito do Rio Preto')," +
                    "(2110500,21,'S�o Bento')," +
                    "(2110609,21,'S�o Bernardo')," +
                    "(2110658,21,'S�o domingos do Azeit�o')," +
                    "(2110708,21,'S�o domingos do Maranh�o')," +
                    "(2110807,21,'S�o F�lix de Balsas')," +
                    "(2110856,21,'S�o Francisco do Brej�o')," +
                    "(2110906,21,'S�o Francisco do Maranh�o')," +
                    "(2111003,21,'S�o Jo�o Batista')," +
                    "(2111029,21,'S�o Jo�o do Car�')," +
                    "(2111052,21,'S�o Jo�o do Para�so')," +
                    "(2111078,21,'S�o Jo�o do Soter')," +
                    "(2111102,21,'S�o Jo�o dos Patos')," +
                    "(2111201,21,'S�o Jos� de Ribamar')," +
                    "(2111250,21,'S�o Jos� dos Bas�lios')," +
                    "(2111300,21,'S�o Lu�s')," +
                    "(2111409,21,'S�o Lu�s Gonzaga do Maranh�o')," +
                    "(2111508,21,'S�o Mateus do Maranh�o')," +
                    "(2111532,21,'S�o Pedro da �gua Branca')," +
                    "(2111573,21,'S�o Pedro dos Crentes')," +
                    "(2111607,21,'S�o Raimundo das Mangabeiras')," +
                    "(2111631,21,'S�o Raimundo do doca Bezerra')," +
                    "(2111672,21,'S�o Roberto')," +
                    "(2111706,21,'S�o Vicente Ferrer')," +
                    "(2111722,21,'Satubinha')," +
                    "(2111748,21,'Senador Alexandre Costa')," +
                    "(2111763,21,'Senador La Rocque')," +
                    "(2111789,21,'Serrano do Maranh�o')," +
                    "(2111805,21,'S�tio Novo')," +
                    "(2111904,21,'Sucupira do Norte')," +
                    "(2111953,21,'Sucupira do Riach�o')," +
                    "(2112001,21,'Tasso Fragoso')," +
                    "(2112100,21,'Timbiras')," +
                    "(2112209,21,'Timon')," +
                    "(2112233,21,'Trizidela do Vale')," +
                    "(2112274,21,'Tufil�ndia')," +
                    "(2112308,21,'Tuntum')," +
                    "(2112407,21,'Turia�u')," +
                    "(2112456,21,'Turil�ndia')," +
                    "(2112506,21,'Tut�ia')," +
                    "(2112605,21,'Urbano Santos')," +
                    "(2112704,21,'Vargem Grande')," +
                    "(2112803,21,'Viana')," +
                    "(2112852,21,'Vila Nova dos Mart�rios')," +
                    "(2112902,21,'Vit�ria do Mearim')," +
                    "(2113009,21,'Vitorino Freire')," +
                    "(2114007,21,'Z� doca')," +
                    "(2200053,22,'Acau�')," +
                    "(2200103,22,'Agricol�ndia')," +
                    "(2200202,22,'�gua Branca')," +
                    "(2200251,22,'Alagoinha do Piau�')," +
                    "(2200277,22,'Alegrete do Piau�')," +
                    "(2200301,22,'Alto Long�')," +
                    "(2200400,22,'Altos')," +
                    "(2200459,22,'Alvorada do Gurgu�ia')," +
                    "(2200509,22,'Amarante')," +
                    "(2200608,22,'Angical do Piau�')," +
                    "(2200707,22,'An�sio de Abreu')," +
                    "(2200806,22,'Ant�nio Almeida')," +
                    "(2200905,22,'Aroazes')," +
                    "(2200954,22,'Aroeiras do Itaim')," +
                    "(2201002,22,'Arraial')," +
                    "(2201051,22,'Assun��o do Piau�')," +
                    "(2201101,22,'Avelino Lopes')," +
                    "(2201150,22,'Baixa Grande do Ribeiro')," +
                    "(2201176,22,'Barra Dalc�ntara')," +
                    "(2201200,22,'Barras')," +
                    "(2201309,22,'Barreiras do Piau�')," +
                    "(2201408,22,'Barro Duro')," +
                    "(2201507,22,'Batalha')," +
                    "(2201556,22,'Bela Vista do Piau�')," +
                    "(2201572,22,'Bel�m do Piau�')," +
                    "(2201606,22,'Beneditinos')," +
                    "(2201705,22,'Bertol�nia')," +
                    "(2201739,22,'Bet�nia do Piau�')," +
                    "(2201770,22,'Boa Hora')," +
                    "(2201804,22,'Bocaina')," +
                    "(2201903,22,'Bom Jesus')," +
                    "(2201919,22,'Bom Princ�pio do Piau�')," +
                    "(2201929,22,'Bonfim do Piau�')," +
                    "(2201945,22,'Boqueir�o do Piau�')," +
                    "(2201960,22,'Brasileira')," +
                    "(2201988,22,'Brejo do Piau�')," +
                    "(2202000,22,'Buriti dos Lopes')," +
                    "(2202026,22,'Buriti dos Montes')," +
                    "(2202059,22,'Cabeceiras do Piau�')," +
                    "(2202075,22,'Cajazeiras do Piau�')," +
                    "(2202083,22,'Cajueiro da Praia')," +
                    "(2202091,22,'Caldeir�o Grande do Piau�')," +
                    "(2202109,22,'Campinas do Piau�')," +
                    "(2202117,22,'Campo Alegre do Fidalgo')," +
                    "(2202133,22,'Campo Grande do Piau�')," +
                    "(2202174,22,'Campo Largo do Piau�')," +
                    "(2202208,22,'Campo Maior')," +
                    "(2202251,22,'Canavieira')," +
                    "(2202307,22,'Canto do Buriti')," +
                    "(2202406,22,'Capit�o de Campos')," +
                    "(2202455,22,'Capit�o Gerv�sio Oliveira')," +
                    "(2202505,22,'Caracol')," +
                    "(2202539,22,'Cara�bas do Piau�')," +
                    "(2202554,22,'Caridade do Piau�')," +
                    "(2202604,22,'Castelo do Piau�')," +
                    "(2202653,22,'Caxing�')," +
                    "(2202703,22,'Cocal')," +
                    "(2202711,22,'Cocal de Telha')," +
                    "(2202729,22,'Cocal dos Alves')," +
                    "(2202737,22,'Coivaras')," +
                    "(2202752,22,'Col�nia do Gurgu�ia')," +
                    "(2202778,22,'Col�nia do Piau�')," +
                    "(2202802,22,'Concei��o do Canind�')," +
                    "(2202851,22,'Coronel Jos� Dias')," +
                    "(2202901,22,'Corrente')," +
                    "(2203008,22,'Cristal�ndia do Piau�')," +
                    "(2203107,22,'Cristino Castro')," +
                    "(2203206,22,'Curimat�')," +
                    "(2203230,22,'Currais')," +
                    "(2203255,22,'Curralinhos')," +
                    "(2203271,22,'Curral Novo do Piau�')," +
                    "(2203305,22,'demerval Lob�o')," +
                    "(2203354,22,'Dirceu Arcoverde')," +
                    "(2203404,22,'dom Expedito Lopes')," +
                    "(2203420,22,'domingos Mour�o')," +
                    "(2203453,22,'dom Inoc�ncio')," +
                    "(2203503,22,'Elesb�o Veloso')," +
                    "(2203602,22,'Eliseu Martins')," +
                    "(2203701,22,'Esperantina')," +
                    "(2203750,22,'Fartura do Piau�')," +
                    "(2203800,22,'Flores do Piau�')," +
                    "(2203859,22,'Floresta do Piau�')," +
                    "(2203909,22,'Floriano')," +
                    "(2204006,22,'Francin�polis')," +
                    "(2204105,22,'Francisco Ayres')," +
                    "(2204154,22,'Francisco Macedo')," +
                    "(2204204,22,'Francisco Santos')," +
                    "(2204303,22,'Fronteiras')," +
                    "(2204352,22,'Geminiano')," +
                    "(2204402,22,'Gilbu�s')," +
                    "(2204501,22,'Guadalupe')," +
                    "(2204550,22,'Guaribas')," +
                    "(2204600,22,'Hugo Napole�o')," +
                    "(2204659,22,'Ilha Grande')," +
                    "(2204709,22,'Inhuma')," +
                    "(2204808,22,'Ipiranga do Piau�')," +
                    "(2204907,22,'Isa�as Coelho')," +
                    "(2205003,22,'Itain�polis')," +
                    "(2205102,22,'Itaueira')," +
                    "(2205151,22,'Jacobina do Piau�')," +
                    "(2205201,22,'Jaic�s')," +
                    "(2205250,22,'Jardim do Mulato')," +
                    "(2205276,22,'Jatob� do Piau�')," +
                    "(2205300,22,'Jerumenha')," +
                    "(2205359,22,'Jo�o Costa')," +
                    "(2205409,22,'Joaquim Pires')," +
                    "(2205458,22,'Joca Marques')," +
                    "(2205508,22,'Jos� de Freitas')," +
                    "(2205516,22,'Juazeiro do Piau�')," +
                    "(2205524,22,'J�lio Borges')," +
                    "(2205532,22,'Jurema')," +
                    "(2205540,22,'Lagoinha do Piau�')," +
                    "(2205557,22,'Lagoa Alegre')," +
                    "(2205565,22,'Lagoa do Barro do Piau�')," +
                    "(2205573,22,'Lagoa de S�o Francisco')," +
                    "(2205581,22,'Lagoa do Piau�')," +
                    "(2205599,22,'Lagoa do S�tio')," +
                    "(2205607,22,'Landri Sales')," +
                    "(2205706,22,'Lu�s Correia')," +
                    "(2205805,22,'Luzil�ndia')," +
                    "(2205854,22,'Madeiro')," +
                    "(2205904,22,'Manoel Em�dio')," +
                    "(2205953,22,'Marcol�ndia')," +
                    "(2206001,22,'Marcos Parente')," +
                    "(2206050,22,'Massap� do Piau�')," +
                    "(2206100,22,'Matias Ol�mpio')," +
                    "(2206209,22,'Miguel Alves')," +
                    "(2206308,22,'Miguel Le�o')," +
                    "(2206357,22,'Milton Brand�o')," +
                    "(2206407,22,'Monsenhor Gil')," +
                    "(2206506,22,'Monsenhor Hip�lito')," +
                    "(2206605,22,'Monte Alegre do Piau�')," +
                    "(2206654,22,'Morro Cabe�a No Tempo')," +
                    "(2206670,22,'Morro do Chap�u do Piau�')," +
                    "(2206696,22,'Murici dos Portelas')," +
                    "(2206704,22,'Nazar� do Piau�')," +
                    "(2206720,22,'Naz�ria')," +
                    "(2206753,22,'Nossa Senhora de Nazar�')," +
                    "(2206803,22,'Nossa Senhora dos Rem�dios')," +
                    "(2206902,22,'Novo Oriente do Piau�')," +
                    "(2206951,22,'Novo Santo Ant�nio')," +
                    "(2207009,22,'Oeiras')," +
                    "(2207108,22,'Olho D�gua do Piau�')," +
                    "(2207207,22,'Padre Marcos')," +
                    "(2207306,22,'Paes Landim')," +
                    "(2207355,22,'Paje� do Piau�')," +
                    "(2207405,22,'Palmeira do Piau�')," +
                    "(2207504,22,'Palmeirais')," +
                    "(2207553,22,'Paquet�')," +
                    "(2207603,22,'Parnagu�')," +
                    "(2207702,22,'Parna�ba')," +
                    "(2207751,22,'Passagem Franca do Piau�')," +
                    "(2207777,22,'Patos do Piau�')," +
                    "(2207793,22,'Pau Darco do Piau�')," +
                    "(2207801,22,'Paulistana')," +
                    "(2207850,22,'Pavussu')," +
                    "(2207900,22,'Pedro Ii')," +
                    "(2207934,22,'Pedro Laurentino')," +
                    "(2207959,22,'Nova Santa Rita')," +
                    "(2208007,22,'Picos')," +
                    "(2208106,22,'Pimenteiras')," +
                    "(2208205,22,'Pio Ix')," +
                    "(2208304,22,'Piracuruca')," +
                    "(2208403,22,'Piripiri')," +
                    "(2208502,22,'Porto')," +
                    "(2208551,22,'Porto Alegre do Piau�')," +
                    "(2208601,22,'Prata do Piau�')," +
                    "(2208650,22,'Queimada Nova')," +
                    "(2208700,22,'Reden��o do Gurgu�ia')," +
                    "(2208809,22,'Regenera��o')," +
                    "(2208858,22,'Riacho Frio')," +
                    "(2208874,22,'Ribeira do Piau�')," +
                    "(2208908,22,'Ribeiro Gon�alves')," +
                    "(2209005,22,'Rio Grande do Piau�')," +
                    "(2209104,22,'Santa Cruz do Piau�')," +
                    "(2209153,22,'Santa Cruz dos Milagres')," +
                    "(2209203,22,'Santa Filomena')," +
                    "(2209302,22,'Santa Luz')," +
                    "(2209351,22,'Santana do Piau�')," +
                    "(2209377,22,'Santa Rosa do Piau�')," +
                    "(2209401,22,'Santo Ant�nio de Lisboa')," +
                    "(2209450,22,'Santo Ant�nio dos Milagres')," +
                    "(2209500,22,'Santo In�cio do Piau�')," +
                    "(2209559,22,'S�o Braz do Piau�')," +
                    "(2209609,22,'S�o F�lix do Piau�')," +
                    "(2209658,22,'S�o Francisco de Assis do Piau�')," +
                    "(2209708,22,'S�o Francisco do Piau�')," +
                    "(2209757,22,'S�o Gon�alo do Gurgu�ia')," +
                    "(2209807,22,'S�o Gon�alo do Piau�')," +
                    "(2209856,22,'S�o Jo�o da Canabrava')," +
                    "(2209872,22,'S�o Jo�o da Fronteira')," +
                    "(2209906,22,'S�o Jo�o da Serra')," +
                    "(2209955,22,'S�o Jo�o da Varjota')," +
                    "(2209971,22,'S�o Jo�o do Arraial')," +
                    "(2210003,22,'S�o Jo�o do Piau�')," +
                    "(2210052,22,'S�o Jos� do Divino')," +
                    "(2210102,22,'S�o Jos� do Peixe')," +
                    "(2210201,22,'S�o Jos� do Piau�')," +
                    "(2210300,22,'S�o Juli�o')," +
                    "(2210359,22,'S�o Louren�o do Piau�')," +
                    "(2210375,22,'S�o Luis do Piau�')," +
                    "(2210383,22,'S�o Miguel da Baixa Grande')," +
                    "(2210391,22,'S�o Miguel do Fidalgo')," +
                    "(2210409,22,'S�o Miguel do Tapuio')," +
                    "(2210508,22,'S�o Pedro do Piau�')," +
                    "(2210607,22,'S�o Raimundo Nonato')," +
                    "(2210623,22,'Sebasti�o Barros')," +
                    "(2210631,22,'Sebasti�o Leal')," +
                    "(2210656,22,'Sigefredo Pacheco')," +
                    "(2210706,22,'Sim�es')," +
                    "(2210805,22,'Simpl�cio Mendes')," +
                    "(2210904,22,'Socorro do Piau�')," +
                    "(2210938,22,'Sussuapara')," +
                    "(2210953,22,'Tamboril do Piau�')," +
                    "(2210979,22,'Tanque do Piau�')," +
                    "(2211001,22,'Teresina')," +
                    "(2211100,22,'Uni�o')," +
                    "(2211209,22,'Uru�u�')," +
                    "(2211308,22,'Valen�a do Piau�')," +
                    "(2211357,22,'V�rzea Branca')," +
                    "(2211407,22,'V�rzea Grande')," +
                    "(2211506,22,'Vera Mendes')," +
                    "(2211605,22,'Vila Nova do Piau�')," +
                    "(2211704,22,'Wall Ferraz')," +
                    "(2300101,23,'Abaiara')," +
                    "(2300150,23,'Acarape')," +
                    "(2300200,23,'Acara�')," +
                    "(2300309,23,'Acopiara')," +
                    "(2300408,23,'Aiuaba')," +
                    "(2300507,23,'Alc�ntaras')," +
                    "(2300606,23,'Altaneira')," +
                    "(2300705,23,'Alto Santo')," +
                    "(2300754,23,'Amontada')," +
                    "(2300804,23,'Antonina do Norte')," +
                    "(2300903,23,'Apuiar�s')," +
                    "(2301000,23,'Aquiraz')," +
                    "(2301109,23,'Aracati')," +
                    "(2301208,23,'Aracoiaba')," +
                    "(2301257,23,'Ararend�')," +
                    "(2301307,23,'Araripe')," +
                    "(2301406,23,'Aratuba')," +
                    "(2301505,23,'Arneiroz')," +
                    "(2301604,23,'Assar�')," +
                    "(2301703,23,'Aurora')," +
                    "(2301802,23,'Baixio')," +
                    "(2301851,23,'Banabui�')," +
                    "(2301901,23,'Barbalha')," +
                    "(2301950,23,'Barreira')," +
                    "(2302008,23,'Barro')," +
                    "(2302057,23,'Barroquinha')," +
                    "(2302107,23,'Baturit�')," +
                    "(2302206,23,'Beberibe')," +
                    "(2302305,23,'Bela Cruz')," +
                    "(2302404,23,'Boa Viagem')," +
                    "(2302503,23,'Brejo Santo')," +
                    "(2302602,23,'Camocim')," +
                    "(2302701,23,'Campos Sales')," +
                    "(2302800,23,'Canind�')," +
                    "(2302909,23,'Capistrano')," +
                    "(2303006,23,'Caridade')," +
                    "(2303105,23,'Carir�')," +
                    "(2303204,23,'Cariria�u')," +
                    "(2303303,23,'Cari�s')," +
                    "(2303402,23,'Carnaubal')," +
                    "(2303501,23,'Cascavel')," +
                    "(2303600,23,'Catarina')," +
                    "(2303659,23,'Catunda')," +
                    "(2303709,23,'Caucaia')," +
                    "(2303808,23,'Cedro')," +
                    "(2303907,23,'Chaval')," +
                    "(2303931,23,'Chor�')," +
                    "(2303956,23,'Chorozinho')," +
                    "(2304004,23,'Corea�')," +
                    "(2304103,23,'Crate�s')," +
                    "(2304202,23,'Crato')," +
                    "(2304236,23,'Croat�')," +
                    "(2304251,23,'Cruz')," +
                    "(2304269,23,'deputado Irapuan Pinheiro')," +
                    "(2304277,23,'Erer�')," +
                    "(2304285,23,'Eus�bio')," +
                    "(2304301,23,'Farias Brito')," +
                    "(2304350,23,'Forquilha')," +
                    "(2304400,23,'Fortaleza')," +
                    "(2304459,23,'Fortim')," +
                    "(2304509,23,'Frecheirinha')," +
                    "(2304608,23,'General Sampaio')," +
                    "(2304657,23,'Gra�a')," +
                    "(2304707,23,'Granja')," +
                    "(2304806,23,'Granjeiro')," +
                    "(2304905,23,'Groa�ras')," +
                    "(2304954,23,'Guai�ba')," +
                    "(2305001,23,'Guaraciaba do Norte')," +
                    "(2305100,23,'Guaramiranga')," +
                    "(2305209,23,'Hidrol�ndia')," +
                    "(2305233,23,'Horizonte')," +
                    "(2305266,23,'Ibaretama')," +
                    "(2305308,23,'Ibiapina')," +
                    "(2305332,23,'Ibicuitinga')," +
                    "(2305357,23,'Icapu�')," +
                    "(2305407,23,'Ic�')," +
                    "(2305506,23,'Iguatu')," +
                    "(2305605,23,'Independ�ncia')," +
                    "(2305654,23,'Ipaporanga')," +
                    "(2305704,23,'Ipaumirim')," +
                    "(2305803,23,'Ipu')," +
                    "(2305902,23,'Ipueiras')," +
                    "(2306009,23,'Iracema')," +
                    "(2306108,23,'Irau�uba')," +
                    "(2306207,23,'Itai�aba')," +
                    "(2306256,23,'Itaitinga')," +
                    "(2306306,23,'Itapaj�')," +
                    "(2306405,23,'Itapipoca')," +
                    "(2306504,23,'Itapi�na')," +
                    "(2306553,23,'Itarema')," +
                    "(2306603,23,'Itatira')," +
                    "(2306702,23,'Jaguaretama')," +
                    "(2306801,23,'Jaguaribara')," +
                    "(2306900,23,'Jaguaribe')," +
                    "(2307007,23,'Jaguaruana')," +
                    "(2307106,23,'Jardim')," +
                    "(2307205,23,'Jati')," +
                    "(2307254,23,'Jijoca de Jericoacoara')," +
                    "(2307304,23,'Juazeiro do Norte')," +
                    "(2307403,23,'Juc�s')," +
                    "(2307502,23,'Lavras da Mangabeira')," +
                    "(2307601,23,'Limoeiro do Norte')," +
                    "(2307635,23,'Madalena')," +
                    "(2307650,23,'Maracana�')," +
                    "(2307700,23,'Maranguape')," +
                    "(2307809,23,'Marco')," +
                    "(2307908,23,'Martin�pole')," +
                    "(2308005,23,'Massap�')," +
                    "(2308104,23,'Mauriti')," +
                    "(2308203,23,'Meruoca')," +
                    "(2308302,23,'Milagres')," +
                    "(2308351,23,'Milh�')," +
                    "(2308377,23,'Mira�ma')," +
                    "(2308401,23,'Miss�o Velha')," +
                    "(2308500,23,'Momba�a')," +
                    "(2308609,23,'Monsenhor Tabosa')," +
                    "(2308708,23,'Morada Nova')," +
                    "(2308807,23,'Mora�jo')," +
                    "(2308906,23,'Morrinhos')," +
                    "(2309003,23,'Mucambo')," +
                    "(2309102,23,'Mulungu')," +
                    "(2309201,23,'Nova Olinda')," +
                    "(2309300,23,'Nova Russas')," +
                    "(2309409,23,'Novo Oriente')," +
                    "(2309458,23,'Ocara')," +
                    "(2309508,23,'Or�s')," +
                    "(2309607,23,'Pacajus')," +
                    "(2309706,23,'Pacatuba')," +
                    "(2309805,23,'Pacoti')," +
                    "(2309904,23,'Pacuj�')," +
                    "(2310001,23,'Palhano')," +
                    "(2310100,23,'Palm�cia')," +
                    "(2310209,23,'Paracuru')," +
                    "(2310258,23,'Paraipaba')," +
                    "(2310308,23,'Parambu')," +
                    "(2310407,23,'Paramoti')," +
                    "(2310506,23,'Pedra Branca')," +
                    "(2310605,23,'Penaforte')," +
                    "(2310704,23,'Pentecoste')," +
                    "(2310803,23,'Pereiro')," +
                    "(2310852,23,'Pindoretama')," +
                    "(2310902,23,'Piquet Carneiro')," +
                    "(2310951,23,'Pires Ferreira')," +
                    "(2311009,23,'Poranga')," +
                    "(2311108,23,'Porteiras')," +
                    "(2311207,23,'Potengi')," +
                    "(2311231,23,'Potiretama')," +
                    "(2311264,23,'Quiterian�polis')," +
                    "(2311306,23,'Quixad�')," +
                    "(2311355,23,'Quixel�')," +
                    "(2311405,23,'Quixeramobim')," +
                    "(2311504,23,'Quixer�')," +
                    "(2311603,23,'Reden��o')," +
                    "(2311702,23,'Reriutaba')," +
                    "(2311801,23,'Russas')," +
                    "(2311900,23,'Saboeiro')," +
                    "(2311959,23,'Salitre')," +
                    "(2312007,23,'Santana do Acara�')," +
                    "(2312106,23,'Santana do Cariri')," +
                    "(2312205,23,'Santa Quit�ria')," +
                    "(2312304,23,'S�o Benedito')," +
                    "(2312403,23,'S�o Gon�alo do Amarante')," +
                    "(2312502,23,'S�o Jo�o do Jaguaribe')," +
                    "(2312601,23,'S�o Lu�s do Curu')," +
                    "(2312700,23,'Senador Pompeu')," +
                    "(2312809,23,'Senador S�')," +
                    "(2312908,23,'Sobral')," +
                    "(2313005,23,'Solon�pole')," +
                    "(2313104,23,'Tabuleiro do Norte')," +
                    "(2313203,23,'Tamboril')," +
                    "(2313252,23,'Tarrafas')," +
                    "(2313302,23,'Tau�')," +
                    "(2313351,23,'Teju�uoca')," +
                    "(2313401,23,'Tiangu�')," +
                    "(2313500,23,'Trairi')," +
                    "(2313559,23,'Tururu')," +
                    "(2313609,23,'Ubajara')," +
                    "(2313708,23,'Umari')," +
                    "(2313757,23,'Umirim')," +
                    "(2313807,23,'Uruburetama')," +
                    "(2313906,23,'Uruoca')," +
                    "(2313955,23,'Varjota')," +
                    "(2314003,23,'V�rzea Alegre')," +
                    "(2314102,23,'Vi�osa do Cear�')," +
                    "(2400109,24,'Acari')," +
                    "(2400208,24,'A�u')," +
                    "(2400307,24,'Afonso Bezerra')," +
                    "(2400406,24,'�gua Nova')," +
                    "(2400505,24,'Alexandria')," +
                    "(2400604,24,'Almino Afonso')," +
                    "(2400703,24,'Alto do Rodrigues')," +
                    "(2400802,24,'Angicos')," +
                    "(2400901,24,'Ant�nio Martins')," +
                    "(2401008,24,'Apodi')," +
                    "(2401107,24,'Areia Branca')," +
                    "(2401206,24,'Ar�s')," +
                    "(2401305,24,'Augusto Severo')," +
                    "(2401404,24,'Ba�a Formosa')," +
                    "(2401453,24,'Bara�na')," +
                    "(2401503,24,'Barcelona')," +
                    "(2401602,24,'Bento Fernandes')," +
                    "(2401651,24,'Bod�')," +
                    "(2401701,24,'Bom Jesus')," +
                    "(2401800,24,'Brejinho')," +
                    "(2401859,24,'Cai�ara do Norte')," +
                    "(2401909,24,'Cai�ara do Rio do Vento')," +
                    "(2402006,24,'Caic�')," +
                    "(2402105,24,'Campo Redondo')," +
                    "(2402204,24,'Canguaretama')," +
                    "(2402303,24,'Cara�bas')," +
                    "(2402402,24,'Carna�ba dos dantas')," +
                    "(2402501,24,'Carnaubais')," +
                    "(2402600,24,'Cear�-Mirim')," +
                    "(2402709,24,'Cerro Cor�')," +
                    "(2402808,24,'Coronel Ezequiel')," +
                    "(2402907,24,'Coronel Jo�o Pessoa')," +
                    "(2403004,24,'Cruzeta')," +
                    "(2403103,24,'Currais Novos')," +
                    "(2403202,24,'doutor Severiano')," +
                    "(2403251,24,'Parnamirim')," +
                    "(2403301,24,'Encanto')," +
                    "(2403400,24,'Equador')," +
                    "(2403509,24,'Esp�rito Santo')," +
                    "(2403608,24,'Extremoz')," +
                    "(2403707,24,'Felipe Guerra')," +
                    "(2403756,24,'Fernando Pedroza')," +
                    "(2403806,24,'Flor�nia')," +
                    "(2403905,24,'Francisco dantas')," +
                    "(2404002,24,'Frutuoso Gomes')," +
                    "(2404101,24,'Galinhos')," +
                    "(2404200,24,'Goianinha')," +
                    "(2404309,24,'Governador Dix-Sept Rosado')," +
                    "(2404408,24,'Grossos')," +
                    "(2404507,24,'Guamar�')," +
                    "(2404606,24,'Ielmo Marinho')," +
                    "(2404705,24,'Ipangua�u')," +
                    "(2404804,24,'Ipueira')," +
                    "(2404853,24,'Itaj�')," +
                    "(2404903,24,'Ita�')," +
                    "(2405009,24,'Ja�an�')," +
                    "(2405108,24,'Janda�ra')," +
                    "(2405207,24,'Jandu�s')," +
                    "(2405306,24,'Janu�rio Cicco')," +
                    "(2405405,24,'Japi')," +
                    "(2405504,24,'Jardim de Angicos')," +
                    "(2405603,24,'Jardim de Piranhas')," +
                    "(2405702,24,'Jardim do Serid�')," +
                    "(2405801,24,'Jo�o C�mara')," +
                    "(2405900,24,'Jo�o Dias')," +
                    "(2406007,24,'Jos� da Penha')," +
                    "(2406106,24,'Jucurutu')," +
                    "(2406155,24,'Jundi�')," +
                    "(2406205,24,'Lagoa Danta')," +
                    "(2406304,24,'Lagoa de Pedras')," +
                    "(2406403,24,'Lagoa de Velhos')," +
                    "(2406502,24,'Lagoa Nova')," +
                    "(2406601,24,'Lagoa Salgada')," +
                    "(2406700,24,'Lajes')," +
                    "(2406809,24,'Lajes Pintadas')," +
                    "(2406908,24,'Lucr�cia')," +
                    "(2407005,24,'Lu�s Gomes')," +
                    "(2407104,24,'Maca�ba')," +
                    "(2407203,24,'Macau')," +
                    "(2407252,24,'Major Sales')," +
                    "(2407302,24,'Marcelino Vieira')," +
                    "(2407401,24,'Martins')," +
                    "(2407500,24,'Maxaranguape')," +
                    "(2407609,24,'Messias Targino')," +
                    "(2407708,24,'Montanhas')," +
                    "(2407807,24,'Monte Alegre')," +
                    "(2407906,24,'Monte das Gameleiras')," +
                    "(2408003,24,'Mossor�')," +
                    "(2408102,24,'Natal')," +
                    "(2408201,24,'N�sia Floresta')," +
                    "(2408300,24,'Nova Cruz')," +
                    "(2408409,24,'Olho-D�gua do Borges')," +
                    "(2408508,24,'Ouro Branco')," +
                    "(2408607,24,'Paran�')," +
                    "(2408706,24,'Para�')," +
                    "(2408805,24,'Parazinho')," +
                    "(2408904,24,'Parelhas')," +
                    "(2408953,24,'Rio do Fogo')," +
                    "(2409100,24,'Passa E Fica')," +
                    "(2409209,24,'Passagem')," +
                    "(2409308,24,'Patu')," +
                    "(2409332,24,'Santa Maria')," +
                    "(2409407,24,'Pau dos Ferros')," +
                    "(2409506,24,'Pedra Grande')," +
                    "(2409605,24,'Pedra Preta')," +
                    "(2409704,24,'Pedro Avelino')," +
                    "(2409803,24,'Pedro Velho')," +
                    "(2409902,24,'Pend�ncias')," +
                    "(2410009,24,'Pil�es')," +
                    "(2410108,24,'Po�o Branco')," +
                    "(2410207,24,'Portalegre')," +
                    "(2410256,24,'Porto do Mangue')," +
                    "(2410306,24,'Serra Caiada')," +
                    "(2410405,24,'Pureza')," +
                    "(2410504,24,'Rafael Fernandes')," +
                    "(2410603,24,'Rafael Godeiro')," +
                    "(2410702,24,'Riacho da Cruz')," +
                    "(2410801,24,'Riacho de Santana')," +
                    "(2410900,24,'Riachuelo')," +
                    "(2411007,24,'Rodolfo Fernandes')," +
                    "(2411056,24,'Tibau')," +
                    "(2411106,24,'Ruy Barbosa')," +
                    "(2411205,24,'Santa Cruz')," +
                    "(2411403,24,'Santana do Matos')," +
                    "(2411429,24,'Santana do Serid�')," +
                    "(2411502,24,'Santo Ant�nio')," +
                    "(2411601,24,'S�o Bento do Norte')," +
                    "(2411700,24,'S�o Bento do Trair�')," +
                    "(2411809,24,'S�o Fernando')," +
                    "(2411908,24,'S�o Francisco do Oeste')," +
                    "(2412005,24,'S�o Gon�alo do Amarante')," +
                    "(2412104,24,'S�o Jo�o do Sabugi')," +
                    "(2412203,24,'S�o Jos� de Mipibu')," +
                    "(2412302,24,'S�o Jos� do Campestre')," +
                    "(2412401,24,'S�o Jos� do Serid�')," +
                    "(2412500,24,'S�o Miguel')," +
                    "(2412559,24,'S�o Miguel do Gostoso')," +
                    "(2412609,24,'S�o Paulo do Potengi')," +
                    "(2412708,24,'S�o Pedro')," +
                    "(2412807,24,'S�o Rafael')," +
                    "(2412906,24,'S�o Tom�')," +
                    "(2413003,24,'S�o Vicente')," +
                    "(2413102,24,'Senador El�i de Souza')," +
                    "(2413201,24,'Senador Georgino Avelino')," +
                    "(2413300,24,'Serra de S�o Bento')," +
                    "(2413359,24,'Serra do Mel')," +
                    "(2413409,24,'Serra Negra do Norte')," +
                    "(2413508,24,'Serrinha')," +
                    "(2413557,24,'Serrinha dos Pintos')," +
                    "(2413607,24,'Severiano Melo')," +
                    "(2413706,24,'S�tio Novo')," +
                    "(2413805,24,'Taboleiro Grande')," +
                    "(2413904,24,'Taipu')," +
                    "(2414001,24,'Tangar�')," +
                    "(2414100,24,'Tenente Ananias')," +
                    "(2414159,24,'Tenente Laurentino Cruz')," +
                    "(2414209,24,'Tibau do Sul')," +
                    "(2414308,24,'Timba�ba dos Batistas')," +
                    "(2414407,24,'Touros')," +
                    "(2414456,24,'Triunfo Potiguar')," +
                    "(2414506,24,'Umarizal')," +
                    "(2414605,24,'Upanema')," +
                    "(2414704,24,'V�rzea')," +
                    "(2414753,24,'Venha-Ver')," +
                    "(2414803,24,'Vera Cruz')," +
                    "(2414902,24,'Vi�osa')," +
                    "(2415008,24,'Vila Flor')," +
                    "(2500106,25,'�gua Branca')," +
                    "(2500205,25,'Aguiar')," +
                    "(2500304,25,'Alagoa Grande')," +
                    "(2500403,25,'Alagoa Nova')," +
                    "(2500502,25,'Alagoinha')," +
                    "(2500536,25,'Alcantil')," +
                    "(2500577,25,'Algod�o de Janda�ra')," +
                    "(2500601,25,'Alhandra')," +
                    "(2500700,25,'S�o Jo�o do Rio do Peixe')," +
                    "(2500734,25,'Amparo')," +
                    "(2500775,25,'Aparecida')," +
                    "(2500809,25,'Ara�agi')," +
                    "(2500908,25,'Arara')," +
                    "(2501005,25,'Araruna')," +
                    "(2501104,25,'Areia')," +
                    "(2501153,25,'Areia de Bara�nas')," +
                    "(2501203,25,'Areial')," +
                    "(2501302,25,'Aroeiras')," +
                    "(2501351,25,'Assun��o')," +
                    "(2501401,25,'Ba�a da Trai��o')," +
                    "(2501500,25,'Bananeiras')," +
                    "(2501534,25,'Bara�na')," +
                    "(2501575,25,'Barra de Santana')," +
                    "(2501609,25,'Barra de Santa Rosa')," +
                    "(2501708,25,'Barra de S�o Miguel')," +
                    "(2501807,25,'Bayeux')," +
                    "(2501906,25,'Bel�m')," +
                    "(2502003,25,'Bel�m do Brejo do Cruz')," +
                    "(2502052,25,'Bernardino Batista')," +
                    "(2502102,25,'Boa Ventura')," +
                    "(2502151,25,'Boa Vista')," +
                    "(2502201,25,'Bom Jesus')," +
                    "(2502300,25,'Bom Sucesso')," +
                    "(2502409,25,'Bonito de Santa F�')," +
                    "(2502508,25,'Boqueir�o')," +
                    "(2502607,25,'Igaracy')," +
                    "(2502706,25,'Borborema')," +
                    "(2502805,25,'Brejo do Cruz')," +
                    "(2502904,25,'Brejo dos Santos')," +
                    "(2503001,25,'Caapor�')," +
                    "(2503100,25,'Cabaceiras')," +
                    "(2503209,25,'Cabedelo')," +
                    "(2503308,25,'Cachoeira dos �ndios')," +
                    "(2503407,25,'Cacimba de Areia')," +
                    "(2503506,25,'Cacimba de dentro')," +
                    "(2503555,25,'Cacimbas')," +
                    "(2503605,25,'Cai�ara')," +
                    "(2503704,25,'Cajazeiras')," +
                    "(2503753,25,'Cajazeirinhas')," +
                    "(2503803,25,'Caldas Brand�o')," +
                    "(2503902,25,'Camala�')," +
                    "(2504009,25,'Campina Grande')," +
                    "(2504033,25,'Capim')," +
                    "(2504074,25,'Cara�bas')," +
                    "(2504108,25,'Carrapateira')," +
                    "(2504157,25,'Casserengue')," +
                    "(2504207,25,'Catingueira')," +
                    "(2504306,25,'Catol� do Rocha')," +
                    "(2504355,25,'Caturit�')," +
                    "(2504405,25,'Concei��o')," +
                    "(2504504,25,'Condado')," +
                    "(2504603,25,'Conde')," +
                    "(2504702,25,'Congo')," +
                    "(2504801,25,'Coremas')," +
                    "(2504850,25,'Coxixola')," +
                    "(2504900,25,'Cruz do Esp�rito Santo')," +
                    "(2505006,25,'Cubati')," +
                    "(2505105,25,'Cuit�')," +
                    "(2505204,25,'Cuitegi')," +
                    "(2505238,25,'Cuit� de Mamanguape')," +
                    "(2505279,25,'Curral de Cima')," +
                    "(2505303,25,'Curral Velho')," +
                    "(2505352,25,'dami�o')," +
                    "(2505402,25,'desterro')," +
                    "(2505501,25,'Vista Serrana')," +
                    "(2505600,25,'Diamante')," +
                    "(2505709,25,'dona In�s')," +
                    "(2505808,25,'Duas Estradas')," +
                    "(2505907,25,'Emas')," +
                    "(2506004,25,'Esperan�a')," +
                    "(2506103,25,'Fagundes')," +
                    "(2506202,25,'Frei Martinho')," +
                    "(2506251,25,'Gado Bravo')," +
                    "(2506301,25,'Guarabira')," +
                    "(2506400,25,'Gurinh�m')," +
                    "(2506509,25,'Gurj�o')," +
                    "(2506608,25,'Ibiara')," +
                    "(2506707,25,'Imaculada')," +
                    "(2506806,25,'Ing�')," +
                    "(2506905,25,'Itabaiana')," +
                    "(2507002,25,'Itaporanga')," +
                    "(2507101,25,'Itapororoca')," +
                    "(2507200,25,'Itatuba')," +
                    "(2507309,25,'Jacara�')," +
                    "(2507408,25,'Jeric�')," +
                    "(2507507,25,'Jo�o Pessoa')," +
                    "(2507606,25,'Juarez T�vora')," +
                    "(2507705,25,'Juazeirinho')," +
                    "(2507804,25,'Junco do Serid�')," +
                    "(2507903,25,'Juripiranga')," +
                    "(2508000,25,'Juru')," +
                    "(2508109,25,'Lagoa')," +
                    "(2508208,25,'Lagoa de dentro')," +
                    "(2508307,25,'Lagoa Seca')," +
                    "(2508406,25,'Lastro')," +
                    "(2508505,25,'Livramento')," +
                    "(2508554,25,'Logradouro')," +
                    "(2508604,25,'Lucena')," +
                    "(2508703,25,'M�e D�gua')," +
                    "(2508802,25,'Malta')," +
                    "(2508901,25,'Mamanguape')," +
                    "(2509008,25,'Mana�ra')," +
                    "(2509057,25,'Marca��o')," +
                    "(2509107,25,'Mari')," +
                    "(2509156,25,'Mariz�polis')," +
                    "(2509206,25,'Massaranduba')," +
                    "(2509305,25,'Mataraca')," +
                    "(2509339,25,'Matinhas')," +
                    "(2509370,25,'Mato Grosso')," +
                    "(2509396,25,'Matur�ia')," +
                    "(2509404,25,'Mogeiro')," +
                    "(2509503,25,'Montadas')," +
                    "(2509602,25,'Monte Horebe')," +
                    "(2509701,25,'Monteiro')," +
                    "(2509800,25,'Mulungu')," +
                    "(2509909,25,'Natuba')," +
                    "(2510006,25,'Nazarezinho')," +
                    "(2510105,25,'Nova Floresta')," +
                    "(2510204,25,'Nova Olinda')," +
                    "(2510303,25,'Nova Palmeira')," +
                    "(2510402,25,'Olho D�gua')," +
                    "(2510501,25,'Olivedos')," +
                    "(2510600,25,'Ouro Velho')," +
                    "(2510659,25,'Parari')," +
                    "(2510709,25,'Passagem')," +
                    "(2510808,25,'Patos')," +
                    "(2510907,25,'Paulista')," +
                    "(2511004,25,'Pedra Branca')," +
                    "(2511103,25,'Pedra Lavrada')," +
                    "(2511202,25,'Pedras de Fogo')," +
                    "(2511301,25,'Pianc�')," +
                    "(2511400,25,'Picu�')," +
                    "(2511509,25,'Pilar')," +
                    "(2511608,25,'Pil�es')," +
                    "(2511707,25,'Pil�ezinhos')," +
                    "(2511806,25,'Pirpirituba')," +
                    "(2511905,25,'Pitimbu')," +
                    "(2512002,25,'Pocinhos')," +
                    "(2512036,25,'Po�o dantas')," +
                    "(2512077,25,'Po�o de Jos� de Moura')," +
                    "(2512101,25,'Pombal')," +
                    "(2512200,25,'Prata')," +
                    "(2512309,25,'Princesa Isabel')," +
                    "(2512408,25,'Puxinan�')," +
                    "(2512507,25,'Queimadas')," +
                    "(2512606,25,'Quixaba')," +
                    "(2512705,25,'Rem�gio')," +
                    "(2512721,25,'Pedro R�gis')," +
                    "(2512747,25,'Riach�o')," +
                    "(2512754,25,'Riach�o do Bacamarte')," +
                    "(2512762,25,'Riach�o do Po�o')," +
                    "(2512788,25,'Riacho de Santo Ant�nio')," +
                    "(2512804,25,'Riacho dos Cavalos')," +
                    "(2512903,25,'Rio Tinto')," +
                    "(2513000,25,'Salgadinho')," +
                    "(2513109,25,'Salgado de S�o F�lix')," +
                    "(2513158,25,'Santa Cec�lia')," +
                    "(2513208,25,'Santa Cruz')," +
                    "(2513307,25,'Santa Helena')," +
                    "(2513356,25,'Santa In�s')," +
                    "(2513406,25,'Santa Luzia')," +
                    "(2513505,25,'Santana de Mangueira')," +
                    "(2513604,25,'Santana dos Garrotes')," +
                    "(2513653,25,'Joca Claudino')," +
                    "(2513703,25,'Santa Rita')," +
                    "(2513802,25,'Santa Teresinha')," +
                    "(2513851,25,'Santo Andr�')," +
                    "(2513901,25,'S�o Bento')," +
                    "(2513927,25,'S�o Bentinho')," +
                    "(2513943,25,'S�o domingos do Cariri')," +
                    "(2513968,25,'S�o domingos')," +
                    "(2513984,25,'S�o Francisco')," +
                    "(2514008,25,'S�o Jo�o do Cariri')," +
                    "(2514107,25,'S�o Jo�o do Tigre')," +
                    "(2514206,25,'S�o Jos� da Lagoa Tapada')," +
                    "(2514305,25,'S�o Jos� de Caiana')," +
                    "(2514404,25,'S�o Jos� de Espinharas')," +
                    "(2514453,25,'S�o Jos� dos Ramos')," +
                    "(2514503,25,'S�o Jos� de Piranhas')," +
                    "(2514552,25,'S�o Jos� de Princesa')," +
                    "(2514602,25,'S�o Jos� do Bonfim')," +
                    "(2514651,25,'S�o Jos� do Brejo do Cruz')," +
                    "(2514701,25,'S�o Jos� do Sabugi')," +
                    "(2514800,25,'S�o Jos� dos Cordeiros')," +
                    "(2514909,25,'S�o Mamede')," +
                    "(2515005,25,'S�o Miguel de Taipu')," +
                    "(2515104,25,'S�o Sebasti�o de Lagoa de Ro�a')," +
                    "(2515203,25,'S�o Sebasti�o do Umbuzeiro')," +
                    "(2515302,25,'Sap�')," +
                    "(2515401,25,'S�o Vicente do Serid�')," +
                    "(2515500,25,'Serra Branca')," +
                    "(2515609,25,'Serra da Raiz')," +
                    "(2515708,25,'Serra Grande')," +
                    "(2515807,25,'Serra Redonda')," +
                    "(2515906,25,'Serraria')," +
                    "(2515930,25,'Sert�ozinho')," +
                    "(2515971,25,'Sobrado')," +
                    "(2516003,25,'Sol�nea')," +
                    "(2516102,25,'Soledade')," +
                    "(2516151,25,'Soss�go')," +
                    "(2516201,25,'Sousa')," +
                    "(2516300,25,'Sum�')," +
                    "(2516409,25,'Tacima')," +
                    "(2516508,25,'Tapero�')," +
                    "(2516607,25,'Tavares')," +
                    "(2516706,25,'Teixeira')," +
                    "(2516755,25,'Ten�rio')," +
                    "(2516805,25,'Triunfo')," +
                    "(2516904,25,'Uira�na')," +
                    "(2517001,25,'Umbuzeiro')," +
                    "(2517100,25,'V�rzea')," +
                    "(2517209,25,'Vieir�polis')," +
                    "(2517407,25,'Zabel�')," +
                    "(2600054,26,'Abreu E Lima')," +
                    "(2600104,26,'Afogados da Ingazeira')," +
                    "(2600203,26,'Afr�nio')," +
                    "(2600302,26,'Agrestina')," +
                    "(2600401,26,'�gua Preta')," +
                    "(2600500,26,'�guas Belas')," +
                    "(2600609,26,'Alagoinha')," +
                    "(2600708,26,'Alian�a')," +
                    "(2600807,26,'Altinho')," +
                    "(2600906,26,'Amaraji')," +
                    "(2601003,26,'Angelim')," +
                    "(2601052,26,'Ara�oiaba')," +
                    "(2601102,26,'Araripina')," +
                    "(2601201,26,'Arcoverde')," +
                    "(2601300,26,'Barra de Guabiraba')," +
                    "(2601409,26,'Barreiros')," +
                    "(2601508,26,'Bel�m de Maria')," +
                    "(2601607,26,'Bel�m do S�o Francisco')," +
                    "(2601706,26,'Belo Jardim')," +
                    "(2601805,26,'Bet�nia')," +
                    "(2601904,26,'Bezerros')," +
                    "(2602001,26,'Bodoc�')," +
                    "(2602100,26,'Bom Conselho')," +
                    "(2602209,26,'Bom Jardim')," +
                    "(2602308,26,'Bonito')," +
                    "(2602407,26,'Brej�o')," +
                    "(2602506,26,'Brejinho')," +
                    "(2602605,26,'Brejo da Madre de deus')," +
                    "(2602704,26,'Buenos Aires')," +
                    "(2602803,26,'Bu�que')," +
                    "(2602902,26,'Cabo de Santo Agostinho')," +
                    "(2603009,26,'Cabrob�')," +
                    "(2603108,26,'Cachoeirinha')," +
                    "(2603207,26,'Caet�s')," +
                    "(2603306,26,'Cal�ado')," +
                    "(2603405,26,'Calumbi')," +
                    "(2603454,26,'Camaragibe')," +
                    "(2603504,26,'Camocim de S�o F�lix')," +
                    "(2603603,26,'Camutanga')," +
                    "(2603702,26,'Canhotinho')," +
                    "(2603801,26,'Capoeiras')," +
                    "(2603900,26,'Carna�ba')," +
                    "(2603926,26,'Carnaubeira da Penha')," +
                    "(2604007,26,'Carpina')," +
                    "(2604106,26,'Caruaru')," +
                    "(2604155,26,'Casinhas')," +
                    "(2604205,26,'Catende')," +
                    "(2604304,26,'Cedro')," +
                    "(2604403,26,'Ch� de Alegria')," +
                    "(2604502,26,'Ch� Grande')," +
                    "(2604601,26,'Condado')," +
                    "(2604700,26,'Correntes')," +
                    "(2604809,26,'Cort�s')," +
                    "(2604908,26,'Cumaru')," +
                    "(2605004,26,'Cupira')," +
                    "(2605103,26,'Cust�dia')," +
                    "(2605152,26,'dormentes')," +
                    "(2605202,26,'Escada')," +
                    "(2605301,26,'Exu')," +
                    "(2605400,26,'Feira Nova')," +
                    "(2605459,26,'Fernando de Noronha')," +
                    "(2605509,26,'Ferreiros')," +
                    "(2605608,26,'Flores')," +
                    "(2605707,26,'Floresta')," +
                    "(2605806,26,'Frei Miguelinho')," +
                    "(2605905,26,'Gameleira')," +
                    "(2606002,26,'Garanhuns')," +
                    "(2606101,26,'Gl�ria do Goit�')," +
                    "(2606200,26,'Goiana')," +
                    "(2606309,26,'Granito')," +
                    "(2606408,26,'Gravat�')," +
                    "(2606507,26,'Iati')," +
                    "(2606606,26,'Ibimirim')," +
                    "(2606705,26,'Ibirajuba')," +
                    "(2606804,26,'Igarassu')," +
                    "(2606903,26,'Iguaracy')," +
                    "(2607000,26,'Inaj�')," +
                    "(2607109,26,'Ingazeira')," +
                    "(2607208,26,'Ipojuca')," +
                    "(2607307,26,'Ipubi')," +
                    "(2607406,26,'Itacuruba')," +
                    "(2607505,26,'Ita�ba')," +
                    "(2607604,26,'Ilha de Itamarac�')," +
                    "(2607653,26,'Itamb�')," +
                    "(2607703,26,'Itapetim')," +
                    "(2607752,26,'Itapissuma')," +
                    "(2607802,26,'Itaquitinga')," +
                    "(2607901,26,'Jaboat�o dos Guararapes')," +
                    "(2607950,26,'Jaqueira')," +
                    "(2608008,26,'Jata�ba')," +
                    "(2608057,26,'Jatob�')," +
                    "(2608107,26,'Jo�o Alfredo')," +
                    "(2608206,26,'Joaquim Nabuco')," +
                    "(2608255,26,'Jucati')," +
                    "(2608305,26,'Jupi')," +
                    "(2608404,26,'Jurema')," +
                    "(2608453,26,'Lagoa do Carro')," +
                    "(2608503,26,'Lagoa de Itaenga')," +
                    "(2608602,26,'Lagoa do Ouro')," +
                    "(2608701,26,'Lagoa dos Gatos')," +
                    "(2608750,26,'Lagoa Grande')," +
                    "(2608800,26,'Lajedo')," +
                    "(2608909,26,'Limoeiro')," +
                    "(2609006,26,'Macaparana')," +
                    "(2609105,26,'Machados')," +
                    "(2609154,26,'Manari')," +
                    "(2609204,26,'Maraial')," +
                    "(2609303,26,'Mirandiba')," +
                    "(2609402,26,'Moreno')," +
                    "(2609501,26,'Nazar� da Mata')," +
                    "(2609600,26,'Olinda')," +
                    "(2609709,26,'Orob�')," +
                    "(2609808,26,'Oroc�')," +
                    "(2609907,26,'Ouricuri')," +
                    "(2610004,26,'Palmares')," +
                    "(2610103,26,'Palmeirina')," +
                    "(2610202,26,'Panelas')," +
                    "(2610301,26,'Paranatama')," +
                    "(2610400,26,'Parnamirim')," +
                    "(2610509,26,'Passira')," +
                    "(2610608,26,'Paudalho')," +
                    "(2610707,26,'Paulista')," +
                    "(2610806,26,'Pedra')," +
                    "(2610905,26,'Pesqueira')," +
                    "(2611002,26,'Petrol�ndia')," +
                    "(2611101,26,'Petrolina')," +
                    "(2611200,26,'Po��o')," +
                    "(2611309,26,'Pombos')," +
                    "(2611408,26,'Primavera')," +
                    "(2611507,26,'Quipap�')," +
                    "(2611533,26,'Quixaba')," +
                    "(2611606,26,'Recife')," +
                    "(2611705,26,'Riacho das Almas')," +
                    "(2611804,26,'Ribeir�o')," +
                    "(2611903,26,'Rio Formoso')," +
                    "(2612000,26,'Sair�')," +
                    "(2612109,26,'Salgadinho')," +
                    "(2612208,26,'Salgueiro')," +
                    "(2612307,26,'Salo�')," +
                    "(2612406,26,'Sanhar�')," +
                    "(2612455,26,'Santa Cruz')," +
                    "(2612471,26,'Santa Cruz da Baixa Verde')," +
                    "(2612505,26,'Santa Cruz do Capibaribe')," +
                    "(2612554,26,'Santa Filomena')," +
                    "(2612604,26,'Santa Maria da Boa Vista')," +
                    "(2612703,26,'Santa Maria do Cambuc�')," +
                    "(2612802,26,'Santa Terezinha')," +
                    "(2612901,26,'S�o Benedito do Sul')," +
                    "(2613008,26,'S�o Bento do Una')," +
                    "(2613107,26,'S�o Caitano')," +
                    "(2613206,26,'S�o Jo�o')," +
                    "(2613305,26,'S�o Joaquim do Monte')," +
                    "(2613404,26,'S�o Jos� da Coroa Grande')," +
                    "(2613503,26,'S�o Jos� do Belmonte')," +
                    "(2613602,26,'S�o Jos� do Egito')," +
                    "(2613701,26,'S�o Louren�o da Mata')," +
                    "(2613800,26,'S�o Vicente Ferrer')," +
                    "(2613909,26,'Serra Talhada')," +
                    "(2614006,26,'Serrita')," +
                    "(2614105,26,'Sert�nia')," +
                    "(2614204,26,'Sirinha�m')," +
                    "(2614303,26,'Moreil�ndia')," +
                    "(2614402,26,'Solid�o')," +
                    "(2614501,26,'Surubim')," +
                    "(2614600,26,'Tabira')," +
                    "(2614709,26,'Tacaimb�')," +
                    "(2614808,26,'Tacaratu')," +
                    "(2614857,26,'Tamandar�')," +
                    "(2615003,26,'Taquaritinga do Norte')," +
                    "(2615102,26,'Terezinha')," +
                    "(2615201,26,'Terra Nova')," +
                    "(2615300,26,'Timba�ba')," +
                    "(2615409,26,'Toritama')," +
                    "(2615508,26,'Tracunha�m')," +
                    "(2615607,26,'Trindade')," +
                    "(2615706,26,'Triunfo')," +
                    "(2615805,26,'Tupanatinga')," +
                    "(2615904,26,'Tuparetama')," +
                    "(2616001,26,'Venturosa')," +
                    "(2616100,26,'Verdejante')," +
                    "(2616183,26,'Vertente do L�rio')," +
                    "(2616209,26,'Vertentes')," +
                    "(2616308,26,'Vic�ncia')," +
                    "(2616407,26,'Vit�ria de Santo Ant�o')," +
                    "(2616506,26,'Xex�u')," +
                    "(2700102,27,'�gua Branca')," +
                    "(2700201,27,'Anadia')," +
                    "(2700300,27,'Arapiraca')," +
                    "(2700409,27,'Atalaia')," +
                    "(2700508,27,'Barra de Santo Ant�nio')," +
                    "(2700607,27,'Barra de S�o Miguel')," +
                    "(2700706,27,'Batalha')," +
                    "(2700805,27,'Bel�m')," +
                    "(2700904,27,'Belo Monte')," +
                    "(2701001,27,'Boca da Mata')," +
                    "(2701100,27,'Branquinha')," +
                    "(2701209,27,'Cacimbinhas')," +
                    "(2701308,27,'Cajueiro')," +
                    "(2701357,27,'Campestre')," +
                    "(2701407,27,'Campo Alegre')," +
                    "(2701506,27,'Campo Grande')," +
                    "(2701605,27,'Canapi')," +
                    "(2701704,27,'Capela')," +
                    "(2701803,27,'Carneiros')," +
                    "(2701902,27,'Ch� Preta')," +
                    "(2702009,27,'Coit� do N�ia')," +
                    "(2702108,27,'Col�nia Leopoldina')," +
                    "(2702207,27,'Coqueiro Seco')," +
                    "(2702306,27,'Coruripe')," +
                    "(2702355,27,'Cra�bas')," +
                    "(2702405,27,'delmiro Gouveia')," +
                    "(2702504,27,'dois Riachos')," +
                    "(2702553,27,'Estrela de Alagoas')," +
                    "(2702603,27,'Feira Grande')," +
                    "(2702702,27,'Feliz deserto')," +
                    "(2702801,27,'Flexeiras')," +
                    "(2702900,27,'Girau do Ponciano')," +
                    "(2703007,27,'Ibateguara')," +
                    "(2703106,27,'Igaci')," +
                    "(2703205,27,'Igreja Nova')," +
                    "(2703304,27,'Inhapi')," +
                    "(2703403,27,'Jacar� dos Homens')," +
                    "(2703502,27,'Jacu�pe')," +
                    "(2703601,27,'Japaratinga')," +
                    "(2703700,27,'Jaramataia')," +
                    "(2703759,27,'Jequi� da Praia')," +
                    "(2703809,27,'Joaquim Gomes')," +
                    "(2703908,27,'Jundi�')," +
                    "(2704005,27,'Junqueiro')," +
                    "(2704104,27,'Lagoa da Canoa')," +
                    "(2704203,27,'Limoeiro de Anadia')," +
                    "(2704302,27,'Macei�')," +
                    "(2704401,27,'Major Isidoro')," +
                    "(2704500,27,'Maragogi')," +
                    "(2704609,27,'Maravilha')," +
                    "(2704708,27,'Marechal deodoro')," +
                    "(2704807,27,'Maribondo')," +
                    "(2704906,27,'Mar Vermelho')," +
                    "(2705002,27,'Mata Grande')," +
                    "(2705101,27,'Matriz de Camaragibe')," +
                    "(2705200,27,'Messias')," +
                    "(2705309,27,'Minador do Negr�o')," +
                    "(2705408,27,'Monteir�polis')," +
                    "(2705507,27,'Murici')," +
                    "(2705606,27,'Novo Lino')," +
                    "(2705705,27,'Olho D�gua das Flores')," +
                    "(2705804,27,'Olho D�gua do Casado')," +
                    "(2705903,27,'Olho D�gua Grande')," +
                    "(2706000,27,'Oliven�a')," +
                    "(2706109,27,'Ouro Branco')," +
                    "(2706208,27,'Palestina')," +
                    "(2706307,27,'Palmeira dos �ndios')," +
                    "(2706406,27,'P�o de A��car')," +
                    "(2706422,27,'Pariconha')," +
                    "(2706448,27,'Paripueira')," +
                    "(2706505,27,'Passo de Camaragibe')," +
                    "(2706604,27,'Paulo Jacinto')," +
                    "(2706703,27,'Penedo')," +
                    "(2706802,27,'Pia�abu�u')," +
                    "(2706901,27,'Pilar')," +
                    "(2707008,27,'Pindoba')," +
                    "(2707107,27,'Piranhas')," +
                    "(2707206,27,'Po�o das Trincheiras')," +
                    "(2707305,27,'Porto Calvo')," +
                    "(2707404,27,'Porto de Pedras')," +
                    "(2707503,27,'Porto Real do Col�gio')," +
                    "(2707602,27,'Quebrangulo')," +
                    "(2707701,27,'Rio Largo')," +
                    "(2707800,27,'Roteiro')," +
                    "(2707909,27,'Santa Luzia do Norte')," +
                    "(2708006,27,'Santana do Ipanema')," +
                    "(2708105,27,'Santana do Munda�')," +
                    "(2708204,27,'S�o Br�s')," +
                    "(2708303,27,'S�o Jos� da Laje')," +
                    "(2708402,27,'S�o Jos� da Tapera')," +
                    "(2708501,27,'S�o Lu�s do Quitunde')," +
                    "(2708600,27,'S�o Miguel dos Campos')," +
                    "(2708709,27,'S�o Miguel dos Milagres')," +
                    "(2708808,27,'S�o Sebasti�o')," +
                    "(2708907,27,'Satuba')," +
                    "(2708956,27,'Senador Rui Palmeira')," +
                    "(2709004,27,'Tanque Darca')," +
                    "(2709103,27,'Taquarana')," +
                    "(2709152,27,'Teot�nio Vilela')," +
                    "(2709202,27,'Traipu')," +
                    "(2709301,27,'Uni�o dos Palmares')," +
                    "(2709400,27,'Vi�osa')," +
                    "(2800100,28,'Amparo de S�o Francisco')," +
                    "(2800209,28,'Aquidab�')," +
                    "(2800308,28,'Aracaju')," +
                    "(2800407,28,'Arau�')," +
                    "(2800506,28,'Areia Branca')," +
                    "(2800605,28,'Barra dos Coqueiros')," +
                    "(2800670,28,'Boquim')," +
                    "(2800704,28,'Brejo Grande')," +
                    "(2801009,28,'Campo do Brito')," +
                    "(2801108,28,'Canhoba')," +
                    "(2801207,28,'Canind� de S�o Francisco')," +
                    "(2801306,28,'Capela')," +
                    "(2801405,28,'Carira')," +
                    "(2801504,28,'Carm�polis')," +
                    "(2801603,28,'Cedro de S�o Jo�o')," +
                    "(2801702,28,'Cristin�polis')," +
                    "(2801900,28,'Cumbe')," +
                    "(2802007,28,'Divina Pastora')," +
                    "(2802106,28,'Est�ncia')," +
                    "(2802205,28,'Feira Nova')," +
                    "(2802304,28,'Frei Paulo')," +
                    "(2802403,28,'Gararu')," +
                    "(2802502,28,'General Maynard')," +
                    "(2802601,28,'Gracho Cardoso')," +
                    "(2802700,28,'Ilha das Flores')," +
                    "(2802809,28,'Indiaroba')," +
                    "(2802908,28,'Itabaiana')," +
                    "(2803005,28,'Itabaianinha')," +
                    "(2803104,28,'Itabi')," +
                    "(2803203,28,'Itaporanga Dajuda')," +
                    "(2803302,28,'Japaratuba')," +
                    "(2803401,28,'Japoat�')," +
                    "(2803500,28,'Lagarto')," +
                    "(2803609,28,'Laranjeiras')," +
                    "(2803708,28,'Macambira')," +
                    "(2803807,28,'Malhada dos Bois')," +
                    "(2803906,28,'Malhador')," +
                    "(2804003,28,'Maruim')," +
                    "(2804102,28,'Moita Bonita')," +
                    "(2804201,28,'Monte Alegre de Sergipe')," +
                    "(2804300,28,'Muribeca')," +
                    "(2804409,28,'Ne�polis')," +
                    "(2804458,28,'Nossa Senhora Aparecida')," +
                    "(2804508,28,'Nossa Senhora da Gl�ria')," +
                    "(2804607,28,'Nossa Senhora das dores')," +
                    "(2804706,28,'Nossa Senhora de Lourdes')," +
                    "(2804805,28,'Nossa Senhora do Socorro')," +
                    "(2804904,28,'Pacatuba')," +
                    "(2805000,28,'Pedra Mole')," +
                    "(2805109,28,'Pedrinhas')," +
                    "(2805208,28,'Pinh�o')," +
                    "(2805307,28,'Pirambu')," +
                    "(2805406,28,'Po�o Redondo')," +
                    "(2805505,28,'Po�o Verde')," +
                    "(2805604,28,'Porto da Folha')," +
                    "(2805703,28,'Propri�')," +
                    "(2805802,28,'Riach�o do dantas')," +
                    "(2805901,28,'Riachuelo')," +
                    "(2806008,28,'Ribeir�polis')," +
                    "(2806107,28,'Ros�rio do Catete')," +
                    "(2806206,28,'Salgado')," +
                    "(2806305,28,'Santa Luzia do Itanhy')," +
                    "(2806404,28,'Santana do S�o Francisco')," +
                    "(2806503,28,'Santa Rosa de Lima')," +
                    "(2806602,28,'Santo Amaro das Brotas')," +
                    "(2806701,28,'S�o Crist�v�o')," +
                    "(2806800,28,'S�o domingos')," +
                    "(2806909,28,'S�o Francisco')," +
                    "(2807006,28,'S�o Miguel do Aleixo')," +
                    "(2807105,28,'Sim�o Dias')," +
                    "(2807204,28,'Siriri')," +
                    "(2807303,28,'Telha')," +
                    "(2807402,28,'Tobias Barreto')," +
                    "(2807501,28,'Tomar do Geru')," +
                    "(2807600,28,'Umba�ba')," +
                    "(2900108,29,'Aba�ra')," +
                    "(2900207,29,'Abar�')," +
                    "(2900306,29,'Acajutiba')," +
                    "(2900355,29,'Adustina')," +
                    "(2900405,29,'�gua Fria')," +
                    "(2900504,29,'�rico Cardoso')," +
                    "(2900603,29,'Aiquara')," +
                    "(2900702,29,'Alagoinhas')," +
                    "(2900801,29,'Alcoba�a')," +
                    "(2900900,29,'Almadina')," +
                    "(2901007,29,'Amargosa')," +
                    "(2901106,29,'Am�lia Rodrigues')," +
                    "(2901155,29,'Am�rica dourada')," +
                    "(2901205,29,'Anag�')," +
                    "(2901304,29,'Andara�')," +
                    "(2901353,29,'Andorinha')," +
                    "(2901403,29,'Angical')," +
                    "(2901502,29,'Anguera')," +
                    "(2901601,29,'Antas')," +
                    "(2901700,29,'Ant�nio Cardoso')," +
                    "(2901809,29,'Ant�nio Gon�alves')," +
                    "(2901908,29,'Apor�')," +
                    "(2901957,29,'Apuarema')," +
                    "(2902005,29,'Aracatu')," +
                    "(2902054,29,'Ara�as')," +
                    "(2902104,29,'Araci')," +
                    "(2902203,29,'Aramari')," +
                    "(2902252,29,'Arataca')," +
                    "(2902302,29,'Aratu�pe')," +
                    "(2902401,29,'Aurelino Leal')," +
                    "(2902500,29,'Baian�polis')," +
                    "(2902609,29,'Baixa Grande')," +
                    "(2902658,29,'Banza�')," +
                    "(2902708,29,'Barra')," +
                    "(2902807,29,'Barra da Estiva')," +
                    "(2902906,29,'Barra do Cho�a')," +
                    "(2903003,29,'Barra do Mendes')," +
                    "(2903102,29,'Barra do Rocha')," +
                    "(2903201,29,'Barreiras')," +
                    "(2903235,29,'Barro Alto')," +
                    "(2903276,29,'Barrocas')," +
                    "(2903300,29,'Barro Preto')," +
                    "(2903409,29,'Belmonte')," +
                    "(2903508,29,'Belo Campo')," +
                    "(2903607,29,'Biritinga')," +
                    "(2903706,29,'Boa Nova')," +
                    "(2903805,29,'Boa Vista do Tupim')," +
                    "(2903904,29,'Bom Jesus da Lapa')," +
                    "(2903953,29,'Bom Jesus da Serra')," +
                    "(2904001,29,'Boninal')," +
                    "(2904050,29,'Bonito')," +
                    "(2904100,29,'Boquira')," +
                    "(2904209,29,'Botupor�')," +
                    "(2904308,29,'Brej�es')," +
                    "(2904407,29,'Brejol�ndia')," +
                    "(2904506,29,'Brotas de Maca�bas')," +
                    "(2904605,29,'Brumado')," +
                    "(2904704,29,'Buerarema')," +
                    "(2904753,29,'Buritirama')," +
                    "(2904803,29,'Caatiba')," +
                    "(2904852,29,'Cabaceiras do Paragua�u')," +
                    "(2904902,29,'Cachoeira')," +
                    "(2905008,29,'Cacul�')," +
                    "(2905107,29,'Ca�m')," +
                    "(2905156,29,'Caetanos')," +
                    "(2905206,29,'Caetit�')," +
                    "(2905305,29,'Cafarnaum')," +
                    "(2905404,29,'Cairu')," +
                    "(2905503,29,'Caldeir�o Grande')," +
                    "(2905602,29,'Camacan')," +
                    "(2905701,29,'Cama�ari')," +
                    "(2905800,29,'Camamu')," +
                    "(2905909,29,'Campo Alegre de Lourdes')," +
                    "(2906006,29,'Campo Formoso')," +
                    "(2906105,29,'Can�polis')," +
                    "(2906204,29,'Canarana')," +
                    "(2906303,29,'Canavieiras')," +
                    "(2906402,29,'Candeal')," +
                    "(2906501,29,'Candeias')," +
                    "(2906600,29,'Candiba')," +
                    "(2906709,29,'C�ndido Sales')," +
                    "(2906808,29,'Cansan��o')," +
                    "(2906824,29,'Canudos')," +
                    "(2906857,29,'Capela do Alto Alegre')," +
                    "(2906873,29,'Capim Grosso')," +
                    "(2906899,29,'Cara�bas')," +
                    "(2906907,29,'Caravelas')," +
                    "(2907004,29,'Cardeal da Silva')," +
                    "(2907103,29,'Carinhanha')," +
                    "(2907202,29,'Casa Nova')," +
                    "(2907301,29,'Castro Alves')," +
                    "(2907400,29,'Catol�ndia')," +
                    "(2907509,29,'Catu')," +
                    "(2907558,29,'Caturama')," +
                    "(2907608,29,'Central')," +
                    "(2907707,29,'Chorroch�')," +
                    "(2907806,29,'C�cero dantas')," +
                    "(2907905,29,'Cip�')," +
                    "(2908002,29,'Coaraci')," +
                    "(2908101,29,'Cocos')," +
                    "(2908200,29,'Concei��o da Feira')," +
                    "(2908309,29,'Concei��o do Almeida')," +
                    "(2908408,29,'Concei��o do Coit�')," +
                    "(2908507,29,'Concei��o do Jacu�pe')," +
                    "(2908606,29,'Conde')," +
                    "(2908705,29,'Conde�ba')," +
                    "(2908804,29,'Contendas do Sincor�')," +
                    "(2908903,29,'Cora��o de Maria')," +
                    "(2909000,29,'Cordeiros')," +
                    "(2909109,29,'Coribe')," +
                    "(2909208,29,'Coronel Jo�o S�')," +
                    "(2909307,29,'Correntina')," +
                    "(2909406,29,'Cotegipe')," +
                    "(2909505,29,'Cravol�ndia')," +
                    "(2909604,29,'Cris�polis')," +
                    "(2909703,29,'Crist�polis')," +
                    "(2909802,29,'Cruz das Almas')," +
                    "(2909901,29,'Cura��')," +
                    "(2910008,29,'D�rio Meira')," +
                    "(2910057,29,'Dias D�vila')," +
                    "(2910107,29,'dom Bas�lio')," +
                    "(2910206,29,'dom Macedo Costa')," +
                    "(2910305,29,'El�sio Medrado')," +
                    "(2910404,29,'Encruzilhada')," +
                    "(2910503,29,'Entre Rios')," +
                    "(2910602,29,'Esplanada')," +
                    "(2910701,29,'Euclides da Cunha')," +
                    "(2910727,29,'Eun�polis')," +
                    "(2910750,29,'F�tima')," +
                    "(2910776,29,'Feira da Mata')," +
                    "(2910800,29,'Feira de Santana')," +
                    "(2910859,29,'Filad�lfia')," +
                    "(2910909,29,'Firmino Alves')," +
                    "(2911006,29,'Floresta Azul')," +
                    "(2911105,29,'Formosa do Rio Preto')," +
                    "(2911204,29,'Gandu')," +
                    "(2911253,29,'Gavi�o')," +
                    "(2911303,29,'Gentio do Ouro')," +
                    "(2911402,29,'Gl�ria')," +
                    "(2911501,29,'Gongogi')," +
                    "(2911600,29,'Governador Mangabeira')," +
                    "(2911659,29,'Guajeru')," +
                    "(2911709,29,'Guanambi')," +
                    "(2911808,29,'Guaratinga')," +
                    "(2911857,29,'Heli�polis')," +
                    "(2911907,29,'Ia�u')," +
                    "(2912004,29,'Ibiassuc�')," +
                    "(2912103,29,'Ibicara�')," +
                    "(2912202,29,'Ibicoara')," +
                    "(2912301,29,'Ibicu�')," +
                    "(2912400,29,'Ibipeba')," +
                    "(2912509,29,'Ibipitanga')," +
                    "(2912608,29,'Ibiquera')," +
                    "(2912707,29,'Ibirapitanga')," +
                    "(2912806,29,'Ibirapu�')," +
                    "(2912905,29,'Ibirataia')," +
                    "(2913002,29,'Ibitiara')," +
                    "(2913101,29,'Ibitit�')," +
                    "(2913200,29,'Ibotirama')," +
                    "(2913309,29,'Ichu')," +
                    "(2913408,29,'Igapor�')," +
                    "(2913457,29,'Igrapi�na')," +
                    "(2913507,29,'Igua�')," +
                    "(2913606,29,'Ilh�us')," +
                    "(2913705,29,'Inhambupe')," +
                    "(2913804,29,'Ipecaet�')," +
                    "(2913903,29,'Ipia�')," +
                    "(2914000,29,'Ipir�')," +
                    "(2914109,29,'Ipupiara')," +
                    "(2914208,29,'Irajuba')," +
                    "(2914307,29,'Iramaia')," +
                    "(2914406,29,'Iraquara')," +
                    "(2914505,29,'Irar�')," +
                    "(2914604,29,'Irec�')," +
                    "(2914653,29,'Itabela')," +
                    "(2914703,29,'Itaberaba')," +
                    "(2914802,29,'Itabuna')," +
                    "(2914901,29,'Itacar�')," +
                    "(2915007,29,'Itaet�')," +
                    "(2915106,29,'Itagi')," +
                    "(2915205,29,'Itagib�')," +
                    "(2915304,29,'Itagimirim')," +
                    "(2915353,29,'Itagua�u da Bahia')," +
                    "(2915403,29,'Itaju do Col�nia')," +
                    "(2915502,29,'Itaju�pe')," +
                    "(2915601,29,'Itamaraju')," +
                    "(2915700,29,'Itamari')," +
                    "(2915809,29,'Itamb�')," +
                    "(2915908,29,'Itanagra')," +
                    "(2916005,29,'Itanh�m')," +
                    "(2916104,29,'Itaparica')," +
                    "(2916203,29,'Itap�')," +
                    "(2916302,29,'Itapebi')," +
                    "(2916401,29,'Itapetinga')," +
                    "(2916500,29,'Itapicuru')," +
                    "(2916609,29,'Itapitanga')," +
                    "(2916708,29,'Itaquara')," +
                    "(2916807,29,'Itarantim')," +
                    "(2916856,29,'Itatim')," +
                    "(2916906,29,'Itiru�u')," +
                    "(2917003,29,'Iti�ba')," +
                    "(2917102,29,'Itoror�')," +
                    "(2917201,29,'Itua�u')," +
                    "(2917300,29,'Ituber�')," +
                    "(2917334,29,'Iui�')," +
                    "(2917359,29,'Jaborandi')," +
                    "(2917409,29,'Jacaraci')," +
                    "(2917508,29,'Jacobina')," +
                    "(2917607,29,'Jaguaquara')," +
                    "(2917706,29,'Jaguarari')," +
                    "(2917805,29,'Jaguaripe')," +
                    "(2917904,29,'Janda�ra')," +
                    "(2918001,29,'Jequi�')," +
                    "(2918100,29,'Jeremoabo')," +
                    "(2918209,29,'Jiquiri��')," +
                    "(2918308,29,'Jita�na')," +
                    "(2918357,29,'Jo�o dourado')," +
                    "(2918407,29,'Juazeiro')," +
                    "(2918456,29,'Jucuru�u')," +
                    "(2918506,29,'Jussara')," +
                    "(2918555,29,'Jussari')," +
                    "(2918605,29,'Jussiape')," +
                    "(2918704,29,'Lafaiete Coutinho')," +
                    "(2918753,29,'Lagoa Real')," +
                    "(2918803,29,'Laje')," +
                    "(2918902,29,'Lajed�o')," +
                    "(2919009,29,'Lajedinho')," +
                    "(2919058,29,'Lajedo do Tabocal')," +
                    "(2919108,29,'Lamar�o')," +
                    "(2919157,29,'Lap�o')," +
                    "(2919207,29,'Lauro de Freitas')," +
                    "(2919306,29,'Len��is')," +
                    "(2919405,29,'Lic�nio de Almeida')," +
                    "(2919504,29,'Livramento de Nossa Senhora')," +
                    "(2919553,29,'Lu�s Eduardo Magalh�es')," +
                    "(2919603,29,'Macajuba')," +
                    "(2919702,29,'Macarani')," +
                    "(2919801,29,'Maca�bas')," +
                    "(2919900,29,'Macurur�')," +
                    "(2919926,29,'Madre de deus')," +
                    "(2919959,29,'Maetinga')," +
                    "(2920007,29,'Maiquinique')," +
                    "(2920106,29,'Mairi')," +
                    "(2920205,29,'Malhada')," +
                    "(2920304,29,'Malhada de Pedras')," +
                    "(2920403,29,'Manoel Vitorino')," +
                    "(2920452,29,'Mansid�o')," +
                    "(2920502,29,'Marac�s')," +
                    "(2920601,29,'Maragogipe')," +
                    "(2920700,29,'Mara�')," +
                    "(2920809,29,'Marcion�lio Souza')," +
                    "(2920908,29,'Mascote')," +
                    "(2921005,29,'Mata de S�o Jo�o')," +
                    "(2921054,29,'Matina')," +
                    "(2921104,29,'Medeiros Neto')," +
                    "(2921203,29,'Miguel Calmon')," +
                    "(2921302,29,'Milagres')," +
                    "(2921401,29,'Mirangaba')," +
                    "(2921450,29,'Mirante')," +
                    "(2921500,29,'Monte Santo')," +
                    "(2921609,29,'Morpar�')," +
                    "(2921708,29,'Morro do Chap�u')," +
                    "(2921807,29,'Mortugaba')," +
                    "(2921906,29,'Mucug�')," +
                    "(2922003,29,'Mucuri')," +
                    "(2922052,29,'Mulungu do Morro')," +
                    "(2922102,29,'Mundo Novo')," +
                    "(2922201,29,'Muniz Ferreira')," +
                    "(2922250,29,'Muqu�m de S�o Francisco')," +
                    "(2922300,29,'Muritiba')," +
                    "(2922409,29,'Mutu�pe')," +
                    "(2922508,29,'Nazar�')," +
                    "(2922607,29,'Nilo Pe�anha')," +
                    "(2922656,29,'Nordestina')," +
                    "(2922706,29,'Nova Cana�')," +
                    "(2922730,29,'Nova F�tima')," +
                    "(2922755,29,'Nova Ibi�')," +
                    "(2922805,29,'Nova Itarana')," +
                    "(2922854,29,'Nova Reden��o')," +
                    "(2922904,29,'Nova Soure')," +
                    "(2923001,29,'Nova Vi�osa')," +
                    "(2923035,29,'Novo Horizonte')," +
                    "(2923050,29,'Novo Triunfo')," +
                    "(2923100,29,'Olindina')," +
                    "(2923209,29,'Oliveira dos Brejinhos')," +
                    "(2923308,29,'Ouri�angas')," +
                    "(2923357,29,'Ourol�ndia')," +
                    "(2923407,29,'Palmas de Monte Alto')," +
                    "(2923506,29,'Palmeiras')," +
                    "(2923605,29,'Paramirim')," +
                    "(2923704,29,'Paratinga')," +
                    "(2923803,29,'Paripiranga')," +
                    "(2923902,29,'Pau Brasil')," +
                    "(2924009,29,'Paulo Afonso')," +
                    "(2924058,29,'P� de Serra')," +
                    "(2924108,29,'Pedr�o')," +
                    "(2924207,29,'Pedro Alexandre')," +
                    "(2924306,29,'Piat�')," +
                    "(2924405,29,'Pil�o Arcado')," +
                    "(2924504,29,'Pinda�')," +
                    "(2924603,29,'Pindoba�u')," +
                    "(2924652,29,'Pintadas')," +
                    "(2924678,29,'Pira� do Norte')," +
                    "(2924702,29,'Pirip�')," +
                    "(2924801,29,'Piritiba')," +
                    "(2924900,29,'Planaltino')," +
                    "(2925006,29,'Planalto')," +
                    "(2925105,29,'Po��es')," +
                    "(2925204,29,'Pojuca')," +
                    "(2925253,29,'Ponto Novo')," +
                    "(2925303,29,'Porto Seguro')," +
                    "(2925402,29,'Potiragu�')," +
                    "(2925501,29,'Prado')," +
                    "(2925600,29,'Presidente Dutra')," +
                    "(2925709,29,'Presidente J�nio Quadros')," +
                    "(2925758,29,'Presidente Tancredo Neves')," +
                    "(2925808,29,'Queimadas')," +
                    "(2925907,29,'Quijingue')," +
                    "(2925931,29,'Quixabeira')," +
                    "(2925956,29,'Rafael Jambeiro')," +
                    "(2926004,29,'Remanso')," +
                    "(2926103,29,'Retirol�ndia')," +
                    "(2926202,29,'Riach�o das Neves')," +
                    "(2926301,29,'Riach�o do Jacu�pe')," +
                    "(2926400,29,'Riacho de Santana')," +
                    "(2926509,29,'Ribeira do Amparo')," +
                    "(2926608,29,'Ribeira do Pombal')," +
                    "(2926657,29,'Ribeir�o do Largo')," +
                    "(2926707,29,'Rio de Contas')," +
                    "(2926806,29,'Rio do Ant�nio')," +
                    "(2926905,29,'Rio do Pires')," +
                    "(2927002,29,'Rio Real')," +
                    "(2927101,29,'Rodelas')," +
                    "(2927200,29,'Ruy Barbosa')," +
                    "(2927309,29,'Salinas da Margarida')," +
                    "(2927408,29,'Salvador')," +
                    "(2927507,29,'Santa B�rbara')," +
                    "(2927606,29,'Santa Br�gida')," +
                    "(2927705,29,'Santa Cruz Cabr�lia')," +
                    "(2927804,29,'Santa Cruz da Vit�ria')," +
                    "(2927903,29,'Santa In�s')," +
                    "(2928000,29,'Santaluz')," +
                    "(2928059,29,'Santa Luzia')," +
                    "(2928109,29,'Santa Maria da Vit�ria')," +
                    "(2928208,29,'Santana')," +
                    "(2928307,29,'Santan�polis')," +
                    "(2928406,29,'Santa Rita de C�ssia')," +
                    "(2928505,29,'Santa Teresinha')," +
                    "(2928604,29,'Santo Amaro')," +
                    "(2928703,29,'Santo Ant�nio de Jesus')," +
                    "(2928802,29,'Santo Est�v�o')," +
                    "(2928901,29,'S�o desid�rio')," +
                    "(2928950,29,'S�o domingos')," +
                    "(2929008,29,'S�o F�lix')," +
                    "(2929057,29,'S�o F�lix do Coribe')," +
                    "(2929107,29,'S�o Felipe')," +
                    "(2929206,29,'S�o Francisco do Conde')," +
                    "(2929255,29,'S�o Gabriel')," +
                    "(2929305,29,'S�o Gon�alo dos Campos')," +
                    "(2929354,29,'S�o Jos� da Vit�ria')," +
                    "(2929370,29,'S�o Jos� do Jacu�pe')," +
                    "(2929404,29,'S�o Miguel das Matas')," +
                    "(2929503,29,'S�o Sebasti�o do Pass�')," +
                    "(2929602,29,'Sapea�u')," +
                    "(2929701,29,'S�tiro Dias')," +
                    "(2929750,29,'Saubara')," +
                    "(2929800,29,'Sa�de')," +
                    "(2929909,29,'Seabra')," +
                    "(2930006,29,'Sebasti�o Laranjeiras')," +
                    "(2930105,29,'Senhor do Bonfim')," +
                    "(2930154,29,'Serra do Ramalho')," +
                    "(2930204,29,'Sento S�')," +
                    "(2930303,29,'Serra dourada')," +
                    "(2930402,29,'Serra Preta')," +
                    "(2930501,29,'Serrinha')," +
                    "(2930600,29,'Serrol�ndia')," +
                    "(2930709,29,'Sim�es Filho')," +
                    "(2930758,29,'S�tio do Mato')," +
                    "(2930766,29,'S�tio do Quinto')," +
                    "(2930774,29,'Sobradinho')," +
                    "(2930808,29,'Souto Soares')," +
                    "(2930907,29,'Tabocas do Brejo Velho')," +
                    "(2931004,29,'Tanha�u')," +
                    "(2931053,29,'Tanque Novo')," +
                    "(2931103,29,'Tanquinho')," +
                    "(2931202,29,'Tapero�')," +
                    "(2931301,29,'Tapiramut�')," +
                    "(2931350,29,'Teixeira de Freitas')," +
                    "(2931400,29,'Teodoro Sampaio')," +
                    "(2931509,29,'Teofil�ndia')," +
                    "(2931608,29,'Teol�ndia')," +
                    "(2931707,29,'Terra Nova')," +
                    "(2931806,29,'Tremedal')," +
                    "(2931905,29,'Tucano')," +
                    "(2932002,29,'Uau�')," +
                    "(2932101,29,'Uba�ra')," +
                    "(2932200,29,'Ubaitaba')," +
                    "(2932309,29,'Ubat�')," +
                    "(2932408,29,'Uiba�')," +
                    "(2932457,29,'Umburanas')," +
                    "(2932507,29,'Una')," +
                    "(2932606,29,'Urandi')," +
                    "(2932705,29,'Uru�uca')," +
                    "(2932804,29,'Utinga')," +
                    "(2932903,29,'Valen�a')," +
                    "(2933000,29,'Valente')," +
                    "(2933059,29,'V�rzea da Ro�a')," +
                    "(2933109,29,'V�rzea do Po�o')," +
                    "(2933158,29,'V�rzea Nova')," +
                    "(2933174,29,'Varzedo')," +
                    "(2933208,29,'Vera Cruz')," +
                    "(2933257,29,'Vereda')," +
                    "(2933307,29,'Vit�ria da Conquista')," +
                    "(2933406,29,'Wagner')," +
                    "(2933455,29,'Wanderley')," +
                    "(2933505,29,'Wenceslau Guimar�es')," +
                    "(2933604,29,'Xique-Xique')," +
                    "(3100104,31,'Abadia dos dourados')," +
                    "(3100203,31,'Abaet�')," +
                    "(3100302,31,'Abre Campo')," +
                    "(3100401,31,'Acaiaca')," +
                    "(3100500,31,'A�ucena')," +
                    "(3100609,31,'�gua Boa')," +
                    "(3100708,31,'�gua Comprida')," +
                    "(3100807,31,'Aguanil')," +
                    "(3100906,31,'�guas Formosas')," +
                    "(3101003,31,'�guas Vermelhas')," +
                    "(3101102,31,'Aimor�s')," +
                    "(3101201,31,'Aiuruoca')," +
                    "(3101300,31,'Alagoa')," +
                    "(3101409,31,'Albertina')," +
                    "(3101508,31,'Al�m Para�ba')," +
                    "(3101607,31,'Alfenas')," +
                    "(3101631,31,'Alfredo Vasconcelos')," +
                    "(3101706,31,'Almenara')," +
                    "(3101805,31,'Alpercata')," +
                    "(3101904,31,'Alpin�polis')," +
                    "(3102001,31,'Alterosa')," +
                    "(3102050,31,'Alto Capara�')," +
                    "(3102100,31,'Alto Rio doce')," +
                    "(3102209,31,'Alvarenga')," +
                    "(3102308,31,'Alvin�polis')," +
                    "(3102407,31,'Alvorada de Minas')," +
                    "(3102506,31,'Amparo do Serra')," +
                    "(3102605,31,'Andradas')," +
                    "(3102704,31,'Cachoeira de Paje�')," +
                    "(3102803,31,'Andrel�ndia')," +
                    "(3102852,31,'Angel�ndia')," +
                    "(3102902,31,'Ant�nio Carlos')," +
                    "(3103009,31,'Ant�nio Dias')," +
                    "(3103108,31,'Ant�nio Prado de Minas')," +
                    "(3103207,31,'Ara�a�')," +
                    "(3103306,31,'Aracitaba')," +
                    "(3103405,31,'Ara�ua�')," +
                    "(3103504,31,'Araguari')," +
                    "(3103603,31,'Arantina')," +
                    "(3103702,31,'Araponga')," +
                    "(3103751,31,'Arapor�')," +
                    "(3103801,31,'Arapu�')," +
                    "(3103900,31,'Ara�jos')," +
                    "(3104007,31,'Arax�')," +
                    "(3104106,31,'Arceburgo')," +
                    "(3104205,31,'Arcos')," +
                    "(3104304,31,'Areado')," +
                    "(3104403,31,'Argirita')," +
                    "(3104452,31,'Aricanduva')," +
                    "(3104502,31,'Arinos')," +
                    "(3104601,31,'Astolfo Dutra')," +
                    "(3104700,31,'Atal�ia')," +
                    "(3104809,31,'Augusto de Lima')," +
                    "(3104908,31,'Baependi')," +
                    "(3105004,31,'Baldim')," +
                    "(3105103,31,'Bambu�')," +
                    "(3105202,31,'Bandeira')," +
                    "(3105301,31,'Bandeira do Sul')," +
                    "(3105400,31,'Bar�o de Cocais')," +
                    "(3105509,31,'Bar�o de Monte Alto')," +
                    "(3105608,31,'Barbacena')," +
                    "(3105707,31,'Barra Longa')," +
                    "(3105905,31,'Barroso')," +
                    "(3106002,31,'Bela Vista de Minas')," +
                    "(3106101,31,'Belmiro Braga')," +
                    "(3106200,31,'Belo Horizonte')," +
                    "(3106309,31,'Belo Oriente')," +
                    "(3106408,31,'Belo Vale')," +
                    "(3106507,31,'Berilo')," +
                    "(3106606,31,'Bert�polis')," +
                    "(3106655,31,'Berizal')," +
                    "(3106705,31,'Betim')," +
                    "(3106804,31,'Bias Fortes')," +
                    "(3106903,31,'Bicas')," +
                    "(3107000,31,'Biquinhas')," +
                    "(3107109,31,'Boa Esperan�a')," +
                    "(3107208,31,'Bocaina de Minas')," +
                    "(3107307,31,'Bocai�va')," +
                    "(3107406,31,'Bom despacho')," +
                    "(3107505,31,'Bom Jardim de Minas')," +
                    "(3107604,31,'Bom Jesus da Penha')," +
                    "(3107703,31,'Bom Jesus do Amparo')," +
                    "(3107802,31,'Bom Jesus do Galho')," +
                    "(3107901,31,'Bom Repouso')," +
                    "(3108008,31,'Bom Sucesso')," +
                    "(3108107,31,'Bonfim')," +
                    "(3108206,31,'Bonfin�polis de Minas')," +
                    "(3108255,31,'Bonito de Minas')," +
                    "(3108305,31,'Borda da Mata')," +
                    "(3108404,31,'Botelhos')," +
                    "(3108503,31,'Botumirim')," +
                    "(3108552,31,'Brasil�ndia de Minas')," +
                    "(3108602,31,'Bras�lia de Minas')," +
                    "(3108701,31,'Br�s Pires')," +
                    "(3108800,31,'Bra�nas')," +
                    "(3108909,31,'Braz�polis')," +
                    "(3109006,31,'Brumadinho')," +
                    "(3109105,31,'Bueno Brand�o')," +
                    "(3109204,31,'Buen�polis')," +
                    "(3109253,31,'Bugre')," +
                    "(3109303,31,'Buritis')," +
                    "(3109402,31,'Buritizeiro')," +
                    "(3109451,31,'Cabeceira Grande')," +
                    "(3109501,31,'Cabo Verde')," +
                    "(3109600,31,'Cachoeira da Prata')," +
                    "(3109709,31,'Cachoeira de Minas')," +
                    "(3109808,31,'Cachoeira dourada')," +
                    "(3109907,31,'Caetan�polis')," +
                    "(3110004,31,'Caet�')," +
                    "(3110103,31,'Caiana')," +
                    "(3110202,31,'Cajuri')," +
                    "(3110301,31,'Caldas')," +
                    "(3110400,31,'Camacho')," +
                    "(3110509,31,'Camanducaia')," +
                    "(3110608,31,'Cambu�')," +
                    "(3110707,31,'Cambuquira')," +
                    "(3110806,31,'Campan�rio')," +
                    "(3110905,31,'Campanha')," +
                    "(3111002,31,'Campestre')," +
                    "(3111101,31,'Campina Verde')," +
                    "(3111150,31,'Campo Azul')," +
                    "(3111200,31,'Campo Belo')," +
                    "(3111309,31,'Campo do Meio')," +
                    "(3111408,31,'Campo Florido')," +
                    "(3111507,31,'Campos Altos')," +
                    "(3111606,31,'Campos Gerais')," +
                    "(3111705,31,'Cana�')," +
                    "(3111804,31,'Can�polis')," +
                    "(3111903,31,'Cana Verde')," +
                    "(3112000,31,'Candeias')," +
                    "(3112059,31,'Cantagalo')," +
                    "(3112109,31,'Capara�')," +
                    "(3112208,31,'Capela Nova')," +
                    "(3112307,31,'Capelinha')," +
                    "(3112406,31,'Capetinga')," +
                    "(3112505,31,'Capim Branco')," +
                    "(3112604,31,'Capin�polis')," +
                    "(3112653,31,'Capit�o Andrade')," +
                    "(3112703,31,'Capit�o En�as')," +
                    "(3112802,31,'Capit�lio')," +
                    "(3112901,31,'Caputira')," +
                    "(3113008,31,'Cara�')," +
                    "(3113107,31,'Carana�ba')," +
                    "(3113206,31,'Caranda�')," +
                    "(3113305,31,'Carangola')," +
                    "(3113404,31,'Caratinga')," +
                    "(3113503,31,'Carbonita')," +
                    "(3113602,31,'Carea�u')," +
                    "(3113701,31,'Carlos Chagas')," +
                    "(3113800,31,'Carm�sia')," +
                    "(3113909,31,'Carmo da Cachoeira')," +
                    "(3114006,31,'Carmo da Mata')," +
                    "(3114105,31,'Carmo de Minas')," +
                    "(3114204,31,'Carmo do Cajuru')," +
                    "(3114303,31,'Carmo do Parana�ba')," +
                    "(3114402,31,'Carmo do Rio Claro')," +
                    "(3114501,31,'Carm�polis de Minas')," +
                    "(3114550,31,'Carneirinho')," +
                    "(3114600,31,'Carrancas')," +
                    "(3114709,31,'Carvalh�polis')," +
                    "(3114808,31,'Carvalhos')," +
                    "(3114907,31,'Casa Grande')," +
                    "(3115003,31,'Cascalho Rico')," +
                    "(3115102,31,'C�ssia')," +
                    "(3115201,31,'Concei��o da Barra de Minas')," +
                    "(3115300,31,'Cataguases')," +
                    "(3115359,31,'Catas Altas')," +
                    "(3115409,31,'Catas Altas da Noruega')," +
                    "(3115458,31,'Catuji')," +
                    "(3115474,31,'Catuti')," +
                    "(3115508,31,'Caxambu')," +
                    "(3115607,31,'Cedro do Abaet�')," +
                    "(3115706,31,'Central de Minas')," +
                    "(3115805,31,'Centralina')," +
                    "(3115904,31,'Ch�cara')," +
                    "(3116001,31,'Chal�')," +
                    "(3116100,31,'Chapada do Norte')," +
                    "(3116159,31,'Chapada Ga�cha')," +
                    "(3116209,31,'Chiador')," +
                    "(3116308,31,'Cipot�nea')," +
                    "(3116407,31,'Claraval')," +
                    "(3116506,31,'Claro dos Po��es')," +
                    "(3116605,31,'Cl�udio')," +
                    "(3116704,31,'Coimbra')," +
                    "(3116803,31,'Coluna')," +
                    "(3116902,31,'Comendador Gomes')," +
                    "(3117009,31,'Comercinho')," +
                    "(3117108,31,'Concei��o da Aparecida')," +
                    "(3117207,31,'Concei��o das Pedras')," +
                    "(3117306,31,'Concei��o das Alagoas')," +
                    "(3117405,31,'Concei��o de Ipanema')," +
                    "(3117504,31,'Concei��o do Mato dentro')," +
                    "(3117603,31,'Concei��o do Par�')," +
                    "(3117702,31,'Concei��o do Rio Verde')," +
                    "(3117801,31,'Concei��o dos Ouros')," +
                    "(3117836,31,'C�nego Marinho')," +
                    "(3117876,31,'Confins')," +
                    "(3117900,31,'Congonhal')," +
                    "(3118007,31,'Congonhas')," +
                    "(3118106,31,'Congonhas do Norte')," +
                    "(3118205,31,'Conquista')," +
                    "(3118304,31,'Conselheiro Lafaiete')," +
                    "(3118403,31,'Conselheiro Pena')," +
                    "(3118502,31,'Consola��o')," +
                    "(3118601,31,'Contagem')," +
                    "(3118700,31,'Coqueiral')," +
                    "(3118809,31,'Cora��o de Jesus')," +
                    "(3118908,31,'Cordisburgo')," +
                    "(3119005,31,'Cordisl�ndia')," +
                    "(3119104,31,'Corinto')," +
                    "(3119203,31,'Coroaci')," +
                    "(3119302,31,'Coromandel')," +
                    "(3119401,31,'Coronel Fabriciano')," +
                    "(3119500,31,'Coronel Murta')," +
                    "(3119609,31,'Coronel Pacheco')," +
                    "(3119708,31,'Coronel Xavier Chaves')," +
                    "(3119807,31,'C�rrego danta')," +
                    "(3119906,31,'C�rrego do Bom Jesus')," +
                    "(3119955,31,'C�rrego Fundo')," +
                    "(3120003,31,'C�rrego Novo')," +
                    "(3120102,31,'Couto de Magalh�es de Minas')," +
                    "(3120151,31,'Cris�lita')," +
                    "(3120201,31,'Cristais')," +
                    "(3120300,31,'Crist�lia')," +
                    "(3120409,31,'Cristiano Otoni')," +
                    "(3120508,31,'Cristina')," +
                    "(3120607,31,'Crucil�ndia')," +
                    "(3120706,31,'Cruzeiro da Fortaleza')," +
                    "(3120805,31,'Cruz�lia')," +
                    "(3120839,31,'Cuparaque')," +
                    "(3120870,31,'Curral de dentro')," +
                    "(3120904,31,'Curvelo')," +
                    "(3121001,31,'datas')," +
                    "(3121100,31,'delfim Moreira')," +
                    "(3121209,31,'delfin�polis')," +
                    "(3121258,31,'delta')," +
                    "(3121308,31,'descoberto')," +
                    "(3121407,31,'desterro de Entre Rios')," +
                    "(3121506,31,'desterro do Melo')," +
                    "(3121605,31,'Diamantina')," +
                    "(3121704,31,'Diogo de Vasconcelos')," +
                    "(3121803,31,'Dion�sio')," +
                    "(3121902,31,'Divin�sia')," +
                    "(3122009,31,'Divino')," +
                    "(3122108,31,'Divino das Laranjeiras')," +
                    "(3122207,31,'Divinol�ndia de Minas')," +
                    "(3122306,31,'Divin�polis')," +
                    "(3122355,31,'Divisa Alegre')," +
                    "(3122405,31,'Divisa Nova')," +
                    "(3122454,31,'Divis�polis')," +
                    "(3122470,31,'dom Bosco')," +
                    "(3122504,31,'dom Cavati')," +
                    "(3122603,31,'dom Joaquim')," +
                    "(3122702,31,'dom Silv�rio')," +
                    "(3122801,31,'dom Vi�oso')," +
                    "(3122900,31,'dona Eus�bia')," +
                    "(3123007,31,'dores de Campos')," +
                    "(3123106,31,'dores de Guanh�es')," +
                    "(3123205,31,'dores do Indai�')," +
                    "(3123304,31,'dores do Turvo')," +
                    "(3123403,31,'dores�polis')," +
                    "(3123502,31,'douradoquara')," +
                    "(3123528,31,'Durand�')," +
                    "(3123601,31,'El�i Mendes')," +
                    "(3123700,31,'Engenheiro Caldas')," +
                    "(3123809,31,'Engenheiro Navarro')," +
                    "(3123858,31,'Entre Folhas')," +
                    "(3123908,31,'Entre Rios de Minas')," +
                    "(3124005,31,'Erv�lia')," +
                    "(3124104,31,'Esmeraldas')," +
                    "(3124203,31,'Espera Feliz')," +
                    "(3124302,31,'Espinosa')," +
                    "(3124401,31,'Esp�rito Santo do dourado')," +
                    "(3124500,31,'Estiva')," +
                    "(3124609,31,'Estrela dalva')," +
                    "(3124708,31,'Estrela do Indai�')," +
                    "(3124807,31,'Estrela do Sul')," +
                    "(3124906,31,'Eugen�polis')," +
                    "(3125002,31,'Ewbank da C�mara')," +
                    "(3125101,31,'Extrema')," +
                    "(3125200,31,'Fama')," +
                    "(3125309,31,'Faria Lemos')," +
                    "(3125408,31,'Fel�cio dos Santos')," +
                    "(3125507,31,'S�o Gon�alo do Rio Preto')," +
                    "(3125606,31,'Felisburgo')," +
                    "(3125705,31,'Felixl�ndia')," +
                    "(3125804,31,'Fernandes Tourinho')," +
                    "(3125903,31,'Ferros')," +
                    "(3125952,31,'Fervedouro')," +
                    "(3126000,31,'Florestal')," +
                    "(3126109,31,'Formiga')," +
                    "(3126208,31,'Formoso')," +
                    "(3126307,31,'Fortaleza de Minas')," +
                    "(3126406,31,'Fortuna de Minas')," +
                    "(3126505,31,'Francisco Badar�')," +
                    "(3126604,31,'Francisco Dumont')," +
                    "(3126703,31,'Francisco S�')," +
                    "(3126752,31,'Francisc�polis')," +
                    "(3126802,31,'Frei Gaspar')," +
                    "(3126901,31,'Frei Inoc�ncio')," +
                    "(3126950,31,'Frei Lagonegro')," +
                    "(3127008,31,'Fronteira')," +
                    "(3127057,31,'Fronteira dos Vales')," +
                    "(3127073,31,'Fruta de Leite')," +
                    "(3127107,31,'Frutal')," +
                    "(3127206,31,'Funil�ndia')," +
                    "(3127305,31,'Galil�ia')," +
                    "(3127339,31,'Gameleiras')," +
                    "(3127354,31,'Glaucil�ndia')," +
                    "(3127370,31,'Goiabeira')," +
                    "(3127388,31,'Goian�')," +
                    "(3127404,31,'Gon�alves')," +
                    "(3127503,31,'Gonzaga')," +
                    "(3127602,31,'Gouveia')," +
                    "(3127701,31,'Governador Valadares')," +
                    "(3127800,31,'Gr�o Mogol')," +
                    "(3127909,31,'Grupiara')," +
                    "(3128006,31,'Guanh�es')," +
                    "(3128105,31,'Guap�')," +
                    "(3128204,31,'Guaraciaba')," +
                    "(3128253,31,'Guaraciama')," +
                    "(3128303,31,'Guaran�sia')," +
                    "(3128402,31,'Guarani')," +
                    "(3128501,31,'Guarar�')," +
                    "(3128600,31,'Guarda-Mor')," +
                    "(3128709,31,'Guaxup�')," +
                    "(3128808,31,'Guidoval')," +
                    "(3128907,31,'Guimar�nia')," +
                    "(3129004,31,'Guiricema')," +
                    "(3129103,31,'Gurinhat�')," +
                    "(3129202,31,'Heliodora')," +
                    "(3129301,31,'Iapu')," +
                    "(3129400,31,'Ibertioga')," +
                    "(3129509,31,'Ibi�')," +
                    "(3129608,31,'Ibia�')," +
                    "(3129657,31,'Ibiracatu')," +
                    "(3129707,31,'Ibiraci')," +
                    "(3129806,31,'Ibirit�')," +
                    "(3129905,31,'Ibiti�ra de Minas')," +
                    "(3130002,31,'Ibituruna')," +
                    "(3130051,31,'Icara� de Minas')," +
                    "(3130101,31,'Igarap�')," +
                    "(3130200,31,'Igaratinga')," +
                    "(3130309,31,'Iguatama')," +
                    "(3130408,31,'Ijaci')," +
                    "(3130507,31,'Ilic�nea')," +
                    "(3130556,31,'Imb� de Minas')," +
                    "(3130606,31,'Inconfidentes')," +
                    "(3130655,31,'Indaiabira')," +
                    "(3130705,31,'Indian�polis')," +
                    "(3130804,31,'Inga�')," +
                    "(3130903,31,'Inhapim')," +
                    "(3131000,31,'Inha�ma')," +
                    "(3131109,31,'Inimutaba')," +
                    "(3131158,31,'Ipaba')," +
                    "(3131208,31,'Ipanema')," +
                    "(3131307,31,'Ipatinga')," +
                    "(3131406,31,'Ipia�u')," +
                    "(3131505,31,'Ipui�na')," +
                    "(3131604,31,'Ira� de Minas')," +
                    "(3131703,31,'Itabira')," +
                    "(3131802,31,'Itabirinha')," +
                    "(3131901,31,'Itabirito')," +
                    "(3132008,31,'Itacambira')," +
                    "(3132107,31,'Itacarambi')," +
                    "(3132206,31,'Itaguara')," +
                    "(3132305,31,'Itaip�')," +
                    "(3132404,31,'Itajub�')," +
                    "(3132503,31,'Itamarandiba')," +
                    "(3132602,31,'Itamarati de Minas')," +
                    "(3132701,31,'Itambacuri')," +
                    "(3132800,31,'Itamb� do Mato dentro')," +
                    "(3132909,31,'Itamogi')," +
                    "(3133006,31,'Itamonte')," +
                    "(3133105,31,'Itanhandu')," +
                    "(3133204,31,'Itanhomi')," +
                    "(3133303,31,'Itaobim')," +
                    "(3133402,31,'Itapagipe')," +
                    "(3133501,31,'Itapecerica')," +
                    "(3133600,31,'Itapeva')," +
                    "(3133709,31,'Itatiaiu�u')," +
                    "(3133758,31,'Ita� de Minas')," +
                    "(3133808,31,'Ita�na')," +
                    "(3133907,31,'Itaverava')," +
                    "(3134004,31,'Itinga')," +
                    "(3134103,31,'Itueta')," +
                    "(3134202,31,'Ituiutaba')," +
                    "(3134301,31,'Itumirim')," +
                    "(3134400,31,'Iturama')," +
                    "(3134509,31,'Itutinga')," +
                    "(3134608,31,'Jaboticatubas')," +
                    "(3134707,31,'Jacinto')," +
                    "(3134806,31,'Jacu�')," +
                    "(3134905,31,'Jacutinga')," +
                    "(3135001,31,'Jaguara�u')," +
                    "(3135050,31,'Ja�ba')," +
                    "(3135076,31,'Jampruca')," +
                    "(3135100,31,'Jana�ba')," +
                    "(3135209,31,'Janu�ria')," +
                    "(3135308,31,'Japara�ba')," +
                    "(3135357,31,'Japonvar')," +
                    "(3135407,31,'Jeceaba')," +
                    "(3135456,31,'Jenipapo de Minas')," +
                    "(3135506,31,'Jequeri')," +
                    "(3135605,31,'Jequita�')," +
                    "(3135704,31,'Jequitib�')," +
                    "(3135803,31,'Jequitinhonha')," +
                    "(3135902,31,'Jesu�nia')," +
                    "(3136009,31,'Joa�ma')," +
                    "(3136108,31,'Joan�sia')," +
                    "(3136207,31,'Jo�o Monlevade')," +
                    "(3136306,31,'Jo�o Pinheiro')," +
                    "(3136405,31,'Joaquim Fel�cio')," +
                    "(3136504,31,'Jord�nia')," +
                    "(3136520,31,'Jos� Gon�alves de Minas')," +
                    "(3136553,31,'Jos� Raydan')," +
                    "(3136579,31,'Josen�polis')," +
                    "(3136603,31,'Nova Uni�o')," +
                    "(3136652,31,'Juatuba')," +
                    "(3136702,31,'Juiz de Fora')," +
                    "(3136801,31,'Juramento')," +
                    "(3136900,31,'Juruaia')," +
                    "(3136959,31,'Juven�lia')," +
                    "(3137007,31,'Ladainha')," +
                    "(3137106,31,'Lagamar')," +
                    "(3137205,31,'Lagoa da Prata')," +
                    "(3137304,31,'Lagoa dos Patos')," +
                    "(3137403,31,'Lagoa dourada')," +
                    "(3137502,31,'Lagoa Formosa')," +
                    "(3137536,31,'Lagoa Grande')," +
                    "(3137601,31,'Lagoa Santa')," +
                    "(3137700,31,'Lajinha')," +
                    "(3137809,31,'Lambari')," +
                    "(3137908,31,'Lamim')," +
                    "(3138005,31,'Laranjal')," +
                    "(3138104,31,'Lassance')," +
                    "(3138203,31,'Lavras')," +
                    "(3138302,31,'Leandro Ferreira')," +
                    "(3138351,31,'Leme do Prado')," +
                    "(3138401,31,'Leopoldina')," +
                    "(3138500,31,'Liberdade')," +
                    "(3138609,31,'Lima Duarte')," +
                    "(3138625,31,'Limeira do Oeste')," +
                    "(3138658,31,'Lontra')," +
                    "(3138674,31,'Luisburgo')," +
                    "(3138682,31,'Luisl�ndia')," +
                    "(3138708,31,'Lumin�rias')," +
                    "(3138807,31,'Luz')," +
                    "(3138906,31,'Machacalis')," +
                    "(3139003,31,'Machado')," +
                    "(3139102,31,'Madre de deus de Minas')," +
                    "(3139201,31,'Malacacheta')," +
                    "(3139250,31,'Mamonas')," +
                    "(3139300,31,'Manga')," +
                    "(3139409,31,'Manhua�u')," +
                    "(3139508,31,'Manhumirim')," +
                    "(3139607,31,'Mantena')," +
                    "(3139706,31,'Maravilhas')," +
                    "(3139805,31,'Mar de Espanha')," +
                    "(3139904,31,'Maria da F�')," +
                    "(3140001,31,'Mariana')," +
                    "(3140100,31,'Marilac')," +
                    "(3140159,31,'M�rio Campos')," +
                    "(3140209,31,'Marip� de Minas')," +
                    "(3140308,31,'Marli�ria')," +
                    "(3140407,31,'Marmel�polis')," +
                    "(3140506,31,'Martinho Campos')," +
                    "(3140530,31,'Martins Soares')," +
                    "(3140555,31,'Mata Verde')," +
                    "(3140605,31,'Materl�ndia')," +
                    "(3140704,31,'Mateus Leme')," +
                    "(3140803,31,'Matias Barbosa')," +
                    "(3140852,31,'Matias Cardoso')," +
                    "(3140902,31,'Matip�')," +
                    "(3141009,31,'Mato Verde')," +
                    "(3141108,31,'Matozinhos')," +
                    "(3141207,31,'Matutina')," +
                    "(3141306,31,'Medeiros')," +
                    "(3141405,31,'Medina')," +
                    "(3141504,31,'Mendes Pimentel')," +
                    "(3141603,31,'Merc�s')," +
                    "(3141702,31,'Mesquita')," +
                    "(3141801,31,'Minas Novas')," +
                    "(3141900,31,'Minduri')," +
                    "(3142007,31,'Mirabela')," +
                    "(3142106,31,'Miradouro')," +
                    "(3142205,31,'Mira�')," +
                    "(3142254,31,'Mirav�nia')," +
                    "(3142304,31,'Moeda')," +
                    "(3142403,31,'Moema')," +
                    "(3142502,31,'Monjolos')," +
                    "(3142601,31,'Monsenhor Paulo')," +
                    "(3142700,31,'Montalv�nia')," +
                    "(3142809,31,'Monte Alegre de Minas')," +
                    "(3142908,31,'Monte Azul')," +
                    "(3143005,31,'Monte Belo')," +
                    "(3143104,31,'Monte Carmelo')," +
                    "(3143153,31,'Monte Formoso')," +
                    "(3143203,31,'Monte Santo de Minas')," +
                    "(3143302,31,'Montes Claros')," +
                    "(3143401,31,'Monte Si�o')," +
                    "(3143450,31,'Montezuma')," +
                    "(3143500,31,'Morada Nova de Minas')," +
                    "(3143609,31,'Morro da Gar�a')," +
                    "(3143708,31,'Morro do Pilar')," +
                    "(3143807,31,'Munhoz')," +
                    "(3143906,31,'Muria�')," +
                    "(3144003,31,'Mutum')," +
                    "(3144102,31,'Muzambinho')," +
                    "(3144201,31,'Nacip Raydan')," +
                    "(3144300,31,'Nanuque')," +
                    "(3144359,31,'Naque')," +
                    "(3144375,31,'Natal�ndia')," +
                    "(3144409,31,'Nat�rcia')," +
                    "(3144508,31,'Nazareno')," +
                    "(3144607,31,'Nepomuceno')," +
                    "(3144656,31,'Ninheira')," +
                    "(3144672,31,'Nova Bel�m')," +
                    "(3144706,31,'Nova Era')," +
                    "(3144805,31,'Nova Lima')," +
                    "(3144904,31,'Nova M�dica')," +
                    "(3145000,31,'Nova Ponte')," +
                    "(3145059,31,'Nova Porteirinha')," +
                    "(3145109,31,'Nova Resende')," +
                    "(3145208,31,'Nova Serrana')," +
                    "(3145307,31,'Novo Cruzeiro')," +
                    "(3145356,31,'Novo Oriente de Minas')," +
                    "(3145372,31,'Novorizonte')," +
                    "(3145406,31,'Olaria')," +
                    "(3145455,31,'Olhos-D�gua')," +
                    "(3145505,31,'Ol�mpio Noronha')," +
                    "(3145604,31,'Oliveira')," +
                    "(3145703,31,'Oliveira Fortes')," +
                    "(3145802,31,'On�a de Pitangui')," +
                    "(3145851,31,'Orat�rios')," +
                    "(3145877,31,'Oriz�nia')," +
                    "(3145901,31,'Ouro Branco')," +
                    "(3146008,31,'Ouro Fino')," +
                    "(3146107,31,'Ouro Preto')," +
                    "(3146206,31,'Ouro Verde de Minas')," +
                    "(3146255,31,'Padre Carvalho')," +
                    "(3146305,31,'Padre Para�so')," +
                    "(3146404,31,'Paineiras')," +
                    "(3146503,31,'Pains')," +
                    "(3146552,31,'Pai Pedro')," +
                    "(3146602,31,'Paiva')," +
                    "(3146701,31,'Palma')," +
                    "(3146750,31,'Palm�polis')," +
                    "(3146909,31,'Papagaios')," +
                    "(3147006,31,'Paracatu')," +
                    "(3147105,31,'Par� de Minas')," +
                    "(3147204,31,'Paragua�u')," +
                    "(3147303,31,'Parais�polis')," +
                    "(3147402,31,'Paraopeba')," +
                    "(3147501,31,'Passab�m')," +
                    "(3147600,31,'Passa Quatro')," +
                    "(3147709,31,'Passa Tempo')," +
                    "(3147808,31,'Passa-Vinte')," +
                    "(3147907,31,'Passos')," +
                    "(3147956,31,'Patis')," +
                    "(3148004,31,'Patos de Minas')," +
                    "(3148103,31,'Patroc�nio')," +
                    "(3148202,31,'Patroc�nio do Muria�')," +
                    "(3148301,31,'Paula C�ndido')," +
                    "(3148400,31,'Paulistas')," +
                    "(3148509,31,'Pav�o')," +
                    "(3148608,31,'Pe�anha')," +
                    "(3148707,31,'Pedra Azul')," +
                    "(3148756,31,'Pedra Bonita')," +
                    "(3148806,31,'Pedra do Anta')," +
                    "(3148905,31,'Pedra do Indai�')," +
                    "(3149002,31,'Pedra dourada')," +
                    "(3149101,31,'Pedralva')," +
                    "(3149150,31,'Pedras de Maria da Cruz')," +
                    "(3149200,31,'Pedrin�polis')," +
                    "(3149309,31,'Pedro Leopoldo')," +
                    "(3149408,31,'Pedro Teixeira')," +
                    "(3149507,31,'Pequeri')," +
                    "(3149606,31,'Pequi')," +
                    "(3149705,31,'Perdig�o')," +
                    "(3149804,31,'Perdizes')," +
                    "(3149903,31,'Perd�es')," +
                    "(3149952,31,'Periquito')," +
                    "(3150000,31,'Pescador')," +
                    "(3150109,31,'Piau')," +
                    "(3150158,31,'Piedade de Caratinga')," +
                    "(3150208,31,'Piedade de Ponte Nova')," +
                    "(3150307,31,'Piedade do Rio Grande')," +
                    "(3150406,31,'Piedade dos Gerais')," +
                    "(3150505,31,'Pimenta')," +
                    "(3150539,31,'Pingo-D�gua')," +
                    "(3150570,31,'Pint�polis')," +
                    "(3150604,31,'Piracema')," +
                    "(3150703,31,'Pirajuba')," +
                    "(3150802,31,'Piranga')," +
                    "(3150901,31,'Pirangu�u')," +
                    "(3151008,31,'Piranguinho')," +
                    "(3151107,31,'Pirapetinga')," +
                    "(3151206,31,'Pirapora')," +
                    "(3151305,31,'Pira�ba')," +
                    "(3151404,31,'Pitangui')," +
                    "(3151503,31,'Piumhi')," +
                    "(3151602,31,'Planura')," +
                    "(3151701,31,'Po�o Fundo')," +
                    "(3151800,31,'Po�os de Caldas')," +
                    "(3151909,31,'Pocrane')," +
                    "(3152006,31,'Pomp�u')," +
                    "(3152105,31,'Ponte Nova')," +
                    "(3152131,31,'Ponto Chique')," +
                    "(3152170,31,'Ponto dos Volantes')," +
                    "(3152204,31,'Porteirinha')," +
                    "(3152303,31,'Porto Firme')," +
                    "(3152402,31,'Pot�')," +
                    "(3152501,31,'Pouso Alegre')," +
                    "(3152600,31,'Pouso Alto')," +
                    "(3152709,31,'Prados')," +
                    "(3152808,31,'Prata')," +
                    "(3152907,31,'Prat�polis')," +
                    "(3153004,31,'Pratinha')," +
                    "(3153103,31,'Presidente Bernardes')," +
                    "(3153202,31,'Presidente Juscelino')," +
                    "(3153301,31,'Presidente Kubitschek')," +
                    "(3153400,31,'Presidente Oleg�rio')," +
                    "(3153509,31,'Alto Jequitib�')," +
                    "(3153608,31,'Prudente de Morais')," +
                    "(3153707,31,'Quartel Geral')," +
                    "(3153806,31,'Queluzito')," +
                    "(3153905,31,'Raposos')," +
                    "(3154002,31,'Raul Soares')," +
                    "(3154101,31,'Recreio')," +
                    "(3154150,31,'Reduto')," +
                    "(3154200,31,'Resende Costa')," +
                    "(3154309,31,'Resplendor')," +
                    "(3154408,31,'Ressaquinha')," +
                    "(3154457,31,'Riachinho')," +
                    "(3154507,31,'Riacho dos Machados')," +
                    "(3154606,31,'Ribeir�o das Neves')," +
                    "(3154705,31,'Ribeir�o Vermelho')," +
                    "(3154804,31,'Rio Acima')," +
                    "(3154903,31,'Rio Casca')," +
                    "(3155009,31,'Rio doce')," +
                    "(3155108,31,'Rio do Prado')," +
                    "(3155207,31,'Rio Espera')," +
                    "(3155306,31,'Rio Manso')," +
                    "(3155405,31,'Rio Novo')," +
                    "(3155504,31,'Rio Parana�ba')," +
                    "(3155603,31,'Rio Pardo de Minas')," +
                    "(3155702,31,'Rio Piracicaba')," +
                    "(3155801,31,'Rio Pomba')," +
                    "(3155900,31,'Rio Preto')," +
                    "(3156007,31,'Rio Vermelho')," +
                    "(3156106,31,'Rit�polis')," +
                    "(3156205,31,'Rochedo de Minas')," +
                    "(3156304,31,'Rodeiro')," +
                    "(3156403,31,'Romaria')," +
                    "(3156452,31,'Ros�rio da Limeira')," +
                    "(3156502,31,'Rubelita')," +
                    "(3156601,31,'Rubim')," +
                    "(3156700,31,'Sabar�')," +
                    "(3156809,31,'Sabin�polis')," +
                    "(3156908,31,'Sacramento')," +
                    "(3157005,31,'Salinas')," +
                    "(3157104,31,'Salto da Divisa')," +
                    "(3157203,31,'Santa B�rbara')," +
                    "(3157252,31,'Santa B�rbara do Leste')," +
                    "(3157278,31,'Santa B�rbara do Monte Verde')," +
                    "(3157302,31,'Santa B�rbara do Tug�rio')," +
                    "(3157336,31,'Santa Cruz de Minas')," +
                    "(3157377,31,'Santa Cruz de Salinas')," +
                    "(3157401,31,'Santa Cruz do Escalvado')," +
                    "(3157500,31,'Santa Efig�nia de Minas')," +
                    "(3157609,31,'Santa F� de Minas')," +
                    "(3157658,31,'Santa Helena de Minas')," +
                    "(3157708,31,'Santa Juliana')," +
                    "(3157807,31,'Santa Luzia')," +
                    "(3157906,31,'Santa Margarida')," +
                    "(3158003,31,'Santa Maria de Itabira')," +
                    "(3158102,31,'Santa Maria do Salto')," +
                    "(3158201,31,'Santa Maria do Sua�u�')," +
                    "(3158300,31,'Santana da Vargem')," +
                    "(3158409,31,'Santana de Cataguases')," +
                    "(3158508,31,'Santana de Pirapama')," +
                    "(3158607,31,'Santana do deserto')," +
                    "(3158706,31,'Santana do Garamb�u')," +
                    "(3158805,31,'Santana do Jacar�')," +
                    "(3158904,31,'Santana do Manhua�u')," +
                    "(3158953,31,'Santana do Para�so')," +
                    "(3159001,31,'Santana do Riacho')," +
                    "(3159100,31,'Santana dos Montes')," +
                    "(3159209,31,'Santa Rita de Caldas')," +
                    "(3159308,31,'Santa Rita de Jacutinga')," +
                    "(3159357,31,'Santa Rita de Minas')," +
                    "(3159407,31,'Santa Rita de Ibitipoca')," +
                    "(3159506,31,'Santa Rita do Itueto')," +
                    "(3159605,31,'Santa Rita do Sapuca�')," +
                    "(3159704,31,'Santa Rosa da Serra')," +
                    "(3159803,31,'Santa Vit�ria')," +
                    "(3159902,31,'Santo Ant�nio do Amparo')," +
                    "(3160009,31,'Santo Ant�nio do Aventureiro')," +
                    "(3160108,31,'Santo Ant�nio do Grama')," +
                    "(3160207,31,'Santo Ant�nio do Itamb�')," +
                    "(3160306,31,'Santo Ant�nio do Jacinto')," +
                    "(3160405,31,'Santo Ant�nio do Monte')," +
                    "(3160454,31,'Santo Ant�nio do Retiro')," +
                    "(3160504,31,'Santo Ant�nio do Rio Abaixo')," +
                    "(3160603,31,'Santo Hip�lito')," +
                    "(3160702,31,'Santos Dumont')," +
                    "(3160801,31,'S�o Bento Abade')," +
                    "(3160900,31,'S�o Br�s do Sua�u�')," +
                    "(3160959,31,'S�o domingos das dores')," +
                    "(3161007,31,'S�o domingos do Prata')," +
                    "(3161056,31,'S�o F�lix de Minas')," +
                    "(3161106,31,'S�o Francisco')," +
                    "(3161205,31,'S�o Francisco de Paula')," +
                    "(3161304,31,'S�o Francisco de Sales')," +
                    "(3161403,31,'S�o Francisco do Gl�ria')," +
                    "(3161502,31,'S�o Geraldo')," +
                    "(3161601,31,'S�o Geraldo da Piedade')," +
                    "(3161650,31,'S�o Geraldo do Baixio')," +
                    "(3161700,31,'S�o Gon�alo do Abaet�')," +
                    "(3161809,31,'S�o Gon�alo do Par�')," +
                    "(3161908,31,'S�o Gon�alo do Rio Abaixo')," +
                    "(3162005,31,'S�o Gon�alo do Sapuca�')," +
                    "(3162104,31,'S�o Gotardo')," +
                    "(3162203,31,'S�o Jo�o Batista do Gl�ria')," +
                    "(3162252,31,'S�o Jo�o da Lagoa')," +
                    "(3162302,31,'S�o Jo�o da Mata')," +
                    "(3162401,31,'S�o Jo�o da Ponte')," +
                    "(3162450,31,'S�o Jo�o das Miss�es')," +
                    "(3162500,31,'S�o Jo�o del Rei')," +
                    "(3162559,31,'S�o Jo�o do Manhua�u')," +
                    "(3162575,31,'S�o Jo�o do Manteninha')," +
                    "(3162609,31,'S�o Jo�o do Oriente')," +
                    "(3162658,31,'S�o Jo�o do Pacu�')," +
                    "(3162708,31,'S�o Jo�o do Para�so')," +
                    "(3162807,31,'S�o Jo�o Evangelista')," +
                    "(3162906,31,'S�o Jo�o Nepomuceno')," +
                    "(3162922,31,'S�o Joaquim de Bicas')," +
                    "(3162948,31,'S�o Jos� da Barra')," +
                    "(3162955,31,'S�o Jos� da Lapa')," +
                    "(3163003,31,'S�o Jos� da Safira')," +
                    "(3163102,31,'S�o Jos� da Varginha')," +
                    "(3163201,31,'S�o Jos� do Alegre')," +
                    "(3163300,31,'S�o Jos� do Divino')," +
                    "(3163409,31,'S�o Jos� do Goiabal')," +
                    "(3163508,31,'S�o Jos� do Jacuri')," +
                    "(3163607,31,'S�o Jos� do Mantimento')," +
                    "(3163706,31,'S�o Louren�o')," +
                    "(3163805,31,'S�o Miguel do Anta')," +
                    "(3163904,31,'S�o Pedro da Uni�o')," +
                    "(3164001,31,'S�o Pedro dos Ferros')," +
                    "(3164100,31,'S�o Pedro do Sua�u�')," +
                    "(3164209,31,'S�o Rom�o')," +
                    "(3164308,31,'S�o Roque de Minas')," +
                    "(3164407,31,'S�o Sebasti�o da Bela Vista')," +
                    "(3164431,31,'S�o Sebasti�o da Vargem Alegre')," +
                    "(3164472,31,'S�o Sebasti�o do Anta')," +
                    "(3164506,31,'S�o Sebasti�o do Maranh�o')," +
                    "(3164605,31,'S�o Sebasti�o do Oeste')," +
                    "(3164704,31,'S�o Sebasti�o do Para�so')," +
                    "(3164803,31,'S�o Sebasti�o do Rio Preto')," +
                    "(3164902,31,'S�o Sebasti�o do Rio Verde')," +
                    "(3165008,31,'S�o Tiago')," +
                    "(3165107,31,'S�o Tom�s de Aquino')," +
                    "(3165206,31,'S�o Thom� das Letras')," +
                    "(3165305,31,'S�o Vicente de Minas')," +
                    "(3165404,31,'Sapuca�-Mirim')," +
                    "(3165503,31,'Sardo�')," +
                    "(3165537,31,'Sarzedo')," +
                    "(3165552,31,'Setubinha')," +
                    "(3165560,31,'Sem-Peixe')," +
                    "(3165578,31,'Senador Amaral')," +
                    "(3165602,31,'Senador Cortes')," +
                    "(3165701,31,'Senador Firmino')," +
                    "(3165800,31,'Senador Jos� Bento')," +
                    "(3165909,31,'Senador Modestino Gon�alves')," +
                    "(3166006,31,'Senhora de Oliveira')," +
                    "(3166105,31,'Senhora do Porto')," +
                    "(3166204,31,'Senhora dos Rem�dios')," +
                    "(3166303,31,'Sericita')," +
                    "(3166402,31,'Seritinga')," +
                    "(3166501,31,'Serra Azul de Minas')," +
                    "(3166600,31,'Serra da Saudade')," +
                    "(3166709,31,'Serra dos Aimor�s')," +
                    "(3166808,31,'Serra do Salitre')," +
                    "(3166907,31,'Serrania')," +
                    "(3166956,31,'Serran�polis de Minas')," +
                    "(3167004,31,'Serranos')," +
                    "(3167103,31,'Serro')," +
                    "(3167202,31,'Sete Lagoas')," +
                    "(3167301,31,'Silveir�nia')," +
                    "(3167400,31,'Silvian�polis')," +
                    "(3167509,31,'Sim�o Pereira')," +
                    "(3167608,31,'Simon�sia')," +
                    "(3167707,31,'Sobr�lia')," +
                    "(3167806,31,'Soledade de Minas')," +
                    "(3167905,31,'Tabuleiro')," +
                    "(3168002,31,'Taiobeiras')," +
                    "(3168051,31,'Taparuba')," +
                    "(3168101,31,'Tapira')," +
                    "(3168200,31,'Tapira�')," +
                    "(3168309,31,'Taquara�u de Minas')," +
                    "(3168408,31,'Tarumirim')," +
                    "(3168507,31,'Teixeiras')," +
                    "(3168606,31,'Te�filo Otoni')," +
                    "(3168705,31,'Tim�teo')," +
                    "(3168804,31,'Tiradentes')," +
                    "(3168903,31,'Tiros')," +
                    "(3169000,31,'Tocantins')," +
                    "(3169059,31,'Tocos do Moji')," +
                    "(3169109,31,'Toledo')," +
                    "(3169208,31,'Tombos')," +
                    "(3169307,31,'Tr�s Cora��es')," +
                    "(3169356,31,'Tr�s Marias')," +
                    "(3169406,31,'Tr�s Pontas')," +
                    "(3169505,31,'Tumiritinga')," +
                    "(3169604,31,'Tupaciguara')," +
                    "(3169703,31,'Turmalina')," +
                    "(3169802,31,'Turvol�ndia')," +
                    "(3169901,31,'Ub�')," +
                    "(3170008,31,'Uba�')," +
                    "(3170057,31,'Ubaporanga')," +
                    "(3170107,31,'Uberaba')," +
                    "(3170206,31,'Uberl�ndia')," +
                    "(3170305,31,'Umburatiba')," +
                    "(3170404,31,'Una�')," +
                    "(3170438,31,'Uni�o de Minas')," +
                    "(3170479,31,'Uruana de Minas')," +
                    "(3170503,31,'Uruc�nia')," +
                    "(3170529,31,'Urucuia')," +
                    "(3170578,31,'Vargem Alegre')," +
                    "(3170602,31,'Vargem Bonita')," +
                    "(3170651,31,'Vargem Grande do Rio Pardo')," +
                    "(3170701,31,'Varginha')," +
                    "(3170750,31,'Varj�o de Minas')," +
                    "(3170800,31,'V�rzea da Palma')," +
                    "(3170909,31,'Varzel�ndia')," +
                    "(3171006,31,'Vazante')," +
                    "(3171030,31,'Verdel�ndia')," +
                    "(3171071,31,'Veredinha')," +
                    "(3171105,31,'Ver�ssimo')," +
                    "(3171154,31,'Vermelho Novo')," +
                    "(3171204,31,'Vespasiano')," +
                    "(3171303,31,'Vi�osa')," +
                    "(3171402,31,'Vieiras')," +
                    "(3171501,31,'Mathias Lobato')," +
                    "(3171600,31,'Virgem da Lapa')," +
                    "(3171709,31,'Virg�nia')," +
                    "(3171808,31,'Virgin�polis')," +
                    "(3171907,31,'Virgol�ndia')," +
                    "(3172004,31,'Visconde do Rio Branco')," +
                    "(3172103,31,'Volta Grande')," +
                    "(3172202,31,'Wenceslau Braz')," +
                    "(3200102,32,'Afonso Cl�udio')," +
                    "(3200136,32,'�guia Branca')," +
                    "(3200169,32,'�gua doce do Norte')," +
                    "(3200201,32,'Alegre')," +
                    "(3200300,32,'Alfredo Chaves')," +
                    "(3200359,32,'Alto Rio Novo')," +
                    "(3200409,32,'Anchieta')," +
                    "(3200508,32,'Apiac�')," +
                    "(3200607,32,'Aracruz')," +
                    "(3200706,32,'Atilio Vivacqua')," +
                    "(3200805,32,'Baixo Guandu')," +
                    "(3200904,32,'Barra de S�o Francisco')," +
                    "(3201001,32,'Boa Esperan�a')," +
                    "(3201100,32,'Bom Jesus do Norte')," +
                    "(3201159,32,'Brejetuba')," +
                    "(3201209,32,'Cachoeiro de Itapemirim')," +
                    "(3201308,32,'Cariacica')," +
                    "(3201407,32,'Castelo')," +
                    "(3201506,32,'Colatina')," +
                    "(3201605,32,'Concei��o da Barra')," +
                    "(3201704,32,'Concei��o do Castelo')," +
                    "(3201803,32,'Divino de S�o Louren�o')," +
                    "(3201902,32,'domingos Martins')," +
                    "(3202009,32,'dores do Rio Preto')," +
                    "(3202108,32,'Ecoporanga')," +
                    "(3202207,32,'Fund�o')," +
                    "(3202256,32,'Governador Lindenberg')," +
                    "(3202306,32,'Gua�u�')," +
                    "(3202405,32,'Guarapari')," +
                    "(3202454,32,'Ibatiba')," +
                    "(3202504,32,'Ibira�u')," +
                    "(3202553,32,'Ibitirama')," +
                    "(3202603,32,'Iconha')," +
                    "(3202652,32,'Irupi')," +
                    "(3202702,32,'Itagua�u')," +
                    "(3202801,32,'Itapemirim')," +
                    "(3202900,32,'Itarana')," +
                    "(3203007,32,'I�na')," +
                    "(3203056,32,'Jaguar�')," +
                    "(3203106,32,'Jer�nimo Monteiro')," +
                    "(3203130,32,'Jo�o Neiva')," +
                    "(3203163,32,'Laranja da Terra')," +
                    "(3203205,32,'Linhares')," +
                    "(3203304,32,'Manten�polis')," +
                    "(3203320,32,'Marata�zes')," +
                    "(3203346,32,'Marechal Floriano')," +
                    "(3203353,32,'Maril�ndia')," +
                    "(3203403,32,'Mimoso do Sul')," +
                    "(3203502,32,'Montanha')," +
                    "(3203601,32,'Mucurici')," +
                    "(3203700,32,'Muniz Freire')," +
                    "(3203809,32,'Muqui')," +
                    "(3203908,32,'Nova Ven�cia')," +
                    "(3204005,32,'Pancas')," +
                    "(3204054,32,'Pedro Can�rio')," +
                    "(3204104,32,'Pinheiros')," +
                    "(3204203,32,'Pi�ma')," +
                    "(3204252,32,'Ponto Belo')," +
                    "(3204302,32,'Presidente Kennedy')," +
                    "(3204351,32,'Rio Bananal')," +
                    "(3204401,32,'Rio Novo do Sul')," +
                    "(3204500,32,'Santa Leopoldina')," +
                    "(3204559,32,'Santa Maria de Jetib�')," +
                    "(3204609,32,'Santa Teresa')," +
                    "(3204658,32,'S�o domingos do Norte')," +
                    "(3204708,32,'S�o Gabriel da Palha')," +
                    "(3204807,32,'S�o Jos� do Cal�ado')," +
                    "(3204906,32,'S�o Mateus')," +
                    "(3204955,32,'S�o Roque do Cana�')," +
                    "(3205002,32,'Serra')," +
                    "(3205010,32,'Sooretama')," +
                    "(3205036,32,'Vargem Alta')," +
                    "(3205069,32,'Venda Nova do Imigrante')," +
                    "(3205101,32,'Viana')," +
                    "(3205150,32,'Vila Pav�o')," +
                    "(3205176,32,'Vila Val�rio')," +
                    "(3205200,32,'Vila Velha')," +
                    "(3205309,32,'Vit�ria')," +
                    "(3300100,33,'Angra dos Reis')," +
                    "(3300159,33,'Aperib�')," +
                    "(3300209,33,'Araruama')," +
                    "(3300225,33,'Areal')," +
                    "(3300233,33,'Arma��o dos B�zios')," +
                    "(3300258,33,'Arraial do Cabo')," +
                    "(3300308,33,'Barra do Pira�')," +
                    "(3300407,33,'Barra Mansa')," +
                    "(3300456,33,'Belford Roxo')," +
                    "(3300506,33,'Bom Jardim')," +
                    "(3300605,33,'Bom Jesus do Itabapoana')," +
                    "(3300704,33,'Cabo Frio')," +
                    "(3300803,33,'Cachoeiras de Macacu')," +
                    "(3300902,33,'Cambuci')," +
                    "(3300936,33,'Carapebus')," +
                    "(3300951,33,'Comendador Levy Gasparian')," +
                    "(3301009,33,'Campos dos Goytacazes')," +
                    "(3301108,33,'Cantagalo')," +
                    "(3301157,33,'Cardoso Moreira')," +
                    "(3301207,33,'Carmo')," +
                    "(3301306,33,'Casimiro de Abreu')," +
                    "(3301405,33,'Concei��o de Macabu')," +
                    "(3301504,33,'Cordeiro')," +
                    "(3301603,33,'Duas Barras')," +
                    "(3301702,33,'Duque de Caxias')," +
                    "(3301801,33,'Engenheiro Paulo de Frontin')," +
                    "(3301850,33,'Guapimirim')," +
                    "(3301876,33,'Iguaba Grande')," +
                    "(3301900,33,'Itabora�')," +
                    "(3302007,33,'Itagua�')," +
                    "(3302056,33,'Italva')," +
                    "(3302106,33,'Itaocara')," +
                    "(3302205,33,'Itaperuna')," +
                    "(3302254,33,'Itatiaia')," +
                    "(3302270,33,'Japeri')," +
                    "(3302304,33,'Laje do Muria�')," +
                    "(3302403,33,'Maca�')," +
                    "(3302452,33,'Macuco')," +
                    "(3302502,33,'Mag�')," +
                    "(3302601,33,'Mangaratiba')," +
                    "(3302700,33,'Maric�')," +
                    "(3302809,33,'Mendes')," +
                    "(3302858,33,'Mesquita')," +
                    "(3302908,33,'Miguel Pereira')," +
                    "(3303005,33,'Miracema')," +
                    "(3303104,33,'Natividade')," +
                    "(3303203,33,'Nil�polis')," +
                    "(3303302,33,'Niter�i')," +
                    "(3303401,33,'Nova Friburgo')," +
                    "(3303500,33,'Nova Igua�u')," +
                    "(3303609,33,'Paracambi')," +
                    "(3303708,33,'Para�ba do Sul')," +
                    "(3303807,33,'Paraty')," +
                    "(3303856,33,'Paty do Alferes')," +
                    "(3303906,33,'Petr�polis')," +
                    "(3303955,33,'Pinheiral')," +
                    "(3304003,33,'Pira�')," +
                    "(3304102,33,'Porci�ncula')," +
                    "(3304110,33,'Porto Real')," +
                    "(3304128,33,'Quatis')," +
                    "(3304144,33,'Queimados')," +
                    "(3304151,33,'Quissam�')," +
                    "(3304201,33,'Resende')," +
                    "(3304300,33,'Rio Bonito')," +
                    "(3304409,33,'Rio Claro')," +
                    "(3304508,33,'Rio das Flores')," +
                    "(3304524,33,'Rio das Ostras')," +
                    "(3304557,33,'Rio de Janeiro')," +
                    "(3304607,33,'Santa Maria Madalena')," +
                    "(3304706,33,'Santo Ant�nio de P�dua')," +
                    "(3304755,33,'S�o Francisco de Itabapoana')," +
                    "(3304805,33,'S�o Fid�lis')," +
                    "(3304904,33,'S�o Gon�alo')," +
                    "(3305000,33,'S�o Jo�o da Barra')," +
                    "(3305109,33,'S�o Jo�o de Meriti')," +
                    "(3305133,33,'S�o Jos� de Ub�')," +
                    "(3305158,33,'S�o Jos� do Vale do Rio Preto')," +
                    "(3305208,33,'S�o Pedro da Aldeia')," +
                    "(3305307,33,'S�o Sebasti�o do Alto')," +
                    "(3305406,33,'Sapucaia')," +
                    "(3305505,33,'Saquarema')," +
                    "(3305554,33,'Serop�dica')," +
                    "(3305604,33,'Silva Jardim')," +
                    "(3305703,33,'Sumidouro')," +
                    "(3305752,33,'Tangu�')," +
                    "(3305802,33,'Teres�polis')," +
                    "(3305901,33,'Trajano de Moraes')," +
                    "(3306008,33,'Tr�s Rios')," +
                    "(3306107,33,'Valen�a')," +
                    "(3306156,33,'Varre-Sai')," +
                    "(3306206,33,'Vassouras')," +
                    "(3306305,33,'Volta Redonda')," +
                    "(3500105,35,'Adamantina')," +
                    "(3500204,35,'Adolfo')," +
                    "(3500303,35,'Agua�')," +
                    "(3500402,35,'�guas da Prata')," +
                    "(3500501,35,'�guas de Lind�ia')," +
                    "(3500550,35,'�guas de Santa B�rbara')," +
                    "(3500600,35,'�guas de S�o Pedro')," +
                    "(3500709,35,'Agudos')," +
                    "(3500758,35,'Alambari')," +
                    "(3500808,35,'Alfredo Marcondes')," +
                    "(3500907,35,'Altair')," +
                    "(3501004,35,'Altin�polis')," +
                    "(3501103,35,'Alto Alegre')," +
                    "(3501152,35,'Alum�nio')," +
                    "(3501202,35,'�lvares Florence')," +
                    "(3501301,35,'�lvares Machado')," +
                    "(3501400,35,'�lvaro de Carvalho')," +
                    "(3501509,35,'Alvinl�ndia')," +
                    "(3501608,35,'Americana')," +
                    "(3501707,35,'Am�rico Brasiliense')," +
                    "(3501806,35,'Am�rico de Campos')," +
                    "(3501905,35,'Amparo')," +
                    "(3502002,35,'Anal�ndia')," +
                    "(3502101,35,'Andradina')," +
                    "(3502200,35,'Angatuba')," +
                    "(3502309,35,'Anhembi')," +
                    "(3502408,35,'Anhumas')," +
                    "(3502507,35,'Aparecida')," +
                    "(3502606,35,'Aparecida Doeste')," +
                    "(3502705,35,'Apia�')," +
                    "(3502754,35,'Ara�ariguama')," +
                    "(3502804,35,'Ara�atuba')," +
                    "(3502903,35,'Ara�oiaba da Serra')," +
                    "(3503000,35,'Aramina')," +
                    "(3503109,35,'Arandu')," +
                    "(3503158,35,'Arape�')," +
                    "(3503208,35,'Araraquara')," +
                    "(3503307,35,'Araras')," +
                    "(3503356,35,'Arco-�ris')," +
                    "(3503406,35,'Arealva')," +
                    "(3503505,35,'Areias')," +
                    "(3503604,35,'Arei�polis')," +
                    "(3503703,35,'Ariranha')," +
                    "(3503802,35,'Artur Nogueira')," +
                    "(3503901,35,'Aruj�')," +
                    "(3503950,35,'Asp�sia')," +
                    "(3504008,35,'Assis')," +
                    "(3504107,35,'Atibaia')," +
                    "(3504206,35,'Auriflama')," +
                    "(3504305,35,'Ava�')," +
                    "(3504404,35,'Avanhandava')," +
                    "(3504503,35,'Avar�')," +
                    "(3504602,35,'Bady Bassitt')," +
                    "(3504701,35,'Balbinos')," +
                    "(3504800,35,'B�lsamo')," +
                    "(3504909,35,'Bananal')," +
                    "(3505005,35,'Bar�o de Antonina')," +
                    "(3505104,35,'Barbosa')," +
                    "(3505203,35,'Bariri')," +
                    "(3505302,35,'Barra Bonita')," +
                    "(3505351,35,'Barra do Chap�u')," +
                    "(3505401,35,'Barra do Turvo')," +
                    "(3505500,35,'Barretos')," +
                    "(3505609,35,'Barrinha')," +
                    "(3505708,35,'Barueri')," +
                    "(3505807,35,'Bastos')," +
                    "(3505906,35,'Batatais')," +
                    "(3506003,35,'Bauru')," +
                    "(3506102,35,'Bebedouro')," +
                    "(3506201,35,'Bento de Abreu')," +
                    "(3506300,35,'Bernardino de Campos')," +
                    "(3506359,35,'Bertioga')," +
                    "(3506409,35,'Bilac')," +
                    "(3506508,35,'Birigui')," +
                    "(3506607,35,'Biritiba-Mirim')," +
                    "(3506706,35,'Boa Esperan�a do Sul')," +
                    "(3506805,35,'Bocaina')," +
                    "(3506904,35,'Bofete')," +
                    "(3507001,35,'Boituva')," +
                    "(3507100,35,'Bom Jesus dos Perd�es')," +
                    "(3507159,35,'Bom Sucesso de Itarar�')," +
                    "(3507209,35,'Bor�')," +
                    "(3507308,35,'Borac�ia')," +
                    "(3507407,35,'Borborema')," +
                    "(3507456,35,'Borebi')," +
                    "(3507506,35,'Botucatu')," +
                    "(3507605,35,'Bragan�a Paulista')," +
                    "(3507704,35,'Bra�na')," +
                    "(3507753,35,'Brejo Alegre')," +
                    "(3507803,35,'Brodowski')," +
                    "(3507902,35,'Brotas')," +
                    "(3508009,35,'Buri')," +
                    "(3508108,35,'Buritama')," +
                    "(3508207,35,'Buritizal')," +
                    "(3508306,35,'Cabr�lia Paulista')," +
                    "(3508405,35,'Cabre�va')," +
                    "(3508504,35,'Ca�apava')," +
                    "(3508603,35,'Cachoeira Paulista')," +
                    "(3508702,35,'Caconde')," +
                    "(3508801,35,'Cafel�ndia')," +
                    "(3508900,35,'Caiabu')," +
                    "(3509007,35,'Caieiras')," +
                    "(3509106,35,'Caiu�')," +
                    "(3509205,35,'Cajamar')," +
                    "(3509254,35,'Cajati')," +
                    "(3509304,35,'Cajobi')," +
                    "(3509403,35,'Cajuru')," +
                    "(3509452,35,'Campina do Monte Alegre')," +
                    "(3509502,35,'Campinas')," +
                    "(3509601,35,'Campo Limpo Paulista')," +
                    "(3509700,35,'Campos do Jord�o')," +
                    "(3509809,35,'Campos Novos Paulista')," +
                    "(3509908,35,'Canan�ia')," +
                    "(3509957,35,'Canas')," +
                    "(3510005,35,'C�ndido Mota')," +
                    "(3510104,35,'C�ndido Rodrigues')," +
                    "(3510153,35,'Canitar')," +
                    "(3510203,35,'Cap�o Bonito')," +
                    "(3510302,35,'Capela do Alto')," +
                    "(3510401,35,'Capivari')," +
                    "(3510500,35,'Caraguatatuba')," +
                    "(3510609,35,'Carapicu�ba')," +
                    "(3510708,35,'Cardoso')," +
                    "(3510807,35,'Casa Branca')," +
                    "(3510906,35,'C�ssia dos Coqueiros')," +
                    "(3511003,35,'Castilho')," +
                    "(3511102,35,'Catanduva')," +
                    "(3511201,35,'Catigu�')," +
                    "(3511300,35,'Cedral')," +
                    "(3511409,35,'Cerqueira C�sar')," +
                    "(3511508,35,'Cerquilho')," +
                    "(3511607,35,'Ces�rio Lange')," +
                    "(3511706,35,'Charqueada')," +
                    "(3511904,35,'Clementina')," +
                    "(3512001,35,'Colina')," +
                    "(3512100,35,'Col�mbia')," +
                    "(3512209,35,'Conchal')," +
                    "(3512308,35,'Conchas')," +
                    "(3512407,35,'Cordeir�polis')," +
                    "(3512506,35,'Coroados')," +
                    "(3512605,35,'Coronel Macedo')," +
                    "(3512704,35,'Corumbata�')," +
                    "(3512803,35,'Cosm�polis')," +
                    "(3512902,35,'Cosmorama')," +
                    "(3513009,35,'Cotia')," +
                    "(3513108,35,'Cravinhos')," +
                    "(3513207,35,'Cristais Paulista')," +
                    "(3513306,35,'Cruz�lia')," +
                    "(3513405,35,'Cruzeiro')," +
                    "(3513504,35,'Cubat�o')," +
                    "(3513603,35,'Cunha')," +
                    "(3513702,35,'descalvado')," +
                    "(3513801,35,'Diadema')," +
                    "(3513850,35,'Dirce Reis')," +
                    "(3513900,35,'Divinol�ndia')," +
                    "(3514007,35,'dobrada')," +
                    "(3514106,35,'dois C�rregos')," +
                    "(3514205,35,'dolcin�polis')," +
                    "(3514304,35,'dourado')," +
                    "(3514403,35,'Dracena')," +
                    "(3514502,35,'Duartina')," +
                    "(3514601,35,'Dumont')," +
                    "(3514700,35,'Echapor�')," +
                    "(3514809,35,'Eldorado')," +
                    "(3514908,35,'Elias Fausto')," +
                    "(3514924,35,'Elisi�rio')," +
                    "(3514957,35,'Emba�ba')," +
                    "(3515004,35,'Embu das Artes')," +
                    "(3515103,35,'Embu-Gua�u')," +
                    "(3515129,35,'Emilian�polis')," +
                    "(3515152,35,'Engenheiro Coelho')," +
                    "(3515186,35,'Esp�rito Santo do Pinhal')," +
                    "(3515194,35,'Esp�rito Santo do Turvo')," +
                    "(3515202,35,'Estrela Doeste')," +
                    "(3515301,35,'Estrela do Norte')," +
                    "(3515350,35,'Euclides da Cunha Paulista')," +
                    "(3515400,35,'Fartura')," +
                    "(3515509,35,'Fernand�polis')," +
                    "(3515608,35,'Fernando Prestes')," +
                    "(3515657,35,'Fern�o')," +
                    "(3515707,35,'Ferraz de Vasconcelos')," +
                    "(3515806,35,'Flora Rica')," +
                    "(3515905,35,'Floreal')," +
                    "(3516002,35,'Fl�rida Paulista')," +
                    "(3516101,35,'Flor�nia')," +
                    "(3516200,35,'Franca')," +
                    "(3516309,35,'Francisco Morato')," +
                    "(3516408,35,'Franco da Rocha')," +
                    "(3516507,35,'Gabriel Monteiro')," +
                    "(3516606,35,'G�lia')," +
                    "(3516705,35,'Gar�a')," +
                    "(3516804,35,'Gast�o Vidigal')," +
                    "(3516853,35,'Gavi�o Peixoto')," +
                    "(3516903,35,'General Salgado')," +
                    "(3517000,35,'Getulina')," +
                    "(3517109,35,'Glic�rio')," +
                    "(3517208,35,'Guai�ara')," +
                    "(3517307,35,'Guaimb�')," +
                    "(3517406,35,'Gua�ra')," +
                    "(3517505,35,'Guapia�u')," +
                    "(3517604,35,'Guapiara')," +
                    "(3517703,35,'Guar�')," +
                    "(3517802,35,'Guara�a�')," +
                    "(3517901,35,'Guaraci')," +
                    "(3518008,35,'Guarani Doeste')," +
                    "(3518107,35,'Guarant�')," +
                    "(3518206,35,'Guararapes')," +
                    "(3518305,35,'Guararema')," +
                    "(3518404,35,'Guaratinguet�')," +
                    "(3518503,35,'Guare�')," +
                    "(3518602,35,'Guariba')," +
                    "(3518701,35,'Guaruj�')," +
                    "(3518800,35,'Guarulhos')," +
                    "(3518859,35,'Guatapar�')," +
                    "(3518909,35,'Guzol�ndia')," +
                    "(3519006,35,'Hercul�ndia')," +
                    "(3519055,35,'Holambra')," +
                    "(3519071,35,'Hortol�ndia')," +
                    "(3519105,35,'Iacanga')," +
                    "(3519204,35,'Iacri')," +
                    "(3519253,35,'Iaras')," +
                    "(3519303,35,'Ibat�')," +
                    "(3519402,35,'Ibir�')," +
                    "(3519501,35,'Ibirarema')," +
                    "(3519600,35,'Ibitinga')," +
                    "(3519709,35,'Ibi�na')," +
                    "(3519808,35,'Ic�m')," +
                    "(3519907,35,'Iep�')," +
                    "(3520004,35,'Igara�u do Tiet�')," +
                    "(3520103,35,'Igarapava')," +
                    "(3520202,35,'Igarat�')," +
                    "(3520301,35,'Iguape')," +
                    "(3520400,35,'Ilhabela')," +
                    "(3520426,35,'Ilha Comprida')," +
                    "(3520442,35,'Ilha Solteira')," +
                    "(3520509,35,'Indaiatuba')," +
                    "(3520608,35,'Indiana')," +
                    "(3520707,35,'Indiapor�')," +
                    "(3520806,35,'In�bia Paulista')," +
                    "(3520905,35,'Ipaussu')," +
                    "(3521002,35,'Iper�')," +
                    "(3521101,35,'Ipe�na')," +
                    "(3521150,35,'Ipigu�')," +
                    "(3521200,35,'Iporanga')," +
                    "(3521309,35,'Ipu�')," +
                    "(3521408,35,'Iracem�polis')," +
                    "(3521507,35,'Irapu�')," +
                    "(3521606,35,'Irapuru')," +
                    "(3521705,35,'Itaber�')," +
                    "(3521804,35,'Ita�')," +
                    "(3521903,35,'Itajobi')," +
                    "(3522000,35,'Itaju')," +
                    "(3522109,35,'Itanha�m')," +
                    "(3522158,35,'Ita�ca')," +
                    "(3522208,35,'Itapecerica da Serra')," +
                    "(3522307,35,'Itapetininga')," +
                    "(3522406,35,'Itapeva')," +
                    "(3522505,35,'Itapevi')," +
                    "(3522604,35,'Itapira')," +
                    "(3522653,35,'Itapirapu� Paulista')," +
                    "(3522703,35,'It�polis')," +
                    "(3522802,35,'Itaporanga')," +
                    "(3522901,35,'Itapu�')," +
                    "(3523008,35,'Itapura')," +
                    "(3523107,35,'Itaquaquecetuba')," +
                    "(3523206,35,'Itarar�')," +
                    "(3523305,35,'Itariri')," +
                    "(3523404,35,'Itatiba')," +
                    "(3523503,35,'Itatinga')," +
                    "(3523602,35,'Itirapina')," +
                    "(3523701,35,'Itirapu�')," +
                    "(3523800,35,'Itobi')," +
                    "(3523909,35,'Itu')," +
                    "(3524006,35,'Itupeva')," +
                    "(3524105,35,'Ituverava')," +
                    "(3524204,35,'Jaborandi')," +
                    "(3524303,35,'Jaboticabal')," +
                    "(3524402,35,'Jacare�')," +
                    "(3524501,35,'Jaci')," +
                    "(3524600,35,'Jacupiranga')," +
                    "(3524709,35,'Jaguari�na')," +
                    "(3524808,35,'Jales')," +
                    "(3524907,35,'Jambeiro')," +
                    "(3525003,35,'Jandira')," +
                    "(3525102,35,'Jardin�polis')," +
                    "(3525201,35,'Jarinu')," +
                    "(3525300,35,'Ja�')," +
                    "(3525409,35,'Jeriquara')," +
                    "(3525508,35,'Joan�polis')," +
                    "(3525607,35,'Jo�o Ramalho')," +
                    "(3525706,35,'Jos� Bonif�cio')," +
                    "(3525805,35,'J�lio Mesquita')," +
                    "(3525854,35,'Jumirim')," +
                    "(3525904,35,'Jundia�')," +
                    "(3526001,35,'Junqueir�polis')," +
                    "(3526100,35,'Juqui�')," +
                    "(3526209,35,'Juquitiba')," +
                    "(3526308,35,'Lagoinha')," +
                    "(3526407,35,'Laranjal Paulista')," +
                    "(3526506,35,'Lav�nia')," +
                    "(3526605,35,'Lavrinhas')," +
                    "(3526704,35,'Leme')," +
                    "(3526803,35,'Len��is Paulista')," +
                    "(3526902,35,'Limeira')," +
                    "(3527009,35,'Lind�ia')," +
                    "(3527108,35,'Lins')," +
                    "(3527207,35,'Lorena')," +
                    "(3527256,35,'Lourdes')," +
                    "(3527306,35,'Louveira')," +
                    "(3527405,35,'Luc�lia')," +
                    "(3527504,35,'Lucian�polis')," +
                    "(3527603,35,'Lu�s Ant�nio')," +
                    "(3527702,35,'Luizi�nia')," +
                    "(3527801,35,'Lup�rcio')," +
                    "(3527900,35,'Lut�cia')," +
                    "(3528007,35,'Macatuba')," +
                    "(3528106,35,'Macaubal')," +
                    "(3528205,35,'Maced�nia')," +
                    "(3528304,35,'Magda')," +
                    "(3528403,35,'Mairinque')," +
                    "(3528502,35,'Mairipor�')," +
                    "(3528601,35,'Manduri')," +
                    "(3528700,35,'Marab� Paulista')," +
                    "(3528809,35,'Maraca�')," +
                    "(3528858,35,'Marapoama')," +
                    "(3528908,35,'Mari�polis')," +
                    "(3529005,35,'Mar�lia')," +
                    "(3529104,35,'Marin�polis')," +
                    "(3529203,35,'Martin�polis')," +
                    "(3529302,35,'Mat�o')," +
                    "(3529401,35,'Mau�')," +
                    "(3529500,35,'Mendon�a')," +
                    "(3529609,35,'Meridiano')," +
                    "(3529658,35,'Mes�polis')," +
                    "(3529708,35,'Miguel�polis')," +
                    "(3529807,35,'Mineiros do Tiet�')," +
                    "(3529906,35,'Miracatu')," +
                    "(3530003,35,'Mira Estrela')," +
                    "(3530102,35,'Mirand�polis')," +
                    "(3530201,35,'Mirante do Paranapanema')," +
                    "(3530300,35,'Mirassol')," +
                    "(3530409,35,'Mirassol�ndia')," +
                    "(3530508,35,'Mococa')," +
                    "(3530607,35,'Mogi das Cruzes')," +
                    "(3530706,35,'Mogi Gua�u')," +
                    "(3530805,35,'Mogi Mirim')," +
                    "(3530904,35,'Mombuca')," +
                    "(3531001,35,'Mon��es')," +
                    "(3531100,35,'Mongagu�')," +
                    "(3531209,35,'Monte Alegre do Sul')," +
                    "(3531308,35,'Monte Alto')," +
                    "(3531407,35,'Monte Apraz�vel')," +
                    "(3531506,35,'Monte Azul Paulista')," +
                    "(3531605,35,'Monte Castelo')," +
                    "(3531704,35,'Monteiro Lobato')," +
                    "(3531803,35,'Monte Mor')," +
                    "(3531902,35,'Morro Agudo')," +
                    "(3532009,35,'Morungaba')," +
                    "(3532058,35,'Motuca')," +
                    "(3532108,35,'Murutinga do Sul')," +
                    "(3532157,35,'Nantes')," +
                    "(3532207,35,'Narandiba')," +
                    "(3532306,35,'Natividade da Serra')," +
                    "(3532405,35,'Nazar� Paulista')," +
                    "(3532504,35,'Neves Paulista')," +
                    "(3532603,35,'Nhandeara')," +
                    "(3532702,35,'Nipo�')," +
                    "(3532801,35,'Nova Alian�a')," +
                    "(3532827,35,'Nova Campina')," +
                    "(3532843,35,'Nova Cana� Paulista')," +
                    "(3532868,35,'Nova Castilho')," +
                    "(3532900,35,'Nova Europa')," +
                    "(3533007,35,'Nova Granada')," +
                    "(3533106,35,'Nova Guataporanga')," +
                    "(3533205,35,'Nova Independ�ncia')," +
                    "(3533254,35,'Novais')," +
                    "(3533304,35,'Nova Luzit�nia')," +
                    "(3533403,35,'Nova Odessa')," +
                    "(3533502,35,'Novo Horizonte')," +
                    "(3533601,35,'Nuporanga')," +
                    "(3533700,35,'Ocau�u')," +
                    "(3533809,35,'�leo')," +
                    "(3533908,35,'Ol�mpia')," +
                    "(3534005,35,'Onda Verde')," +
                    "(3534104,35,'Oriente')," +
                    "(3534203,35,'Orindi�va')," +
                    "(3534302,35,'Orl�ndia')," +
                    "(3534401,35,'Osasco')," +
                    "(3534500,35,'Oscar Bressane')," +
                    "(3534609,35,'Osvaldo Cruz')," +
                    "(3534708,35,'Ourinhos')," +
                    "(3534757,35,'Ouroeste')," +
                    "(3534807,35,'Ouro Verde')," +
                    "(3534906,35,'Pacaembu')," +
                    "(3535002,35,'Palestina')," +
                    "(3535101,35,'Palmares Paulista')," +
                    "(3535200,35,'Palmeira Doeste')," +
                    "(3535309,35,'Palmital')," +
                    "(3535408,35,'Panorama')," +
                    "(3535507,35,'Paragua�u Paulista')," +
                    "(3535606,35,'Paraibuna')," +
                    "(3535705,35,'Para�so')," +
                    "(3535804,35,'Paranapanema')," +
                    "(3535903,35,'Paranapu�')," +
                    "(3536000,35,'Parapu�')," +
                    "(3536109,35,'Pardinho')," +
                    "(3536208,35,'Pariquera-A�u')," +
                    "(3536257,35,'Parisi')," +
                    "(3536307,35,'Patroc�nio Paulista')," +
                    "(3536406,35,'Paulic�ia')," +
                    "(3536505,35,'Paul�nia')," +
                    "(3536570,35,'Paulist�nia')," +
                    "(3536604,35,'Paulo de Faria')," +
                    "(3536703,35,'Pederneiras')," +
                    "(3536802,35,'Pedra Bela')," +
                    "(3536901,35,'Pedran�polis')," +
                    "(3537008,35,'Pedregulho')," +
                    "(3537107,35,'Pedreira')," +
                    "(3537156,35,'Pedrinhas Paulista')," +
                    "(3537206,35,'Pedro de Toledo')," +
                    "(3537305,35,'Pen�polis')," +
                    "(3537404,35,'Pereira Barreto')," +
                    "(3537503,35,'Pereiras')," +
                    "(3537602,35,'Peru�be')," +
                    "(3537701,35,'Piacatu')," +
                    "(3537800,35,'Piedade')," +
                    "(3537909,35,'Pilar do Sul')," +
                    "(3538006,35,'Pindamonhangaba')," +
                    "(3538105,35,'Pindorama')," +
                    "(3538204,35,'Pinhalzinho')," +
                    "(3538303,35,'Piquerobi')," +
                    "(3538501,35,'Piquete')," +
                    "(3538600,35,'Piracaia')," +
                    "(3538709,35,'Piracicaba')," +
                    "(3538808,35,'Piraju')," +
                    "(3538907,35,'Piraju�')," +
                    "(3539004,35,'Pirangi')," +
                    "(3539103,35,'Pirapora do Bom Jesus')," +
                    "(3539202,35,'Pirapozinho')," +
                    "(3539301,35,'Pirassununga')," +
                    "(3539400,35,'Piratininga')," +
                    "(3539509,35,'Pitangueiras')," +
                    "(3539608,35,'Planalto')," +
                    "(3539707,35,'Platina')," +
                    "(3539806,35,'Po�')," +
                    "(3539905,35,'Poloni')," +
                    "(3540002,35,'Pomp�ia')," +
                    "(3540101,35,'Ponga�')," +
                    "(3540200,35,'Pontal')," +
                    "(3540259,35,'Pontalinda')," +
                    "(3540309,35,'Pontes Gestal')," +
                    "(3540408,35,'Populina')," +
                    "(3540507,35,'Porangaba')," +
                    "(3540606,35,'Porto Feliz')," +
                    "(3540705,35,'Porto Ferreira')," +
                    "(3540754,35,'Potim')," +
                    "(3540804,35,'Potirendaba')," +
                    "(3540853,35,'Pracinha')," +
                    "(3540903,35,'Prad�polis')," +
                    "(3541000,35,'Praia Grande')," +
                    "(3541059,35,'Prat�nia')," +
                    "(3541109,35,'Presidente Alves')," +
                    "(3541208,35,'Presidente Bernardes')," +
                    "(3541307,35,'Presidente Epit�cio')," +
                    "(3541406,35,'Presidente Prudente')," +
                    "(3541505,35,'Presidente Venceslau')," +
                    "(3541604,35,'Promiss�o')," +
                    "(3541653,35,'Quadra')," +
                    "(3541703,35,'Quat�')," +
                    "(3541802,35,'Queiroz')," +
                    "(3541901,35,'Queluz')," +
                    "(3542008,35,'Quintana')," +
                    "(3542107,35,'Rafard')," +
                    "(3542206,35,'Rancharia')," +
                    "(3542305,35,'Reden��o da Serra')," +
                    "(3542404,35,'Regente Feij�')," +
                    "(3542503,35,'Regin�polis')," +
                    "(3542602,35,'Registro')," +
                    "(3542701,35,'Restinga')," +
                    "(3542800,35,'Ribeira')," +
                    "(3542909,35,'Ribeir�o Bonito')," +
                    "(3543006,35,'Ribeir�o Branco')," +
                    "(3543105,35,'Ribeir�o Corrente')," +
                    "(3543204,35,'Ribeir�o do Sul')," +
                    "(3543238,35,'Ribeir�o dos �ndios')," +
                    "(3543253,35,'Ribeir�o Grande')," +
                    "(3543303,35,'Ribeir�o Pires')," +
                    "(3543402,35,'Ribeir�o Preto')," +
                    "(3543501,35,'Riversul')," +
                    "(3543600,35,'Rifaina')," +
                    "(3543709,35,'Rinc�o')," +
                    "(3543808,35,'Rin�polis')," +
                    "(3543907,35,'Rio Claro')," +
                    "(3544004,35,'Rio das Pedras')," +
                    "(3544103,35,'Rio Grande da Serra')," +
                    "(3544202,35,'Riol�ndia')," +
                    "(3544251,35,'Rosana')," +
                    "(3544301,35,'Roseira')," +
                    "(3544400,35,'Rubi�cea')," +
                    "(3544509,35,'Rubin�ia')," +
                    "(3544608,35,'Sabino')," +
                    "(3544707,35,'Sagres')," +
                    "(3544806,35,'Sales')," +
                    "(3544905,35,'Sales Oliveira')," +
                    "(3545001,35,'Sales�polis')," +
                    "(3545100,35,'Salmour�o')," +
                    "(3545159,35,'Saltinho')," +
                    "(3545209,35,'Salto')," +
                    "(3545308,35,'Salto de Pirapora')," +
                    "(3545407,35,'Salto Grande')," +
                    "(3545506,35,'Sandovalina')," +
                    "(3545605,35,'Santa Ad�lia')," +
                    "(3545704,35,'Santa Albertina')," +
                    "(3545803,35,'Santa B�rbara Doeste')," +
                    "(3546009,35,'Santa Branca')," +
                    "(3546108,35,'Santa Clara Doeste')," +
                    "(3546207,35,'Santa Cruz da Concei��o')," +
                    "(3546256,35,'Santa Cruz da Esperan�a')," +
                    "(3546306,35,'Santa Cruz das Palmeiras')," +
                    "(3546405,35,'Santa Cruz do Rio Pardo')," +
                    "(3546504,35,'Santa Ernestina')," +
                    "(3546603,35,'Santa F� do Sul')," +
                    "(3546702,35,'Santa Gertrudes')," +
                    "(3546801,35,'Santa Isabel')," +
                    "(3546900,35,'Santa L�cia')," +
                    "(3547007,35,'Santa Maria da Serra')," +
                    "(3547106,35,'Santa Mercedes')," +
                    "(3547205,35,'Santana da Ponte Pensa')," +
                    "(3547304,35,'Santana de Parna�ba')," +
                    "(3547403,35,'Santa Rita Doeste')," +
                    "(3547502,35,'Santa Rita do Passa Quatro')," +
                    "(3547601,35,'Santa Rosa de Viterbo')," +
                    "(3547650,35,'Santa Salete')," +
                    "(3547700,35,'Santo Anast�cio')," +
                    "(3547809,35,'Santo Andr�')," +
                    "(3547908,35,'Santo Ant�nio da Alegria')," +
                    "(3548005,35,'Santo Ant�nio de Posse')," +
                    "(3548054,35,'Santo Ant�nio do Aracangu�')," +
                    "(3548104,35,'Santo Ant�nio do Jardim')," +
                    "(3548203,35,'Santo Ant�nio do Pinhal')," +
                    "(3548302,35,'Santo Expedito')," +
                    "(3548401,35,'Sant�polis do Aguape�')," +
                    "(3548500,35,'Santos')," +
                    "(3548609,35,'S�o Bento do Sapuca�')," +
                    "(3548708,35,'S�o Bernardo do Campo')," +
                    "(3548807,35,'S�o Caetano do Sul')," +
                    "(3548906,35,'S�o Carlos')," +
                    "(3549003,35,'S�o Francisco')," +
                    "(3549102,35,'S�o Jo�o da Boa Vista')," +
                    "(3549201,35,'S�o Jo�o das Duas Pontes')," +
                    "(3549250,35,'S�o Jo�o de Iracema')," +
                    "(3549300,35,'S�o Jo�o do Pau Dalho')," +
                    "(3549409,35,'S�o Joaquim da Barra')," +
                    "(3549508,35,'S�o Jos� da Bela Vista')," +
                    "(3549607,35,'S�o Jos� do Barreiro')," +
                    "(3549706,35,'S�o Jos� do Rio Pardo')," +
                    "(3549805,35,'S�o Jos� do Rio Preto')," +
                    "(3549904,35,'S�o Jos� dos Campos')," +
                    "(3549953,35,'S�o Louren�o da Serra')," +
                    "(3550001,35,'S�o Lu�s do Paraitinga')," +
                    "(3550100,35,'S�o Manuel')," +
                    "(3550209,35,'S�o Miguel Arcanjo')," +
                    "(3550308,35,'S�o Paulo')," +
                    "(3550407,35,'S�o Pedro')," +
                    "(3550506,35,'S�o Pedro do Turvo')," +
                    "(3550605,35,'S�o Roque')," +
                    "(3550704,35,'S�o Sebasti�o')," +
                    "(3550803,35,'S�o Sebasti�o da Grama')," +
                    "(3550902,35,'S�o Sim�o')," +
                    "(3551009,35,'S�o Vicente')," +
                    "(3551108,35,'Sarapu�')," +
                    "(3551207,35,'Sarutai�')," +
                    "(3551306,35,'Sebastian�polis do Sul')," +
                    "(3551405,35,'Serra Azul')," +
                    "(3551504,35,'Serrana')," +
                    "(3551603,35,'Serra Negra')," +
                    "(3551702,35,'Sert�ozinho')," +
                    "(3551801,35,'Sete Barras')," +
                    "(3551900,35,'Sever�nia')," +
                    "(3552007,35,'Silveiras')," +
                    "(3552106,35,'Socorro')," +
                    "(3552205,35,'Sorocaba')," +
                    "(3552304,35,'Sud Mennucci')," +
                    "(3552403,35,'Sumar�')," +
                    "(3552502,35,'Suzano')," +
                    "(3552551,35,'Suzan�polis')," +
                    "(3552601,35,'Tabapu�')," +
                    "(3552700,35,'Tabatinga')," +
                    "(3552809,35,'Tabo�o da Serra')," +
                    "(3552908,35,'Taciba')," +
                    "(3553005,35,'Tagua�')," +
                    "(3553104,35,'Taia�u')," +
                    "(3553203,35,'Tai�va')," +
                    "(3553302,35,'Tamba�')," +
                    "(3553401,35,'Tanabi')," +
                    "(3553500,35,'Tapira�')," +
                    "(3553609,35,'Tapiratiba')," +
                    "(3553658,35,'Taquaral')," +
                    "(3553708,35,'Taquaritinga')," +
                    "(3553807,35,'Taquarituba')," +
                    "(3553856,35,'Taquariva�')," +
                    "(3553906,35,'Tarabai')," +
                    "(3553955,35,'Tarum�')," +
                    "(3554003,35,'Tatu�')," +
                    "(3554102,35,'Taubat�')," +
                    "(3554201,35,'Tejup�')," +
                    "(3554300,35,'Teodoro Sampaio')," +
                    "(3554409,35,'Terra Roxa')," +
                    "(3554508,35,'Tiet�')," +
                    "(3554607,35,'Timburi')," +
                    "(3554656,35,'Torre de Pedra')," +
                    "(3554706,35,'Torrinha')," +
                    "(3554755,35,'Trabiju')," +
                    "(3554805,35,'Trememb�')," +
                    "(3554904,35,'Tr�s Fronteiras')," +
                    "(3554953,35,'Tuiuti')," +
                    "(3555000,35,'Tup�')," +
                    "(3555109,35,'Tupi Paulista')," +
                    "(3555208,35,'Turi�ba')," +
                    "(3555307,35,'Turmalina')," +
                    "(3555356,35,'Ubarana')," +
                    "(3555406,35,'Ubatuba')," +
                    "(3555505,35,'Ubirajara')," +
                    "(3555604,35,'Uchoa')," +
                    "(3555703,35,'Uni�o Paulista')," +
                    "(3555802,35,'Ur�nia')," +
                    "(3555901,35,'Uru')," +
                    "(3556008,35,'Urup�s')," +
                    "(3556107,35,'Valentim Gentil')," +
                    "(3556206,35,'Valinhos')," +
                    "(3556305,35,'Valpara�so')," +
                    "(3556354,35,'Vargem')," +
                    "(3556404,35,'Vargem Grande do Sul')," +
                    "(3556453,35,'Vargem Grande Paulista')," +
                    "(3556503,35,'V�rzea Paulista')," +
                    "(3556602,35,'Vera Cruz')," +
                    "(3556701,35,'Vinhedo')," +
                    "(3556800,35,'Viradouro')," +
                    "(3556909,35,'Vista Alegre do Alto')," +
                    "(3556958,35,'Vit�ria Brasil')," +
                    "(3557006,35,'Votorantim')," +
                    "(3557105,35,'Votuporanga')," +
                    "(3557154,35,'Zacarias')," +
                    "(3557204,35,'Chavantes')," +
                    "(3557303,35,'Estiva Gerbi')," +
                    "(4100103,41,'Abati�')," +
                    "(4100202,41,'Adrian�polis')," +
                    "(4100301,41,'Agudos do Sul')," +
                    "(4100400,41,'Almirante Tamandar�')," +
                    "(4100459,41,'Altamira do Paran�')," +
                    "(4100509,41,'Alt�nia')," +
                    "(4100608,41,'Alto Paran�')," +
                    "(4100707,41,'Alto Piquiri')," +
                    "(4100806,41,'Alvorada do Sul')," +
                    "(4100905,41,'Amapor�')," +
                    "(4101002,41,'Amp�re')," +
                    "(4101051,41,'Anahy')," +
                    "(4101101,41,'Andir�')," +
                    "(4101150,41,'�ngulo')," +
                    "(4101200,41,'Antonina')," +
                    "(4101309,41,'Ant�nio Olinto')," +
                    "(4101408,41,'Apucarana')," +
                    "(4101507,41,'Arapongas')," +
                    "(4101606,41,'Arapoti')," +
                    "(4101655,41,'Arapu�')," +
                    "(4101705,41,'Araruna')," +
                    "(4101804,41,'Arauc�ria')," +
                    "(4101853,41,'Ariranha do Iva�')," +
                    "(4101903,41,'Assa�')," +
                    "(4102000,41,'Assis Chateaubriand')," +
                    "(4102109,41,'Astorga')," +
                    "(4102208,41,'Atalaia')," +
                    "(4102307,41,'Balsa Nova')," +
                    "(4102406,41,'Bandeirantes')," +
                    "(4102505,41,'Barbosa Ferraz')," +
                    "(4102604,41,'Barrac�o')," +
                    "(4102703,41,'Barra do Jacar�')," +
                    "(4102752,41,'Bela Vista da Caroba')," +
                    "(4102802,41,'Bela Vista do Para�so')," +
                    "(4102901,41,'Bituruna')," +
                    "(4103008,41,'Boa Esperan�a')," +
                    "(4103024,41,'Boa Esperan�a do Igua�u')," +
                    "(4103040,41,'Boa Ventura de S�o Roque')," +
                    "(4103057,41,'Boa Vista da Aparecida')," +
                    "(4103107,41,'Bocai�va do Sul')," +
                    "(4103156,41,'Bom Jesus do Sul')," +
                    "(4103206,41,'Bom Sucesso')," +
                    "(4103222,41,'Bom Sucesso do Sul')," +
                    "(4103305,41,'Borraz�polis')," +
                    "(4103354,41,'Braganey')," +
                    "(4103370,41,'Brasil�ndia do Sul')," +
                    "(4103404,41,'Cafeara')," +
                    "(4103453,41,'Cafel�ndia')," +
                    "(4103479,41,'Cafezal do Sul')," +
                    "(4103503,41,'Calif�rnia')," +
                    "(4103602,41,'Cambar�')," +
                    "(4103701,41,'Camb�')," +
                    "(4103800,41,'Cambira')," +
                    "(4103909,41,'Campina da Lagoa')," +
                    "(4103958,41,'Campina do Sim�o')," +
                    "(4104006,41,'Campina Grande do Sul')," +
                    "(4104055,41,'Campo Bonito')," +
                    "(4104105,41,'Campo do Tenente')," +
                    "(4104204,41,'Campo Largo')," +
                    "(4104253,41,'Campo Magro')," +
                    "(4104303,41,'Campo Mour�o')," +
                    "(4104402,41,'C�ndido de Abreu')," +
                    "(4104428,41,'Cand�i')," +
                    "(4104451,41,'Cantagalo')," +
                    "(4104501,41,'Capanema')," +
                    "(4104600,41,'Capit�o Le�nidas Marques')," +
                    "(4104659,41,'Carambe�')," +
                    "(4104709,41,'Carl�polis')," +
                    "(4104808,41,'Cascavel')," +
                    "(4104907,41,'Castro')," +
                    "(4105003,41,'Catanduvas')," +
                    "(4105102,41,'Centen�rio do Sul')," +
                    "(4105201,41,'Cerro Azul')," +
                    "(4105300,41,'C�u Azul')," +
                    "(4105409,41,'Chopinzinho')," +
                    "(4105508,41,'Cianorte')," +
                    "(4105607,41,'Cidade Ga�cha')," +
                    "(4105706,41,'Clevel�ndia')," +
                    "(4105805,41,'Colombo')," +
                    "(4105904,41,'Colorado')," +
                    "(4106001,41,'Congonhinhas')," +
                    "(4106100,41,'Conselheiro Mairinck')," +
                    "(4106209,41,'Contenda')," +
                    "(4106308,41,'Corb�lia')," +
                    "(4106407,41,'Corn�lio Proc�pio')," +
                    "(4106456,41,'Coronel domingos Soares')," +
                    "(4106506,41,'Coronel Vivida')," +
                    "(4106555,41,'Corumbata� do Sul')," +
                    "(4106571,41,'Cruzeiro do Igua�u')," +
                    "(4106605,41,'Cruzeiro do Oeste')," +
                    "(4106704,41,'Cruzeiro do Sul')," +
                    "(4106803,41,'Cruz Machado')," +
                    "(4106852,41,'Cruzmaltina')," +
                    "(4106902,41,'Curitiba')," +
                    "(4107009,41,'Curi�va')," +
                    "(4107108,41,'Diamante do Norte')," +
                    "(4107124,41,'Diamante do Sul')," +
                    "(4107157,41,'Diamante Doeste')," +
                    "(4107207,41,'dois Vizinhos')," +
                    "(4107256,41,'douradina')," +
                    "(4107306,41,'doutor Camargo')," +
                    "(4107405,41,'En�as Marques')," +
                    "(4107504,41,'Engenheiro Beltr�o')," +
                    "(4107520,41,'Esperan�a Nova')," +
                    "(4107538,41,'Entre Rios do Oeste')," +
                    "(4107546,41,'Espig�o Alto do Igua�u')," +
                    "(4107553,41,'Farol')," +
                    "(4107603,41,'Faxinal')," +
                    "(4107652,41,'Fazenda Rio Grande')," +
                    "(4107702,41,'F�nix')," +
                    "(4107736,41,'Fernandes Pinheiro')," +
                    "(4107751,41,'Figueira')," +
                    "(4107801,41,'Flora�')," +
                    "(4107850,41,'Flor da Serra do Sul')," +
                    "(4107900,41,'Floresta')," +
                    "(4108007,41,'Florest�polis')," +
                    "(4108106,41,'Fl�rida')," +
                    "(4108205,41,'Formosa do Oeste')," +
                    "(4108304,41,'Foz do Igua�u')," +
                    "(4108320,41,'Francisco Alves')," +
                    "(4108403,41,'Francisco Beltr�o')," +
                    "(4108452,41,'Foz do Jord�o')," +
                    "(4108502,41,'General Carneiro')," +
                    "(4108551,41,'Godoy Moreira')," +
                    "(4108601,41,'Goioer�')," +
                    "(4108650,41,'Goioxim')," +
                    "(4108700,41,'Grandes Rios')," +
                    "(4108809,41,'Gua�ra')," +
                    "(4108908,41,'Guaira��')," +
                    "(4108957,41,'Guamiranga')," +
                    "(4109005,41,'Guapirama')," +
                    "(4109104,41,'Guaporema')," +
                    "(4109203,41,'Guaraci')," +
                    "(4109302,41,'Guarania�u')," +
                    "(4109401,41,'Guarapuava')," +
                    "(4109500,41,'Guaraque�aba')," +
                    "(4109609,41,'Guaratuba')," +
                    "(4109658,41,'Hon�rio Serpa')," +
                    "(4109708,41,'Ibaiti')," +
                    "(4109757,41,'Ibema')," +
                    "(4109807,41,'Ibipor�')," +
                    "(4109906,41,'Icara�ma')," +
                    "(4110003,41,'Iguara�u')," +
                    "(4110052,41,'Iguatu')," +
                    "(4110078,41,'Imba�')," +
                    "(4110102,41,'Imbituva')," +
                    "(4110201,41,'In�cio Martins')," +
                    "(4110300,41,'Inaj�')," +
                    "(4110409,41,'Indian�polis')," +
                    "(4110508,41,'Ipiranga')," +
                    "(4110607,41,'Ipor�')," +
                    "(4110656,41,'Iracema do Oeste')," +
                    "(4110706,41,'Irati')," +
                    "(4110805,41,'Iretama')," +
                    "(4110904,41,'Itaguaj�')," +
                    "(4110953,41,'Itaipul�ndia')," +
                    "(4111001,41,'Itambarac�')," +
                    "(4111100,41,'Itamb�')," +
                    "(4111209,41,'Itapejara Doeste')," +
                    "(4111258,41,'Itaperu�u')," +
                    "(4111308,41,'Ita�na do Sul')," +
                    "(4111407,41,'Iva�')," +
                    "(4111506,41,'Ivaipor�')," +
                    "(4111555,41,'Ivat�')," +
                    "(4111605,41,'Ivatuba')," +
                    "(4111704,41,'Jaboti')," +
                    "(4111803,41,'Jacarezinho')," +
                    "(4111902,41,'Jaguapit�')," +
                    "(4112009,41,'Jaguaria�va')," +
                    "(4112108,41,'Jandaia do Sul')," +
                    "(4112207,41,'Jani�polis')," +
                    "(4112306,41,'Japira')," +
                    "(4112405,41,'Japur�')," +
                    "(4112504,41,'Jardim Alegre')," +
                    "(4112603,41,'Jardim Olinda')," +
                    "(4112702,41,'Jataizinho')," +
                    "(4112751,41,'Jesu�tas')," +
                    "(4112801,41,'Joaquim T�vora')," +
                    "(4112900,41,'Jundia� do Sul')," +
                    "(4112959,41,'Juranda')," +
                    "(4113007,41,'Jussara')," +
                    "(4113106,41,'Kalor�')," +
                    "(4113205,41,'Lapa')," +
                    "(4113254,41,'Laranjal')," +
                    "(4113304,41,'Laranjeiras do Sul')," +
                    "(4113403,41,'Le�polis')," +
                    "(4113429,41,'Lidian�polis')," +
                    "(4113452,41,'Lindoeste')," +
                    "(4113502,41,'Loanda')," +
                    "(4113601,41,'Lobato')," +
                    "(4113700,41,'Londrina')," +
                    "(4113734,41,'Luiziana')," +
                    "(4113759,41,'Lunardelli')," +
                    "(4113809,41,'Lupion�polis')," +
                    "(4113908,41,'Mallet')," +
                    "(4114005,41,'Mambor�')," +
                    "(4114104,41,'Mandagua�u')," +
                    "(4114203,41,'Mandaguari')," +
                    "(4114302,41,'Mandirituba')," +
                    "(4114351,41,'Manfrin�polis')," +
                    "(4114401,41,'Mangueirinha')," +
                    "(4114500,41,'Manoel Ribas')," +
                    "(4114609,41,'Marechal C�ndido Rondon')," +
                    "(4114708,41,'Maria Helena')," +
                    "(4114807,41,'Marialva')," +
                    "(4114906,41,'Maril�ndia do Sul')," +
                    "(4115002,41,'Marilena')," +
                    "(4115101,41,'Mariluz')," +
                    "(4115200,41,'Maring�')," +
                    "(4115309,41,'Mari�polis')," +
                    "(4115358,41,'Marip�')," +
                    "(4115408,41,'Marmeleiro')," +
                    "(4115457,41,'Marquinho')," +
                    "(4115507,41,'Marumbi')," +
                    "(4115606,41,'Matel�ndia')," +
                    "(4115705,41,'Matinhos')," +
                    "(4115739,41,'Mato Rico')," +
                    "(4115754,41,'Mau� da Serra')," +
                    "(4115804,41,'Medianeira')," +
                    "(4115853,41,'Mercedes')," +
                    "(4115903,41,'Mirador')," +
                    "(4116000,41,'Miraselva')," +
                    "(4116059,41,'Missal')," +
                    "(4116109,41,'Moreira Sales')," +
                    "(4116208,41,'Morretes')," +
                    "(4116307,41,'Munhoz de Melo')," +
                    "(4116406,41,'Nossa Senhora das Gra�as')," +
                    "(4116505,41,'Nova Alian�a do Iva�')," +
                    "(4116604,41,'Nova Am�rica da Colina')," +
                    "(4116703,41,'Nova Aurora')," +
                    "(4116802,41,'Nova Cantu')," +
                    "(4116901,41,'Nova Esperan�a')," +
                    "(4116950,41,'Nova Esperan�a do Sudoeste')," +
                    "(4117008,41,'Nova F�tima')," +
                    "(4117057,41,'Nova Laranjeiras')," +
                    "(4117107,41,'Nova Londrina')," +
                    "(4117206,41,'Nova Ol�mpia')," +
                    "(4117214,41,'Nova Santa B�rbara')," +
                    "(4117222,41,'Nova Santa Rosa')," +
                    "(4117255,41,'Nova Prata do Igua�u')," +
                    "(4117271,41,'Nova Tebas')," +
                    "(4117297,41,'Novo Itacolomi')," +
                    "(4117305,41,'Ortigueira')," +
                    "(4117404,41,'Ourizona')," +
                    "(4117453,41,'Ouro Verde do Oeste')," +
                    "(4117503,41,'Pai�andu')," +
                    "(4117602,41,'Palmas')," +
                    "(4117701,41,'Palmeira')," +
                    "(4117800,41,'Palmital')," +
                    "(4117909,41,'Palotina')," +
                    "(4118006,41,'Para�so do Norte')," +
                    "(4118105,41,'Paranacity')," +
                    "(4118204,41,'Paranagu�')," +
                    "(4118303,41,'Paranapoema')," +
                    "(4118402,41,'Paranava�')," +
                    "(4118451,41,'Pato Bragado')," +
                    "(4118501,41,'Pato Branco')," +
                    "(4118600,41,'Paula Freitas')," +
                    "(4118709,41,'Paulo Frontin')," +
                    "(4118808,41,'Peabiru')," +
                    "(4118857,41,'Perobal')," +
                    "(4118907,41,'P�rola')," +
                    "(4119004,41,'P�rola Doeste')," +
                    "(4119103,41,'Pi�n')," +
                    "(4119152,41,'Pinhais')," +
                    "(4119202,41,'Pinhal�o')," +
                    "(4119251,41,'Pinhal de S�o Bento')," +
                    "(4119301,41,'Pinh�o')," +
                    "(4119400,41,'Pira� do Sul')," +
                    "(4119509,41,'Piraquara')," +
                    "(4119608,41,'Pitanga')," +
                    "(4119657,41,'Pitangueiras')," +
                    "(4119707,41,'Planaltina do Paran�')," +
                    "(4119806,41,'Planalto')," +
                    "(4119905,41,'Ponta Grossa')," +
                    "(4119954,41,'Pontal do Paran�')," +
                    "(4120002,41,'Porecatu')," +
                    "(4120101,41,'Porto Amazonas')," +
                    "(4120150,41,'Porto Barreiro')," +
                    "(4120200,41,'Porto Rico')," +
                    "(4120309,41,'Porto Vit�ria')," +
                    "(4120333,41,'Prado Ferreira')," +
                    "(4120358,41,'Pranchita')," +
                    "(4120408,41,'Presidente Castelo Branco')," +
                    "(4120507,41,'Primeiro de Maio')," +
                    "(4120606,41,'Prudent�polis')," +
                    "(4120655,41,'Quarto Centen�rio')," +
                    "(4120705,41,'Quatigu�')," +
                    "(4120804,41,'Quatro Barras')," +
                    "(4120853,41,'Quatro Pontes')," +
                    "(4120903,41,'Quedas do Igua�u')," +
                    "(4121000,41,'Quer�ncia do Norte')," +
                    "(4121109,41,'Quinta do Sol')," +
                    "(4121208,41,'Quitandinha')," +
                    "(4121257,41,'Ramil�ndia')," +
                    "(4121307,41,'Rancho Alegre')," +
                    "(4121356,41,'Rancho Alegre Doeste')," +
                    "(4121406,41,'Realeza')," +
                    "(4121505,41,'Rebou�as')," +
                    "(4121604,41,'Renascen�a')," +
                    "(4121703,41,'Reserva')," +
                    "(4121752,41,'Reserva do Igua�u')," +
                    "(4121802,41,'Ribeir�o Claro')," +
                    "(4121901,41,'Ribeir�o do Pinhal')," +
                    "(4122008,41,'Rio Azul')," +
                    "(4122107,41,'Rio Bom')," +
                    "(4122156,41,'Rio Bonito do Igua�u')," +
                    "(4122172,41,'Rio Branco do Iva�')," +
                    "(4122206,41,'Rio Branco do Sul')," +
                    "(4122305,41,'Rio Negro')," +
                    "(4122404,41,'Rol�ndia')," +
                    "(4122503,41,'Roncador')," +
                    "(4122602,41,'Rondon')," +
                    "(4122651,41,'Ros�rio do Iva�')," +
                    "(4122701,41,'Sab�udia')," +
                    "(4122800,41,'Salgado Filho')," +
                    "(4122909,41,'Salto do Itarar�')," +
                    "(4123006,41,'Salto do Lontra')," +
                    "(4123105,41,'Santa Am�lia')," +
                    "(4123204,41,'Santa Cec�lia do Pav�o')," +
                    "(4123303,41,'Santa Cruz de Monte Castelo')," +
                    "(4123402,41,'Santa F�')," +
                    "(4123501,41,'Santa Helena')," +
                    "(4123600,41,'Santa In�s')," +
                    "(4123709,41,'Santa Isabel do Iva�')," +
                    "(4123808,41,'Santa Izabel do Oeste')," +
                    "(4123824,41,'Santa L�cia')," +
                    "(4123857,41,'Santa Maria do Oeste')," +
                    "(4123907,41,'Santa Mariana')," +
                    "(4123956,41,'Santa M�nica')," +
                    "(4124004,41,'Santana do Itarar�')," +
                    "(4124020,41,'Santa Tereza do Oeste')," +
                    "(4124053,41,'Santa Terezinha de Itaipu')," +
                    "(4124103,41,'Santo Ant�nio da Platina')," +
                    "(4124202,41,'Santo Ant�nio do Caiu�')," +
                    "(4124301,41,'Santo Ant�nio do Para�so')," +
                    "(4124400,41,'Santo Ant�nio do Sudoeste')," +
                    "(4124509,41,'Santo In�cio')," +
                    "(4124608,41,'S�o Carlos do Iva�')," +
                    "(4124707,41,'S�o Jer�nimo da Serra')," +
                    "(4124806,41,'S�o Jo�o')," +
                    "(4124905,41,'S�o Jo�o do Caiu�')," +
                    "(4125001,41,'S�o Jo�o do Iva�')," +
                    "(4125100,41,'S�o Jo�o do Triunfo')," +
                    "(4125209,41,'S�o Jorge Doeste')," +
                    "(4125308,41,'S�o Jorge do Iva�')," +
                    "(4125357,41,'S�o Jorge do Patroc�nio')," +
                    "(4125407,41,'S�o Jos� da Boa Vista')," +
                    "(4125456,41,'S�o Jos� das Palmeiras')," +
                    "(4125506,41,'S�o Jos� dos Pinhais')," +
                    "(4125555,41,'S�o Manoel do Paran�')," +
                    "(4125605,41,'S�o Mateus do Sul')," +
                    "(4125704,41,'S�o Miguel do Igua�u')," +
                    "(4125753,41,'S�o Pedro do Igua�u')," +
                    "(4125803,41,'S�o Pedro do Iva�')," +
                    "(4125902,41,'S�o Pedro do Paran�')," +
                    "(4126009,41,'S�o Sebasti�o da Amoreira')," +
                    "(4126108,41,'S�o Tom�')," +
                    "(4126207,41,'Sapopema')," +
                    "(4126256,41,'Sarandi')," +
                    "(4126272,41,'Saudade do Igua�u')," +
                    "(4126306,41,'Seng�s')," +
                    "(4126355,41,'Serran�polis do Igua�u')," +
                    "(4126405,41,'Sertaneja')," +
                    "(4126504,41,'Sertan�polis')," +
                    "(4126603,41,'Siqueira Campos')," +
                    "(4126652,41,'Sulina')," +
                    "(4126678,41,'Tamarana')," +
                    "(4126702,41,'Tamboara')," +
                    "(4126801,41,'Tapejara')," +
                    "(4126900,41,'Tapira')," +
                    "(4127007,41,'Teixeira Soares')," +
                    "(4127106,41,'Tel�maco Borba')," +
                    "(4127205,41,'Terra Boa')," +
                    "(4127304,41,'Terra Rica')," +
                    "(4127403,41,'Terra Roxa')," +
                    "(4127502,41,'Tibagi')," +
                    "(4127601,41,'Tijucas do Sul')," +
                    "(4127700,41,'Toledo')," +
                    "(4127809,41,'Tomazina')," +
                    "(4127858,41,'Tr�s Barras do Paran�')," +
                    "(4127882,41,'Tunas do Paran�')," +
                    "(4127908,41,'Tuneiras do Oeste')," +
                    "(4127957,41,'Tup�ssi')," +
                    "(4127965,41,'Turvo')," +
                    "(4128005,41,'Ubirat�')," +
                    "(4128104,41,'Umuarama')," +
                    "(4128203,41,'Uni�o da Vit�ria')," +
                    "(4128302,41,'Uniflor')," +
                    "(4128401,41,'Ura�')," +
                    "(4128500,41,'Wenceslau Braz')," +
                    "(4128534,41,'Ventania')," +
                    "(4128559,41,'Vera Cruz do Oeste')," +
                    "(4128609,41,'Ver�')," +
                    "(4128625,41,'Alto Para�so')," +
                    "(4128633,41,'doutor Ulysses')," +
                    "(4128658,41,'Virmond')," +
                    "(4128708,41,'Vitorino')," +
                    "(4128807,41,'Xambr�')," +
                    "(4200051,42,'Abdon Batista')," +
                    "(4200101,42,'Abelardo Luz')," +
                    "(4200200,42,'Agrol�ndia')," +
                    "(4200309,42,'Agron�mica')," +
                    "(4200408,42,'�gua doce')," +
                    "(4200507,42,'�guas de Chapec�')," +
                    "(4200556,42,'�guas Frias')," +
                    "(4200606,42,'�guas Mornas')," +
                    "(4200705,42,'Alfredo Wagner')," +
                    "(4200754,42,'Alto Bela Vista')," +
                    "(4200804,42,'Anchieta')," +
                    "(4200903,42,'Angelina')," +
                    "(4201000,42,'Anita Garibaldi')," +
                    "(4201109,42,'Anit�polis')," +
                    "(4201208,42,'Ant�nio Carlos')," +
                    "(4201257,42,'Api�na')," +
                    "(4201273,42,'Arabut�')," +
                    "(4201307,42,'Araquari')," +
                    "(4201406,42,'Ararangu�')," +
                    "(4201505,42,'Armaz�m')," +
                    "(4201604,42,'Arroio Trinta')," +
                    "(4201653,42,'Arvoredo')," +
                    "(4201703,42,'Ascurra')," +
                    "(4201802,42,'Atalanta')," +
                    "(4201901,42,'Aurora')," +
                    "(4201950,42,'Balne�rio Arroio do Silva')," +
                    "(4202008,42,'Balne�rio Cambori�')," +
                    "(4202057,42,'Balne�rio Barra do Sul')," +
                    "(4202073,42,'Balne�rio Gaivota')," +
                    "(4202081,42,'Bandeirante')," +
                    "(4202099,42,'Barra Bonita')," +
                    "(4202107,42,'Barra Velha')," +
                    "(4202131,42,'Bela Vista do Toldo')," +
                    "(4202156,42,'Belmonte')," +
                    "(4202206,42,'Benedito Novo')," +
                    "(4202305,42,'Bigua�u')," +
                    "(4202404,42,'Blumenau')," +
                    "(4202438,42,'Bocaina do Sul')," +
                    "(4202453,42,'Bombinhas')," +
                    "(4202503,42,'Bom Jardim da Serra')," +
                    "(4202537,42,'Bom Jesus')," +
                    "(4202578,42,'Bom Jesus do Oeste')," +
                    "(4202602,42,'Bom Retiro')," +
                    "(4202701,42,'Botuver�')," +
                    "(4202800,42,'Bra�o do Norte')," +
                    "(4202859,42,'Bra�o do Trombudo')," +
                    "(4202875,42,'Brun�polis')," +
                    "(4202909,42,'Brusque')," +
                    "(4203006,42,'Ca�ador')," +
                    "(4203105,42,'Caibi')," +
                    "(4203154,42,'Calmon')," +
                    "(4203204,42,'Cambori�')," +
                    "(4203253,42,'Cap�o Alto')," +
                    "(4203303,42,'Campo Alegre')," +
                    "(4203402,42,'Campo Belo do Sul')," +
                    "(4203501,42,'Campo Er�')," +
                    "(4203600,42,'Campos Novos')," +
                    "(4203709,42,'Canelinha')," +
                    "(4203808,42,'Canoinhas')," +
                    "(4203907,42,'Capinzal')," +
                    "(4203956,42,'Capivari de Baixo')," +
                    "(4204004,42,'Catanduvas')," +
                    "(4204103,42,'Caxambu do Sul')," +
                    "(4204152,42,'Celso Ramos')," +
                    "(4204178,42,'Cerro Negro')," +
                    "(4204194,42,'Chapad�o do Lageado')," +
                    "(4204202,42,'Chapec�')," +
                    "(4204251,42,'Cocal do Sul')," +
                    "(4204301,42,'Conc�rdia')," +
                    "(4204350,42,'Cordilheira Alta')," +
                    "(4204400,42,'Coronel Freitas')," +
                    "(4204459,42,'Coronel Martins')," +
                    "(4204509,42,'Corup�')," +
                    "(4204558,42,'Correia Pinto')," +
                    "(4204608,42,'Crici�ma')," +
                    "(4204707,42,'Cunha Por�')," +
                    "(4204756,42,'Cunhata�')," +
                    "(4204806,42,'Curitibanos')," +
                    "(4204905,42,'descanso')," +
                    "(4205001,42,'Dion�sio Cerqueira')," +
                    "(4205100,42,'dona Emma')," +
                    "(4205159,42,'doutor Pedrinho')," +
                    "(4205175,42,'Entre Rios')," +
                    "(4205191,42,'Ermo')," +
                    "(4205209,42,'Erval Velho')," +
                    "(4205308,42,'Faxinal dos Guedes')," +
                    "(4205357,42,'Flor do Sert�o')," +
                    "(4205407,42,'Florian�polis')," +
                    "(4205431,42,'Formosa do Sul')," +
                    "(4205456,42,'Forquilhinha')," +
                    "(4205506,42,'Fraiburgo')," +
                    "(4205555,42,'Frei Rog�rio')," +
                    "(4205605,42,'Galv�o')," +
                    "(4205704,42,'Garopaba')," +
                    "(4205803,42,'Garuva')," +
                    "(4205902,42,'Gaspar')," +
                    "(4206009,42,'Governador Celso Ramos')," +
                    "(4206108,42,'Gr�o Par�')," +
                    "(4206207,42,'Gravatal')," +
                    "(4206306,42,'Guabiruba')," +
                    "(4206405,42,'Guaraciaba')," +
                    "(4206504,42,'Guaramirim')," +
                    "(4206603,42,'Guaruj� do Sul')," +
                    "(4206652,42,'Guatamb�')," +
                    "(4206702,42,'Herval Doeste')," +
                    "(4206751,42,'Ibiam')," +
                    "(4206801,42,'Ibicar�')," +
                    "(4206900,42,'Ibirama')," +
                    "(4207007,42,'I�ara')," +
                    "(4207106,42,'Ilhota')," +
                    "(4207205,42,'Imaru�')," +
                    "(4207304,42,'Imbituba')," +
                    "(4207403,42,'Imbuia')," +
                    "(4207502,42,'Indaial')," +
                    "(4207577,42,'Iomer�')," +
                    "(4207601,42,'Ipira')," +
                    "(4207650,42,'Ipor� do Oeste')," +
                    "(4207684,42,'Ipua�u')," +
                    "(4207700,42,'Ipumirim')," +
                    "(4207759,42,'Iraceminha')," +
                    "(4207809,42,'Irani')," +
                    "(4207858,42,'Irati')," +
                    "(4207908,42,'Irine�polis')," +
                    "(4208005,42,'It�')," +
                    "(4208104,42,'Itai�polis')," +
                    "(4208203,42,'Itaja�')," +
                    "(4208302,42,'Itapema')," +
                    "(4208401,42,'Itapiranga')," +
                    "(4208450,42,'Itapo�')," +
                    "(4208500,42,'Ituporanga')," +
                    "(4208609,42,'Jabor�')," +
                    "(4208708,42,'Jacinto Machado')," +
                    "(4208807,42,'Jaguaruna')," +
                    "(4208906,42,'Jaragu� do Sul')," +
                    "(4208955,42,'Jardin�polis')," +
                    "(4209003,42,'Joa�aba')," +
                    "(4209102,42,'Joinville')," +
                    "(4209151,42,'Jos� Boiteux')," +
                    "(4209177,42,'Jupi�')," +
                    "(4209201,42,'Lacerd�polis')," +
                    "(4209300,42,'Lages')," +
                    "(4209409,42,'Laguna')," +
                    "(4209458,42,'Lajeado Grande')," +
                    "(4209508,42,'Laurentino')," +
                    "(4209607,42,'Lauro Muller')," +
                    "(4209706,42,'Lebon R�gis')," +
                    "(4209805,42,'Leoberto Leal')," +
                    "(4209854,42,'Lind�ia do Sul')," +
                    "(4209904,42,'Lontras')," +
                    "(4210001,42,'Luiz Alves')," +
                    "(4210035,42,'Luzerna')," +
                    "(4210050,42,'Macieira')," +
                    "(4210100,42,'Mafra')," +
                    "(4210209,42,'Major Gercino')," +
                    "(4210308,42,'Major Vieira')," +
                    "(4210407,42,'Maracaj�')," +
                    "(4210506,42,'Maravilha')," +
                    "(4210555,42,'Marema')," +
                    "(4210605,42,'Massaranduba')," +
                    "(4210704,42,'Matos Costa')," +
                    "(4210803,42,'Meleiro')," +
                    "(4210852,42,'Mirim doce')," +
                    "(4210902,42,'Modelo')," +
                    "(4211009,42,'Monda�')," +
                    "(4211058,42,'Monte Carlo')," +
                    "(4211108,42,'Monte Castelo')," +
                    "(4211207,42,'Morro da Fuma�a')," +
                    "(4211256,42,'Morro Grande')," +
                    "(4211306,42,'Navegantes')," +
                    "(4211405,42,'Nova Erechim')," +
                    "(4211454,42,'Nova Itaberaba')," +
                    "(4211504,42,'Nova Trento')," +
                    "(4211603,42,'Nova Veneza')," +
                    "(4211652,42,'Novo Horizonte')," +
                    "(4211702,42,'Orleans')," +
                    "(4211751,42,'Otac�lio Costa')," +
                    "(4211801,42,'Ouro')," +
                    "(4211850,42,'Ouro Verde')," +
                    "(4211876,42,'Paial')," +
                    "(4211892,42,'Painel')," +
                    "(4211900,42,'Palho�a')," +
                    "(4212007,42,'Palma Sola')," +
                    "(4212056,42,'Palmeira')," +
                    "(4212106,42,'Palmitos')," +
                    "(4212205,42,'Papanduva')," +
                    "(4212239,42,'Para�so')," +
                    "(4212254,42,'Passo de Torres')," +
                    "(4212270,42,'Passos Maia')," +
                    "(4212304,42,'Paulo Lopes')," +
                    "(4212403,42,'Pedras Grandes')," +
                    "(4212502,42,'Penha')," +
                    "(4212601,42,'Peritiba')," +
                    "(4212650,42,'Pescaria Brava')," +
                    "(4212700,42,'Petrol�ndia')," +
                    "(4212809,42,'Balne�rio Pi�arras')," +
                    "(4212908,42,'Pinhalzinho')," +
                    "(4213005,42,'Pinheiro Preto')," +
                    "(4213104,42,'Piratuba')," +
                    "(4213153,42,'Planalto Alegre')," +
                    "(4213203,42,'Pomerode')," +
                    "(4213302,42,'Ponte Alta')," +
                    "(4213351,42,'Ponte Alta do Norte')," +
                    "(4213401,42,'Ponte Serrada')," +
                    "(4213500,42,'Porto Belo')," +
                    "(4213609,42,'Porto Uni�o')," +
                    "(4213708,42,'Pouso Redondo')," +
                    "(4213807,42,'Praia Grande')," +
                    "(4213906,42,'Presidente Castello Branco')," +
                    "(4214003,42,'Presidente Get�lio')," +
                    "(4214102,42,'Presidente Nereu')," +
                    "(4214151,42,'Princesa')," +
                    "(4214201,42,'Quilombo')," +
                    "(4214300,42,'Rancho Queimado')," +
                    "(4214409,42,'Rio das Antas')," +
                    "(4214508,42,'Rio do Campo')," +
                    "(4214607,42,'Rio do Oeste')," +
                    "(4214706,42,'Rio dos Cedros')," +
                    "(4214805,42,'Rio do Sul')," +
                    "(4214904,42,'Rio Fortuna')," +
                    "(4215000,42,'Rio Negrinho')," +
                    "(4215059,42,'Rio Rufino')," +
                    "(4215075,42,'Riqueza')," +
                    "(4215109,42,'Rodeio')," +
                    "(4215208,42,'Romel�ndia')," +
                    "(4215307,42,'Salete')," +
                    "(4215356,42,'Saltinho')," +
                    "(4215406,42,'Salto Veloso')," +
                    "(4215455,42,'Sang�o')," +
                    "(4215505,42,'Santa Cec�lia')," +
                    "(4215554,42,'Santa Helena')," +
                    "(4215604,42,'Santa Rosa de Lima')," +
                    "(4215653,42,'Santa Rosa do Sul')," +
                    "(4215679,42,'Santa Terezinha')," +
                    "(4215687,42,'Santa Terezinha do Progresso')," +
                    "(4215695,42,'Santiago do Sul')," +
                    "(4215703,42,'Santo Amaro da Imperatriz')," +
                    "(4215752,42,'S�o Bernardino')," +
                    "(4215802,42,'S�o Bento do Sul')," +
                    "(4215901,42,'S�o Bonif�cio')," +
                    "(4216008,42,'S�o Carlos')," +
                    "(4216057,42,'S�o Cristov�o do Sul')," +
                    "(4216107,42,'S�o domingos')," +
                    "(4216206,42,'S�o Francisco do Sul')," +
                    "(4216255,42,'S�o Jo�o do Oeste')," +
                    "(4216305,42,'S�o Jo�o Batista')," +
                    "(4216354,42,'S�o Jo�o do Itaperi�')," +
                    "(4216404,42,'S�o Jo�o do Sul')," +
                    "(4216503,42,'S�o Joaquim')," +
                    "(4216602,42,'S�o Jos�')," +
                    "(4216701,42,'S�o Jos� do Cedro')," +
                    "(4216800,42,'S�o Jos� do Cerrito')," +
                    "(4216909,42,'S�o Louren�o do Oeste')," +
                    "(4217006,42,'S�o Ludgero')," +
                    "(4217105,42,'S�o Martinho')," +
                    "(4217154,42,'S�o Miguel da Boa Vista')," +
                    "(4217204,42,'S�o Miguel do Oeste')," +
                    "(4217253,42,'S�o Pedro de Alc�ntara')," +
                    "(4217303,42,'Saudades')," +
                    "(4217402,42,'Schroeder')," +
                    "(4217501,42,'Seara')," +
                    "(4217550,42,'Serra Alta')," +
                    "(4217600,42,'Sider�polis')," +
                    "(4217709,42,'Sombrio')," +
                    "(4217758,42,'Sul Brasil')," +
                    "(4217808,42,'Tai�')," +
                    "(4217907,42,'Tangar�')," +
                    "(4217956,42,'Tigrinhos')," +
                    "(4218004,42,'Tijucas')," +
                    "(4218103,42,'Timb� do Sul')," +
                    "(4218202,42,'Timb�')," +
                    "(4218251,42,'Timb� Grande')," +
                    "(4218301,42,'Tr�s Barras')," +
                    "(4218350,42,'Treviso')," +
                    "(4218400,42,'Treze de Maio')," +
                    "(4218509,42,'Treze T�lias')," +
                    "(4218608,42,'Trombudo Central')," +
                    "(4218707,42,'Tubar�o')," +
                    "(4218756,42,'Tun�polis')," +
                    "(4218806,42,'Turvo')," +
                    "(4218855,42,'Uni�o do Oeste')," +
                    "(4218905,42,'Urubici')," +
                    "(4218954,42,'Urupema')," +
                    "(4219002,42,'Urussanga')," +
                    "(4219101,42,'Varge�o')," +
                    "(4219150,42,'Vargem')," +
                    "(4219176,42,'Vargem Bonita')," +
                    "(4219200,42,'Vidal Ramos')," +
                    "(4219309,42,'Videira')," +
                    "(4219358,42,'Vitor Meireles')," +
                    "(4219408,42,'Witmarsum')," +
                    "(4219507,42,'Xanxer�')," +
                    "(4219606,42,'Xavantina')," +
                    "(4219705,42,'Xaxim')," +
                    "(4219853,42,'Zort�a')," +
                    "(4220000,42,'Balne�rio Rinc�o')," +
                    "(4300034,43,'Acegu�')," +
                    "(4300059,43,'�gua Santa')," +
                    "(4300109,43,'Agudo')," +
                    "(4300208,43,'Ajuricaba')," +
                    "(4300307,43,'Alecrim')," +
                    "(4300406,43,'Alegrete')," +
                    "(4300455,43,'Alegria')," +
                    "(4300471,43,'Almirante Tamandar� do Sul')," +
                    "(4300505,43,'Alpestre')," +
                    "(4300554,43,'Alto Alegre')," +
                    "(4300570,43,'Alto Feliz')," +
                    "(4300604,43,'Alvorada')," +
                    "(4300638,43,'Amaral Ferrador')," +
                    "(4300646,43,'Ametista do Sul')," +
                    "(4300661,43,'Andr� da Rocha')," +
                    "(4300703,43,'Anta Gorda')," +
                    "(4300802,43,'Ant�nio Prado')," +
                    "(4300851,43,'Arambar�')," +
                    "(4300877,43,'Araric�')," +
                    "(4300901,43,'Aratiba')," +
                    "(4301008,43,'Arroio do Meio')," +
                    "(4301057,43,'Arroio do Sal')," +
                    "(4301073,43,'Arroio do Padre')," +
                    "(4301107,43,'Arroio dos Ratos')," +
                    "(4301206,43,'Arroio do Tigre')," +
                    "(4301305,43,'Arroio Grande')," +
                    "(4301404,43,'Arvorezinha')," +
                    "(4301503,43,'Augusto Pestana')," +
                    "(4301552,43,'�urea')," +
                    "(4301602,43,'Bag�')," +
                    "(4301636,43,'Balne�rio Pinhal')," +
                    "(4301651,43,'Bar�o')," +
                    "(4301701,43,'Bar�o de Cotegipe')," +
                    "(4301750,43,'Bar�o do Triunfo')," +
                    "(4301800,43,'Barrac�o')," +
                    "(4301859,43,'Barra do Guarita')," +
                    "(4301875,43,'Barra do Quara�')," +
                    "(4301909,43,'Barra do Ribeiro')," +
                    "(4301925,43,'Barra do Rio Azul')," +
                    "(4301958,43,'Barra Funda')," +
                    "(4302006,43,'Barros Cassal')," +
                    "(4302055,43,'Benjamin Constant do Sul')," +
                    "(4302105,43,'Bento Gon�alves')," +
                    "(4302154,43,'Boa Vista das Miss�es')," +
                    "(4302204,43,'Boa Vista do Buric�')," +
                    "(4302220,43,'Boa Vista do Cadeado')," +
                    "(4302238,43,'Boa Vista do Incra')," +
                    "(4302253,43,'Boa Vista do Sul')," +
                    "(4302303,43,'Bom Jesus')," +
                    "(4302352,43,'Bom Princ�pio')," +
                    "(4302378,43,'Bom Progresso')," +
                    "(4302402,43,'Bom Retiro do Sul')," +
                    "(4302451,43,'Boqueir�o do Le�o')," +
                    "(4302501,43,'Bossoroca')," +
                    "(4302584,43,'Bozano')," +
                    "(4302600,43,'Braga')," +
                    "(4302659,43,'Brochier')," +
                    "(4302709,43,'Buti�')," +
                    "(4302808,43,'Ca�apava do Sul')," +
                    "(4302907,43,'Cacequi')," +
                    "(4303004,43,'Cachoeira do Sul')," +
                    "(4303103,43,'Cachoeirinha')," +
                    "(4303202,43,'Cacique doble')," +
                    "(4303301,43,'Caibat�')," +
                    "(4303400,43,'Cai�ara')," +
                    "(4303509,43,'Camaqu�')," +
                    "(4303558,43,'Camargo')," +
                    "(4303608,43,'Cambar� do Sul')," +
                    "(4303673,43,'Campestre da Serra')," +
                    "(4303707,43,'Campina das Miss�es')," +
                    "(4303806,43,'Campinas do Sul')," +
                    "(4303905,43,'Campo Bom')," +
                    "(4304002,43,'Campo Novo')," +
                    "(4304101,43,'Campos Borges')," +
                    "(4304200,43,'Candel�ria')," +
                    "(4304309,43,'C�ndido God�i')," +
                    "(4304358,43,'Candiota')," +
                    "(4304408,43,'Canela')," +
                    "(4304507,43,'Cangu�u')," +
                    "(4304606,43,'Canoas')," +
                    "(4304614,43,'Canudos do Vale')," +
                    "(4304622,43,'Cap�o Bonito do Sul')," +
                    "(4304630,43,'Cap�o da Canoa')," +
                    "(4304655,43,'Cap�o do Cip�')," +
                    "(4304663,43,'Cap�o do Le�o')," +
                    "(4304671,43,'Capivari do Sul')," +
                    "(4304689,43,'Capela de Santana')," +
                    "(4304697,43,'Capit�o')," +
                    "(4304705,43,'Carazinho')," +
                    "(4304713,43,'Cara�')," +
                    "(4304804,43,'Carlos Barbosa')," +
                    "(4304853,43,'Carlos Gomes')," +
                    "(4304903,43,'Casca')," +
                    "(4304952,43,'Caseiros')," +
                    "(4305009,43,'Catu�pe')," +
                    "(4305108,43,'Caxias do Sul')," +
                    "(4305116,43,'Centen�rio')," +
                    "(4305124,43,'Cerrito')," +
                    "(4305132,43,'Cerro Branco')," +
                    "(4305157,43,'Cerro Grande')," +
                    "(4305173,43,'Cerro Grande do Sul')," +
                    "(4305207,43,'Cerro Largo')," +
                    "(4305306,43,'Chapada')," +
                    "(4305355,43,'Charqueadas')," +
                    "(4305371,43,'Charrua')," +
                    "(4305405,43,'Chiapetta')," +
                    "(4305439,43,'Chu�')," +
                    "(4305447,43,'Chuvisca')," +
                    "(4305454,43,'Cidreira')," +
                    "(4305504,43,'Cir�aco')," +
                    "(4305587,43,'Colinas')," +
                    "(4305603,43,'Colorado')," +
                    "(4305702,43,'Condor')," +
                    "(4305801,43,'Constantina')," +
                    "(4305835,43,'Coqueiro Baixo')," +
                    "(4305850,43,'Coqueiros do Sul')," +
                    "(4305871,43,'Coronel Barros')," +
                    "(4305900,43,'Coronel Bicaco')," +
                    "(4305934,43,'Coronel Pilar')," +
                    "(4305959,43,'Cotipor�')," +
                    "(4305975,43,'Coxilha')," +
                    "(4306007,43,'Crissiumal')," +
                    "(4306056,43,'Cristal')," +
                    "(4306072,43,'Cristal do Sul')," +
                    "(4306106,43,'Cruz Alta')," +
                    "(4306130,43,'Cruzaltense')," +
                    "(4306205,43,'Cruzeiro do Sul')," +
                    "(4306304,43,'david Canabarro')," +
                    "(4306320,43,'derrubadas')," +
                    "(4306353,43,'dezesseis de Novembro')," +
                    "(4306379,43,'Dilermando de Aguiar')," +
                    "(4306403,43,'dois Irm�os')," +
                    "(4306429,43,'dois Irm�os das Miss�es')," +
                    "(4306452,43,'dois Lajeados')," +
                    "(4306502,43,'dom Feliciano')," +
                    "(4306551,43,'dom Pedro de Alc�ntara')," +
                    "(4306601,43,'dom Pedrito')," +
                    "(4306700,43,'dona Francisca')," +
                    "(4306734,43,'doutor Maur�cio Cardoso')," +
                    "(4306759,43,'doutor Ricardo')," +
                    "(4306767,43,'Eldorado do Sul')," +
                    "(4306809,43,'Encantado')," +
                    "(4306908,43,'Encruzilhada do Sul')," +
                    "(4306924,43,'Engenho Velho')," +
                    "(4306932,43,'Entre-Iju�s')," +
                    "(4306957,43,'Entre Rios do Sul')," +
                    "(4306973,43,'Erebango')," +
                    "(4307005,43,'Erechim')," +
                    "(4307054,43,'Ernestina')," +
                    "(4307104,43,'Herval')," +
                    "(4307203,43,'Erval Grande')," +
                    "(4307302,43,'Erval Seco')," +
                    "(4307401,43,'Esmeralda')," +
                    "(4307450,43,'Esperan�a do Sul')," +
                    "(4307500,43,'Espumoso')," +
                    "(4307559,43,'Esta��o')," +
                    "(4307609,43,'Est�ncia Velha')," +
                    "(4307708,43,'Esteio')," +
                    "(4307807,43,'Estrela')," +
                    "(4307815,43,'Estrela Velha')," +
                    "(4307831,43,'Eug�nio de Castro')," +
                    "(4307864,43,'Fagundes Varela')," +
                    "(4307906,43,'Farroupilha')," +
                    "(4308003,43,'Faxinal do Soturno')," +
                    "(4308052,43,'Faxinalzinho')," +
                    "(4308078,43,'Fazenda Vilanova')," +
                    "(4308102,43,'Feliz')," +
                    "(4308201,43,'Flores da Cunha')," +
                    "(4308250,43,'Floriano Peixoto')," +
                    "(4308300,43,'Fontoura Xavier')," +
                    "(4308409,43,'Formigueiro')," +
                    "(4308433,43,'Forquetinha')," +
                    "(4308458,43,'Fortaleza dos Valos')," +
                    "(4308508,43,'Frederico Westphalen')," +
                    "(4308607,43,'Garibaldi')," +
                    "(4308656,43,'Garruchos')," +
                    "(4308706,43,'Gaurama')," +
                    "(4308805,43,'General C�mara')," +
                    "(4308854,43,'Gentil')," +
                    "(4308904,43,'Get�lio Vargas')," +
                    "(4309001,43,'Giru�')," +
                    "(4309050,43,'Glorinha')," +
                    "(4309100,43,'Gramado')," +
                    "(4309126,43,'Gramado dos Loureiros')," +
                    "(4309159,43,'Gramado Xavier')," +
                    "(4309209,43,'Gravata�')," +
                    "(4309258,43,'Guabiju')," +
                    "(4309308,43,'Gua�ba')," +
                    "(4309407,43,'Guapor�')," +
                    "(4309506,43,'Guarani das Miss�es')," +
                    "(4309555,43,'Harmonia')," +
                    "(4309571,43,'Herveiras')," +
                    "(4309605,43,'Horizontina')," +
                    "(4309654,43,'Hulha Negra')," +
                    "(4309704,43,'Humait�')," +
                    "(4309753,43,'Ibarama')," +
                    "(4309803,43,'Ibia��')," +
                    "(4309902,43,'Ibiraiaras')," +
                    "(4309951,43,'Ibirapuit�')," +
                    "(4310009,43,'Ibirub�')," +
                    "(4310108,43,'Igrejinha')," +
                    "(4310207,43,'Iju�')," +
                    "(4310306,43,'Il�polis')," +
                    "(4310330,43,'Imb�')," +
                    "(4310363,43,'Imigrante')," +
                    "(4310405,43,'Independ�ncia')," +
                    "(4310413,43,'Inhacor�')," +
                    "(4310439,43,'Ip�')," +
                    "(4310462,43,'Ipiranga do Sul')," +
                    "(4310504,43,'Ira�')," +
                    "(4310538,43,'Itaara')," +
                    "(4310553,43,'Itacurubi')," +
                    "(4310579,43,'Itapuca')," +
                    "(4310603,43,'Itaqui')," +
                    "(4310652,43,'Itati')," +
                    "(4310702,43,'Itatiba do Sul')," +
                    "(4310751,43,'Ivor�')," +
                    "(4310801,43,'Ivoti')," +
                    "(4310850,43,'Jaboticaba')," +
                    "(4310876,43,'Jacuizinho')," +
                    "(4310900,43,'Jacutinga')," +
                    "(4311007,43,'Jaguar�o')," +
                    "(4311106,43,'Jaguari')," +
                    "(4311122,43,'Jaquirana')," +
                    "(4311130,43,'Jari')," +
                    "(4311155,43,'J�ia')," +
                    "(4311205,43,'J�lio de Castilhos')," +
                    "(4311239,43,'Lagoa Bonita do Sul')," +
                    "(4311254,43,'Lago�o')," +
                    "(4311270,43,'Lagoa dos Tr�s Cantos')," +
                    "(4311304,43,'Lagoa Vermelha')," +
                    "(4311403,43,'Lajeado')," +
                    "(4311429,43,'Lajeado do Bugre')," +
                    "(4311502,43,'Lavras do Sul')," +
                    "(4311601,43,'Liberato Salzano')," +
                    "(4311627,43,'Lindolfo Collor')," +
                    "(4311643,43,'Linha Nova')," +
                    "(4311700,43,'Machadinho')," +
                    "(4311718,43,'Ma�ambar�')," +
                    "(4311734,43,'Mampituba')," +
                    "(4311759,43,'Manoel Viana')," +
                    "(4311775,43,'Maquin�')," +
                    "(4311791,43,'Marat�')," +
                    "(4311809,43,'Marau')," +
                    "(4311908,43,'Marcelino Ramos')," +
                    "(4311981,43,'Mariana Pimentel')," +
                    "(4312005,43,'Mariano Moro')," +
                    "(4312054,43,'Marques de Souza')," +
                    "(4312104,43,'Mata')," +
                    "(4312138,43,'Mato Castelhano')," +
                    "(4312153,43,'Mato Leit�o')," +
                    "(4312179,43,'Mato Queimado')," +
                    "(4312203,43,'Maximiliano de Almeida')," +
                    "(4312252,43,'Minas do Le�o')," +
                    "(4312302,43,'Miragua�')," +
                    "(4312351,43,'Montauri')," +
                    "(4312377,43,'Monte Alegre dos Campos')," +
                    "(4312385,43,'Monte Belo do Sul')," +
                    "(4312401,43,'Montenegro')," +
                    "(4312427,43,'Morma�o')," +
                    "(4312443,43,'Morrinhos do Sul')," +
                    "(4312450,43,'Morro Redondo')," +
                    "(4312476,43,'Morro Reuter')," +
                    "(4312500,43,'Mostardas')," +
                    "(4312609,43,'Mu�um')," +
                    "(4312617,43,'Muitos Cap�es')," +
                    "(4312625,43,'Muliterno')," +
                    "(4312658,43,'N�o-Me-Toque')," +
                    "(4312674,43,'Nicolau Vergueiro')," +
                    "(4312708,43,'Nonoai')," +
                    "(4312757,43,'Nova Alvorada')," +
                    "(4312807,43,'Nova Ara��')," +
                    "(4312906,43,'Nova Bassano')," +
                    "(4312955,43,'Nova Boa Vista')," +
                    "(4313003,43,'Nova Br�scia')," +
                    "(4313011,43,'Nova Candel�ria')," +
                    "(4313037,43,'Nova Esperan�a do Sul')," +
                    "(4313060,43,'Nova Hartz')," +
                    "(4313086,43,'Nova P�dua')," +
                    "(4313102,43,'Nova Palma')," +
                    "(4313201,43,'Nova Petr�polis')," +
                    "(4313300,43,'Nova Prata')," +
                    "(4313334,43,'Nova Ramada')," +
                    "(4313359,43,'Nova Roma do Sul')," +
                    "(4313375,43,'Nova Santa Rita')," +
                    "(4313391,43,'Novo Cabrais')," +
                    "(4313409,43,'Novo Hamburgo')," +
                    "(4313425,43,'Novo Machado')," +
                    "(4313441,43,'Novo Tiradentes')," +
                    "(4313466,43,'Novo Xingu')," +
                    "(4313490,43,'Novo Barreiro')," +
                    "(4313508,43,'Os�rio')," +
                    "(4313607,43,'Paim Filho')," +
                    "(4313656,43,'Palmares do Sul')," +
                    "(4313706,43,'Palmeira das Miss�es')," +
                    "(4313805,43,'Palmitinho')," +
                    "(4313904,43,'Panambi')," +
                    "(4313953,43,'Pantano Grande')," +
                    "(4314001,43,'Para�')," +
                    "(4314027,43,'Para�so do Sul')," +
                    "(4314035,43,'Pareci Novo')," +
                    "(4314050,43,'Parob�')," +
                    "(4314068,43,'Passa Sete')," +
                    "(4314076,43,'Passo do Sobrado')," +
                    "(4314100,43,'Passo Fundo')," +
                    "(4314134,43,'Paulo Bento')," +
                    "(4314159,43,'Paverama')," +
                    "(4314175,43,'Pedras Altas')," +
                    "(4314209,43,'Pedro Os�rio')," +
                    "(4314308,43,'Peju�ara')," +
                    "(4314407,43,'Pelotas')," +
                    "(4314423,43,'Picada Caf�')," +
                    "(4314456,43,'Pinhal')," +
                    "(4314464,43,'Pinhal da Serra')," +
                    "(4314472,43,'Pinhal Grande')," +
                    "(4314498,43,'Pinheirinho do Vale')," +
                    "(4314506,43,'Pinheiro Machado')," +
                    "(4314548,43,'Pinto Bandeira')," +
                    "(4314555,43,'Pirap�')," +
                    "(4314605,43,'Piratini')," +
                    "(4314704,43,'Planalto')," +
                    "(4314753,43,'Po�o das Antas')," +
                    "(4314779,43,'Pont�o')," +
                    "(4314787,43,'Ponte Preta')," +
                    "(4314803,43,'Port�o')," +
                    "(4314902,43,'Porto Alegre')," +
                    "(4315008,43,'Porto Lucena')," +
                    "(4315057,43,'Porto Mau�')," +
                    "(4315073,43,'Porto Vera Cruz')," +
                    "(4315107,43,'Porto Xavier')," +
                    "(4315131,43,'Pouso Novo')," +
                    "(4315149,43,'Presidente Lucena')," +
                    "(4315156,43,'Progresso')," +
                    "(4315172,43,'Prot�sio Alves')," +
                    "(4315206,43,'Putinga')," +
                    "(4315305,43,'Quara�')," +
                    "(4315313,43,'Quatro Irm�os')," +
                    "(4315321,43,'Quevedos')," +
                    "(4315354,43,'Quinze de Novembro')," +
                    "(4315404,43,'Redentora')," +
                    "(4315453,43,'Relvado')," +
                    "(4315503,43,'Restinga Seca')," +
                    "(4315552,43,'Rio dos �ndios')," +
                    "(4315602,43,'Rio Grande')," +
                    "(4315701,43,'Rio Pardo')," +
                    "(4315750,43,'Riozinho')," +
                    "(4315800,43,'Roca Sales')," +
                    "(4315909,43,'Rodeio Bonito')," +
                    "(4315958,43,'Rolador')," +
                    "(4316006,43,'Rolante')," +
                    "(4316105,43,'Ronda Alta')," +
                    "(4316204,43,'Rondinha')," +
                    "(4316303,43,'Roque Gonzales')," +
                    "(4316402,43,'Ros�rio do Sul')," +
                    "(4316428,43,'Sagrada Fam�lia')," +
                    "(4316436,43,'Saldanha Marinho')," +
                    "(4316451,43,'Salto do Jacu�')," +
                    "(4316477,43,'Salvador das Miss�es')," +
                    "(4316501,43,'Salvador do Sul')," +
                    "(4316600,43,'Sananduva')," +
                    "(4316709,43,'Santa B�rbara do Sul')," +
                    "(4316733,43,'Santa Cec�lia do Sul')," +
                    "(4316758,43,'Santa Clara do Sul')," +
                    "(4316808,43,'Santa Cruz do Sul')," +
                    "(4316907,43,'Santa Maria')," +
                    "(4316956,43,'Santa Maria do Herval')," +
                    "(4316972,43,'Santa Margarida do Sul')," +
                    "(4317004,43,'Santana da Boa Vista')," +
                    "(4317103,43,'Santana do Livramento')," +
                    "(4317202,43,'Santa Rosa')," +
                    "(4317251,43,'Santa Tereza')," +
                    "(4317301,43,'Santa Vit�ria do Palmar')," +
                    "(4317400,43,'Santiago')," +
                    "(4317509,43,'Santo �ngelo')," +
                    "(4317558,43,'Santo Ant�nio do Palma')," +
                    "(4317608,43,'Santo Ant�nio da Patrulha')," +
                    "(4317707,43,'Santo Ant�nio das Miss�es')," +
                    "(4317756,43,'Santo Ant�nio do Planalto')," +
                    "(4317806,43,'Santo Augusto')," +
                    "(4317905,43,'Santo Cristo')," +
                    "(4317954,43,'Santo Expedito do Sul')," +
                    "(4318002,43,'S�o Borja')," +
                    "(4318051,43,'S�o domingos do Sul')," +
                    "(4318101,43,'S�o Francisco de Assis')," +
                    "(4318200,43,'S�o Francisco de Paula')," +
                    "(4318309,43,'S�o Gabriel')," +
                    "(4318408,43,'S�o Jer�nimo')," +
                    "(4318424,43,'S�o Jo�o da Urtiga')," +
                    "(4318432,43,'S�o Jo�o do Pol�sine')," +
                    "(4318440,43,'S�o Jorge')," +
                    "(4318457,43,'S�o Jos� das Miss�es')," +
                    "(4318465,43,'S�o Jos� do Herval')," +
                    "(4318481,43,'S�o Jos� do Hort�ncio')," +
                    "(4318499,43,'S�o Jos� do Inhacor�')," +
                    "(4318507,43,'S�o Jos� do Norte')," +
                    "(4318606,43,'S�o Jos� do Ouro')," +
                    "(4318614,43,'S�o Jos� do Sul')," +
                    "(4318622,43,'S�o Jos� dos Ausentes')," +
                    "(4318705,43,'S�o Leopoldo')," +
                    "(4318804,43,'S�o Louren�o do Sul')," +
                    "(4318903,43,'S�o Luiz Gonzaga')," +
                    "(4319000,43,'S�o Marcos')," +
                    "(4319109,43,'S�o Martinho')," +
                    "(4319125,43,'S�o Martinho da Serra')," +
                    "(4319158,43,'S�o Miguel das Miss�es')," +
                    "(4319208,43,'S�o Nicolau')," +
                    "(4319307,43,'S�o Paulo das Miss�es')," +
                    "(4319356,43,'S�o Pedro da Serra')," +
                    "(4319364,43,'S�o Pedro das Miss�es')," +
                    "(4319372,43,'S�o Pedro do Buti�')," +
                    "(4319406,43,'S�o Pedro do Sul')," +
                    "(4319505,43,'S�o Sebasti�o do Ca�')," +
                    "(4319604,43,'S�o Sep�')," +
                    "(4319703,43,'S�o Valentim')," +
                    "(4319711,43,'S�o Valentim do Sul')," +
                    "(4319737,43,'S�o Val�rio do Sul')," +
                    "(4319752,43,'S�o Vendelino')," +
                    "(4319802,43,'S�o Vicente do Sul')," +
                    "(4319901,43,'Sapiranga')," +
                    "(4320008,43,'Sapucaia do Sul')," +
                    "(4320107,43,'Sarandi')," +
                    "(4320206,43,'Seberi')," +
                    "(4320230,43,'Sede Nova')," +
                    "(4320263,43,'Segredo')," +
                    "(4320305,43,'Selbach')," +
                    "(4320321,43,'Senador Salgado Filho')," +
                    "(4320354,43,'Sentinela do Sul')," +
                    "(4320404,43,'Serafina Corr�a')," +
                    "(4320453,43,'S�rio')," +
                    "(4320503,43,'Sert�o')," +
                    "(4320552,43,'Sert�o Santana')," +
                    "(4320578,43,'Sete de Setembro')," +
                    "(4320602,43,'Severiano de Almeida')," +
                    "(4320651,43,'Silveira Martins')," +
                    "(4320677,43,'Sinimbu')," +
                    "(4320701,43,'Sobradinho')," +
                    "(4320800,43,'Soledade')," +
                    "(4320859,43,'Taba�')," +
                    "(4320909,43,'Tapejara')," +
                    "(4321006,43,'Tapera')," +
                    "(4321105,43,'Tapes')," +
                    "(4321204,43,'Taquara')," +
                    "(4321303,43,'Taquari')," +
                    "(4321329,43,'Taquaru�u do Sul')," +
                    "(4321352,43,'Tavares')," +
                    "(4321402,43,'Tenente Portela')," +
                    "(4321436,43,'Terra de Areia')," +
                    "(4321451,43,'Teut�nia')," +
                    "(4321469,43,'Tio Hugo')," +
                    "(4321477,43,'Tiradentes do Sul')," +
                    "(4321493,43,'Toropi')," +
                    "(4321501,43,'Torres')," +
                    "(4321600,43,'Tramanda�')," +
                    "(4321626,43,'Travesseiro')," +
                    "(4321634,43,'Tr�s Arroios')," +
                    "(4321667,43,'Tr�s Cachoeiras')," +
                    "(4321709,43,'Tr�s Coroas')," +
                    "(4321808,43,'Tr�s de Maio')," +
                    "(4321832,43,'Tr�s Forquilhas')," +
                    "(4321857,43,'Tr�s Palmeiras')," +
                    "(4321907,43,'Tr�s Passos')," +
                    "(4321956,43,'Trindade do Sul')," +
                    "(4322004,43,'Triunfo')," +
                    "(4322103,43,'Tucunduva')," +
                    "(4322152,43,'Tunas')," +
                    "(4322186,43,'Tupanci do Sul')," +
                    "(4322202,43,'Tupanciret�')," +
                    "(4322251,43,'Tupandi')," +
                    "(4322301,43,'Tuparendi')," +
                    "(4322327,43,'Turu�u')," +
                    "(4322343,43,'Ubiretama')," +
                    "(4322350,43,'Uni�o da Serra')," +
                    "(4322376,43,'Unistalda')," +
                    "(4322400,43,'Uruguaiana')," +
                    "(4322509,43,'Vacaria')," +
                    "(4322525,43,'Vale Verde')," +
                    "(4322533,43,'Vale do Sol')," +
                    "(4322541,43,'Vale Real')," +
                    "(4322558,43,'Vanini')," +
                    "(4322608,43,'Ven�ncio Aires')," +
                    "(4322707,43,'Vera Cruz')," +
                    "(4322806,43,'Veran�polis')," +
                    "(4322855,43,'Vespasiano Correa')," +
                    "(4322905,43,'Viadutos')," +
                    "(4323002,43,'Viam�o')," +
                    "(4323101,43,'Vicente Dutra')," +
                    "(4323200,43,'Victor Graeff')," +
                    "(4323309,43,'Vila Flores')," +
                    "(4323358,43,'Vila L�ngaro')," +
                    "(4323408,43,'Vila Maria')," +
                    "(4323457,43,'Vila Nova do Sul')," +
                    "(4323507,43,'Vista Alegre')," +
                    "(4323606,43,'Vista Alegre do Prata')," +
                    "(4323705,43,'Vista Ga�cha')," +
                    "(4323754,43,'Vit�ria das Miss�es')," +
                    "(4323770,43,'Westfalia')," +
                    "(4323804,43,'Xangri-L�')," +
                    "(5000203,50,'�gua Clara')," +
                    "(5000252,50,'Alcin�polis')," +
                    "(5000609,50,'Amambai')," +
                    "(5000708,50,'Anast�cio')," +
                    "(5000807,50,'Anauril�ndia')," +
                    "(5000856,50,'Ang�lica')," +
                    "(5000906,50,'Ant�nio Jo�o')," +
                    "(5001003,50,'Aparecida do Taboado')," +
                    "(5001102,50,'Aquidauana')," +
                    "(5001243,50,'Aral Moreira')," +
                    "(5001508,50,'Bandeirantes')," +
                    "(5001904,50,'Bataguassu')," +
                    "(5002001,50,'Bataypor�')," +
                    "(5002100,50,'Bela Vista')," +
                    "(5002159,50,'Bodoquena')," +
                    "(5002209,50,'Bonito')," +
                    "(5002308,50,'Brasil�ndia')," +
                    "(5002407,50,'Caarap�')," +
                    "(5002605,50,'Camapu�')," +
                    "(5002704,50,'Campo Grande')," +
                    "(5002803,50,'Caracol')," +
                    "(5002902,50,'Cassil�ndia')," +
                    "(5002951,50,'Chapad�o do Sul')," +
                    "(5003108,50,'Corguinho')," +
                    "(5003157,50,'Coronel Sapucaia')," +
                    "(5003207,50,'Corumb�')," +
                    "(5003256,50,'Costa Rica')," +
                    "(5003306,50,'Coxim')," +
                    "(5003454,50,'deod�polis')," +
                    "(5003488,50,'dois Irm�os do Buriti')," +
                    "(5003504,50,'douradina')," +
                    "(5003702,50,'dourados')," +
                    "(5003751,50,'Eldorado')," +
                    "(5003801,50,'F�tima do Sul')," +
                    "(5003900,50,'Figueir�o')," +
                    "(5004007,50,'Gl�ria de dourados')," +
                    "(5004106,50,'Guia Lopes da Laguna')," +
                    "(5004304,50,'Iguatemi')," +
                    "(5004403,50,'Inoc�ncia')," +
                    "(5004502,50,'Itapor�')," +
                    "(5004601,50,'Itaquira�')," +
                    "(5004700,50,'Ivinhema')," +
                    "(5004809,50,'Japor�')," +
                    "(5004908,50,'Jaraguari')," +
                    "(5005004,50,'Jardim')," +
                    "(5005103,50,'Jate�')," +
                    "(5005152,50,'Juti')," +
                    "(5005202,50,'Lad�rio')," +
                    "(5005251,50,'Laguna Carap�')," +
                    "(5005400,50,'Maracaju')," +
                    "(5005608,50,'Miranda')," +
                    "(5005681,50,'Mundo Novo')," +
                    "(5005707,50,'Navira�')," +
                    "(5005806,50,'Nioaque')," +
                    "(5006002,50,'Nova Alvorada do Sul')," +
                    "(5006200,50,'Nova Andradina')," +
                    "(5006259,50,'Novo Horizonte do Sul')," +
                    "(5006275,50,'Para�so das �guas')," +
                    "(5006309,50,'Parana�ba')," +
                    "(5006358,50,'Paranhos')," +
                    "(5006408,50,'Pedro Gomes')," +
                    "(5006606,50,'Ponta Por�')," +
                    "(5006903,50,'Porto Murtinho')," +
                    "(5007109,50,'Ribas do Rio Pardo')," +
                    "(5007208,50,'Rio Brilhante')," +
                    "(5007307,50,'Rio Negro')," +
                    "(5007406,50,'Rio Verde de Mato Grosso')," +
                    "(5007505,50,'Rochedo')," +
                    "(5007554,50,'Santa Rita do Pardo')," +
                    "(5007695,50,'S�o Gabriel do Oeste')," +
                    "(5007703,50,'Sete Quedas')," +
                    "(5007802,50,'Selv�ria')," +
                    "(5007901,50,'Sidrol�ndia')," +
                    "(5007935,50,'Sonora')," +
                    "(5007950,50,'Tacuru')," +
                    "(5007976,50,'Taquarussu')," +
                    "(5008008,50,'Terenos')," +
                    "(5008305,50,'Tr�s Lagoas')," +
                    "(5008404,50,'Vicentina')," +
                    "(5100102,51,'Acorizal')," +
                    "(5100201,51,'�gua Boa')," +
                    "(5100250,51,'Alta Floresta')," +
                    "(5100300,51,'Alto Araguaia')," +
                    "(5100359,51,'Alto Boa Vista')," +
                    "(5100409,51,'Alto Gar�as')," +
                    "(5100508,51,'Alto Paraguai')," +
                    "(5100607,51,'Alto Taquari')," +
                    "(5100805,51,'Apiac�s')," +
                    "(5101001,51,'Araguaiana')," +
                    "(5101209,51,'Araguainha')," +
                    "(5101258,51,'Araputanga')," +
                    "(5101308,51,'Aren�polis')," +
                    "(5101407,51,'Aripuan�')," +
                    "(5101605,51,'Bar�o de Melga�o')," +
                    "(5101704,51,'Barra do Bugres')," +
                    "(5101803,51,'Barra do Gar�as')," +
                    "(5101852,51,'Bom Jesus do Araguaia')," +
                    "(5101902,51,'Brasnorte')," +
                    "(5102504,51,'C�ceres')," +
                    "(5102603,51,'Campin�polis')," +
                    "(5102637,51,'Campo Novo do Parecis')," +
                    "(5102678,51,'Campo Verde')," +
                    "(5102686,51,'Campos de J�lio')," +
                    "(5102694,51,'Canabrava do Norte')," +
                    "(5102702,51,'Canarana')," +
                    "(5102793,51,'Carlinda')," +
                    "(5102850,51,'Castanheira')," +
                    "(5103007,51,'Chapada dos Guimar�es')," +
                    "(5103056,51,'Cl�udia')," +
                    "(5103106,51,'Cocalinho')," +
                    "(5103205,51,'Col�der')," +
                    "(5103254,51,'Colniza')," +
                    "(5103304,51,'Comodoro')," +
                    "(5103353,51,'Confresa')," +
                    "(5103361,51,'Conquista Doeste')," +
                    "(5103379,51,'Cotrigua�u')," +
                    "(5103403,51,'Cuiab�')," +
                    "(5103437,51,'Curvel�ndia')," +
                    "(5103452,51,'denise')," +
                    "(5103502,51,'Diamantino')," +
                    "(5103601,51,'dom Aquino')," +
                    "(5103700,51,'Feliz Natal')," +
                    "(5103809,51,'Figueir�polis Doeste')," +
                    "(5103858,51,'Ga�cha do Norte')," +
                    "(5103908,51,'General Carneiro')," +
                    "(5103957,51,'Gl�ria Doeste')," +
                    "(5104104,51,'Guarant� do Norte')," +
                    "(5104203,51,'Guiratinga')," +
                    "(5104500,51,'Indiava�')," +
                    "(5104526,51,'Ipiranga do Norte')," +
                    "(5104542,51,'Itanhang�')," +
                    "(5104559,51,'Ita�ba')," +
                    "(5104609,51,'Itiquira')," +
                    "(5104807,51,'Jaciara')," +
                    "(5104906,51,'Jangada')," +
                    "(5105002,51,'Jauru')," +
                    "(5105101,51,'Juara')," +
                    "(5105150,51,'Ju�na')," +
                    "(5105176,51,'Juruena')," +
                    "(5105200,51,'Juscimeira')," +
                    "(5105234,51,'Lambari Doeste')," +
                    "(5105259,51,'Lucas do Rio Verde')," +
                    "(5105309,51,'Luciara')," +
                    "(5105507,51,'Vila Bela da Sant�ssima Trindade')," +
                    "(5105580,51,'Marcel�ndia')," +
                    "(5105606,51,'Matup�')," +
                    "(5105622,51,'Mirassol Doeste')," +
                    "(5105903,51,'Nobres')," +
                    "(5106000,51,'Nortel�ndia')," +
                    "(5106109,51,'Nossa Senhora do Livramento')," +
                    "(5106158,51,'Nova Bandeirantes')," +
                    "(5106174,51,'Nova Nazar�')," +
                    "(5106182,51,'Nova Lacerda')," +
                    "(5106190,51,'Nova Santa Helena')," +
                    "(5106208,51,'Nova Brasil�ndia')," +
                    "(5106216,51,'Nova Cana� do Norte')," +
                    "(5106224,51,'Nova Mutum')," +
                    "(5106232,51,'Nova Ol�mpia')," +
                    "(5106240,51,'Nova Ubirat�')," +
                    "(5106257,51,'Nova Xavantina')," +
                    "(5106265,51,'Novo Mundo')," +
                    "(5106273,51,'Novo Horizonte do Norte')," +
                    "(5106281,51,'Novo S�o Joaquim')," +
                    "(5106299,51,'Parana�ta')," +
                    "(5106307,51,'Paranatinga')," +
                    "(5106315,51,'Novo Santo Ant�nio')," +
                    "(5106372,51,'Pedra Preta')," +
                    "(5106422,51,'Peixoto de Azevedo')," +
                    "(5106455,51,'Planalto da Serra')," +
                    "(5106505,51,'Pocon�')," +
                    "(5106653,51,'Pontal do Araguaia')," +
                    "(5106703,51,'Ponte Branca')," +
                    "(5106752,51,'Pontes E Lacerda')," +
                    "(5106778,51,'Porto Alegre do Norte')," +
                    "(5106802,51,'Porto dos Ga�chos')," +
                    "(5106828,51,'Porto Esperidi�o')," +
                    "(5106851,51,'Porto Estrela')," +
                    "(5107008,51,'Poxor�u')," +
                    "(5107040,51,'Primavera do Leste')," +
                    "(5107065,51,'Quer�ncia')," +
                    "(5107107,51,'S�o Jos� dos Quatro Marcos')," +
                    "(5107156,51,'Reserva do Caba�al')," +
                    "(5107180,51,'Ribeir�o Cascalheira')," +
                    "(5107198,51,'Ribeir�ozinho')," +
                    "(5107206,51,'Rio Branco')," +
                    "(5107248,51,'Santa Carmem')," +
                    "(5107263,51,'Santo Afonso')," +
                    "(5107297,51,'S�o Jos� do Povo')," +
                    "(5107305,51,'S�o Jos� do Rio Claro')," +
                    "(5107354,51,'S�o Jos� do Xingu')," +
                    "(5107404,51,'S�o Pedro da Cipa')," +
                    "(5107578,51,'Rondol�ndia')," +
                    "(5107602,51,'Rondon�polis')," +
                    "(5107701,51,'Ros�rio Oeste')," +
                    "(5107743,51,'Santa Cruz do Xingu')," +
                    "(5107750,51,'Salto do C�u')," +
                    "(5107768,51,'Santa Rita do Trivelato')," +
                    "(5107776,51,'Santa Terezinha')," +
                    "(5107792,51,'Santo Ant�nio do Leste')," +
                    "(5107800,51,'Santo Ant�nio do Leverger')," +
                    "(5107859,51,'S�o F�lix do Araguaia')," +
                    "(5107875,51,'Sapezal')," +
                    "(5107883,51,'Serra Nova dourada')," +
                    "(5107909,51,'Sinop')," +
                    "(5107925,51,'Sorriso')," +
                    "(5107941,51,'Tabapor�')," +
                    "(5107958,51,'Tangar� da Serra')," +
                    "(5108006,51,'Tapurah')," +
                    "(5108055,51,'Terra Nova do Norte')," +
                    "(5108105,51,'Tesouro')," +
                    "(5108204,51,'Torixor�u')," +
                    "(5108303,51,'Uni�o do Sul')," +
                    "(5108352,51,'Vale de S�o domingos')," +
                    "(5108402,51,'V�rzea Grande')," +
                    "(5108501,51,'Vera')," +
                    "(5108600,51,'Vila Rica')," +
                    "(5108808,51,'Nova Guarita')," +
                    "(5108857,51,'Nova Maril�ndia')," +
                    "(5108907,51,'Nova Maring�')," +
                    "(5108956,51,'Nova Monte Verde')," +
                    "(5200050,52,'Abadia de Goi�s')," +
                    "(5200100,52,'Abadi�nia')," +
                    "(5200134,52,'Acre�na')," +
                    "(5200159,52,'Adel�ndia')," +
                    "(5200175,52,'�gua Fria de Goi�s')," +
                    "(5200209,52,'�gua Limpa')," +
                    "(5200258,52,'�guas Lindas de Goi�s')," +
                    "(5200308,52,'Alex�nia')," +
                    "(5200506,52,'Alo�ndia')," +
                    "(5200555,52,'Alto Horizonte')," +
                    "(5200605,52,'Alto Para�so de Goi�s')," +
                    "(5200803,52,'Alvorada do Norte')," +
                    "(5200829,52,'Amaralina')," +
                    "(5200852,52,'Americano do Brasil')," +
                    "(5200902,52,'Amorin�polis')," +
                    "(5201108,52,'An�polis')," +
                    "(5201207,52,'Anhanguera')," +
                    "(5201306,52,'Anicuns')," +
                    "(5201405,52,'Aparecida de Goi�nia')," +
                    "(5201454,52,'Aparecida do Rio doce')," +
                    "(5201504,52,'Apor�')," +
                    "(5201603,52,'Ara�u')," +
                    "(5201702,52,'Aragar�as')," +
                    "(5201801,52,'Aragoi�nia')," +
                    "(5202155,52,'Araguapaz')," +
                    "(5202353,52,'Aren�polis')," +
                    "(5202502,52,'Aruan�')," +
                    "(5202601,52,'Auril�ndia')," +
                    "(5202809,52,'Avelin�polis')," +
                    "(5203104,52,'Baliza')," +
                    "(5203203,52,'Barro Alto')," +
                    "(5203302,52,'Bela Vista de Goi�s')," +
                    "(5203401,52,'Bom Jardim de Goi�s')," +
                    "(5203500,52,'Bom Jesus de Goi�s')," +
                    "(5203559,52,'Bonfin�polis')," +
                    "(5203575,52,'Bon�polis')," +
                    "(5203609,52,'Brazabrantes')," +
                    "(5203807,52,'Brit�nia')," +
                    "(5203906,52,'Buriti Alegre')," +
                    "(5203939,52,'Buriti de Goi�s')," +
                    "(5203962,52,'Buritin�polis')," +
                    "(5204003,52,'Cabeceiras')," +
                    "(5204102,52,'Cachoeira Alta')," +
                    "(5204201,52,'Cachoeira de Goi�s')," +
                    "(5204250,52,'Cachoeira dourada')," +
                    "(5204300,52,'Ca�u')," +
                    "(5204409,52,'Caiap�nia')," +
                    "(5204508,52,'Caldas Novas')," +
                    "(5204557,52,'Caldazinha')," +
                    "(5204607,52,'Campestre de Goi�s')," +
                    "(5204656,52,'Campina�u')," +
                    "(5204706,52,'Campinorte')," +
                    "(5204805,52,'Campo Alegre de Goi�s')," +
                    "(5204854,52,'Campo Limpo de Goi�s')," +
                    "(5204904,52,'Campos Belos')," +
                    "(5204953,52,'Campos Verdes')," +
                    "(5205000,52,'Carmo do Rio Verde')," +
                    "(5205059,52,'Castel�ndia')," +
                    "(5205109,52,'Catal�o')," +
                    "(5205208,52,'Catura�')," +
                    "(5205307,52,'Cavalcante')," +
                    "(5205406,52,'Ceres')," +
                    "(5205455,52,'Cezarina')," +
                    "(5205471,52,'Chapad�o do C�u')," +
                    "(5205497,52,'Cidade Ocidental')," +
                    "(5205513,52,'Cocalzinho de Goi�s')," +
                    "(5205521,52,'Colinas do Sul')," +
                    "(5205703,52,'C�rrego do Ouro')," +
                    "(5205802,52,'Corumb� de Goi�s')," +
                    "(5205901,52,'Corumba�ba')," +
                    "(5206206,52,'Cristalina')," +
                    "(5206305,52,'Cristian�polis')," +
                    "(5206404,52,'Crix�s')," +
                    "(5206503,52,'Crom�nia')," +
                    "(5206602,52,'Cumari')," +
                    "(5206701,52,'damian�polis')," +
                    "(5206800,52,'damol�ndia')," +
                    "(5206909,52,'davin�polis')," +
                    "(5207105,52,'Diorama')," +
                    "(5207253,52,'doverl�ndia')," +
                    "(5207352,52,'Edealina')," +
                    "(5207402,52,'Ed�ia')," +
                    "(5207501,52,'Estrela do Norte')," +
                    "(5207535,52,'Faina')," +
                    "(5207600,52,'Fazenda Nova')," +
                    "(5207808,52,'Firmin�polis')," +
                    "(5207907,52,'Flores de Goi�s')," +
                    "(5208004,52,'Formosa')," +
                    "(5208103,52,'Formoso')," +
                    "(5208152,52,'Gameleira de Goi�s')," +
                    "(5208301,52,'Divin�polis de Goi�s')," +
                    "(5208400,52,'Goian�polis')," +
                    "(5208509,52,'Goiandira')," +
                    "(5208608,52,'Goian�sia')," +
                    "(5208707,52,'Goi�nia')," +
                    "(5208806,52,'Goianira')," +
                    "(5208905,52,'Goi�s')," +
                    "(5209101,52,'Goiatuba')," +
                    "(5209150,52,'Gouvel�ndia')," +
                    "(5209200,52,'Guap�')," +
                    "(5209291,52,'Guara�ta')," +
                    "(5209408,52,'Guarani de Goi�s')," +
                    "(5209457,52,'Guarinos')," +
                    "(5209606,52,'Heitora�')," +
                    "(5209705,52,'Hidrol�ndia')," +
                    "(5209804,52,'Hidrolina')," +
                    "(5209903,52,'Iaciara')," +
                    "(5209937,52,'Inaciol�ndia')," +
                    "(5209952,52,'Indiara')," +
                    "(5210000,52,'Inhumas')," +
                    "(5210109,52,'Ipameri')," +
                    "(5210158,52,'Ipiranga de Goi�s')," +
                    "(5210208,52,'Ipor�')," +
                    "(5210307,52,'Israel�ndia')," +
                    "(5210406,52,'Itabera�')," +
                    "(5210562,52,'Itaguari')," +
                    "(5210604,52,'Itaguaru')," +
                    "(5210802,52,'Itaj�')," +
                    "(5210901,52,'Itapaci')," +
                    "(5211008,52,'Itapirapu�')," +
                    "(5211206,52,'Itapuranga')," +
                    "(5211305,52,'Itarum�')," +
                    "(5211404,52,'Itau�u')," +
                    "(5211503,52,'Itumbiara')," +
                    "(5211602,52,'Ivol�ndia')," +
                    "(5211701,52,'Jandaia')," +
                    "(5211800,52,'Jaragu�')," +
                    "(5211909,52,'Jata�')," +
                    "(5212006,52,'Jaupaci')," +
                    "(5212055,52,'Jes�polis')," +
                    "(5212105,52,'Jovi�nia')," +
                    "(5212204,52,'Jussara')," +
                    "(5212253,52,'Lagoa Santa')," +
                    "(5212303,52,'Leopoldo de Bulh�es')," +
                    "(5212501,52,'Luzi�nia')," +
                    "(5212600,52,'Mairipotaba')," +
                    "(5212709,52,'Mamba�')," +
                    "(5212808,52,'Mara Rosa')," +
                    "(5212907,52,'Marzag�o')," +
                    "(5212956,52,'Matrinch�')," +
                    "(5213004,52,'Mauril�ndia')," +
                    "(5213053,52,'Mimoso de Goi�s')," +
                    "(5213087,52,'Mina�u')," +
                    "(5213103,52,'Mineiros')," +
                    "(5213400,52,'Moipor�')," +
                    "(5213509,52,'Monte Alegre de Goi�s')," +
                    "(5213707,52,'Montes Claros de Goi�s')," +
                    "(5213756,52,'Montividiu')," +
                    "(5213772,52,'Montividiu do Norte')," +
                    "(5213806,52,'Morrinhos')," +
                    "(5213855,52,'Morro Agudo de Goi�s')," +
                    "(5213905,52,'Moss�medes')," +
                    "(5214002,52,'Mozarl�ndia')," +
                    "(5214051,52,'Mundo Novo')," +
                    "(5214101,52,'Mutun�polis')," +
                    "(5214408,52,'Naz�rio')," +
                    "(5214507,52,'Ner�polis')," +
                    "(5214606,52,'Niquel�ndia')," +
                    "(5214705,52,'Nova Am�rica')," +
                    "(5214804,52,'Nova Aurora')," +
                    "(5214838,52,'Nova Crix�s')," +
                    "(5214861,52,'Nova Gl�ria')," +
                    "(5214879,52,'Nova Igua�u de Goi�s')," +
                    "(5214903,52,'Nova Roma')," +
                    "(5215009,52,'Nova Veneza')," +
                    "(5215207,52,'Novo Brasil')," +
                    "(5215231,52,'Novo Gama')," +
                    "(5215256,52,'Novo Planalto')," +
                    "(5215306,52,'Orizona')," +
                    "(5215405,52,'Ouro Verde de Goi�s')," +
                    "(5215504,52,'Ouvidor')," +
                    "(5215603,52,'Padre Bernardo')," +
                    "(5215652,52,'Palestina de Goi�s')," +
                    "(5215702,52,'Palmeiras de Goi�s')," +
                    "(5215801,52,'Palmelo')," +
                    "(5215900,52,'Palmin�polis')," +
                    "(5216007,52,'Panam�')," +
                    "(5216304,52,'Paranaiguara')," +
                    "(5216403,52,'Para�na')," +
                    "(5216452,52,'Perol�ndia')," +
                    "(5216809,52,'Petrolina de Goi�s')," +
                    "(5216908,52,'Pilar de Goi�s')," +
                    "(5217104,52,'Piracanjuba')," +
                    "(5217203,52,'Piranhas')," +
                    "(5217302,52,'Piren�polis')," +
                    "(5217401,52,'Pires do Rio')," +
                    "(5217609,52,'Planaltina')," +
                    "(5217708,52,'Pontalina')," +
                    "(5218003,52,'Porangatu')," +
                    "(5218052,52,'Porteir�o')," +
                    "(5218102,52,'Portel�ndia')," +
                    "(5218300,52,'Posse')," +
                    "(5218391,52,'Professor Jamil')," +
                    "(5218508,52,'Quirin�polis')," +
                    "(5218607,52,'Rialma')," +
                    "(5218706,52,'Rian�polis')," +
                    "(5218789,52,'Rio Quente')," +
                    "(5218805,52,'Rio Verde')," +
                    "(5218904,52,'Rubiataba')," +
                    "(5219001,52,'Sanclerl�ndia')," +
                    "(5219100,52,'Santa B�rbara de Goi�s')," +
                    "(5219209,52,'Santa Cruz de Goi�s')," +
                    "(5219258,52,'Santa F� de Goi�s')," +
                    "(5219308,52,'Santa Helena de Goi�s')," +
                    "(5219357,52,'Santa Isabel')," +
                    "(5219407,52,'Santa Rita do Araguaia')," +
                    "(5219456,52,'Santa Rita do Novo destino')," +
                    "(5219506,52,'Santa Rosa de Goi�s')," +
                    "(5219605,52,'Santa Tereza de Goi�s')," +
                    "(5219704,52,'Santa Terezinha de Goi�s')," +
                    "(5219712,52,'Santo Ant�nio da Barra')," +
                    "(5219738,52,'Santo Ant�nio de Goi�s')," +
                    "(5219753,52,'Santo Ant�nio do descoberto')," +
                    "(5219803,52,'S�o domingos')," +
                    "(5219902,52,'S�o Francisco de Goi�s')," +
                    "(5220009,52,'S�o Jo�o Dalian�a')," +
                    "(5220058,52,'S�o Jo�o da Para�na')," +
                    "(5220108,52,'S�o Lu�s de Montes Belos')," +
                    "(5220157,52,'S�o Lu�z do Norte')," +
                    "(5220207,52,'S�o Miguel do Araguaia')," +
                    "(5220264,52,'S�o Miguel do Passa Quatro')," +
                    "(5220280,52,'S�o Patr�cio')," +
                    "(5220405,52,'S�o Sim�o')," +
                    "(5220454,52,'Senador Canedo')," +
                    "(5220504,52,'Serran�polis')," +
                    "(5220603,52,'Silv�nia')," +
                    "(5220686,52,'Simol�ndia')," +
                    "(5220702,52,'S�tio Dabadia')," +
                    "(5221007,52,'Taquaral de Goi�s')," +
                    "(5221080,52,'Teresina de Goi�s')," +
                    "(5221197,52,'Terez�polis de Goi�s')," +
                    "(5221304,52,'Tr�s Ranchos')," +
                    "(5221403,52,'Trindade')," +
                    "(5221452,52,'Trombas')," +
                    "(5221502,52,'Turv�nia')," +
                    "(5221551,52,'Turvel�ndia')," +
                    "(5221577,52,'Uirapuru')," +
                    "(5221601,52,'Urua�u')," +
                    "(5221700,52,'Uruana')," +
                    "(5221809,52,'Uruta�')," +
                    "(5221858,52,'Valpara�so de Goi�s')," +
                    "(5221908,52,'Varj�o')," +
                    "(5222005,52,'Vian�polis')," +
                    "(5222054,52,'Vicentin�polis')," +
                    "(5222203,52,'Vila Boa')," +
                    "(5222302,52,'Vila Prop�cio')," +
                    "(5300108,53,'Bras�lia')";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
