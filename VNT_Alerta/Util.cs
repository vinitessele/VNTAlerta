﻿
using Microsoft.Toolkit.Uwp.Notifications;
using System.Net.Mail;

namespace VNT_CentralDeNotificacao
{
    public class Util
    {
        public static void NotificacaoWindow(DtoNotificacao notificacao)
        {
            new ToastContentBuilder()
         .AddArgument("conversationId", 9813)
         .AddText(notificacao.NomeEmpresa)
         .AddText(notificacao.Descricao)
         .Show(toast =>
         {
             toast.ExpirationTime = DateTime.Now.AddDays(1);
         });
        }
        public static void EnviaEmail(DtoNotificacao notificacao, DaoCfgNotificacao configuracao)
        {
            // Configurações do servidor SMTP
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "vntnotificacao@gmail.com";
            string smtpPassword = "sifw qwdn xbmc gebh";

            // Endereço de email do remetente
            string fromEmail = "vntnotificacao@gmail.com";

            // Endereço de email do destinatário
            string[] ToEmails = configuracao.emailTo.Split(';');
            foreach(var toEmail in ToEmails){
                // Criar objeto de mensagem
                MailMessage message = new MailMessage(fromEmail, toEmail);
                message.Subject = configuracao.emailSubject;
                message.Body = configuracao.emailBody + "</br>" + notificacao.NomeEmpresa + "</br> " + notificacao.Descricao + "</br> " + notificacao.DataNotificacao;

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
        public static string InsertEstado()
        {
            return "Insert into Estado (id, Nome, Uf, Regiao) values " +
                                        "(27, 'Alagoas', 'AL', 2)," +
                                        "(16, 'Amapá', 'AP', 1)," +
                                        "(13, 'Amazonas', 'AM', 1)," +
                                        "(29, 'Bahia', 'BA', 2)," +
                                        "(23, 'Ceará', 'CE', 2)," +
                                        "(53, 'Distrito Federal', 'DF', 5)," +
                                        "(32, 'Espírito Santo', 'ES', 3)," +
                                        "(52, 'Goiás', 'GO', 5)," +
                                        "(21, 'Maranhão', 'MA', 2)," +
                                        "(51, 'Mato Grosso', 'MT', 5)," +
                                        "(50, 'Mato Grosso do Sul', 'MS', 5)," +
                                        "(31, 'Minas Gerais', 'MG', 3)," +
                                        "(15, 'Pará', 'PA', 1)," +
                                        "(25, 'Paraíba', 'PB', 2)," +
                                        "(41, 'Paraná', 'PR', 4)," +
                                        "(26, 'Pernambuco', 'PE', 2)," +
                                        "(22, 'Piauí', 'PI', 2)," +
                                        "(33, 'Rio de Janeiro', 'RJ', 3)," +
                                        "(24, 'Rio Grande do Norte', 'RN', 2)," +
                                        "(43, 'Rio Grande do Sul', 'RS', 4)," +
                                        "(11, 'Rondônia', 'RO', 1)," +
                                        "(14, 'Roraima', 'RR', 1)," +
                                        "(42, 'Santa Catarina', 'SC', 4)," +
                                        "(35, 'São Paulo', 'SP', 3)," +
                                        "(28, 'Sergipe', 'SE', 2)," +
                                        "(17, 'Tocantins', 'TO', 1)";
        }

        public static string InsertCidades()
        {
            return "Insert into cidade (id, idestado, Nome) VALUES " +
                        "(1100015,11,'Alta Floresta Doeste')," +
                        "(1100023,11,'Ariquemes')," +
                        "(1100031,11,'Cabixi')," +
                        "(1100049,11,'Cacoal')," +
                        "(1100056,11,'Cerejeiras')," +
                        "(1100064,11,'Colorado do Oeste')," +
                        "(1100072,11,'Corumbiara')," +
                        "(1100080,11,'Costa Marques')," +
                        "(1100098,11,'Espigão Doeste')," +
                        "(1100106,11,'Guajará-Mirim')," +
                        "(1100114,11,'Jaru')," +
                        "(1100122,11,'Ji-Paraná')," +
                        "(1100130,11,'Machadinho Doeste')," +
                        "(1100148,11,'Nova Brasilândia Doeste')," +
                        "(1100155,11,'Ouro Preto do Oeste')," +
                        "(1100189,11,'Pimenta Bueno')," +
                        "(1100205,11,'Porto Velho')," +
                        "(1100254,11,'Presidente Médici')," +
                        "(1100262,11,'Rio Crespo')," +
                        "(1100288,11,'Rolim de Moura')," +
                        "(1100296,11,'Santa Luzia Doeste')," +
                        "(1100304,11,'Vilhena')," +
                        "(1100320,11,'São Miguel do Guaporé')," +
                        "(1100338,11,'Nova Mamoré')," +
                        "(1100346,11,'Alvorada Doeste')," +
                        "(1100379,11,'Alto Alegre dos Parecis')," +
                        "(1100403,11,'Alto Paraíso')," +
                        "(1100452,11,'Buritis')," +
                        "(1100502,11,'Novo Horizonte do Oeste')," +
                        "(1100601,11,'Cacaulândia')," +
                        "(1100700,11,'Campo Novo de Rondônia')," +
                        "(1100809,11,'Candeias do Jamari')," +
                        "(1100908,11,'Castanheiras')," +
                        "(1100924,11,'Chupinguaia')," +
                        "(1100940,11,'Cujubim')," +
                        "(1101005,11,'Governador Jorge Teixeira')," +
                        "(1101104,11,'Itapuã do Oeste')," +
                        "(1101203,11,'Ministro Andreazza')," +
                        "(1101302,11,'Mirante da Serra')," +
                        "(1101401,11,'Monte Negro')," +
                        "(1101435,11,'Nova União')," +
                        "(1101450,11,'Parecis')," +
                        "(1101468,11,'Pimenteiras do Oeste')," +
                        "(1101476,11,'Primavera de Rondônia')," +
                        "(1101484,11,'São Felipe Doeste')," +
                        "(1101492,11,'São Francisco do Guaporé')," +
                        "(1101500,11,'Seringueiras')," +
                        "(1101559,11,'Teixeirópolis')," +
                        "(1101609,11,'Theobroma')," +
                        "(1101708,11,'Urupá')," +
                        "(1101757,11,'Vale do Anari')," +
                        "(1101807,11,'Vale do Paraíso')," +
                        "(1200013,12,'Acrelândia')," +
                        "(1200054,12,'Assis Brasil')," +
                        "(1200104,12,'Brasiléia')," +
                        "(1200138,12,'Bujari')," +
                        "(1200179,12,'Capixaba')," +
                        "(1200203,12,'Cruzeiro do Sul')," +
                        "(1200252,12,'Epitaciolândia')," +
                        "(1200302,12,'Feijó')," +
                        "(1200328,12,'Jordão')," +
                        "(1200336,12,'Mâncio Lima')," +
                        "(1200344,12,'Manoel Urbano')," +
                        "(1200351,12,'Marechal Thaumaturgo')," +
                        "(1200385,12,'Plácido de Castro')," +
                        "(1200393,12,'Porto Walter')," +
                        "(1200401,12,'Rio Branco')," +
                        "(1200427,12,'Rodrigues Alves')," +
                        "(1200435,12,'Santa Rosa do Purus')," +
                        "(1200450,12,'Senador Guiomard')," +
                        "(1200500,12,'Sena Madureira')," +
                        "(1200609,12,'Tarauacá')," +
                        "(1200708,12,'Xapuri')," +
                        "(1200807,12,'Porto Acre')," +
                        "(1300029,13,'Alvarães')," +
                        "(1300060,13,'Amaturá')," +
                        "(1300086,13,'Anamã')," +
                        "(1300102,13,'Anori')," +
                        "(1300144,13,'Apuí')," +
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
                        "(1301159,13,'Careiro da Várzea')," +
                        "(1301209,13,'Coari')," +
                        "(1301308,13,'Codajás')," +
                        "(1301407,13,'Eirunepé')," +
                        "(1301506,13,'Envira')," +
                        "(1301605,13,'Fonte Boa')," +
                        "(1301654,13,'Guajará')," +
                        "(1301704,13,'Humaitá')," +
                        "(1301803,13,'Ipixuna')," +
                        "(1301852,13,'Iranduba')," +
                        "(1301902,13,'Itacoatiara')," +
                        "(1301951,13,'Itamarati')," +
                        "(1302009,13,'Itapiranga')," +
                        "(1302108,13,'Japurá')," +
                        "(1302207,13,'Juruá')," +
                        "(1302306,13,'Jutaí')," +
                        "(1302405,13,'Lábrea')," +
                        "(1302504,13,'Manacapuru')," +
                        "(1302553,13,'Manaquiri')," +
                        "(1302603,13,'Manaus')," +
                        "(1302702,13,'Manicoré')," +
                        "(1302801,13,'Maraã')," +
                        "(1302900,13,'Maués')," +
                        "(1303007,13,'Nhamundá')," +
                        "(1303106,13,'Nova Olinda do Norte')," +
                        "(1303205,13,'Novo Airão')," +
                        "(1303304,13,'Novo Aripuanã')," +
                        "(1303403,13,'Parintins')," +
                        "(1303502,13,'Pauini')," +
                        "(1303536,13,'Presidente Figueiredo')," +
                        "(1303569,13,'Rio Preto da Eva')," +
                        "(1303601,13,'Santa Isabel do Rio Negro')," +
                        "(1303700,13,'Santo Antônio do Içá')," +
                        "(1303809,13,'São Gabriel da Cachoeira')," +
                        "(1303908,13,'São Paulo de Olivença')," +
                        "(1303957,13,'São Sebastião do Uatumã')," +
                        "(1304005,13,'Silves')," +
                        "(1304062,13,'Tabatinga')," +
                        "(1304104,13,'Tapauá')," +
                        "(1304203,13,'Tefé')," +
                        "(1304237,13,'Tonantins')," +
                        "(1304260,13,'Uarini')," +
                        "(1304302,13,'Urucará')," +
                        "(1304401,13,'Urucurituba')," +
                        "(1400027,14,'Amajari')," +
                        "(1400050,14,'Alto Alegre')," +
                        "(1400100,14,'Boa Vista')," +
                        "(1400159,14,'Bonfim')," +
                        "(1400175,14,'Cantá')," +
                        "(1400209,14,'Caracaraí')," +
                        "(1400233,14,'Caroebe')," +
                        "(1400282,14,'Iracema')," +
                        "(1400308,14,'Mucajaí')," +
                        "(1400407,14,'Normandia')," +
                        "(1400456,14,'Pacaraima')," +
                        "(1400472,14,'Rorainópolis')," +
                        "(1400506,14,'São João da Baliza')," +
                        "(1400605,14,'São Luiz')," +
                        "(1400704,14,'Uiramutã')," +
                        "(1500107,15,'Abaetetuba')," +
                        "(1500131,15,'Abel Figueiredo')," +
                        "(1500206,15,'Acará')," +
                        "(1500305,15,'Afuá')," +
                        "(1500347,15,'Água Azul do Norte')," +
                        "(1500404,15,'Alenquer')," +
                        "(1500503,15,'Almeirim')," +
                        "(1500602,15,'Altamira')," +
                        "(1500701,15,'Anajás')," +
                        "(1500800,15,'Ananindeua')," +
                        "(1500859,15,'Anapu')," +
                        "(1500909,15,'Augusto Corrêa')," +
                        "(1500958,15,'Aurora do Pará')," +
                        "(1501006,15,'Aveiro')," +
                        "(1501105,15,'Bagre')," +
                        "(1501204,15,'Baião')," +
                        "(1501253,15,'Bannach')," +
                        "(1501303,15,'Barcarena')," +
                        "(1501402,15,'Belém')," +
                        "(1501451,15,'Belterra')," +
                        "(1501501,15,'Benevides')," +
                        "(1501576,15,'Bom Jesus do Tocantins')," +
                        "(1501600,15,'Bonito')," +
                        "(1501709,15,'Bragança')," +
                        "(1501725,15,'Brasil Novo')," +
                        "(1501758,15,'Brejo Grande do Araguaia')," +
                        "(1501782,15,'Breu Branco')," +
                        "(1501808,15,'Breves')," +
                        "(1501907,15,'Bujaru')," +
                        "(1501956,15,'Cachoeira do Piriá')," +
                        "(1502004,15,'Cachoeira do Arari')," +
                        "(1502103,15,'Cametá')," +
                        "(1502152,15,'Canaã dos Carajás')," +
                        "(1502202,15,'Capanema')," +
                        "(1502301,15,'Capitão Poço')," +
                        "(1502400,15,'Castanhal')," +
                        "(1502509,15,'Chaves')," +
                        "(1502608,15,'Colares')," +
                        "(1502707,15,'Conceição do Araguaia')," +
                        "(1502756,15,'Concórdia do Pará')," +
                        "(1502764,15,'Cumaru do Norte')," +
                        "(1502772,15,'Curionópolis')," +
                        "(1502806,15,'Curralinho')," +
                        "(1502855,15,'Curuá')," +
                        "(1502905,15,'Curuçá')," +
                        "(1502939,15,'dom Eliseu')," +
                        "(1502954,15,'Eldorado do Carajás')," +
                        "(1503002,15,'Faro')," +
                        "(1503044,15,'Floresta do Araguaia')," +
                        "(1503077,15,'Garrafão do Norte')," +
                        "(1503093,15,'Goianésia do Pará')," +
                        "(1503101,15,'Gurupá')," +
                        "(1503200,15,'Igarapé-Açu')," +
                        "(1503309,15,'Igarapé-Miri')," +
                        "(1503408,15,'Inhangapi')," +
                        "(1503457,15,'Ipixuna do Pará')," +
                        "(1503507,15,'Irituia')," +
                        "(1503606,15,'Itaituba')," +
                        "(1503705,15,'Itupiranga')," +
                        "(1503754,15,'Jacareacanga')," +
                        "(1503804,15,'Jacundá')," +
                        "(1503903,15,'Juruti')," +
                        "(1504000,15,'Limoeiro do Ajuru')," +
                        "(1504059,15,'Mãe do Rio')," +
                        "(1504109,15,'Magalhães Barata')," +
                        "(1504208,15,'Marabá')," +
                        "(1504307,15,'Maracanã')," +
                        "(1504406,15,'Marapanim')," +
                        "(1504422,15,'Marituba')," +
                        "(1504455,15,'Medicilândia')," +
                        "(1504505,15,'Melgaço')," +
                        "(1504604,15,'Mocajuba')," +
                        "(1504703,15,'Moju')," +
                        "(1504752,15,'Mojuí dos Campos')," +
                        "(1504802,15,'Monte Alegre')," +
                        "(1504901,15,'Muaná')," +
                        "(1504950,15,'Nova Esperança do Piriá')," +
                        "(1504976,15,'Nova Ipixuna')," +
                        "(1505007,15,'Nova Timboteua')," +
                        "(1505031,15,'Novo Progresso')," +
                        "(1505064,15,'Novo Repartimento')," +
                        "(1505106,15,'Óbidos')," +
                        "(1505205,15,'Oeiras do Pará')," +
                        "(1505304,15,'Oriximiná')," +
                        "(1505403,15,'Ourém')," +
                        "(1505437,15,'Ourilândia do Norte')," +
                        "(1505486,15,'Pacajá')," +
                        "(1505494,15,'Palestina do Pará')," +
                        "(1505502,15,'Paragominas')," +
                        "(1505536,15,'Parauapebas')," +
                        "(1505551,15,'Pau Darco')," +
                        "(1505601,15,'Peixe-Boi')," +
                        "(1505635,15,'Piçarra')," +
                        "(1505650,15,'Placas')," +
                        "(1505700,15,'Ponta de Pedras')," +
                        "(1505809,15,'Portel')," +
                        "(1505908,15,'Porto de Moz')," +
                        "(1506005,15,'Prainha')," +
                        "(1506104,15,'Primavera')," +
                        "(1506112,15,'Quatipuru')," +
                        "(1506138,15,'Redenção')," +
                        "(1506161,15,'Rio Maria')," +
                        "(1506187,15,'Rondon do Pará')," +
                        "(1506195,15,'Rurópolis')," +
                        "(1506203,15,'Salinópolis')," +
                        "(1506302,15,'Salvaterra')," +
                        "(1506351,15,'Santa Bárbara do Pará')," +
                        "(1506401,15,'Santa Cruz do Arari')," +
                        "(1506500,15,'Santa Izabel do Pará')," +
                        "(1506559,15,'Santa Luzia do Pará')," +
                        "(1506583,15,'Santa Maria das Barreiras')," +
                        "(1506609,15,'Santa Maria do Pará')," +
                        "(1506708,15,'Santana do Araguaia')," +
                        "(1506807,15,'Santarém')," +
                        "(1506906,15,'Santarém Novo')," +
                        "(1507003,15,'Santo Antônio do Tauá')," +
                        "(1507102,15,'São Caetano de Odivelas')," +
                        "(1507151,15,'São domingos do Araguaia')," +
                        "(1507201,15,'São domingos do Capim')," +
                        "(1507300,15,'São Félix do Xingu')," +
                        "(1507409,15,'São Francisco do Pará')," +
                        "(1507458,15,'São Geraldo do Araguaia')," +
                        "(1507466,15,'São João da Ponta')," +
                        "(1507474,15,'São João de Pirabas')," +
                        "(1507508,15,'São João do Araguaia')," +
                        "(1507607,15,'São Miguel do Guamá')," +
                        "(1507706,15,'São Sebastião da Boa Vista')," +
                        "(1507755,15,'Sapucaia')," +
                        "(1507805,15,'Senador José Porfírio')," +
                        "(1507904,15,'Soure')," +
                        "(1507953,15,'Tailândia')," +
                        "(1507961,15,'Terra Alta')," +
                        "(1507979,15,'Terra Santa')," +
                        "(1508001,15,'Tomé-Açu')," +
                        "(1508035,15,'Tracuateua')," +
                        "(1508050,15,'Trairão')," +
                        "(1508084,15,'Tucumã')," +
                        "(1508100,15,'Tucuruí')," +
                        "(1508126,15,'Ulianópolis')," +
                        "(1508159,15,'Uruará')," +
                        "(1508209,15,'Vigia')," +
                        "(1508308,15,'Viseu')," +
                        "(1508357,15,'Vitória do Xingu')," +
                        "(1508407,15,'Xinguara')," +
                        "(1600055,16,'Serra do Navio')," +
                        "(1600105,16,'Amapá')," +
                        "(1600154,16,'Pedra Branca do Amapari')," +
                        "(1600204,16,'Calçoene')," +
                        "(1600212,16,'Cutias')," +
                        "(1600238,16,'Ferreira Gomes')," +
                        "(1600253,16,'Itaubal')," +
                        "(1600279,16,'Laranjal do Jari')," +
                        "(1600303,16,'Macapá')," +
                        "(1600402,16,'Mazagão')," +
                        "(1600501,16,'Oiapoque')," +
                        "(1600535,16,'Porto Grande')," +
                        "(1600550,16,'Pracuúba')," +
                        "(1600600,16,'Santana')," +
                        "(1600709,16,'Tartarugalzinho')," +
                        "(1600808,16,'Vitória do Jari')," +
                        "(1700251,17,'Abreulândia')," +
                        "(1700301,17,'Aguiarnópolis')," +
                        "(1700350,17,'Aliança do Tocantins')," +
                        "(1700400,17,'Almas')," +
                        "(1700707,17,'Alvorada')," +
                        "(1701002,17,'Ananás')," +
                        "(1701051,17,'Angico')," +
                        "(1701101,17,'Aparecida do Rio Negro')," +
                        "(1701309,17,'Aragominas')," +
                        "(1701903,17,'Araguacema')," +
                        "(1702000,17,'Araguaçu')," +
                        "(1702109,17,'Araguaína')," +
                        "(1702158,17,'Araguanã')," +
                        "(1702208,17,'Araguatins')," +
                        "(1702307,17,'Arapoema')," +
                        "(1702406,17,'Arraias')," +
                        "(1702554,17,'Augustinópolis')," +
                        "(1702703,17,'Aurora do Tocantins')," +
                        "(1702901,17,'Axixá do Tocantins')," +
                        "(1703008,17,'Babaçulândia')," +
                        "(1703057,17,'Bandeirantes do Tocantins')," +
                        "(1703073,17,'Barra do Ouro')," +
                        "(1703107,17,'Barrolândia')," +
                        "(1703206,17,'Bernardo Sayão')," +
                        "(1703305,17,'Bom Jesus do Tocantins')," +
                        "(1703602,17,'Brasilândia do Tocantins')," +
                        "(1703701,17,'Brejinho de Nazaré')," +
                        "(1703800,17,'Buriti do Tocantins')," +
                        "(1703826,17,'Cachoeirinha')," +
                        "(1703842,17,'Campos Lindos')," +
                        "(1703867,17,'Cariri do Tocantins')," +
                        "(1703883,17,'Carmolândia')," +
                        "(1703891,17,'Carrasco Bonito')," +
                        "(1703909,17,'Caseara')," +
                        "(1704105,17,'Centenário')," +
                        "(1704600,17,'Chapada de Areia')," +
                        "(1705102,17,'Chapada da Natividade')," +
                        "(1705508,17,'Colinas do Tocantins')," +
                        "(1705557,17,'Combinado')," +
                        "(1705607,17,'Conceição do Tocantins')," +
                        "(1706001,17,'Couto Magalhães')," +
                        "(1706100,17,'Cristalândia')," +
                        "(1706258,17,'Crixás do Tocantins')," +
                        "(1706506,17,'darcinópolis')," +
                        "(1707009,17,'Dianópolis')," +
                        "(1707108,17,'Divinópolis do Tocantins')," +
                        "(1707207,17,'dois Irmãos do Tocantins')," +
                        "(1707306,17,'Dueré')," +
                        "(1707405,17,'Esperantina')," +
                        "(1707553,17,'Fátima')," +
                        "(1707652,17,'Figueirópolis')," +
                        "(1707702,17,'Filadélfia')," +
                        "(1708205,17,'Formoso do Araguaia')," +
                        "(1708254,17,'Fortaleza do Tabocão')," +
                        "(1708304,17,'Goianorte')," +
                        "(1709005,17,'Goiatins')," +
                        "(1709302,17,'Guaraí')," +
                        "(1709500,17,'Gurupi')," +
                        "(1709807,17,'Ipueiras')," +
                        "(1710508,17,'Itacajá')," +
                        "(1710706,17,'Itaguatins')," +
                        "(1710904,17,'Itapiratins')," +
                        "(1711100,17,'Itaporã do Tocantins')," +
                        "(1711506,17,'Jaú do Tocantins')," +
                        "(1711803,17,'Juarina')," +
                        "(1711902,17,'Lagoa da Confusão')," +
                        "(1711951,17,'Lagoa do Tocantins')," +
                        "(1712009,17,'Lajeado')," +
                        "(1712157,17,'Lavandeira')," +
                        "(1712405,17,'Lizarda')," +
                        "(1712454,17,'Luzinópolis')," +
                        "(1712504,17,'Marianópolis do Tocantins')," +
                        "(1712702,17,'Mateiros')," +
                        "(1712801,17,'Maurilândia do Tocantins')," +
                        "(1713205,17,'Miracema do Tocantins')," +
                        "(1713304,17,'Miranorte')," +
                        "(1713601,17,'Monte do Carmo')," +
                        "(1713700,17,'Monte Santo do Tocantins')," +
                        "(1713809,17,'Palmeiras do Tocantins')," +
                        "(1713957,17,'Muricilândia')," +
                        "(1714203,17,'Natividade')," +
                        "(1714302,17,'Nazaré')," +
                        "(1714880,17,'Nova Olinda')," +
                        "(1715002,17,'Nova Rosalândia')," +
                        "(1715101,17,'Novo Acordo')," +
                        "(1715150,17,'Novo Alegre')," +
                        "(1715259,17,'Novo Jardim')," +
                        "(1715507,17,'Oliveira de Fátima')," +
                        "(1715705,17,'Palmeirante')," +
                        "(1715754,17,'Palmeirópolis')," +
                        "(1716109,17,'Paraíso do Tocantins')," +
                        "(1716208,17,'Paranã')," +
                        "(1716307,17,'Pau Darco')," +
                        "(1716505,17,'Pedro Afonso')," +
                        "(1716604,17,'Peixe')," +
                        "(1716653,17,'Pequizeiro')," +
                        "(1716703,17,'Colméia')," +
                        "(1717008,17,'Pindorama do Tocantins')," +
                        "(1717206,17,'Piraquê')," +
                        "(1717503,17,'Pium')," +
                        "(1717800,17,'Ponte Alta do Bom Jesus')," +
                        "(1717909,17,'Ponte Alta do Tocantins')," +
                        "(1718006,17,'Porto Alegre do Tocantins')," +
                        "(1718204,17,'Porto Nacional')," +
                        "(1718303,17,'Praia Norte')," +
                        "(1718402,17,'Presidente Kennedy')," +
                        "(1718451,17,'Pugmil')," +
                        "(1718501,17,'Recursolândia')," +
                        "(1718550,17,'Riachinho')," +
                        "(1718659,17,'Rio da Conceição')," +
                        "(1718709,17,'Rio dos Bois')," +
                        "(1718758,17,'Rio Sono')," +
                        "(1718808,17,'Sampaio')," +
                        "(1718840,17,'Sandolândia')," +
                        "(1718865,17,'Santa Fé do Araguaia')," +
                        "(1718881,17,'Santa Maria do Tocantins')," +
                        "(1718899,17,'Santa Rita do Tocantins')," +
                        "(1718907,17,'Santa Rosa do Tocantins')," +
                        "(1719004,17,'Santa Tereza do Tocantins')," +
                        "(1720002,17,'Santa Terezinha do Tocantins')," +
                        "(1720101,17,'São Bento do Tocantins')," +
                        "(1720150,17,'São Félix do Tocantins')," +
                        "(1720200,17,'São Miguel do Tocantins')," +
                        "(1720259,17,'São Salvador do Tocantins')," +
                        "(1720309,17,'São Sebastião do Tocantins')," +
                        "(1720499,17,'São Valério')," +
                        "(1720655,17,'Silvanópolis')," +
                        "(1720804,17,'Sítio Novo do Tocantins')," +
                        "(1720853,17,'Sucupira')," +
                        "(1720903,17,'Taguatinga')," +
                        "(1720937,17,'Taipas do Tocantins')," +
                        "(1720978,17,'Talismã')," +
                        "(1721000,17,'Palmas')," +
                        "(1721109,17,'Tocantínia')," +
                        "(1721208,17,'Tocantinópolis')," +
                        "(1721257,17,'Tupirama')," +
                        "(1721307,17,'Tupiratins')," +
                        "(1722081,17,'Wanderlândia')," +
                        "(1722107,17,'Xambioá')," +
                        "(2100055,21,'Açailândia')," +
                        "(2100105,21,'Afonso Cunha')," +
                        "(2100154,21,'Água doce do Maranhão')," +
                        "(2100204,21,'Alcântara')," +
                        "(2100303,21,'Aldeias Altas')," +
                        "(2100402,21,'Altamira do Maranhão')," +
                        "(2100436,21,'Alto Alegre do Maranhão')," +
                        "(2100477,21,'Alto Alegre do Pindaré')," +
                        "(2100501,21,'Alto Parnaíba')," +
                        "(2100550,21,'Amapá do Maranhão')," +
                        "(2100600,21,'Amarante do Maranhão')," +
                        "(2100709,21,'Anajatuba')," +
                        "(2100808,21,'Anapurus')," +
                        "(2100832,21,'Apicum-Açu')," +
                        "(2100873,21,'Araguanã')," +
                        "(2100907,21,'Araioses')," +
                        "(2100956,21,'Arame')," +
                        "(2101004,21,'Arari')," +
                        "(2101103,21,'Axixá')," +
                        "(2101202,21,'Bacabal')," +
                        "(2101251,21,'Bacabeira')," +
                        "(2101301,21,'Bacuri')," +
                        "(2101350,21,'Bacurituba')," +
                        "(2101400,21,'Balsas')," +
                        "(2101509,21,'Barão de Grajaú')," +
                        "(2101608,21,'Barra do Corda')," +
                        "(2101707,21,'Barreirinhas')," +
                        "(2101731,21,'Belágua')," +
                        "(2101772,21,'Bela Vista do Maranhão')," +
                        "(2101806,21,'Benedito Leite')," +
                        "(2101905,21,'Bequimão')," +
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
                        "(2102408,21,'Cajapió')," +
                        "(2102507,21,'Cajari')," +
                        "(2102556,21,'Campestre do Maranhão')," +
                        "(2102606,21,'Cândido Mendes')," +
                        "(2102705,21,'Cantanhede')," +
                        "(2102754,21,'Capinzal do Norte')," +
                        "(2102804,21,'Carolina')," +
                        "(2102903,21,'Carutapera')," +
                        "(2103000,21,'Caxias')," +
                        "(2103109,21,'Cedral')," +
                        "(2103125,21,'Central do Maranhão')," +
                        "(2103158,21,'Centro do Guilherme')," +
                        "(2103174,21,'Centro Novo do Maranhão')," +
                        "(2103208,21,'Chapadinha')," +
                        "(2103257,21,'Cidelândia')," +
                        "(2103307,21,'Codó')," +
                        "(2103406,21,'Coelho Neto')," +
                        "(2103505,21,'Colinas')," +
                        "(2103554,21,'Conceição do Lago-Açu')," +
                        "(2103604,21,'Coroatá')," +
                        "(2103703,21,'Cururupu')," +
                        "(2103752,21,'davinópolis')," +
                        "(2103802,21,'dom Pedro')," +
                        "(2103901,21,'Duque Bacelar')," +
                        "(2104008,21,'Esperantinópolis')," +
                        "(2104057,21,'Estreito')," +
                        "(2104073,21,'Feira Nova do Maranhão')," +
                        "(2104081,21,'Fernando Falcão')," +
                        "(2104099,21,'Formosa da Serra Negra')," +
                        "(2104107,21,'Fortaleza dos Nogueiras')," +
                        "(2104206,21,'Fortuna')," +
                        "(2104305,21,'Godofredo Viana')," +
                        "(2104404,21,'Gonçalves Dias')," +
                        "(2104503,21,'Governador Archer')," +
                        "(2104552,21,'Governador Edison Lobão')," +
                        "(2104602,21,'Governador Eugênio Barros')," +
                        "(2104628,21,'Governador Luiz Rocha')," +
                        "(2104651,21,'Governador Newton Bello')," +
                        "(2104677,21,'Governador Nunes Freire')," +
                        "(2104701,21,'Graça Aranha')," +
                        "(2104800,21,'Grajaú')," +
                        "(2104909,21,'Guimarães')," +
                        "(2105005,21,'Humberto de Campos')," +
                        "(2105104,21,'Icatu')," +
                        "(2105153,21,'Igarapé do Meio')," +
                        "(2105203,21,'Igarapé Grande')," +
                        "(2105302,21,'Imperatriz')," +
                        "(2105351,21,'Itaipava do Grajaú')," +
                        "(2105401,21,'Itapecuru Mirim')," +
                        "(2105427,21,'Itinga do Maranhão')," +
                        "(2105450,21,'Jatobá')," +
                        "(2105476,21,'Jenipapo dos Vieiras')," +
                        "(2105500,21,'João Lisboa')," +
                        "(2105609,21,'Joselândia')," +
                        "(2105658,21,'Junco do Maranhão')," +
                        "(2105708,21,'Lago da Pedra')," +
                        "(2105807,21,'Lago do Junco')," +
                        "(2105906,21,'Lago Verde')," +
                        "(2105922,21,'Lagoa do Mato')," +
                        "(2105948,21,'Lago dos Rodrigues')," +
                        "(2105963,21,'Lagoa Grande do Maranhão')," +
                        "(2105989,21,'Lajeado Novo')," +
                        "(2106003,21,'Lima Campos')," +
                        "(2106102,21,'Loreto')," +
                        "(2106201,21,'Luís domingues')," +
                        "(2106300,21,'Magalhães de Almeida')," +
                        "(2106326,21,'Maracaçumé')," +
                        "(2106359,21,'Marajá do Sena')," +
                        "(2106375,21,'Maranhãozinho')," +
                        "(2106409,21,'Mata Roma')," +
                        "(2106508,21,'Matinha')," +
                        "(2106607,21,'Matões')," +
                        "(2106631,21,'Matões do Norte')," +
                        "(2106672,21,'Milagres do Maranhão')," +
                        "(2106706,21,'Mirador')," +
                        "(2106755,21,'Miranda do Norte')," +
                        "(2106805,21,'Mirinzal')," +
                        "(2106904,21,'Monção')," +
                        "(2107001,21,'Montes Altos')," +
                        "(2107100,21,'Morros')," +
                        "(2107209,21,'Nina Rodrigues')," +
                        "(2107258,21,'Nova Colinas')," +
                        "(2107308,21,'Nova Iorque')," +
                        "(2107357,21,'Nova Olinda do Maranhão')," +
                        "(2107407,21,'Olho Dágua das Cunhãs')," +
                        "(2107456,21,'Olinda Nova do Maranhão')," +
                        "(2107506,21,'Paço do Lumiar')," +
                        "(2107605,21,'Palmeirândia')," +
                        "(2107704,21,'Paraibano')," +
                        "(2107803,21,'Parnarama')," +
                        "(2107902,21,'Passagem Franca')," +
                        "(2108009,21,'Pastos Bons')," +
                        "(2108058,21,'Paulino Neves')," +
                        "(2108108,21,'Paulo Ramos')," +
                        "(2108207,21,'Pedreiras')," +
                        "(2108256,21,'Pedro do Rosário')," +
                        "(2108306,21,'Penalva')," +
                        "(2108405,21,'Peri Mirim')," +
                        "(2108454,21,'Peritoró')," +
                        "(2108504,21,'Pindaré-Mirim')," +
                        "(2108603,21,'Pinheiro')," +
                        "(2108702,21,'Pio Xii')," +
                        "(2108801,21,'Pirapemas')," +
                        "(2108900,21,'Poção de Pedras')," +
                        "(2109007,21,'Porto Franco')," +
                        "(2109056,21,'Porto Rico do Maranhão')," +
                        "(2109106,21,'Presidente Dutra')," +
                        "(2109205,21,'Presidente Juscelino')," +
                        "(2109239,21,'Presidente Médici')," +
                        "(2109270,21,'Presidente Sarney')," +
                        "(2109304,21,'Presidente Vargas')," +
                        "(2109403,21,'Primeira Cruz')," +
                        "(2109452,21,'Raposa')," +
                        "(2109502,21,'Riachão')," +
                        "(2109551,21,'Ribamar Fiquene')," +
                        "(2109601,21,'Rosário')," +
                        "(2109700,21,'Sambaíba')," +
                        "(2109759,21,'Santa Filomena do Maranhão')," +
                        "(2109809,21,'Santa Helena')," +
                        "(2109908,21,'Santa Inês')," +
                        "(2110005,21,'Santa Luzia')," +
                        "(2110039,21,'Santa Luzia do Paruá')," +
                        "(2110104,21,'Santa Quitéria do Maranhão')," +
                        "(2110203,21,'Santa Rita')," +
                        "(2110237,21,'Santana do Maranhão')," +
                        "(2110278,21,'Santo Amaro do Maranhão')," +
                        "(2110302,21,'Santo Antônio dos Lopes')," +
                        "(2110401,21,'São Benedito do Rio Preto')," +
                        "(2110500,21,'São Bento')," +
                        "(2110609,21,'São Bernardo')," +
                        "(2110658,21,'São domingos do Azeitão')," +
                        "(2110708,21,'São domingos do Maranhão')," +
                        "(2110807,21,'São Félix de Balsas')," +
                        "(2110856,21,'São Francisco do Brejão')," +
                        "(2110906,21,'São Francisco do Maranhão')," +
                        "(2111003,21,'São João Batista')," +
                        "(2111029,21,'São João do Carú')," +
                        "(2111052,21,'São João do Paraíso')," +
                        "(2111078,21,'São João do Soter')," +
                        "(2111102,21,'São João dos Patos')," +
                        "(2111201,21,'São José de Ribamar')," +
                        "(2111250,21,'São José dos Basílios')," +
                        "(2111300,21,'São Luís')," +
                        "(2111409,21,'São Luís Gonzaga do Maranhão')," +
                        "(2111508,21,'São Mateus do Maranhão')," +
                        "(2111532,21,'São Pedro da Água Branca')," +
                        "(2111573,21,'São Pedro dos Crentes')," +
                        "(2111607,21,'São Raimundo das Mangabeiras')," +
                        "(2111631,21,'São Raimundo do doca Bezerra')," +
                        "(2111672,21,'São Roberto')," +
                        "(2111706,21,'São Vicente Ferrer')," +
                        "(2111722,21,'Satubinha')," +
                        "(2111748,21,'Senador Alexandre Costa')," +
                        "(2111763,21,'Senador La Rocque')," +
                        "(2111789,21,'Serrano do Maranhão')," +
                        "(2111805,21,'Sítio Novo')," +
                        "(2111904,21,'Sucupira do Norte')," +
                        "(2111953,21,'Sucupira do Riachão')," +
                        "(2112001,21,'Tasso Fragoso')," +
                        "(2112100,21,'Timbiras')," +
                        "(2112209,21,'Timon')," +
                        "(2112233,21,'Trizidela do Vale')," +
                        "(2112274,21,'Tufilândia')," +
                        "(2112308,21,'Tuntum')," +
                        "(2112407,21,'Turiaçu')," +
                        "(2112456,21,'Turilândia')," +
                        "(2112506,21,'Tutóia')," +
                        "(2112605,21,'Urbano Santos')," +
                        "(2112704,21,'Vargem Grande')," +
                        "(2112803,21,'Viana')," +
                        "(2112852,21,'Vila Nova dos Martírios')," +
                        "(2112902,21,'Vitória do Mearim')," +
                        "(2113009,21,'Vitorino Freire')," +
                        "(2114007,21,'Zé doca')," +
                        "(2200053,22,'Acauã')," +
                        "(2200103,22,'Agricolândia')," +
                        "(2200202,22,'Água Branca')," +
                        "(2200251,22,'Alagoinha do Piauí')," +
                        "(2200277,22,'Alegrete do Piauí')," +
                        "(2200301,22,'Alto Longá')," +
                        "(2200400,22,'Altos')," +
                        "(2200459,22,'Alvorada do Gurguéia')," +
                        "(2200509,22,'Amarante')," +
                        "(2200608,22,'Angical do Piauí')," +
                        "(2200707,22,'Anísio de Abreu')," +
                        "(2200806,22,'Antônio Almeida')," +
                        "(2200905,22,'Aroazes')," +
                        "(2200954,22,'Aroeiras do Itaim')," +
                        "(2201002,22,'Arraial')," +
                        "(2201051,22,'Assunção do Piauí')," +
                        "(2201101,22,'Avelino Lopes')," +
                        "(2201150,22,'Baixa Grande do Ribeiro')," +
                        "(2201176,22,'Barra Dalcântara')," +
                        "(2201200,22,'Barras')," +
                        "(2201309,22,'Barreiras do Piauí')," +
                        "(2201408,22,'Barro Duro')," +
                        "(2201507,22,'Batalha')," +
                        "(2201556,22,'Bela Vista do Piauí')," +
                        "(2201572,22,'Belém do Piauí')," +
                        "(2201606,22,'Beneditinos')," +
                        "(2201705,22,'Bertolínia')," +
                        "(2201739,22,'Betânia do Piauí')," +
                        "(2201770,22,'Boa Hora')," +
                        "(2201804,22,'Bocaina')," +
                        "(2201903,22,'Bom Jesus')," +
                        "(2201919,22,'Bom Princípio do Piauí')," +
                        "(2201929,22,'Bonfim do Piauí')," +
                        "(2201945,22,'Boqueirão do Piauí')," +
                        "(2201960,22,'Brasileira')," +
                        "(2201988,22,'Brejo do Piauí')," +
                        "(2202000,22,'Buriti dos Lopes')," +
                        "(2202026,22,'Buriti dos Montes')," +
                        "(2202059,22,'Cabeceiras do Piauí')," +
                        "(2202075,22,'Cajazeiras do Piauí')," +
                        "(2202083,22,'Cajueiro da Praia')," +
                        "(2202091,22,'Caldeirão Grande do Piauí')," +
                        "(2202109,22,'Campinas do Piauí')," +
                        "(2202117,22,'Campo Alegre do Fidalgo')," +
                        "(2202133,22,'Campo Grande do Piauí')," +
                        "(2202174,22,'Campo Largo do Piauí')," +
                        "(2202208,22,'Campo Maior')," +
                        "(2202251,22,'Canavieira')," +
                        "(2202307,22,'Canto do Buriti')," +
                        "(2202406,22,'Capitão de Campos')," +
                        "(2202455,22,'Capitão Gervásio Oliveira')," +
                        "(2202505,22,'Caracol')," +
                        "(2202539,22,'Caraúbas do Piauí')," +
                        "(2202554,22,'Caridade do Piauí')," +
                        "(2202604,22,'Castelo do Piauí')," +
                        "(2202653,22,'Caxingó')," +
                        "(2202703,22,'Cocal')," +
                        "(2202711,22,'Cocal de Telha')," +
                        "(2202729,22,'Cocal dos Alves')," +
                        "(2202737,22,'Coivaras')," +
                        "(2202752,22,'Colônia do Gurguéia')," +
                        "(2202778,22,'Colônia do Piauí')," +
                        "(2202802,22,'Conceição do Canindé')," +
                        "(2202851,22,'Coronel José Dias')," +
                        "(2202901,22,'Corrente')," +
                        "(2203008,22,'Cristalândia do Piauí')," +
                        "(2203107,22,'Cristino Castro')," +
                        "(2203206,22,'Curimatá')," +
                        "(2203230,22,'Currais')," +
                        "(2203255,22,'Curralinhos')," +
                        "(2203271,22,'Curral Novo do Piauí')," +
                        "(2203305,22,'demerval Lobão')," +
                        "(2203354,22,'Dirceu Arcoverde')," +
                        "(2203404,22,'dom Expedito Lopes')," +
                        "(2203420,22,'domingos Mourão')," +
                        "(2203453,22,'dom Inocêncio')," +
                        "(2203503,22,'Elesbão Veloso')," +
                        "(2203602,22,'Eliseu Martins')," +
                        "(2203701,22,'Esperantina')," +
                        "(2203750,22,'Fartura do Piauí')," +
                        "(2203800,22,'Flores do Piauí')," +
                        "(2203859,22,'Floresta do Piauí')," +
                        "(2203909,22,'Floriano')," +
                        "(2204006,22,'Francinópolis')," +
                        "(2204105,22,'Francisco Ayres')," +
                        "(2204154,22,'Francisco Macedo')," +
                        "(2204204,22,'Francisco Santos')," +
                        "(2204303,22,'Fronteiras')," +
                        "(2204352,22,'Geminiano')," +
                        "(2204402,22,'Gilbués')," +
                        "(2204501,22,'Guadalupe')," +
                        "(2204550,22,'Guaribas')," +
                        "(2204600,22,'Hugo Napoleão')," +
                        "(2204659,22,'Ilha Grande')," +
                        "(2204709,22,'Inhuma')," +
                        "(2204808,22,'Ipiranga do Piauí')," +
                        "(2204907,22,'Isaías Coelho')," +
                        "(2205003,22,'Itainópolis')," +
                        "(2205102,22,'Itaueira')," +
                        "(2205151,22,'Jacobina do Piauí')," +
                        "(2205201,22,'Jaicós')," +
                        "(2205250,22,'Jardim do Mulato')," +
                        "(2205276,22,'Jatobá do Piauí')," +
                        "(2205300,22,'Jerumenha')," +
                        "(2205359,22,'João Costa')," +
                        "(2205409,22,'Joaquim Pires')," +
                        "(2205458,22,'Joca Marques')," +
                        "(2205508,22,'José de Freitas')," +
                        "(2205516,22,'Juazeiro do Piauí')," +
                        "(2205524,22,'Júlio Borges')," +
                        "(2205532,22,'Jurema')," +
                        "(2205540,22,'Lagoinha do Piauí')," +
                        "(2205557,22,'Lagoa Alegre')," +
                        "(2205565,22,'Lagoa do Barro do Piauí')," +
                        "(2205573,22,'Lagoa de São Francisco')," +
                        "(2205581,22,'Lagoa do Piauí')," +
                        "(2205599,22,'Lagoa do Sítio')," +
                        "(2205607,22,'Landri Sales')," +
                        "(2205706,22,'Luís Correia')," +
                        "(2205805,22,'Luzilândia')," +
                        "(2205854,22,'Madeiro')," +
                        "(2205904,22,'Manoel Emídio')," +
                        "(2205953,22,'Marcolândia')," +
                        "(2206001,22,'Marcos Parente')," +
                        "(2206050,22,'Massapê do Piauí')," +
                        "(2206100,22,'Matias Olímpio')," +
                        "(2206209,22,'Miguel Alves')," +
                        "(2206308,22,'Miguel Leão')," +
                        "(2206357,22,'Milton Brandão')," +
                        "(2206407,22,'Monsenhor Gil')," +
                        "(2206506,22,'Monsenhor Hipólito')," +
                        "(2206605,22,'Monte Alegre do Piauí')," +
                        "(2206654,22,'Morro Cabeça No Tempo')," +
                        "(2206670,22,'Morro do Chapéu do Piauí')," +
                        "(2206696,22,'Murici dos Portelas')," +
                        "(2206704,22,'Nazaré do Piauí')," +
                        "(2206720,22,'Nazária')," +
                        "(2206753,22,'Nossa Senhora de Nazaré')," +
                        "(2206803,22,'Nossa Senhora dos Remédios')," +
                        "(2206902,22,'Novo Oriente do Piauí')," +
                        "(2206951,22,'Novo Santo Antônio')," +
                        "(2207009,22,'Oeiras')," +
                        "(2207108,22,'Olho Dágua do Piauí')," +
                        "(2207207,22,'Padre Marcos')," +
                        "(2207306,22,'Paes Landim')," +
                        "(2207355,22,'Pajeú do Piauí')," +
                        "(2207405,22,'Palmeira do Piauí')," +
                        "(2207504,22,'Palmeirais')," +
                        "(2207553,22,'Paquetá')," +
                        "(2207603,22,'Parnaguá')," +
                        "(2207702,22,'Parnaíba')," +
                        "(2207751,22,'Passagem Franca do Piauí')," +
                        "(2207777,22,'Patos do Piauí')," +
                        "(2207793,22,'Pau Darco do Piauí')," +
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
                        "(2208551,22,'Porto Alegre do Piauí')," +
                        "(2208601,22,'Prata do Piauí')," +
                        "(2208650,22,'Queimada Nova')," +
                        "(2208700,22,'Redenção do Gurguéia')," +
                        "(2208809,22,'Regeneração')," +
                        "(2208858,22,'Riacho Frio')," +
                        "(2208874,22,'Ribeira do Piauí')," +
                        "(2208908,22,'Ribeiro Gonçalves')," +
                        "(2209005,22,'Rio Grande do Piauí')," +
                        "(2209104,22,'Santa Cruz do Piauí')," +
                        "(2209153,22,'Santa Cruz dos Milagres')," +
                        "(2209203,22,'Santa Filomena')," +
                        "(2209302,22,'Santa Luz')," +
                        "(2209351,22,'Santana do Piauí')," +
                        "(2209377,22,'Santa Rosa do Piauí')," +
                        "(2209401,22,'Santo Antônio de Lisboa')," +
                        "(2209450,22,'Santo Antônio dos Milagres')," +
                        "(2209500,22,'Santo Inácio do Piauí')," +
                        "(2209559,22,'São Braz do Piauí')," +
                        "(2209609,22,'São Félix do Piauí')," +
                        "(2209658,22,'São Francisco de Assis do Piauí')," +
                        "(2209708,22,'São Francisco do Piauí')," +
                        "(2209757,22,'São Gonçalo do Gurguéia')," +
                        "(2209807,22,'São Gonçalo do Piauí')," +
                        "(2209856,22,'São João da Canabrava')," +
                        "(2209872,22,'São João da Fronteira')," +
                        "(2209906,22,'São João da Serra')," +
                        "(2209955,22,'São João da Varjota')," +
                        "(2209971,22,'São João do Arraial')," +
                        "(2210003,22,'São João do Piauí')," +
                        "(2210052,22,'São José do Divino')," +
                        "(2210102,22,'São José do Peixe')," +
                        "(2210201,22,'São José do Piauí')," +
                        "(2210300,22,'São Julião')," +
                        "(2210359,22,'São Lourenço do Piauí')," +
                        "(2210375,22,'São Luis do Piauí')," +
                        "(2210383,22,'São Miguel da Baixa Grande')," +
                        "(2210391,22,'São Miguel do Fidalgo')," +
                        "(2210409,22,'São Miguel do Tapuio')," +
                        "(2210508,22,'São Pedro do Piauí')," +
                        "(2210607,22,'São Raimundo Nonato')," +
                        "(2210623,22,'Sebastião Barros')," +
                        "(2210631,22,'Sebastião Leal')," +
                        "(2210656,22,'Sigefredo Pacheco')," +
                        "(2210706,22,'Simões')," +
                        "(2210805,22,'Simplício Mendes')," +
                        "(2210904,22,'Socorro do Piauí')," +
                        "(2210938,22,'Sussuapara')," +
                        "(2210953,22,'Tamboril do Piauí')," +
                        "(2210979,22,'Tanque do Piauí')," +
                        "(2211001,22,'Teresina')," +
                        "(2211100,22,'União')," +
                        "(2211209,22,'Uruçuí')," +
                        "(2211308,22,'Valença do Piauí')," +
                        "(2211357,22,'Várzea Branca')," +
                        "(2211407,22,'Várzea Grande')," +
                        "(2211506,22,'Vera Mendes')," +
                        "(2211605,22,'Vila Nova do Piauí')," +
                        "(2211704,22,'Wall Ferraz')," +
                        "(2300101,23,'Abaiara')," +
                        "(2300150,23,'Acarape')," +
                        "(2300200,23,'Acaraú')," +
                        "(2300309,23,'Acopiara')," +
                        "(2300408,23,'Aiuaba')," +
                        "(2300507,23,'Alcântaras')," +
                        "(2300606,23,'Altaneira')," +
                        "(2300705,23,'Alto Santo')," +
                        "(2300754,23,'Amontada')," +
                        "(2300804,23,'Antonina do Norte')," +
                        "(2300903,23,'Apuiarés')," +
                        "(2301000,23,'Aquiraz')," +
                        "(2301109,23,'Aracati')," +
                        "(2301208,23,'Aracoiaba')," +
                        "(2301257,23,'Ararendá')," +
                        "(2301307,23,'Araripe')," +
                        "(2301406,23,'Aratuba')," +
                        "(2301505,23,'Arneiroz')," +
                        "(2301604,23,'Assaré')," +
                        "(2301703,23,'Aurora')," +
                        "(2301802,23,'Baixio')," +
                        "(2301851,23,'Banabuiú')," +
                        "(2301901,23,'Barbalha')," +
                        "(2301950,23,'Barreira')," +
                        "(2302008,23,'Barro')," +
                        "(2302057,23,'Barroquinha')," +
                        "(2302107,23,'Baturité')," +
                        "(2302206,23,'Beberibe')," +
                        "(2302305,23,'Bela Cruz')," +
                        "(2302404,23,'Boa Viagem')," +
                        "(2302503,23,'Brejo Santo')," +
                        "(2302602,23,'Camocim')," +
                        "(2302701,23,'Campos Sales')," +
                        "(2302800,23,'Canindé')," +
                        "(2302909,23,'Capistrano')," +
                        "(2303006,23,'Caridade')," +
                        "(2303105,23,'Cariré')," +
                        "(2303204,23,'Caririaçu')," +
                        "(2303303,23,'Cariús')," +
                        "(2303402,23,'Carnaubal')," +
                        "(2303501,23,'Cascavel')," +
                        "(2303600,23,'Catarina')," +
                        "(2303659,23,'Catunda')," +
                        "(2303709,23,'Caucaia')," +
                        "(2303808,23,'Cedro')," +
                        "(2303907,23,'Chaval')," +
                        "(2303931,23,'Choró')," +
                        "(2303956,23,'Chorozinho')," +
                        "(2304004,23,'Coreaú')," +
                        "(2304103,23,'Crateús')," +
                        "(2304202,23,'Crato')," +
                        "(2304236,23,'Croatá')," +
                        "(2304251,23,'Cruz')," +
                        "(2304269,23,'deputado Irapuan Pinheiro')," +
                        "(2304277,23,'Ererê')," +
                        "(2304285,23,'Eusébio')," +
                        "(2304301,23,'Farias Brito')," +
                        "(2304350,23,'Forquilha')," +
                        "(2304400,23,'Fortaleza')," +
                        "(2304459,23,'Fortim')," +
                        "(2304509,23,'Frecheirinha')," +
                        "(2304608,23,'General Sampaio')," +
                        "(2304657,23,'Graça')," +
                        "(2304707,23,'Granja')," +
                        "(2304806,23,'Granjeiro')," +
                        "(2304905,23,'Groaíras')," +
                        "(2304954,23,'Guaiúba')," +
                        "(2305001,23,'Guaraciaba do Norte')," +
                        "(2305100,23,'Guaramiranga')," +
                        "(2305209,23,'Hidrolândia')," +
                        "(2305233,23,'Horizonte')," +
                        "(2305266,23,'Ibaretama')," +
                        "(2305308,23,'Ibiapina')," +
                        "(2305332,23,'Ibicuitinga')," +
                        "(2305357,23,'Icapuí')," +
                        "(2305407,23,'Icó')," +
                        "(2305506,23,'Iguatu')," +
                        "(2305605,23,'Independência')," +
                        "(2305654,23,'Ipaporanga')," +
                        "(2305704,23,'Ipaumirim')," +
                        "(2305803,23,'Ipu')," +
                        "(2305902,23,'Ipueiras')," +
                        "(2306009,23,'Iracema')," +
                        "(2306108,23,'Irauçuba')," +
                        "(2306207,23,'Itaiçaba')," +
                        "(2306256,23,'Itaitinga')," +
                        "(2306306,23,'Itapajé')," +
                        "(2306405,23,'Itapipoca')," +
                        "(2306504,23,'Itapiúna')," +
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
                        "(2307403,23,'Jucás')," +
                        "(2307502,23,'Lavras da Mangabeira')," +
                        "(2307601,23,'Limoeiro do Norte')," +
                        "(2307635,23,'Madalena')," +
                        "(2307650,23,'Maracanaú')," +
                        "(2307700,23,'Maranguape')," +
                        "(2307809,23,'Marco')," +
                        "(2307908,23,'Martinópole')," +
                        "(2308005,23,'Massapê')," +
                        "(2308104,23,'Mauriti')," +
                        "(2308203,23,'Meruoca')," +
                        "(2308302,23,'Milagres')," +
                        "(2308351,23,'Milhã')," +
                        "(2308377,23,'Miraíma')," +
                        "(2308401,23,'Missão Velha')," +
                        "(2308500,23,'Mombaça')," +
                        "(2308609,23,'Monsenhor Tabosa')," +
                        "(2308708,23,'Morada Nova')," +
                        "(2308807,23,'Moraújo')," +
                        "(2308906,23,'Morrinhos')," +
                        "(2309003,23,'Mucambo')," +
                        "(2309102,23,'Mulungu')," +
                        "(2309201,23,'Nova Olinda')," +
                        "(2309300,23,'Nova Russas')," +
                        "(2309409,23,'Novo Oriente')," +
                        "(2309458,23,'Ocara')," +
                        "(2309508,23,'Orós')," +
                        "(2309607,23,'Pacajus')," +
                        "(2309706,23,'Pacatuba')," +
                        "(2309805,23,'Pacoti')," +
                        "(2309904,23,'Pacujá')," +
                        "(2310001,23,'Palhano')," +
                        "(2310100,23,'Palmácia')," +
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
                        "(2311264,23,'Quiterianópolis')," +
                        "(2311306,23,'Quixadá')," +
                        "(2311355,23,'Quixelô')," +
                        "(2311405,23,'Quixeramobim')," +
                        "(2311504,23,'Quixeré')," +
                        "(2311603,23,'Redenção')," +
                        "(2311702,23,'Reriutaba')," +
                        "(2311801,23,'Russas')," +
                        "(2311900,23,'Saboeiro')," +
                        "(2311959,23,'Salitre')," +
                        "(2312007,23,'Santana do Acaraú')," +
                        "(2312106,23,'Santana do Cariri')," +
                        "(2312205,23,'Santa Quitéria')," +
                        "(2312304,23,'São Benedito')," +
                        "(2312403,23,'São Gonçalo do Amarante')," +
                        "(2312502,23,'São João do Jaguaribe')," +
                        "(2312601,23,'São Luís do Curu')," +
                        "(2312700,23,'Senador Pompeu')," +
                        "(2312809,23,'Senador Sá')," +
                        "(2312908,23,'Sobral')," +
                        "(2313005,23,'Solonópole')," +
                        "(2313104,23,'Tabuleiro do Norte')," +
                        "(2313203,23,'Tamboril')," +
                        "(2313252,23,'Tarrafas')," +
                        "(2313302,23,'Tauá')," +
                        "(2313351,23,'Tejuçuoca')," +
                        "(2313401,23,'Tianguá')," +
                        "(2313500,23,'Trairi')," +
                        "(2313559,23,'Tururu')," +
                        "(2313609,23,'Ubajara')," +
                        "(2313708,23,'Umari')," +
                        "(2313757,23,'Umirim')," +
                        "(2313807,23,'Uruburetama')," +
                        "(2313906,23,'Uruoca')," +
                        "(2313955,23,'Varjota')," +
                        "(2314003,23,'Várzea Alegre')," +
                        "(2314102,23,'Viçosa do Ceará')," +
                        "(2400109,24,'Acari')," +
                        "(2400208,24,'Açu')," +
                        "(2400307,24,'Afonso Bezerra')," +
                        "(2400406,24,'Água Nova')," +
                        "(2400505,24,'Alexandria')," +
                        "(2400604,24,'Almino Afonso')," +
                        "(2400703,24,'Alto do Rodrigues')," +
                        "(2400802,24,'Angicos')," +
                        "(2400901,24,'Antônio Martins')," +
                        "(2401008,24,'Apodi')," +
                        "(2401107,24,'Areia Branca')," +
                        "(2401206,24,'Arês')," +
                        "(2401305,24,'Augusto Severo')," +
                        "(2401404,24,'Baía Formosa')," +
                        "(2401453,24,'Baraúna')," +
                        "(2401503,24,'Barcelona')," +
                        "(2401602,24,'Bento Fernandes')," +
                        "(2401651,24,'Bodó')," +
                        "(2401701,24,'Bom Jesus')," +
                        "(2401800,24,'Brejinho')," +
                        "(2401859,24,'Caiçara do Norte')," +
                        "(2401909,24,'Caiçara do Rio do Vento')," +
                        "(2402006,24,'Caicó')," +
                        "(2402105,24,'Campo Redondo')," +
                        "(2402204,24,'Canguaretama')," +
                        "(2402303,24,'Caraúbas')," +
                        "(2402402,24,'Carnaúba dos dantas')," +
                        "(2402501,24,'Carnaubais')," +
                        "(2402600,24,'Ceará-Mirim')," +
                        "(2402709,24,'Cerro Corá')," +
                        "(2402808,24,'Coronel Ezequiel')," +
                        "(2402907,24,'Coronel João Pessoa')," +
                        "(2403004,24,'Cruzeta')," +
                        "(2403103,24,'Currais Novos')," +
                        "(2403202,24,'doutor Severiano')," +
                        "(2403251,24,'Parnamirim')," +
                        "(2403301,24,'Encanto')," +
                        "(2403400,24,'Equador')," +
                        "(2403509,24,'Espírito Santo')," +
                        "(2403608,24,'Extremoz')," +
                        "(2403707,24,'Felipe Guerra')," +
                        "(2403756,24,'Fernando Pedroza')," +
                        "(2403806,24,'Florânia')," +
                        "(2403905,24,'Francisco dantas')," +
                        "(2404002,24,'Frutuoso Gomes')," +
                        "(2404101,24,'Galinhos')," +
                        "(2404200,24,'Goianinha')," +
                        "(2404309,24,'Governador Dix-Sept Rosado')," +
                        "(2404408,24,'Grossos')," +
                        "(2404507,24,'Guamaré')," +
                        "(2404606,24,'Ielmo Marinho')," +
                        "(2404705,24,'Ipanguaçu')," +
                        "(2404804,24,'Ipueira')," +
                        "(2404853,24,'Itajá')," +
                        "(2404903,24,'Itaú')," +
                        "(2405009,24,'Jaçanã')," +
                        "(2405108,24,'Jandaíra')," +
                        "(2405207,24,'Janduís')," +
                        "(2405306,24,'Januário Cicco')," +
                        "(2405405,24,'Japi')," +
                        "(2405504,24,'Jardim de Angicos')," +
                        "(2405603,24,'Jardim de Piranhas')," +
                        "(2405702,24,'Jardim do Seridó')," +
                        "(2405801,24,'João Câmara')," +
                        "(2405900,24,'João Dias')," +
                        "(2406007,24,'José da Penha')," +
                        "(2406106,24,'Jucurutu')," +
                        "(2406155,24,'Jundiá')," +
                        "(2406205,24,'Lagoa Danta')," +
                        "(2406304,24,'Lagoa de Pedras')," +
                        "(2406403,24,'Lagoa de Velhos')," +
                        "(2406502,24,'Lagoa Nova')," +
                        "(2406601,24,'Lagoa Salgada')," +
                        "(2406700,24,'Lajes')," +
                        "(2406809,24,'Lajes Pintadas')," +
                        "(2406908,24,'Lucrécia')," +
                        "(2407005,24,'Luís Gomes')," +
                        "(2407104,24,'Macaíba')," +
                        "(2407203,24,'Macau')," +
                        "(2407252,24,'Major Sales')," +
                        "(2407302,24,'Marcelino Vieira')," +
                        "(2407401,24,'Martins')," +
                        "(2407500,24,'Maxaranguape')," +
                        "(2407609,24,'Messias Targino')," +
                        "(2407708,24,'Montanhas')," +
                        "(2407807,24,'Monte Alegre')," +
                        "(2407906,24,'Monte das Gameleiras')," +
                        "(2408003,24,'Mossoró')," +
                        "(2408102,24,'Natal')," +
                        "(2408201,24,'Nísia Floresta')," +
                        "(2408300,24,'Nova Cruz')," +
                        "(2408409,24,'Olho-Dágua do Borges')," +
                        "(2408508,24,'Ouro Branco')," +
                        "(2408607,24,'Paraná')," +
                        "(2408706,24,'Paraú')," +
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
                        "(2409902,24,'Pendências')," +
                        "(2410009,24,'Pilões')," +
                        "(2410108,24,'Poço Branco')," +
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
                        "(2411429,24,'Santana do Seridó')," +
                        "(2411502,24,'Santo Antônio')," +
                        "(2411601,24,'São Bento do Norte')," +
                        "(2411700,24,'São Bento do Trairí')," +
                        "(2411809,24,'São Fernando')," +
                        "(2411908,24,'São Francisco do Oeste')," +
                        "(2412005,24,'São Gonçalo do Amarante')," +
                        "(2412104,24,'São João do Sabugi')," +
                        "(2412203,24,'São José de Mipibu')," +
                        "(2412302,24,'São José do Campestre')," +
                        "(2412401,24,'São José do Seridó')," +
                        "(2412500,24,'São Miguel')," +
                        "(2412559,24,'São Miguel do Gostoso')," +
                        "(2412609,24,'São Paulo do Potengi')," +
                        "(2412708,24,'São Pedro')," +
                        "(2412807,24,'São Rafael')," +
                        "(2412906,24,'São Tomé')," +
                        "(2413003,24,'São Vicente')," +
                        "(2413102,24,'Senador Elói de Souza')," +
                        "(2413201,24,'Senador Georgino Avelino')," +
                        "(2413300,24,'Serra de São Bento')," +
                        "(2413359,24,'Serra do Mel')," +
                        "(2413409,24,'Serra Negra do Norte')," +
                        "(2413508,24,'Serrinha')," +
                        "(2413557,24,'Serrinha dos Pintos')," +
                        "(2413607,24,'Severiano Melo')," +
                        "(2413706,24,'Sítio Novo')," +
                        "(2413805,24,'Taboleiro Grande')," +
                        "(2413904,24,'Taipu')," +
                        "(2414001,24,'Tangará')," +
                        "(2414100,24,'Tenente Ananias')," +
                        "(2414159,24,'Tenente Laurentino Cruz')," +
                        "(2414209,24,'Tibau do Sul')," +
                        "(2414308,24,'Timbaúba dos Batistas')," +
                        "(2414407,24,'Touros')," +
                        "(2414456,24,'Triunfo Potiguar')," +
                        "(2414506,24,'Umarizal')," +
                        "(2414605,24,'Upanema')," +
                        "(2414704,24,'Várzea')," +
                        "(2414753,24,'Venha-Ver')," +
                        "(2414803,24,'Vera Cruz')," +
                        "(2414902,24,'Viçosa')," +
                        "(2415008,24,'Vila Flor')," +
                        "(2500106,25,'Água Branca')," +
                        "(2500205,25,'Aguiar')," +
                        "(2500304,25,'Alagoa Grande')," +
                        "(2500403,25,'Alagoa Nova')," +
                        "(2500502,25,'Alagoinha')," +
                        "(2500536,25,'Alcantil')," +
                        "(2500577,25,'Algodão de Jandaíra')," +
                        "(2500601,25,'Alhandra')," +
                        "(2500700,25,'São João do Rio do Peixe')," +
                        "(2500734,25,'Amparo')," +
                        "(2500775,25,'Aparecida')," +
                        "(2500809,25,'Araçagi')," +
                        "(2500908,25,'Arara')," +
                        "(2501005,25,'Araruna')," +
                        "(2501104,25,'Areia')," +
                        "(2501153,25,'Areia de Baraúnas')," +
                        "(2501203,25,'Areial')," +
                        "(2501302,25,'Aroeiras')," +
                        "(2501351,25,'Assunção')," +
                        "(2501401,25,'Baía da Traição')," +
                        "(2501500,25,'Bananeiras')," +
                        "(2501534,25,'Baraúna')," +
                        "(2501575,25,'Barra de Santana')," +
                        "(2501609,25,'Barra de Santa Rosa')," +
                        "(2501708,25,'Barra de São Miguel')," +
                        "(2501807,25,'Bayeux')," +
                        "(2501906,25,'Belém')," +
                        "(2502003,25,'Belém do Brejo do Cruz')," +
                        "(2502052,25,'Bernardino Batista')," +
                        "(2502102,25,'Boa Ventura')," +
                        "(2502151,25,'Boa Vista')," +
                        "(2502201,25,'Bom Jesus')," +
                        "(2502300,25,'Bom Sucesso')," +
                        "(2502409,25,'Bonito de Santa Fé')," +
                        "(2502508,25,'Boqueirão')," +
                        "(2502607,25,'Igaracy')," +
                        "(2502706,25,'Borborema')," +
                        "(2502805,25,'Brejo do Cruz')," +
                        "(2502904,25,'Brejo dos Santos')," +
                        "(2503001,25,'Caaporã')," +
                        "(2503100,25,'Cabaceiras')," +
                        "(2503209,25,'Cabedelo')," +
                        "(2503308,25,'Cachoeira dos Índios')," +
                        "(2503407,25,'Cacimba de Areia')," +
                        "(2503506,25,'Cacimba de dentro')," +
                        "(2503555,25,'Cacimbas')," +
                        "(2503605,25,'Caiçara')," +
                        "(2503704,25,'Cajazeiras')," +
                        "(2503753,25,'Cajazeirinhas')," +
                        "(2503803,25,'Caldas Brandão')," +
                        "(2503902,25,'Camalaú')," +
                        "(2504009,25,'Campina Grande')," +
                        "(2504033,25,'Capim')," +
                        "(2504074,25,'Caraúbas')," +
                        "(2504108,25,'Carrapateira')," +
                        "(2504157,25,'Casserengue')," +
                        "(2504207,25,'Catingueira')," +
                        "(2504306,25,'Catolé do Rocha')," +
                        "(2504355,25,'Caturité')," +
                        "(2504405,25,'Conceição')," +
                        "(2504504,25,'Condado')," +
                        "(2504603,25,'Conde')," +
                        "(2504702,25,'Congo')," +
                        "(2504801,25,'Coremas')," +
                        "(2504850,25,'Coxixola')," +
                        "(2504900,25,'Cruz do Espírito Santo')," +
                        "(2505006,25,'Cubati')," +
                        "(2505105,25,'Cuité')," +
                        "(2505204,25,'Cuitegi')," +
                        "(2505238,25,'Cuité de Mamanguape')," +
                        "(2505279,25,'Curral de Cima')," +
                        "(2505303,25,'Curral Velho')," +
                        "(2505352,25,'damião')," +
                        "(2505402,25,'desterro')," +
                        "(2505501,25,'Vista Serrana')," +
                        "(2505600,25,'Diamante')," +
                        "(2505709,25,'dona Inês')," +
                        "(2505808,25,'Duas Estradas')," +
                        "(2505907,25,'Emas')," +
                        "(2506004,25,'Esperança')," +
                        "(2506103,25,'Fagundes')," +
                        "(2506202,25,'Frei Martinho')," +
                        "(2506251,25,'Gado Bravo')," +
                        "(2506301,25,'Guarabira')," +
                        "(2506400,25,'Gurinhém')," +
                        "(2506509,25,'Gurjão')," +
                        "(2506608,25,'Ibiara')," +
                        "(2506707,25,'Imaculada')," +
                        "(2506806,25,'Ingá')," +
                        "(2506905,25,'Itabaiana')," +
                        "(2507002,25,'Itaporanga')," +
                        "(2507101,25,'Itapororoca')," +
                        "(2507200,25,'Itatuba')," +
                        "(2507309,25,'Jacaraú')," +
                        "(2507408,25,'Jericó')," +
                        "(2507507,25,'João Pessoa')," +
                        "(2507606,25,'Juarez Távora')," +
                        "(2507705,25,'Juazeirinho')," +
                        "(2507804,25,'Junco do Seridó')," +
                        "(2507903,25,'Juripiranga')," +
                        "(2508000,25,'Juru')," +
                        "(2508109,25,'Lagoa')," +
                        "(2508208,25,'Lagoa de dentro')," +
                        "(2508307,25,'Lagoa Seca')," +
                        "(2508406,25,'Lastro')," +
                        "(2508505,25,'Livramento')," +
                        "(2508554,25,'Logradouro')," +
                        "(2508604,25,'Lucena')," +
                        "(2508703,25,'Mãe Dágua')," +
                        "(2508802,25,'Malta')," +
                        "(2508901,25,'Mamanguape')," +
                        "(2509008,25,'Manaíra')," +
                        "(2509057,25,'Marcação')," +
                        "(2509107,25,'Mari')," +
                        "(2509156,25,'Marizópolis')," +
                        "(2509206,25,'Massaranduba')," +
                        "(2509305,25,'Mataraca')," +
                        "(2509339,25,'Matinhas')," +
                        "(2509370,25,'Mato Grosso')," +
                        "(2509396,25,'Maturéia')," +
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
                        "(2510402,25,'Olho Dágua')," +
                        "(2510501,25,'Olivedos')," +
                        "(2510600,25,'Ouro Velho')," +
                        "(2510659,25,'Parari')," +
                        "(2510709,25,'Passagem')," +
                        "(2510808,25,'Patos')," +
                        "(2510907,25,'Paulista')," +
                        "(2511004,25,'Pedra Branca')," +
                        "(2511103,25,'Pedra Lavrada')," +
                        "(2511202,25,'Pedras de Fogo')," +
                        "(2511301,25,'Piancó')," +
                        "(2511400,25,'Picuí')," +
                        "(2511509,25,'Pilar')," +
                        "(2511608,25,'Pilões')," +
                        "(2511707,25,'Pilõezinhos')," +
                        "(2511806,25,'Pirpirituba')," +
                        "(2511905,25,'Pitimbu')," +
                        "(2512002,25,'Pocinhos')," +
                        "(2512036,25,'Poço dantas')," +
                        "(2512077,25,'Poço de José de Moura')," +
                        "(2512101,25,'Pombal')," +
                        "(2512200,25,'Prata')," +
                        "(2512309,25,'Princesa Isabel')," +
                        "(2512408,25,'Puxinanã')," +
                        "(2512507,25,'Queimadas')," +
                        "(2512606,25,'Quixaba')," +
                        "(2512705,25,'Remígio')," +
                        "(2512721,25,'Pedro Régis')," +
                        "(2512747,25,'Riachão')," +
                        "(2512754,25,'Riachão do Bacamarte')," +
                        "(2512762,25,'Riachão do Poço')," +
                        "(2512788,25,'Riacho de Santo Antônio')," +
                        "(2512804,25,'Riacho dos Cavalos')," +
                        "(2512903,25,'Rio Tinto')," +
                        "(2513000,25,'Salgadinho')," +
                        "(2513109,25,'Salgado de São Félix')," +
                        "(2513158,25,'Santa Cecília')," +
                        "(2513208,25,'Santa Cruz')," +
                        "(2513307,25,'Santa Helena')," +
                        "(2513356,25,'Santa Inês')," +
                        "(2513406,25,'Santa Luzia')," +
                        "(2513505,25,'Santana de Mangueira')," +
                        "(2513604,25,'Santana dos Garrotes')," +
                        "(2513653,25,'Joca Claudino')," +
                        "(2513703,25,'Santa Rita')," +
                        "(2513802,25,'Santa Teresinha')," +
                        "(2513851,25,'Santo André')," +
                        "(2513901,25,'São Bento')," +
                        "(2513927,25,'São Bentinho')," +
                        "(2513943,25,'São domingos do Cariri')," +
                        "(2513968,25,'São domingos')," +
                        "(2513984,25,'São Francisco')," +
                        "(2514008,25,'São João do Cariri')," +
                        "(2514107,25,'São João do Tigre')," +
                        "(2514206,25,'São José da Lagoa Tapada')," +
                        "(2514305,25,'São José de Caiana')," +
                        "(2514404,25,'São José de Espinharas')," +
                        "(2514453,25,'São José dos Ramos')," +
                        "(2514503,25,'São José de Piranhas')," +
                        "(2514552,25,'São José de Princesa')," +
                        "(2514602,25,'São José do Bonfim')," +
                        "(2514651,25,'São José do Brejo do Cruz')," +
                        "(2514701,25,'São José do Sabugi')," +
                        "(2514800,25,'São José dos Cordeiros')," +
                        "(2514909,25,'São Mamede')," +
                        "(2515005,25,'São Miguel de Taipu')," +
                        "(2515104,25,'São Sebastião de Lagoa de Roça')," +
                        "(2515203,25,'São Sebastião do Umbuzeiro')," +
                        "(2515302,25,'Sapé')," +
                        "(2515401,25,'São Vicente do Seridó')," +
                        "(2515500,25,'Serra Branca')," +
                        "(2515609,25,'Serra da Raiz')," +
                        "(2515708,25,'Serra Grande')," +
                        "(2515807,25,'Serra Redonda')," +
                        "(2515906,25,'Serraria')," +
                        "(2515930,25,'Sertãozinho')," +
                        "(2515971,25,'Sobrado')," +
                        "(2516003,25,'Solânea')," +
                        "(2516102,25,'Soledade')," +
                        "(2516151,25,'Sossêgo')," +
                        "(2516201,25,'Sousa')," +
                        "(2516300,25,'Sumé')," +
                        "(2516409,25,'Tacima')," +
                        "(2516508,25,'Taperoá')," +
                        "(2516607,25,'Tavares')," +
                        "(2516706,25,'Teixeira')," +
                        "(2516755,25,'Tenório')," +
                        "(2516805,25,'Triunfo')," +
                        "(2516904,25,'Uiraúna')," +
                        "(2517001,25,'Umbuzeiro')," +
                        "(2517100,25,'Várzea')," +
                        "(2517209,25,'Vieirópolis')," +
                        "(2517407,25,'Zabelê')," +
                        "(2600054,26,'Abreu E Lima')," +
                        "(2600104,26,'Afogados da Ingazeira')," +
                        "(2600203,26,'Afrânio')," +
                        "(2600302,26,'Agrestina')," +
                        "(2600401,26,'Água Preta')," +
                        "(2600500,26,'Águas Belas')," +
                        "(2600609,26,'Alagoinha')," +
                        "(2600708,26,'Aliança')," +
                        "(2600807,26,'Altinho')," +
                        "(2600906,26,'Amaraji')," +
                        "(2601003,26,'Angelim')," +
                        "(2601052,26,'Araçoiaba')," +
                        "(2601102,26,'Araripina')," +
                        "(2601201,26,'Arcoverde')," +
                        "(2601300,26,'Barra de Guabiraba')," +
                        "(2601409,26,'Barreiros')," +
                        "(2601508,26,'Belém de Maria')," +
                        "(2601607,26,'Belém do São Francisco')," +
                        "(2601706,26,'Belo Jardim')," +
                        "(2601805,26,'Betânia')," +
                        "(2601904,26,'Bezerros')," +
                        "(2602001,26,'Bodocó')," +
                        "(2602100,26,'Bom Conselho')," +
                        "(2602209,26,'Bom Jardim')," +
                        "(2602308,26,'Bonito')," +
                        "(2602407,26,'Brejão')," +
                        "(2602506,26,'Brejinho')," +
                        "(2602605,26,'Brejo da Madre de deus')," +
                        "(2602704,26,'Buenos Aires')," +
                        "(2602803,26,'Buíque')," +
                        "(2602902,26,'Cabo de Santo Agostinho')," +
                        "(2603009,26,'Cabrobó')," +
                        "(2603108,26,'Cachoeirinha')," +
                        "(2603207,26,'Caetés')," +
                        "(2603306,26,'Calçado')," +
                        "(2603405,26,'Calumbi')," +
                        "(2603454,26,'Camaragibe')," +
                        "(2603504,26,'Camocim de São Félix')," +
                        "(2603603,26,'Camutanga')," +
                        "(2603702,26,'Canhotinho')," +
                        "(2603801,26,'Capoeiras')," +
                        "(2603900,26,'Carnaíba')," +
                        "(2603926,26,'Carnaubeira da Penha')," +
                        "(2604007,26,'Carpina')," +
                        "(2604106,26,'Caruaru')," +
                        "(2604155,26,'Casinhas')," +
                        "(2604205,26,'Catende')," +
                        "(2604304,26,'Cedro')," +
                        "(2604403,26,'Chã de Alegria')," +
                        "(2604502,26,'Chã Grande')," +
                        "(2604601,26,'Condado')," +
                        "(2604700,26,'Correntes')," +
                        "(2604809,26,'Cortês')," +
                        "(2604908,26,'Cumaru')," +
                        "(2605004,26,'Cupira')," +
                        "(2605103,26,'Custódia')," +
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
                        "(2606101,26,'Glória do Goitá')," +
                        "(2606200,26,'Goiana')," +
                        "(2606309,26,'Granito')," +
                        "(2606408,26,'Gravatá')," +
                        "(2606507,26,'Iati')," +
                        "(2606606,26,'Ibimirim')," +
                        "(2606705,26,'Ibirajuba')," +
                        "(2606804,26,'Igarassu')," +
                        "(2606903,26,'Iguaracy')," +
                        "(2607000,26,'Inajá')," +
                        "(2607109,26,'Ingazeira')," +
                        "(2607208,26,'Ipojuca')," +
                        "(2607307,26,'Ipubi')," +
                        "(2607406,26,'Itacuruba')," +
                        "(2607505,26,'Itaíba')," +
                        "(2607604,26,'Ilha de Itamaracá')," +
                        "(2607653,26,'Itambé')," +
                        "(2607703,26,'Itapetim')," +
                        "(2607752,26,'Itapissuma')," +
                        "(2607802,26,'Itaquitinga')," +
                        "(2607901,26,'Jaboatão dos Guararapes')," +
                        "(2607950,26,'Jaqueira')," +
                        "(2608008,26,'Jataúba')," +
                        "(2608057,26,'Jatobá')," +
                        "(2608107,26,'João Alfredo')," +
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
                        "(2609501,26,'Nazaré da Mata')," +
                        "(2609600,26,'Olinda')," +
                        "(2609709,26,'Orobó')," +
                        "(2609808,26,'Orocó')," +
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
                        "(2611002,26,'Petrolândia')," +
                        "(2611101,26,'Petrolina')," +
                        "(2611200,26,'Poção')," +
                        "(2611309,26,'Pombos')," +
                        "(2611408,26,'Primavera')," +
                        "(2611507,26,'Quipapá')," +
                        "(2611533,26,'Quixaba')," +
                        "(2611606,26,'Recife')," +
                        "(2611705,26,'Riacho das Almas')," +
                        "(2611804,26,'Ribeirão')," +
                        "(2611903,26,'Rio Formoso')," +
                        "(2612000,26,'Sairé')," +
                        "(2612109,26,'Salgadinho')," +
                        "(2612208,26,'Salgueiro')," +
                        "(2612307,26,'Saloá')," +
                        "(2612406,26,'Sanharó')," +
                        "(2612455,26,'Santa Cruz')," +
                        "(2612471,26,'Santa Cruz da Baixa Verde')," +
                        "(2612505,26,'Santa Cruz do Capibaribe')," +
                        "(2612554,26,'Santa Filomena')," +
                        "(2612604,26,'Santa Maria da Boa Vista')," +
                        "(2612703,26,'Santa Maria do Cambucá')," +
                        "(2612802,26,'Santa Terezinha')," +
                        "(2612901,26,'São Benedito do Sul')," +
                        "(2613008,26,'São Bento do Una')," +
                        "(2613107,26,'São Caitano')," +
                        "(2613206,26,'São João')," +
                        "(2613305,26,'São Joaquim do Monte')," +
                        "(2613404,26,'São José da Coroa Grande')," +
                        "(2613503,26,'São José do Belmonte')," +
                        "(2613602,26,'São José do Egito')," +
                        "(2613701,26,'São Lourenço da Mata')," +
                        "(2613800,26,'São Vicente Ferrer')," +
                        "(2613909,26,'Serra Talhada')," +
                        "(2614006,26,'Serrita')," +
                        "(2614105,26,'Sertânia')," +
                        "(2614204,26,'Sirinhaém')," +
                        "(2614303,26,'Moreilândia')," +
                        "(2614402,26,'Solidão')," +
                        "(2614501,26,'Surubim')," +
                        "(2614600,26,'Tabira')," +
                        "(2614709,26,'Tacaimbó')," +
                        "(2614808,26,'Tacaratu')," +
                        "(2614857,26,'Tamandaré')," +
                        "(2615003,26,'Taquaritinga do Norte')," +
                        "(2615102,26,'Terezinha')," +
                        "(2615201,26,'Terra Nova')," +
                        "(2615300,26,'Timbaúba')," +
                        "(2615409,26,'Toritama')," +
                        "(2615508,26,'Tracunhaém')," +
                        "(2615607,26,'Trindade')," +
                        "(2615706,26,'Triunfo')," +
                        "(2615805,26,'Tupanatinga')," +
                        "(2615904,26,'Tuparetama')," +
                        "(2616001,26,'Venturosa')," +
                        "(2616100,26,'Verdejante')," +
                        "(2616183,26,'Vertente do Lério')," +
                        "(2616209,26,'Vertentes')," +
                        "(2616308,26,'Vicência')," +
                        "(2616407,26,'Vitória de Santo Antão')," +
                        "(2616506,26,'Xexéu')," +
                        "(2700102,27,'Água Branca')," +
                        "(2700201,27,'Anadia')," +
                        "(2700300,27,'Arapiraca')," +
                        "(2700409,27,'Atalaia')," +
                        "(2700508,27,'Barra de Santo Antônio')," +
                        "(2700607,27,'Barra de São Miguel')," +
                        "(2700706,27,'Batalha')," +
                        "(2700805,27,'Belém')," +
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
                        "(2701902,27,'Chã Preta')," +
                        "(2702009,27,'Coité do Nóia')," +
                        "(2702108,27,'Colônia Leopoldina')," +
                        "(2702207,27,'Coqueiro Seco')," +
                        "(2702306,27,'Coruripe')," +
                        "(2702355,27,'Craíbas')," +
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
                        "(2703403,27,'Jacaré dos Homens')," +
                        "(2703502,27,'Jacuípe')," +
                        "(2703601,27,'Japaratinga')," +
                        "(2703700,27,'Jaramataia')," +
                        "(2703759,27,'Jequiá da Praia')," +
                        "(2703809,27,'Joaquim Gomes')," +
                        "(2703908,27,'Jundiá')," +
                        "(2704005,27,'Junqueiro')," +
                        "(2704104,27,'Lagoa da Canoa')," +
                        "(2704203,27,'Limoeiro de Anadia')," +
                        "(2704302,27,'Maceió')," +
                        "(2704401,27,'Major Isidoro')," +
                        "(2704500,27,'Maragogi')," +
                        "(2704609,27,'Maravilha')," +
                        "(2704708,27,'Marechal deodoro')," +
                        "(2704807,27,'Maribondo')," +
                        "(2704906,27,'Mar Vermelho')," +
                        "(2705002,27,'Mata Grande')," +
                        "(2705101,27,'Matriz de Camaragibe')," +
                        "(2705200,27,'Messias')," +
                        "(2705309,27,'Minador do Negrão')," +
                        "(2705408,27,'Monteirópolis')," +
                        "(2705507,27,'Murici')," +
                        "(2705606,27,'Novo Lino')," +
                        "(2705705,27,'Olho Dágua das Flores')," +
                        "(2705804,27,'Olho Dágua do Casado')," +
                        "(2705903,27,'Olho Dágua Grande')," +
                        "(2706000,27,'Olivença')," +
                        "(2706109,27,'Ouro Branco')," +
                        "(2706208,27,'Palestina')," +
                        "(2706307,27,'Palmeira dos Índios')," +
                        "(2706406,27,'Pão de Açúcar')," +
                        "(2706422,27,'Pariconha')," +
                        "(2706448,27,'Paripueira')," +
                        "(2706505,27,'Passo de Camaragibe')," +
                        "(2706604,27,'Paulo Jacinto')," +
                        "(2706703,27,'Penedo')," +
                        "(2706802,27,'Piaçabuçu')," +
                        "(2706901,27,'Pilar')," +
                        "(2707008,27,'Pindoba')," +
                        "(2707107,27,'Piranhas')," +
                        "(2707206,27,'Poço das Trincheiras')," +
                        "(2707305,27,'Porto Calvo')," +
                        "(2707404,27,'Porto de Pedras')," +
                        "(2707503,27,'Porto Real do Colégio')," +
                        "(2707602,27,'Quebrangulo')," +
                        "(2707701,27,'Rio Largo')," +
                        "(2707800,27,'Roteiro')," +
                        "(2707909,27,'Santa Luzia do Norte')," +
                        "(2708006,27,'Santana do Ipanema')," +
                        "(2708105,27,'Santana do Mundaú')," +
                        "(2708204,27,'São Brás')," +
                        "(2708303,27,'São José da Laje')," +
                        "(2708402,27,'São José da Tapera')," +
                        "(2708501,27,'São Luís do Quitunde')," +
                        "(2708600,27,'São Miguel dos Campos')," +
                        "(2708709,27,'São Miguel dos Milagres')," +
                        "(2708808,27,'São Sebastião')," +
                        "(2708907,27,'Satuba')," +
                        "(2708956,27,'Senador Rui Palmeira')," +
                        "(2709004,27,'Tanque Darca')," +
                        "(2709103,27,'Taquarana')," +
                        "(2709152,27,'Teotônio Vilela')," +
                        "(2709202,27,'Traipu')," +
                        "(2709301,27,'União dos Palmares')," +
                        "(2709400,27,'Viçosa')," +
                        "(2800100,28,'Amparo de São Francisco')," +
                        "(2800209,28,'Aquidabã')," +
                        "(2800308,28,'Aracaju')," +
                        "(2800407,28,'Arauá')," +
                        "(2800506,28,'Areia Branca')," +
                        "(2800605,28,'Barra dos Coqueiros')," +
                        "(2800670,28,'Boquim')," +
                        "(2800704,28,'Brejo Grande')," +
                        "(2801009,28,'Campo do Brito')," +
                        "(2801108,28,'Canhoba')," +
                        "(2801207,28,'Canindé de São Francisco')," +
                        "(2801306,28,'Capela')," +
                        "(2801405,28,'Carira')," +
                        "(2801504,28,'Carmópolis')," +
                        "(2801603,28,'Cedro de São João')," +
                        "(2801702,28,'Cristinápolis')," +
                        "(2801900,28,'Cumbe')," +
                        "(2802007,28,'Divina Pastora')," +
                        "(2802106,28,'Estância')," +
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
                        "(2803401,28,'Japoatã')," +
                        "(2803500,28,'Lagarto')," +
                        "(2803609,28,'Laranjeiras')," +
                        "(2803708,28,'Macambira')," +
                        "(2803807,28,'Malhada dos Bois')," +
                        "(2803906,28,'Malhador')," +
                        "(2804003,28,'Maruim')," +
                        "(2804102,28,'Moita Bonita')," +
                        "(2804201,28,'Monte Alegre de Sergipe')," +
                        "(2804300,28,'Muribeca')," +
                        "(2804409,28,'Neópolis')," +
                        "(2804458,28,'Nossa Senhora Aparecida')," +
                        "(2804508,28,'Nossa Senhora da Glória')," +
                        "(2804607,28,'Nossa Senhora das dores')," +
                        "(2804706,28,'Nossa Senhora de Lourdes')," +
                        "(2804805,28,'Nossa Senhora do Socorro')," +
                        "(2804904,28,'Pacatuba')," +
                        "(2805000,28,'Pedra Mole')," +
                        "(2805109,28,'Pedrinhas')," +
                        "(2805208,28,'Pinhão')," +
                        "(2805307,28,'Pirambu')," +
                        "(2805406,28,'Poço Redondo')," +
                        "(2805505,28,'Poço Verde')," +
                        "(2805604,28,'Porto da Folha')," +
                        "(2805703,28,'Propriá')," +
                        "(2805802,28,'Riachão do dantas')," +
                        "(2805901,28,'Riachuelo')," +
                        "(2806008,28,'Ribeirópolis')," +
                        "(2806107,28,'Rosário do Catete')," +
                        "(2806206,28,'Salgado')," +
                        "(2806305,28,'Santa Luzia do Itanhy')," +
                        "(2806404,28,'Santana do São Francisco')," +
                        "(2806503,28,'Santa Rosa de Lima')," +
                        "(2806602,28,'Santo Amaro das Brotas')," +
                        "(2806701,28,'São Cristóvão')," +
                        "(2806800,28,'São domingos')," +
                        "(2806909,28,'São Francisco')," +
                        "(2807006,28,'São Miguel do Aleixo')," +
                        "(2807105,28,'Simão Dias')," +
                        "(2807204,28,'Siriri')," +
                        "(2807303,28,'Telha')," +
                        "(2807402,28,'Tobias Barreto')," +
                        "(2807501,28,'Tomar do Geru')," +
                        "(2807600,28,'Umbaúba')," +
                        "(2900108,29,'Abaíra')," +
                        "(2900207,29,'Abaré')," +
                        "(2900306,29,'Acajutiba')," +
                        "(2900355,29,'Adustina')," +
                        "(2900405,29,'Água Fria')," +
                        "(2900504,29,'Érico Cardoso')," +
                        "(2900603,29,'Aiquara')," +
                        "(2900702,29,'Alagoinhas')," +
                        "(2900801,29,'Alcobaça')," +
                        "(2900900,29,'Almadina')," +
                        "(2901007,29,'Amargosa')," +
                        "(2901106,29,'Amélia Rodrigues')," +
                        "(2901155,29,'América dourada')," +
                        "(2901205,29,'Anagé')," +
                        "(2901304,29,'Andaraí')," +
                        "(2901353,29,'Andorinha')," +
                        "(2901403,29,'Angical')," +
                        "(2901502,29,'Anguera')," +
                        "(2901601,29,'Antas')," +
                        "(2901700,29,'Antônio Cardoso')," +
                        "(2901809,29,'Antônio Gonçalves')," +
                        "(2901908,29,'Aporá')," +
                        "(2901957,29,'Apuarema')," +
                        "(2902005,29,'Aracatu')," +
                        "(2902054,29,'Araças')," +
                        "(2902104,29,'Araci')," +
                        "(2902203,29,'Aramari')," +
                        "(2902252,29,'Arataca')," +
                        "(2902302,29,'Aratuípe')," +
                        "(2902401,29,'Aurelino Leal')," +
                        "(2902500,29,'Baianópolis')," +
                        "(2902609,29,'Baixa Grande')," +
                        "(2902658,29,'Banzaê')," +
                        "(2902708,29,'Barra')," +
                        "(2902807,29,'Barra da Estiva')," +
                        "(2902906,29,'Barra do Choça')," +
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
                        "(2904209,29,'Botuporã')," +
                        "(2904308,29,'Brejões')," +
                        "(2904407,29,'Brejolândia')," +
                        "(2904506,29,'Brotas de Macaúbas')," +
                        "(2904605,29,'Brumado')," +
                        "(2904704,29,'Buerarema')," +
                        "(2904753,29,'Buritirama')," +
                        "(2904803,29,'Caatiba')," +
                        "(2904852,29,'Cabaceiras do Paraguaçu')," +
                        "(2904902,29,'Cachoeira')," +
                        "(2905008,29,'Caculé')," +
                        "(2905107,29,'Caém')," +
                        "(2905156,29,'Caetanos')," +
                        "(2905206,29,'Caetité')," +
                        "(2905305,29,'Cafarnaum')," +
                        "(2905404,29,'Cairu')," +
                        "(2905503,29,'Caldeirão Grande')," +
                        "(2905602,29,'Camacan')," +
                        "(2905701,29,'Camaçari')," +
                        "(2905800,29,'Camamu')," +
                        "(2905909,29,'Campo Alegre de Lourdes')," +
                        "(2906006,29,'Campo Formoso')," +
                        "(2906105,29,'Canápolis')," +
                        "(2906204,29,'Canarana')," +
                        "(2906303,29,'Canavieiras')," +
                        "(2906402,29,'Candeal')," +
                        "(2906501,29,'Candeias')," +
                        "(2906600,29,'Candiba')," +
                        "(2906709,29,'Cândido Sales')," +
                        "(2906808,29,'Cansanção')," +
                        "(2906824,29,'Canudos')," +
                        "(2906857,29,'Capela do Alto Alegre')," +
                        "(2906873,29,'Capim Grosso')," +
                        "(2906899,29,'Caraíbas')," +
                        "(2906907,29,'Caravelas')," +
                        "(2907004,29,'Cardeal da Silva')," +
                        "(2907103,29,'Carinhanha')," +
                        "(2907202,29,'Casa Nova')," +
                        "(2907301,29,'Castro Alves')," +
                        "(2907400,29,'Catolândia')," +
                        "(2907509,29,'Catu')," +
                        "(2907558,29,'Caturama')," +
                        "(2907608,29,'Central')," +
                        "(2907707,29,'Chorrochó')," +
                        "(2907806,29,'Cícero dantas')," +
                        "(2907905,29,'Cipó')," +
                        "(2908002,29,'Coaraci')," +
                        "(2908101,29,'Cocos')," +
                        "(2908200,29,'Conceição da Feira')," +
                        "(2908309,29,'Conceição do Almeida')," +
                        "(2908408,29,'Conceição do Coité')," +
                        "(2908507,29,'Conceição do Jacuípe')," +
                        "(2908606,29,'Conde')," +
                        "(2908705,29,'Condeúba')," +
                        "(2908804,29,'Contendas do Sincorá')," +
                        "(2908903,29,'Coração de Maria')," +
                        "(2909000,29,'Cordeiros')," +
                        "(2909109,29,'Coribe')," +
                        "(2909208,29,'Coronel João Sá')," +
                        "(2909307,29,'Correntina')," +
                        "(2909406,29,'Cotegipe')," +
                        "(2909505,29,'Cravolândia')," +
                        "(2909604,29,'Crisópolis')," +
                        "(2909703,29,'Cristópolis')," +
                        "(2909802,29,'Cruz das Almas')," +
                        "(2909901,29,'Curaçá')," +
                        "(2910008,29,'Dário Meira')," +
                        "(2910057,29,'Dias Dávila')," +
                        "(2910107,29,'dom Basílio')," +
                        "(2910206,29,'dom Macedo Costa')," +
                        "(2910305,29,'Elísio Medrado')," +
                        "(2910404,29,'Encruzilhada')," +
                        "(2910503,29,'Entre Rios')," +
                        "(2910602,29,'Esplanada')," +
                        "(2910701,29,'Euclides da Cunha')," +
                        "(2910727,29,'Eunápolis')," +
                        "(2910750,29,'Fátima')," +
                        "(2910776,29,'Feira da Mata')," +
                        "(2910800,29,'Feira de Santana')," +
                        "(2910859,29,'Filadélfia')," +
                        "(2910909,29,'Firmino Alves')," +
                        "(2911006,29,'Floresta Azul')," +
                        "(2911105,29,'Formosa do Rio Preto')," +
                        "(2911204,29,'Gandu')," +
                        "(2911253,29,'Gavião')," +
                        "(2911303,29,'Gentio do Ouro')," +
                        "(2911402,29,'Glória')," +
                        "(2911501,29,'Gongogi')," +
                        "(2911600,29,'Governador Mangabeira')," +
                        "(2911659,29,'Guajeru')," +
                        "(2911709,29,'Guanambi')," +
                        "(2911808,29,'Guaratinga')," +
                        "(2911857,29,'Heliópolis')," +
                        "(2911907,29,'Iaçu')," +
                        "(2912004,29,'Ibiassucê')," +
                        "(2912103,29,'Ibicaraí')," +
                        "(2912202,29,'Ibicoara')," +
                        "(2912301,29,'Ibicuí')," +
                        "(2912400,29,'Ibipeba')," +
                        "(2912509,29,'Ibipitanga')," +
                        "(2912608,29,'Ibiquera')," +
                        "(2912707,29,'Ibirapitanga')," +
                        "(2912806,29,'Ibirapuã')," +
                        "(2912905,29,'Ibirataia')," +
                        "(2913002,29,'Ibitiara')," +
                        "(2913101,29,'Ibititá')," +
                        "(2913200,29,'Ibotirama')," +
                        "(2913309,29,'Ichu')," +
                        "(2913408,29,'Igaporã')," +
                        "(2913457,29,'Igrapiúna')," +
                        "(2913507,29,'Iguaí')," +
                        "(2913606,29,'Ilhéus')," +
                        "(2913705,29,'Inhambupe')," +
                        "(2913804,29,'Ipecaetá')," +
                        "(2913903,29,'Ipiaú')," +
                        "(2914000,29,'Ipirá')," +
                        "(2914109,29,'Ipupiara')," +
                        "(2914208,29,'Irajuba')," +
                        "(2914307,29,'Iramaia')," +
                        "(2914406,29,'Iraquara')," +
                        "(2914505,29,'Irará')," +
                        "(2914604,29,'Irecê')," +
                        "(2914653,29,'Itabela')," +
                        "(2914703,29,'Itaberaba')," +
                        "(2914802,29,'Itabuna')," +
                        "(2914901,29,'Itacaré')," +
                        "(2915007,29,'Itaeté')," +
                        "(2915106,29,'Itagi')," +
                        "(2915205,29,'Itagibá')," +
                        "(2915304,29,'Itagimirim')," +
                        "(2915353,29,'Itaguaçu da Bahia')," +
                        "(2915403,29,'Itaju do Colônia')," +
                        "(2915502,29,'Itajuípe')," +
                        "(2915601,29,'Itamaraju')," +
                        "(2915700,29,'Itamari')," +
                        "(2915809,29,'Itambé')," +
                        "(2915908,29,'Itanagra')," +
                        "(2916005,29,'Itanhém')," +
                        "(2916104,29,'Itaparica')," +
                        "(2916203,29,'Itapé')," +
                        "(2916302,29,'Itapebi')," +
                        "(2916401,29,'Itapetinga')," +
                        "(2916500,29,'Itapicuru')," +
                        "(2916609,29,'Itapitanga')," +
                        "(2916708,29,'Itaquara')," +
                        "(2916807,29,'Itarantim')," +
                        "(2916856,29,'Itatim')," +
                        "(2916906,29,'Itiruçu')," +
                        "(2917003,29,'Itiúba')," +
                        "(2917102,29,'Itororó')," +
                        "(2917201,29,'Ituaçu')," +
                        "(2917300,29,'Ituberá')," +
                        "(2917334,29,'Iuiú')," +
                        "(2917359,29,'Jaborandi')," +
                        "(2917409,29,'Jacaraci')," +
                        "(2917508,29,'Jacobina')," +
                        "(2917607,29,'Jaguaquara')," +
                        "(2917706,29,'Jaguarari')," +
                        "(2917805,29,'Jaguaripe')," +
                        "(2917904,29,'Jandaíra')," +
                        "(2918001,29,'Jequié')," +
                        "(2918100,29,'Jeremoabo')," +
                        "(2918209,29,'Jiquiriçá')," +
                        "(2918308,29,'Jitaúna')," +
                        "(2918357,29,'João dourado')," +
                        "(2918407,29,'Juazeiro')," +
                        "(2918456,29,'Jucuruçu')," +
                        "(2918506,29,'Jussara')," +
                        "(2918555,29,'Jussari')," +
                        "(2918605,29,'Jussiape')," +
                        "(2918704,29,'Lafaiete Coutinho')," +
                        "(2918753,29,'Lagoa Real')," +
                        "(2918803,29,'Laje')," +
                        "(2918902,29,'Lajedão')," +
                        "(2919009,29,'Lajedinho')," +
                        "(2919058,29,'Lajedo do Tabocal')," +
                        "(2919108,29,'Lamarão')," +
                        "(2919157,29,'Lapão')," +
                        "(2919207,29,'Lauro de Freitas')," +
                        "(2919306,29,'Lençóis')," +
                        "(2919405,29,'Licínio de Almeida')," +
                        "(2919504,29,'Livramento de Nossa Senhora')," +
                        "(2919553,29,'Luís Eduardo Magalhães')," +
                        "(2919603,29,'Macajuba')," +
                        "(2919702,29,'Macarani')," +
                        "(2919801,29,'Macaúbas')," +
                        "(2919900,29,'Macururé')," +
                        "(2919926,29,'Madre de deus')," +
                        "(2919959,29,'Maetinga')," +
                        "(2920007,29,'Maiquinique')," +
                        "(2920106,29,'Mairi')," +
                        "(2920205,29,'Malhada')," +
                        "(2920304,29,'Malhada de Pedras')," +
                        "(2920403,29,'Manoel Vitorino')," +
                        "(2920452,29,'Mansidão')," +
                        "(2920502,29,'Maracás')," +
                        "(2920601,29,'Maragogipe')," +
                        "(2920700,29,'Maraú')," +
                        "(2920809,29,'Marcionílio Souza')," +
                        "(2920908,29,'Mascote')," +
                        "(2921005,29,'Mata de São João')," +
                        "(2921054,29,'Matina')," +
                        "(2921104,29,'Medeiros Neto')," +
                        "(2921203,29,'Miguel Calmon')," +
                        "(2921302,29,'Milagres')," +
                        "(2921401,29,'Mirangaba')," +
                        "(2921450,29,'Mirante')," +
                        "(2921500,29,'Monte Santo')," +
                        "(2921609,29,'Morpará')," +
                        "(2921708,29,'Morro do Chapéu')," +
                        "(2921807,29,'Mortugaba')," +
                        "(2921906,29,'Mucugê')," +
                        "(2922003,29,'Mucuri')," +
                        "(2922052,29,'Mulungu do Morro')," +
                        "(2922102,29,'Mundo Novo')," +
                        "(2922201,29,'Muniz Ferreira')," +
                        "(2922250,29,'Muquém de São Francisco')," +
                        "(2922300,29,'Muritiba')," +
                        "(2922409,29,'Mutuípe')," +
                        "(2922508,29,'Nazaré')," +
                        "(2922607,29,'Nilo Peçanha')," +
                        "(2922656,29,'Nordestina')," +
                        "(2922706,29,'Nova Canaã')," +
                        "(2922730,29,'Nova Fátima')," +
                        "(2922755,29,'Nova Ibiá')," +
                        "(2922805,29,'Nova Itarana')," +
                        "(2922854,29,'Nova Redenção')," +
                        "(2922904,29,'Nova Soure')," +
                        "(2923001,29,'Nova Viçosa')," +
                        "(2923035,29,'Novo Horizonte')," +
                        "(2923050,29,'Novo Triunfo')," +
                        "(2923100,29,'Olindina')," +
                        "(2923209,29,'Oliveira dos Brejinhos')," +
                        "(2923308,29,'Ouriçangas')," +
                        "(2923357,29,'Ourolândia')," +
                        "(2923407,29,'Palmas de Monte Alto')," +
                        "(2923506,29,'Palmeiras')," +
                        "(2923605,29,'Paramirim')," +
                        "(2923704,29,'Paratinga')," +
                        "(2923803,29,'Paripiranga')," +
                        "(2923902,29,'Pau Brasil')," +
                        "(2924009,29,'Paulo Afonso')," +
                        "(2924058,29,'Pé de Serra')," +
                        "(2924108,29,'Pedrão')," +
                        "(2924207,29,'Pedro Alexandre')," +
                        "(2924306,29,'Piatã')," +
                        "(2924405,29,'Pilão Arcado')," +
                        "(2924504,29,'Pindaí')," +
                        "(2924603,29,'Pindobaçu')," +
                        "(2924652,29,'Pintadas')," +
                        "(2924678,29,'Piraí do Norte')," +
                        "(2924702,29,'Piripá')," +
                        "(2924801,29,'Piritiba')," +
                        "(2924900,29,'Planaltino')," +
                        "(2925006,29,'Planalto')," +
                        "(2925105,29,'Poções')," +
                        "(2925204,29,'Pojuca')," +
                        "(2925253,29,'Ponto Novo')," +
                        "(2925303,29,'Porto Seguro')," +
                        "(2925402,29,'Potiraguá')," +
                        "(2925501,29,'Prado')," +
                        "(2925600,29,'Presidente Dutra')," +
                        "(2925709,29,'Presidente Jânio Quadros')," +
                        "(2925758,29,'Presidente Tancredo Neves')," +
                        "(2925808,29,'Queimadas')," +
                        "(2925907,29,'Quijingue')," +
                        "(2925931,29,'Quixabeira')," +
                        "(2925956,29,'Rafael Jambeiro')," +
                        "(2926004,29,'Remanso')," +
                        "(2926103,29,'Retirolândia')," +
                        "(2926202,29,'Riachão das Neves')," +
                        "(2926301,29,'Riachão do Jacuípe')," +
                        "(2926400,29,'Riacho de Santana')," +
                        "(2926509,29,'Ribeira do Amparo')," +
                        "(2926608,29,'Ribeira do Pombal')," +
                        "(2926657,29,'Ribeirão do Largo')," +
                        "(2926707,29,'Rio de Contas')," +
                        "(2926806,29,'Rio do Antônio')," +
                        "(2926905,29,'Rio do Pires')," +
                        "(2927002,29,'Rio Real')," +
                        "(2927101,29,'Rodelas')," +
                        "(2927200,29,'Ruy Barbosa')," +
                        "(2927309,29,'Salinas da Margarida')," +
                        "(2927408,29,'Salvador')," +
                        "(2927507,29,'Santa Bárbara')," +
                        "(2927606,29,'Santa Brígida')," +
                        "(2927705,29,'Santa Cruz Cabrália')," +
                        "(2927804,29,'Santa Cruz da Vitória')," +
                        "(2927903,29,'Santa Inês')," +
                        "(2928000,29,'Santaluz')," +
                        "(2928059,29,'Santa Luzia')," +
                        "(2928109,29,'Santa Maria da Vitória')," +
                        "(2928208,29,'Santana')," +
                        "(2928307,29,'Santanópolis')," +
                        "(2928406,29,'Santa Rita de Cássia')," +
                        "(2928505,29,'Santa Teresinha')," +
                        "(2928604,29,'Santo Amaro')," +
                        "(2928703,29,'Santo Antônio de Jesus')," +
                        "(2928802,29,'Santo Estêvão')," +
                        "(2928901,29,'São desidério')," +
                        "(2928950,29,'São domingos')," +
                        "(2929008,29,'São Félix')," +
                        "(2929057,29,'São Félix do Coribe')," +
                        "(2929107,29,'São Felipe')," +
                        "(2929206,29,'São Francisco do Conde')," +
                        "(2929255,29,'São Gabriel')," +
                        "(2929305,29,'São Gonçalo dos Campos')," +
                        "(2929354,29,'São José da Vitória')," +
                        "(2929370,29,'São José do Jacuípe')," +
                        "(2929404,29,'São Miguel das Matas')," +
                        "(2929503,29,'São Sebastião do Passé')," +
                        "(2929602,29,'Sapeaçu')," +
                        "(2929701,29,'Sátiro Dias')," +
                        "(2929750,29,'Saubara')," +
                        "(2929800,29,'Saúde')," +
                        "(2929909,29,'Seabra')," +
                        "(2930006,29,'Sebastião Laranjeiras')," +
                        "(2930105,29,'Senhor do Bonfim')," +
                        "(2930154,29,'Serra do Ramalho')," +
                        "(2930204,29,'Sento Sé')," +
                        "(2930303,29,'Serra dourada')," +
                        "(2930402,29,'Serra Preta')," +
                        "(2930501,29,'Serrinha')," +
                        "(2930600,29,'Serrolândia')," +
                        "(2930709,29,'Simões Filho')," +
                        "(2930758,29,'Sítio do Mato')," +
                        "(2930766,29,'Sítio do Quinto')," +
                        "(2930774,29,'Sobradinho')," +
                        "(2930808,29,'Souto Soares')," +
                        "(2930907,29,'Tabocas do Brejo Velho')," +
                        "(2931004,29,'Tanhaçu')," +
                        "(2931053,29,'Tanque Novo')," +
                        "(2931103,29,'Tanquinho')," +
                        "(2931202,29,'Taperoá')," +
                        "(2931301,29,'Tapiramutá')," +
                        "(2931350,29,'Teixeira de Freitas')," +
                        "(2931400,29,'Teodoro Sampaio')," +
                        "(2931509,29,'Teofilândia')," +
                        "(2931608,29,'Teolândia')," +
                        "(2931707,29,'Terra Nova')," +
                        "(2931806,29,'Tremedal')," +
                        "(2931905,29,'Tucano')," +
                        "(2932002,29,'Uauá')," +
                        "(2932101,29,'Ubaíra')," +
                        "(2932200,29,'Ubaitaba')," +
                        "(2932309,29,'Ubatã')," +
                        "(2932408,29,'Uibaí')," +
                        "(2932457,29,'Umburanas')," +
                        "(2932507,29,'Una')," +
                        "(2932606,29,'Urandi')," +
                        "(2932705,29,'Uruçuca')," +
                        "(2932804,29,'Utinga')," +
                        "(2932903,29,'Valença')," +
                        "(2933000,29,'Valente')," +
                        "(2933059,29,'Várzea da Roça')," +
                        "(2933109,29,'Várzea do Poço')," +
                        "(2933158,29,'Várzea Nova')," +
                        "(2933174,29,'Varzedo')," +
                        "(2933208,29,'Vera Cruz')," +
                        "(2933257,29,'Vereda')," +
                        "(2933307,29,'Vitória da Conquista')," +
                        "(2933406,29,'Wagner')," +
                        "(2933455,29,'Wanderley')," +
                        "(2933505,29,'Wenceslau Guimarães')," +
                        "(2933604,29,'Xique-Xique')," +
                        "(3100104,31,'Abadia dos dourados')," +
                        "(3100203,31,'Abaeté')," +
                        "(3100302,31,'Abre Campo')," +
                        "(3100401,31,'Acaiaca')," +
                        "(3100500,31,'Açucena')," +
                        "(3100609,31,'Água Boa')," +
                        "(3100708,31,'Água Comprida')," +
                        "(3100807,31,'Aguanil')," +
                        "(3100906,31,'Águas Formosas')," +
                        "(3101003,31,'Águas Vermelhas')," +
                        "(3101102,31,'Aimorés')," +
                        "(3101201,31,'Aiuruoca')," +
                        "(3101300,31,'Alagoa')," +
                        "(3101409,31,'Albertina')," +
                        "(3101508,31,'Além Paraíba')," +
                        "(3101607,31,'Alfenas')," +
                        "(3101631,31,'Alfredo Vasconcelos')," +
                        "(3101706,31,'Almenara')," +
                        "(3101805,31,'Alpercata')," +
                        "(3101904,31,'Alpinópolis')," +
                        "(3102001,31,'Alterosa')," +
                        "(3102050,31,'Alto Caparaó')," +
                        "(3102100,31,'Alto Rio doce')," +
                        "(3102209,31,'Alvarenga')," +
                        "(3102308,31,'Alvinópolis')," +
                        "(3102407,31,'Alvorada de Minas')," +
                        "(3102506,31,'Amparo do Serra')," +
                        "(3102605,31,'Andradas')," +
                        "(3102704,31,'Cachoeira de Pajeú')," +
                        "(3102803,31,'Andrelândia')," +
                        "(3102852,31,'Angelândia')," +
                        "(3102902,31,'Antônio Carlos')," +
                        "(3103009,31,'Antônio Dias')," +
                        "(3103108,31,'Antônio Prado de Minas')," +
                        "(3103207,31,'Araçaí')," +
                        "(3103306,31,'Aracitaba')," +
                        "(3103405,31,'Araçuaí')," +
                        "(3103504,31,'Araguari')," +
                        "(3103603,31,'Arantina')," +
                        "(3103702,31,'Araponga')," +
                        "(3103751,31,'Araporã')," +
                        "(3103801,31,'Arapuá')," +
                        "(3103900,31,'Araújos')," +
                        "(3104007,31,'Araxá')," +
                        "(3104106,31,'Arceburgo')," +
                        "(3104205,31,'Arcos')," +
                        "(3104304,31,'Areado')," +
                        "(3104403,31,'Argirita')," +
                        "(3104452,31,'Aricanduva')," +
                        "(3104502,31,'Arinos')," +
                        "(3104601,31,'Astolfo Dutra')," +
                        "(3104700,31,'Ataléia')," +
                        "(3104809,31,'Augusto de Lima')," +
                        "(3104908,31,'Baependi')," +
                        "(3105004,31,'Baldim')," +
                        "(3105103,31,'Bambuí')," +
                        "(3105202,31,'Bandeira')," +
                        "(3105301,31,'Bandeira do Sul')," +
                        "(3105400,31,'Barão de Cocais')," +
                        "(3105509,31,'Barão de Monte Alto')," +
                        "(3105608,31,'Barbacena')," +
                        "(3105707,31,'Barra Longa')," +
                        "(3105905,31,'Barroso')," +
                        "(3106002,31,'Bela Vista de Minas')," +
                        "(3106101,31,'Belmiro Braga')," +
                        "(3106200,31,'Belo Horizonte')," +
                        "(3106309,31,'Belo Oriente')," +
                        "(3106408,31,'Belo Vale')," +
                        "(3106507,31,'Berilo')," +
                        "(3106606,31,'Bertópolis')," +
                        "(3106655,31,'Berizal')," +
                        "(3106705,31,'Betim')," +
                        "(3106804,31,'Bias Fortes')," +
                        "(3106903,31,'Bicas')," +
                        "(3107000,31,'Biquinhas')," +
                        "(3107109,31,'Boa Esperança')," +
                        "(3107208,31,'Bocaina de Minas')," +
                        "(3107307,31,'Bocaiúva')," +
                        "(3107406,31,'Bom despacho')," +
                        "(3107505,31,'Bom Jardim de Minas')," +
                        "(3107604,31,'Bom Jesus da Penha')," +
                        "(3107703,31,'Bom Jesus do Amparo')," +
                        "(3107802,31,'Bom Jesus do Galho')," +
                        "(3107901,31,'Bom Repouso')," +
                        "(3108008,31,'Bom Sucesso')," +
                        "(3108107,31,'Bonfim')," +
                        "(3108206,31,'Bonfinópolis de Minas')," +
                        "(3108255,31,'Bonito de Minas')," +
                        "(3108305,31,'Borda da Mata')," +
                        "(3108404,31,'Botelhos')," +
                        "(3108503,31,'Botumirim')," +
                        "(3108552,31,'Brasilândia de Minas')," +
                        "(3108602,31,'Brasília de Minas')," +
                        "(3108701,31,'Brás Pires')," +
                        "(3108800,31,'Braúnas')," +
                        "(3108909,31,'Brazópolis')," +
                        "(3109006,31,'Brumadinho')," +
                        "(3109105,31,'Bueno Brandão')," +
                        "(3109204,31,'Buenópolis')," +
                        "(3109253,31,'Bugre')," +
                        "(3109303,31,'Buritis')," +
                        "(3109402,31,'Buritizeiro')," +
                        "(3109451,31,'Cabeceira Grande')," +
                        "(3109501,31,'Cabo Verde')," +
                        "(3109600,31,'Cachoeira da Prata')," +
                        "(3109709,31,'Cachoeira de Minas')," +
                        "(3109808,31,'Cachoeira dourada')," +
                        "(3109907,31,'Caetanópolis')," +
                        "(3110004,31,'Caeté')," +
                        "(3110103,31,'Caiana')," +
                        "(3110202,31,'Cajuri')," +
                        "(3110301,31,'Caldas')," +
                        "(3110400,31,'Camacho')," +
                        "(3110509,31,'Camanducaia')," +
                        "(3110608,31,'Cambuí')," +
                        "(3110707,31,'Cambuquira')," +
                        "(3110806,31,'Campanário')," +
                        "(3110905,31,'Campanha')," +
                        "(3111002,31,'Campestre')," +
                        "(3111101,31,'Campina Verde')," +
                        "(3111150,31,'Campo Azul')," +
                        "(3111200,31,'Campo Belo')," +
                        "(3111309,31,'Campo do Meio')," +
                        "(3111408,31,'Campo Florido')," +
                        "(3111507,31,'Campos Altos')," +
                        "(3111606,31,'Campos Gerais')," +
                        "(3111705,31,'Canaã')," +
                        "(3111804,31,'Canápolis')," +
                        "(3111903,31,'Cana Verde')," +
                        "(3112000,31,'Candeias')," +
                        "(3112059,31,'Cantagalo')," +
                        "(3112109,31,'Caparaó')," +
                        "(3112208,31,'Capela Nova')," +
                        "(3112307,31,'Capelinha')," +
                        "(3112406,31,'Capetinga')," +
                        "(3112505,31,'Capim Branco')," +
                        "(3112604,31,'Capinópolis')," +
                        "(3112653,31,'Capitão Andrade')," +
                        "(3112703,31,'Capitão Enéas')," +
                        "(3112802,31,'Capitólio')," +
                        "(3112901,31,'Caputira')," +
                        "(3113008,31,'Caraí')," +
                        "(3113107,31,'Caranaíba')," +
                        "(3113206,31,'Carandaí')," +
                        "(3113305,31,'Carangola')," +
                        "(3113404,31,'Caratinga')," +
                        "(3113503,31,'Carbonita')," +
                        "(3113602,31,'Careaçu')," +
                        "(3113701,31,'Carlos Chagas')," +
                        "(3113800,31,'Carmésia')," +
                        "(3113909,31,'Carmo da Cachoeira')," +
                        "(3114006,31,'Carmo da Mata')," +
                        "(3114105,31,'Carmo de Minas')," +
                        "(3114204,31,'Carmo do Cajuru')," +
                        "(3114303,31,'Carmo do Paranaíba')," +
                        "(3114402,31,'Carmo do Rio Claro')," +
                        "(3114501,31,'Carmópolis de Minas')," +
                        "(3114550,31,'Carneirinho')," +
                        "(3114600,31,'Carrancas')," +
                        "(3114709,31,'Carvalhópolis')," +
                        "(3114808,31,'Carvalhos')," +
                        "(3114907,31,'Casa Grande')," +
                        "(3115003,31,'Cascalho Rico')," +
                        "(3115102,31,'Cássia')," +
                        "(3115201,31,'Conceição da Barra de Minas')," +
                        "(3115300,31,'Cataguases')," +
                        "(3115359,31,'Catas Altas')," +
                        "(3115409,31,'Catas Altas da Noruega')," +
                        "(3115458,31,'Catuji')," +
                        "(3115474,31,'Catuti')," +
                        "(3115508,31,'Caxambu')," +
                        "(3115607,31,'Cedro do Abaeté')," +
                        "(3115706,31,'Central de Minas')," +
                        "(3115805,31,'Centralina')," +
                        "(3115904,31,'Chácara')," +
                        "(3116001,31,'Chalé')," +
                        "(3116100,31,'Chapada do Norte')," +
                        "(3116159,31,'Chapada Gaúcha')," +
                        "(3116209,31,'Chiador')," +
                        "(3116308,31,'Cipotânea')," +
                        "(3116407,31,'Claraval')," +
                        "(3116506,31,'Claro dos Poções')," +
                        "(3116605,31,'Cláudio')," +
                        "(3116704,31,'Coimbra')," +
                        "(3116803,31,'Coluna')," +
                        "(3116902,31,'Comendador Gomes')," +
                        "(3117009,31,'Comercinho')," +
                        "(3117108,31,'Conceição da Aparecida')," +
                        "(3117207,31,'Conceição das Pedras')," +
                        "(3117306,31,'Conceição das Alagoas')," +
                        "(3117405,31,'Conceição de Ipanema')," +
                        "(3117504,31,'Conceição do Mato dentro')," +
                        "(3117603,31,'Conceição do Pará')," +
                        "(3117702,31,'Conceição do Rio Verde')," +
                        "(3117801,31,'Conceição dos Ouros')," +
                        "(3117836,31,'Cônego Marinho')," +
                        "(3117876,31,'Confins')," +
                        "(3117900,31,'Congonhal')," +
                        "(3118007,31,'Congonhas')," +
                        "(3118106,31,'Congonhas do Norte')," +
                        "(3118205,31,'Conquista')," +
                        "(3118304,31,'Conselheiro Lafaiete')," +
                        "(3118403,31,'Conselheiro Pena')," +
                        "(3118502,31,'Consolação')," +
                        "(3118601,31,'Contagem')," +
                        "(3118700,31,'Coqueiral')," +
                        "(3118809,31,'Coração de Jesus')," +
                        "(3118908,31,'Cordisburgo')," +
                        "(3119005,31,'Cordislândia')," +
                        "(3119104,31,'Corinto')," +
                        "(3119203,31,'Coroaci')," +
                        "(3119302,31,'Coromandel')," +
                        "(3119401,31,'Coronel Fabriciano')," +
                        "(3119500,31,'Coronel Murta')," +
                        "(3119609,31,'Coronel Pacheco')," +
                        "(3119708,31,'Coronel Xavier Chaves')," +
                        "(3119807,31,'Córrego danta')," +
                        "(3119906,31,'Córrego do Bom Jesus')," +
                        "(3119955,31,'Córrego Fundo')," +
                        "(3120003,31,'Córrego Novo')," +
                        "(3120102,31,'Couto de Magalhães de Minas')," +
                        "(3120151,31,'Crisólita')," +
                        "(3120201,31,'Cristais')," +
                        "(3120300,31,'Cristália')," +
                        "(3120409,31,'Cristiano Otoni')," +
                        "(3120508,31,'Cristina')," +
                        "(3120607,31,'Crucilândia')," +
                        "(3120706,31,'Cruzeiro da Fortaleza')," +
                        "(3120805,31,'Cruzília')," +
                        "(3120839,31,'Cuparaque')," +
                        "(3120870,31,'Curral de dentro')," +
                        "(3120904,31,'Curvelo')," +
                        "(3121001,31,'datas')," +
                        "(3121100,31,'delfim Moreira')," +
                        "(3121209,31,'delfinópolis')," +
                        "(3121258,31,'delta')," +
                        "(3121308,31,'descoberto')," +
                        "(3121407,31,'desterro de Entre Rios')," +
                        "(3121506,31,'desterro do Melo')," +
                        "(3121605,31,'Diamantina')," +
                        "(3121704,31,'Diogo de Vasconcelos')," +
                        "(3121803,31,'Dionísio')," +
                        "(3121902,31,'Divinésia')," +
                        "(3122009,31,'Divino')," +
                        "(3122108,31,'Divino das Laranjeiras')," +
                        "(3122207,31,'Divinolândia de Minas')," +
                        "(3122306,31,'Divinópolis')," +
                        "(3122355,31,'Divisa Alegre')," +
                        "(3122405,31,'Divisa Nova')," +
                        "(3122454,31,'Divisópolis')," +
                        "(3122470,31,'dom Bosco')," +
                        "(3122504,31,'dom Cavati')," +
                        "(3122603,31,'dom Joaquim')," +
                        "(3122702,31,'dom Silvério')," +
                        "(3122801,31,'dom Viçoso')," +
                        "(3122900,31,'dona Eusébia')," +
                        "(3123007,31,'dores de Campos')," +
                        "(3123106,31,'dores de Guanhães')," +
                        "(3123205,31,'dores do Indaiá')," +
                        "(3123304,31,'dores do Turvo')," +
                        "(3123403,31,'doresópolis')," +
                        "(3123502,31,'douradoquara')," +
                        "(3123528,31,'Durandé')," +
                        "(3123601,31,'Elói Mendes')," +
                        "(3123700,31,'Engenheiro Caldas')," +
                        "(3123809,31,'Engenheiro Navarro')," +
                        "(3123858,31,'Entre Folhas')," +
                        "(3123908,31,'Entre Rios de Minas')," +
                        "(3124005,31,'Ervália')," +
                        "(3124104,31,'Esmeraldas')," +
                        "(3124203,31,'Espera Feliz')," +
                        "(3124302,31,'Espinosa')," +
                        "(3124401,31,'Espírito Santo do dourado')," +
                        "(3124500,31,'Estiva')," +
                        "(3124609,31,'Estrela dalva')," +
                        "(3124708,31,'Estrela do Indaiá')," +
                        "(3124807,31,'Estrela do Sul')," +
                        "(3124906,31,'Eugenópolis')," +
                        "(3125002,31,'Ewbank da Câmara')," +
                        "(3125101,31,'Extrema')," +
                        "(3125200,31,'Fama')," +
                        "(3125309,31,'Faria Lemos')," +
                        "(3125408,31,'Felício dos Santos')," +
                        "(3125507,31,'São Gonçalo do Rio Preto')," +
                        "(3125606,31,'Felisburgo')," +
                        "(3125705,31,'Felixlândia')," +
                        "(3125804,31,'Fernandes Tourinho')," +
                        "(3125903,31,'Ferros')," +
                        "(3125952,31,'Fervedouro')," +
                        "(3126000,31,'Florestal')," +
                        "(3126109,31,'Formiga')," +
                        "(3126208,31,'Formoso')," +
                        "(3126307,31,'Fortaleza de Minas')," +
                        "(3126406,31,'Fortuna de Minas')," +
                        "(3126505,31,'Francisco Badaró')," +
                        "(3126604,31,'Francisco Dumont')," +
                        "(3126703,31,'Francisco Sá')," +
                        "(3126752,31,'Franciscópolis')," +
                        "(3126802,31,'Frei Gaspar')," +
                        "(3126901,31,'Frei Inocêncio')," +
                        "(3126950,31,'Frei Lagonegro')," +
                        "(3127008,31,'Fronteira')," +
                        "(3127057,31,'Fronteira dos Vales')," +
                        "(3127073,31,'Fruta de Leite')," +
                        "(3127107,31,'Frutal')," +
                        "(3127206,31,'Funilândia')," +
                        "(3127305,31,'Galiléia')," +
                        "(3127339,31,'Gameleiras')," +
                        "(3127354,31,'Glaucilândia')," +
                        "(3127370,31,'Goiabeira')," +
                        "(3127388,31,'Goianá')," +
                        "(3127404,31,'Gonçalves')," +
                        "(3127503,31,'Gonzaga')," +
                        "(3127602,31,'Gouveia')," +
                        "(3127701,31,'Governador Valadares')," +
                        "(3127800,31,'Grão Mogol')," +
                        "(3127909,31,'Grupiara')," +
                        "(3128006,31,'Guanhães')," +
                        "(3128105,31,'Guapé')," +
                        "(3128204,31,'Guaraciaba')," +
                        "(3128253,31,'Guaraciama')," +
                        "(3128303,31,'Guaranésia')," +
                        "(3128402,31,'Guarani')," +
                        "(3128501,31,'Guarará')," +
                        "(3128600,31,'Guarda-Mor')," +
                        "(3128709,31,'Guaxupé')," +
                        "(3128808,31,'Guidoval')," +
                        "(3128907,31,'Guimarânia')," +
                        "(3129004,31,'Guiricema')," +
                        "(3129103,31,'Gurinhatã')," +
                        "(3129202,31,'Heliodora')," +
                        "(3129301,31,'Iapu')," +
                        "(3129400,31,'Ibertioga')," +
                        "(3129509,31,'Ibiá')," +
                        "(3129608,31,'Ibiaí')," +
                        "(3129657,31,'Ibiracatu')," +
                        "(3129707,31,'Ibiraci')," +
                        "(3129806,31,'Ibirité')," +
                        "(3129905,31,'Ibitiúra de Minas')," +
                        "(3130002,31,'Ibituruna')," +
                        "(3130051,31,'Icaraí de Minas')," +
                        "(3130101,31,'Igarapé')," +
                        "(3130200,31,'Igaratinga')," +
                        "(3130309,31,'Iguatama')," +
                        "(3130408,31,'Ijaci')," +
                        "(3130507,31,'Ilicínea')," +
                        "(3130556,31,'Imbé de Minas')," +
                        "(3130606,31,'Inconfidentes')," +
                        "(3130655,31,'Indaiabira')," +
                        "(3130705,31,'Indianópolis')," +
                        "(3130804,31,'Ingaí')," +
                        "(3130903,31,'Inhapim')," +
                        "(3131000,31,'Inhaúma')," +
                        "(3131109,31,'Inimutaba')," +
                        "(3131158,31,'Ipaba')," +
                        "(3131208,31,'Ipanema')," +
                        "(3131307,31,'Ipatinga')," +
                        "(3131406,31,'Ipiaçu')," +
                        "(3131505,31,'Ipuiúna')," +
                        "(3131604,31,'Iraí de Minas')," +
                        "(3131703,31,'Itabira')," +
                        "(3131802,31,'Itabirinha')," +
                        "(3131901,31,'Itabirito')," +
                        "(3132008,31,'Itacambira')," +
                        "(3132107,31,'Itacarambi')," +
                        "(3132206,31,'Itaguara')," +
                        "(3132305,31,'Itaipé')," +
                        "(3132404,31,'Itajubá')," +
                        "(3132503,31,'Itamarandiba')," +
                        "(3132602,31,'Itamarati de Minas')," +
                        "(3132701,31,'Itambacuri')," +
                        "(3132800,31,'Itambé do Mato dentro')," +
                        "(3132909,31,'Itamogi')," +
                        "(3133006,31,'Itamonte')," +
                        "(3133105,31,'Itanhandu')," +
                        "(3133204,31,'Itanhomi')," +
                        "(3133303,31,'Itaobim')," +
                        "(3133402,31,'Itapagipe')," +
                        "(3133501,31,'Itapecerica')," +
                        "(3133600,31,'Itapeva')," +
                        "(3133709,31,'Itatiaiuçu')," +
                        "(3133758,31,'Itaú de Minas')," +
                        "(3133808,31,'Itaúna')," +
                        "(3133907,31,'Itaverava')," +
                        "(3134004,31,'Itinga')," +
                        "(3134103,31,'Itueta')," +
                        "(3134202,31,'Ituiutaba')," +
                        "(3134301,31,'Itumirim')," +
                        "(3134400,31,'Iturama')," +
                        "(3134509,31,'Itutinga')," +
                        "(3134608,31,'Jaboticatubas')," +
                        "(3134707,31,'Jacinto')," +
                        "(3134806,31,'Jacuí')," +
                        "(3134905,31,'Jacutinga')," +
                        "(3135001,31,'Jaguaraçu')," +
                        "(3135050,31,'Jaíba')," +
                        "(3135076,31,'Jampruca')," +
                        "(3135100,31,'Janaúba')," +
                        "(3135209,31,'Januária')," +
                        "(3135308,31,'Japaraíba')," +
                        "(3135357,31,'Japonvar')," +
                        "(3135407,31,'Jeceaba')," +
                        "(3135456,31,'Jenipapo de Minas')," +
                        "(3135506,31,'Jequeri')," +
                        "(3135605,31,'Jequitaí')," +
                        "(3135704,31,'Jequitibá')," +
                        "(3135803,31,'Jequitinhonha')," +
                        "(3135902,31,'Jesuânia')," +
                        "(3136009,31,'Joaíma')," +
                        "(3136108,31,'Joanésia')," +
                        "(3136207,31,'João Monlevade')," +
                        "(3136306,31,'João Pinheiro')," +
                        "(3136405,31,'Joaquim Felício')," +
                        "(3136504,31,'Jordânia')," +
                        "(3136520,31,'José Gonçalves de Minas')," +
                        "(3136553,31,'José Raydan')," +
                        "(3136579,31,'Josenópolis')," +
                        "(3136603,31,'Nova União')," +
                        "(3136652,31,'Juatuba')," +
                        "(3136702,31,'Juiz de Fora')," +
                        "(3136801,31,'Juramento')," +
                        "(3136900,31,'Juruaia')," +
                        "(3136959,31,'Juvenília')," +
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
                        "(3138682,31,'Luislândia')," +
                        "(3138708,31,'Luminárias')," +
                        "(3138807,31,'Luz')," +
                        "(3138906,31,'Machacalis')," +
                        "(3139003,31,'Machado')," +
                        "(3139102,31,'Madre de deus de Minas')," +
                        "(3139201,31,'Malacacheta')," +
                        "(3139250,31,'Mamonas')," +
                        "(3139300,31,'Manga')," +
                        "(3139409,31,'Manhuaçu')," +
                        "(3139508,31,'Manhumirim')," +
                        "(3139607,31,'Mantena')," +
                        "(3139706,31,'Maravilhas')," +
                        "(3139805,31,'Mar de Espanha')," +
                        "(3139904,31,'Maria da Fé')," +
                        "(3140001,31,'Mariana')," +
                        "(3140100,31,'Marilac')," +
                        "(3140159,31,'Mário Campos')," +
                        "(3140209,31,'Maripá de Minas')," +
                        "(3140308,31,'Marliéria')," +
                        "(3140407,31,'Marmelópolis')," +
                        "(3140506,31,'Martinho Campos')," +
                        "(3140530,31,'Martins Soares')," +
                        "(3140555,31,'Mata Verde')," +
                        "(3140605,31,'Materlândia')," +
                        "(3140704,31,'Mateus Leme')," +
                        "(3140803,31,'Matias Barbosa')," +
                        "(3140852,31,'Matias Cardoso')," +
                        "(3140902,31,'Matipó')," +
                        "(3141009,31,'Mato Verde')," +
                        "(3141108,31,'Matozinhos')," +
                        "(3141207,31,'Matutina')," +
                        "(3141306,31,'Medeiros')," +
                        "(3141405,31,'Medina')," +
                        "(3141504,31,'Mendes Pimentel')," +
                        "(3141603,31,'Mercês')," +
                        "(3141702,31,'Mesquita')," +
                        "(3141801,31,'Minas Novas')," +
                        "(3141900,31,'Minduri')," +
                        "(3142007,31,'Mirabela')," +
                        "(3142106,31,'Miradouro')," +
                        "(3142205,31,'Miraí')," +
                        "(3142254,31,'Miravânia')," +
                        "(3142304,31,'Moeda')," +
                        "(3142403,31,'Moema')," +
                        "(3142502,31,'Monjolos')," +
                        "(3142601,31,'Monsenhor Paulo')," +
                        "(3142700,31,'Montalvânia')," +
                        "(3142809,31,'Monte Alegre de Minas')," +
                        "(3142908,31,'Monte Azul')," +
                        "(3143005,31,'Monte Belo')," +
                        "(3143104,31,'Monte Carmelo')," +
                        "(3143153,31,'Monte Formoso')," +
                        "(3143203,31,'Monte Santo de Minas')," +
                        "(3143302,31,'Montes Claros')," +
                        "(3143401,31,'Monte Sião')," +
                        "(3143450,31,'Montezuma')," +
                        "(3143500,31,'Morada Nova de Minas')," +
                        "(3143609,31,'Morro da Garça')," +
                        "(3143708,31,'Morro do Pilar')," +
                        "(3143807,31,'Munhoz')," +
                        "(3143906,31,'Muriaé')," +
                        "(3144003,31,'Mutum')," +
                        "(3144102,31,'Muzambinho')," +
                        "(3144201,31,'Nacip Raydan')," +
                        "(3144300,31,'Nanuque')," +
                        "(3144359,31,'Naque')," +
                        "(3144375,31,'Natalândia')," +
                        "(3144409,31,'Natércia')," +
                        "(3144508,31,'Nazareno')," +
                        "(3144607,31,'Nepomuceno')," +
                        "(3144656,31,'Ninheira')," +
                        "(3144672,31,'Nova Belém')," +
                        "(3144706,31,'Nova Era')," +
                        "(3144805,31,'Nova Lima')," +
                        "(3144904,31,'Nova Módica')," +
                        "(3145000,31,'Nova Ponte')," +
                        "(3145059,31,'Nova Porteirinha')," +
                        "(3145109,31,'Nova Resende')," +
                        "(3145208,31,'Nova Serrana')," +
                        "(3145307,31,'Novo Cruzeiro')," +
                        "(3145356,31,'Novo Oriente de Minas')," +
                        "(3145372,31,'Novorizonte')," +
                        "(3145406,31,'Olaria')," +
                        "(3145455,31,'Olhos-Dágua')," +
                        "(3145505,31,'Olímpio Noronha')," +
                        "(3145604,31,'Oliveira')," +
                        "(3145703,31,'Oliveira Fortes')," +
                        "(3145802,31,'Onça de Pitangui')," +
                        "(3145851,31,'Oratórios')," +
                        "(3145877,31,'Orizânia')," +
                        "(3145901,31,'Ouro Branco')," +
                        "(3146008,31,'Ouro Fino')," +
                        "(3146107,31,'Ouro Preto')," +
                        "(3146206,31,'Ouro Verde de Minas')," +
                        "(3146255,31,'Padre Carvalho')," +
                        "(3146305,31,'Padre Paraíso')," +
                        "(3146404,31,'Paineiras')," +
                        "(3146503,31,'Pains')," +
                        "(3146552,31,'Pai Pedro')," +
                        "(3146602,31,'Paiva')," +
                        "(3146701,31,'Palma')," +
                        "(3146750,31,'Palmópolis')," +
                        "(3146909,31,'Papagaios')," +
                        "(3147006,31,'Paracatu')," +
                        "(3147105,31,'Pará de Minas')," +
                        "(3147204,31,'Paraguaçu')," +
                        "(3147303,31,'Paraisópolis')," +
                        "(3147402,31,'Paraopeba')," +
                        "(3147501,31,'Passabém')," +
                        "(3147600,31,'Passa Quatro')," +
                        "(3147709,31,'Passa Tempo')," +
                        "(3147808,31,'Passa-Vinte')," +
                        "(3147907,31,'Passos')," +
                        "(3147956,31,'Patis')," +
                        "(3148004,31,'Patos de Minas')," +
                        "(3148103,31,'Patrocínio')," +
                        "(3148202,31,'Patrocínio do Muriaé')," +
                        "(3148301,31,'Paula Cândido')," +
                        "(3148400,31,'Paulistas')," +
                        "(3148509,31,'Pavão')," +
                        "(3148608,31,'Peçanha')," +
                        "(3148707,31,'Pedra Azul')," +
                        "(3148756,31,'Pedra Bonita')," +
                        "(3148806,31,'Pedra do Anta')," +
                        "(3148905,31,'Pedra do Indaiá')," +
                        "(3149002,31,'Pedra dourada')," +
                        "(3149101,31,'Pedralva')," +
                        "(3149150,31,'Pedras de Maria da Cruz')," +
                        "(3149200,31,'Pedrinópolis')," +
                        "(3149309,31,'Pedro Leopoldo')," +
                        "(3149408,31,'Pedro Teixeira')," +
                        "(3149507,31,'Pequeri')," +
                        "(3149606,31,'Pequi')," +
                        "(3149705,31,'Perdigão')," +
                        "(3149804,31,'Perdizes')," +
                        "(3149903,31,'Perdões')," +
                        "(3149952,31,'Periquito')," +
                        "(3150000,31,'Pescador')," +
                        "(3150109,31,'Piau')," +
                        "(3150158,31,'Piedade de Caratinga')," +
                        "(3150208,31,'Piedade de Ponte Nova')," +
                        "(3150307,31,'Piedade do Rio Grande')," +
                        "(3150406,31,'Piedade dos Gerais')," +
                        "(3150505,31,'Pimenta')," +
                        "(3150539,31,'Pingo-Dágua')," +
                        "(3150570,31,'Pintópolis')," +
                        "(3150604,31,'Piracema')," +
                        "(3150703,31,'Pirajuba')," +
                        "(3150802,31,'Piranga')," +
                        "(3150901,31,'Piranguçu')," +
                        "(3151008,31,'Piranguinho')," +
                        "(3151107,31,'Pirapetinga')," +
                        "(3151206,31,'Pirapora')," +
                        "(3151305,31,'Piraúba')," +
                        "(3151404,31,'Pitangui')," +
                        "(3151503,31,'Piumhi')," +
                        "(3151602,31,'Planura')," +
                        "(3151701,31,'Poço Fundo')," +
                        "(3151800,31,'Poços de Caldas')," +
                        "(3151909,31,'Pocrane')," +
                        "(3152006,31,'Pompéu')," +
                        "(3152105,31,'Ponte Nova')," +
                        "(3152131,31,'Ponto Chique')," +
                        "(3152170,31,'Ponto dos Volantes')," +
                        "(3152204,31,'Porteirinha')," +
                        "(3152303,31,'Porto Firme')," +
                        "(3152402,31,'Poté')," +
                        "(3152501,31,'Pouso Alegre')," +
                        "(3152600,31,'Pouso Alto')," +
                        "(3152709,31,'Prados')," +
                        "(3152808,31,'Prata')," +
                        "(3152907,31,'Pratápolis')," +
                        "(3153004,31,'Pratinha')," +
                        "(3153103,31,'Presidente Bernardes')," +
                        "(3153202,31,'Presidente Juscelino')," +
                        "(3153301,31,'Presidente Kubitschek')," +
                        "(3153400,31,'Presidente Olegário')," +
                        "(3153509,31,'Alto Jequitibá')," +
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
                        "(3154606,31,'Ribeirão das Neves')," +
                        "(3154705,31,'Ribeirão Vermelho')," +
                        "(3154804,31,'Rio Acima')," +
                        "(3154903,31,'Rio Casca')," +
                        "(3155009,31,'Rio doce')," +
                        "(3155108,31,'Rio do Prado')," +
                        "(3155207,31,'Rio Espera')," +
                        "(3155306,31,'Rio Manso')," +
                        "(3155405,31,'Rio Novo')," +
                        "(3155504,31,'Rio Paranaíba')," +
                        "(3155603,31,'Rio Pardo de Minas')," +
                        "(3155702,31,'Rio Piracicaba')," +
                        "(3155801,31,'Rio Pomba')," +
                        "(3155900,31,'Rio Preto')," +
                        "(3156007,31,'Rio Vermelho')," +
                        "(3156106,31,'Ritápolis')," +
                        "(3156205,31,'Rochedo de Minas')," +
                        "(3156304,31,'Rodeiro')," +
                        "(3156403,31,'Romaria')," +
                        "(3156452,31,'Rosário da Limeira')," +
                        "(3156502,31,'Rubelita')," +
                        "(3156601,31,'Rubim')," +
                        "(3156700,31,'Sabará')," +
                        "(3156809,31,'Sabinópolis')," +
                        "(3156908,31,'Sacramento')," +
                        "(3157005,31,'Salinas')," +
                        "(3157104,31,'Salto da Divisa')," +
                        "(3157203,31,'Santa Bárbara')," +
                        "(3157252,31,'Santa Bárbara do Leste')," +
                        "(3157278,31,'Santa Bárbara do Monte Verde')," +
                        "(3157302,31,'Santa Bárbara do Tugúrio')," +
                        "(3157336,31,'Santa Cruz de Minas')," +
                        "(3157377,31,'Santa Cruz de Salinas')," +
                        "(3157401,31,'Santa Cruz do Escalvado')," +
                        "(3157500,31,'Santa Efigênia de Minas')," +
                        "(3157609,31,'Santa Fé de Minas')," +
                        "(3157658,31,'Santa Helena de Minas')," +
                        "(3157708,31,'Santa Juliana')," +
                        "(3157807,31,'Santa Luzia')," +
                        "(3157906,31,'Santa Margarida')," +
                        "(3158003,31,'Santa Maria de Itabira')," +
                        "(3158102,31,'Santa Maria do Salto')," +
                        "(3158201,31,'Santa Maria do Suaçuí')," +
                        "(3158300,31,'Santana da Vargem')," +
                        "(3158409,31,'Santana de Cataguases')," +
                        "(3158508,31,'Santana de Pirapama')," +
                        "(3158607,31,'Santana do deserto')," +
                        "(3158706,31,'Santana do Garambéu')," +
                        "(3158805,31,'Santana do Jacaré')," +
                        "(3158904,31,'Santana do Manhuaçu')," +
                        "(3158953,31,'Santana do Paraíso')," +
                        "(3159001,31,'Santana do Riacho')," +
                        "(3159100,31,'Santana dos Montes')," +
                        "(3159209,31,'Santa Rita de Caldas')," +
                        "(3159308,31,'Santa Rita de Jacutinga')," +
                        "(3159357,31,'Santa Rita de Minas')," +
                        "(3159407,31,'Santa Rita de Ibitipoca')," +
                        "(3159506,31,'Santa Rita do Itueto')," +
                        "(3159605,31,'Santa Rita do Sapucaí')," +
                        "(3159704,31,'Santa Rosa da Serra')," +
                        "(3159803,31,'Santa Vitória')," +
                        "(3159902,31,'Santo Antônio do Amparo')," +
                        "(3160009,31,'Santo Antônio do Aventureiro')," +
                        "(3160108,31,'Santo Antônio do Grama')," +
                        "(3160207,31,'Santo Antônio do Itambé')," +
                        "(3160306,31,'Santo Antônio do Jacinto')," +
                        "(3160405,31,'Santo Antônio do Monte')," +
                        "(3160454,31,'Santo Antônio do Retiro')," +
                        "(3160504,31,'Santo Antônio do Rio Abaixo')," +
                        "(3160603,31,'Santo Hipólito')," +
                        "(3160702,31,'Santos Dumont')," +
                        "(3160801,31,'São Bento Abade')," +
                        "(3160900,31,'São Brás do Suaçuí')," +
                        "(3160959,31,'São domingos das dores')," +
                        "(3161007,31,'São domingos do Prata')," +
                        "(3161056,31,'São Félix de Minas')," +
                        "(3161106,31,'São Francisco')," +
                        "(3161205,31,'São Francisco de Paula')," +
                        "(3161304,31,'São Francisco de Sales')," +
                        "(3161403,31,'São Francisco do Glória')," +
                        "(3161502,31,'São Geraldo')," +
                        "(3161601,31,'São Geraldo da Piedade')," +
                        "(3161650,31,'São Geraldo do Baixio')," +
                        "(3161700,31,'São Gonçalo do Abaeté')," +
                        "(3161809,31,'São Gonçalo do Pará')," +
                        "(3161908,31,'São Gonçalo do Rio Abaixo')," +
                        "(3162005,31,'São Gonçalo do Sapucaí')," +
                        "(3162104,31,'São Gotardo')," +
                        "(3162203,31,'São João Batista do Glória')," +
                        "(3162252,31,'São João da Lagoa')," +
                        "(3162302,31,'São João da Mata')," +
                        "(3162401,31,'São João da Ponte')," +
                        "(3162450,31,'São João das Missões')," +
                        "(3162500,31,'São João del Rei')," +
                        "(3162559,31,'São João do Manhuaçu')," +
                        "(3162575,31,'São João do Manteninha')," +
                        "(3162609,31,'São João do Oriente')," +
                        "(3162658,31,'São João do Pacuí')," +
                        "(3162708,31,'São João do Paraíso')," +
                        "(3162807,31,'São João Evangelista')," +
                        "(3162906,31,'São João Nepomuceno')," +
                        "(3162922,31,'São Joaquim de Bicas')," +
                        "(3162948,31,'São José da Barra')," +
                        "(3162955,31,'São José da Lapa')," +
                        "(3163003,31,'São José da Safira')," +
                        "(3163102,31,'São José da Varginha')," +
                        "(3163201,31,'São José do Alegre')," +
                        "(3163300,31,'São José do Divino')," +
                        "(3163409,31,'São José do Goiabal')," +
                        "(3163508,31,'São José do Jacuri')," +
                        "(3163607,31,'São José do Mantimento')," +
                        "(3163706,31,'São Lourenço')," +
                        "(3163805,31,'São Miguel do Anta')," +
                        "(3163904,31,'São Pedro da União')," +
                        "(3164001,31,'São Pedro dos Ferros')," +
                        "(3164100,31,'São Pedro do Suaçuí')," +
                        "(3164209,31,'São Romão')," +
                        "(3164308,31,'São Roque de Minas')," +
                        "(3164407,31,'São Sebastião da Bela Vista')," +
                        "(3164431,31,'São Sebastião da Vargem Alegre')," +
                        "(3164472,31,'São Sebastião do Anta')," +
                        "(3164506,31,'São Sebastião do Maranhão')," +
                        "(3164605,31,'São Sebastião do Oeste')," +
                        "(3164704,31,'São Sebastião do Paraíso')," +
                        "(3164803,31,'São Sebastião do Rio Preto')," +
                        "(3164902,31,'São Sebastião do Rio Verde')," +
                        "(3165008,31,'São Tiago')," +
                        "(3165107,31,'São Tomás de Aquino')," +
                        "(3165206,31,'São Thomé das Letras')," +
                        "(3165305,31,'São Vicente de Minas')," +
                        "(3165404,31,'Sapucaí-Mirim')," +
                        "(3165503,31,'Sardoá')," +
                        "(3165537,31,'Sarzedo')," +
                        "(3165552,31,'Setubinha')," +
                        "(3165560,31,'Sem-Peixe')," +
                        "(3165578,31,'Senador Amaral')," +
                        "(3165602,31,'Senador Cortes')," +
                        "(3165701,31,'Senador Firmino')," +
                        "(3165800,31,'Senador José Bento')," +
                        "(3165909,31,'Senador Modestino Gonçalves')," +
                        "(3166006,31,'Senhora de Oliveira')," +
                        "(3166105,31,'Senhora do Porto')," +
                        "(3166204,31,'Senhora dos Remédios')," +
                        "(3166303,31,'Sericita')," +
                        "(3166402,31,'Seritinga')," +
                        "(3166501,31,'Serra Azul de Minas')," +
                        "(3166600,31,'Serra da Saudade')," +
                        "(3166709,31,'Serra dos Aimorés')," +
                        "(3166808,31,'Serra do Salitre')," +
                        "(3166907,31,'Serrania')," +
                        "(3166956,31,'Serranópolis de Minas')," +
                        "(3167004,31,'Serranos')," +
                        "(3167103,31,'Serro')," +
                        "(3167202,31,'Sete Lagoas')," +
                        "(3167301,31,'Silveirânia')," +
                        "(3167400,31,'Silvianópolis')," +
                        "(3167509,31,'Simão Pereira')," +
                        "(3167608,31,'Simonésia')," +
                        "(3167707,31,'Sobrália')," +
                        "(3167806,31,'Soledade de Minas')," +
                        "(3167905,31,'Tabuleiro')," +
                        "(3168002,31,'Taiobeiras')," +
                        "(3168051,31,'Taparuba')," +
                        "(3168101,31,'Tapira')," +
                        "(3168200,31,'Tapiraí')," +
                        "(3168309,31,'Taquaraçu de Minas')," +
                        "(3168408,31,'Tarumirim')," +
                        "(3168507,31,'Teixeiras')," +
                        "(3168606,31,'Teófilo Otoni')," +
                        "(3168705,31,'Timóteo')," +
                        "(3168804,31,'Tiradentes')," +
                        "(3168903,31,'Tiros')," +
                        "(3169000,31,'Tocantins')," +
                        "(3169059,31,'Tocos do Moji')," +
                        "(3169109,31,'Toledo')," +
                        "(3169208,31,'Tombos')," +
                        "(3169307,31,'Três Corações')," +
                        "(3169356,31,'Três Marias')," +
                        "(3169406,31,'Três Pontas')," +
                        "(3169505,31,'Tumiritinga')," +
                        "(3169604,31,'Tupaciguara')," +
                        "(3169703,31,'Turmalina')," +
                        "(3169802,31,'Turvolândia')," +
                        "(3169901,31,'Ubá')," +
                        "(3170008,31,'Ubaí')," +
                        "(3170057,31,'Ubaporanga')," +
                        "(3170107,31,'Uberaba')," +
                        "(3170206,31,'Uberlândia')," +
                        "(3170305,31,'Umburatiba')," +
                        "(3170404,31,'Unaí')," +
                        "(3170438,31,'União de Minas')," +
                        "(3170479,31,'Uruana de Minas')," +
                        "(3170503,31,'Urucânia')," +
                        "(3170529,31,'Urucuia')," +
                        "(3170578,31,'Vargem Alegre')," +
                        "(3170602,31,'Vargem Bonita')," +
                        "(3170651,31,'Vargem Grande do Rio Pardo')," +
                        "(3170701,31,'Varginha')," +
                        "(3170750,31,'Varjão de Minas')," +
                        "(3170800,31,'Várzea da Palma')," +
                        "(3170909,31,'Varzelândia')," +
                        "(3171006,31,'Vazante')," +
                        "(3171030,31,'Verdelândia')," +
                        "(3171071,31,'Veredinha')," +
                        "(3171105,31,'Veríssimo')," +
                        "(3171154,31,'Vermelho Novo')," +
                        "(3171204,31,'Vespasiano')," +
                        "(3171303,31,'Viçosa')," +
                        "(3171402,31,'Vieiras')," +
                        "(3171501,31,'Mathias Lobato')," +
                        "(3171600,31,'Virgem da Lapa')," +
                        "(3171709,31,'Virgínia')," +
                        "(3171808,31,'Virginópolis')," +
                        "(3171907,31,'Virgolândia')," +
                        "(3172004,31,'Visconde do Rio Branco')," +
                        "(3172103,31,'Volta Grande')," +
                        "(3172202,31,'Wenceslau Braz')," +
                        "(3200102,32,'Afonso Cláudio')," +
                        "(3200136,32,'Águia Branca')," +
                        "(3200169,32,'Água doce do Norte')," +
                        "(3200201,32,'Alegre')," +
                        "(3200300,32,'Alfredo Chaves')," +
                        "(3200359,32,'Alto Rio Novo')," +
                        "(3200409,32,'Anchieta')," +
                        "(3200508,32,'Apiacá')," +
                        "(3200607,32,'Aracruz')," +
                        "(3200706,32,'Atilio Vivacqua')," +
                        "(3200805,32,'Baixo Guandu')," +
                        "(3200904,32,'Barra de São Francisco')," +
                        "(3201001,32,'Boa Esperança')," +
                        "(3201100,32,'Bom Jesus do Norte')," +
                        "(3201159,32,'Brejetuba')," +
                        "(3201209,32,'Cachoeiro de Itapemirim')," +
                        "(3201308,32,'Cariacica')," +
                        "(3201407,32,'Castelo')," +
                        "(3201506,32,'Colatina')," +
                        "(3201605,32,'Conceição da Barra')," +
                        "(3201704,32,'Conceição do Castelo')," +
                        "(3201803,32,'Divino de São Lourenço')," +
                        "(3201902,32,'domingos Martins')," +
                        "(3202009,32,'dores do Rio Preto')," +
                        "(3202108,32,'Ecoporanga')," +
                        "(3202207,32,'Fundão')," +
                        "(3202256,32,'Governador Lindenberg')," +
                        "(3202306,32,'Guaçuí')," +
                        "(3202405,32,'Guarapari')," +
                        "(3202454,32,'Ibatiba')," +
                        "(3202504,32,'Ibiraçu')," +
                        "(3202553,32,'Ibitirama')," +
                        "(3202603,32,'Iconha')," +
                        "(3202652,32,'Irupi')," +
                        "(3202702,32,'Itaguaçu')," +
                        "(3202801,32,'Itapemirim')," +
                        "(3202900,32,'Itarana')," +
                        "(3203007,32,'Iúna')," +
                        "(3203056,32,'Jaguaré')," +
                        "(3203106,32,'Jerônimo Monteiro')," +
                        "(3203130,32,'João Neiva')," +
                        "(3203163,32,'Laranja da Terra')," +
                        "(3203205,32,'Linhares')," +
                        "(3203304,32,'Mantenópolis')," +
                        "(3203320,32,'Marataízes')," +
                        "(3203346,32,'Marechal Floriano')," +
                        "(3203353,32,'Marilândia')," +
                        "(3203403,32,'Mimoso do Sul')," +
                        "(3203502,32,'Montanha')," +
                        "(3203601,32,'Mucurici')," +
                        "(3203700,32,'Muniz Freire')," +
                        "(3203809,32,'Muqui')," +
                        "(3203908,32,'Nova Venécia')," +
                        "(3204005,32,'Pancas')," +
                        "(3204054,32,'Pedro Canário')," +
                        "(3204104,32,'Pinheiros')," +
                        "(3204203,32,'Piúma')," +
                        "(3204252,32,'Ponto Belo')," +
                        "(3204302,32,'Presidente Kennedy')," +
                        "(3204351,32,'Rio Bananal')," +
                        "(3204401,32,'Rio Novo do Sul')," +
                        "(3204500,32,'Santa Leopoldina')," +
                        "(3204559,32,'Santa Maria de Jetibá')," +
                        "(3204609,32,'Santa Teresa')," +
                        "(3204658,32,'São domingos do Norte')," +
                        "(3204708,32,'São Gabriel da Palha')," +
                        "(3204807,32,'São José do Calçado')," +
                        "(3204906,32,'São Mateus')," +
                        "(3204955,32,'São Roque do Canaã')," +
                        "(3205002,32,'Serra')," +
                        "(3205010,32,'Sooretama')," +
                        "(3205036,32,'Vargem Alta')," +
                        "(3205069,32,'Venda Nova do Imigrante')," +
                        "(3205101,32,'Viana')," +
                        "(3205150,32,'Vila Pavão')," +
                        "(3205176,32,'Vila Valério')," +
                        "(3205200,32,'Vila Velha')," +
                        "(3205309,32,'Vitória')," +
                        "(3300100,33,'Angra dos Reis')," +
                        "(3300159,33,'Aperibé')," +
                        "(3300209,33,'Araruama')," +
                        "(3300225,33,'Areal')," +
                        "(3300233,33,'Armação dos Búzios')," +
                        "(3300258,33,'Arraial do Cabo')," +
                        "(3300308,33,'Barra do Piraí')," +
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
                        "(3301405,33,'Conceição de Macabu')," +
                        "(3301504,33,'Cordeiro')," +
                        "(3301603,33,'Duas Barras')," +
                        "(3301702,33,'Duque de Caxias')," +
                        "(3301801,33,'Engenheiro Paulo de Frontin')," +
                        "(3301850,33,'Guapimirim')," +
                        "(3301876,33,'Iguaba Grande')," +
                        "(3301900,33,'Itaboraí')," +
                        "(3302007,33,'Itaguaí')," +
                        "(3302056,33,'Italva')," +
                        "(3302106,33,'Itaocara')," +
                        "(3302205,33,'Itaperuna')," +
                        "(3302254,33,'Itatiaia')," +
                        "(3302270,33,'Japeri')," +
                        "(3302304,33,'Laje do Muriaé')," +
                        "(3302403,33,'Macaé')," +
                        "(3302452,33,'Macuco')," +
                        "(3302502,33,'Magé')," +
                        "(3302601,33,'Mangaratiba')," +
                        "(3302700,33,'Maricá')," +
                        "(3302809,33,'Mendes')," +
                        "(3302858,33,'Mesquita')," +
                        "(3302908,33,'Miguel Pereira')," +
                        "(3303005,33,'Miracema')," +
                        "(3303104,33,'Natividade')," +
                        "(3303203,33,'Nilópolis')," +
                        "(3303302,33,'Niterói')," +
                        "(3303401,33,'Nova Friburgo')," +
                        "(3303500,33,'Nova Iguaçu')," +
                        "(3303609,33,'Paracambi')," +
                        "(3303708,33,'Paraíba do Sul')," +
                        "(3303807,33,'Paraty')," +
                        "(3303856,33,'Paty do Alferes')," +
                        "(3303906,33,'Petrópolis')," +
                        "(3303955,33,'Pinheiral')," +
                        "(3304003,33,'Piraí')," +
                        "(3304102,33,'Porciúncula')," +
                        "(3304110,33,'Porto Real')," +
                        "(3304128,33,'Quatis')," +
                        "(3304144,33,'Queimados')," +
                        "(3304151,33,'Quissamã')," +
                        "(3304201,33,'Resende')," +
                        "(3304300,33,'Rio Bonito')," +
                        "(3304409,33,'Rio Claro')," +
                        "(3304508,33,'Rio das Flores')," +
                        "(3304524,33,'Rio das Ostras')," +
                        "(3304557,33,'Rio de Janeiro')," +
                        "(3304607,33,'Santa Maria Madalena')," +
                        "(3304706,33,'Santo Antônio de Pádua')," +
                        "(3304755,33,'São Francisco de Itabapoana')," +
                        "(3304805,33,'São Fidélis')," +
                        "(3304904,33,'São Gonçalo')," +
                        "(3305000,33,'São João da Barra')," +
                        "(3305109,33,'São João de Meriti')," +
                        "(3305133,33,'São José de Ubá')," +
                        "(3305158,33,'São José do Vale do Rio Preto')," +
                        "(3305208,33,'São Pedro da Aldeia')," +
                        "(3305307,33,'São Sebastião do Alto')," +
                        "(3305406,33,'Sapucaia')," +
                        "(3305505,33,'Saquarema')," +
                        "(3305554,33,'Seropédica')," +
                        "(3305604,33,'Silva Jardim')," +
                        "(3305703,33,'Sumidouro')," +
                        "(3305752,33,'Tanguá')," +
                        "(3305802,33,'Teresópolis')," +
                        "(3305901,33,'Trajano de Moraes')," +
                        "(3306008,33,'Três Rios')," +
                        "(3306107,33,'Valença')," +
                        "(3306156,33,'Varre-Sai')," +
                        "(3306206,33,'Vassouras')," +
                        "(3306305,33,'Volta Redonda')," +
                        "(3500105,35,'Adamantina')," +
                        "(3500204,35,'Adolfo')," +
                        "(3500303,35,'Aguaí')," +
                        "(3500402,35,'Águas da Prata')," +
                        "(3500501,35,'Águas de Lindóia')," +
                        "(3500550,35,'Águas de Santa Bárbara')," +
                        "(3500600,35,'Águas de São Pedro')," +
                        "(3500709,35,'Agudos')," +
                        "(3500758,35,'Alambari')," +
                        "(3500808,35,'Alfredo Marcondes')," +
                        "(3500907,35,'Altair')," +
                        "(3501004,35,'Altinópolis')," +
                        "(3501103,35,'Alto Alegre')," +
                        "(3501152,35,'Alumínio')," +
                        "(3501202,35,'Álvares Florence')," +
                        "(3501301,35,'Álvares Machado')," +
                        "(3501400,35,'Álvaro de Carvalho')," +
                        "(3501509,35,'Alvinlândia')," +
                        "(3501608,35,'Americana')," +
                        "(3501707,35,'Américo Brasiliense')," +
                        "(3501806,35,'Américo de Campos')," +
                        "(3501905,35,'Amparo')," +
                        "(3502002,35,'Analândia')," +
                        "(3502101,35,'Andradina')," +
                        "(3502200,35,'Angatuba')," +
                        "(3502309,35,'Anhembi')," +
                        "(3502408,35,'Anhumas')," +
                        "(3502507,35,'Aparecida')," +
                        "(3502606,35,'Aparecida Doeste')," +
                        "(3502705,35,'Apiaí')," +
                        "(3502754,35,'Araçariguama')," +
                        "(3502804,35,'Araçatuba')," +
                        "(3502903,35,'Araçoiaba da Serra')," +
                        "(3503000,35,'Aramina')," +
                        "(3503109,35,'Arandu')," +
                        "(3503158,35,'Arapeí')," +
                        "(3503208,35,'Araraquara')," +
                        "(3503307,35,'Araras')," +
                        "(3503356,35,'Arco-Íris')," +
                        "(3503406,35,'Arealva')," +
                        "(3503505,35,'Areias')," +
                        "(3503604,35,'Areiópolis')," +
                        "(3503703,35,'Ariranha')," +
                        "(3503802,35,'Artur Nogueira')," +
                        "(3503901,35,'Arujá')," +
                        "(3503950,35,'Aspásia')," +
                        "(3504008,35,'Assis')," +
                        "(3504107,35,'Atibaia')," +
                        "(3504206,35,'Auriflama')," +
                        "(3504305,35,'Avaí')," +
                        "(3504404,35,'Avanhandava')," +
                        "(3504503,35,'Avaré')," +
                        "(3504602,35,'Bady Bassitt')," +
                        "(3504701,35,'Balbinos')," +
                        "(3504800,35,'Bálsamo')," +
                        "(3504909,35,'Bananal')," +
                        "(3505005,35,'Barão de Antonina')," +
                        "(3505104,35,'Barbosa')," +
                        "(3505203,35,'Bariri')," +
                        "(3505302,35,'Barra Bonita')," +
                        "(3505351,35,'Barra do Chapéu')," +
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
                        "(3506706,35,'Boa Esperança do Sul')," +
                        "(3506805,35,'Bocaina')," +
                        "(3506904,35,'Bofete')," +
                        "(3507001,35,'Boituva')," +
                        "(3507100,35,'Bom Jesus dos Perdões')," +
                        "(3507159,35,'Bom Sucesso de Itararé')," +
                        "(3507209,35,'Borá')," +
                        "(3507308,35,'Boracéia')," +
                        "(3507407,35,'Borborema')," +
                        "(3507456,35,'Borebi')," +
                        "(3507506,35,'Botucatu')," +
                        "(3507605,35,'Bragança Paulista')," +
                        "(3507704,35,'Braúna')," +
                        "(3507753,35,'Brejo Alegre')," +
                        "(3507803,35,'Brodowski')," +
                        "(3507902,35,'Brotas')," +
                        "(3508009,35,'Buri')," +
                        "(3508108,35,'Buritama')," +
                        "(3508207,35,'Buritizal')," +
                        "(3508306,35,'Cabrália Paulista')," +
                        "(3508405,35,'Cabreúva')," +
                        "(3508504,35,'Caçapava')," +
                        "(3508603,35,'Cachoeira Paulista')," +
                        "(3508702,35,'Caconde')," +
                        "(3508801,35,'Cafelândia')," +
                        "(3508900,35,'Caiabu')," +
                        "(3509007,35,'Caieiras')," +
                        "(3509106,35,'Caiuá')," +
                        "(3509205,35,'Cajamar')," +
                        "(3509254,35,'Cajati')," +
                        "(3509304,35,'Cajobi')," +
                        "(3509403,35,'Cajuru')," +
                        "(3509452,35,'Campina do Monte Alegre')," +
                        "(3509502,35,'Campinas')," +
                        "(3509601,35,'Campo Limpo Paulista')," +
                        "(3509700,35,'Campos do Jordão')," +
                        "(3509809,35,'Campos Novos Paulista')," +
                        "(3509908,35,'Cananéia')," +
                        "(3509957,35,'Canas')," +
                        "(3510005,35,'Cândido Mota')," +
                        "(3510104,35,'Cândido Rodrigues')," +
                        "(3510153,35,'Canitar')," +
                        "(3510203,35,'Capão Bonito')," +
                        "(3510302,35,'Capela do Alto')," +
                        "(3510401,35,'Capivari')," +
                        "(3510500,35,'Caraguatatuba')," +
                        "(3510609,35,'Carapicuíba')," +
                        "(3510708,35,'Cardoso')," +
                        "(3510807,35,'Casa Branca')," +
                        "(3510906,35,'Cássia dos Coqueiros')," +
                        "(3511003,35,'Castilho')," +
                        "(3511102,35,'Catanduva')," +
                        "(3511201,35,'Catiguá')," +
                        "(3511300,35,'Cedral')," +
                        "(3511409,35,'Cerqueira César')," +
                        "(3511508,35,'Cerquilho')," +
                        "(3511607,35,'Cesário Lange')," +
                        "(3511706,35,'Charqueada')," +
                        "(3511904,35,'Clementina')," +
                        "(3512001,35,'Colina')," +
                        "(3512100,35,'Colômbia')," +
                        "(3512209,35,'Conchal')," +
                        "(3512308,35,'Conchas')," +
                        "(3512407,35,'Cordeirópolis')," +
                        "(3512506,35,'Coroados')," +
                        "(3512605,35,'Coronel Macedo')," +
                        "(3512704,35,'Corumbataí')," +
                        "(3512803,35,'Cosmópolis')," +
                        "(3512902,35,'Cosmorama')," +
                        "(3513009,35,'Cotia')," +
                        "(3513108,35,'Cravinhos')," +
                        "(3513207,35,'Cristais Paulista')," +
                        "(3513306,35,'Cruzália')," +
                        "(3513405,35,'Cruzeiro')," +
                        "(3513504,35,'Cubatão')," +
                        "(3513603,35,'Cunha')," +
                        "(3513702,35,'descalvado')," +
                        "(3513801,35,'Diadema')," +
                        "(3513850,35,'Dirce Reis')," +
                        "(3513900,35,'Divinolândia')," +
                        "(3514007,35,'dobrada')," +
                        "(3514106,35,'dois Córregos')," +
                        "(3514205,35,'dolcinópolis')," +
                        "(3514304,35,'dourado')," +
                        "(3514403,35,'Dracena')," +
                        "(3514502,35,'Duartina')," +
                        "(3514601,35,'Dumont')," +
                        "(3514700,35,'Echaporã')," +
                        "(3514809,35,'Eldorado')," +
                        "(3514908,35,'Elias Fausto')," +
                        "(3514924,35,'Elisiário')," +
                        "(3514957,35,'Embaúba')," +
                        "(3515004,35,'Embu das Artes')," +
                        "(3515103,35,'Embu-Guaçu')," +
                        "(3515129,35,'Emilianópolis')," +
                        "(3515152,35,'Engenheiro Coelho')," +
                        "(3515186,35,'Espírito Santo do Pinhal')," +
                        "(3515194,35,'Espírito Santo do Turvo')," +
                        "(3515202,35,'Estrela Doeste')," +
                        "(3515301,35,'Estrela do Norte')," +
                        "(3515350,35,'Euclides da Cunha Paulista')," +
                        "(3515400,35,'Fartura')," +
                        "(3515509,35,'Fernandópolis')," +
                        "(3515608,35,'Fernando Prestes')," +
                        "(3515657,35,'Fernão')," +
                        "(3515707,35,'Ferraz de Vasconcelos')," +
                        "(3515806,35,'Flora Rica')," +
                        "(3515905,35,'Floreal')," +
                        "(3516002,35,'Flórida Paulista')," +
                        "(3516101,35,'Florínia')," +
                        "(3516200,35,'Franca')," +
                        "(3516309,35,'Francisco Morato')," +
                        "(3516408,35,'Franco da Rocha')," +
                        "(3516507,35,'Gabriel Monteiro')," +
                        "(3516606,35,'Gália')," +
                        "(3516705,35,'Garça')," +
                        "(3516804,35,'Gastão Vidigal')," +
                        "(3516853,35,'Gavião Peixoto')," +
                        "(3516903,35,'General Salgado')," +
                        "(3517000,35,'Getulina')," +
                        "(3517109,35,'Glicério')," +
                        "(3517208,35,'Guaiçara')," +
                        "(3517307,35,'Guaimbê')," +
                        "(3517406,35,'Guaíra')," +
                        "(3517505,35,'Guapiaçu')," +
                        "(3517604,35,'Guapiara')," +
                        "(3517703,35,'Guará')," +
                        "(3517802,35,'Guaraçaí')," +
                        "(3517901,35,'Guaraci')," +
                        "(3518008,35,'Guarani Doeste')," +
                        "(3518107,35,'Guarantã')," +
                        "(3518206,35,'Guararapes')," +
                        "(3518305,35,'Guararema')," +
                        "(3518404,35,'Guaratinguetá')," +
                        "(3518503,35,'Guareí')," +
                        "(3518602,35,'Guariba')," +
                        "(3518701,35,'Guarujá')," +
                        "(3518800,35,'Guarulhos')," +
                        "(3518859,35,'Guatapará')," +
                        "(3518909,35,'Guzolândia')," +
                        "(3519006,35,'Herculândia')," +
                        "(3519055,35,'Holambra')," +
                        "(3519071,35,'Hortolândia')," +
                        "(3519105,35,'Iacanga')," +
                        "(3519204,35,'Iacri')," +
                        "(3519253,35,'Iaras')," +
                        "(3519303,35,'Ibaté')," +
                        "(3519402,35,'Ibirá')," +
                        "(3519501,35,'Ibirarema')," +
                        "(3519600,35,'Ibitinga')," +
                        "(3519709,35,'Ibiúna')," +
                        "(3519808,35,'Icém')," +
                        "(3519907,35,'Iepê')," +
                        "(3520004,35,'Igaraçu do Tietê')," +
                        "(3520103,35,'Igarapava')," +
                        "(3520202,35,'Igaratá')," +
                        "(3520301,35,'Iguape')," +
                        "(3520400,35,'Ilhabela')," +
                        "(3520426,35,'Ilha Comprida')," +
                        "(3520442,35,'Ilha Solteira')," +
                        "(3520509,35,'Indaiatuba')," +
                        "(3520608,35,'Indiana')," +
                        "(3520707,35,'Indiaporã')," +
                        "(3520806,35,'Inúbia Paulista')," +
                        "(3520905,35,'Ipaussu')," +
                        "(3521002,35,'Iperó')," +
                        "(3521101,35,'Ipeúna')," +
                        "(3521150,35,'Ipiguá')," +
                        "(3521200,35,'Iporanga')," +
                        "(3521309,35,'Ipuã')," +
                        "(3521408,35,'Iracemápolis')," +
                        "(3521507,35,'Irapuã')," +
                        "(3521606,35,'Irapuru')," +
                        "(3521705,35,'Itaberá')," +
                        "(3521804,35,'Itaí')," +
                        "(3521903,35,'Itajobi')," +
                        "(3522000,35,'Itaju')," +
                        "(3522109,35,'Itanhaém')," +
                        "(3522158,35,'Itaóca')," +
                        "(3522208,35,'Itapecerica da Serra')," +
                        "(3522307,35,'Itapetininga')," +
                        "(3522406,35,'Itapeva')," +
                        "(3522505,35,'Itapevi')," +
                        "(3522604,35,'Itapira')," +
                        "(3522653,35,'Itapirapuã Paulista')," +
                        "(3522703,35,'Itápolis')," +
                        "(3522802,35,'Itaporanga')," +
                        "(3522901,35,'Itapuí')," +
                        "(3523008,35,'Itapura')," +
                        "(3523107,35,'Itaquaquecetuba')," +
                        "(3523206,35,'Itararé')," +
                        "(3523305,35,'Itariri')," +
                        "(3523404,35,'Itatiba')," +
                        "(3523503,35,'Itatinga')," +
                        "(3523602,35,'Itirapina')," +
                        "(3523701,35,'Itirapuã')," +
                        "(3523800,35,'Itobi')," +
                        "(3523909,35,'Itu')," +
                        "(3524006,35,'Itupeva')," +
                        "(3524105,35,'Ituverava')," +
                        "(3524204,35,'Jaborandi')," +
                        "(3524303,35,'Jaboticabal')," +
                        "(3524402,35,'Jacareí')," +
                        "(3524501,35,'Jaci')," +
                        "(3524600,35,'Jacupiranga')," +
                        "(3524709,35,'Jaguariúna')," +
                        "(3524808,35,'Jales')," +
                        "(3524907,35,'Jambeiro')," +
                        "(3525003,35,'Jandira')," +
                        "(3525102,35,'Jardinópolis')," +
                        "(3525201,35,'Jarinu')," +
                        "(3525300,35,'Jaú')," +
                        "(3525409,35,'Jeriquara')," +
                        "(3525508,35,'Joanópolis')," +
                        "(3525607,35,'João Ramalho')," +
                        "(3525706,35,'José Bonifácio')," +
                        "(3525805,35,'Júlio Mesquita')," +
                        "(3525854,35,'Jumirim')," +
                        "(3525904,35,'Jundiaí')," +
                        "(3526001,35,'Junqueirópolis')," +
                        "(3526100,35,'Juquiá')," +
                        "(3526209,35,'Juquitiba')," +
                        "(3526308,35,'Lagoinha')," +
                        "(3526407,35,'Laranjal Paulista')," +
                        "(3526506,35,'Lavínia')," +
                        "(3526605,35,'Lavrinhas')," +
                        "(3526704,35,'Leme')," +
                        "(3526803,35,'Lençóis Paulista')," +
                        "(3526902,35,'Limeira')," +
                        "(3527009,35,'Lindóia')," +
                        "(3527108,35,'Lins')," +
                        "(3527207,35,'Lorena')," +
                        "(3527256,35,'Lourdes')," +
                        "(3527306,35,'Louveira')," +
                        "(3527405,35,'Lucélia')," +
                        "(3527504,35,'Lucianópolis')," +
                        "(3527603,35,'Luís Antônio')," +
                        "(3527702,35,'Luiziânia')," +
                        "(3527801,35,'Lupércio')," +
                        "(3527900,35,'Lutécia')," +
                        "(3528007,35,'Macatuba')," +
                        "(3528106,35,'Macaubal')," +
                        "(3528205,35,'Macedônia')," +
                        "(3528304,35,'Magda')," +
                        "(3528403,35,'Mairinque')," +
                        "(3528502,35,'Mairiporã')," +
                        "(3528601,35,'Manduri')," +
                        "(3528700,35,'Marabá Paulista')," +
                        "(3528809,35,'Maracaí')," +
                        "(3528858,35,'Marapoama')," +
                        "(3528908,35,'Mariápolis')," +
                        "(3529005,35,'Marília')," +
                        "(3529104,35,'Marinópolis')," +
                        "(3529203,35,'Martinópolis')," +
                        "(3529302,35,'Matão')," +
                        "(3529401,35,'Mauá')," +
                        "(3529500,35,'Mendonça')," +
                        "(3529609,35,'Meridiano')," +
                        "(3529658,35,'Mesópolis')," +
                        "(3529708,35,'Miguelópolis')," +
                        "(3529807,35,'Mineiros do Tietê')," +
                        "(3529906,35,'Miracatu')," +
                        "(3530003,35,'Mira Estrela')," +
                        "(3530102,35,'Mirandópolis')," +
                        "(3530201,35,'Mirante do Paranapanema')," +
                        "(3530300,35,'Mirassol')," +
                        "(3530409,35,'Mirassolândia')," +
                        "(3530508,35,'Mococa')," +
                        "(3530607,35,'Mogi das Cruzes')," +
                        "(3530706,35,'Mogi Guaçu')," +
                        "(3530805,35,'Mogi Mirim')," +
                        "(3530904,35,'Mombuca')," +
                        "(3531001,35,'Monções')," +
                        "(3531100,35,'Mongaguá')," +
                        "(3531209,35,'Monte Alegre do Sul')," +
                        "(3531308,35,'Monte Alto')," +
                        "(3531407,35,'Monte Aprazível')," +
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
                        "(3532405,35,'Nazaré Paulista')," +
                        "(3532504,35,'Neves Paulista')," +
                        "(3532603,35,'Nhandeara')," +
                        "(3532702,35,'Nipoã')," +
                        "(3532801,35,'Nova Aliança')," +
                        "(3532827,35,'Nova Campina')," +
                        "(3532843,35,'Nova Canaã Paulista')," +
                        "(3532868,35,'Nova Castilho')," +
                        "(3532900,35,'Nova Europa')," +
                        "(3533007,35,'Nova Granada')," +
                        "(3533106,35,'Nova Guataporanga')," +
                        "(3533205,35,'Nova Independência')," +
                        "(3533254,35,'Novais')," +
                        "(3533304,35,'Nova Luzitânia')," +
                        "(3533403,35,'Nova Odessa')," +
                        "(3533502,35,'Novo Horizonte')," +
                        "(3533601,35,'Nuporanga')," +
                        "(3533700,35,'Ocauçu')," +
                        "(3533809,35,'Óleo')," +
                        "(3533908,35,'Olímpia')," +
                        "(3534005,35,'Onda Verde')," +
                        "(3534104,35,'Oriente')," +
                        "(3534203,35,'Orindiúva')," +
                        "(3534302,35,'Orlândia')," +
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
                        "(3535507,35,'Paraguaçu Paulista')," +
                        "(3535606,35,'Paraibuna')," +
                        "(3535705,35,'Paraíso')," +
                        "(3535804,35,'Paranapanema')," +
                        "(3535903,35,'Paranapuã')," +
                        "(3536000,35,'Parapuã')," +
                        "(3536109,35,'Pardinho')," +
                        "(3536208,35,'Pariquera-Açu')," +
                        "(3536257,35,'Parisi')," +
                        "(3536307,35,'Patrocínio Paulista')," +
                        "(3536406,35,'Paulicéia')," +
                        "(3536505,35,'Paulínia')," +
                        "(3536570,35,'Paulistânia')," +
                        "(3536604,35,'Paulo de Faria')," +
                        "(3536703,35,'Pederneiras')," +
                        "(3536802,35,'Pedra Bela')," +
                        "(3536901,35,'Pedranópolis')," +
                        "(3537008,35,'Pedregulho')," +
                        "(3537107,35,'Pedreira')," +
                        "(3537156,35,'Pedrinhas Paulista')," +
                        "(3537206,35,'Pedro de Toledo')," +
                        "(3537305,35,'Penápolis')," +
                        "(3537404,35,'Pereira Barreto')," +
                        "(3537503,35,'Pereiras')," +
                        "(3537602,35,'Peruíbe')," +
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
                        "(3538907,35,'Pirajuí')," +
                        "(3539004,35,'Pirangi')," +
                        "(3539103,35,'Pirapora do Bom Jesus')," +
                        "(3539202,35,'Pirapozinho')," +
                        "(3539301,35,'Pirassununga')," +
                        "(3539400,35,'Piratininga')," +
                        "(3539509,35,'Pitangueiras')," +
                        "(3539608,35,'Planalto')," +
                        "(3539707,35,'Platina')," +
                        "(3539806,35,'Poá')," +
                        "(3539905,35,'Poloni')," +
                        "(3540002,35,'Pompéia')," +
                        "(3540101,35,'Pongaí')," +
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
                        "(3540903,35,'Pradópolis')," +
                        "(3541000,35,'Praia Grande')," +
                        "(3541059,35,'Pratânia')," +
                        "(3541109,35,'Presidente Alves')," +
                        "(3541208,35,'Presidente Bernardes')," +
                        "(3541307,35,'Presidente Epitácio')," +
                        "(3541406,35,'Presidente Prudente')," +
                        "(3541505,35,'Presidente Venceslau')," +
                        "(3541604,35,'Promissão')," +
                        "(3541653,35,'Quadra')," +
                        "(3541703,35,'Quatá')," +
                        "(3541802,35,'Queiroz')," +
                        "(3541901,35,'Queluz')," +
                        "(3542008,35,'Quintana')," +
                        "(3542107,35,'Rafard')," +
                        "(3542206,35,'Rancharia')," +
                        "(3542305,35,'Redenção da Serra')," +
                        "(3542404,35,'Regente Feijó')," +
                        "(3542503,35,'Reginópolis')," +
                        "(3542602,35,'Registro')," +
                        "(3542701,35,'Restinga')," +
                        "(3542800,35,'Ribeira')," +
                        "(3542909,35,'Ribeirão Bonito')," +
                        "(3543006,35,'Ribeirão Branco')," +
                        "(3543105,35,'Ribeirão Corrente')," +
                        "(3543204,35,'Ribeirão do Sul')," +
                        "(3543238,35,'Ribeirão dos Índios')," +
                        "(3543253,35,'Ribeirão Grande')," +
                        "(3543303,35,'Ribeirão Pires')," +
                        "(3543402,35,'Ribeirão Preto')," +
                        "(3543501,35,'Riversul')," +
                        "(3543600,35,'Rifaina')," +
                        "(3543709,35,'Rincão')," +
                        "(3543808,35,'Rinópolis')," +
                        "(3543907,35,'Rio Claro')," +
                        "(3544004,35,'Rio das Pedras')," +
                        "(3544103,35,'Rio Grande da Serra')," +
                        "(3544202,35,'Riolândia')," +
                        "(3544251,35,'Rosana')," +
                        "(3544301,35,'Roseira')," +
                        "(3544400,35,'Rubiácea')," +
                        "(3544509,35,'Rubinéia')," +
                        "(3544608,35,'Sabino')," +
                        "(3544707,35,'Sagres')," +
                        "(3544806,35,'Sales')," +
                        "(3544905,35,'Sales Oliveira')," +
                        "(3545001,35,'Salesópolis')," +
                        "(3545100,35,'Salmourão')," +
                        "(3545159,35,'Saltinho')," +
                        "(3545209,35,'Salto')," +
                        "(3545308,35,'Salto de Pirapora')," +
                        "(3545407,35,'Salto Grande')," +
                        "(3545506,35,'Sandovalina')," +
                        "(3545605,35,'Santa Adélia')," +
                        "(3545704,35,'Santa Albertina')," +
                        "(3545803,35,'Santa Bárbara Doeste')," +
                        "(3546009,35,'Santa Branca')," +
                        "(3546108,35,'Santa Clara Doeste')," +
                        "(3546207,35,'Santa Cruz da Conceição')," +
                        "(3546256,35,'Santa Cruz da Esperança')," +
                        "(3546306,35,'Santa Cruz das Palmeiras')," +
                        "(3546405,35,'Santa Cruz do Rio Pardo')," +
                        "(3546504,35,'Santa Ernestina')," +
                        "(3546603,35,'Santa Fé do Sul')," +
                        "(3546702,35,'Santa Gertrudes')," +
                        "(3546801,35,'Santa Isabel')," +
                        "(3546900,35,'Santa Lúcia')," +
                        "(3547007,35,'Santa Maria da Serra')," +
                        "(3547106,35,'Santa Mercedes')," +
                        "(3547205,35,'Santana da Ponte Pensa')," +
                        "(3547304,35,'Santana de Parnaíba')," +
                        "(3547403,35,'Santa Rita Doeste')," +
                        "(3547502,35,'Santa Rita do Passa Quatro')," +
                        "(3547601,35,'Santa Rosa de Viterbo')," +
                        "(3547650,35,'Santa Salete')," +
                        "(3547700,35,'Santo Anastácio')," +
                        "(3547809,35,'Santo André')," +
                        "(3547908,35,'Santo Antônio da Alegria')," +
                        "(3548005,35,'Santo Antônio de Posse')," +
                        "(3548054,35,'Santo Antônio do Aracanguá')," +
                        "(3548104,35,'Santo Antônio do Jardim')," +
                        "(3548203,35,'Santo Antônio do Pinhal')," +
                        "(3548302,35,'Santo Expedito')," +
                        "(3548401,35,'Santópolis do Aguapeí')," +
                        "(3548500,35,'Santos')," +
                        "(3548609,35,'São Bento do Sapucaí')," +
                        "(3548708,35,'São Bernardo do Campo')," +
                        "(3548807,35,'São Caetano do Sul')," +
                        "(3548906,35,'São Carlos')," +
                        "(3549003,35,'São Francisco')," +
                        "(3549102,35,'São João da Boa Vista')," +
                        "(3549201,35,'São João das Duas Pontes')," +
                        "(3549250,35,'São João de Iracema')," +
                        "(3549300,35,'São João do Pau Dalho')," +
                        "(3549409,35,'São Joaquim da Barra')," +
                        "(3549508,35,'São José da Bela Vista')," +
                        "(3549607,35,'São José do Barreiro')," +
                        "(3549706,35,'São José do Rio Pardo')," +
                        "(3549805,35,'São José do Rio Preto')," +
                        "(3549904,35,'São José dos Campos')," +
                        "(3549953,35,'São Lourenço da Serra')," +
                        "(3550001,35,'São Luís do Paraitinga')," +
                        "(3550100,35,'São Manuel')," +
                        "(3550209,35,'São Miguel Arcanjo')," +
                        "(3550308,35,'São Paulo')," +
                        "(3550407,35,'São Pedro')," +
                        "(3550506,35,'São Pedro do Turvo')," +
                        "(3550605,35,'São Roque')," +
                        "(3550704,35,'São Sebastião')," +
                        "(3550803,35,'São Sebastião da Grama')," +
                        "(3550902,35,'São Simão')," +
                        "(3551009,35,'São Vicente')," +
                        "(3551108,35,'Sarapuí')," +
                        "(3551207,35,'Sarutaiá')," +
                        "(3551306,35,'Sebastianópolis do Sul')," +
                        "(3551405,35,'Serra Azul')," +
                        "(3551504,35,'Serrana')," +
                        "(3551603,35,'Serra Negra')," +
                        "(3551702,35,'Sertãozinho')," +
                        "(3551801,35,'Sete Barras')," +
                        "(3551900,35,'Severínia')," +
                        "(3552007,35,'Silveiras')," +
                        "(3552106,35,'Socorro')," +
                        "(3552205,35,'Sorocaba')," +
                        "(3552304,35,'Sud Mennucci')," +
                        "(3552403,35,'Sumaré')," +
                        "(3552502,35,'Suzano')," +
                        "(3552551,35,'Suzanápolis')," +
                        "(3552601,35,'Tabapuã')," +
                        "(3552700,35,'Tabatinga')," +
                        "(3552809,35,'Taboão da Serra')," +
                        "(3552908,35,'Taciba')," +
                        "(3553005,35,'Taguaí')," +
                        "(3553104,35,'Taiaçu')," +
                        "(3553203,35,'Taiúva')," +
                        "(3553302,35,'Tambaú')," +
                        "(3553401,35,'Tanabi')," +
                        "(3553500,35,'Tapiraí')," +
                        "(3553609,35,'Tapiratiba')," +
                        "(3553658,35,'Taquaral')," +
                        "(3553708,35,'Taquaritinga')," +
                        "(3553807,35,'Taquarituba')," +
                        "(3553856,35,'Taquarivaí')," +
                        "(3553906,35,'Tarabai')," +
                        "(3553955,35,'Tarumã')," +
                        "(3554003,35,'Tatuí')," +
                        "(3554102,35,'Taubaté')," +
                        "(3554201,35,'Tejupá')," +
                        "(3554300,35,'Teodoro Sampaio')," +
                        "(3554409,35,'Terra Roxa')," +
                        "(3554508,35,'Tietê')," +
                        "(3554607,35,'Timburi')," +
                        "(3554656,35,'Torre de Pedra')," +
                        "(3554706,35,'Torrinha')," +
                        "(3554755,35,'Trabiju')," +
                        "(3554805,35,'Tremembé')," +
                        "(3554904,35,'Três Fronteiras')," +
                        "(3554953,35,'Tuiuti')," +
                        "(3555000,35,'Tupã')," +
                        "(3555109,35,'Tupi Paulista')," +
                        "(3555208,35,'Turiúba')," +
                        "(3555307,35,'Turmalina')," +
                        "(3555356,35,'Ubarana')," +
                        "(3555406,35,'Ubatuba')," +
                        "(3555505,35,'Ubirajara')," +
                        "(3555604,35,'Uchoa')," +
                        "(3555703,35,'União Paulista')," +
                        "(3555802,35,'Urânia')," +
                        "(3555901,35,'Uru')," +
                        "(3556008,35,'Urupês')," +
                        "(3556107,35,'Valentim Gentil')," +
                        "(3556206,35,'Valinhos')," +
                        "(3556305,35,'Valparaíso')," +
                        "(3556354,35,'Vargem')," +
                        "(3556404,35,'Vargem Grande do Sul')," +
                        "(3556453,35,'Vargem Grande Paulista')," +
                        "(3556503,35,'Várzea Paulista')," +
                        "(3556602,35,'Vera Cruz')," +
                        "(3556701,35,'Vinhedo')," +
                        "(3556800,35,'Viradouro')," +
                        "(3556909,35,'Vista Alegre do Alto')," +
                        "(3556958,35,'Vitória Brasil')," +
                        "(3557006,35,'Votorantim')," +
                        "(3557105,35,'Votuporanga')," +
                        "(3557154,35,'Zacarias')," +
                        "(3557204,35,'Chavantes')," +
                        "(3557303,35,'Estiva Gerbi')," +
                        "(4100103,41,'Abatiá')," +
                        "(4100202,41,'Adrianópolis')," +
                        "(4100301,41,'Agudos do Sul')," +
                        "(4100400,41,'Almirante Tamandaré')," +
                        "(4100459,41,'Altamira do Paraná')," +
                        "(4100509,41,'Altônia')," +
                        "(4100608,41,'Alto Paraná')," +
                        "(4100707,41,'Alto Piquiri')," +
                        "(4100806,41,'Alvorada do Sul')," +
                        "(4100905,41,'Amaporã')," +
                        "(4101002,41,'Ampére')," +
                        "(4101051,41,'Anahy')," +
                        "(4101101,41,'Andirá')," +
                        "(4101150,41,'Ângulo')," +
                        "(4101200,41,'Antonina')," +
                        "(4101309,41,'Antônio Olinto')," +
                        "(4101408,41,'Apucarana')," +
                        "(4101507,41,'Arapongas')," +
                        "(4101606,41,'Arapoti')," +
                        "(4101655,41,'Arapuã')," +
                        "(4101705,41,'Araruna')," +
                        "(4101804,41,'Araucária')," +
                        "(4101853,41,'Ariranha do Ivaí')," +
                        "(4101903,41,'Assaí')," +
                        "(4102000,41,'Assis Chateaubriand')," +
                        "(4102109,41,'Astorga')," +
                        "(4102208,41,'Atalaia')," +
                        "(4102307,41,'Balsa Nova')," +
                        "(4102406,41,'Bandeirantes')," +
                        "(4102505,41,'Barbosa Ferraz')," +
                        "(4102604,41,'Barracão')," +
                        "(4102703,41,'Barra do Jacaré')," +
                        "(4102752,41,'Bela Vista da Caroba')," +
                        "(4102802,41,'Bela Vista do Paraíso')," +
                        "(4102901,41,'Bituruna')," +
                        "(4103008,41,'Boa Esperança')," +
                        "(4103024,41,'Boa Esperança do Iguaçu')," +
                        "(4103040,41,'Boa Ventura de São Roque')," +
                        "(4103057,41,'Boa Vista da Aparecida')," +
                        "(4103107,41,'Bocaiúva do Sul')," +
                        "(4103156,41,'Bom Jesus do Sul')," +
                        "(4103206,41,'Bom Sucesso')," +
                        "(4103222,41,'Bom Sucesso do Sul')," +
                        "(4103305,41,'Borrazópolis')," +
                        "(4103354,41,'Braganey')," +
                        "(4103370,41,'Brasilândia do Sul')," +
                        "(4103404,41,'Cafeara')," +
                        "(4103453,41,'Cafelândia')," +
                        "(4103479,41,'Cafezal do Sul')," +
                        "(4103503,41,'Califórnia')," +
                        "(4103602,41,'Cambará')," +
                        "(4103701,41,'Cambé')," +
                        "(4103800,41,'Cambira')," +
                        "(4103909,41,'Campina da Lagoa')," +
                        "(4103958,41,'Campina do Simão')," +
                        "(4104006,41,'Campina Grande do Sul')," +
                        "(4104055,41,'Campo Bonito')," +
                        "(4104105,41,'Campo do Tenente')," +
                        "(4104204,41,'Campo Largo')," +
                        "(4104253,41,'Campo Magro')," +
                        "(4104303,41,'Campo Mourão')," +
                        "(4104402,41,'Cândido de Abreu')," +
                        "(4104428,41,'Candói')," +
                        "(4104451,41,'Cantagalo')," +
                        "(4104501,41,'Capanema')," +
                        "(4104600,41,'Capitão Leônidas Marques')," +
                        "(4104659,41,'Carambeí')," +
                        "(4104709,41,'Carlópolis')," +
                        "(4104808,41,'Cascavel')," +
                        "(4104907,41,'Castro')," +
                        "(4105003,41,'Catanduvas')," +
                        "(4105102,41,'Centenário do Sul')," +
                        "(4105201,41,'Cerro Azul')," +
                        "(4105300,41,'Céu Azul')," +
                        "(4105409,41,'Chopinzinho')," +
                        "(4105508,41,'Cianorte')," +
                        "(4105607,41,'Cidade Gaúcha')," +
                        "(4105706,41,'Clevelândia')," +
                        "(4105805,41,'Colombo')," +
                        "(4105904,41,'Colorado')," +
                        "(4106001,41,'Congonhinhas')," +
                        "(4106100,41,'Conselheiro Mairinck')," +
                        "(4106209,41,'Contenda')," +
                        "(4106308,41,'Corbélia')," +
                        "(4106407,41,'Cornélio Procópio')," +
                        "(4106456,41,'Coronel domingos Soares')," +
                        "(4106506,41,'Coronel Vivida')," +
                        "(4106555,41,'Corumbataí do Sul')," +
                        "(4106571,41,'Cruzeiro do Iguaçu')," +
                        "(4106605,41,'Cruzeiro do Oeste')," +
                        "(4106704,41,'Cruzeiro do Sul')," +
                        "(4106803,41,'Cruz Machado')," +
                        "(4106852,41,'Cruzmaltina')," +
                        "(4106902,41,'Curitiba')," +
                        "(4107009,41,'Curiúva')," +
                        "(4107108,41,'Diamante do Norte')," +
                        "(4107124,41,'Diamante do Sul')," +
                        "(4107157,41,'Diamante Doeste')," +
                        "(4107207,41,'dois Vizinhos')," +
                        "(4107256,41,'douradina')," +
                        "(4107306,41,'doutor Camargo')," +
                        "(4107405,41,'Enéas Marques')," +
                        "(4107504,41,'Engenheiro Beltrão')," +
                        "(4107520,41,'Esperança Nova')," +
                        "(4107538,41,'Entre Rios do Oeste')," +
                        "(4107546,41,'Espigão Alto do Iguaçu')," +
                        "(4107553,41,'Farol')," +
                        "(4107603,41,'Faxinal')," +
                        "(4107652,41,'Fazenda Rio Grande')," +
                        "(4107702,41,'Fênix')," +
                        "(4107736,41,'Fernandes Pinheiro')," +
                        "(4107751,41,'Figueira')," +
                        "(4107801,41,'Floraí')," +
                        "(4107850,41,'Flor da Serra do Sul')," +
                        "(4107900,41,'Floresta')," +
                        "(4108007,41,'Florestópolis')," +
                        "(4108106,41,'Flórida')," +
                        "(4108205,41,'Formosa do Oeste')," +
                        "(4108304,41,'Foz do Iguaçu')," +
                        "(4108320,41,'Francisco Alves')," +
                        "(4108403,41,'Francisco Beltrão')," +
                        "(4108452,41,'Foz do Jordão')," +
                        "(4108502,41,'General Carneiro')," +
                        "(4108551,41,'Godoy Moreira')," +
                        "(4108601,41,'Goioerê')," +
                        "(4108650,41,'Goioxim')," +
                        "(4108700,41,'Grandes Rios')," +
                        "(4108809,41,'Guaíra')," +
                        "(4108908,41,'Guairaçá')," +
                        "(4108957,41,'Guamiranga')," +
                        "(4109005,41,'Guapirama')," +
                        "(4109104,41,'Guaporema')," +
                        "(4109203,41,'Guaraci')," +
                        "(4109302,41,'Guaraniaçu')," +
                        "(4109401,41,'Guarapuava')," +
                        "(4109500,41,'Guaraqueçaba')," +
                        "(4109609,41,'Guaratuba')," +
                        "(4109658,41,'Honório Serpa')," +
                        "(4109708,41,'Ibaiti')," +
                        "(4109757,41,'Ibema')," +
                        "(4109807,41,'Ibiporã')," +
                        "(4109906,41,'Icaraíma')," +
                        "(4110003,41,'Iguaraçu')," +
                        "(4110052,41,'Iguatu')," +
                        "(4110078,41,'Imbaú')," +
                        "(4110102,41,'Imbituva')," +
                        "(4110201,41,'Inácio Martins')," +
                        "(4110300,41,'Inajá')," +
                        "(4110409,41,'Indianópolis')," +
                        "(4110508,41,'Ipiranga')," +
                        "(4110607,41,'Iporã')," +
                        "(4110656,41,'Iracema do Oeste')," +
                        "(4110706,41,'Irati')," +
                        "(4110805,41,'Iretama')," +
                        "(4110904,41,'Itaguajé')," +
                        "(4110953,41,'Itaipulândia')," +
                        "(4111001,41,'Itambaracá')," +
                        "(4111100,41,'Itambé')," +
                        "(4111209,41,'Itapejara Doeste')," +
                        "(4111258,41,'Itaperuçu')," +
                        "(4111308,41,'Itaúna do Sul')," +
                        "(4111407,41,'Ivaí')," +
                        "(4111506,41,'Ivaiporã')," +
                        "(4111555,41,'Ivaté')," +
                        "(4111605,41,'Ivatuba')," +
                        "(4111704,41,'Jaboti')," +
                        "(4111803,41,'Jacarezinho')," +
                        "(4111902,41,'Jaguapitã')," +
                        "(4112009,41,'Jaguariaíva')," +
                        "(4112108,41,'Jandaia do Sul')," +
                        "(4112207,41,'Janiópolis')," +
                        "(4112306,41,'Japira')," +
                        "(4112405,41,'Japurá')," +
                        "(4112504,41,'Jardim Alegre')," +
                        "(4112603,41,'Jardim Olinda')," +
                        "(4112702,41,'Jataizinho')," +
                        "(4112751,41,'Jesuítas')," +
                        "(4112801,41,'Joaquim Távora')," +
                        "(4112900,41,'Jundiaí do Sul')," +
                        "(4112959,41,'Juranda')," +
                        "(4113007,41,'Jussara')," +
                        "(4113106,41,'Kaloré')," +
                        "(4113205,41,'Lapa')," +
                        "(4113254,41,'Laranjal')," +
                        "(4113304,41,'Laranjeiras do Sul')," +
                        "(4113403,41,'Leópolis')," +
                        "(4113429,41,'Lidianópolis')," +
                        "(4113452,41,'Lindoeste')," +
                        "(4113502,41,'Loanda')," +
                        "(4113601,41,'Lobato')," +
                        "(4113700,41,'Londrina')," +
                        "(4113734,41,'Luiziana')," +
                        "(4113759,41,'Lunardelli')," +
                        "(4113809,41,'Lupionópolis')," +
                        "(4113908,41,'Mallet')," +
                        "(4114005,41,'Mamborê')," +
                        "(4114104,41,'Mandaguaçu')," +
                        "(4114203,41,'Mandaguari')," +
                        "(4114302,41,'Mandirituba')," +
                        "(4114351,41,'Manfrinópolis')," +
                        "(4114401,41,'Mangueirinha')," +
                        "(4114500,41,'Manoel Ribas')," +
                        "(4114609,41,'Marechal Cândido Rondon')," +
                        "(4114708,41,'Maria Helena')," +
                        "(4114807,41,'Marialva')," +
                        "(4114906,41,'Marilândia do Sul')," +
                        "(4115002,41,'Marilena')," +
                        "(4115101,41,'Mariluz')," +
                        "(4115200,41,'Maringá')," +
                        "(4115309,41,'Mariópolis')," +
                        "(4115358,41,'Maripá')," +
                        "(4115408,41,'Marmeleiro')," +
                        "(4115457,41,'Marquinho')," +
                        "(4115507,41,'Marumbi')," +
                        "(4115606,41,'Matelândia')," +
                        "(4115705,41,'Matinhos')," +
                        "(4115739,41,'Mato Rico')," +
                        "(4115754,41,'Mauá da Serra')," +
                        "(4115804,41,'Medianeira')," +
                        "(4115853,41,'Mercedes')," +
                        "(4115903,41,'Mirador')," +
                        "(4116000,41,'Miraselva')," +
                        "(4116059,41,'Missal')," +
                        "(4116109,41,'Moreira Sales')," +
                        "(4116208,41,'Morretes')," +
                        "(4116307,41,'Munhoz de Melo')," +
                        "(4116406,41,'Nossa Senhora das Graças')," +
                        "(4116505,41,'Nova Aliança do Ivaí')," +
                        "(4116604,41,'Nova América da Colina')," +
                        "(4116703,41,'Nova Aurora')," +
                        "(4116802,41,'Nova Cantu')," +
                        "(4116901,41,'Nova Esperança')," +
                        "(4116950,41,'Nova Esperança do Sudoeste')," +
                        "(4117008,41,'Nova Fátima')," +
                        "(4117057,41,'Nova Laranjeiras')," +
                        "(4117107,41,'Nova Londrina')," +
                        "(4117206,41,'Nova Olímpia')," +
                        "(4117214,41,'Nova Santa Bárbara')," +
                        "(4117222,41,'Nova Santa Rosa')," +
                        "(4117255,41,'Nova Prata do Iguaçu')," +
                        "(4117271,41,'Nova Tebas')," +
                        "(4117297,41,'Novo Itacolomi')," +
                        "(4117305,41,'Ortigueira')," +
                        "(4117404,41,'Ourizona')," +
                        "(4117453,41,'Ouro Verde do Oeste')," +
                        "(4117503,41,'Paiçandu')," +
                        "(4117602,41,'Palmas')," +
                        "(4117701,41,'Palmeira')," +
                        "(4117800,41,'Palmital')," +
                        "(4117909,41,'Palotina')," +
                        "(4118006,41,'Paraíso do Norte')," +
                        "(4118105,41,'Paranacity')," +
                        "(4118204,41,'Paranaguá')," +
                        "(4118303,41,'Paranapoema')," +
                        "(4118402,41,'Paranavaí')," +
                        "(4118451,41,'Pato Bragado')," +
                        "(4118501,41,'Pato Branco')," +
                        "(4118600,41,'Paula Freitas')," +
                        "(4118709,41,'Paulo Frontin')," +
                        "(4118808,41,'Peabiru')," +
                        "(4118857,41,'Perobal')," +
                        "(4118907,41,'Pérola')," +
                        "(4119004,41,'Pérola Doeste')," +
                        "(4119103,41,'Piên')," +
                        "(4119152,41,'Pinhais')," +
                        "(4119202,41,'Pinhalão')," +
                        "(4119251,41,'Pinhal de São Bento')," +
                        "(4119301,41,'Pinhão')," +
                        "(4119400,41,'Piraí do Sul')," +
                        "(4119509,41,'Piraquara')," +
                        "(4119608,41,'Pitanga')," +
                        "(4119657,41,'Pitangueiras')," +
                        "(4119707,41,'Planaltina do Paraná')," +
                        "(4119806,41,'Planalto')," +
                        "(4119905,41,'Ponta Grossa')," +
                        "(4119954,41,'Pontal do Paraná')," +
                        "(4120002,41,'Porecatu')," +
                        "(4120101,41,'Porto Amazonas')," +
                        "(4120150,41,'Porto Barreiro')," +
                        "(4120200,41,'Porto Rico')," +
                        "(4120309,41,'Porto Vitória')," +
                        "(4120333,41,'Prado Ferreira')," +
                        "(4120358,41,'Pranchita')," +
                        "(4120408,41,'Presidente Castelo Branco')," +
                        "(4120507,41,'Primeiro de Maio')," +
                        "(4120606,41,'Prudentópolis')," +
                        "(4120655,41,'Quarto Centenário')," +
                        "(4120705,41,'Quatiguá')," +
                        "(4120804,41,'Quatro Barras')," +
                        "(4120853,41,'Quatro Pontes')," +
                        "(4120903,41,'Quedas do Iguaçu')," +
                        "(4121000,41,'Querência do Norte')," +
                        "(4121109,41,'Quinta do Sol')," +
                        "(4121208,41,'Quitandinha')," +
                        "(4121257,41,'Ramilândia')," +
                        "(4121307,41,'Rancho Alegre')," +
                        "(4121356,41,'Rancho Alegre Doeste')," +
                        "(4121406,41,'Realeza')," +
                        "(4121505,41,'Rebouças')," +
                        "(4121604,41,'Renascença')," +
                        "(4121703,41,'Reserva')," +
                        "(4121752,41,'Reserva do Iguaçu')," +
                        "(4121802,41,'Ribeirão Claro')," +
                        "(4121901,41,'Ribeirão do Pinhal')," +
                        "(4122008,41,'Rio Azul')," +
                        "(4122107,41,'Rio Bom')," +
                        "(4122156,41,'Rio Bonito do Iguaçu')," +
                        "(4122172,41,'Rio Branco do Ivaí')," +
                        "(4122206,41,'Rio Branco do Sul')," +
                        "(4122305,41,'Rio Negro')," +
                        "(4122404,41,'Rolândia')," +
                        "(4122503,41,'Roncador')," +
                        "(4122602,41,'Rondon')," +
                        "(4122651,41,'Rosário do Ivaí')," +
                        "(4122701,41,'Sabáudia')," +
                        "(4122800,41,'Salgado Filho')," +
                        "(4122909,41,'Salto do Itararé')," +
                        "(4123006,41,'Salto do Lontra')," +
                        "(4123105,41,'Santa Amélia')," +
                        "(4123204,41,'Santa Cecília do Pavão')," +
                        "(4123303,41,'Santa Cruz de Monte Castelo')," +
                        "(4123402,41,'Santa Fé')," +
                        "(4123501,41,'Santa Helena')," +
                        "(4123600,41,'Santa Inês')," +
                        "(4123709,41,'Santa Isabel do Ivaí')," +
                        "(4123808,41,'Santa Izabel do Oeste')," +
                        "(4123824,41,'Santa Lúcia')," +
                        "(4123857,41,'Santa Maria do Oeste')," +
                        "(4123907,41,'Santa Mariana')," +
                        "(4123956,41,'Santa Mônica')," +
                        "(4124004,41,'Santana do Itararé')," +
                        "(4124020,41,'Santa Tereza do Oeste')," +
                        "(4124053,41,'Santa Terezinha de Itaipu')," +
                        "(4124103,41,'Santo Antônio da Platina')," +
                        "(4124202,41,'Santo Antônio do Caiuá')," +
                        "(4124301,41,'Santo Antônio do Paraíso')," +
                        "(4124400,41,'Santo Antônio do Sudoeste')," +
                        "(4124509,41,'Santo Inácio')," +
                        "(4124608,41,'São Carlos do Ivaí')," +
                        "(4124707,41,'São Jerônimo da Serra')," +
                        "(4124806,41,'São João')," +
                        "(4124905,41,'São João do Caiuá')," +
                        "(4125001,41,'São João do Ivaí')," +
                        "(4125100,41,'São João do Triunfo')," +
                        "(4125209,41,'São Jorge Doeste')," +
                        "(4125308,41,'São Jorge do Ivaí')," +
                        "(4125357,41,'São Jorge do Patrocínio')," +
                        "(4125407,41,'São José da Boa Vista')," +
                        "(4125456,41,'São José das Palmeiras')," +
                        "(4125506,41,'São José dos Pinhais')," +
                        "(4125555,41,'São Manoel do Paraná')," +
                        "(4125605,41,'São Mateus do Sul')," +
                        "(4125704,41,'São Miguel do Iguaçu')," +
                        "(4125753,41,'São Pedro do Iguaçu')," +
                        "(4125803,41,'São Pedro do Ivaí')," +
                        "(4125902,41,'São Pedro do Paraná')," +
                        "(4126009,41,'São Sebastião da Amoreira')," +
                        "(4126108,41,'São Tomé')," +
                        "(4126207,41,'Sapopema')," +
                        "(4126256,41,'Sarandi')," +
                        "(4126272,41,'Saudade do Iguaçu')," +
                        "(4126306,41,'Sengés')," +
                        "(4126355,41,'Serranópolis do Iguaçu')," +
                        "(4126405,41,'Sertaneja')," +
                        "(4126504,41,'Sertanópolis')," +
                        "(4126603,41,'Siqueira Campos')," +
                        "(4126652,41,'Sulina')," +
                        "(4126678,41,'Tamarana')," +
                        "(4126702,41,'Tamboara')," +
                        "(4126801,41,'Tapejara')," +
                        "(4126900,41,'Tapira')," +
                        "(4127007,41,'Teixeira Soares')," +
                        "(4127106,41,'Telêmaco Borba')," +
                        "(4127205,41,'Terra Boa')," +
                        "(4127304,41,'Terra Rica')," +
                        "(4127403,41,'Terra Roxa')," +
                        "(4127502,41,'Tibagi')," +
                        "(4127601,41,'Tijucas do Sul')," +
                        "(4127700,41,'Toledo')," +
                        "(4127809,41,'Tomazina')," +
                        "(4127858,41,'Três Barras do Paraná')," +
                        "(4127882,41,'Tunas do Paraná')," +
                        "(4127908,41,'Tuneiras do Oeste')," +
                        "(4127957,41,'Tupãssi')," +
                        "(4127965,41,'Turvo')," +
                        "(4128005,41,'Ubiratã')," +
                        "(4128104,41,'Umuarama')," +
                        "(4128203,41,'União da Vitória')," +
                        "(4128302,41,'Uniflor')," +
                        "(4128401,41,'Uraí')," +
                        "(4128500,41,'Wenceslau Braz')," +
                        "(4128534,41,'Ventania')," +
                        "(4128559,41,'Vera Cruz do Oeste')," +
                        "(4128609,41,'Verê')," +
                        "(4128625,41,'Alto Paraíso')," +
                        "(4128633,41,'doutor Ulysses')," +
                        "(4128658,41,'Virmond')," +
                        "(4128708,41,'Vitorino')," +
                        "(4128807,41,'Xambrê')," +
                        "(4200051,42,'Abdon Batista')," +
                        "(4200101,42,'Abelardo Luz')," +
                        "(4200200,42,'Agrolândia')," +
                        "(4200309,42,'Agronômica')," +
                        "(4200408,42,'Água doce')," +
                        "(4200507,42,'Águas de Chapecó')," +
                        "(4200556,42,'Águas Frias')," +
                        "(4200606,42,'Águas Mornas')," +
                        "(4200705,42,'Alfredo Wagner')," +
                        "(4200754,42,'Alto Bela Vista')," +
                        "(4200804,42,'Anchieta')," +
                        "(4200903,42,'Angelina')," +
                        "(4201000,42,'Anita Garibaldi')," +
                        "(4201109,42,'Anitápolis')," +
                        "(4201208,42,'Antônio Carlos')," +
                        "(4201257,42,'Apiúna')," +
                        "(4201273,42,'Arabutã')," +
                        "(4201307,42,'Araquari')," +
                        "(4201406,42,'Araranguá')," +
                        "(4201505,42,'Armazém')," +
                        "(4201604,42,'Arroio Trinta')," +
                        "(4201653,42,'Arvoredo')," +
                        "(4201703,42,'Ascurra')," +
                        "(4201802,42,'Atalanta')," +
                        "(4201901,42,'Aurora')," +
                        "(4201950,42,'Balneário Arroio do Silva')," +
                        "(4202008,42,'Balneário Camboriú')," +
                        "(4202057,42,'Balneário Barra do Sul')," +
                        "(4202073,42,'Balneário Gaivota')," +
                        "(4202081,42,'Bandeirante')," +
                        "(4202099,42,'Barra Bonita')," +
                        "(4202107,42,'Barra Velha')," +
                        "(4202131,42,'Bela Vista do Toldo')," +
                        "(4202156,42,'Belmonte')," +
                        "(4202206,42,'Benedito Novo')," +
                        "(4202305,42,'Biguaçu')," +
                        "(4202404,42,'Blumenau')," +
                        "(4202438,42,'Bocaina do Sul')," +
                        "(4202453,42,'Bombinhas')," +
                        "(4202503,42,'Bom Jardim da Serra')," +
                        "(4202537,42,'Bom Jesus')," +
                        "(4202578,42,'Bom Jesus do Oeste')," +
                        "(4202602,42,'Bom Retiro')," +
                        "(4202701,42,'Botuverá')," +
                        "(4202800,42,'Braço do Norte')," +
                        "(4202859,42,'Braço do Trombudo')," +
                        "(4202875,42,'Brunópolis')," +
                        "(4202909,42,'Brusque')," +
                        "(4203006,42,'Caçador')," +
                        "(4203105,42,'Caibi')," +
                        "(4203154,42,'Calmon')," +
                        "(4203204,42,'Camboriú')," +
                        "(4203253,42,'Capão Alto')," +
                        "(4203303,42,'Campo Alegre')," +
                        "(4203402,42,'Campo Belo do Sul')," +
                        "(4203501,42,'Campo Erê')," +
                        "(4203600,42,'Campos Novos')," +
                        "(4203709,42,'Canelinha')," +
                        "(4203808,42,'Canoinhas')," +
                        "(4203907,42,'Capinzal')," +
                        "(4203956,42,'Capivari de Baixo')," +
                        "(4204004,42,'Catanduvas')," +
                        "(4204103,42,'Caxambu do Sul')," +
                        "(4204152,42,'Celso Ramos')," +
                        "(4204178,42,'Cerro Negro')," +
                        "(4204194,42,'Chapadão do Lageado')," +
                        "(4204202,42,'Chapecó')," +
                        "(4204251,42,'Cocal do Sul')," +
                        "(4204301,42,'Concórdia')," +
                        "(4204350,42,'Cordilheira Alta')," +
                        "(4204400,42,'Coronel Freitas')," +
                        "(4204459,42,'Coronel Martins')," +
                        "(4204509,42,'Corupá')," +
                        "(4204558,42,'Correia Pinto')," +
                        "(4204608,42,'Criciúma')," +
                        "(4204707,42,'Cunha Porã')," +
                        "(4204756,42,'Cunhataí')," +
                        "(4204806,42,'Curitibanos')," +
                        "(4204905,42,'descanso')," +
                        "(4205001,42,'Dionísio Cerqueira')," +
                        "(4205100,42,'dona Emma')," +
                        "(4205159,42,'doutor Pedrinho')," +
                        "(4205175,42,'Entre Rios')," +
                        "(4205191,42,'Ermo')," +
                        "(4205209,42,'Erval Velho')," +
                        "(4205308,42,'Faxinal dos Guedes')," +
                        "(4205357,42,'Flor do Sertão')," +
                        "(4205407,42,'Florianópolis')," +
                        "(4205431,42,'Formosa do Sul')," +
                        "(4205456,42,'Forquilhinha')," +
                        "(4205506,42,'Fraiburgo')," +
                        "(4205555,42,'Frei Rogério')," +
                        "(4205605,42,'Galvão')," +
                        "(4205704,42,'Garopaba')," +
                        "(4205803,42,'Garuva')," +
                        "(4205902,42,'Gaspar')," +
                        "(4206009,42,'Governador Celso Ramos')," +
                        "(4206108,42,'Grão Pará')," +
                        "(4206207,42,'Gravatal')," +
                        "(4206306,42,'Guabiruba')," +
                        "(4206405,42,'Guaraciaba')," +
                        "(4206504,42,'Guaramirim')," +
                        "(4206603,42,'Guarujá do Sul')," +
                        "(4206652,42,'Guatambú')," +
                        "(4206702,42,'Herval Doeste')," +
                        "(4206751,42,'Ibiam')," +
                        "(4206801,42,'Ibicaré')," +
                        "(4206900,42,'Ibirama')," +
                        "(4207007,42,'Içara')," +
                        "(4207106,42,'Ilhota')," +
                        "(4207205,42,'Imaruí')," +
                        "(4207304,42,'Imbituba')," +
                        "(4207403,42,'Imbuia')," +
                        "(4207502,42,'Indaial')," +
                        "(4207577,42,'Iomerê')," +
                        "(4207601,42,'Ipira')," +
                        "(4207650,42,'Iporã do Oeste')," +
                        "(4207684,42,'Ipuaçu')," +
                        "(4207700,42,'Ipumirim')," +
                        "(4207759,42,'Iraceminha')," +
                        "(4207809,42,'Irani')," +
                        "(4207858,42,'Irati')," +
                        "(4207908,42,'Irineópolis')," +
                        "(4208005,42,'Itá')," +
                        "(4208104,42,'Itaiópolis')," +
                        "(4208203,42,'Itajaí')," +
                        "(4208302,42,'Itapema')," +
                        "(4208401,42,'Itapiranga')," +
                        "(4208450,42,'Itapoá')," +
                        "(4208500,42,'Ituporanga')," +
                        "(4208609,42,'Jaborá')," +
                        "(4208708,42,'Jacinto Machado')," +
                        "(4208807,42,'Jaguaruna')," +
                        "(4208906,42,'Jaraguá do Sul')," +
                        "(4208955,42,'Jardinópolis')," +
                        "(4209003,42,'Joaçaba')," +
                        "(4209102,42,'Joinville')," +
                        "(4209151,42,'José Boiteux')," +
                        "(4209177,42,'Jupiá')," +
                        "(4209201,42,'Lacerdópolis')," +
                        "(4209300,42,'Lages')," +
                        "(4209409,42,'Laguna')," +
                        "(4209458,42,'Lajeado Grande')," +
                        "(4209508,42,'Laurentino')," +
                        "(4209607,42,'Lauro Muller')," +
                        "(4209706,42,'Lebon Régis')," +
                        "(4209805,42,'Leoberto Leal')," +
                        "(4209854,42,'Lindóia do Sul')," +
                        "(4209904,42,'Lontras')," +
                        "(4210001,42,'Luiz Alves')," +
                        "(4210035,42,'Luzerna')," +
                        "(4210050,42,'Macieira')," +
                        "(4210100,42,'Mafra')," +
                        "(4210209,42,'Major Gercino')," +
                        "(4210308,42,'Major Vieira')," +
                        "(4210407,42,'Maracajá')," +
                        "(4210506,42,'Maravilha')," +
                        "(4210555,42,'Marema')," +
                        "(4210605,42,'Massaranduba')," +
                        "(4210704,42,'Matos Costa')," +
                        "(4210803,42,'Meleiro')," +
                        "(4210852,42,'Mirim doce')," +
                        "(4210902,42,'Modelo')," +
                        "(4211009,42,'Mondaí')," +
                        "(4211058,42,'Monte Carlo')," +
                        "(4211108,42,'Monte Castelo')," +
                        "(4211207,42,'Morro da Fumaça')," +
                        "(4211256,42,'Morro Grande')," +
                        "(4211306,42,'Navegantes')," +
                        "(4211405,42,'Nova Erechim')," +
                        "(4211454,42,'Nova Itaberaba')," +
                        "(4211504,42,'Nova Trento')," +
                        "(4211603,42,'Nova Veneza')," +
                        "(4211652,42,'Novo Horizonte')," +
                        "(4211702,42,'Orleans')," +
                        "(4211751,42,'Otacílio Costa')," +
                        "(4211801,42,'Ouro')," +
                        "(4211850,42,'Ouro Verde')," +
                        "(4211876,42,'Paial')," +
                        "(4211892,42,'Painel')," +
                        "(4211900,42,'Palhoça')," +
                        "(4212007,42,'Palma Sola')," +
                        "(4212056,42,'Palmeira')," +
                        "(4212106,42,'Palmitos')," +
                        "(4212205,42,'Papanduva')," +
                        "(4212239,42,'Paraíso')," +
                        "(4212254,42,'Passo de Torres')," +
                        "(4212270,42,'Passos Maia')," +
                        "(4212304,42,'Paulo Lopes')," +
                        "(4212403,42,'Pedras Grandes')," +
                        "(4212502,42,'Penha')," +
                        "(4212601,42,'Peritiba')," +
                        "(4212650,42,'Pescaria Brava')," +
                        "(4212700,42,'Petrolândia')," +
                        "(4212809,42,'Balneário Piçarras')," +
                        "(4212908,42,'Pinhalzinho')," +
                        "(4213005,42,'Pinheiro Preto')," +
                        "(4213104,42,'Piratuba')," +
                        "(4213153,42,'Planalto Alegre')," +
                        "(4213203,42,'Pomerode')," +
                        "(4213302,42,'Ponte Alta')," +
                        "(4213351,42,'Ponte Alta do Norte')," +
                        "(4213401,42,'Ponte Serrada')," +
                        "(4213500,42,'Porto Belo')," +
                        "(4213609,42,'Porto União')," +
                        "(4213708,42,'Pouso Redondo')," +
                        "(4213807,42,'Praia Grande')," +
                        "(4213906,42,'Presidente Castello Branco')," +
                        "(4214003,42,'Presidente Getúlio')," +
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
                        "(4215208,42,'Romelândia')," +
                        "(4215307,42,'Salete')," +
                        "(4215356,42,'Saltinho')," +
                        "(4215406,42,'Salto Veloso')," +
                        "(4215455,42,'Sangão')," +
                        "(4215505,42,'Santa Cecília')," +
                        "(4215554,42,'Santa Helena')," +
                        "(4215604,42,'Santa Rosa de Lima')," +
                        "(4215653,42,'Santa Rosa do Sul')," +
                        "(4215679,42,'Santa Terezinha')," +
                        "(4215687,42,'Santa Terezinha do Progresso')," +
                        "(4215695,42,'Santiago do Sul')," +
                        "(4215703,42,'Santo Amaro da Imperatriz')," +
                        "(4215752,42,'São Bernardino')," +
                        "(4215802,42,'São Bento do Sul')," +
                        "(4215901,42,'São Bonifácio')," +
                        "(4216008,42,'São Carlos')," +
                        "(4216057,42,'São Cristovão do Sul')," +
                        "(4216107,42,'São domingos')," +
                        "(4216206,42,'São Francisco do Sul')," +
                        "(4216255,42,'São João do Oeste')," +
                        "(4216305,42,'São João Batista')," +
                        "(4216354,42,'São João do Itaperiú')," +
                        "(4216404,42,'São João do Sul')," +
                        "(4216503,42,'São Joaquim')," +
                        "(4216602,42,'São José')," +
                        "(4216701,42,'São José do Cedro')," +
                        "(4216800,42,'São José do Cerrito')," +
                        "(4216909,42,'São Lourenço do Oeste')," +
                        "(4217006,42,'São Ludgero')," +
                        "(4217105,42,'São Martinho')," +
                        "(4217154,42,'São Miguel da Boa Vista')," +
                        "(4217204,42,'São Miguel do Oeste')," +
                        "(4217253,42,'São Pedro de Alcântara')," +
                        "(4217303,42,'Saudades')," +
                        "(4217402,42,'Schroeder')," +
                        "(4217501,42,'Seara')," +
                        "(4217550,42,'Serra Alta')," +
                        "(4217600,42,'Siderópolis')," +
                        "(4217709,42,'Sombrio')," +
                        "(4217758,42,'Sul Brasil')," +
                        "(4217808,42,'Taió')," +
                        "(4217907,42,'Tangará')," +
                        "(4217956,42,'Tigrinhos')," +
                        "(4218004,42,'Tijucas')," +
                        "(4218103,42,'Timbé do Sul')," +
                        "(4218202,42,'Timbó')," +
                        "(4218251,42,'Timbó Grande')," +
                        "(4218301,42,'Três Barras')," +
                        "(4218350,42,'Treviso')," +
                        "(4218400,42,'Treze de Maio')," +
                        "(4218509,42,'Treze Tílias')," +
                        "(4218608,42,'Trombudo Central')," +
                        "(4218707,42,'Tubarão')," +
                        "(4218756,42,'Tunápolis')," +
                        "(4218806,42,'Turvo')," +
                        "(4218855,42,'União do Oeste')," +
                        "(4218905,42,'Urubici')," +
                        "(4218954,42,'Urupema')," +
                        "(4219002,42,'Urussanga')," +
                        "(4219101,42,'Vargeão')," +
                        "(4219150,42,'Vargem')," +
                        "(4219176,42,'Vargem Bonita')," +
                        "(4219200,42,'Vidal Ramos')," +
                        "(4219309,42,'Videira')," +
                        "(4219358,42,'Vitor Meireles')," +
                        "(4219408,42,'Witmarsum')," +
                        "(4219507,42,'Xanxerê')," +
                        "(4219606,42,'Xavantina')," +
                        "(4219705,42,'Xaxim')," +
                        "(4219853,42,'Zortéa')," +
                        "(4220000,42,'Balneário Rincão')," +
                        "(4300034,43,'Aceguá')," +
                        "(4300059,43,'Água Santa')," +
                        "(4300109,43,'Agudo')," +
                        "(4300208,43,'Ajuricaba')," +
                        "(4300307,43,'Alecrim')," +
                        "(4300406,43,'Alegrete')," +
                        "(4300455,43,'Alegria')," +
                        "(4300471,43,'Almirante Tamandaré do Sul')," +
                        "(4300505,43,'Alpestre')," +
                        "(4300554,43,'Alto Alegre')," +
                        "(4300570,43,'Alto Feliz')," +
                        "(4300604,43,'Alvorada')," +
                        "(4300638,43,'Amaral Ferrador')," +
                        "(4300646,43,'Ametista do Sul')," +
                        "(4300661,43,'André da Rocha')," +
                        "(4300703,43,'Anta Gorda')," +
                        "(4300802,43,'Antônio Prado')," +
                        "(4300851,43,'Arambaré')," +
                        "(4300877,43,'Araricá')," +
                        "(4300901,43,'Aratiba')," +
                        "(4301008,43,'Arroio do Meio')," +
                        "(4301057,43,'Arroio do Sal')," +
                        "(4301073,43,'Arroio do Padre')," +
                        "(4301107,43,'Arroio dos Ratos')," +
                        "(4301206,43,'Arroio do Tigre')," +
                        "(4301305,43,'Arroio Grande')," +
                        "(4301404,43,'Arvorezinha')," +
                        "(4301503,43,'Augusto Pestana')," +
                        "(4301552,43,'Áurea')," +
                        "(4301602,43,'Bagé')," +
                        "(4301636,43,'Balneário Pinhal')," +
                        "(4301651,43,'Barão')," +
                        "(4301701,43,'Barão de Cotegipe')," +
                        "(4301750,43,'Barão do Triunfo')," +
                        "(4301800,43,'Barracão')," +
                        "(4301859,43,'Barra do Guarita')," +
                        "(4301875,43,'Barra do Quaraí')," +
                        "(4301909,43,'Barra do Ribeiro')," +
                        "(4301925,43,'Barra do Rio Azul')," +
                        "(4301958,43,'Barra Funda')," +
                        "(4302006,43,'Barros Cassal')," +
                        "(4302055,43,'Benjamin Constant do Sul')," +
                        "(4302105,43,'Bento Gonçalves')," +
                        "(4302154,43,'Boa Vista das Missões')," +
                        "(4302204,43,'Boa Vista do Buricá')," +
                        "(4302220,43,'Boa Vista do Cadeado')," +
                        "(4302238,43,'Boa Vista do Incra')," +
                        "(4302253,43,'Boa Vista do Sul')," +
                        "(4302303,43,'Bom Jesus')," +
                        "(4302352,43,'Bom Princípio')," +
                        "(4302378,43,'Bom Progresso')," +
                        "(4302402,43,'Bom Retiro do Sul')," +
                        "(4302451,43,'Boqueirão do Leão')," +
                        "(4302501,43,'Bossoroca')," +
                        "(4302584,43,'Bozano')," +
                        "(4302600,43,'Braga')," +
                        "(4302659,43,'Brochier')," +
                        "(4302709,43,'Butiá')," +
                        "(4302808,43,'Caçapava do Sul')," +
                        "(4302907,43,'Cacequi')," +
                        "(4303004,43,'Cachoeira do Sul')," +
                        "(4303103,43,'Cachoeirinha')," +
                        "(4303202,43,'Cacique doble')," +
                        "(4303301,43,'Caibaté')," +
                        "(4303400,43,'Caiçara')," +
                        "(4303509,43,'Camaquã')," +
                        "(4303558,43,'Camargo')," +
                        "(4303608,43,'Cambará do Sul')," +
                        "(4303673,43,'Campestre da Serra')," +
                        "(4303707,43,'Campina das Missões')," +
                        "(4303806,43,'Campinas do Sul')," +
                        "(4303905,43,'Campo Bom')," +
                        "(4304002,43,'Campo Novo')," +
                        "(4304101,43,'Campos Borges')," +
                        "(4304200,43,'Candelária')," +
                        "(4304309,43,'Cândido Godói')," +
                        "(4304358,43,'Candiota')," +
                        "(4304408,43,'Canela')," +
                        "(4304507,43,'Canguçu')," +
                        "(4304606,43,'Canoas')," +
                        "(4304614,43,'Canudos do Vale')," +
                        "(4304622,43,'Capão Bonito do Sul')," +
                        "(4304630,43,'Capão da Canoa')," +
                        "(4304655,43,'Capão do Cipó')," +
                        "(4304663,43,'Capão do Leão')," +
                        "(4304671,43,'Capivari do Sul')," +
                        "(4304689,43,'Capela de Santana')," +
                        "(4304697,43,'Capitão')," +
                        "(4304705,43,'Carazinho')," +
                        "(4304713,43,'Caraá')," +
                        "(4304804,43,'Carlos Barbosa')," +
                        "(4304853,43,'Carlos Gomes')," +
                        "(4304903,43,'Casca')," +
                        "(4304952,43,'Caseiros')," +
                        "(4305009,43,'Catuípe')," +
                        "(4305108,43,'Caxias do Sul')," +
                        "(4305116,43,'Centenário')," +
                        "(4305124,43,'Cerrito')," +
                        "(4305132,43,'Cerro Branco')," +
                        "(4305157,43,'Cerro Grande')," +
                        "(4305173,43,'Cerro Grande do Sul')," +
                        "(4305207,43,'Cerro Largo')," +
                        "(4305306,43,'Chapada')," +
                        "(4305355,43,'Charqueadas')," +
                        "(4305371,43,'Charrua')," +
                        "(4305405,43,'Chiapetta')," +
                        "(4305439,43,'Chuí')," +
                        "(4305447,43,'Chuvisca')," +
                        "(4305454,43,'Cidreira')," +
                        "(4305504,43,'Ciríaco')," +
                        "(4305587,43,'Colinas')," +
                        "(4305603,43,'Colorado')," +
                        "(4305702,43,'Condor')," +
                        "(4305801,43,'Constantina')," +
                        "(4305835,43,'Coqueiro Baixo')," +
                        "(4305850,43,'Coqueiros do Sul')," +
                        "(4305871,43,'Coronel Barros')," +
                        "(4305900,43,'Coronel Bicaco')," +
                        "(4305934,43,'Coronel Pilar')," +
                        "(4305959,43,'Cotiporã')," +
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
                        "(4306403,43,'dois Irmãos')," +
                        "(4306429,43,'dois Irmãos das Missões')," +
                        "(4306452,43,'dois Lajeados')," +
                        "(4306502,43,'dom Feliciano')," +
                        "(4306551,43,'dom Pedro de Alcântara')," +
                        "(4306601,43,'dom Pedrito')," +
                        "(4306700,43,'dona Francisca')," +
                        "(4306734,43,'doutor Maurício Cardoso')," +
                        "(4306759,43,'doutor Ricardo')," +
                        "(4306767,43,'Eldorado do Sul')," +
                        "(4306809,43,'Encantado')," +
                        "(4306908,43,'Encruzilhada do Sul')," +
                        "(4306924,43,'Engenho Velho')," +
                        "(4306932,43,'Entre-Ijuís')," +
                        "(4306957,43,'Entre Rios do Sul')," +
                        "(4306973,43,'Erebango')," +
                        "(4307005,43,'Erechim')," +
                        "(4307054,43,'Ernestina')," +
                        "(4307104,43,'Herval')," +
                        "(4307203,43,'Erval Grande')," +
                        "(4307302,43,'Erval Seco')," +
                        "(4307401,43,'Esmeralda')," +
                        "(4307450,43,'Esperança do Sul')," +
                        "(4307500,43,'Espumoso')," +
                        "(4307559,43,'Estação')," +
                        "(4307609,43,'Estância Velha')," +
                        "(4307708,43,'Esteio')," +
                        "(4307807,43,'Estrela')," +
                        "(4307815,43,'Estrela Velha')," +
                        "(4307831,43,'Eugênio de Castro')," +
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
                        "(4308805,43,'General Câmara')," +
                        "(4308854,43,'Gentil')," +
                        "(4308904,43,'Getúlio Vargas')," +
                        "(4309001,43,'Giruá')," +
                        "(4309050,43,'Glorinha')," +
                        "(4309100,43,'Gramado')," +
                        "(4309126,43,'Gramado dos Loureiros')," +
                        "(4309159,43,'Gramado Xavier')," +
                        "(4309209,43,'Gravataí')," +
                        "(4309258,43,'Guabiju')," +
                        "(4309308,43,'Guaíba')," +
                        "(4309407,43,'Guaporé')," +
                        "(4309506,43,'Guarani das Missões')," +
                        "(4309555,43,'Harmonia')," +
                        "(4309571,43,'Herveiras')," +
                        "(4309605,43,'Horizontina')," +
                        "(4309654,43,'Hulha Negra')," +
                        "(4309704,43,'Humaitá')," +
                        "(4309753,43,'Ibarama')," +
                        "(4309803,43,'Ibiaçá')," +
                        "(4309902,43,'Ibiraiaras')," +
                        "(4309951,43,'Ibirapuitã')," +
                        "(4310009,43,'Ibirubá')," +
                        "(4310108,43,'Igrejinha')," +
                        "(4310207,43,'Ijuí')," +
                        "(4310306,43,'Ilópolis')," +
                        "(4310330,43,'Imbé')," +
                        "(4310363,43,'Imigrante')," +
                        "(4310405,43,'Independência')," +
                        "(4310413,43,'Inhacorá')," +
                        "(4310439,43,'Ipê')," +
                        "(4310462,43,'Ipiranga do Sul')," +
                        "(4310504,43,'Iraí')," +
                        "(4310538,43,'Itaara')," +
                        "(4310553,43,'Itacurubi')," +
                        "(4310579,43,'Itapuca')," +
                        "(4310603,43,'Itaqui')," +
                        "(4310652,43,'Itati')," +
                        "(4310702,43,'Itatiba do Sul')," +
                        "(4310751,43,'Ivorá')," +
                        "(4310801,43,'Ivoti')," +
                        "(4310850,43,'Jaboticaba')," +
                        "(4310876,43,'Jacuizinho')," +
                        "(4310900,43,'Jacutinga')," +
                        "(4311007,43,'Jaguarão')," +
                        "(4311106,43,'Jaguari')," +
                        "(4311122,43,'Jaquirana')," +
                        "(4311130,43,'Jari')," +
                        "(4311155,43,'Jóia')," +
                        "(4311205,43,'Júlio de Castilhos')," +
                        "(4311239,43,'Lagoa Bonita do Sul')," +
                        "(4311254,43,'Lagoão')," +
                        "(4311270,43,'Lagoa dos Três Cantos')," +
                        "(4311304,43,'Lagoa Vermelha')," +
                        "(4311403,43,'Lajeado')," +
                        "(4311429,43,'Lajeado do Bugre')," +
                        "(4311502,43,'Lavras do Sul')," +
                        "(4311601,43,'Liberato Salzano')," +
                        "(4311627,43,'Lindolfo Collor')," +
                        "(4311643,43,'Linha Nova')," +
                        "(4311700,43,'Machadinho')," +
                        "(4311718,43,'Maçambará')," +
                        "(4311734,43,'Mampituba')," +
                        "(4311759,43,'Manoel Viana')," +
                        "(4311775,43,'Maquiné')," +
                        "(4311791,43,'Maratá')," +
                        "(4311809,43,'Marau')," +
                        "(4311908,43,'Marcelino Ramos')," +
                        "(4311981,43,'Mariana Pimentel')," +
                        "(4312005,43,'Mariano Moro')," +
                        "(4312054,43,'Marques de Souza')," +
                        "(4312104,43,'Mata')," +
                        "(4312138,43,'Mato Castelhano')," +
                        "(4312153,43,'Mato Leitão')," +
                        "(4312179,43,'Mato Queimado')," +
                        "(4312203,43,'Maximiliano de Almeida')," +
                        "(4312252,43,'Minas do Leão')," +
                        "(4312302,43,'Miraguaí')," +
                        "(4312351,43,'Montauri')," +
                        "(4312377,43,'Monte Alegre dos Campos')," +
                        "(4312385,43,'Monte Belo do Sul')," +
                        "(4312401,43,'Montenegro')," +
                        "(4312427,43,'Mormaço')," +
                        "(4312443,43,'Morrinhos do Sul')," +
                        "(4312450,43,'Morro Redondo')," +
                        "(4312476,43,'Morro Reuter')," +
                        "(4312500,43,'Mostardas')," +
                        "(4312609,43,'Muçum')," +
                        "(4312617,43,'Muitos Capões')," +
                        "(4312625,43,'Muliterno')," +
                        "(4312658,43,'Não-Me-Toque')," +
                        "(4312674,43,'Nicolau Vergueiro')," +
                        "(4312708,43,'Nonoai')," +
                        "(4312757,43,'Nova Alvorada')," +
                        "(4312807,43,'Nova Araçá')," +
                        "(4312906,43,'Nova Bassano')," +
                        "(4312955,43,'Nova Boa Vista')," +
                        "(4313003,43,'Nova Bréscia')," +
                        "(4313011,43,'Nova Candelária')," +
                        "(4313037,43,'Nova Esperança do Sul')," +
                        "(4313060,43,'Nova Hartz')," +
                        "(4313086,43,'Nova Pádua')," +
                        "(4313102,43,'Nova Palma')," +
                        "(4313201,43,'Nova Petrópolis')," +
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
                        "(4313508,43,'Osório')," +
                        "(4313607,43,'Paim Filho')," +
                        "(4313656,43,'Palmares do Sul')," +
                        "(4313706,43,'Palmeira das Missões')," +
                        "(4313805,43,'Palmitinho')," +
                        "(4313904,43,'Panambi')," +
                        "(4313953,43,'Pantano Grande')," +
                        "(4314001,43,'Paraí')," +
                        "(4314027,43,'Paraíso do Sul')," +
                        "(4314035,43,'Pareci Novo')," +
                        "(4314050,43,'Parobé')," +
                        "(4314068,43,'Passa Sete')," +
                        "(4314076,43,'Passo do Sobrado')," +
                        "(4314100,43,'Passo Fundo')," +
                        "(4314134,43,'Paulo Bento')," +
                        "(4314159,43,'Paverama')," +
                        "(4314175,43,'Pedras Altas')," +
                        "(4314209,43,'Pedro Osório')," +
                        "(4314308,43,'Pejuçara')," +
                        "(4314407,43,'Pelotas')," +
                        "(4314423,43,'Picada Café')," +
                        "(4314456,43,'Pinhal')," +
                        "(4314464,43,'Pinhal da Serra')," +
                        "(4314472,43,'Pinhal Grande')," +
                        "(4314498,43,'Pinheirinho do Vale')," +
                        "(4314506,43,'Pinheiro Machado')," +
                        "(4314548,43,'Pinto Bandeira')," +
                        "(4314555,43,'Pirapó')," +
                        "(4314605,43,'Piratini')," +
                        "(4314704,43,'Planalto')," +
                        "(4314753,43,'Poço das Antas')," +
                        "(4314779,43,'Pontão')," +
                        "(4314787,43,'Ponte Preta')," +
                        "(4314803,43,'Portão')," +
                        "(4314902,43,'Porto Alegre')," +
                        "(4315008,43,'Porto Lucena')," +
                        "(4315057,43,'Porto Mauá')," +
                        "(4315073,43,'Porto Vera Cruz')," +
                        "(4315107,43,'Porto Xavier')," +
                        "(4315131,43,'Pouso Novo')," +
                        "(4315149,43,'Presidente Lucena')," +
                        "(4315156,43,'Progresso')," +
                        "(4315172,43,'Protásio Alves')," +
                        "(4315206,43,'Putinga')," +
                        "(4315305,43,'Quaraí')," +
                        "(4315313,43,'Quatro Irmãos')," +
                        "(4315321,43,'Quevedos')," +
                        "(4315354,43,'Quinze de Novembro')," +
                        "(4315404,43,'Redentora')," +
                        "(4315453,43,'Relvado')," +
                        "(4315503,43,'Restinga Seca')," +
                        "(4315552,43,'Rio dos Índios')," +
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
                        "(4316402,43,'Rosário do Sul')," +
                        "(4316428,43,'Sagrada Família')," +
                        "(4316436,43,'Saldanha Marinho')," +
                        "(4316451,43,'Salto do Jacuí')," +
                        "(4316477,43,'Salvador das Missões')," +
                        "(4316501,43,'Salvador do Sul')," +
                        "(4316600,43,'Sananduva')," +
                        "(4316709,43,'Santa Bárbara do Sul')," +
                        "(4316733,43,'Santa Cecília do Sul')," +
                        "(4316758,43,'Santa Clara do Sul')," +
                        "(4316808,43,'Santa Cruz do Sul')," +
                        "(4316907,43,'Santa Maria')," +
                        "(4316956,43,'Santa Maria do Herval')," +
                        "(4316972,43,'Santa Margarida do Sul')," +
                        "(4317004,43,'Santana da Boa Vista')," +
                        "(4317103,43,'Santana do Livramento')," +
                        "(4317202,43,'Santa Rosa')," +
                        "(4317251,43,'Santa Tereza')," +
                        "(4317301,43,'Santa Vitória do Palmar')," +
                        "(4317400,43,'Santiago')," +
                        "(4317509,43,'Santo Ângelo')," +
                        "(4317558,43,'Santo Antônio do Palma')," +
                        "(4317608,43,'Santo Antônio da Patrulha')," +
                        "(4317707,43,'Santo Antônio das Missões')," +
                        "(4317756,43,'Santo Antônio do Planalto')," +
                        "(4317806,43,'Santo Augusto')," +
                        "(4317905,43,'Santo Cristo')," +
                        "(4317954,43,'Santo Expedito do Sul')," +
                        "(4318002,43,'São Borja')," +
                        "(4318051,43,'São domingos do Sul')," +
                        "(4318101,43,'São Francisco de Assis')," +
                        "(4318200,43,'São Francisco de Paula')," +
                        "(4318309,43,'São Gabriel')," +
                        "(4318408,43,'São Jerônimo')," +
                        "(4318424,43,'São João da Urtiga')," +
                        "(4318432,43,'São João do Polêsine')," +
                        "(4318440,43,'São Jorge')," +
                        "(4318457,43,'São José das Missões')," +
                        "(4318465,43,'São José do Herval')," +
                        "(4318481,43,'São José do Hortêncio')," +
                        "(4318499,43,'São José do Inhacorá')," +
                        "(4318507,43,'São José do Norte')," +
                        "(4318606,43,'São José do Ouro')," +
                        "(4318614,43,'São José do Sul')," +
                        "(4318622,43,'São José dos Ausentes')," +
                        "(4318705,43,'São Leopoldo')," +
                        "(4318804,43,'São Lourenço do Sul')," +
                        "(4318903,43,'São Luiz Gonzaga')," +
                        "(4319000,43,'São Marcos')," +
                        "(4319109,43,'São Martinho')," +
                        "(4319125,43,'São Martinho da Serra')," +
                        "(4319158,43,'São Miguel das Missões')," +
                        "(4319208,43,'São Nicolau')," +
                        "(4319307,43,'São Paulo das Missões')," +
                        "(4319356,43,'São Pedro da Serra')," +
                        "(4319364,43,'São Pedro das Missões')," +
                        "(4319372,43,'São Pedro do Butiá')," +
                        "(4319406,43,'São Pedro do Sul')," +
                        "(4319505,43,'São Sebastião do Caí')," +
                        "(4319604,43,'São Sepé')," +
                        "(4319703,43,'São Valentim')," +
                        "(4319711,43,'São Valentim do Sul')," +
                        "(4319737,43,'São Valério do Sul')," +
                        "(4319752,43,'São Vendelino')," +
                        "(4319802,43,'São Vicente do Sul')," +
                        "(4319901,43,'Sapiranga')," +
                        "(4320008,43,'Sapucaia do Sul')," +
                        "(4320107,43,'Sarandi')," +
                        "(4320206,43,'Seberi')," +
                        "(4320230,43,'Sede Nova')," +
                        "(4320263,43,'Segredo')," +
                        "(4320305,43,'Selbach')," +
                        "(4320321,43,'Senador Salgado Filho')," +
                        "(4320354,43,'Sentinela do Sul')," +
                        "(4320404,43,'Serafina Corrêa')," +
                        "(4320453,43,'Sério')," +
                        "(4320503,43,'Sertão')," +
                        "(4320552,43,'Sertão Santana')," +
                        "(4320578,43,'Sete de Setembro')," +
                        "(4320602,43,'Severiano de Almeida')," +
                        "(4320651,43,'Silveira Martins')," +
                        "(4320677,43,'Sinimbu')," +
                        "(4320701,43,'Sobradinho')," +
                        "(4320800,43,'Soledade')," +
                        "(4320859,43,'Tabaí')," +
                        "(4320909,43,'Tapejara')," +
                        "(4321006,43,'Tapera')," +
                        "(4321105,43,'Tapes')," +
                        "(4321204,43,'Taquara')," +
                        "(4321303,43,'Taquari')," +
                        "(4321329,43,'Taquaruçu do Sul')," +
                        "(4321352,43,'Tavares')," +
                        "(4321402,43,'Tenente Portela')," +
                        "(4321436,43,'Terra de Areia')," +
                        "(4321451,43,'Teutônia')," +
                        "(4321469,43,'Tio Hugo')," +
                        "(4321477,43,'Tiradentes do Sul')," +
                        "(4321493,43,'Toropi')," +
                        "(4321501,43,'Torres')," +
                        "(4321600,43,'Tramandaí')," +
                        "(4321626,43,'Travesseiro')," +
                        "(4321634,43,'Três Arroios')," +
                        "(4321667,43,'Três Cachoeiras')," +
                        "(4321709,43,'Três Coroas')," +
                        "(4321808,43,'Três de Maio')," +
                        "(4321832,43,'Três Forquilhas')," +
                        "(4321857,43,'Três Palmeiras')," +
                        "(4321907,43,'Três Passos')," +
                        "(4321956,43,'Trindade do Sul')," +
                        "(4322004,43,'Triunfo')," +
                        "(4322103,43,'Tucunduva')," +
                        "(4322152,43,'Tunas')," +
                        "(4322186,43,'Tupanci do Sul')," +
                        "(4322202,43,'Tupanciretã')," +
                        "(4322251,43,'Tupandi')," +
                        "(4322301,43,'Tuparendi')," +
                        "(4322327,43,'Turuçu')," +
                        "(4322343,43,'Ubiretama')," +
                        "(4322350,43,'União da Serra')," +
                        "(4322376,43,'Unistalda')," +
                        "(4322400,43,'Uruguaiana')," +
                        "(4322509,43,'Vacaria')," +
                        "(4322525,43,'Vale Verde')," +
                        "(4322533,43,'Vale do Sol')," +
                        "(4322541,43,'Vale Real')," +
                        "(4322558,43,'Vanini')," +
                        "(4322608,43,'Venâncio Aires')," +
                        "(4322707,43,'Vera Cruz')," +
                        "(4322806,43,'Veranópolis')," +
                        "(4322855,43,'Vespasiano Correa')," +
                        "(4322905,43,'Viadutos')," +
                        "(4323002,43,'Viamão')," +
                        "(4323101,43,'Vicente Dutra')," +
                        "(4323200,43,'Victor Graeff')," +
                        "(4323309,43,'Vila Flores')," +
                        "(4323358,43,'Vila Lângaro')," +
                        "(4323408,43,'Vila Maria')," +
                        "(4323457,43,'Vila Nova do Sul')," +
                        "(4323507,43,'Vista Alegre')," +
                        "(4323606,43,'Vista Alegre do Prata')," +
                        "(4323705,43,'Vista Gaúcha')," +
                        "(4323754,43,'Vitória das Missões')," +
                        "(4323770,43,'Westfalia')," +
                        "(4323804,43,'Xangri-Lá')," +
                        "(5000203,50,'Água Clara')," +
                        "(5000252,50,'Alcinópolis')," +
                        "(5000609,50,'Amambai')," +
                        "(5000708,50,'Anastácio')," +
                        "(5000807,50,'Anaurilândia')," +
                        "(5000856,50,'Angélica')," +
                        "(5000906,50,'Antônio João')," +
                        "(5001003,50,'Aparecida do Taboado')," +
                        "(5001102,50,'Aquidauana')," +
                        "(5001243,50,'Aral Moreira')," +
                        "(5001508,50,'Bandeirantes')," +
                        "(5001904,50,'Bataguassu')," +
                        "(5002001,50,'Batayporã')," +
                        "(5002100,50,'Bela Vista')," +
                        "(5002159,50,'Bodoquena')," +
                        "(5002209,50,'Bonito')," +
                        "(5002308,50,'Brasilândia')," +
                        "(5002407,50,'Caarapó')," +
                        "(5002605,50,'Camapuã')," +
                        "(5002704,50,'Campo Grande')," +
                        "(5002803,50,'Caracol')," +
                        "(5002902,50,'Cassilândia')," +
                        "(5002951,50,'Chapadão do Sul')," +
                        "(5003108,50,'Corguinho')," +
                        "(5003157,50,'Coronel Sapucaia')," +
                        "(5003207,50,'Corumbá')," +
                        "(5003256,50,'Costa Rica')," +
                        "(5003306,50,'Coxim')," +
                        "(5003454,50,'deodápolis')," +
                        "(5003488,50,'dois Irmãos do Buriti')," +
                        "(5003504,50,'douradina')," +
                        "(5003702,50,'dourados')," +
                        "(5003751,50,'Eldorado')," +
                        "(5003801,50,'Fátima do Sul')," +
                        "(5003900,50,'Figueirão')," +
                        "(5004007,50,'Glória de dourados')," +
                        "(5004106,50,'Guia Lopes da Laguna')," +
                        "(5004304,50,'Iguatemi')," +
                        "(5004403,50,'Inocência')," +
                        "(5004502,50,'Itaporã')," +
                        "(5004601,50,'Itaquiraí')," +
                        "(5004700,50,'Ivinhema')," +
                        "(5004809,50,'Japorã')," +
                        "(5004908,50,'Jaraguari')," +
                        "(5005004,50,'Jardim')," +
                        "(5005103,50,'Jateí')," +
                        "(5005152,50,'Juti')," +
                        "(5005202,50,'Ladário')," +
                        "(5005251,50,'Laguna Carapã')," +
                        "(5005400,50,'Maracaju')," +
                        "(5005608,50,'Miranda')," +
                        "(5005681,50,'Mundo Novo')," +
                        "(5005707,50,'Naviraí')," +
                        "(5005806,50,'Nioaque')," +
                        "(5006002,50,'Nova Alvorada do Sul')," +
                        "(5006200,50,'Nova Andradina')," +
                        "(5006259,50,'Novo Horizonte do Sul')," +
                        "(5006275,50,'Paraíso das Águas')," +
                        "(5006309,50,'Paranaíba')," +
                        "(5006358,50,'Paranhos')," +
                        "(5006408,50,'Pedro Gomes')," +
                        "(5006606,50,'Ponta Porã')," +
                        "(5006903,50,'Porto Murtinho')," +
                        "(5007109,50,'Ribas do Rio Pardo')," +
                        "(5007208,50,'Rio Brilhante')," +
                        "(5007307,50,'Rio Negro')," +
                        "(5007406,50,'Rio Verde de Mato Grosso')," +
                        "(5007505,50,'Rochedo')," +
                        "(5007554,50,'Santa Rita do Pardo')," +
                        "(5007695,50,'São Gabriel do Oeste')," +
                        "(5007703,50,'Sete Quedas')," +
                        "(5007802,50,'Selvíria')," +
                        "(5007901,50,'Sidrolândia')," +
                        "(5007935,50,'Sonora')," +
                        "(5007950,50,'Tacuru')," +
                        "(5007976,50,'Taquarussu')," +
                        "(5008008,50,'Terenos')," +
                        "(5008305,50,'Três Lagoas')," +
                        "(5008404,50,'Vicentina')," +
                        "(5100102,51,'Acorizal')," +
                        "(5100201,51,'Água Boa')," +
                        "(5100250,51,'Alta Floresta')," +
                        "(5100300,51,'Alto Araguaia')," +
                        "(5100359,51,'Alto Boa Vista')," +
                        "(5100409,51,'Alto Garças')," +
                        "(5100508,51,'Alto Paraguai')," +
                        "(5100607,51,'Alto Taquari')," +
                        "(5100805,51,'Apiacás')," +
                        "(5101001,51,'Araguaiana')," +
                        "(5101209,51,'Araguainha')," +
                        "(5101258,51,'Araputanga')," +
                        "(5101308,51,'Arenápolis')," +
                        "(5101407,51,'Aripuanã')," +
                        "(5101605,51,'Barão de Melgaço')," +
                        "(5101704,51,'Barra do Bugres')," +
                        "(5101803,51,'Barra do Garças')," +
                        "(5101852,51,'Bom Jesus do Araguaia')," +
                        "(5101902,51,'Brasnorte')," +
                        "(5102504,51,'Cáceres')," +
                        "(5102603,51,'Campinápolis')," +
                        "(5102637,51,'Campo Novo do Parecis')," +
                        "(5102678,51,'Campo Verde')," +
                        "(5102686,51,'Campos de Júlio')," +
                        "(5102694,51,'Canabrava do Norte')," +
                        "(5102702,51,'Canarana')," +
                        "(5102793,51,'Carlinda')," +
                        "(5102850,51,'Castanheira')," +
                        "(5103007,51,'Chapada dos Guimarães')," +
                        "(5103056,51,'Cláudia')," +
                        "(5103106,51,'Cocalinho')," +
                        "(5103205,51,'Colíder')," +
                        "(5103254,51,'Colniza')," +
                        "(5103304,51,'Comodoro')," +
                        "(5103353,51,'Confresa')," +
                        "(5103361,51,'Conquista Doeste')," +
                        "(5103379,51,'Cotriguaçu')," +
                        "(5103403,51,'Cuiabá')," +
                        "(5103437,51,'Curvelândia')," +
                        "(5103452,51,'denise')," +
                        "(5103502,51,'Diamantino')," +
                        "(5103601,51,'dom Aquino')," +
                        "(5103700,51,'Feliz Natal')," +
                        "(5103809,51,'Figueirópolis Doeste')," +
                        "(5103858,51,'Gaúcha do Norte')," +
                        "(5103908,51,'General Carneiro')," +
                        "(5103957,51,'Glória Doeste')," +
                        "(5104104,51,'Guarantã do Norte')," +
                        "(5104203,51,'Guiratinga')," +
                        "(5104500,51,'Indiavaí')," +
                        "(5104526,51,'Ipiranga do Norte')," +
                        "(5104542,51,'Itanhangá')," +
                        "(5104559,51,'Itaúba')," +
                        "(5104609,51,'Itiquira')," +
                        "(5104807,51,'Jaciara')," +
                        "(5104906,51,'Jangada')," +
                        "(5105002,51,'Jauru')," +
                        "(5105101,51,'Juara')," +
                        "(5105150,51,'Juína')," +
                        "(5105176,51,'Juruena')," +
                        "(5105200,51,'Juscimeira')," +
                        "(5105234,51,'Lambari Doeste')," +
                        "(5105259,51,'Lucas do Rio Verde')," +
                        "(5105309,51,'Luciara')," +
                        "(5105507,51,'Vila Bela da Santíssima Trindade')," +
                        "(5105580,51,'Marcelândia')," +
                        "(5105606,51,'Matupá')," +
                        "(5105622,51,'Mirassol Doeste')," +
                        "(5105903,51,'Nobres')," +
                        "(5106000,51,'Nortelândia')," +
                        "(5106109,51,'Nossa Senhora do Livramento')," +
                        "(5106158,51,'Nova Bandeirantes')," +
                        "(5106174,51,'Nova Nazaré')," +
                        "(5106182,51,'Nova Lacerda')," +
                        "(5106190,51,'Nova Santa Helena')," +
                        "(5106208,51,'Nova Brasilândia')," +
                        "(5106216,51,'Nova Canaã do Norte')," +
                        "(5106224,51,'Nova Mutum')," +
                        "(5106232,51,'Nova Olímpia')," +
                        "(5106240,51,'Nova Ubiratã')," +
                        "(5106257,51,'Nova Xavantina')," +
                        "(5106265,51,'Novo Mundo')," +
                        "(5106273,51,'Novo Horizonte do Norte')," +
                        "(5106281,51,'Novo São Joaquim')," +
                        "(5106299,51,'Paranaíta')," +
                        "(5106307,51,'Paranatinga')," +
                        "(5106315,51,'Novo Santo Antônio')," +
                        "(5106372,51,'Pedra Preta')," +
                        "(5106422,51,'Peixoto de Azevedo')," +
                        "(5106455,51,'Planalto da Serra')," +
                        "(5106505,51,'Poconé')," +
                        "(5106653,51,'Pontal do Araguaia')," +
                        "(5106703,51,'Ponte Branca')," +
                        "(5106752,51,'Pontes E Lacerda')," +
                        "(5106778,51,'Porto Alegre do Norte')," +
                        "(5106802,51,'Porto dos Gaúchos')," +
                        "(5106828,51,'Porto Esperidião')," +
                        "(5106851,51,'Porto Estrela')," +
                        "(5107008,51,'Poxoréu')," +
                        "(5107040,51,'Primavera do Leste')," +
                        "(5107065,51,'Querência')," +
                        "(5107107,51,'São José dos Quatro Marcos')," +
                        "(5107156,51,'Reserva do Cabaçal')," +
                        "(5107180,51,'Ribeirão Cascalheira')," +
                        "(5107198,51,'Ribeirãozinho')," +
                        "(5107206,51,'Rio Branco')," +
                        "(5107248,51,'Santa Carmem')," +
                        "(5107263,51,'Santo Afonso')," +
                        "(5107297,51,'São José do Povo')," +
                        "(5107305,51,'São José do Rio Claro')," +
                        "(5107354,51,'São José do Xingu')," +
                        "(5107404,51,'São Pedro da Cipa')," +
                        "(5107578,51,'Rondolândia')," +
                        "(5107602,51,'Rondonópolis')," +
                        "(5107701,51,'Rosário Oeste')," +
                        "(5107743,51,'Santa Cruz do Xingu')," +
                        "(5107750,51,'Salto do Céu')," +
                        "(5107768,51,'Santa Rita do Trivelato')," +
                        "(5107776,51,'Santa Terezinha')," +
                        "(5107792,51,'Santo Antônio do Leste')," +
                        "(5107800,51,'Santo Antônio do Leverger')," +
                        "(5107859,51,'São Félix do Araguaia')," +
                        "(5107875,51,'Sapezal')," +
                        "(5107883,51,'Serra Nova dourada')," +
                        "(5107909,51,'Sinop')," +
                        "(5107925,51,'Sorriso')," +
                        "(5107941,51,'Tabaporã')," +
                        "(5107958,51,'Tangará da Serra')," +
                        "(5108006,51,'Tapurah')," +
                        "(5108055,51,'Terra Nova do Norte')," +
                        "(5108105,51,'Tesouro')," +
                        "(5108204,51,'Torixoréu')," +
                        "(5108303,51,'União do Sul')," +
                        "(5108352,51,'Vale de São domingos')," +
                        "(5108402,51,'Várzea Grande')," +
                        "(5108501,51,'Vera')," +
                        "(5108600,51,'Vila Rica')," +
                        "(5108808,51,'Nova Guarita')," +
                        "(5108857,51,'Nova Marilândia')," +
                        "(5108907,51,'Nova Maringá')," +
                        "(5108956,51,'Nova Monte Verde')," +
                        "(5200050,52,'Abadia de Goiás')," +
                        "(5200100,52,'Abadiânia')," +
                        "(5200134,52,'Acreúna')," +
                        "(5200159,52,'Adelândia')," +
                        "(5200175,52,'Água Fria de Goiás')," +
                        "(5200209,52,'Água Limpa')," +
                        "(5200258,52,'Águas Lindas de Goiás')," +
                        "(5200308,52,'Alexânia')," +
                        "(5200506,52,'Aloândia')," +
                        "(5200555,52,'Alto Horizonte')," +
                        "(5200605,52,'Alto Paraíso de Goiás')," +
                        "(5200803,52,'Alvorada do Norte')," +
                        "(5200829,52,'Amaralina')," +
                        "(5200852,52,'Americano do Brasil')," +
                        "(5200902,52,'Amorinópolis')," +
                        "(5201108,52,'Anápolis')," +
                        "(5201207,52,'Anhanguera')," +
                        "(5201306,52,'Anicuns')," +
                        "(5201405,52,'Aparecida de Goiânia')," +
                        "(5201454,52,'Aparecida do Rio doce')," +
                        "(5201504,52,'Aporé')," +
                        "(5201603,52,'Araçu')," +
                        "(5201702,52,'Aragarças')," +
                        "(5201801,52,'Aragoiânia')," +
                        "(5202155,52,'Araguapaz')," +
                        "(5202353,52,'Arenópolis')," +
                        "(5202502,52,'Aruanã')," +
                        "(5202601,52,'Aurilândia')," +
                        "(5202809,52,'Avelinópolis')," +
                        "(5203104,52,'Baliza')," +
                        "(5203203,52,'Barro Alto')," +
                        "(5203302,52,'Bela Vista de Goiás')," +
                        "(5203401,52,'Bom Jardim de Goiás')," +
                        "(5203500,52,'Bom Jesus de Goiás')," +
                        "(5203559,52,'Bonfinópolis')," +
                        "(5203575,52,'Bonópolis')," +
                        "(5203609,52,'Brazabrantes')," +
                        "(5203807,52,'Britânia')," +
                        "(5203906,52,'Buriti Alegre')," +
                        "(5203939,52,'Buriti de Goiás')," +
                        "(5203962,52,'Buritinópolis')," +
                        "(5204003,52,'Cabeceiras')," +
                        "(5204102,52,'Cachoeira Alta')," +
                        "(5204201,52,'Cachoeira de Goiás')," +
                        "(5204250,52,'Cachoeira dourada')," +
                        "(5204300,52,'Caçu')," +
                        "(5204409,52,'Caiapônia')," +
                        "(5204508,52,'Caldas Novas')," +
                        "(5204557,52,'Caldazinha')," +
                        "(5204607,52,'Campestre de Goiás')," +
                        "(5204656,52,'Campinaçu')," +
                        "(5204706,52,'Campinorte')," +
                        "(5204805,52,'Campo Alegre de Goiás')," +
                        "(5204854,52,'Campo Limpo de Goiás')," +
                        "(5204904,52,'Campos Belos')," +
                        "(5204953,52,'Campos Verdes')," +
                        "(5205000,52,'Carmo do Rio Verde')," +
                        "(5205059,52,'Castelândia')," +
                        "(5205109,52,'Catalão')," +
                        "(5205208,52,'Caturaí')," +
                        "(5205307,52,'Cavalcante')," +
                        "(5205406,52,'Ceres')," +
                        "(5205455,52,'Cezarina')," +
                        "(5205471,52,'Chapadão do Céu')," +
                        "(5205497,52,'Cidade Ocidental')," +
                        "(5205513,52,'Cocalzinho de Goiás')," +
                        "(5205521,52,'Colinas do Sul')," +
                        "(5205703,52,'Córrego do Ouro')," +
                        "(5205802,52,'Corumbá de Goiás')," +
                        "(5205901,52,'Corumbaíba')," +
                        "(5206206,52,'Cristalina')," +
                        "(5206305,52,'Cristianópolis')," +
                        "(5206404,52,'Crixás')," +
                        "(5206503,52,'Cromínia')," +
                        "(5206602,52,'Cumari')," +
                        "(5206701,52,'damianópolis')," +
                        "(5206800,52,'damolândia')," +
                        "(5206909,52,'davinópolis')," +
                        "(5207105,52,'Diorama')," +
                        "(5207253,52,'doverlândia')," +
                        "(5207352,52,'Edealina')," +
                        "(5207402,52,'Edéia')," +
                        "(5207501,52,'Estrela do Norte')," +
                        "(5207535,52,'Faina')," +
                        "(5207600,52,'Fazenda Nova')," +
                        "(5207808,52,'Firminópolis')," +
                        "(5207907,52,'Flores de Goiás')," +
                        "(5208004,52,'Formosa')," +
                        "(5208103,52,'Formoso')," +
                        "(5208152,52,'Gameleira de Goiás')," +
                        "(5208301,52,'Divinópolis de Goiás')," +
                        "(5208400,52,'Goianápolis')," +
                        "(5208509,52,'Goiandira')," +
                        "(5208608,52,'Goianésia')," +
                        "(5208707,52,'Goiânia')," +
                        "(5208806,52,'Goianira')," +
                        "(5208905,52,'Goiás')," +
                        "(5209101,52,'Goiatuba')," +
                        "(5209150,52,'Gouvelândia')," +
                        "(5209200,52,'Guapó')," +
                        "(5209291,52,'Guaraíta')," +
                        "(5209408,52,'Guarani de Goiás')," +
                        "(5209457,52,'Guarinos')," +
                        "(5209606,52,'Heitoraí')," +
                        "(5209705,52,'Hidrolândia')," +
                        "(5209804,52,'Hidrolina')," +
                        "(5209903,52,'Iaciara')," +
                        "(5209937,52,'Inaciolândia')," +
                        "(5209952,52,'Indiara')," +
                        "(5210000,52,'Inhumas')," +
                        "(5210109,52,'Ipameri')," +
                        "(5210158,52,'Ipiranga de Goiás')," +
                        "(5210208,52,'Iporá')," +
                        "(5210307,52,'Israelândia')," +
                        "(5210406,52,'Itaberaí')," +
                        "(5210562,52,'Itaguari')," +
                        "(5210604,52,'Itaguaru')," +
                        "(5210802,52,'Itajá')," +
                        "(5210901,52,'Itapaci')," +
                        "(5211008,52,'Itapirapuã')," +
                        "(5211206,52,'Itapuranga')," +
                        "(5211305,52,'Itarumã')," +
                        "(5211404,52,'Itauçu')," +
                        "(5211503,52,'Itumbiara')," +
                        "(5211602,52,'Ivolândia')," +
                        "(5211701,52,'Jandaia')," +
                        "(5211800,52,'Jaraguá')," +
                        "(5211909,52,'Jataí')," +
                        "(5212006,52,'Jaupaci')," +
                        "(5212055,52,'Jesúpolis')," +
                        "(5212105,52,'Joviânia')," +
                        "(5212204,52,'Jussara')," +
                        "(5212253,52,'Lagoa Santa')," +
                        "(5212303,52,'Leopoldo de Bulhões')," +
                        "(5212501,52,'Luziânia')," +
                        "(5212600,52,'Mairipotaba')," +
                        "(5212709,52,'Mambaí')," +
                        "(5212808,52,'Mara Rosa')," +
                        "(5212907,52,'Marzagão')," +
                        "(5212956,52,'Matrinchã')," +
                        "(5213004,52,'Maurilândia')," +
                        "(5213053,52,'Mimoso de Goiás')," +
                        "(5213087,52,'Minaçu')," +
                        "(5213103,52,'Mineiros')," +
                        "(5213400,52,'Moiporá')," +
                        "(5213509,52,'Monte Alegre de Goiás')," +
                        "(5213707,52,'Montes Claros de Goiás')," +
                        "(5213756,52,'Montividiu')," +
                        "(5213772,52,'Montividiu do Norte')," +
                        "(5213806,52,'Morrinhos')," +
                        "(5213855,52,'Morro Agudo de Goiás')," +
                        "(5213905,52,'Mossâmedes')," +
                        "(5214002,52,'Mozarlândia')," +
                        "(5214051,52,'Mundo Novo')," +
                        "(5214101,52,'Mutunópolis')," +
                        "(5214408,52,'Nazário')," +
                        "(5214507,52,'Nerópolis')," +
                        "(5214606,52,'Niquelândia')," +
                        "(5214705,52,'Nova América')," +
                        "(5214804,52,'Nova Aurora')," +
                        "(5214838,52,'Nova Crixás')," +
                        "(5214861,52,'Nova Glória')," +
                        "(5214879,52,'Nova Iguaçu de Goiás')," +
                        "(5214903,52,'Nova Roma')," +
                        "(5215009,52,'Nova Veneza')," +
                        "(5215207,52,'Novo Brasil')," +
                        "(5215231,52,'Novo Gama')," +
                        "(5215256,52,'Novo Planalto')," +
                        "(5215306,52,'Orizona')," +
                        "(5215405,52,'Ouro Verde de Goiás')," +
                        "(5215504,52,'Ouvidor')," +
                        "(5215603,52,'Padre Bernardo')," +
                        "(5215652,52,'Palestina de Goiás')," +
                        "(5215702,52,'Palmeiras de Goiás')," +
                        "(5215801,52,'Palmelo')," +
                        "(5215900,52,'Palminópolis')," +
                        "(5216007,52,'Panamá')," +
                        "(5216304,52,'Paranaiguara')," +
                        "(5216403,52,'Paraúna')," +
                        "(5216452,52,'Perolândia')," +
                        "(5216809,52,'Petrolina de Goiás')," +
                        "(5216908,52,'Pilar de Goiás')," +
                        "(5217104,52,'Piracanjuba')," +
                        "(5217203,52,'Piranhas')," +
                        "(5217302,52,'Pirenópolis')," +
                        "(5217401,52,'Pires do Rio')," +
                        "(5217609,52,'Planaltina')," +
                        "(5217708,52,'Pontalina')," +
                        "(5218003,52,'Porangatu')," +
                        "(5218052,52,'Porteirão')," +
                        "(5218102,52,'Portelândia')," +
                        "(5218300,52,'Posse')," +
                        "(5218391,52,'Professor Jamil')," +
                        "(5218508,52,'Quirinópolis')," +
                        "(5218607,52,'Rialma')," +
                        "(5218706,52,'Rianápolis')," +
                        "(5218789,52,'Rio Quente')," +
                        "(5218805,52,'Rio Verde')," +
                        "(5218904,52,'Rubiataba')," +
                        "(5219001,52,'Sanclerlândia')," +
                        "(5219100,52,'Santa Bárbara de Goiás')," +
                        "(5219209,52,'Santa Cruz de Goiás')," +
                        "(5219258,52,'Santa Fé de Goiás')," +
                        "(5219308,52,'Santa Helena de Goiás')," +
                        "(5219357,52,'Santa Isabel')," +
                        "(5219407,52,'Santa Rita do Araguaia')," +
                        "(5219456,52,'Santa Rita do Novo destino')," +
                        "(5219506,52,'Santa Rosa de Goiás')," +
                        "(5219605,52,'Santa Tereza de Goiás')," +
                        "(5219704,52,'Santa Terezinha de Goiás')," +
                        "(5219712,52,'Santo Antônio da Barra')," +
                        "(5219738,52,'Santo Antônio de Goiás')," +
                        "(5219753,52,'Santo Antônio do descoberto')," +
                        "(5219803,52,'São domingos')," +
                        "(5219902,52,'São Francisco de Goiás')," +
                        "(5220009,52,'São João Daliança')," +
                        "(5220058,52,'São João da Paraúna')," +
                        "(5220108,52,'São Luís de Montes Belos')," +
                        "(5220157,52,'São Luíz do Norte')," +
                        "(5220207,52,'São Miguel do Araguaia')," +
                        "(5220264,52,'São Miguel do Passa Quatro')," +
                        "(5220280,52,'São Patrício')," +
                        "(5220405,52,'São Simão')," +
                        "(5220454,52,'Senador Canedo')," +
                        "(5220504,52,'Serranópolis')," +
                        "(5220603,52,'Silvânia')," +
                        "(5220686,52,'Simolândia')," +
                        "(5220702,52,'Sítio Dabadia')," +
                        "(5221007,52,'Taquaral de Goiás')," +
                        "(5221080,52,'Teresina de Goiás')," +
                        "(5221197,52,'Terezópolis de Goiás')," +
                        "(5221304,52,'Três Ranchos')," +
                        "(5221403,52,'Trindade')," +
                        "(5221452,52,'Trombas')," +
                        "(5221502,52,'Turvânia')," +
                        "(5221551,52,'Turvelândia')," +
                        "(5221577,52,'Uirapuru')," +
                        "(5221601,52,'Uruaçu')," +
                        "(5221700,52,'Uruana')," +
                        "(5221809,52,'Urutaí')," +
                        "(5221858,52,'Valparaíso de Goiás')," +
                        "(5221908,52,'Varjão')," +
                        "(5222005,52,'Vianópolis')," +
                        "(5222054,52,'Vicentinópolis')," +
                        "(5222203,52,'Vila Boa')," +
                        "(5222302,52,'Vila Propício')," +
                        "(5300108,53,'Brasília')";
        }
    }
}
