using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;//es el nuget de prostgre
using NLog;//nuget para logs
using ControlEscolarCore.Utilities;//esta el loggin manager
using ControlEscolarCore.Model;//la clase de estudiantes, y personas

namespace ControlEscolarCore.Data
{
    public class EstudiantesDataAccess
    {//logger para esta clase
        private static readonly Logger _logger = LoggingManager.GetLogger("alumnos_tem2.Data.EstudiantesDataAccess");
        /// 
        private readonly PostgreSQLDataAccess _dbAccess;
        //
        private readonly PersonasDataAccess _personasData;
        //constructor
        public EstudiantesDataAccess()
        {
            try
            {
                //obtinee la instancia de postgre
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                //para la unica intacnia de bd
                //instancia al acceso a datos de personas para operaciones relacionadas
                _personasData = new PersonasDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "error al inicializar EstudiantesDataAccess");
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes(bool soloActivos = true, int tipoFecha = 0, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            //solo acitvos ==true; por defecto si no se pone el parmetro se pone true
            //tipo fecha=alta,baja,nacimiento
            //rango de fechas que interactua con la consultas, pueden estar nulas
            List<Estudiante> estudiantes = new List<Estudiante>();

            try
            {
                string query = @"
                    SELECT e.id,e.matricula,e.semestre,e.fecha_alta,e.fecha_baja,e.estatus,
                            CASE
                                WHEN e.estatus=0 THEN 'Baja'
                                WHEN e.estatus=1 THEN 'Activo'
                                WHEN e.estatus=2 THEN 'Baja temporal'
                                    ELSE
                                        'Desconocido'
                            END AS descestatus_estudiante,
                                e.id_persona,p.nombre_completo,p.correo,p.telefono,p.fecha_nacimiento,p.curp,p.estatus as estatus_persona
                    FROM escolar.estudiantes e
                    INNER JOIN seguridad.personas p ON e.id_persona=p.id
                    WHERE 1=1";//Iniciamos con na condicion siempre verdadeera para facilitar la adicion de filros 
                

                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                if (soloActivos)
                {
                    query += " AND e.estatus = 1";
                }
                if (fechaInicio != null && fechaFin != null)
                {
                    switch (tipoFecha)
                    {
                        case 1://fecha de nacimiento
                            query += " AND p.fecha_nacimiento BETWEEN @FechaInicio AND @FechaFin";
                            break;
                        case 2://decha alta
                            query += " AND e.fecha_alta BETWEEN @FechaInicio AND @FechaFin";
                            break;
                        case 3://fecha baja
                            query += " AND e.fecha_baja BETWEEN @FechaInicio AND @FechaFin";
                            break;
                    }
                    //@ es un parametro, nombre: valor
                    //añadir a la lista como tipo parametro
                    parametros.Add(_dbAccess.CreateParameter("@FechaInicio", fechaInicio.Value));
                    parametros.Add(_dbAccess.CreateParameter("@FechaFin", fechaFin.Value));

                }
                //ordena por id o matricula para tener orden predeternado
                query += " ORDER BY e.id";
                //establece conexion
                //lisra para hacer la conexion
                //paso 1 -conectarse
                _dbAccess.Connect();
                //ejecuta la consulta con sus parametros
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, parametros.ToArray());
                /*la lista ya tiene algo debe mandarlo a donde fue llamado(donde se llamara
                 antes del view pasa por el controller    
                 */
                //convertir los resultados a objetos estudiantes
                foreach (DataRow row in resultado.Rows)
                {
                    //es el reglon de una tabla el resultado: por cada row recorrer, forecah de reglones de datatable
                    Persona persona = new Persona(//crear una persona, de acuerdo al constructor todos sus datos
                    Convert.ToInt32(row["id_persona"]),
                        row["nombre_completo"].ToString() ?? "",
                        row["correo"].ToString() ?? "",
                        row["telefono"].ToString() ?? "",
                        row["curp"].ToString() ?? "",
                        row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                         Convert.ToBoolean(row["estatus_persona"])
                        );

                    //crear el objeto estudiante
                    Estudiante estudiante = new Estudiante(
                  Convert.ToInt32(row["id"]),
                  Convert.ToInt32(row["id_persona"]),
                      row["matricula"].ToString() ?? "",
                      row["semestre"].ToString() ?? "",
                     Convert.ToDateTime(row["fecha_alta"]),
                      row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                      Convert.ToInt32(row["estatus"]),
                      row["descestatus_estudiante"].ToString() ?? "",
                      persona
                       );
                    estudiantes.Add(estudiante);
                }
                _logger.Debug($"Se obtuvieron{estudiantes.Count} resguistros de esestudiantes");
                return estudiantes;
            } catch (Exception ex) {
                //logear error
                _logger.Error(ex, "Error al obtener informacion de los estudiantes de la base de datos");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();//asegura cierre de la conexion
            }
        }
        /// <summary>
        /// matricula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public bool ExisteMatricula(string matricula)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM escolar.estudiantes WHERE matricula =@Matricula";
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", matricula);
                //conexion a bd
                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramMatricula);
                int cantidad = (int)Convert.ToUInt64(resultado);
                bool existe = cantidad > 0;
                return existe;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verififcar la existencia de la matrciula{matricula}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
        /// <summary>
        /// curp
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public bool ExisteCurp(string curp)
        {
            try
            {
                string query= "SELECT COUNT(*) FROM seguridad.personas WHERE curp = @Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", curp);
                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramCurp);
                int count = Convert.ToInt32(resultado);
                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"error al verificar la existemcia del CURP:{curp}");
                return false;    
            }
            finally
            {
                _dbAccess.Disconnect(); 
            }
        }
        public int InsertarEstudiante(Estudiante estudiante)
        {

            try
            {
                //insetar persona
                int idPersona = _personasData.InsertarPersona(estudiante.DatosPersonales);
                if (idPersona <= 0)
                {
                    _logger.Error($"no se pudo insetar la persona{estudiante.Matricula}");

                    return -1;
                }
                //actualizar el id persona el objeto estudiante
                estudiante.IdPersona= idPersona;
                //insetar estudiante
                string query = @"INSERT INTO escolar.estudiantes 
(id_persona,matricula,semestre,fecha_alta,estatus)
VALUES (@IdPersona,@Matricula,@Semestre,@FechaAlta,@Estatus)
RETURNING id";
               
                //crear parametros
                NpgsqlParameter paramIdPersona =_dbAccess.CreateParameter("@IdPersona",estudiante.IdPersona);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);
                //conexion a bd
                _dbAccess.Connect();
                //ejecuta la insercion y obtiene le id generado
                object? resultado=_dbAccess.ExecuteScalar(query,paramIdPersona,paramMatricula,paramSemestre,paramFechaAlta,paramEstatus);
                //convierte el resultado a entero
                int idestudiante_generado=Convert.ToInt32(resultado);
                _logger.Info($"estudiante insertado correctamente con id: {idestudiante_generado}");
                return idestudiante_generado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar un estudiante{estudiante.Matricula}");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
        public Estudiante? ObtenerEstudiantePorId(int id)
        {
            try
            {
                string query = @"
                    SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
                           e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona
                    FROM escolar.estudiantes e
                    INNER JOIN seguridad.personas p ON e.id_persona = p.id
                    WHERE e.id = @Id";

                //Crea un parametro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", id);

                //Establece la conexion a la BD
                _dbAccess.Connect();

                //Ejecuta la consulta con el parametro
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontro ningun estudiante con ID: {id}");
                    return null;
                }

                //Obtiene la primera fila (deberia ser la unica)
                DataRow row = resultado.Rows[0];

                //Crea el objeto persona
                Persona persona = new Persona(
                        Convert.ToInt32(row["id_persona"]),
                        row["nombre_completo"].ToString() ?? "",
                        row["correo"].ToString() ?? "",
                        row["telefono"].ToString() ?? "",
                        row["curp"].ToString() ?? "",
                        row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                        Convert.ToBoolean(row["estatus_persona"])
                 );

                //Crea el objeto estudiante
                Estudiante estudiante = new Estudiante(
                        Convert.ToInt32(row["id"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["matricula"].ToString() ?? "",
                        row["semestre"].ToString() ?? "",
                        Convert.ToDateTime(row["fecha_alta"]),
                        row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                        Convert.ToInt32(row["estatus"]),
                        row["estatus"].ToString() ?? "Desconocido",
                        persona
                 );
                return estudiante;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el estudiante con ID {id}");
                return null;
            }
            finally
            {
                //Asegura que se cierre la conexion
                _dbAccess.Disconnect();
            }
        }
        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                _logger.Debug($"actualizando estudiante con ID{estudiante.Id} y persona con id: {estudiante.IdPersona}");
                bool actualizacionPersonaExitosa = _personasData.ActualizarPersona(estudiante.DatosPersonales);
                if( !actualizacionPersonaExitosa)
                {
                    _logger.Warn($"no se pudo actualizar la persona con ID{estudiante.IdPersona}");
                    return false;
                }

                /*
                string queryEstudiante =@"
UPDATE escolar.estudiantes
SET matricula = @Matricula,
    semestre = @Semestre,
    fecha_alta = @fecha_alta,
    estatus = @Estatus,
    fecha_baja = @fecha_baja
WHERE id = @IdEstudiante";


                // Conexión a la base de datos
                _dbAccess.Connect();
                NpgsqlParameter paramIdEstudiante = _dbAccess.CreateParameter("IdEstudiante", estudiante.Id);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("fecha_alta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("Estatus", estudiante.Estatus);
                NpgsqlParameter paramFechaBaja = _dbAccess.CreateParameter("fecha_baja",
                    estudiante.FechaBaja.HasValue ? (object)estudiante.FechaBaja.Value : DBNull.Value);*/

                 string queryEstudiante = @"
                     UPDATE escolar.estudiantes
                     SET matricula = @Matricula,
                     semestre = @Semestre,
                     fecha_alta = @fecha_alta,
                     estatus = @Estatus,
                     fecha_baja = @fecha_baja
                     WHERE id = @IdEstudiante";

                 //Establece la conexion a la BD
                 _dbAccess.Connect();

                 //Crea los parametros
                 NpgsqlParameter paramIdEstudiante = _dbAccess.CreateParameter("@IdEstudiante", estudiante.Id);
                 NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                 NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                 NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@fecha_alta", estudiante.FechaAlta);
                 NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);
                 NpgsqlParameter paramFechaBaja = _dbAccess.CreateParameter("@fecha_baja",
                     estudiante.FechaBaja.HasValue ? (object)estudiante.FechaBaja.Value : DBNull.Value);

                //Ejecuta la actualizacion 
               // int filasAfectadasEstudiante = _dbAccess.ExecuteNonQuery(queryEstudiante, paramIdEstudiante, paramMatricula, paramSemestre,paramEstatus, paramFechaBaja);
                int filasAfectadasEstudiante = _dbAccess.ExecuteNonQuery(
    queryEstudiante,
    paramIdEstudiante,
    paramMatricula,
    paramSemestre,
    paramFechaAlta,      // ¡Estaba faltando esto!
    paramEstatus,
    paramFechaBaja
);

                bool exito = filasAfectadasEstudiante > 0;
                if (!exito)
                {
                    _logger.Warn($"No se pudo actualizar el estudiante con ID {estudiante.Id}. No se encontro el registro");
                }
                else
                {
                    _logger.Warn($"Estudiante con ID {estudiante.Id} actualizado correctamente");
                }
                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error al actualizar el estudiante con ID {estudiante.Id}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
}
