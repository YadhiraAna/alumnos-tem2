using alumnos_tem2.View;
using NLog;
using alumnos_tem2.Utilities;
using OfficeOpenXml;
using ControlEscolarCore.Controller;
using ControlEscolarCore.Data;

namespace alumnos_tem2
{
    internal static class Program
    {
        private static Logger? _logger;//variable global para todo el sistema
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
           // _logger = LoggingManager.GetLogger("alumnos_tem2.program");
            //_logger.Info("Aplicacion iniciada");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new View.frmLogin());
       


            frmLogin login_form = new frmLogin();
            if (login_form.ShowDialog() == DialogResult.OK)
            {//si la respuesta es ok lo que va a correr el mdi
                Application.Run(new MDI_control_escolar());
            }//levantar como aplicacion completa al mdi y no al login
        }
    }
}