using System;
using System.Windows.Forms;

namespace MVSOUL.TELAS.GENERICAS
{
    public partial class TELA_CALENDARIO : Form
    {
        public static DateTime DataSelecionada { get; set; }
        public static bool Voltou { get; set; }
        public static bool Flag { get; set; }

        public TELA_CALENDARIO()
        {
            InitializeComponent();
        }

        private void BTN_VOLTAR_Click(object sender, EventArgs e)
        {
            Voltou = true;
            Close();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            DataSelecionada = CALENDARIO.SelectionStart;
            Voltou = false;
            Close();
        }

        public void SelecionarData()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var Calendario = new TELA_CALENDARIO();
                Calendario.ShowDialog();
                if (Voltou)
                {
                    return;
                }
                DataSelecionada = CALENDARIO.SelectionStart;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
