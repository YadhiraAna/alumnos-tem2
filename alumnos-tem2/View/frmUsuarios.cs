using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using alumnos_tem2.Utilities;

namespace alumnos_tem2.View
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios(Form parent)
        {
            InitializeComponent();
            Formas.InicializarForma(parent, this);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
