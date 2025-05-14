using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alumnos_tem2.View
{
    public partial class MDI_control_escolar : Form
    {
        public MDI_control_escolar()
        {
            InitializeComponent();
        }

        private void MDI_control_escolar_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//solo close(); tambien 
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* //desplejar la forma de estudiantes frmEstudiantes
             frmEstudiantes forma_estudiantes = new frmEstudiantes(this);
             //SHOW DIALOG-espera una respuesta,el otro solo muestra el panel
             forma_estudiantes.Show();*/
            AbreVentanaHija("frmEstudiantes");
        }

        private void reporte111ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  frmReporte111 forma_reporte111 = new frmReporte111(this);
              forma_reporte111.Show();
            */
            AbreVentanaHija("frmReporte111");
        }

        private void reporte12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmReporte12 forma_reporte12 = new frmReporte12(this);
            forma_reporte12.Show();*/
            AbreVentanaHija("frmReporte12");
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmRoles forma_roles = new frmRoles(this);
            forma_roles.Show();*/
            AbreVentanaHija("frmRoles");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* frmUsuarios forma_usuarios = new frmUsuarios(this);
             forma_usuarios.Show();*/
            AbreVentanaHija("frmUsuarios");
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void AbreVentanaHija(string nombre_forma)
        {
            
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.ToLower() == nombre_forma.ToLower())
                {
                    // Si la ventana ya está abierta, traerla al frente y restaurarla si estaba minimizada
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    return;
                }
            }
            // Si no está abierta, crear y mostrar una nueva instancia
            Form childForm;
            switch (nombre_forma.ToLower())
            {
                case "frmestudiantes":
                    childForm = new frmEstudiantes(this);
                    break;
                case "frmreporte111":
                    childForm = new frmReporte111(this);
                    break;
                case "frmreporte12":
                    childForm = new frmReporte12(this);
                    break;
                case "frmroles":
                    childForm = new frmRoles(this);
                    break;
                case "frmusuarios":
                    childForm = new frmUsuarios(this);
                    break;
                default:
                    return;
            }
            childForm.Show();
    }
    }
}
