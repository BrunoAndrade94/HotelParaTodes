using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO;
using HPT_DLL.BancoDeDados;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using System;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES
{
    public class CARGO : TABELA_ENTIDADE, ICRUD
    {
        private static CARGO_DAO _cargo_dao = new CARGO_DAO();
        private static CARGO _Cargo;

        [Required(ErrorMessage = "Nome do cargo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Salário é obrigatório!")]
        public float Salario { get; set; }

        [Required(ErrorMessage = "Carga horária é obrigatório!")]
        public float CargaHoraria { get; set; }
        public void INCLUIR()
        {
            #region CARGO
            _Cargo = new CARGO
            {
                CargaHoraria = float.Parse(TELA_M_ENTIDADES.LISTA_STRING[0]),
                Nome = TELA_M_ENTIDADES.LISTA_STRING[1],
                Salario = float.Parse(TELA_M_ENTIDADES.LISTA_STRING[2]),
                Inclusao = DateTime.Now,
                Alteracao = DateTime.Now
            };
            NOVO(_Cargo);
            #endregion
        }
        public void EXCLUIR()
        {

        }
        public void ATUALIZAR()
        {

        }
        #region CRUD
        public static void NOVO(CARGO _Cargo)
        {
            _cargo_dao.Adicionar(_Cargo);
            MENSAGEM_AO_USUARIO.INCLUSAO_SUCESSO();
        }
        public static void ATUALIZAR(CARGO _Cargo)
        {
            _cargo_dao.Atualizar(_Cargo);
            MENSAGEM_AO_USUARIO.ATUALIZADO_SUCESSO();
        }
        public static void REMOVER(CARGO _Cargo)
        {
            _cargo_dao.Remover(_Cargo);
            MENSAGEM_AO_USUARIO.REMOVER_SUCESSO();
        }
        #endregion

        #region CONSULTA
        public static void CONSULTAR(string descricao, string salario, string cargaHoraria)
        {
            using (var contexto = new CONTEXTO())
            {
                var CONSULTA = from cargo in contexto.DB_CARGOS
                               select cargo;

                if (!string.IsNullOrEmpty(descricao))
                {
                    CONSULTA = CONSULTA.Where(cargo => cargo.Nome.Equals(descricao));
                }

                if (!string.IsNullOrEmpty(cargaHoraria))
                {
                    CONSULTA = CONSULTA.Where(cargo => cargo.CargaHoraria.Equals(cargaHoraria));
                }

                if (!string.IsNullOrEmpty(salario))
                {
                    if (float.TryParse(salario, out float flutuante))
                    {
                        CONSULTA = CONSULTA.Where(cargo => cargo.Salario.Equals(flutuante));
                    }
                }
                foreach (var item in CONSULTA)
                {
                    TELA_M_ENTIDADES.LISTA.Add(item);
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
