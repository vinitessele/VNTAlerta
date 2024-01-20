namespace GeradorAtivador
{
    public partial class FrmAtiviador : Form
    {
        public FrmAtiviador()
        {
            InitializeComponent();
        }

        private void btnChaveAcesso_Click(object sender, EventArgs e)
        {
            //"Test0000";
            textChave.Text = geraChave(textEmpresa.Text);
        }

        public static char GetLetter()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num];
        }

        public static char GetDigit()
        {
            string chars = "0123456789";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num];
        }

        private string geraChave(string idempresa)
        {
            string[] partes = idempresa.Split(';');

            string key = idempresa.Substring(0, 1) + GetLetter() + GetDigit() + partes[1].Substring(0, 2);
            key += "-";
            key += idempresa.Substring(1, 1) + GetDigit() + GetLetter() + partes[1].Substring(3, 2);
            key += "-";
            key += idempresa.Substring(2, 1) + GetLetter() + GetDigit() + partes[1].Substring(6, 2);
            key += "-";
            key += idempresa.Substring(3, 1) + GetDigit() + GetLetter() + partes[1].Substring(8, 2);
            key += "-";
            key += idempresa.Substring(4, 4) + GetLetter();
            return key;
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            string arquivoLicenca = @"c:\temp\reg.vnt";
            string chave = "Ajasklskeoessinmieosiusfoiweuwww";
            if (!File.Exists(arquivoLicenca))
            {
                Crypt crypt = new();
                StreamWriter arquivo;
                // Criptografar
                arquivo = File.CreateText(arquivoLicenca);
                arquivo.WriteLine(crypt.Encrypt(textNomeEmpresa.Text, chave));
                arquivo.WriteLine(crypt.Encrypt(textCNPJ.Text, chave));
                
                textChaveAcesso.Text = geraChave(textidentificacaoCliente.Text+";"+ textexpira.Text);
                
                arquivo.WriteLine(crypt.Encrypt(textChaveAcesso.Text, chave));
                arquivo.WriteLine(crypt.Encrypt(textStatus.Text, chave));
                arquivo.WriteLine(crypt.Encrypt(textIdCidade.Text, chave));
                arquivo.WriteLine(crypt.Encrypt(textdataInicioAtivacao.Text, chave));
                arquivo.WriteLine(crypt.Encrypt(textexpira.Text, chave));
                arquivo.WriteLine(crypt.Encrypt(textidentificacaoCliente.Text, chave));
                arquivo.Close();
            }
        }
    }
}
