using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;
using System.Data;

namespace capaDatos
{
    // Aqui se llevan a cabo todas las conecciones con la base de datos
    public class CDCliente
    {
        string CsdenaConexcion = "Server=localhost;User=root;Password=;Port=4306;database=cursos";
        public void PruebaConexion()
        {
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);

            try
            {
                mySqlconexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse" + ex.Message);
                return;
            }
            mySqlconexion.Close();
            MessageBox.Show("Conectado");
        }

        //Este método recibe como argumento un cliente
        //Toma los atributos del cliente y los ingresa a la base de datos
        public void Crear(CECliente cE)
        {
            //Se crea una coneccion a la base de datos
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

        //Metodo del tipo "dataset" retorna la base de datos
        public DataSet Listar()//No resive parametros
        {
            //Se crea una coneccion a la base de datos
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            //Aqui se habre la base de datos
            mySqlconexion.Open();
            //pregunta que se realiza a la base de datos
            //Aqui se le esta pidiendo que seleccione todo lo que hay en la tabla cliente
            string Query = "SELECT * FROM `cliente` LIMIT 1000;";
            //Aqui se declara un adactador
            //Este adaptador es el que se conenta a la base de datos
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            //Aqui se le ingresan los argumentos al adptador
            //el query pone el comando que se usara en la base de datos
            //no se necesita implentar el comando "ExecuteNonQuery" ya que al pasas esta linea asi ya vaincluidado el resultado
            Adaptador = new MySqlDataAdapter(Query, mySqlconexion);
            //aqui se le pide que el "datset" cree una tabla con las columnas y filas necesarias
            Adaptador.Fill(dataSet, "tbl");

            //Esta instacia el data set ya tiene la informacion de la tabla en la base de datos
            //se retorna la tabla en la base de datos
            return dataSet;
        }

        public DataSet Actualizar()//No resive parametros
        {
            //Se crea una coneccion a la base de datos
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            //Aqui se habre la base de datos
            mySqlconexion.Open();
            //pregunta que se realiza a la base de datos
            //Aqui se le esta pidiendo que seleccione todo lo que hay en la tabla cliente
            string Query = "UPDATE `cliente` SET `nombre`='NOMBRE1', `apellido`='APELLIDO1', `foto`='FOTO1' WHERE  `ID`=2;";
            //Aqui se declara un adactador
            //Este adaptador es el que se conenta a la base de datos
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            //Aqui se le ingresan los argumentos al adptador
            //el query pone el comando que se usara en la base de datos
            //no se necesita implentar el comando "ExecuteNonQuery" ya que al pasas esta linea asi ya vaincluidado el resultado
            Adaptador = new MySqlDataAdapter(Query, mySqlconexion);
            //aqui se le pide que el "datset" cree una tabla con las columnas y filas necesarias
            Adaptador.Fill(dataSet, "tbl");

            //Esta instacia el data set ya tiene la informacion de la tabla en la base de datos
            //se retorna la tabla en la base de datos
            return dataSet;
        }


    }
}