using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO;
using HPT_DLL.BancoDeDados;
using System.Linq;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES
{
    public class USUARIO_SENHA
    {
        #region PROPRIEDADES
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }        

        private static USUARIO_SENHA_DAO hospede_dao = new USUARIO_SENHA_DAO();
        #endregion

        public USUARIO_SENHA() { }

        public USUARIO_SENHA(string login)
        {
            Login = login;
        }


        #region CRUD
        public static void ATUALIZAR(USUARIO_SENHA Login)
        {
            hospede_dao.Atualizar(Login);
            MENSAGEM_AO_USUARIO.ATUALIZADO_SUCESSO();
        }
        public static void REMOVER(USUARIO_SENHA Login)
        {
            hospede_dao.Remover(Login);
            MENSAGEM_AO_USUARIO.REMOVER_SUCESSO();
        }
        #endregion
        #region CONSULTAS
        public static void VALIDAR_ACESSO_AO_SISTEMA(string nome, string senha)
        {
            using (var contexto = new CONTEXTO())
            {
                var CONSULTA = from _login in contexto.DB_LOGINS
                               join _colab in contexto.DB_COLABORADORES on _login.ID equals _colab.Login.ID
                               select new { l = _login, en = _colab };

                if (!string.IsNullOrEmpty(nome))
                {
                    CONSULTA = CONSULTA.Where(l => l.l.Login.Equals(nome));
                    if (!string.IsNullOrEmpty(senha))
                    {
                        CONSULTA = CONSULTA.Where(l => l.l.Senha.Equals(senha));
                    }
                }
                foreach (var item in CONSULTA)
                {
                    TELA_LOGIN.LOGIN_ATUAL.Login = item.l.Login;
                    TELA_LOGIN.LOGIN_ATUAL.Senha = item.l.Senha;
                }                 
            }
        }
        #endregion
        public override string ToString()
        {
            return $"{Login} {Senha}";
        }
    }
}
