/*
Autor: Alejandro Villarreal

LMAD

PARA EL PROYECTO ES OBLIGATORIO EL USO DE ESTA CLASE, 
EN EL SENTIDO DE QUE LOS DATOS DE CONEXION AL SERVIDOR ESTAN DEFINIDOS EN EL App.Config
Y NO TENER ESOS DATOS EN CODIGO DURO DEL PROYECTO.

NO SE PERMITE HARDCODE.

LOS MÉTODOS QUE SE DEFINEN EN ESTA CLASE SON EJEMPLOS, PARA QUE SE BASEN Y USTEDES HAGAN LOS SUYOS PROPIOS
Y DEFINAN Y PROGRAMEN TODOS LOS MÉTODOS QUE SEAN NECESARIOS PARA SU PROYECTO.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using HS_APP;
using Proyecto_MAD;


/*
Se tiene que cambiar el namespace para el que usen en su proyecto
*/
namespace WindowsFormsApplication1
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();

        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

        private static void conectar()
        {
            string cnn = ConfigurationManager.ConnectionStrings["SQLCONEXION"].ToString();
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }
        private static void desconectar()
        {
            _conexion.Close();
        }

        public DataTable Get_Paises()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10);
                parametro1.Value = "LISTPAISES";


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_EstadosPorPais(int paisID)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 20).Value = "LISTESTADOSXPAIS";
                var parametro2 = _comandosql.Parameters.Add("@PaisID", SqlDbType.Int).Value = paisID;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        
        public DataTable Get_CiudadesPorEstado(int estadoID)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 20).Value = "LISTCIUDADXESTADO";
                var parametro2 = _comandosql.Parameters.Add("@EstadoID", SqlDbType.Int).Value = estadoID;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_CiudadesPorPais(int paisID)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 20).Value = "LISTCIUDADXPAIS";
                var parametro2 = _comandosql.Parameters.Add("@PaisID", SqlDbType.Int).Value = paisID;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void CrearPais(string Pais)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "CREARPAIS";
                _comandosql.Parameters.Add("@Pais", SqlDbType.NVarChar, 50).Value = Pais;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar pais: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void BorrarPais(int PaisID)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "DELETEPAIS";
                _comandosql.Parameters.Add("@PaisID", SqlDbType.Int).Value = PaisID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar pais: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void ModificarPais(int PaisID, string Pais)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "ACTPAIS";
                _comandosql.Parameters.Add("@Pais", SqlDbType.NVarChar, 50).Value = Pais;
                _comandosql.Parameters.Add("@PaisID", SqlDbType.Int).Value = PaisID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar pais: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CrearEstado(int PaisID, string Estado)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 15).Value = "CREARESTADO";
                _comandosql.Parameters.Add("@PaisID", SqlDbType.Int).Value = PaisID;
                _comandosql.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = Estado;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar estado: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void BorrarEstado(int EstadoID)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 15).Value = "DELETEESTADO";
                _comandosql.Parameters.Add("@EstadoID", SqlDbType.Int).Value = EstadoID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar estado: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void ModificarEstado(int EstadoID, string Estado)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 15).Value = "ACTESTADO";
                _comandosql.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = Estado;
                _comandosql.Parameters.Add("@EstadoID", SqlDbType.Int).Value = EstadoID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar estado: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CrearCiudad(int EstadoID, string Ciudad)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 15).Value = "CREARCIUDAD";
                _comandosql.Parameters.Add("@EstadoID", SqlDbType.Int).Value = EstadoID;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 50).Value = Ciudad;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar ciudad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void BorrarCiudad(int CiudadID)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 15).Value = "DELETECIUDAD";
                _comandosql.Parameters.Add("@CiudadID", SqlDbType.Int).Value = CiudadID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar ciudad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void ModificarCiudad(int CiudadID, string Ciudad)
        {
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 15).Value = "ACTCIUDAD";
                _comandosql.Parameters.Add("@CiudadID", SqlDbType.Int).Value = CiudadID;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 50).Value = Ciudad;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar ciudad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Get_Hoteles()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Ubicaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15);
                parametro1.Value = "HOTELESLIST";


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /*-------------------------------------------USUARIO-------------------------------------------*/
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable Get_Usuarios()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10);
                parametro1.Value = "CARGAR";


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool CambiarEstado(int IdUs)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                var parametro = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10);
                parametro.Value = "ESTADO";
                var parametro1 = _comandosql.Parameters.Add("@UsuarioID", SqlDbType.Int);
                parametro1.Value = IdUs;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if (_tabla.Rows.Count > 0)
                {
                    isValid = true;
                }

            }
            catch (SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        }

        public bool IniciarSesion(string us, string psm, string tpus)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                var parametro = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10);
                parametro.Value = "LOGIN";
                var parametro1 = _comandosql.Parameters.Add("@Correo", SqlDbType.Char, 20);
                parametro1.Value = us;
                var parametro2 = _comandosql.Parameters.Add("@PasswordAct", SqlDbType.Char, 20);
                parametro2.Value = psm;
                var parametro3 = _comandosql.Parameters.Add("@TipoUsuario", SqlDbType.Char, 15);
                parametro3.Value = tpus;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if (_tabla.Rows.Count > 0)
                {
                    isValid = true;
                }

            }
            catch (SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        }

        public List<EnlaceUsuarios> BuscarID()
        {
            var listaUsuarios = new List<EnlaceUsuarios>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARUSER";

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaUsuarios.Add(new EnlaceUsuarios
                    {
                        UsuarioID = Convert.ToInt32(row["UsuarioID"]),
                        Correo = row["Correo"].ToString(),
                        NumeroNomina = row["NumeroNomina"].ToString(),
                        Estado = Convert.ToBoolean(row["Estado"])
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaUsuarios;
        }

        public void CrearUsuario(EnlaceUsuarios user)
        {
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "INSERTAR";
                _comandosql.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = user.UsuarioID;
                _comandosql.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = user.Nombre;
                _comandosql.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 50).Value = user.Apellidos;
                _comandosql.Parameters.Add("@Correo", SqlDbType.NVarChar, 50).Value = user.Correo;
                _comandosql.Parameters.Add("@PasswordAct", SqlDbType.NVarChar, 50).Value = user.PasswordAct;
                _comandosql.Parameters.Add("@NumeroNomina", SqlDbType.VarChar, 20).Value = user.NumeroNomina;
                _comandosql.Parameters.Add("@TipoUsuario", SqlDbType.VarChar, 15).Value = user.TipoUsuario;
                _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = user.FechaNacimiento;
                _comandosql.Parameters.Add("@UsuarioRegistrador", SqlDbType.Int).Value = user.UsuarioRegistrador;
                _comandosql.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = user.Celular;
                _comandosql.Parameters.Add("@TelefonoCasa", SqlDbType.VarChar, 15).Value = user.TelefonoCasa;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void ActualizarUsuario(EnlaceUsuarios usuario)
        {
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTUALIZA";
                comando.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuario.UsuarioID;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 50).Value = usuario.Correo;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = usuario.Nombre;
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 50).Value = usuario.Apellidos;
                comando.Parameters.Add("@NumeroNomina", SqlDbType.VarChar, 20).Value = usuario.NumeroNomina;
                comando.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = usuario.Celular;
                comando.Parameters.Add("@TelefonoCasa", SqlDbType.VarChar, 15).Value = string.IsNullOrWhiteSpace(usuario.TelefonoCasa) ? (object)DBNull.Value : usuario.TelefonoCasa;
                comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = usuario.FechaNacimiento;

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void ActualizaHistorialPasswords(EnlaceUsuarios usuario)
        {
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "NEWPASSW";
                comando.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuario.UsuarioID;
                comando.Parameters.Add("@PasswordAct", SqlDbType.NVarChar, 50).Value = usuario.PasswordAct;
                comando.Parameters.Add("@PasswordAnt1", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(usuario.PasswordAnt1) ? (object)DBNull.Value : usuario.PasswordAnt1;
                comando.Parameters.Add("@PasswordAnt2", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(usuario.PasswordAnt2) ? (object)DBNull.Value : usuario.PasswordAnt2;

                comando.ExecuteNonQuery();
                MessageBox.Show("Contraseña actualizado correctamente.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        /*-------------------------------------------CLIENTE-------------------------------------------*/
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable Get_Clientes()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "spGestionClientes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10);
                parametro1.Value = "CARGAR";


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void CrearCliente(EnlaceClientes Client)
        {
            try
            {
                conectar();
                string qry = "spGestionClientes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "INSERTAR";
                _comandosql.Parameters.Add("@ClienteID", SqlDbType.Int).Value = Client.ClienteID;
                _comandosql.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = Client.Nombre;
                _comandosql.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 50).Value = Client.Apellidos;
                _comandosql.Parameters.Add("@RFC", SqlDbType.NVarChar, 50).Value = Client.RFC;
                _comandosql.Parameters.Add("@Correo", SqlDbType.NVarChar, 50).Value = Client.Correo;
                _comandosql.Parameters.Add("@EstadoCivil", SqlDbType.NVarChar, 20).Value = Client.EstadoCivil;
                _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 15).Value = Client.FechaNacimiento;
                _comandosql.Parameters.Add("@UsuarioModificador", SqlDbType.Int).Value = Client.UsuarioModificador;
                _comandosql.Parameters.Add("@Pais", SqlDbType.NVarChar, 20).Value = Client.Pais;
                _comandosql.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = Client.Estado;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 20).Value = Client.Ciudad;
                _comandosql.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = Client.Celular;
                _comandosql.Parameters.Add("@TelefonoCasa", SqlDbType.VarChar, 15).Value = string.IsNullOrWhiteSpace(Client.TelefonoCasa) ? (object)DBNull.Value : Client.TelefonoCasa;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar cliente: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void ActualizaCliente(EnlaceClientes Client)
        {
            try
            {
                conectar();
                string qry = "spGestionClientes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "ACTUALIZA";
                _comandosql.Parameters.Add("@ClienteID", SqlDbType.Int).Value = Client.ClienteID;
                _comandosql.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = Client.Nombre;
                _comandosql.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 50).Value = Client.Apellidos;
                _comandosql.Parameters.Add("@RFC", SqlDbType.NVarChar, 50).Value = Client.RFC;
                _comandosql.Parameters.Add("@Correo", SqlDbType.NVarChar, 50).Value = Client.Correo;
                _comandosql.Parameters.Add("@EstadoCivil", SqlDbType.NVarChar, 20).Value = Client.EstadoCivil;
                _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 15).Value = Client.FechaNacimiento;
                _comandosql.Parameters.Add("@UsuarioModificador", SqlDbType.Int).Value = Client.UsuarioModificador;
                _comandosql.Parameters.Add("@Pais", SqlDbType.NVarChar, 15).Value = Client.Pais;
                _comandosql.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = Client.Estado;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 20).Value = Client.Ciudad;
                _comandosql.Parameters.Add("@Celular", SqlDbType.VarChar, 20).Value = Client.Celular;
                _comandosql.Parameters.Add("@TelefonoCasa", SqlDbType.VarChar, 15).Value = Client.TelefonoCasa;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar cliente: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public List<EnlaceClientes> BuscarCliente()
        {
            var listaClientes = new List<EnlaceClientes>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "spGestionClientes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARCLIENTE";

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaClientes.Add(new EnlaceClientes
                    {
                        ClienteID = Convert.ToInt32(row["ClienteID"]),
                        Correo = row["Correo"].ToString(),
                        RFC = row["RFC"].ToString()
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaClientes;
        }

        public DataTable Buscar_Clientes(string filtro, string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "spGestionClientes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10).Value = "BUSCAR";
                _comandosql.Parameters.Add("@Filtro", SqlDbType.VarChar, 20).Value = filtro;

                switch (filtro.ToUpper())
                {
                    case "TODOS":
                        break;
                    case "RFC":
                        _comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 20).Value = valor;
                        break;
                    case "CORREO":
                        _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = valor;
                        break;
                    case "APELLIDOS":
                        _comandosql.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = valor;
                        break;
                }

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        /*-------------------------------------------HOTELES-------------------------------------------*/
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable CargarHotel(string filtro, string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 10).Value = "BUSCAR";
                _comandosql.Parameters.Add("@Filtro", SqlDbType.VarChar, 20).Value = filtro;

                switch (filtro.ToUpper())
                {
                    case "TODOS":
                        break;
                    case "PAIS":
                        _comandosql.Parameters.Add("@Pais", SqlDbType.VarChar, 20).Value = valor;
                        break;
                    case "NOMBRE":
                        _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = valor;
                        break;
                    case "CIUDAD":
                        _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 20).Value = valor;
                        break;
                }

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void CrearHotel(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "INSERTAR";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = Hotel.HotelID;
                _comandosql.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = Hotel.Nombre;
                _comandosql.Parameters.Add("@Domicilio", SqlDbType.NVarChar, 50).Value = Hotel.Domicilio;
                _comandosql.Parameters.Add("@NumPisos", SqlDbType.Int).Value = Hotel.NumPisos;
                _comandosql.Parameters.Add("@UsuarioRegistrador", SqlDbType.Int).Value = Hotel.UsuarioRegistrador;
                _comandosql.Parameters.Add("@FechaInicioOperaciones", SqlDbType.Date, 15).Value = Hotel.FechaInicioOperaciones;
                _comandosql.Parameters.Add("@Pais", SqlDbType.NVarChar, 20).Value = Hotel.Pais;
                _comandosql.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = Hotel.Estado;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 20).Value = Hotel.Ciudad;

                _comandosql.ExecuteNonQuery();

                MessageBox.Show("Hotel creado correctamente.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public List<EnlaceHoteles> BuscarHotel()
        {
            var listaServicios = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARHOTEL";

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaServicios.Add(new EnlaceHoteles
                    {
                        HotelID = Convert.ToInt32(row["HotelID"]),
                        Nombre = row["Nombre"].ToString(),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaServicios;
        }

        public void ActualizaHotel(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTHOTEL";
                comando.Parameters.Add("@HotelID", SqlDbType.Int).Value = Hotel.HotelID;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = Hotel.Nombre;
                comando.Parameters.Add("@Domicilio", SqlDbType.NVarChar, 50).Value = Hotel.Domicilio;
                comando.Parameters.Add("@FechaInicioOperaciones", SqlDbType.Date, 15).Value = Hotel.FechaInicioOperaciones;
                comando.Parameters.Add("@NumPisos", SqlDbType.Int).Value = Hotel.NumPisos;
                comando.Parameters.Add("@Pais", SqlDbType.NVarChar, 20).Value = Hotel.Pais;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = Hotel.Estado;
                comando.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 20).Value = Hotel.Ciudad;

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CargarCaracteristicas(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "INSCARACHOTEL";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = Hotel.HotelID;
                _comandosql.Parameters.Add("@Caracteristicas", SqlDbType.NVarChar, -1).Value = Hotel.Caracteristicas;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void EliminarCaaracteristica(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTCARACT";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = Hotel.HotelID;
                _comandosql.Parameters.Add("@Caracteristicas", SqlDbType.NVarChar, -1).Value = Hotel.Caracteristicas;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public List<EnlaceHoteles> CargarCaractHotel(int IdHotel)
        {
            var listaHoteles = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 20).Value = "CARGARCARACHOTEL";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Char, 15).Value = IdHotel;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaHoteles.Add(new EnlaceHoteles
                    {
                        HotelID = Convert.ToInt32(row["HotelID"]),
                        Caracteristicas = row["Caracteristicas"].ToString()
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaHoteles;
        }

        public void CrearServicios(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "INSSERVICIO";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = Hotel.HotelID;
                _comandosql.Parameters.Add("@NombreServicio", SqlDbType.NVarChar, 100).Value = Hotel.NombreServicio;

                var paramPrecio = _comandosql.Parameters.Add("@PrecioServicio", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Hotel.PrecioServicio;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Get_Servicios(int IDhotel)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "CARGARSERVICIOS";
                var parametro2 = _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = IDhotel;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public List<EnlaceHoteles> BuscarServicio(int IdHotel)
        {
            var listaServicios = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARSERV";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = IdHotel;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaServicios.Add(new EnlaceHoteles
                    {
                        ServicioID = Convert.ToInt32(row["ServicioID"]),
                        HotelID = Convert.ToInt32(row["HotelID"]),
                        NombreServicio = row["Nombre"].ToString(),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaServicios;
        }

        public void ActualizaServicios(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTSERVICIO";
                comando.Parameters.Add("@ServicioID", SqlDbType.Int).Value = Hotel.ServicioID;
                comando.Parameters.Add("@NombreServicio", SqlDbType.NVarChar, 100).Value = Hotel.NombreServicio;

                var paramPrecio = comando.Parameters.Add("@PrecioServicio", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Hotel.PrecioServicio;

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el servicio: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void BorrarServicio(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "DELETESERV";
                _comandosql.Parameters.Add("@ServicioID", SqlDbType.Int).Value = Hotel.ServicioID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al borrar servicio: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CrearTipoHabitacion(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "INSERTTH";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = Hotel.HotelID;
                _comandosql.Parameters.Add("@CantPersonas", SqlDbType.Int).Value = Hotel.CantPersonas;
                _comandosql.Parameters.Add("@UsuarioRegistrador", SqlDbType.Int).Value = Hotel.UsuarioRegistrador;
                _comandosql.Parameters.Add("@Nivel", SqlDbType.NVarChar, 100).Value = Hotel.Nivel;

                var paramPrecio = _comandosql.Parameters.Add("@PrecioNoche", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Hotel.PrecioNoche;

                _comandosql.ExecuteNonQuery();

                MessageBox.Show("Tipo de habitación creado correctamente.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Get_TipoHabitaciones(int HotelID)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15);
                parametro1.Value = "BUSCARTIPHAB";
                var parametro2 = _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = HotelID;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);


            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public List<EnlaceHoteles> BuscarTipoHabitacion(int IdHotel)
        {
            var listaServicios = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARTH";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = IdHotel;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaServicios.Add(new EnlaceHoteles
                    {
                        TipoHabID = Convert.ToInt32(row["TipoHabID"]),
                        Nivel = row["Nivel"].ToString(),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaServicios;
        }

        public void ActualizaTipoHabitacion(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTUTH";
                comando.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = Hotel.TipoHabID;
                comando.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = Hotel.Nivel;
                comando.Parameters.Add("@CantPersonas", SqlDbType.Int).Value = Hotel.CantPersonas;
                var paramPrecio = comando.Parameters.Add("@PrecioNoche", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Hotel.PrecioNoche;

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void crearCaracteristicasTH(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "INSCARACTIPHAB";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = Hotel.TipoHabID;
                _comandosql.Parameters.Add("@CaractTipHab", SqlDbType.NVarChar, -1).Value = Hotel.CaractTipHab;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void EliminarCaracteristicaTipHab(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTCARACTTH";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = Hotel.TipoHabID;
                _comandosql.Parameters.Add("@CaractTipHab", SqlDbType.NVarChar, -1).Value = Hotel.CaractTipHab;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public List<EnlaceHoteles> CargarCaractTipoHab(int IdTipHab)
        {
            var listaHoteles = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 20).Value = "CARGARCARACTIPHAB";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Char, 15).Value = IdTipHab;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaHoteles.Add(new EnlaceHoteles
                    {
                        TipoHabID = Convert.ToInt32(row["TipoHabID"]),
                        CaractTipHab = row["Caracteristicas"].ToString()
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaHoteles;
        }

        public void CrearAmenidades(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "INSAMENIDAD";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = Hotel.TipoHabID;
                _comandosql.Parameters.Add("@NombreAmenidad", SqlDbType.NVarChar, 100).Value = Hotel.NombreAmenidad;

                var paramPrecio = _comandosql.Parameters.Add("@PrecioAmenidad", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Hotel.PrecioAmenidad;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Get_Amenidades(int IDAmenidad)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "CARGARAMENIDADES";
                var parametro2 = _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = IDAmenidad;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public List<EnlaceHoteles> BuscarAmenidad(int IdAmenidad)
        {
            var listaServicios = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARAMEN";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = IdAmenidad;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaServicios.Add(new EnlaceHoteles
                    {
                        AmenidadID= Convert.ToInt32(row["AmenidadID"]),
                        TipoHabID = Convert.ToInt32(row["TipoHabitacion"]),
                        NombreAmenidad= row["Nombre"].ToString(),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaServicios;
        }

        public void ActualizaAmenidades(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTAMENIDAD";
                comando.Parameters.Add("@AmenidadID", SqlDbType.Int).Value = Hotel.AmenidadID;
                comando.Parameters.Add("@NombreAmenidad", SqlDbType.NVarChar, 100).Value = Hotel.NombreAmenidad;

                var paramPrecio = comando.Parameters.Add("@PrecioAmenidad", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Hotel.PrecioAmenidad;

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void BorrarAmenidad(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "DELETEAMEN";
                _comandosql.Parameters.Add("@AmenidadID", SqlDbType.Int).Value = Hotel.AmenidadID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al borrar amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CrearHabitaciones(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "INSHABITACION";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = Hotel.TipoHabID;
                _comandosql.Parameters.Add("@numeroHabitacion", SqlDbType.NVarChar, 100).Value = Hotel.numeroHabitacion;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar habitación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Get_Habitaciones(int IDHabitacion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "CARGARHABITACION";
                var parametro2 = _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = IDHabitacion;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public List<EnlaceHoteles> BuscarHabitacion(int IDTipHab)
        {
            var listaServicios = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARHABIT";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = IDTipHab;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaServicios.Add(new EnlaceHoteles
                    {
                        HabitacionID = Convert.ToInt32(row["HabitacionID"]),
                        numeroHabitacion = row["Numero"].ToString(),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaServicios;
        }

        public void ActualizaHabitacion(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                SqlCommand comando = new SqlCommand(qry, _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 20).Value = "ACTHABIT";
                comando.Parameters.Add("@HabitacionID", SqlDbType.Int).Value = Hotel.HabitacionID;
                comando.Parameters.Add("@numeroHabitacion", SqlDbType.NVarChar, 100).Value = Hotel.numeroHabitacion;

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar habitación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void BorrarHabitacion(EnlaceHoteles Hotel)
        {
            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "DELETEHABI";
                _comandosql.Parameters.Add("@HabitacionID", SqlDbType.Int).Value = Hotel.HabitacionID;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        /*----------------------------------------RESERVACIONES----------------------------------------*/
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public List<EnlaceHoteles> BuscarTipoHabitacionHotel(int IdHotel)
        {
            var listaTipHab = new List<EnlaceHoteles>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARTIPHAB";
                _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = IdHotel;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    listaTipHab.Add(new EnlaceHoteles
                    {
                        TipoHabID = Convert.ToInt32(row["TipoHabID"]),
                        Nivel = row["Nivel"].ToString(),
                        PrecioNoche = Convert.ToDecimal(row["PrecioNocheDecimal"]),
                        PrecioFormateado = row["Precio Noche por persona"].ToString(),
                        CantPersonas = Convert.ToInt32(row["Personas maximas permitidas"]),
                        CaractTipHab = row["Caracteristicas"].ToString(),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return listaTipHab;
        }

        public List<string> BuscarHabitacionesPorTipo(int tipoHabID)
        {
            var numerosHabitacion = new List<string>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARHABIT";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = tipoHabID;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    numerosHabitacion.Add(row["Numero"].ToString());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return numerosHabitacion;
        }

        public List<string> BuscarHabitacionesId(int tipoHabID)
        {
            var IdHabitaciones = new List<string>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARHABIT";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = tipoHabID;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    IdHabitaciones.Add(row["HabitacionID"].ToString());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return IdHabitaciones;
        }

        public void CrearReservacion(EnlaceReservaciones Reserva)
        {
            try
            {
                conectar();
                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "CREAR";
                _comandosql.Parameters.Add("@ReservacionID", SqlDbType.UniqueIdentifier).Value = Reserva.ReservacionID;
                _comandosql.Parameters.Add("@FechaCheckIn", SqlDbType.Date).Value = Reserva.FechaCheckIn;
                _comandosql.Parameters.Add("@FechaCheckOut", SqlDbType.Date).Value = Reserva.FechaCheckOut;
                _comandosql.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = Reserva.UsuarioRegistro;
                _comandosql.Parameters.Add("@CantidadPersonas", SqlDbType.Int).Value = Reserva.CantidadPersonas;
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = Reserva.TipoHabID;
                _comandosql.Parameters.Add("@HabitacionID", SqlDbType.Int).Value = Reserva.HabitacionID;
                _comandosql.Parameters.Add("@ClienteID", SqlDbType.Int).Value = Reserva.ClienteID;

                var paramAnticipo = _comandosql.Parameters.Add("@Anticipo", SqlDbType.Decimal);
                paramAnticipo.Precision = 10;
                paramAnticipo.Scale = 2;
                paramAnticipo.Value = Reserva.Anticipo;

                var paramPrecio = _comandosql.Parameters.Add("@PrecioNoche", SqlDbType.Decimal);
                paramPrecio.Precision = 10;
                paramPrecio.Scale = 2;
                paramPrecio.Value = Reserva.PrecioNoche;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al crear Reservación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public List<EnlaceReservaciones> ObtenerReservaciones(int tipoHabID)
        {
            var Reservaciones = new List<EnlaceReservaciones>();
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 16).Value = "BUSCARRESERVAS";
                _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = tipoHabID;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    Reservaciones.Add(new EnlaceReservaciones
                    {
                        TipoHabID = Convert.ToInt32(row["TipoHabID"]),
                        HabitacionID = Convert.ToInt32(row["HabitacionID"]),
                        Estatus = row["Estatus"].ToString(),
                        FechCheckIn = (DateTime)(row["FechaCheckIn"] is DBNull ? (DateTime?)null : Convert.ToDateTime(row["FechaCheckIn"])),
                        FechCheckOut = (DateTime)(row["FechaCheckOut"] is DBNull ? (DateTime?)null : Convert.ToDateTime(row["FechaCheckOut"]))
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
            }
            finally
            {
                desconectar();
            }

            return Reservaciones;
        }

        public void CancelarReservacion(string ID_Reservacion)
        {
            try
            {
                conectar();
                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "CANCELAR";
                _comandosql.Parameters.Add("@IDReservacion", SqlDbType.NVarChar).Value = ID_Reservacion;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cancelar Reservación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Buscar_ReservacionesCancelar(string filtro, string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "FILTRARCANCEL";
                _comandosql.Parameters.Add("@Filtro", SqlDbType.VarChar, 20).Value = filtro;

                switch (filtro.ToUpper())
                {
                    case "TODOS":
                        break;
                    case "CODIGO":
                        _comandosql.Parameters.Add("@IDReservacion", SqlDbType.VarChar, 50).Value = valor;
                        break;
                }

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Buscar_ReservacionesCheck(string filtro, string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "FILTRARCHECK";
                _comandosql.Parameters.Add("@Filtro", SqlDbType.VarChar, 20).Value = filtro;

                switch (filtro.ToUpper())
                {
                    case "TODOS":
                        break;
                    case "CODIGO":
                        _comandosql.Parameters.Add("@IDReservacion", SqlDbType.VarChar, 50).Value = valor;
                        break;
                }

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void CheckIn(string ID_Reservacion)
        {
            try
            {
                conectar();
                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "CHECKIN";
                _comandosql.Parameters.Add("@IDReservacion", SqlDbType.NVarChar).Value = ID_Reservacion;

                _comandosql.ExecuteNonQuery();
                MessageBox.Show("Check-In realizado exitosamente.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al hacer Check-In: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CancelacionAutomatica()
        {
            try
            {
                conectar();
                string qry = "sp_Reservaciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "CANCELAUT";

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cancelar reservaciones ya pasadas " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        /*------------------------------------------FACTURAS-------------------------------------------*/
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable CargarServiciosCobrar(int IDhotel, int IDTipoHabit)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "spFacturas";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "CARGARSERVICIOS";
                var parametro2 = _comandosql.Parameters.Add("@HotelID", SqlDbType.Int).Value = IDhotel;
                var parametro3 = _comandosql.Parameters.Add("@TipoHabID", SqlDbType.Int).Value = IDTipoHabit;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void CrearFactura(EnlaceFactura Factura)
        {
            try
            {
                conectar();
                string qry = "spFacturas";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 10).Value = "INSERTAR";
                _comandosql.Parameters.Add("@FacturaID", SqlDbType.UniqueIdentifier).Value = Factura.FacturaID;
                _comandosql.Parameters.Add("@ReservacionID", SqlDbType.UniqueIdentifier).Value = Factura.ReservacionID;

                var paramHospedaje = _comandosql.Parameters.Add("@MontoHospedaje", SqlDbType.Decimal);
                paramHospedaje.Precision = 10;
                paramHospedaje.Scale = 2;
                paramHospedaje.Value = Factura.MontoHospedaje;

                var paramServicio = _comandosql.Parameters.Add("@MontoServicios", SqlDbType.Decimal);
                paramServicio.Precision = 10;
                paramServicio.Scale = 2;
                paramServicio.Value = Factura.MontoServicios;

                var paramTotal = _comandosql.Parameters.Add("@MontoTotal", SqlDbType.Decimal);
                paramTotal.Precision = 10;
                paramTotal.Scale = 2;
                paramTotal.Value = Factura.MontoTotal;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al crear Factura: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /*------------------------------------------REPORTES-------------------------------------------*/
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable HistorialCliente(string filtro, string valor)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "spReportes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "HISTORIAL";
                _comandosql.Parameters.Add("@Filtro", SqlDbType.VarChar, 20).Value = filtro;

                switch (filtro.ToUpper())
                {
                    case "APELLIDOS":
                        _comandosql.Parameters.Add("@ApellidosCliente", SqlDbType.VarChar, 50).Value = valor;
                        break;
                    case "NOMBRE":
                        _comandosql.Parameters.Add("@NombreCliente", SqlDbType.VarChar, 50).Value = valor;
                        break;
                }

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ReporteOcupacion(string pais, string ciudad, string Hotel, int? year)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "spReportes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "REPORTEOCUP";
                _comandosql.Parameters.Add("@Pais", SqlDbType.VarChar, 20).Value = pais;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 20).Value = ciudad;
                _comandosql.Parameters.Add("@NombreHotel", SqlDbType.VarChar, 20).Value = Hotel;
                _comandosql.Parameters.Add("@Anio", SqlDbType.Int).Value = year.HasValue ? (object)year.Value : DBNull.Value;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ReporteOcupacion2(string pais, string ciudad, string Hotel, int? year)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "spReportes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "REPORTEOCUP2";
                _comandosql.Parameters.Add("@Pais", SqlDbType.VarChar, 20).Value = pais;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 20).Value = ciudad;
                _comandosql.Parameters.Add("@NombreHotel", SqlDbType.VarChar, 20).Value = Hotel;
                _comandosql.Parameters.Add("@Anio", SqlDbType.Int).Value = year.HasValue ? (object)year.Value : DBNull.Value;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ReporteVentas(string pais, string ciudad, string Hotel, int? year)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();

                string qry = "spReportes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = "REPORTEVENTAS";
                _comandosql.Parameters.Add("@Pais", SqlDbType.VarChar, 20).Value = pais;
                _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 20).Value = ciudad;
                _comandosql.Parameters.Add("@NombreHotel", SqlDbType.VarChar, 20).Value = Hotel;
                _comandosql.Parameters.Add("@Anio", SqlDbType.Int).Value = year.HasValue ? (object)year.Value : DBNull.Value;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                string msg = "Error de base de datos:\n" + e.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }





    }

}
