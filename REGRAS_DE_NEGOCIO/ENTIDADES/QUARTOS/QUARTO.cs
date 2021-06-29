using HotelParaTodes;
using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HPT_DLL.BancoDeDados;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HPT_DLL.Entidades
{
    public class QUARTO : TABELA_ENTIDADE
    {
        private static QUARTO_DAO _quarto_dao = new QUARTO_DAO();

        #region ENTIDADES

        [Required(ErrorMessage = "Número do quarto é obrigatório!")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Andar do quarto é obrigatório!")]
        public int Andar { get; set; }

        [Required(ErrorMessage = "Tipo do quarto é obrigatório!")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Descrição do quarto é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Número do quarto é obrigatório!")]
        [RegularExpression(@"(\d+)(.|,)?(\d+)?", ErrorMessage = "Valor por hora só aceita números!")]
        public float ValorPorHora { get; set; }

        // avaliacao ficaria num outro relatorio que join QUARTO e HOSPEDE
        public int Avaliacao { get; set; }
        #endregion

        #region CRUD
        public static void NOVO(QUARTO Quarto)
        {
            _quarto_dao.Adicionar(Quarto);
            MENSAGEM_AO_USUARIO.INCLUSAO_SUCESSO();
        }
        public static void ATUALIZAR(QUARTO Quarto)
        {
            _quarto_dao.Atualizar(Quarto);
            MENSAGEM_AO_USUARIO.ATUALIZADO_SUCESSO();
        }
        public static void REMOVER(QUARTO Quarto)
        {
            _quarto_dao.Remover(Quarto);
            MENSAGEM_AO_USUARIO.REMOVER_SUCESSO();
        }
        #endregion
        #region CONSULTA
        public static void CONSULTAR(string descricao, string tipo, string valorPorHora)
        {
            using (var contexto = new CONTEXTO())
            {
                var CONSULTA = from quarto in contexto.DB_QUARTOS
                               select quarto;

                if (!string.IsNullOrEmpty(descricao))
                {
                    CONSULTA = CONSULTA.Where(quarto => quarto.Nome.Equals(descricao));
                }
                if (!string.IsNullOrEmpty(tipo))
                {
                    CONSULTA = CONSULTA.Where(quarto => quarto.Tipo.Equals(tipo));
                }
                if (!string.IsNullOrEmpty(valorPorHora))
                {
                    if (float.TryParse(valorPorHora, out float flutuante))
                    {
                        CONSULTA = CONSULTA.Where(quarto => quarto.ValorPorHora.Equals(flutuante));
                    }
                }
                foreach (var item in CONSULTA)
                {
                    TELA_M_ENTIDADES.LISTA.Add(item);
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
        public override string ToString()
        {
            return $"{Nome} {Numero}";
        }
    }
}
