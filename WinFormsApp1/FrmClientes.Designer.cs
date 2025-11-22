namespace WinFormsApp1
{
    partial class FrmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelEscritorio = new Panel();
            label5 = new Label();
            buttonEliminar = new Button();
            buttonActualizar = new Button();
            buttonGuardar = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            textBoxTelefono = new TextBox();
            textBoxDireccion = new TextBox();
            textBoxApellido = new TextBox();
            textBoxNombre = new TextBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            panelEscritorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panelEscritorio
            // 
            panelEscritorio.Controls.Add(label5);
            panelEscritorio.Controls.Add(buttonEliminar);
            panelEscritorio.Controls.Add(buttonActualizar);
            panelEscritorio.Controls.Add(buttonGuardar);
            panelEscritorio.Controls.Add(label10);
            panelEscritorio.Controls.Add(label9);
            panelEscritorio.Controls.Add(label8);
            panelEscritorio.Controls.Add(label7);
            panelEscritorio.Controls.Add(textBoxTelefono);
            panelEscritorio.Controls.Add(textBoxDireccion);
            panelEscritorio.Controls.Add(textBoxApellido);
            panelEscritorio.Controls.Add(textBoxNombre);
            panelEscritorio.Controls.Add(dataGridView1);
            panelEscritorio.Controls.Add(label6);
            panelEscritorio.Dock = DockStyle.Fill;
            panelEscritorio.Location = new Point(0, 0);
            panelEscritorio.Name = "panelEscritorio";
            panelEscritorio.Size = new Size(1000, 700);
            panelEscritorio.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(40, 58);
            label5.Name = "label5";
            label5.Size = new Size(104, 32);
            label5.TabIndex = 0;
            label5.Text = "Clientes";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(679, 421);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 13;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(598, 421);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 12;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(517, 421);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 11;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(515, 318);
            label10.Name = "label10";
            label10.Size = new Size(56, 15);
            label10.TabIndex = 10;
            label10.Text = "Teléfono:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(511, 263);
            label9.Name = "label9";
            label9.Size = new Size(60, 15);
            label9.TabIndex = 9;
            label9.Text = "Dirección:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(517, 208);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 8;
            label8.Text = "Apellido:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(517, 158);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 7;
            label7.Text = "Nombre:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.Click += label7_Click;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(586, 315);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(164, 23);
            textBoxTelefono.TabIndex = 6;
            textBoxTelefono.TextChanged += textBoxTelefono_TextChanged;
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.Location = new Point(586, 260);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(164, 23);
            textBoxDireccion.TabIndex = 5;
            textBoxDireccion.TextChanged += textBoxDireccion_TextChanged;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(586, 205);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(164, 23);
            textBoxApellido.TabIndex = 4;
            textBoxApellido.TextChanged += textBoxApellido_TextChanged;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(586, 155);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(164, 23);
            textBoxNombre.TabIndex = 3;
            textBoxNombre.TextChanged += textBoxNombre_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 90);
            label6.Name = "label6";
            label6.Size = new Size(168, 15);
            label6.TabIndex = 1;
            label6.Text = "Gestión de clientes del sistema";
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(panelEscritorio);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmClientes";
            Text = "Form2";
            panelEscritorio.ResumeLayout(false);
            panelEscritorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEscritorio;
        private DataGridView dataGridView1;
        private Label label6;
        private Label label7;
        private TextBox textBoxDireccion;
        private TextBox textBoxApellido;
        private TextBox textBoxNombre;
        private Label label9;
        private Label label8;
        private Button buttonEliminar;
        private Button buttonActualizar;
        private Button buttonGuardar;
        private Label label5;
        private Label label10;
        private TextBox textBoxTelefono;
    }
}