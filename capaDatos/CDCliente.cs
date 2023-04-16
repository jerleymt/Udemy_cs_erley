using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;
using System.Data;

namespace capaDatos
{
    public class CDCliente
    {
        //string CsdenaConexcion = "Server=localhost;User=root;Password=123456;Port=3306;database=curso_cs";
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
        public void Crear(CECliente cE)
        {
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            mySqlconexion.Open();
            string Query = "INSERT INTO `cliente` (`nombre`, `apellido`, `foto`) VALUES ('"+cE.Nombre+"', '"+cE.Apellido+"', '"+MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto)+"')";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlconexion);
            mySqlCommand.ExecuteNonQuery(); 
            mySqlconexion.Close();
            MessageBox.Show("Registro creado");
        }

        public DataSet Listar()
        {
            MySqlConnection mySqlconexion = new MySqlConnection(CsdenaConexcion);
            mySqlconexion.Open();
            string Query = "SELECT * FROM `cliente` LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlconexion);
            Adaptador.Fill(dataSet, "tbl");

            return dataSet;
        }
    }
}