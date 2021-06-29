using HotelParaTodes;
using System.Linq;
using HPT_DLL.BancoDeDados;
using HPT_DLL.BancoDeDados.DAO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;

namespace HPT_DLL.Entidades.Pessoas
{
    sealed public class HOSPEDE : PESSOA
    {
        // tirar
        public QUARTO Quarto { get; set; }

        #region PROPRIEDADES
        public List<PAGAMENTO> FormaPagamento { get; set; }
        private static HOSPEDE_DAO hospede_dao = new HOSPEDE_DAO();
        #endregion

        #region CRUD
        public static void NOVO(HOSPEDE Hospede)
        {
            hospede_dao.Adicionar(Hospede);
            MENSAGEM_AO_USUARIO.INCLUSAO_SUCESSO();
        }
        public static void ATUALIZAR(HOSPEDE Hospede)
        {
            hospede_dao.Atualizar(Hospede);
            MENSAGEM_AO_USUARIO.ATUALIZADO_SUCESSO();
        }
        public static void REMOVER(HOSPEDE Hospede)
        {
            hospede_dao.Remover(Hospede);
            MENSAGEM_AO_USUARIO.REMOVER_SUCESSO();
        }
        #endregion
        #region CONSULTA
        public static void CONSULTAR(string nome, string sobrenome, string cpf)
        {
            using (var contexto = new CONTEXTO())
            {
                var CONSULTA = from _hospede in contexto.DB_HOSPEDES
                               join ende in contexto.DB_ENDERECOS on _hospede.Endereco.ID equals ende.ID
                               select new { h = _hospede, en = ende };

                if (!string.IsNullOrEmpty(nome))
                {
                    CONSULTA = CONSULTA.Where(h => h.h.Nome.Equals(nome));
                }
                if (!string.IsNullOrEmpty(sobrenome))
                {
                    CONSULTA = CONSULTA.Where(h => h.h.Sobrenome.Equals(sobrenome));
                }
                if (!string.IsNullOrEmpty(cpf))
                {
                    CONSULTA = CONSULTA.Where(h => h.h.CPF.Equals(cpf));
                }
                foreach (var item in CONSULTA)
                {
                    TELA_M_ENTIDADES.LISTA.Add(item.h);
                }
            }
        }
        #endregion

        #region VALIDAR CLASSE
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
        #endregion
    }
}
