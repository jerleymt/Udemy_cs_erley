using capaEntidad;
using System.Windows.Forms;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente cDCliente = new CDCliente();

        public bool ValidaddorDatos(CECliente cliente)
        {
            bool resultado = true;

            if (cliente.Nombre == string.Empty)
            {
                resultado = false;
                MessageBox.Show("Debe ingresar un nombre");
                return resultado;
            }

            if (cliente.Apellido == string.Empty)
            {
                resultado = false;
                MessageBox.Show("Debe ingresar un apellido");
                return resultado;
            }
 
            if (cliente.Foto == null)
            {
                resultado = false;
                MessageBox.Show("La foto es obligatoria");
                return resultado;
            }
            return resultado;
        }
        public void pruebaMySql()
        {
            cDCliente.PruebaConexion();
        }
        //Este método crea el cliente a partir del método crear de la clase capa datos
        //resive como argumento un cliente
        public void CrearCliente(CECliente cE)
        {
            cDCliente.Crear(cE);
        }

        //Este método obtiene la base de datos de del método en la clase capa datos
        //retorna lo que hay en la base de datos
        public DataSet ObterDatos( )
        {
            return cDCliente.Listar( );
        }
        public DataSet Actualizar_datos(CECliente cECliente)
        {
            return cDCliente.Actualizar();
        }
    }
}