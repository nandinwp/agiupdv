using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

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

            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = property.GetValue(entity);

                if (value == null)
                {
                    erros.Add($"A propriedade '{property.Name}' não pode ser nula.");
                }
                else if (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(value as string))
                {
                    erros.Add($"A propriedade '{property.Name}' não pode ser vazia.");
                }
            }

            return !erros.Any();
        }
    }
}
