using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frClientes : Form
    {
        CNCliente cNCliente = new CNCliente();
        public frClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Value = 0;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            picFoto.Image = null;
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = string.Empty;
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                picFoto.Load(ofdFoto.FileName);
            }
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            bool resultado;
            CECliente cECliente = new CECliente();
            cECliente.Id = (int)txtId.Value;
            cECliente.Nombre = txtNombre.Text;
            cECliente.Apellido = txtApellido.Text;
            cECliente.Foto = picFoto.ImageLocation;

            resultado = cNCliente.ValidaddorDatos(cECliente);

            if (resultado == false)
            {
                return;
            }

            if (cECliente.Id == 0)
            {
                cNCliente.CrearCliente(cECliente);
            }

            else
            {
                cNCliente.Editar_datos(cECliente);
            }
            cargar_datos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cNCliente.pruebaMySql();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }

        private void cargar_datos()
        {
            //Los datos de la tabla será igual a lo que se obtenga de la base de datos
            gridDatos.DataSource = cNCliente.ObterDatos().Tables["tbl"];
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nuestro elemento de la tabla = al valor de la fila actual y la columna entre comillas
            txtId.Value = (int)gridDatos.CurrentRow.Cells["Id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["Apellido"].Value.ToString();
            //Aquí se pasa como argumento  la fila actual y la columna entre comillas
            picFoto.Load(gridDatos.CurrentRow.Cells["Foto"].Value.ToString());
        }
    }
}