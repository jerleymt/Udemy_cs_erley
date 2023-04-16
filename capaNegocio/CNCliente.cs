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

        public void CrearCliente(CECliente cE)
        {
            cDCliente.Crear(cE);
        }

        public DataSet ObterDatos( )
        {
            return cDCliente.Listar( );
        }
    }
}