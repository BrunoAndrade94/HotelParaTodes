using HotelParaTodes.NOTIFICACOES;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS
{
    static class MINHAS_REGEX
    {
        public static string EMAIL { get; private set; } = @"^([\w\W]+)(@)(\w+)(\.)(\w+)(\.?)(\w+)";
        public static string RG { get; private set; } = @"^(\d{1,2})(\.?)(\d{3})(\.?)(\d{3})(-?)(\d{1}|X|x$)";
        public static string CPF { get; private set; } = @"^(\d{3})(\.)(\d{3})(\.)(\d{3})(\-)(\d{2}$)";
        public static string DATA { get; private set; } = @"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$";
        public static string TELEFONE { get; private set; } = @"^(\(\d{2}\))(\d\.)(\d+)(-?)(\d+)";


        public static void VALIDAR_REGEX(Control controle, string regex, string erro)
        {            
            string masked;
            Match resultado = null;
            var reg = new Regex(regex);
            if (controle is MaskedTextBox)
            {
                masked = REMOVER_MASKED.TEXTO_SEM_MASKED(controle as MaskedTextBox);
                //resultado = reg.Match(masked);
                resultado = reg.Match(controle.Text);
                if (!string.IsNullOrEmpty(masked))
                {
                    if (!resultado.Success)
                    {
                        MENSAGEM_AO_USUARIO.ERRO(erro);
                        controle.Focus();
                    }
                }
                return;
            }
            else resultado = reg.Match(controle.Text);
            if (!string.IsNullOrEmpty(controle.Text))
            {
                if (!resultado.Success)
                {
                    MENSAGEM_AO_USUARIO.ERRO(erro);
                    controle.Focus();
                }
            }
        }
    }
}
