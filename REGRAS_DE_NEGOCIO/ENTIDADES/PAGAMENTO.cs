using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES
{
    public class PAGAMENTO : TABELA_ENTIDADE
    {
        public string Nome { get; set; }
        public string Operadora { get; set; }

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
