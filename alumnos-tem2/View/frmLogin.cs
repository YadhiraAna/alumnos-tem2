using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolarCore.Bussines;
using NLog;
using ControlEscolarCore.Utilities;

namespace alumnos_tem2.View
{
    public partial class frmLogin : Form
    {
        //private static readonly Logger _logger = LoggingManager.GetLogger("alumnos_tem2.View.frmLogin");
        //o  private static readonly Logger _logger = LoggingManager.GetLogger("frmLogin");
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_inicio_Click(object sender, EventArgs e)
        {
           /* if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                MessageBox.Show("El campo de usuario no puede estar vacio.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacio.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UsuariosNegocio.EsFormatoValido(txt_usuario.Text))
            {
                MessageBox.Show("El nombre del usuario no tiene el formato correcto", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Listo para iniciar sesion", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
           */
            //Estamos listos para inicar sesion 
            this.Hide();
            //MDI_Cotrol_escolar mdi = new MDI_Cotrol_escolar();
            //mdi.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //_logger.Info("Usuario accedio ha iniciar secion");//mensaje que se escribira en el log
            //_logger.Warn("espacio en disco bajo");//mesnaje de advertencia
            try
            {
                try
                {
                    int divisor = 0;
                    int resultado = 10/divisor;//esto genera una DivideByZeroException

                }
                catch (DivideByZeroException ex)
                {
                    throw new ApplicationException("Error al realizar el calculo en la aplicacion", ex);
                }

            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "Se produjo un error en la operacion");
                if (ex.InnerException != null)
                {
                    //si hubo un error con una excepcion mas detallada
                   // _logger.Fatal(ex,$"Error critio con detalle interno:{ex.InnerException.Message}");
                }
            }
        }
    }
}
