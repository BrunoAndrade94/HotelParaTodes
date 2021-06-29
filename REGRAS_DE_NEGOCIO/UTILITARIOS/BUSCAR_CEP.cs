using System.IO;
using System.Net;
using System.Text;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS
{
    public class BUSCAR_CEP
    {
        public static string GERAR_JSON_CEP(string CEP)
        {
            System.Net.HttpWebRequest requisicao = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + CEP + "/json/");
            HttpWebResponse resposta = (HttpWebResponse)requisicao.GetResponse();

            int cont;
            byte[] buffer = new byte[1000];
            StringBuilder sb = new StringBuilder();
            string temp;
            Stream stream = resposta.GetResponseStream();
            do
            {
                cont = stream.Read(buffer, 0, buffer.Length);
                temp = Encoding.Default.GetString(buffer, 0, cont).Trim();
                sb.Append(temp);

            } while (cont > 0);
            return sb.ToString();
        }
    }
}
