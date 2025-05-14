using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlEscolarCore.Utilities
{
    public class Validaciones//no  es public ni privada, solo es vicible para el proyecto
    {
        public static bool EsCorreoValido(string correo)//static no llamar un objeto 
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            //es boleano--
            return Regex.IsMatch(correo, patron);
        }
      
        public static bool EsCURPValido(string curp)
        {
            string patron = "^[A-Z]{4}\\d{6}[HM]{1}[A-Z]{5}\\d{2}$";
            return Regex.IsMatch(curp, patron);
        }
    }
}
