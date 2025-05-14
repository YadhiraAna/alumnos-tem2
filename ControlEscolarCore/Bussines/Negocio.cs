using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;

namespace ControlEscolarCore.Bussines
{
    public class UsuariosNegocio
    {
        public static bool EsFormatoValido(string correo)
        {
            return Validaciones.EsCorreoValido(correo);
        }
    }
    public class EstudiantesNegocio()
    {
        public static bool EsCorreoVaalido(string correo)
        {
            return Validaciones.EsCorreoValido(correo);
        }
        public static bool EsCURPValido(string curp)
        {
            return Validaciones.EsCURPValido(curp);
        }
        /*
         * este metodo no va en utilies es algo particular sde almno
         */
        public static bool EsNoControlValido(string nocontrol)
        {
            string patron = @"^(T|M)-\d{4}-\d{3,5}$";
            return Regex.IsMatch(nocontrol, patron);
        }
    }
}
