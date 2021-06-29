using System;
using System.Windows.Forms;

namespace HotelParaTodes
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TELA_M_ENTIDADES());
            Application.Run(new TELA_INICIAL());
        }
    }
}
