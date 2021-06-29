using System.Windows.Forms;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS
{
    static public class LIMPAR_FORMULARIO
    {
        public static void EXECUTAR(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox)
                {
                    (cont as TextBox).Text = "";
                }
                if (cont is ComboBox)
                {
                    (cont as ComboBox).Text = "";
                }
                if (cont is MaskedTextBox)
                {
                    (cont as MaskedTextBox).Text = "";
                }
                if (cont is CheckBox)
                {
                    (cont as CheckBox).Checked = false;
                }
                if (cont is CheckedListBox)
                {
                    foreach (ListControl item in (cont as CheckedListBox).Items)
                    {
                        item.SelectedIndex = -1;
                    }
                }
                if (cont is ListView)
                {
                    (cont as ListView).Items.Clear();
                }
                EXECUTAR(cont);
            }
        }
    }
}
