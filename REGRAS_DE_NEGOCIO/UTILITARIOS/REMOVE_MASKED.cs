using System;
using System.Windows.Forms;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS
{
    public static class REMOVER_MASKED
    {
        public static string TEXTO_SEM_MASKED(this MaskedTextBox _mask)
        {
            _mask.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            String retString = _mask.Text;
            _mask.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            return retString;
        }
    }
}
