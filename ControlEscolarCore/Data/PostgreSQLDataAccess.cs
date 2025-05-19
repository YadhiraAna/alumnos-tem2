using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;
using NLog;
using Npgsql;//comunica a postgree
using ControlEscolarCore.Utilities;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;

namespace ControlEscolarCore.Data
{
    //solo va a ver variables para trabajar con cosas generales
    //consultas y parametros
    /// <summary>
    /// clase que maneja el acceso  a datos postgre,incluyendo conexiones, consultas, y ejecucion de procedimientos almancenados
    /// </summary>
    public class PostgreSQLDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("alumnos_tem2.Data.PostgreeSQLDataAccess");
        //cadena de conexion desde Ap.cpnfig
        //private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        //le indiica al dataacces donde esta la cadena de conexion que esta appConfig
        private NpgsqlConnection _conecction;
        private static PostgreSQLDataAccess? _instance;
        //para crear solo una instancias y no tenerlas repertidas
        // Campo estático para almacenar la cadena de conexión
        private static string _connectionString;
        //constrauctor
        /*private PostgreSQLDataAccess()
        {
            try
            {
                _conecction = new NpgsqlConnection(_connectionString);
                _logger.Info("instancia de acceso a datos creada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar el acceso a la base dde datos");
                throw;//para informar el error, pasa el error aotro lado
            }
        }*/
        // Propiedad para establecer la cadena de conexión desde el API
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    try
                    {
                        // Intenta obtener desde ConfigurationManager (Windows Forms)
                        _connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"]?.ConnectionString;
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn(ex, "No se pudo obtener la cadena de conexión desde ConfigurationManager");
                    }
                }
                return _connectionString;
            }
            set { _connectionString = value; }
        }
        private PostgreSQLDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión no está configurada. Asegúrate de establecer PostgreSQLDataAccess.ConnectionString antes de usar la clase.");
                }

                _conecction = new NpgsqlConnection(ConnectionString);
                _logger.Info("Instancia de acceso a datos creada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar el acceso a la base de datos");
                throw;
            }
        }
        //solo tener una instancia
        public static PostgreSQLDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostgreSQLDataAccess();
            }
            return _instance;
        }
        //etablece la coneccion a la base de datos
        public bool Connect()
        {
            try
            {
                if (_conecction.State != ConnectionState.Open)
                {
                    _conecction.Open();
                    _logger.Info("Conexion a la base de datos establecida correctamente");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al conectar con la base de datos");
                throw;
            }
        }
        public bool Disconnect()
        {
            try
            {
                if (_conecction.State == ConnectionState.Open)
                {
                    _conecction.Close();
                    _logger.Info("conexion a la base de datos cerrada correctamente");
                }
                return true;
            } catch (Exception ex) {
                _logger.Error(ex, "error al cerrar la conexion");
                throw;
            }
        }
        //
        /// <summary>
        /// metodo que crea comandos , talvez de parametros , algo generico del execute reader
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>///!!!!!!!!!!
        public DataTable ExecuteQuery_Reader(string query, params NpgsqlParameter[] parameters) {
            DataTable dataTable = new DataTable();
            try
            {
                _logger.Debug($"Ejecutando cosulta:{query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    
                    //ejecutar el command
                    //reader necesita un adapter no trabaja solo ocupa el data, recibe el command para saber que va ejecutar
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        //funciona con.fill-llenar la infromacion en algo, y la coloca en datatable lo llena
                        adapter.Fill(dataTable);
                        _logger.Debug($"Consulta ejecutada exitosamente.FilasObtenidas{dataTable.Rows.Count}");//inf para el log
                    }
                }
                return dataTable;//la retorna: el conjunto de datos 
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la consulta: {query}");
                throw;
            }
        }
        private NpgsqlCommand CreateCommand(string query, params NpgsqlParameter[] parameters)
        {
            //parametros pueden ser varios
            NpgsqlCommand command = new NpgsqlCommand(query, _conecction);
            if (parameters != null) {
                command.Parameters.AddRange(parameters);
                foreach (var param in parameters)//infromacion para el log
                {
                    _logger.Trace($"Parametro: {param.ParameterName}={param.Value ?? "NULL"}");
                }
            }
            return command;
        }
    
    public int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando operacion:{query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    int result = command.ExecuteNonQuery();
                    _logger.Debug($"Operacion ejecutada exitosamente.filas afectadas");
                return result;
                }//la retorna: el conjunto de datos 
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la consulta: {query}");
                throw;
            }
        }
        public Object? ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando cosulta escalar:{query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    object? result=command.ExecuteScalar();
                    _logger.Debug($"consulta escalar ejecuta exitosamente. Id afectado: {result}");
                    return result;
                }
               }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la consulta escalar: {query}");
                throw;
            }
        }/// <summary>
        /// crea un parametro para usar en consultas
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public NpgsqlParameter CreateParameter(string name, object value)
        {
            //no eres nulo devuelve el valor si es devuelve null
            return new NpgsqlParameter(name, value?? DBNull.Value);//!
        }//valor que va ir a la base de datos--valo nulo de base de datos
    }
}
