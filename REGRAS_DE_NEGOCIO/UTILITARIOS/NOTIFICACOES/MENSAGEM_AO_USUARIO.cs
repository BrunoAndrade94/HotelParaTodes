using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace HotelParaTodes.NOTIFICACOES
{
    public static class MENSAGEM_AO_USUARIO
    {
        #region FRASES MAIS USADAS
        private static string MensagemAoUsuario = "Mensagem ao Usuário";
        #endregion

        #region QUESTOES
        public static DialogResult LIMPAR_A_TELA()
        {
            return MessageBox.Show("Deseja limpar a tela?", MensagemAoUsuario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult APAGAR_REGISTRO()
        {
            return MessageBox.Show("Deseja apagar registro?", MensagemAoUsuario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ALTERAR_REGISTRO()
        {
            return MessageBox.Show("Deseja alterar registro?", MensagemAoUsuario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion

        #region NOTIFICACOES
        public static DialogResult INCLUSAO_SUCESSO()
        {
            return MessageBox.Show("Aviso! Inclusão realizada com sucesso.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult AGUARDE()
        {
            return MessageBox.Show("Aviso! Aguarde.", MensagemAoUsuario);
        }
        public static DialogResult REMOVER_SUCESSO()
        {
            return MessageBox.Show("Aviso! Exclusão realizada com sucesso.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ATUALIZADO_SUCESSO()
        {
            return MessageBox.Show("Aviso! Atualização realizada com sucesso.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult REGISTRO_NAO_ENCONTRADO()
        {
            return MessageBox.Show("Aviso! Registro não encontrado.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult NO_ULTIMO_REGISTRO()
        {
            return MessageBox.Show("Aviso! Nós estamos no último registro.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult NO_PRIMEIRO_REGISTRO()
        {
            return MessageBox.Show("Aviso! Nós estamos no primeiro registro.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult OPERACACAO_CANCELADA_PELO_USUARIO()
        {
            return MessageBox.Show("Aviso! Operação cancelada pelo usuário.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult CEP_INVALIDO()
        {
            return MessageBox.Show("Aviso! Este CEP não é válido.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region NOTIFICACOES DE ACESSO SISTEMA
        public static DialogResult BOAS_VINDAS(string login)
        {
            return MessageBox.Show($"Boas Vindas {login}!", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult DESEJA_DESCONECTAR()
        {
            return MessageBox.Show("Deseja realmente se desconetar?", MensagemAoUsuario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult DESCONECTAR_OK()
        {
            return MessageBox.Show("Sucesso ao desconectar!", MensagemAoUsuario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult FALHA_LOGIN()
        {
            return MessageBox.Show("Atenção! Login ou Senha incorretos!", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region ERROS
        public static DialogResult ERRO(string ex)
        {
            return MessageBox.Show(ex, MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_AO_ATUALIZAR(string tabela)
        {
            return MessageBox.Show($"Atenção! A tabela precisa conter dados para ser atualizada.\nAdicione {tabela} na tabela antes de atualizar!", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_VINCULO_AO_ADICIONAR(string tabelaExcluida, string tabelaVinculada)
        {
            return MessageBox.Show($"Atenção! Você não pode adicionar {tabelaExcluida} sem antes incluir {tabelaVinculada} na tabela.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_AO_ADICIONAR(string tabela)
        {
            return MessageBox.Show($"Atenção! Você não pode adicionar {tabela} sem antes excluir os dados da tabela.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_AO_REMOVER(string tabela1, string tabela2)
        {
            return MessageBox.Show($"Atenção! Você não pode remover {tabela1} sem antes excluir os dados da tabela {tabela2}.", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_BANCO_VAZIO(string tabela)
        {
            return MessageBox.Show($"Atenção! A tabela precisa conter dados para ser excluida.\nAdicione {tabela} na tabela antes de excluir!", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_RELATORIO_NULL()
        {
            return MessageBox.Show("Atenção! O relatório retorno nenhum resultado!", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ERRO_EMAIL()
        {
            return MessageBox.Show("Atenção! Informe um email válido!", MensagemAoUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
