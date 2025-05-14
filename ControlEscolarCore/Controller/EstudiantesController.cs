using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Data;
using ControlEscolarCore.Utilities;
using ControlEscolarCore.Model;
using NLog;
using OfficeOpenXml;
//llama a todos

namespace ControlEscolarCore.Controller
{
    public class EstudiantesController
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("alumnos_tem2.Controller.EstuantesController");
        private readonly EstudiantesDataAccess _estudiantesData;
        private readonly PersonasDataAccess _personasData;
        /// <summary>
        /// constructor de estudiantes
        /// </summary>
        public EstudiantesController()
        {
            try
            {
                _estudiantesData = new EstudiantesDataAccess();
                _personasData = new PersonasDataAccess();

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "error al inicializar el controlador de estudiantes");
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soloAtivo"></param>
        /// <param name="tipoFecha"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public List<Estudiante> ObtenerEstudiantes(bool soloAtivo = true, int tipoFecha = 0, DateTime? fechaInicio = null,
            DateTime? fechaFin = null)
        {

            try
            {
                //variable var: no tienen un tipo definido, una variable tipo comodin
                var estudiantes = _estudiantesData.ObtenerTodosLosEstudiantes(soloAtivo, tipoFecha, fechaInicio, fechaFin);
                _logger.Info($"se obtuvieron {estudiantes.Count} estudiantes");
                return estudiantes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener la lista de estudiantes");
                throw;
            }
        }
        //public List<Estudiante > Buscar 
      //proceso para dar alta estudiantes
        public (int id,string mensaje) ReguistrarEstudiante(Estudiante estudiante)
        {
            try
            {
                //verificar si la matricula existe
                if (_estudiantesData.ExisteMatricula(estudiante.Matricula))
                {
                    _logger.Warn($"intento de registrar estudiante con matricula duplicada:{estudiante.Matricula}");
                    return (-3, $"la matricula{estudiante.Matricula} ya esta registrada en el sistema");
                }
                //verificar curp
                if (_personasData.ExisteCURP(estudiante.DatosPersonales.Curp)) 
                {
                    _logger.Warn($"intento de registrar estudiante con CURP duplicada:{estudiante.DatosPersonales.Curp}");
                    return (-2, $"la matricula{estudiante.DatosPersonales.Curp} ya esta registrada en el sistema");

                }
                //reguistrar estudiante
                _logger.Info($"registarndo nuevo estudiante: {estudiante.DatosPersonales.NombreCompleto}, Matricula{estudiante.Matricula}");
                int idEstudiante = _estudiantesData.InsertarEstudiante(estudiante);
                if (idEstudiante <= 0)
                {
                    return (-4, "error al registrar el estudiante en la base de datos");
                }
                _logger.Info($"estudiante registrado exitosamente co ID:{idEstudiante}");
                return (idEstudiante,"estudiante registrado exitosamente");
            }

            catch (Exception e)
            {
                _logger.Error(e, $"error al reguistrar estudiante: {estudiante.DatosPersonales.NombreCompleto ?? "sin nombre"},Matricula: {estudiante.Matricula}");
           return (-5, $"error inseperado: {e.Message}");
                    }
        }
        /// <summary>
        /// obtiene informacion detallada de un estudiante por ID
        /// </summary>
        /// <param name="idEstudiante">ID estudiante</param>
        /// <returns>objeto estudiante con toda la informacio, o null si no existe</returns>
        public Estudiante? ObtenerDetalleEstudiante(int idEstudiante)
        {
            try
            {
                _logger.Debug($"Solicitando detalle del estudiante con ID: {idEstudiante}");
                return _estudiantesData.ObtenerEstudiantePorId(idEstudiante);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener detalles del estudiante con ID: {idEstudiante}");
                throw;
            }
        }
        public (bool exito, string mensaje) ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                //Validaciones basicas
                if (estudiante == null)
                {
                    return (false, "No se proporcionaron datos del estudiante");
                }
                if (estudiante.Id <= 0)
                {
                    return (false, "ID del estusiante no valido");
                }
               /* if (estudiante.IdPersona <= 0)
                {
                    return (false, "ID de persona no valido");
                }*/
                if (estudiante.DatosPersonales == null)
                {
                    return (false, "No se proporcionaron datos personales del estudiante");
                }
                //Verificar si el estudiante existe
                Estudiante? estudianteExistente = _estudiantesData.ObtenerEstudiantePorId(estudiante.Id);
                if (estudianteExistente == null)
                {
                    return (false, $"No se encontro el estudiante con ID: {estudiante.Id}");
                }

                //Verificar si la matricula no este duplicada (si ah cambiado)
                if (estudiante.Matricula != estudianteExistente.Matricula
                    && _estudiantesData.ExisteMatricula(estudiante.Matricula))
                {
                    return (false, $"La matricula {estudiante.Matricula} ya esta registrada en el sistema");
                }
                estudiante.DatosPersonales.Id=estudianteExistente.IdPersona;

                //Verificar que el CURP no este duplicado (si ah cambiado)
                if (estudiante.DatosPersonales.Curp != estudianteExistente.DatosPersonales.Curp)
                {
                    //Buscar si existe otra persona con el mismo curp que no sea la persona de este estudiante
                    bool personaConMismoCurp = _personasData.ExisteCURP(estudiante.DatosPersonales.Curp);
                    if (personaConMismoCurp)
                    {
                        return (false, $"El CURP {estudiante.DatosPersonales.Curp} ya esta registrado para otra persona");
                    }
                }

                //Actualizar el estudiante
                _logger.Info($"Actualizando estudiante con ID: {estudiante.Id}, Nombre: {estudiante.DatosPersonales.NombreCompleto}");
                bool resultado = _estudiantesData.ActualizarEstudiante(estudiante);

                if (!resultado)
                {
                    _logger.Error($"Error al actualizar el estudiante con el ID: {estudiante.Id}");
                    return (false, "Error al actualizar el estudiante en la base de datos");
                }

                _logger.Info($"El estudiante con el ID: {estudiante.Id} actualizado exitosamente");
                return (true, "Estudiante actualizado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
                throw;
            }
        }
        //funcion
        public bool ExportarEstudiantesExcel(string rutaArchivo,bool soloActivos=true,
            int tipoFecha=0,DateTime? fechaInicio=null,
            DateTime? fechaFin=null)
        {
            try
            {//obtener estudiantes
                var estudiantes = ObtenerEstudiantes(soloActivos, tipoFecha, fechaInicio, fechaFin); 
                if(estudiantes == null || estudiantes.Count() == 0){
                    _logger.Warn("no hay estudiantes para exportar");
                    return false;
                }
                //crear archivo excel
                using(var packge =new ExcelPackage())
                {//el using: una vez que cierre el using libera la memoria utilizada
                    //crear una hoja de trabajo
                    var worksheet = packge.Workbook.Worksheets.Add("Estudiantes");
                    //establecer encabezados
                    worksheet.Cells[1, 1].Value = "Matricula";
                    worksheet.Cells[1, 2].Value = "Nombre Completo";
                    worksheet.Cells[1, 3].Value = "Correo";
                    worksheet.Cells[1, 4].Value = "Semestre";
                    worksheet.Cells[1, 5].Value = "Telefono";
                    worksheet.Cells[1, 6].Value = "CURP";
                    worksheet.Cells[1, 7].Value = "Fecha tipo";
                    worksheet.Cells[1, 8].Value = "Fecha Alta";
                    worksheet.Cells[1, 9].Value = "Fecha Baja";
                    worksheet.Cells[1, 10].Value = "Estado";
                    //aplicar formato a los encabezados
                    using(var range = worksheet.Cells[1,1,1,10])
                    {
                        /*de que fila[1], de que columna,[1], hasta donde seran los encabezados[10] */
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }
                    //llenar los datos 
                    int row = 2;//es la siguiente fila donde se incertara los datos
                    foreach(var estudiante in estudiantes)
                    {//.cell ubica el dato pasa el reglon(x) y la columna(y)
                        worksheet.Cells[row, 1].Value = estudiante.Matricula;
                        worksheet.Cells[row, 2].Value = estudiante.DatosPersonales.NombreCompleto;
                        worksheet.Cells[row, 3].Value = estudiante.Semestre;
                        worksheet.Cells[row, 4].Value = estudiante.DatosPersonales.Correo;
                        worksheet.Cells[row, 5].Value = estudiante.DatosPersonales.Telefono;
                        worksheet.Cells[row, 6].Value = estudiante.DatosPersonales.Curp;
                        worksheet.Cells[row, 7].Value = estudiante.DatosPersonales.FechaNacimiento;
                        worksheet.Cells[row, 8].Value = estudiante.FechaAlta;
                        worksheet.Cells[row, 9].Value = estudiante.FechaBaja;
                        worksheet.Cells[row, 10].Value = estudiante.DescripcionEstatus;//para que no aparesca con numeros
                        //aplicar formato a las fechas
                        if (estudiante.DatosPersonales.FechaNacimiento.HasValue)//si tiene valor de fecha de nacimiento
                        {//hoja de trabajao, en la celda 7.poner un estilo 
                            worksheet.Cells[row, 7].Style.Numberformat.Format = "dd/MM/yyyy";
                         }//fecha alta no pasa por el filtro porque en algun momento el estudiante se debio dar de alta para estar registrado
                        worksheet.Cells[row, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                        if (estudiante.FechaBaja.HasValue)
                        {
                            worksheet.Cells[row, 9].Style.Numberformat.Format = "dd/MM/yyyy";

                        }
                        row++;
                    }
                    //ajustar el ancho de las columnas
                    //dimensio addres identifica el campos mas grande y lo ajusta
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();//modificar el tamaños de las columnas 
                    //guardar archivo
                    FileInfo fileInfo = new FileInfo(rutaArchivo);
                    packge.SaveAs(fileInfo);
                    _logger.Info($"Archivo Excel exportado correctamente:{rutaArchivo}");
                    return true;
                            }
            }
            catch(Exception e)
            {
                _logger.Error(e, "Error al exportar estudiantes Excel "); throw;
            }

        }
    }    
}
