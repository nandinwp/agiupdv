using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Utils
{
    public static class ValidationHelper
    {
        public static bool Validar<T>(T entity, out List<string> erros)
        {
            erros = new List<string>();

            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                entity,
                new ValidationContext(entity),
                validationResults,
                true
            );

            if (!isValid)
            {
                erros.AddRange(validationResults.Select(vr => vr.ErrorMessage));
            }

            return isValid;
        }


    }
}
