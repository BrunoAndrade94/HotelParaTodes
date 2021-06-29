using HotelParaTodes;
using HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HPT_DLL.BancoDeDados;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using System;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS;
using HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS;
using System.Globalization;

namespace HPT_DLL.Entidades.Pessoas
{
    sealed public class COLABORADOR : PESSOA, ICRUD
    {
        private static COLABORADOR_DAO colaborador_dao = new COLABORADOR_DAO();
        private static COLABORADOR Colaborador = new COLABORADOR();

        [Required(ErrorMessage = "Cargo é obrigatório!")]
        public CARGO Cargo { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório!")]
        public USUARIO_SENHA Login { get; set; } = new USUARIO_SENHA();

        [Required(ErrorMessage = "Admissão é obrigatório!")]
        public DateTime Admissao { get; set; }
        public DateTime Demissao { get; set; }

        public void INCLUIR()
        {
            #region Colaborador
            Colaborador.Nome = TELA_M_ENTIDADES.LISTA_STRING[0];
            Colaborador.Sobrenome = TELA_M_ENTIDADES.LISTA_STRING[1];
            Colaborador.EMail = TELA_M_ENTIDADES.LISTA_STRING[2];
            Colaborador.Sexo = TELA_M_ENTIDADES.LISTA_STRING[3];
            Colaborador.CPF = TELA_M_ENTIDADES.LISTA_STRING[4];
            Colaborador.Nascimento = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[5]);
            Colaborador.Telefone = TELA_M_ENTIDADES.LISTA_STRING[6];
            Colaborador.RG = TELA_M_ENTIDADES.LISTA_STRING[7];
            #endregion

            #region Endereço
            Endereco = ENDERECO.DESSERIALIZAR_JSON(BUSCAR_CEP.GERAR_JSON_CEP(TELA_M_ENTIDADES.LISTA_STRING[14]));
            Endereco.Numero = TELA_M_ENTIDADES.LISTA_STRING[11];
            Endereco.complemento = TELA_M_ENTIDADES.LISTA_STRING[8];
            Colaborador.Endereco = Endereco;
            #endregion

            #region Cargo
            //Cargo.ID = TELA_M_ENTIDADES.ID_CARGO;
            //Cargo.Nome = TELA_M_ENTIDADES.LISTA_STRING[18];
            // tirar entidade cargo deixar apensar CARGOID
            Colaborador.Cargo.ID = TELA_M_ENTIDADES.ID_CARGO;
            #endregion

            #region Login
            Colaborador.Login = new USUARIO_SENHA(TELA_M_ENTIDADES.LISTA_STRING[19]);
            #endregion

            #region Data Inclusão
            Colaborador.Inclusao = DateTime.Now; // converter para datetime
            Colaborador.Admissao = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[15]); // converter para datetime
            #endregion

            colaborador_dao.Adicionar(Colaborador);
            MENSAGEM_AO_USUARIO.INCLUSAO_SUCESSO();
        }
        public void EXCLUIR()
        {

        }
        public void ATUALIZAR()
        {
            #region Colaborador
            Colaborador.ID = TELA_M_ENTIDADES.ID_PESSOA;
            Colaborador.Nome = TELA_M_ENTIDADES.LISTA_STRING[0];
            Colaborador.Sobrenome = TELA_M_ENTIDADES.LISTA_STRING[1];
            Colaborador.EMail = TELA_M_ENTIDADES.LISTA_STRING[2];
            Colaborador.Sexo = TELA_M_ENTIDADES.LISTA_STRING[3];
            Colaborador.CPF = TELA_M_ENTIDADES.LISTA_STRING[4];
            Colaborador.Nascimento = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[5]);
            Colaborador.Telefone = TELA_M_ENTIDADES.LISTA_STRING[6];
            Colaborador.RG = TELA_M_ENTIDADES.LISTA_STRING[7];
            #endregion

            #region Endereço
            Endereco = ENDERECO.DESSERIALIZAR_JSON(BUSCAR_CEP.GERAR_JSON_CEP(TELA_M_ENTIDADES.LISTA_STRING[14]));
            Endereco.ID = TELA_M_ENTIDADES.ID_ENDERECO;
            Endereco.Numero = TELA_M_ENTIDADES.LISTA_STRING[11];
            Endereco.complemento = TELA_M_ENTIDADES.LISTA_STRING[8];
            Colaborador.Endereco = Endereco;
            #endregion

            #region Cargo
            Cargo.ID = TELA_M_ENTIDADES.ID_CARGO;
            Cargo.Nome = TELA_M_ENTIDADES.LISTA_STRING[17];
            Colaborador.Cargo = Cargo;
            #endregion

            #region Login
            Login.ID = TELA_M_ENTIDADES.ID_LOGIN;
            Login.Login = TELA_M_ENTIDADES.LISTA_STRING[18];
            Colaborador.Login = Login;
            #endregion

            #region Data Alteração
            Colaborador.Inclusao = TELA_M_ENTIDADES.DATA_INCLUSAO;
            Colaborador.Alteracao = DateTime.Now.Date;
            #endregion

            colaborador_dao.Atualizar(Colaborador);
            MENSAGEM_AO_USUARIO.ATUALIZADO_SUCESSO();
        }

        //  SEM USO ********************************
        public void EXECUTAR(int operacao)
        {
            // teste - 
            if (operacao == 0)
            {
                #region DADOS PESSOAIS
                Colaborador.Nome = TELA_M_ENTIDADES.LISTA_STRING[1];
                Colaborador.Sobrenome = TELA_M_ENTIDADES.LISTA_STRING[2];
                Colaborador.EMail = TELA_M_ENTIDADES.LISTA_STRING[3];
                Colaborador.Sexo = TELA_M_ENTIDADES.LISTA_STRING[4];
                Colaborador.CPF = TELA_M_ENTIDADES.LISTA_STRING[5];
                Colaborador.Nascimento = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[6]);
                Colaborador.Telefone = TELA_M_ENTIDADES.LISTA_STRING[7];
                Colaborador.RG = TELA_M_ENTIDADES.LISTA_STRING[8];

                var f = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[3]);
                //Colaborador.Admissao = DateTime.Today.ToString("d");

                Colaborador.Cargo.Nome = TELA_M_ENTIDADES.LISTA_STRING[17];
                Colaborador.Login.Login = TELA_M_ENTIDADES.LISTA_STRING[18];
                #endregion
            }
            // excluir
            if (operacao == 1)
            {
                Colaborador.Nome = TELA_M_ENTIDADES.LISTA_STRING[1];
                Colaborador.Sobrenome = TELA_M_ENTIDADES.LISTA_STRING[2];
                Colaborador.EMail = TELA_M_ENTIDADES.LISTA_STRING[3];
                Colaborador.Sexo = TELA_M_ENTIDADES.LISTA_STRING[4];
                Colaborador.CPF = TELA_M_ENTIDADES.LISTA_STRING[5];
                Colaborador.Nascimento = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[6]);
                Colaborador.Telefone = TELA_M_ENTIDADES.LISTA_STRING[7];
                Colaborador.RG = TELA_M_ENTIDADES.LISTA_STRING[8];

                var f = DateTime.Parse(TELA_M_ENTIDADES.LISTA_STRING[3]);
                //Colaborador.Admissao = DateTime.Today.ToString("d");



                Colaborador.Cargo.Nome = TELA_M_ENTIDADES.LISTA_STRING[17];
                Colaborador.Login.Login = TELA_M_ENTIDADES.LISTA_STRING[18];
            }
            MENSAGEM_AO_USUARIO.INCLUSAO_SUCESSO();
        }

        #region CRUD
        // retirar
        private static void NOVO(COLABORADOR Colaborador)
        {
            colaborador_dao.Adicionar(Colaborador);
            MENSAGEM_AO_USUARIO.INCLUSAO_SUCESSO();
        }
        private static void ATUALIZAR(COLABORADOR Colaborador)
        {
            colaborador_dao.Atualizar(Colaborador);
            MENSAGEM_AO_USUARIO.ATUALIZADO_SUCESSO();
        }
        private static void REMOVER(COLABORADOR Colaborador)
        {
            colaborador_dao.Remover(Colaborador);
            MENSAGEM_AO_USUARIO.REMOVER_SUCESSO();
        }
        #endregion

        #region CONSULTA
        public static void CONSULTAR(string nome, string sobrenome, string cpf)
        {
            using (var contexto = new CONTEXTO())
            {
                var CONSULTA = from _colaborador in contexto.DB_COLABORADORES
                               join _endereco in contexto.DB_ENDERECOS on _colaborador.Endereco.ID equals _endereco.ID
                               join _cargo in contexto.DB_CARGOS on _colaborador.Cargo.ID equals _cargo.ID
                               join _login in contexto.DB_LOGINS on _colaborador.Login.ID equals _login.ID
                               select new { colaborador = _colaborador, endereco = _endereco, cargo = _cargo, login = _login };

                if (!string.IsNullOrEmpty(nome))
                {
                    CONSULTA = CONSULTA.Where(h => h.colaborador.Nome.Equals(nome));
                }
                if (!string.IsNullOrEmpty(sobrenome))
                {
                    CONSULTA = CONSULTA.Where(h => h.colaborador.Sobrenome.Equals(sobrenome));
                }
                if (!string.IsNullOrEmpty(cpf))
                {
                    CONSULTA = CONSULTA.Where(h => h.colaborador.CPF.Equals(cpf));
                }
                foreach (var item in CONSULTA)
                {
                    TELA_M_ENTIDADES.LISTA.Add(item.colaborador);
                }
            }
        }
        #endregion

        public void VALIDAR_CLASSE()
        {
            var contextos = new ValidationContext(this, serviceProvider: null, items: null);
            var resultados = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(this, contextos, resultados, true);

            if (valido == false)
            {
                var sbErros = new StringBuilder();
                foreach (var validarResultado in resultados)
                {
                    sbErros.AppendLine(validarResultado.ErrorMessage);
                }
                throw new ValidationException(sbErros.ToString());
            }
        }
    }
}
