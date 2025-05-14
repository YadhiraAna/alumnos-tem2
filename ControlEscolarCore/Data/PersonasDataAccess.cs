using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;
using ControlEscolarCore.Model;
using NLog;
using Npgsql;

namespace ControlEscolarCore.Data
{
    public class PersonasDataAccess
    {
        //logger para la clase
        private static readonly Logger _logger = LoggingManager.GetLogger("alumnos_tem2.Data.PersonasDataAccess");
        //instancia del acceso a datos postgree
        private readonly PostgreSQLDataAccess _dbAccess;
        //contructor
        public PersonasDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "Error al instializar PersonasDataAccess");
                throw;
            }
        }
        public int InsertarPersona(Persona persona)
        {
            try
            {
                string query = "INSERT INTO seguridad.personas (nombre_completo, correo, telefono, fecha_nacimiento, curp, estatus) " +
"VALUES (@NombreCompleto, @Correo, @Telefono, @FechaNacimiento, @Curp, @Estatus) " +
"RETURNING id";
                //crear parametros
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);
                //establecer conexion
                _dbAccess.Connect();
                //ejecutar insercion y obtiene id generado(scalar sdolo se afceta uno)
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramCorreo, paramTelefono, paramFechaNac, paramCurp, paramEstatus);
                //resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"persona insertada correctamente con ID{idGenerado}");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"error al insertar persona{persona.NombreCompleto}");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
        public bool ExisteCURP(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM seguridad.personas WHERE curp =@Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter(@"Curp", curp);
                _dbAccess.Connect();
                Object? resultado = _dbAccess.ExecuteScalar(query, paramCurp);
                int count=Convert.ToInt32(resultado);
                return count > 0;
            }
            catch(Exception e)
            {
                _logger.Error(e, $"error al verificar si existe CRUP: {curp}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                string query = "UPDATE seguridad.personas " +
                    "SET nombre_completo = @NombreCompleto, " +
                    "    correo  =@Correo, " +
                    "    telefono  =@Telefono, " +
                    "    fecha_nacimiento  =@FechaNacimiento, " +
                    "    curp  =@Curp, " +
                    "    estatus  =@Estatus " +
                    "WHERE id = @Id";

                //Crea los parametros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", persona.Id);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                //Establece la conexion a la BD
                _dbAccess.Connect();

                //Ejecuta la actualizacion 
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramCorreo, paramTelefono,
                    paramFechaNac, paramCurp, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Persona con ID {persona.Id} actualizada correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar la persona con ID {persona.Id}. No se encontro el registro");
                }
                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error al actualizar la persona con ID {persona.Id}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
}
