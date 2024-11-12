using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Utils
{
    public static class Helpers
    {
        public static object ExtractMethodFromBaseName(string name)
        {
            string entityName = $"Agiu_PDV.Models.{name}";
            
            Type type = Type.GetType(entityName);

            if (type == null)
            {
                throw new InvalidOperationException($"Tipo '{entityName}' não encontrado.");
            }

            return Activator.CreateInstance(type);
        }
    }
}
