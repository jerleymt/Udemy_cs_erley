using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;
using System.Data;

namespace capaDatos
{
    // Aquí se llevan a cabo todas las conexiones con la base de datos
    public class CDCliente
    {
        string CsdenaConexcion = "Server=localhost;User=root;Password=;Port=4306;database=cursos";
        //Verifica que la base de datos se abra y en caso de que no lo haga mande un aviso de error
        //esto se hace para que no se cierre el programa
        public void PruebaConexion()
        {
            //Se crea una conexión a la base de datos
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);

            try
            {
                //Se inicia la conexión a la base de dato
                mySqlconexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse" + ex.Message);
                return;
            }
            //Se cierra la conexión a la base de datos
            mySqlconexion.Close();
            MessageBox.Show("Conectado");
        }

        //Este método recibe como argumento un cliente
        //Toma los atributos del cliente y los ingresa a la base de datos
        public void Crear(CECliente cE)
        {
            //Se crea una conexión a la base de datos
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            //Se inicia la conexión a la base de datos
            mySqlconexion.Open();
            //pregunta que se realiza a la base de datos
            //Aquí se le esta pidiendo que inserte todo lo que hay en los campos especificados los atributos del clientes
            string Query = "INSERT INTO `cliente` (`nombre`, `apellido`, `foto`) VALUES ('"+cE.Nombre+"', '"+cE.Apellido+"', '"+MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto)+"')";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlconexion);
            //Aquí le estamos dando la orden de que el comando que se ingreso por medio del query
            //se ejecute en la base datos
            mySqlCommand.ExecuteNonQuery(); 
            //Se cierra la conexión a la base de datos
            mySqlconexion.Close();
            //Este mensaje se muestra cuando esto sale bien
            MessageBox.Show("Registro creado");
        }

        //Método del tipo "dataset" retorna la base de datos
        public DataSet Listar()//No recibe parámetros
        {
            //Se crea una conexión a la base de datos
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            //Aquí se abre la base de datos
            mySqlconexion.Open();
            //pregunta que se realiza a la base de datos
            //Aquí se le esta pidiendo que seleccione todo lo que hay en la tabla cliente
            string Query = "SELECT * FROM `cliente` LIMIT 1000;";
            //Aquí se declara un adaptador
            //Este adaptador es el que se conecta a la base de datos
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            //Aquí se le ingresan los argumentos al adaptador
            //el query pone el comando que se usara en la base de datos
            //no se necesita implementar el comando "ExecuteNonQuery" ya que al pasar esta línea asi ya va incluido el resultado
            Adaptador = new MySqlDataAdapter(Query, mySqlconexion);
            //Aquí se le pide que el "dataset" cree una tabla con las columnas y filas necesarias
            Adaptador.Fill(dataSet, "tbl");

            //Esta instancia el data set ya tiene la información de la tabla en la base de datos
            //se retorna la tabla en la base de datos
            return dataSet;
        }

        public void Editar(CECliente cE)
        {
            //Se crea una conexión a la base de datos
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            //Se inicia la conexión a la base de datos
            mySqlconexion.Open();
            //pregunta que se realiza a la base de datos
            //Aquí se le esta pidiendo que actualice todo lo que hay en las celdas seleccionados
            string Query = "UPDATE `cliente` SET `nombre`='" + cE.Nombre + "', `apellido`='" + cE.Apellido + "', `foto`='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "' WHERE  `id`=" + cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlconexion);
            //Aquí le estamos dando la orden de que el comando que se ingreso por medio del query
            //se ejecute en la base datos
            mySqlCommand.ExecuteNonQuery();
            //Se cierra la conexión a la base de datos
            mySqlconexion.Close();
            //Este mensaje se muestra cuando esto sale bien
            MessageBox.Show("La base de datos se ha actualizado");
        }


    }
}