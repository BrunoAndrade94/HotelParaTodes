using HotelParaTodes.NOTIFICACOES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MVSOUL.TELAS.TELA_CONSULTA
{
    public partial class TELA_DE_CONSULTA : Form
    {
        #region PROPRIEDADES
        static public dynamic OpcaoSelecionada { get; set; }
        public static int ItensPorPagina { get; set; } = 10;
        public static int NumeroDaPagina { get; set; } = 1;
        public decimal TotalDePaginas { get; private set; }
        public List<dynamic> A_LISTA { get; set; } = new List<dynamic>();
        #endregion

        public TELA_DE_CONSULTA(string NOME_TELA, dynamic TABELA_DO_BANCO = null)
        {
            InitializeComponent();

            this.Text = NOME_TELA;
            A_LISTA.AddRange(TABELA_DO_BANCO);
        }

        private void LST_ITENS_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpcaoSelecionada = LST_ITENS.SelectedItem;
            Close();
        }

        private void TELA_DE_CONSULTA_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            TXT_N_PAG.Text = (TotalDePaginas += Math.Ceiling((decimal)A_LISTA.Count() / ItensPorPagina)).ToString();
            LISTAR_OS_ITENS();
            Cursor = Cursors.Default;
        }

        private void LISTAR_OS_ITENS()
        {
            try
            {
                var numeroPulos = (NumeroDaPagina - 1) * ItensPorPagina;
                var NOVA_LISTA = A_LISTA.Skip(numeroPulos);
                NOVA_LISTA = NOVA_LISTA.Take(ItensPorPagina);
                
                LST_ITENS.Items.Clear();

                var query = from item in NOVA_LISTA
                            orderby item.Nome
                            select item.Nome;

                foreach (object obj in query)
                    LST_ITENS.Items.Add(obj);
            }
            catch (SqlException e) { MENSAGEM_AO_USUARIO.ERRO(e.Message); }
            catch (Exception e) { MENSAGEM_AO_USUARIO.ERRO(e.Message); }
        }

        private void BTN_FILTRAR_Click(object sender, EventArgs e)
        {
            if(TXT_CRITERIO.Text == "")
            {
                MENSAGEM_AO_USUARIO.ERRO("É necessário informar um critério!");
                return;
            }                   
            var criterio = TXT_CRITERIO.Text.ToLower();

            var consulta = from item in A_LISTA
                           where item.Nome.ToLower().Contains(criterio)
                           orderby item.Nome
                           select item.Nome;

            LST_ITENS.Items.Clear();
            foreach (var item in consulta)
            {
                LST_ITENS.Items.Add(item);
            }
        }

        private void TXT_CRITERIO_TextChanged(object sender, EventArgs e)
        {

        }

        #region AVANÇA E RECUA PÁGINA
        private void BTN_AVANCAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumeroDaPagina == int.Parse(TXT_N_PAG.Text))
                {
                    MessageBox.Show("Na última página!");
                    return;
                }
                NumeroDaPagina++;
                TXT_PAG_ATUAL.Text = NumeroDaPagina.ToString();
            }
            finally
            {
                LISTAR_OS_ITENS();
            }
        }

        private void BTN_RECUAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumeroDaPagina == 1)
                {
                    MessageBox.Show("Na primeira página!");
                    return;
                }
                NumeroDaPagina--;
                TXT_PAG_ATUAL.Text = NumeroDaPagina.ToString();
            }
            finally
            {
                LISTAR_OS_ITENS();
            }
        }
        #endregion

        private void TXT_N_PAG_Click(object sender, EventArgs e)
        {

        }

        private void TXT_CRITERIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                BTN_FILTRAR_Click(sender, e);
            }                   
        }
    }
}
