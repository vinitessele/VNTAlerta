using System;

namespace VNT_CentralDeNotificacao
{
    public class Crypt
    {

        public string Encrypt(string texto, string chave)
        {
            var codificado = EncodeTo64(texto);

            var codificarComChave = string.Concat(chave, "=====", codificado);

            var codificado2X = EncodeTo64(codificarComChave);

            return EncodeTo64(codificado2X);

        }
        public string Decrypt(string texto, string chave)
        {
            try
            {

                var decodificar = DecodeFrom64(texto);

                var decodificar2XInformacaoCompleta = DecodeFrom64(decodificar);

                String[] separador = { "=====" };
                Int32 count = 2;
                var separadorInformacao = decodificar2XInformacaoCompleta.Split(separador, count, StringSplitOptions.None);

                if (separadorInformacao[0].ToString() == chave)
                {
                    return DecodeFrom64(separadorInformacao[1].ToString());
                }
            }
            catch (Exception)
            {

            }
            return string.Empty;
        }

        static private string DecodeFrom64(string encodeData)
        {
            byte[] encodeDataAsByte = System.Convert.FromBase64String(encodeData);

            string returnValue = System.Text.ASCIIEncoding.UTF8.GetString(encodeDataAsByte);

            return returnValue;
        }

        static private string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsByte = System.Text.ASCIIEncoding.UTF8.GetBytes(toEncode);

            string returnValue = System.Convert.ToBase64String(toEncodeAsByte);

            return returnValue;
        }

    }
}
