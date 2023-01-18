using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    public class FormErros
    {
        private readonly Dictionary<CampoForm, string> erros;

        public FormErros()
        {
            erros = new Dictionary<CampoForm, string>();
        }

        public void AddErro(CampoForm campo, string message)
        {
            erros.Add(campo, message);
        }
        public void Clear()
        {
            erros.Clear();
        }

        public bool HasErro(CampoForm campo)
        {
            return erros.TryGetValue(campo, out var _);
        }

        public bool isEmpty()
        {
            return erros.Count() == 0;
        }

        public string GetErrorMessage(CampoForm campo)
        {
            return HasErro(campo) ? erros[campo] : string.Empty;
        }
    }
}
