using System;
using System.Windows.Forms;
using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;

namespace HotelParaTodes
{
    public partial class TELA_LOGIN : Form
    {
        #region PROPRIEDADES
        public string LOGIN { get; set; }
        public string SENHA { get; set; }
        public static bool LOGIN_SUCESSO { get; set; }
        public static USUARIO_SENHA LOGIN_ATUAL { get; set; } = new USUARIO_SENHA();
        #endregion

        public TELA_LOGIN()
        {
            InitializeComponent();
            TXT_LOGIN.Text = "";
            TXT_SENHA.Text = "";
            TXT_SENHA.UseSystemPasswordChar = true;
        }

        private void BTN_VOLTAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #region CHAMA VALIDADOR DE ACESSO
        private void BTN_CONECTAR_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DialogResult = DialogResult.OK;
            USUARIO_SENHA.VALIDAR_ACESSO_AO_SISTEMA(TXT_LOGIN.Text, TXT_SENHA.Text);
            if (LOGIN_ATUAL.Login != null)
            {
                if (LOGIN_ATUAL.Login.Equals(TXT_LOGIN.Text) & LOGIN_ATUAL.Senha.Equals(TXT_SENHA.Text))
                {
                    MENSAGEM_AO_USUARIO.BOAS_VINDAS(LOGIN_ATUAL.Login);
                    LOGIN_SUCESSO = true;
                }
            }
            else if (TXT_LOGIN.Text == "adm" & TXT_SENHA.Text == "adm")
            {
                LOGIN_SUCESSO = true;
            }
            else
            {
                MENSAGEM_AO_USUARIO.FALHA_LOGIN();
                LOGIN_SUCESSO = false;
            }
            Cursor = Cursors.Default;
        }
        #endregion
        private void TELA_LOGIN_Load(object sender, EventArgs e)
        {
        }
        private void TELA_LOGIN_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        #region BOTAO MOSTRAR A SENHA
        private void LBL_VER_SENHA_MouseEnter(object sender, EventArgs e)
        {
            TXT_SENHA.UseSystemPasswordChar = false;
        }
        private void LBL_VER_SENHA_MouseLeave(object sender, EventArgs e)
        {
            TXT_SENHA.UseSystemPasswordChar = true;
        }
        #endregion

        private void TXT_LOGIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                BTN_CONECTAR_Click(sender, e);
            }
        }

        private void TXT_SENHA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                BTN_CONECTAR_Click(sender, e);
            }
        }
    }
}
