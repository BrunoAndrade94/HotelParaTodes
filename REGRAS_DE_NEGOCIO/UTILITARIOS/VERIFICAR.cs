using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS
{
    public class VERIFICAR
    {
        // nao funciona da forma que eu quero, precisa estar em cada classe
        public void VALIDAR_CLASSE<T>(T classe)
        {
            var contextos = new ValidationContext(classe, serviceProvider: null, items: null);
            var resultados = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(classe, contextos, resultados, true);

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
