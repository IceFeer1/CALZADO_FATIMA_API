namespace WinFormsApp1
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        // Variable para rastrear qué formulario está abierto
        private Form formularioActivo = null;

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Si ya hay uno abierto, cerrarlo para liberar memoria
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = formularioHijo;

            // Configurar el formulario hijo para que se comporte como un control
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill; // Que llene todo el espacio blanco

            // Asumiendo que tu panel blanco se llama "panelEscritorio"
            // Si tiene otro nombre, cámbialo aquí
            panelEscritorio.Controls.Add(formularioHijo);
            panelEscritorio.Tag = formularioHijo;

            // Traer al frente y mostrar
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonClientes_Click(object sender, EventArgs e)
        {
            // Llamamos al método que creamos arriba pasándole una nueva instancia de FrmClientes
            AbrirFormularioHijo(new FrmClientes());
        }

        private void iconButtonProductos_Click(object sender, EventArgs e)
        {
            // Llamamos al método que creamos arriba pasándole una nueva instancia de FrmClientes
            AbrirFormularioHijo(new FrmProductos());
        }

        private void iconButtonVentas_Click(object sender, EventArgs e)
        {
            // Llamamos al método que creamos arriba pasándole una nueva instancia de FrmClientes
            AbrirFormularioHijo(new FrmVentas());

        }

        private void iconButtonDetalleVenta_Click(object sender, EventArgs e)
        {
            // Llamamos al método que creamos arriba pasándole una nueva instancia de FrmClientes
            AbrirFormularioHijo(new FrmDetalleVenta());

        }

        private void iconButtonPedidos_Click(object sender, EventArgs e)
        {
            // Llamamos al método que creamos arriba pasándole una nueva instancia de FrmClientes
            AbrirFormularioHijo(new FrmPedidos());
        }

        private void iconButtonTipoPedido_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmTipoPedido());
        }

        private void iconButtonEstadoPedido_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmEstadoPedido());
        }

        private void iconButtonProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmProveedores());
        }

        private void iconButtonMantenimientos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmMantenimientos());
        }

        private void iconButtonRecibe_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRecibe());
        }

        private void iconButtonSuministra_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmSuministra());
        }
    }
}
