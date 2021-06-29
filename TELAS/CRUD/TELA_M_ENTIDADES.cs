using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS;
using HPT_DLL.Entidades;
using HPT_DLL.Entidades.Pessoas;
using HPT_DLL.Enumerados;
using Microsoft.EntityFrameworkCore;
using MVSOUL.TELAS.GENERICAS;
using MVSOUL.TELAS.TELA_CONSULTA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HotelParaTodes
{
    public partial class TELA_M_ENTIDADES : Form
    {
        #region PROPRIEDADES
        int i;
        private Type _tipo = null;
        public static ENDERECO Endereco { get; set; } = new ENDERECO();
        #region ENTIDADES
        public QUARTO Quarto { get; set; } = new QUARTO();
        public CARGO Cargo { get; set; } = new CARGO();
        public HOSPEDE Hospede { get; set; } = new HOSPEDE();
        public USUARIO_SENHA Login { get; set; } = new USUARIO_SENHA();
        public COLABORADOR Colaborador { get; set; } = new COLABORADOR();
        // teste
        public static List<dynamic> LISTA { get; set; } = new List<dynamic>();
        public static List<string> LISTA_STRING { get; set; } = new List<string>();
        public string SENHA_PADRAO { get; private set; } = "123";
        public static int ID_CARGO { get; private set; }
        public static int ID_PESSOA { get; private set; }
        public static int ID_ENDERECO { get; private set; }
        public static int ID_LOGIN { get; private set; }
        public static dynamic DATA_INCLUSAO { get; private set; }
        #endregion
        #endregion

        public TELA_M_ENTIDADES(Type tipo = null)
        {
            InitializeComponent();
            #region DEFINIR O TIPO DA ENTIDADE
            if (tipo != null)
            {
                _tipo = tipo;
                LBL_NOME_TELA.Text = _tipo.Name;
            }
            #endregion

            #region REMOVER TODAS TAB PAGES
            TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_DADOS_PESSOAIS);
            TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_ENDERECO);
            TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_PAGAMENTO);
            TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_INFORMACOES_QUARTO);
            TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_CARGOS);
            TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_DADOS_COLAB);
            #endregion
        }

        #region CRUD
        #region ATUALIZAR ENTIDADE
        private void BTN_ATUALIZAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (POSSO_ATUALIZAR_O_REGISTRO()) return;
                Cursor = Cursors.WaitCursor;
                LEITURA_DO_FORMULARIO();
                LISTA_STRING.Add(TXT_ID.Text);

                var itemSelecionado = Activator.CreateInstance(_tipo) as ICRUD;
                itemSelecionado.ATUALIZAR();


                if (POSSO_LIMPAR_OS_CONTROLES()) return;

                //if (!string.IsNullOrEmpty(TXT_NOME.Text))
                //if (!string.IsNullOrEmpty(TXT_NOME.Text) && string.IsNullOrEmpty(TXT_DESCRICAO_CARGO_COLAB.Text))
                //{
                //    Hospede.ID = LISTA[i].ID;
                //    Hospede.Alteracao = DateTime.Today.ToString();
                //    PREENCHER_NOVA_ENTIDADE();
                //    Hospede.Endereco.ID = LISTA[i].Endereco.ID;
                //    Hospede.VALIDAR_CLASSE();
                //    HOSPEDE.ATUALIZAR(Hospede);
                //}
                //else if (!string.IsNullOrEmpty(TXT_DESCRICAO_QUARTO.Text))
                //{
                //    Quarto.ID = LISTA[i].ID;
                //    Quarto.Alteracao = DateTime.Today.ToString();
                //    PREENCHER_NOVA_ENTIDADE();
                //    Quarto.VALIDAR_CLASSE();
                //    QUARTO.ATUALIZAR(Quarto);
                //}
                //else if (!string.IsNullOrEmpty(TXT_DESCRICAO_CARGO.Text))
                //{
                //    Cargo.ID = LISTA[i].ID;
                //    Cargo.Alteracao = DateTime.Today.ToString();
                //    PREENCHER_NOVA_ENTIDADE();
                //    Cargo.VALIDAR_CLASSE();
                //    CARGO.ATUALIZAR(Cargo);
                //}
            }
            #region Catchs
            catch (ValidationException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            catch (FormatException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            #endregion
        }

        private void LEITURA_DO_FORMULARIO()
        {
            LISTA_STRING.Clear();
            foreach (TabControl tabcontrol in Controls.OfType<TabControl>())
            {
                foreach (TabPage item in tabcontrol.Controls)
                {
                    foreach (var obj in item.Controls)
                    {
                        if (obj is TextBox)
                        {
                            if (!string.IsNullOrEmpty((obj as TextBox).Text))
                                LISTA_STRING.Add((obj as TextBox).Text);
                            else
                                throw new ArgumentNullException($"O campo {(obj as TextBox).AccessibleName} não pode ficar vazio.");
                        }
                        else if (obj is MaskedTextBox)
                        {
                            if ((obj as MaskedTextBox) == MSK_DATA_DEMISSAO)
                            {
                                if (!string.IsNullOrEmpty(REMOVER_MASKED.TEXTO_SEM_MASKED(obj as MaskedTextBox)))
                                    LISTA_STRING.Add((obj as MaskedTextBox).Text);
                                continue;
                            }
                            if (!string.IsNullOrEmpty(REMOVER_MASKED.TEXTO_SEM_MASKED(obj as MaskedTextBox)))
                                LISTA_STRING.Add((obj as MaskedTextBox).Text);
                            else
                                throw new ArgumentNullException($"O campo {(obj as MaskedTextBox).AccessibleName} não pode ficar vazio.");
                        }
                        else if (obj is ComboBox)
                        {
                            if (!string.IsNullOrEmpty((obj as ComboBox).Text))
                                LISTA_STRING.Add((obj as ComboBox).Text);
                            else
                                throw new ArgumentNullException($"O campo {(obj as ComboBox).AccessibleName} não pode ficar vazio.");
                        }
                    }
                }
            }
        }
        #endregion

        #region INCLUIR ENTIDADE
        private void BTN_INCLUIR_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                LEITURA_DO_FORMULARIO();

                if (i > 1)
                {
                    ID_PESSOA = LISTA[i].ID;
                    ID_ENDERECO = LISTA[i].Endereco.ID;
                    ID_LOGIN = LISTA[i].Login.ID;
                    ID_CARGO = LISTA[i].Cargo.ID;
                }

                //LISTA_STRING.Add(DateTime.Today.ToString("d", CultureInfo.InvariantCulture));

                var itemSelecionado = Activator.CreateInstance(_tipo) as ICRUD;
                itemSelecionado.INCLUIR();
                //#region NOVO HOSPEDE
                //if (!string.IsNullOrEmpty(TXT_NOME.Text) & _tipo.Equals(typeof(HOSPEDE)))
                //{
                //    Hospede.Inclusao = DateTime.Today.ToString();
                //    PREENCHER_NOVA_ENTIDADE();
                //    Hospede.VALIDAR_CLASSE();
                //    Endereco.VALIDAR_CLASSE();
                //    HOSPEDE.NOVO(Hospede);
                //    controle = true;
                //}
                //#endregion
                //#region NOVO QUARTO
                //else if (!string.IsNullOrEmpty(TXT_DESCRICAO_QUARTO.Text) & _tipo.Equals(typeof(QUARTO)))
                //{
                //    Quarto.Inclusao = DateTime.Today.ToString("d");
                //    PREENCHER_NOVA_ENTIDADE();
                //    Quarto.VALIDAR_CLASSE();
                //    QUARTO.NOVO(Quarto);
                //    controle = true;
                //}
                //#endregion
                //#region NOVO COLABORADOR
                //else if (!string.IsNullOrEmpty(TXT_DESCRICAO_CARGO_COLAB.Text) & _tipo.Equals(typeof(COLABORADOR)))
                //{
                //    Colaborador.Inclusao = DateTime.Today.ToString("d");
                //    PREENCHER_NOVA_ENTIDADE();
                //    Colaborador.VALIDAR_CLASSE();
                //    Endereco.VALIDAR_CLASSE();
                //    Cargo.VALIDAR_CLASSE();
                //    COLABORADOR.NOVO(Colaborador);
                //    controle = true;
                //}
                //#endregion
                //#region CARGO
                //else if (!string.IsNullOrEmpty(TXT_DESCRICAO_CARGO.Text) & _tipo.Equals(typeof(CARGO)))
                //{
                //    Cargo.Inclusao = DateTime.Today.ToString("d");
                //    PREENCHER_NOVA_ENTIDADE();
                //    Cargo.VALIDAR_CLASSE();
                //    CARGO.NOVO(Cargo);
                //    controle = true;
                //}
                //#endregion
                //if (!controle)
                //{
                //    MENSAGEM_AO_USUARIO.ERRO("Informe algum dado antes de incluir!");
                //    return;
                //}
                if (MENSAGEM_AO_USUARIO.LIMPAR_A_TELA() == DialogResult.Yes)
                {
                    LIMPAR_FORMULARIO.EXECUTAR(this);
                    DESAHABILITA_BOTAO_ANTERIOR_E_PROXIMO();
                    return;
                }
                BTN_INCLUIR.Enabled = false;
                BTN_CONSULTAR.Enabled = false;
                BTN_ATUALIZAR.Enabled = false;
            }
            #region Catchs
            catch (ValidationException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            catch (FormatException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            #endregion
        }
        #endregion

        #region EXCLUIR ENTIDADE
        private void BTN_EXCLUIR_Click(object sender, EventArgs e)
        {
            try
            {
                if (POSSO_APAGAR_O_REGISTRO()) return;
                Cursor = Cursors.WaitCursor;

                #region HOSPEDE
                if (_tipo.Equals(typeof(HOSPEDE)))
                {
                    HOSPEDE.REMOVER(LISTA[i]);
                }
                #endregion
                #region QUARTO
                else if (_tipo.Equals(typeof(QUARTO)))
                {
                    QUARTO.REMOVER(LISTA[i]);
                }
                #endregion
                #region CARGO
                //else if (CLICOU_EM_QUARTO())
                else if (_tipo.Equals(typeof(CARGO)))
                {
                    CARGO.REMOVER(LISTA[i]);
                }
                #endregion
                if (POSSO_LIMPAR_OS_CONTROLES()) return;
                OFF_UPDATE_DELETE_PREVIOUS_NEXT();
            }
            catch (Exception ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // vou tirar
        private void EXCLUIR_ENTIDADE(int metodo, int entidade)
        {
            try
            {
                if (POSSO_APAGAR_O_REGISTRO()) return;
                Cursor = Cursors.WaitCursor;
                //VAI_ALTERAR_QUEM(3, 1);
                MENSAGEM_AO_USUARIO.REMOVER_SUCESSO();

            }
            catch (Exception ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void OFF_UPDATE_DELETE_PREVIOUS_NEXT()
        {
            BTN_ATUALIZAR.Enabled = false;
            BTN_EXCLUIR.Enabled = false;
            BTN_ANTERIOR.Enabled = false;
            BTN_PROXIMO.Enabled = false;
        }
        #endregion

        #region CONSULTAR ENTIDADE
        private void BTN_CONSULTAR_Click(object sender, EventArgs e)
        {
            try
            {
                i = 0;
                LISTA.Clear();
                //if (TAB_INFORMACOES_GERAIS.TabPages.Contains(TAB_DADOS_PESSOAIS))
                if (_tipo.Equals(typeof(HOSPEDE)))
                {
                    HOSPEDE.CONSULTAR(TXT_NOME.Text, TXT_SOBRENOME.Text, REMOVER_MASKED.TEXTO_SEM_MASKED(MSK_CPF));
                    POPULAR_FORMULARIO();
                }
                //else if (TAB_INFORMACOES_GERAIS.TabPages.Contains(TAB_INFORMACOES_QUARTO))
                else if (_tipo.Equals(typeof(QUARTO)))
                {
                    QUARTO.CONSULTAR(TXT_DESCRICAO_QUARTO.Text, BOX_TIPO_QUARTO.Text, TXT_VALOR_POR_HORA.Text);
                    POPULAR_FORMULARIO();
                }
                //else if (TAB_INFORMACOES_GERAIS.TabPages.Contains(TAB_CARGOS))
                else if (_tipo.Equals(typeof(CARGO)))
                {
                    CARGO.CONSULTAR(TXT_DESCRICAO_CARGO.Text, TXT_SALARIO_CARGO.Text, TXT_CARGA_HORARIA_CARGO.Text);
                    POPULAR_FORMULARIO();
                }
                else if (_tipo.Equals(typeof(COLABORADOR)))
                {
                    COLABORADOR.CONSULTAR(TXT_NOME.Text, TXT_SOBRENOME.Text, REMOVER_MASKED.TEXTO_SEM_MASKED(MSK_CPF));
                    POPULAR_FORMULARIO();
                }
                if (LISTA.Count() == 0) MENSAGEM_AO_USUARIO.REGISTRO_NAO_ENCONTRADO();
                else BTN_EXCLUIR.Enabled = true;
            }
            #region Catchs
            catch (InvalidOperationException ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            catch (Exception ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            #endregion
        }
        #endregion
        #endregion

        #region PREENCHER NOVA ENTIDADE
        private void PREENCHER_NOVA_ENTIDADE()
        {
            if (_tipo.Equals(typeof(HOSPEDE)))
            {
                #region DADOS PESSOAIS
                Hospede.Nome = TXT_NOME.Text;
                Hospede.Sobrenome = TXT_SOBRENOME.Text;
                Hospede.Nascimento = DateTime.Parse(MSK_NASCIMENTO.Text);
                Hospede.EMail = TXT_EMAIL.Text;
                Hospede.Telefone = MSK_TELEFONE.Text;
                Hospede.RG = MSK_RG.Text;
                Hospede.CPF = MSK_CPF.Text;
                Hospede.Sexo = BOX_SEXO.SelectedItem.ToString();
                #endregion
                #region ENDERECO
                Endereco = ENDERECO.DESSERIALIZAR_JSON(BUSCAR_CEP.GERAR_JSON_CEP(MSK_CEP.Text));
                Endereco.Numero = TXT_NUMERO_ENDERECO.Text;
                Endereco.complemento = TXT_COMPLEMENTO.Text;
                Hospede.Endereco = Endereco;
                #endregion
            }
            #region COLABORADOR
            else if (_tipo.Equals(typeof(COLABORADOR)))
            {
                #region DADOS PESSOAIS
                Colaborador.Nome = TXT_NOME.Text;
                Colaborador.Sobrenome = TXT_SOBRENOME.Text;
                Colaborador.Nascimento = DateTime.Parse(MSK_NASCIMENTO.Text);
                Colaborador.EMail = TXT_EMAIL.Text;
                Colaborador.Telefone = MSK_TELEFONE.Text;
                Colaborador.RG = MSK_RG.Text;
                Colaborador.CPF = MSK_CPF.Text;
                Colaborador.Sexo = BOX_SEXO.SelectedItem.ToString();
                Colaborador.Admissao = DateTime.Today.Date;
                #endregion
                #region ENDERECO
                Endereco = ENDERECO.DESSERIALIZAR_JSON(BUSCAR_CEP.GERAR_JSON_CEP(MSK_CEP.Text));
                Endereco.Numero = TXT_NUMERO_ENDERECO.Text;
                Endereco.complemento = TXT_COMPLEMENTO.Text;
                Colaborador.Endereco = Endereco;
                #endregion
                #region CARGO
                Cargo.Nome = TXT_DESCRICAO_CARGO_COLAB.Text;
                Cargo.Salario = float.Parse(TXT_CARGO_SALARIO_COLAB.Text);
                Cargo.CargaHoraria = int.Parse(TXT_CARGO_HORARIA_COLAB.Text);
                //Colaborador.Admissao = MSK_DATA_ADMISSAO.Text;
                Colaborador.Cargo = Cargo;
                #endregion
                #region LOGIN
                Login.Login = TXT_LOGIN.Text;
                Login.Senha = SENHA_PADRAO;
                Colaborador.Login = Login;
                #endregion
            }
            #endregion
            else if (_tipo.Equals(typeof(QUARTO)))
            {
                #region QUARTO
                Quarto.Nome = TXT_DESCRICAO_QUARTO.Text;
                Quarto.Numero = int.Parse(TXT_NUMERO_QUARTO.Text);
                Quarto.Andar = int.Parse(TXT_ANDAR.Text);
                Quarto.ValorPorHora = float.Parse(TXT_VALOR_POR_HORA.Text);
                Quarto.Tipo = BOX_TIPO_QUARTO.SelectedItem.ToString();
                #endregion
            }
            else if (_tipo.Equals(typeof(CARGO)))
            {
                #region CARGO
                Cargo.Nome = TXT_DESCRICAO_CARGO.Text;
                Cargo.Salario = float.Parse(TXT_SALARIO_CARGO.Text);
                Cargo.CargaHoraria = int.Parse(TXT_CARGA_HORARIA_CARGO.Text);
                #endregion
            }
        }
        #endregion

        #region AGRUPAR TUDO AQUI QUE FOR DE HOSPEDE
        #region POPULAR BOX SEXO
        private void POPULAR_BOX_SEXO()
        {
            var enums = Enum.GetNames(typeof(ESEXO));
            for (int i = 0; i < enums.Length; i++)
            {
                BOX_SEXO.Items.Add(enums[i]).ToString();
            }
        }
        #endregion
        #endregion

        #region AGRUPAR TUDO AQUI QUE FOR DE QUARTO
        #region POPULAR BOX TIPO QUARTO
        private void POPULAR_BOX_TIPO_QUARTO()
        {
            var enums = Enum.GetNames(typeof(EQUARTO));
            for (int i = 0; i < enums.Length; i++)
            {
                BOX_TIPO_QUARTO.Items.Add(enums[i]).ToString();
            }
        }
        #endregion
        #endregion

        #region UTILITARIOS DA TELA
        #region VERIFICA TABELA ATIVA
        private bool CLICOU_EM_QUARTO()
        {
            return TAB_INFORMACOES_GERAIS.TabPages.Contains(TAB_INFORMACOES_QUARTO);
        }
        private bool CLICOU_EM_HOSPEDE()
        {
            return TAB_INFORMACOES_GERAIS.TabPages.Contains(TAB_DADOS_PESSOAIS);
        }
        private bool CLICOU_EM_CARGO()
        {
            return TAB_INFORMACOES_GERAIS.TabPages.Contains(TAB_CARGOS);
        }
        #endregion
        #region PROXIMO/ANTERIOR REGISTRO
        /// responsavel por avancar e recuar entre os registro do banco
        private void BTN_PROXIMO_Click(object sender, EventArgs e)
        {
            if (i == LISTA.Count() - 1)
            {
                MENSAGEM_AO_USUARIO.NO_ULTIMO_REGISTRO();
                return;
            }
            i++;
            POPULAR_FORMULARIO();
        }
        private void BTN_ANTERIOR_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MENSAGEM_AO_USUARIO.NO_PRIMEIRO_REGISTRO();
                return;
            }
            i--;
            POPULAR_FORMULARIO();
        }
        #endregion
        #region LIMPAR FORMULARIO
        private void BTN_LIMPAR_Click(object sender, EventArgs e)
        {
            LIMPAR_FORMULARIO.EXECUTAR(this);
            DESAHABILITA_BOTAO_ANTERIOR_E_PROXIMO();
        }
        #endregion
        #region POPULAR FORMULARIO
        private void POPULAR_FORMULARIO()
        {
            if (i < LISTA.Count())
            {
                LIMPAR_FORMULARIO.EXECUTAR(this);
                HABILITA_BOTAO_ANTERIOR_E_PROXIMO();

                LBL_REGISTRO.Text = $@"Registro {i + 1}/{LISTA.Count()}";

                PREENCHER_FORMULARIO();
            }
        }
        #endregion
        #region PREENCHER FORMULARIO ATUAL
        public void PREENCHER_FORMULARIO()
        {
            TXT_ID.Text = LISTA[i].ID.ToString();

            //ID_PESSOA = LISTA[i].ID;
            //ID_ENDERECO = LISTA[i].Endereco.ID;
            //ID_LOGIN = LISTA[i].Login.ID;
            //ID_CARGO = LISTA[i].Cargo.ID;

            MSK_INCLUSAO.Text = LISTA[i].Inclusao.ToString();
            #region HOSPEDE E COLABORADOR
            if (LISTA[i].Alteracao != null) MSK_ATUALIZADO.Text = LISTA[i].Alteracao.ToString();
            if (_tipo.Equals(typeof(HOSPEDE)) || _tipo.Equals(typeof(COLABORADOR)))
            {
                #region DADOS PESSOAIS
                TXT_ID.Text = LISTA[i].ID.ToString();
                TXT_NOME.Text = LISTA[i].Nome;
                TXT_SOBRENOME.Text = LISTA[i].Sobrenome;
                TXT_EMAIL.Text = LISTA[i].EMail;
                MSK_CPF.Text = LISTA[i].CPF.ToString();
                MSK_RG.Text = LISTA[i].RG.ToString();
                MSK_TELEFONE.Text = LISTA[i].Telefone;
                MSK_NASCIMENTO.Text = LISTA[i].Nascimento.ToString();
                BOX_SEXO.Text = LISTA[i].Sexo.ToString();
                #endregion
                #region ENDERECO
                TXT_LOGRADOURO.Text = LISTA[i].Endereco.logradouro;
                TXT_NUMERO_ENDERECO.Text = LISTA[i].Endereco.Numero;
                MSK_CEP.Text = LISTA[i].Endereco.cep;
                TXT_BAIRRO.Text = LISTA[i].Endereco.bairro;
                TXT_LOCALIDADE.Text = LISTA[i].Endereco.localidade;
                TXT_UF.Text = LISTA[i].Endereco.uf;
                TXT_COMPLEMENTO.Text = LISTA[i].Endereco.complemento;
                #endregion
                #region COLABORADOR
                if (_tipo.Equals(typeof(COLABORADOR)))
                {
                    TXT_DESCRICAO_CARGO_COLAB.Text = LISTA[i].Cargo.Nome;
                    TXT_CARGO_SALARIO_COLAB.Text = LISTA[i].Cargo.Salario.ToString();
                    TXT_CARGO_HORARIA_COLAB.Text = LISTA[i].Cargo.CargaHoraria.ToString();
                    MSK_DATA_ADMISSAO.Text = LISTA[i].Admissao;
                    TXT_LOGIN.Text = LISTA[i].Login.Login;
                }
                #endregion
            }
            #endregion
            #region QUARTO
            else if (_tipo.Equals(typeof(QUARTO)))
            {
                #region QUARTO
                TXT_ID.Text = LISTA[i].ID.ToString();
                TXT_DESCRICAO_QUARTO.Text = LISTA[i].Nome;
                BOX_TIPO_QUARTO.Text = LISTA[i].Tipo.ToString();
                TXT_ANDAR.Text = LISTA[i].Andar.ToString();
                TXT_NUMERO_QUARTO.Text = LISTA[i].Numero.ToString();
                TXT_VALOR_POR_HORA.Text = LISTA[i].ValorPorHora.ToString();
                #endregion
            }
            #endregion
            #region CARGO
            else if (_tipo.Equals(typeof(CARGO)))
            {
                #region CARGO
                TXT_DESCRICAO_CARGO.Text = LISTA[i].Nome;
                TXT_SALARIO_CARGO.Text = LISTA[i].Salario.ToString();
                TXT_CARGA_HORARIA_CARGO.Text = LISTA[i].CargaHoraria.ToString();
                #endregion
            }
            #endregion
        }
        #endregion
        #region AO CARREGAR O FORMULARIO
        private void TELA_M_ENTIDADES_Load(object sender, EventArgs e)
        {
            POPULAR_BOX_SEXO();
            POPULAR_BOX_TIPO_QUARTO();
            DESAHABILITA_BOTAO_ANTERIOR_E_PROXIMO();
            //MSK_INCLUSAO.Text = DateTime.Today.ToString("d");
        }
        #endregion
        #region PARA SELECIONAR DATAS - CHAMA CALENDARIO
        private void MSK_NASCIMENTO_Click(object sender, EventArgs e)
        {
            var Calendario = new TELA_CALENDARIO();
            Calendario.ShowDialog();
            if (TELA_CALENDARIO.Voltou) return;
            MSK_NASCIMENTO.Text = TELA_CALENDARIO.DataSelecionada.ToString("d");
        }
        private void MSK_DATA_ADMISSAO_Click(object sender, EventArgs e)
        {
            var Calendario = new TELA_CALENDARIO();
            Calendario.ShowDialog();
            if (TELA_CALENDARIO.Voltou) return;
            MSK_DATA_ADMISSAO.Text = TELA_CALENDARIO.DataSelecionada.ToString("d");
        }
        private void MSK_DATA_DEMISSAO_Click(object sender, EventArgs e)
        {
            var Calendario = new TELA_CALENDARIO();
            Calendario.ShowDialog();
            if (TELA_CALENDARIO.Voltou) return;
            MSK_DATA_DEMISSAO.Text = TELA_CALENDARIO.DataSelecionada.ToString("d");
        }
        #endregion
        #region INSTANCIAR ENTIDADES APÓS USO
        private void INSTANCIAR_ENTIDADES()
        {
            Cargo = new CARGO();
            Quarto = new QUARTO();
            Hospede = new HOSPEDE();
            Endereco = new ENDERECO();
            Colaborador = new COLABORADOR();
        }
        #endregion
        #region TORNA VISIVEL O BOTAO DE NAVEGACAO ENTRE REGISTROS
        private void HABILITA_BOTAO_ANTERIOR_E_PROXIMO()
        {
            BTN_ATUALIZAR.Enabled = true;
            BTN_INCLUIR.Enabled = false;
            BTN_CONSULTAR.Enabled = false;

            if (LISTA.Count() > 1)
            {
                BTN_PROXIMO.Visible = true;
                BTN_ANTERIOR.Visible = true;
                //BTN_PROXIMO.Enabled = true;
                //BTN_ANTERIOR.Enabled = true;
            }
        }
        private void DESAHABILITA_BOTAO_ANTERIOR_E_PROXIMO()
        {
            i = 0;
            INSTANCIAR_ENTIDADES();
            LBL_REGISTRO.Text = $@"Registro 0/0";
            BTN_EXCLUIR.Enabled = false;
            BTN_ATUALIZAR.Enabled = false;
            BTN_CONSULTAR.Enabled = true;
            BTN_INCLUIR.Enabled = true;
            BTN_ATUALIZAR.Enabled = false;
            BTN_PROXIMO.Visible = false;
            BTN_ANTERIOR.Visible = false;
            MSK_INCLUSAO.Text = DateTime.Today.ToString().ToString();
        }
        #endregion
        #region RETONAR UM JSON COM DADOS DO CEP
        private void MSK_CEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                VERIFICA_CEP(MSK_CEP.Text);
            }
        }
        #region ENDERECO - USADO POR MSK_CEP_KeyPress
        private void PREENCHE_ENDERECO()
        {
            TXT_LOGRADOURO.Text = Endereco.logradouro;
            TXT_BAIRRO.Text = Endereco.bairro;
            MSK_CEP.Text = Endereco.cep;
            TXT_LOCALIDADE.Text = Endereco.localidade;
            TXT_UF.Text = Endereco.uf;
        }
        private void LIMPA_ENDERECO()
        {
            TXT_LOGRADOURO.Text = "";
            TXT_BAIRRO.Text = "";
            MSK_CEP.Text = "";
            TXT_LOCALIDADE.Text = "";
            TXT_UF.Text = "";
        }
        #endregion
        #endregion
        #region AO FECHAR O FOMULARIO
        private void TELA_M_ENTIDADES_FormClosing(object sender, FormClosingEventArgs e)
        {
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_DADOS_PESSOAIS);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_ENDERECO);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_PAGAMENTO);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_INFORMACOES_QUARTO);
        }
        #endregion
        #region OCULTAR TAB PAGES
        public void M_QUARTO()
        {
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_INFORMACOES_QUARTO);

            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_DADOS_PESSOAIS);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_ENDERECO);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_PAGAMENTO);
        }
        public void M_COLABORADOR()
        {
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_DADOS_PESSOAIS);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_ENDERECO);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_DADOS_COLAB);

            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_PAGAMENTO);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_INFORMACOES_QUARTO);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_CARGOS);
        }
        public void M_CARGO()
        {
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_CARGOS);

            //M_QUARTO();
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_PAGAMENTO);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_DADOS_COLAB);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_INFORMACOES_QUARTO);
        }
        public void M_HOSPEDE()
        {
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_DADOS_PESSOAIS);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_ENDERECO);
            TAB_INFORMACOES_GERAIS.TabPages.Add(TAB_PAGAMENTO);

            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_INFORMACOES_QUARTO);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_CARGOS);
            //TAB_INFORMACOES_GERAIS.TabPages.Remove(TAB_DADOS_COLAB);
        }
        #endregion
        #endregion

        #region VERIFICACAO DE VALIDACAO USUARIO
        private bool POSSO_LIMPAR_OS_CONTROLES()
        {
            if (MENSAGEM_AO_USUARIO.LIMPAR_A_TELA() == DialogResult.Yes)
            {
                LIMPAR_FORMULARIO.EXECUTAR(this);
                DESAHABILITA_BOTAO_ANTERIOR_E_PROXIMO();
                return true;
            }
            return false;
        }
        private bool POSSO_ATUALIZAR_O_REGISTRO()
        {
            if (MENSAGEM_AO_USUARIO.ALTERAR_REGISTRO() == DialogResult.No)
            {
                MENSAGEM_AO_USUARIO.OPERACACAO_CANCELADA_PELO_USUARIO();
                return true;
            }
            return false;
        }
        private bool POSSO_APAGAR_O_REGISTRO()
        {
            if (MENSAGEM_AO_USUARIO.APAGAR_REGISTRO() == DialogResult.No)
            {
                MENSAGEM_AO_USUARIO.OPERACACAO_CANCELADA_PELO_USUARIO();
                return true;
            }
            return false;
        }
        #endregion

        #region OUTROS
        private void BTN_VOLTAR_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void BOX_SEXO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void TAB_DADOS_PESSOAIS_MouseEnter(object sender, EventArgs e)
        {
            //Cursor = Cursors.Hand;
        }
        private void TAB_PAGAMENTO_MouseEnter(object sender, EventArgs e)
        {
            //Cursor = Cursors.Hand;
        }
        private void TAB_INFORMACOES_GERAIS_MouseEnter(object sender, EventArgs e)
        {
            //Cursor = Cursors.Hand;
        }
        private void BOX_SEXO_MouseEnter(object sender, EventArgs e)
        {

        }
        private void TAB_ENDERECO_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region CONTROLES LEAVE
        private void MSK_CEP_Leave(object sender, EventArgs e)
        {
            VERIFICA_CEP(MSK_CEP.Text);
        }

        private void VERIFICA_CEP(string cep)
        {
            if (!string.IsNullOrEmpty(REMOVER_MASKED.TEXTO_SEM_MASKED(MSK_CEP)))
            {
                Endereco = ENDERECO.DESSERIALIZAR_JSON(BUSCAR_CEP.GERAR_JSON_CEP(cep));
                if (!string.IsNullOrEmpty(Endereco.cep))
                {
                    PREENCHE_ENDERECO();
                    return;
                }
                MENSAGEM_AO_USUARIO.CEP_INVALIDO();
                LIMPA_ENDERECO();
            }
        }
        #endregion

        #region VERIFICACOES FEITAS COM REGEX
        private void TXT_EMAIL_Leave(object sender, EventArgs e)
        {
            MINHAS_REGEX.VALIDAR_REGEX(TXT_EMAIL, MINHAS_REGEX.EMAIL, "Email inválido!");
        }
        private void MSK_RG_Leave(object sender, EventArgs e)
        {
            MINHAS_REGEX.VALIDAR_REGEX(MSK_RG, MINHAS_REGEX.RG, "RG inválido!");
        }
        private void MSK_CPF_Leave(object sender, EventArgs e)
        {
            MINHAS_REGEX.VALIDAR_REGEX(MSK_CPF, MINHAS_REGEX.CPF, "CPF inválido!");
        }
        private void MSK_TELEFONE_Leave(object sender, EventArgs e)
        {
            MINHAS_REGEX.VALIDAR_REGEX(MSK_TELEFONE, MINHAS_REGEX.TELEFONE, "Telefone inválido!");
        }
        #endregion

        private void BTN_TABELA_LISTA_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                using (var contexto = new CARGO_DAO())
                {
                    var tabela = contexto.Trazer();

                    var novaTela = new TELA_DE_CONSULTA("Cargo", tabela);
                    novaTela.ShowDialog();

                    var query = from pd in tabela
                                where pd.Nome.Equals(TELA_DE_CONSULTA.OpcaoSelecionada)
                                select pd;

                    foreach (var curso in query)
                    {
                        ID_CARGO = curso.ID;
                        TXT_DESCRICAO_CARGO_COLAB.Text = curso.Nome;
                        TXT_CARGO_SALARIO_COLAB.Text = curso.Salario.ToString();
                        TXT_CARGO_HORARIA_COLAB.Text = curso.CargaHoraria.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MENSAGEM_AO_USUARIO.ERRO(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
