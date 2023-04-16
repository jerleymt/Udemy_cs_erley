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
            cNCliente.CrearCliente(cECliente);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cNCliente.pruebaMySql();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            gridDatos.DataSource = cNCliente.ObterDatos().Tables["tbl"];
        }
    }
}