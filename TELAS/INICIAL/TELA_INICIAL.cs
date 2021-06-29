using System;
using System.Windows.Forms;
using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HPT_DLL.Entidades;
using HPT_DLL.Entidades.Pessoas;

namespace HotelParaTodes
{
    public partial class TELA_INICIAL : Form
    {
        public TELA_INICIAL()
        {
            InitializeComponent();
            DESABILITAR_TOOL_STRIP();
        }

        #region HABILITAR /  DESABILITAR TOOL STRIP
        private void HABILITAR_TOOL_STRIP()
        {
            gerenciarToolStripMenuItem.Enabled = true;
            reservaToolStripMenuItem.Enabled = true;
            editarToolStripMenuItem.Enabled = true;
            ajudaToolStripMenuItem.Enabled = true;
            conectarToolStripMenuItem.Text = "Desconectar";
        }
        private void DESABILITAR_TOOL_STRIP()
        {
            gerenciarToolStripMenuItem.Enabled = false;
            reservaToolStripMenuItem.Enabled = false;
            editarToolStripMenuItem.Enabled = false;
            ajudaToolStripMenuItem.Enabled = false;
            conectarToolStripMenuItem.Text = "Conectar";
        }
        #endregion
        private void TELA_INICIAL_Load(object sender, EventArgs e)
        {
        }

        #region QUANDO CLICAR PARA SE CONECTAR
        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conectarToolStripMenuItem.Text == "Conectar")
            {
                var login = new TELA_LOGIN();
                do
                {
                    login.ShowDialog();
                    if (login.DialogResult == DialogResult.Cancel) break;
                    if (!TELA_LOGIN.LOGIN_SUCESSO) continue;
                    else
                    {
                        HABILITAR_TOOL_STRIP();
                        break;
                    }
                }
                while (login.DialogResult == DialogResult.OK);
            }
            else if (conectarToolStripMenuItem.Text == "Desconectar")
            {
                if (MessageBox.Show("Deseja realmente se desconetar?", "Mensagem ao Conectante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                MessageBox.Show("Login desconectado com sucesso!");
                DESABILITAR_TOOL_STRIP();
            }
        }
        #endregion

        private void hospedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #region ACESSO A TABELA DA ENTIDADE
        private void hospedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var hospede = new TELA_M_ENTIDADES(typeof(HOSPEDE));
            hospede.M_HOSPEDE();
            hospede.ShowDialog();
        }
        private void quartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var quarto = new TELA_M_ENTIDADES(typeof(QUARTO));
            quarto.M_QUARTO();
            quarto.ShowDialog();
        }
        private void colaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colaborador = new TELA_M_ENTIDADES(typeof(COLABORADOR));
            colaborador.M_COLABORADOR();
            colaborador.ShowDialog();
        }
        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cargo = new TELA_M_ENTIDADES(typeof(CARGO));
            cargo.M_CARGO();
            cargo.ShowDialog();
        }
        #endregion

        #region PARA ALTERAR SENHA
        private void alterarSenhaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // fazer tela para alterar senha, pode ser a mesma do acesso, apenas mudando um pouco o layout
        }
        #endregion

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // criar uma tela de reserva
        }
    }
}
