namespace WinFormsApp1
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panelBarraTitulo = new Panel();
            panelMenu = new Panel();
            iconButtonSuministra = new FontAwesome.Sharp.IconButton();
            iconButtonRecibe = new FontAwesome.Sharp.IconButton();
            iconButtonMantenimientos = new FontAwesome.Sharp.IconButton();
            iconButtonProveedores = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            iconButtonEstadoPedido = new FontAwesome.Sharp.IconButton();
            iconButtonTipoPedido = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            iconButtonPedidos = new FontAwesome.Sharp.IconButton();
            iconButtonDetalleVenta = new FontAwesome.Sharp.IconButton();
            iconButtonVentas = new FontAwesome.Sharp.IconButton();
            iconButtonProductos = new FontAwesome.Sharp.IconButton();
            iconButtonClientes = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            label1 = new Label();
            panelEscritorio = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelBarraTitulo
            // 
            panelBarraTitulo.BackColor = Color.Lavender;
            panelBarraTitulo.Dock = DockStyle.Top;
            panelBarraTitulo.Location = new Point(200, 0);
            panelBarraTitulo.Name = "panelBarraTitulo";
            panelBarraTitulo.Size = new Size(784, 50);
            panelBarraTitulo.TabIndex = 1;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DarkSlateBlue;
            panelMenu.Controls.Add(iconButtonSuministra);
            panelMenu.Controls.Add(iconButtonRecibe);
            panelMenu.Controls.Add(iconButtonMantenimientos);
            panelMenu.Controls.Add(iconButtonProveedores);
            panelMenu.Controls.Add(label4);
            panelMenu.Controls.Add(iconButtonEstadoPedido);
            panelMenu.Controls.Add(iconButtonTipoPedido);
            panelMenu.Controls.Add(label3);
            panelMenu.Controls.Add(iconButtonPedidos);
            panelMenu.Controls.Add(iconButtonDetalleVenta);
            panelMenu.Controls.Add(iconButtonVentas);
            panelMenu.Controls.Add(iconButtonProductos);
            panelMenu.Controls.Add(iconButtonClientes);
            panelMenu.Controls.Add(label2);
            panelMenu.Controls.Add(label1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 661);
            panelMenu.TabIndex = 0;
            panelMenu.Paint += panelMenu_Paint;
            // 
            // iconButtonSuministra
            // 
            iconButtonSuministra.BackColor = Color.Transparent;
            iconButtonSuministra.CausesValidation = false;
            iconButtonSuministra.Dock = DockStyle.Top;
            iconButtonSuministra.FlatAppearance.BorderSize = 0;
            iconButtonSuministra.FlatStyle = FlatStyle.Flat;
            iconButtonSuministra.Font = new Font("Segoe UI", 9F);
            iconButtonSuministra.ForeColor = Color.White;
            iconButtonSuministra.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleUp;
            iconButtonSuministra.IconColor = Color.White;
            iconButtonSuministra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSuministra.IconSize = 32;
            iconButtonSuministra.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSuministra.Location = new Point(0, 535);
            iconButtonSuministra.Name = "iconButtonSuministra";
            iconButtonSuministra.Padding = new Padding(10, 0, 0, 0);
            iconButtonSuministra.Size = new Size(200, 40);
            iconButtonSuministra.TabIndex = 15;
            iconButtonSuministra.Text = "Suministra";
            iconButtonSuministra.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonSuministra.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonSuministra.UseVisualStyleBackColor = false;
            iconButtonSuministra.Click += iconButtonSuministra_Click;
            // 
            // iconButtonRecibe
            // 
            iconButtonRecibe.BackColor = Color.Transparent;
            iconButtonRecibe.Dock = DockStyle.Top;
            iconButtonRecibe.FlatAppearance.BorderSize = 0;
            iconButtonRecibe.FlatStyle = FlatStyle.Flat;
            iconButtonRecibe.Flip = FontAwesome.Sharp.FlipOrientation.Vertical;
            iconButtonRecibe.Font = new Font("Segoe UI", 9F);
            iconButtonRecibe.ForeColor = Color.White;
            iconButtonRecibe.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleUp;
            iconButtonRecibe.IconColor = Color.White;
            iconButtonRecibe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonRecibe.IconSize = 32;
            iconButtonRecibe.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonRecibe.Location = new Point(0, 495);
            iconButtonRecibe.Name = "iconButtonRecibe";
            iconButtonRecibe.Padding = new Padding(10, 0, 0, 0);
            iconButtonRecibe.Size = new Size(200, 40);
            iconButtonRecibe.TabIndex = 14;
            iconButtonRecibe.Text = "Recibe";
            iconButtonRecibe.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonRecibe.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonRecibe.UseVisualStyleBackColor = false;
            iconButtonRecibe.Click += iconButtonRecibe_Click;
            // 
            // iconButtonMantenimientos
            // 
            iconButtonMantenimientos.BackColor = Color.Transparent;
            iconButtonMantenimientos.Dock = DockStyle.Top;
            iconButtonMantenimientos.FlatAppearance.BorderSize = 0;
            iconButtonMantenimientos.FlatStyle = FlatStyle.Flat;
            iconButtonMantenimientos.Font = new Font("Segoe UI", 9F);
            iconButtonMantenimientos.ForeColor = Color.White;
            iconButtonMantenimientos.IconChar = FontAwesome.Sharp.IconChar.Tools;
            iconButtonMantenimientos.IconColor = Color.White;
            iconButtonMantenimientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonMantenimientos.IconSize = 32;
            iconButtonMantenimientos.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonMantenimientos.Location = new Point(0, 455);
            iconButtonMantenimientos.Name = "iconButtonMantenimientos";
            iconButtonMantenimientos.Padding = new Padding(10, 0, 0, 0);
            iconButtonMantenimientos.Size = new Size(200, 40);
            iconButtonMantenimientos.TabIndex = 13;
            iconButtonMantenimientos.Text = "Mantenimientos";
            iconButtonMantenimientos.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonMantenimientos.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonMantenimientos.UseVisualStyleBackColor = false;
            iconButtonMantenimientos.Click += iconButtonMantenimientos_Click;
            // 
            // iconButtonProveedores
            // 
            iconButtonProveedores.BackColor = Color.Transparent;
            iconButtonProveedores.Dock = DockStyle.Top;
            iconButtonProveedores.FlatAppearance.BorderSize = 0;
            iconButtonProveedores.FlatStyle = FlatStyle.Flat;
            iconButtonProveedores.Font = new Font("Segoe UI", 9F);
            iconButtonProveedores.ForeColor = Color.White;
            iconButtonProveedores.IconChar = FontAwesome.Sharp.IconChar.Truck;
            iconButtonProveedores.IconColor = Color.White;
            iconButtonProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonProveedores.IconSize = 32;
            iconButtonProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonProveedores.Location = new Point(0, 415);
            iconButtonProveedores.Name = "iconButtonProveedores";
            iconButtonProveedores.Padding = new Padding(10, 0, 0, 0);
            iconButtonProveedores.Size = new Size(200, 40);
            iconButtonProveedores.TabIndex = 12;
            iconButtonProveedores.Text = "Proveedores";
            iconButtonProveedores.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonProveedores.UseVisualStyleBackColor = false;
            iconButtonProveedores.Click += iconButtonProveedores_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(0, 385);
            label4.Name = "label4";
            label4.Padding = new Padding(50, 0, 0, 0);
            label4.Size = new Size(200, 30);
            label4.TabIndex = 11;
            label4.Text = "Inventario";
            label4.TextAlign = ContentAlignment.BottomLeft;
            label4.Click += label4_Click;
            // 
            // iconButtonEstadoPedido
            // 
            iconButtonEstadoPedido.BackColor = Color.Transparent;
            iconButtonEstadoPedido.Dock = DockStyle.Top;
            iconButtonEstadoPedido.FlatAppearance.BorderSize = 0;
            iconButtonEstadoPedido.FlatStyle = FlatStyle.Flat;
            iconButtonEstadoPedido.Font = new Font("Segoe UI", 9F);
            iconButtonEstadoPedido.ForeColor = Color.White;
            iconButtonEstadoPedido.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButtonEstadoPedido.IconColor = Color.White;
            iconButtonEstadoPedido.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonEstadoPedido.IconSize = 32;
            iconButtonEstadoPedido.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonEstadoPedido.Location = new Point(0, 345);
            iconButtonEstadoPedido.Name = "iconButtonEstadoPedido";
            iconButtonEstadoPedido.Padding = new Padding(10, 0, 0, 0);
            iconButtonEstadoPedido.Size = new Size(200, 40);
            iconButtonEstadoPedido.TabIndex = 10;
            iconButtonEstadoPedido.Text = "Estado Pedido";
            iconButtonEstadoPedido.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonEstadoPedido.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonEstadoPedido.UseVisualStyleBackColor = false;
            iconButtonEstadoPedido.Click += iconButtonEstadoPedido_Click;
            // 
            // iconButtonTipoPedido
            // 
            iconButtonTipoPedido.BackColor = Color.Transparent;
            iconButtonTipoPedido.Dock = DockStyle.Top;
            iconButtonTipoPedido.FlatAppearance.BorderSize = 0;
            iconButtonTipoPedido.FlatStyle = FlatStyle.Flat;
            iconButtonTipoPedido.Font = new Font("Segoe UI", 9F);
            iconButtonTipoPedido.ForeColor = Color.White;
            iconButtonTipoPedido.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButtonTipoPedido.IconColor = Color.White;
            iconButtonTipoPedido.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonTipoPedido.IconSize = 32;
            iconButtonTipoPedido.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonTipoPedido.Location = new Point(0, 305);
            iconButtonTipoPedido.Name = "iconButtonTipoPedido";
            iconButtonTipoPedido.Padding = new Padding(10, 0, 0, 0);
            iconButtonTipoPedido.Size = new Size(200, 40);
            iconButtonTipoPedido.TabIndex = 9;
            iconButtonTipoPedido.Text = "Tipo Pedido";
            iconButtonTipoPedido.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonTipoPedido.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonTipoPedido.UseVisualStyleBackColor = false;
            iconButtonTipoPedido.Click += iconButtonTipoPedido_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(0, 275);
            label3.Name = "label3";
            label3.Padding = new Padding(50, 0, 0, 0);
            label3.Size = new Size(200, 30);
            label3.TabIndex = 8;
            label3.Text = "Catálogos";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // iconButtonPedidos
            // 
            iconButtonPedidos.BackColor = Color.Transparent;
            iconButtonPedidos.Dock = DockStyle.Top;
            iconButtonPedidos.FlatAppearance.BorderSize = 0;
            iconButtonPedidos.FlatStyle = FlatStyle.Flat;
            iconButtonPedidos.Font = new Font("Segoe UI", 9F);
            iconButtonPedidos.ForeColor = Color.White;
            iconButtonPedidos.IconChar = FontAwesome.Sharp.IconChar.TableList;
            iconButtonPedidos.IconColor = Color.White;
            iconButtonPedidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPedidos.IconSize = 32;
            iconButtonPedidos.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonPedidos.Location = new Point(0, 235);
            iconButtonPedidos.Name = "iconButtonPedidos";
            iconButtonPedidos.Padding = new Padding(10, 0, 0, 0);
            iconButtonPedidos.Size = new Size(200, 40);
            iconButtonPedidos.TabIndex = 7;
            iconButtonPedidos.Text = "Pedidos";
            iconButtonPedidos.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonPedidos.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonPedidos.UseVisualStyleBackColor = false;
            iconButtonPedidos.Click += iconButtonPedidos_Click;
            // 
            // iconButtonDetalleVenta
            // 
            iconButtonDetalleVenta.BackColor = Color.Transparent;
            iconButtonDetalleVenta.Dock = DockStyle.Top;
            iconButtonDetalleVenta.FlatAppearance.BorderSize = 0;
            iconButtonDetalleVenta.FlatStyle = FlatStyle.Flat;
            iconButtonDetalleVenta.Font = new Font("Segoe UI", 9F);
            iconButtonDetalleVenta.ForeColor = Color.White;
            iconButtonDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            iconButtonDetalleVenta.IconColor = Color.White;
            iconButtonDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonDetalleVenta.IconSize = 32;
            iconButtonDetalleVenta.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonDetalleVenta.Location = new Point(0, 195);
            iconButtonDetalleVenta.Name = "iconButtonDetalleVenta";
            iconButtonDetalleVenta.Padding = new Padding(10, 0, 0, 0);
            iconButtonDetalleVenta.Size = new Size(200, 40);
            iconButtonDetalleVenta.TabIndex = 6;
            iconButtonDetalleVenta.Text = "Detalle Venta";
            iconButtonDetalleVenta.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonDetalleVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonDetalleVenta.UseVisualStyleBackColor = false;
            iconButtonDetalleVenta.Click += iconButtonDetalleVenta_Click;
            // 
            // iconButtonVentas
            // 
            iconButtonVentas.BackColor = Color.Transparent;
            iconButtonVentas.Dock = DockStyle.Top;
            iconButtonVentas.FlatAppearance.BorderSize = 0;
            iconButtonVentas.FlatStyle = FlatStyle.Flat;
            iconButtonVentas.Font = new Font("Segoe UI", 9F);
            iconButtonVentas.ForeColor = Color.White;
            iconButtonVentas.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            iconButtonVentas.IconColor = Color.White;
            iconButtonVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonVentas.IconSize = 32;
            iconButtonVentas.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonVentas.Location = new Point(0, 155);
            iconButtonVentas.Name = "iconButtonVentas";
            iconButtonVentas.Padding = new Padding(10, 0, 0, 0);
            iconButtonVentas.Size = new Size(200, 40);
            iconButtonVentas.TabIndex = 5;
            iconButtonVentas.Text = "Ventas";
            iconButtonVentas.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonVentas.UseVisualStyleBackColor = false;
            iconButtonVentas.Click += iconButtonVentas_Click;
            // 
            // iconButtonProductos
            // 
            iconButtonProductos.BackColor = Color.Transparent;
            iconButtonProductos.Dock = DockStyle.Top;
            iconButtonProductos.FlatAppearance.BorderSize = 0;
            iconButtonProductos.FlatStyle = FlatStyle.Flat;
            iconButtonProductos.Font = new Font("Segoe UI", 9F);
            iconButtonProductos.ForeColor = Color.White;
            iconButtonProductos.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            iconButtonProductos.IconColor = Color.White;
            iconButtonProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonProductos.IconSize = 32;
            iconButtonProductos.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonProductos.Location = new Point(0, 115);
            iconButtonProductos.Name = "iconButtonProductos";
            iconButtonProductos.Padding = new Padding(10, 0, 0, 0);
            iconButtonProductos.Size = new Size(200, 40);
            iconButtonProductos.TabIndex = 4;
            iconButtonProductos.Text = "Productos";
            iconButtonProductos.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonProductos.UseVisualStyleBackColor = false;
            iconButtonProductos.Click += iconButtonProductos_Click;
            // 
            // iconButtonClientes
            // 
            iconButtonClientes.BackColor = Color.Transparent;
            iconButtonClientes.Dock = DockStyle.Top;
            iconButtonClientes.FlatAppearance.BorderSize = 0;
            iconButtonClientes.FlatStyle = FlatStyle.Flat;
            iconButtonClientes.Font = new Font("Segoe UI", 9F);
            iconButtonClientes.ForeColor = Color.White;
            iconButtonClientes.IconChar = FontAwesome.Sharp.IconChar.ChalkboardTeacher;
            iconButtonClientes.IconColor = Color.White;
            iconButtonClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonClientes.IconSize = 32;
            iconButtonClientes.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonClientes.Location = new Point(0, 75);
            iconButtonClientes.Name = "iconButtonClientes";
            iconButtonClientes.Padding = new Padding(10, 0, 0, 0);
            iconButtonClientes.Size = new Size(200, 40);
            iconButtonClientes.TabIndex = 1;
            iconButtonClientes.Text = "Clientes";
            iconButtonClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonClientes.UseVisualStyleBackColor = false;
            iconButtonClientes.Click += iconButtonClientes_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(0, 45);
            label2.Name = "label2";
            label2.Padding = new Padding(50, 0, 0, 0);
            label2.Size = new Size(200, 30);
            label2.TabIndex = 3;
            label2.Text = "Principal";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.Indigo;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Lucida Calligraphy", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 10, 0, 0);
            label1.Size = new Size(200, 45);
            label1.TabIndex = 2;
            label1.Text = "Calzados Fátima";
            label1.Click += label1_Click;
            // 
            // panelEscritorio
            // 
            panelEscritorio.Dock = DockStyle.Fill;
            panelEscritorio.Location = new Point(200, 50);
            panelEscritorio.Name = "panelEscritorio";
            panelEscritorio.Size = new Size(784, 611);
            panelEscritorio.TabIndex = 2;
            panelEscritorio.Paint += panelEscritorio_Paint;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 661);
            Controls.Add(panelEscritorio);
            Controls.Add(panelBarraTitulo);
            Controls.Add(panelMenu);
            Name = "FrmMenuPrincipal";
            Text = "Form1";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private Panel panelBarraTitulo;
        private Panel panelMenu;
        private Panel panelEscritorio;
        private FontAwesome.Sharp.IconButton iconButtonClientes;
        private Label label1;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButtonProductos;
        private FontAwesome.Sharp.IconButton iconButtonVentas;
        private FontAwesome.Sharp.IconButton iconButtonPedidos;
        private FontAwesome.Sharp.IconButton iconButtonDetalleVenta;
        private FontAwesome.Sharp.IconButton iconButtonProveedores;
        private Label label4;
        private FontAwesome.Sharp.IconButton iconButtonEstadoPedido;
        private FontAwesome.Sharp.IconButton iconButtonTipoPedido;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButtonSuministra;
        private FontAwesome.Sharp.IconButton iconButtonRecibe;
        private FontAwesome.Sharp.IconButton iconButtonMantenimientos;
    }
}
