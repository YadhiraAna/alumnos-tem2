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
using ControlEscolarCore.Controller;
using ControlEscolarCore.Utilities;
using alumnos_tem2.Utilities;
using ControlEscolarCore.Utilities;
using ControlEscolarCore.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
namespace alumnos_tem2.View
{
    public partial class frmEstudiantes : Form
    {
        public frmEstudiantes(Form parent)//
        {
            InitializeComponent();//como una froma
            Formas.InicializarForma(parent, this);//coun un padre
            //InicializarForma(parent);

        }


        private void frmEstudiantes_Load(object sender, EventArgs e)//cargar-cuando la forma ya se creo
        {
            //la inicializacion de valores debe ser depues del la creacion de la forma, se hace en la froma general ya creada 
            InicializaVentanaEstudiantes();

        }
        private void cbox_estatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InicializaVentanaEstudiantes()//con todas la indicaciones para la ventana
        {
            PoblaComboEstatus();
            PoblaComboTipoFecha();
            scEstudiantes.Panel1Collapsed = true;
            dtp_fecha_alta.Value = DateTime.Now;//date time es un iobjetos-now fecha de hoy y la asigna a fecha alta
            CargarEstudiantes();
            /*PoblaComboEstatus();
            scEstudiantes
             */
        }
        private void CargarEstudiantes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;//para que se vea cargando
                                            //crea una instancia de controller
                EstudiantesController estudiantesController = new EstudiantesController();
                //obtener la lista de estudiantes por defecto
                List<Estudiante> estudiantes = estudiantesController.ObtenerEstudiantes(
                    soloAtivo: false,
                    tipoFecha: cbox_tipoFecha.SelectedValue != null ? (int)cbox_tipoFecha.SelectedValue : 0
                    , fechaInicio: dtp_inicio.Enabled ? dtp_inicio.Value : (DateTime?)null,
                    fechaFin: dtp_fin.Enabled ? dtp_fin.Value : (DateTime?)null
                    );

                dgvEstudiantes.DataSource = null;
                //if ()
                if (estudiantes.Count == 0)
                {
                    lbl_totalReg.Text = "Total: 0 registros";
                    if (!string.IsNullOrEmpty(txt_busqueda.Text))
                    {
                        MessageBox.Show("no se encontraron estudiantes con el criterio de busqueda especificado.", "informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Matrícula", typeof(string));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Semestre", typeof(string));
                dt.Columns.Add("Correo", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("CURP", typeof(string));
                dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
                dt.Columns.Add("Fecha Alta", typeof(DateTime));
                dt.Columns.Add("Estatus", typeof(string));

                foreach (Estudiante estudiante in estudiantes)
                {
                    dt.Rows.Add(
                        estudiante.Id,
                        estudiante.Matricula,
                        estudiante.DatosPersonales.NombreCompleto,
                        estudiante.Semestre,
                        estudiante.DatosPersonales.Correo,
                        estudiante.DatosPersonales.Telefono,
                        estudiante.DatosPersonales.Curp,
                        estudiante.DatosPersonales.FechaNacimiento,
                        estudiante.FechaAlta,
                        estudiante.DescripcionEstatus
                    );
                }
                //asignar a la datatable como
                dgvEstudiantes.DataSource = dt;
                //lllenar la tabla con esos reguistros
                //configrar vista
                ConfigurarDataGridView();
                lbl_totalReg.Text = $"Total:{estudiantes.Count} registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes.Contacta al administardor del sistema", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //flecha de que puede tener un estatus, waitcursor
                Cursor = Cursors.Default;//libere el cursos vuelbva a su forma normal
            }
        }
        public void ConfigurarDataGridView()
        {

            //Ajustes generales
            dgvEstudiantes.AllowUserToAddRows = false;
            dgvEstudiantes.AllowUserToDeleteRows = false;
            dgvEstudiantes.ReadOnly = true;

            // Ajustar el ancho de las columnas
            dgvEstudiantes.Columns["Matrícula"].Width = 100;
            dgvEstudiantes.Columns["Nombre Completo"].Width = 200;
            dgvEstudiantes.Columns["Semestre"].Width = 80;
            dgvEstudiantes.Columns["Correo"].Width = 180;
            dgvEstudiantes.Columns["Teléfono"].Width = 120;
            dgvEstudiantes.Columns["CURP"].Width = 150;
            dgvEstudiantes.Columns["Fecha Nacimiento"].Width = 120;
            dgvEstudiantes.Columns["Fecha Alta"].Width = 120;
            dgvEstudiantes.Columns["Estatus"].Width = 100;

            // Ocultar columna ID si es necesario
            dgvEstudiantes.Columns["ID"].Visible = false;

            // Formato para las fechas
            dgvEstudiantes.Columns["Fecha Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEstudiantes.Columns["Fecha Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Alineación
            dgvEstudiantes.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEstudiantes.Columns["Matrícula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Semestre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Estatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color alternado de filas
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray;

            // Selección de fila completa
            dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo de cabeceras
            dgvEstudiantes.EnableHeadersVisualStyles = false;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEstudiantes.Font, FontStyle.Bold);
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenar al hacer clic en el encabezado
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstudiantes.ColumnHeadersHeight = 35;
        }

        private void scEstudiantes_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        //metodo para inicializar forma, que sea hija, para estar dentro del mdi

        //metodo para 

        private void PoblaComboEstatus()
        {

            Dictionary<int, string> list_estatus = new Dictionary<int, string>()
            {
                //key,value
    { 1, "Activo" },
    { 0, "Baja" },
    { 2, "Baja Temporal" }
        };
            //asignar el diccionario al combobox
            cbox_estatus.DataSource = new BindingSource(list_estatus, null);
            //es la fuente de datos que seria la lista atraves del objeto binding
            cbox_estatus.DisplayMember = "value";//lo que muestra
            cbox_estatus.ValueMember = "key";//con la que se enlaza a la base de datos
            cbox_estatus.SelectedValue = 1;//valor inicializado

        }

        private void PoblaComboTipoFecha()
        {

            Dictionary<int, string> list_tipofechas = new Dictionary<int, string>()
            {

    { 1, "Nacimiento" },
    { 0, "Alta" },
    { 2, "Baja" }
        };
            //asignar el diccionario al combobox
            cbox_tipoFecha.DataSource = new BindingSource(list_tipofechas, null);
            //es la fuente de datos que seria la lista atraves del objeto binding
            cbox_tipoFecha.DisplayMember = "value";//lo que muestra
            cbox_tipoFecha.ValueMember = "key";//con la que se enlaza a la base de datos
            cbox_tipoFecha.SelectedValue = 1;//valor inicializado

        }
        private void txt_num_control_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void scEstudiantes_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_mostrarCap_Click(object sender, EventArgs e)
        {
            if (scEstudiantes.Panel1Collapsed)//si esta colapsado
            {
                //entonces no colapsar
                scEstudiantes.Panel1Collapsed = false;
                btn_mostrarCap.Text = "ocultar captura rapida";
            }
            else
            {
                scEstudiantes.Panel1Collapsed = true;

                btn_mostrarCap.Text = "mostrar captura rapida";
            }
        }

        private void btn_carga_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "seleccionar aarchivo de Excel";//titulo para que se intuitivo
            ofdArchivo.Filter = "archivos de excel(*.xlsx;*.xls)|*.xlsx;*.xls";//un filtro para solo abrir archivos tipo excel
                                                                               //ofdArchivo.InitialDirectory = "C:\\";//directorio inicial ,solo como sugerencia de donde estar
            ofdArchivo.FilterIndex = 1;
            ofdArchivo.RestoreDirectory = true;//mantiene  la ultima ruta utilizada, para no mandarlo en c
                                               //VALIDACIONES
            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdArchivo.FileName;
                string extencion = Path.GetExtension(filePath).ToLower();//ocupa una extencion para validar
                if (extencion == ".xlsx" || extencion == ".xls")
                {
                    MessageBox.Show("archivo valido: " + filePath, "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("porfavor, seleccione unarchivo de excel valido ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            //determinar si estamos en modo edicion o nuevi registro
            if (btn_guardar.Text == "Actualizar")
            {
                ActualizarEstudiante();
            }
            else { GuardarEstudiante(); }

        }
        private bool GuardarEstudiante()
        {
            try
            {
                if (DatosVacios())
                {
                    MessageBox.Show("porfavor,llene todos los campos", "Informacion del sistema", MessageBoxButtons.OK);
                    return false;
                }
                if (!DatosValidos())
                {
                    return false;
                }
                //crear elobeto persona con los datos del formulario
                Persona persona = new Persona(
                    txt_nombre.Text.Trim(),
                    txt_correo.Text.Trim(),
                    txt_telefono.Text.Trim(),
                    txt_curp.Text.Trim()
                    );
                persona.FechaNacimiento = dtp_fecha_nacimiento.Value;
                //crear estudiante con los datos del formulario

                //asignar fecha de nnacimiento
                Estudiante estudiante = new Estudiante
                {
                    Matricula = txt_num_control.Text.Trim(),
                    Semestre = npd_semestre.Text.Trim(),
                    FechaAlta = dtp_fecha_alta.Value,
                    Estatus = 1, //Activo por defecto
                    DatosPersonales = persona
                };
                //Crear intancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                //Llamar el metodo para registrar el estudiante utilizando el modelo
                var (idEstudiante, mensaje) = estudiantesController.ReguistrarEstudiante(estudiante);

                //Verificar el resultado
                if (idEstudiante > 0)
                {
                    MessageBox.Show(mensaje, "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); //Metodo para limpiar el formulario edspues de guardar--!!

                    //Actualizar la lista de estudiantes si esta presente en la misma vista
                    CargarEstudiantes();
                }
                else
                {
                    //Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //Enfocar el campo apropiado basado en el codigo de error
                    switch (idEstudiante)
                    {
                        case -2: //Error de curp duplicado
                            txt_curp.Focus();
                            txt_curp.SelectAll();
                            break;
                        case -3: //Error de matricula duplicada
                            txt_num_control.Focus();
                            txt_num_control.SelectAll();
                            break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                //el detalle del error ya se guarara en log de controler
                MessageBox.Show("no se pudo completar el reguistro del estudiante, porfavor, intente nuevamente o cantacte al administrado del sistema", "infromacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool DatosVacios()
        {
            if (txt_nombre.Text == "" || txt_correo.Text == "" || txt_telefono.Text == ""
                || txt_curp.Text == "" || npd_semestre.Text == "" || txt_num_control.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DatosValidos()

        {

            if (!EstudiantesNegocio.EsCorreoVaalido(txt_correo.Text.Trim()))

            {

                MessageBox.Show("Correo inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;

            }

            if (!EstudiantesNegocio.EsCURPValido(txt_curp.Text.Trim()))

            {

                MessageBox.Show("CURP inválida.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;

            }

            if (!EstudiantesNegocio.EsNoControlValido(txt_num_control.Text.Trim()))

            {

                MessageBox.Show("Número de control inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;

            }

            return true;

        }

        private void cbox_tipoFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btn_actualizar_Click_1(object sender, EventArgs e)
        {
            CargarEstudiantes();
        }

        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ObtenerDetalleEstudiante(int idEstudiante)
        {
            try
            { // Llamar al controlador para obtener el estudiante
                EstudiantesController controller_estudiante = new EstudiantesController();
                Estudiante? estudiante = controller_estudiante.ObtenerDetalleEstudiante(idEstudiante);
                if (estudiante != null)
                {
                    // Poblar los controles con la información del estudiante
                    CargarDatosEstudiante(estudiante);
                    // Cambiar a modo de edición
                    ModoEdicion(true);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del estudiante.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los detalles del estudiante: fex.Message)",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDatosEstudiante(Estudiante estudiante)
        {

            // Datos personales
            txt_nombre.Text = estudiante.DatosPersonales.NombreCompleto;
            txt_correo.Text = estudiante.DatosPersonales.Correo;
            txt_telefono.Text = estudiante.DatosPersonales.Telefono;
            txt_curp.Text = estudiante.DatosPersonales.Curp;

            if (estudiante.DatosPersonales.FechaNacimiento.HasValue)
                dtp_fecha_nacimiento.Value = estudiante.DatosPersonales.FechaNacimiento.Value;
            else
                dtp_fecha_nacimiento.Value = DateTime.Now;

            // Datos del estudiante
            txt_num_control.Text = estudiante.Matricula;

            // Buscar el semestre en el control
            // Convertir el semestre a número y asignarlo al NumericUpDown
            if (int.TryParse(estudiante.Semestre, out int semestreNumero))
            {
                // Validar que esté dentro del rango del control___________NUMERICUPDOWN
                if (semestreNumero >= npd_semestre.Minimum && semestreNumero <= npd_semestre.Maximum)
                {
                    npd_semestre.Value = semestreNumero;
                }
                else
                {
                    npd_semestre.Value = npd_semestre.Minimum; // o un valor por defecto seguro
                }
            }
            else
            {
                npd_semestre.Value = npd_semestre.Minimum; // si no se puede convertir
            }
            /* for (int i = 0; i <upSemestre.Items.Count; i++)
             {
                 if (upSemestre.Items[i].ToString() == estudiante.Semestre)
                 {
                     upSemestre.SelectedIndex = i;
                     break;

                 }
             }*/
            // Fechas

            dtp_fecha_alta.Value = estudiante.FechaAlta;

            if (estudiante.FechaBaja.HasValue)//***!!!!!!!!!!!!!!!

            {
                dtp_fecha_baja.Value = estudiante.FechaBaja.Value;
                dtp_fecha_baja.Enabled = true;

            }
            else
            {
                dtp_fecha_baja.Value = DateTime.Now;
                dtp_fecha_baja.Enabled = false;
            }
            // Estatus

            cbox_estatus.SelectedValue = estudiante.Estatus;
            // Guardar el ID en una propiedad o tag para usarlo al actualizar
            this.Tag = estudiante.Id;
        }
        private void ModoEdicion(bool edicion)
        {
            // Cambiar título y configurar botones según el modo
            gb_alta.Text = edicion ? "Editar Estudiante" : "Nuevo Estudiante";
            btn_guardar.Text = edicion ? "Actualizar" : "guardar";

            // Si es modo edición, desactivar campos que no deberían modificarse
            txt_num_control.ReadOnly = edicion;

            // Activar el panel izquierdo para mostrar los detalles
            if (scEstudiantes.Panel1Collapsed)
            {
                scEstudiantes.Panel1Collapsed = false;
                btn_mostrarCap.Text = "Ocultar captura rápida";
            }
        }


        private void editarEstuidanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada en el grid
                if (dgvEstudiantes.SelectedRows.Count > 0)
                {
                    // Obtener el ID del estudiante de la fila seleccionada
                    int idEstudiante = Convert.ToInt32(dgvEstudiantes.SelectedRows[0].Cells["id"].Value);
                    // Llamar a la función para obtener y mostrar los detalles
                    ObtenerDetalleEstudiante(idEstudiante);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un estudiante para editar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar la edición del estudiante: (ex.Message)",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarEstudiante()
        {
            try
            {
                // Validaciones a nivel de interfaz
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, llene todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DatosValidos())
                {
                    return;
                }
                // Obtener el 1D del estudiante almacenado en el Tag

                if (this.Tag == null || !(this.Tag is int))
                {
                    MessageBox.Show("No se ha seleccionado un estudiante para actualizar.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idEstudiante = (int)this.Tag;
                // Crear el objeto Persona con los datos del formulario
                Persona persona = new Persona
                {
                    Id = 0, // Se actualizará con el valor correcto en el controller
                    NombreCompleto = txt_nombre.Text.Trim(),
                    Correo = txt_correo.Text.Trim(),
                    Telefono = txt_telefono.Text.Trim(),
                    Curp = txt_curp.Text.Trim(),
                    FechaNacimiento = dtp_fecha_nacimiento.Value,
                    Estatus = true // Asumimos que la persona está activa
                };

                // Crear el objeto Estudiante con los datos del formulario

                Estudiante estudiante = new Estudiante
                {
                    Id = idEstudiante,
                    IdPersona = 0, // Se actualizará con el valor correcto en el controller
                    Matricula = txt_num_control.Text.Trim(),
                    Semestre = npd_semestre.Text.Trim(),
                    FechaAlta = dtp_fecha_alta.Value,
                    Estatus = cbox_estatus.SelectedValue != null ? (int)cbox_estatus.SelectedValue : 1,
                    DatosPersonales = persona
                };
                // O=Baja,Activo, 2=Baja Temporal
                // Asignar fecha de baja si corresponde
                if (cbox_estatus.SelectedIndex == 0) // Si el estatus es "Baja"
                {
                    estudiante.FechaBaja = dtp_fecha_baja.Value;
                }
                else if (dtp_fecha_baja.Enabled && cbox_estatus.SelectedIndex == 2) // Si es "Baja Temporal" y hay fecha
                {
                    estudiante.FechaBaja = dtp_fecha_baja.Value;

                }
                else
                {
                    estudiante.FechaBaja = null;

                }
                // Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                // Llamar al método para actualizar el estudiante utilizando el modelo
                var (resultado, mensaje) = estudiantesController.ActualizarEstudiante(estudiante);

                // Verificar el resultado
                if (resultado)
                {
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar formulario y restablecer modo
                    LimpiarCampos();
                    ModoEdicion(false);
                    // Actualizar la lista de estudiantes
                    CargarEstudiantes();
                }
                else
                {
                    // Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                // El detalle del error ya se guardará en el log por el controlador
                MessageBox.Show("No se pudo completar la actualización del estudiante. Por favor, intente nuevamente o contacte al administrador",
                "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txt_nombre.Clear();
            txt_correo.Clear();
            txt_telefono.Clear();
            txt_curp.Clear();
            txt_num_control.Clear();
            npd_semestre.Value = 1;
            dtp_fecha_alta.Value = DateTime.Now;
            dtp_fecha_nacimiento.Value = DateTime.Now;
            cbox_estatus.SelectedValue = 2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvEstudiantes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void toolTip_nu_control_Popup(object sender, PopupEventArgs e)
        {

        }

        private void cmsEstudiantes_Opening(object sender, CancelEventArgs e)
        {

        }
        public void ImportarExcel()
        {
            try
            {
                // Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                // Obtener los filtros actuales de la interfaz
                bool soloActivos = chSoloActivos.Checked;
                int tipoFecha = cbox_tipoFecha.SelectedValue != null ? (int)cbox_tipoFecha.SelectedValue : 0;
                DateTime? fechaInicio = dtp_inicio.Value;
                DateTime? fechaFin = dtp_fin.Value;

                // Mostrar diálogo para guardar archivo
                /*open file solo abre no guarda
                 */
                //savefiledialog para guardar archivos, desde codigo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo de Excel";
                    saveFileDialog.FileName = $"Estudiantes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";//nombre del archivo
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(
                        Environment.SpecialFolder.Desktop);//por default en el escritorio

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)//muestra un msj
                    {
                        // Mostrar cursor de espera
                        Cursor.Current = Cursors.WaitCursor;

                        // Exportar usando el método del controlador
                        bool resultado = estudiantesController.ExportarEstudiantesExcel(
                            saveFileDialog.FileName,
                            soloActivos,
                            tipoFecha,
                            fechaInicio,
                            fechaFin);

                        // Restaurar cursor normal
                        Cursor.Current = Cursors.Default;

                        if (resultado)
                        {
                            MessageBox.Show("Archivo Excel exportado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Preguntar si desea abrir el archivo
                            DialogResult abrirArchivo = MessageBox.Show(
                                "¿Desea abrir el archivo Excel generado?",
                                "Abrir archivo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (abrirArchivo == DialogResult.Yes)
                            {
                                var startInfo = new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveFileDialog.FileName,
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron estudiantes para exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exc_Click(object sender, EventArgs e)
        {
            ImportarExcel();
        }
    }
}