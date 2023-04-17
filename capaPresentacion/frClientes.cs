using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frClientes : Form
    {
        CNCliente cNCliente = new CNCliente();
        CECliente cECliente = new CECliente();
        private DialogResult mensaje_yes_not;

        public frClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
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
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;

            mensaje_yes_not = MessageBox.Show("Desea eliminar Cliente", "Aviso importante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (mensaje_yes_not == DialogResult.Yes)
            {
                cECliente.Id = (int)txtId.Value;
                cNCliente.Borrar_datos(cECliente);
            }
            cargar_datos();
            Limpiar();
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