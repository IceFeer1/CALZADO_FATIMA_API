namespace WinFormsApp1
{
    partial class FrmProductos
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
            label5 = new Label();
            buttonEliminar = new Button();
            buttonActualizar = new Button();
            buttonGuardar = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            textBoxTalla = new TextBox();
            textBoxPrecio = new TextBox();
            textBoxNombre = new TextBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 56);
            label5.Name = "label5";
            label5.Size = new Size(131, 32);
            label5.TabIndex = 14;
            label5.Text = "Productos";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(674, 409);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 27;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(593, 409);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 26;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(512, 409);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 25;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(536, 298);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 23;
            label9.Text = "Talla:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(527, 243);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 22;
            label8.Text = "Precio:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 186);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 21;
            label7.Text = "Nombre:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTalla
            // 
            textBoxTalla.Location = new Point(585, 295);
            textBoxTalla.Name = "textBoxTalla";
            textBoxTalla.Size = new Size(164, 23);
            textBoxTalla.TabIndex = 19;
            textBoxTalla.TextChanged += textBoxTalla_TextChanged;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(585, 240);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(164, 23);
            textBoxPrecio.TabIndex = 18;
            textBoxPrecio.TextChanged += textBoxPrecio_TextChanged;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(585, 183);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(164, 23);
            textBoxNombre.TabIndex = 17;
            textBoxNombre.TextChanged += textBoxNombre_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 88);
            label6.Name = "label6";
            label6.Size = new Size(195, 15);
            label6.TabIndex = 15;
            label6.Text = "Gestión de productos del inventario";
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(label5);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonActualizar);
            Controls.Add(buttonGuardar);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxTalla);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxNombre);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProductos";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button buttonEliminar;
        private Button buttonActualizar;
        private Button buttonGuardar;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox textBoxTalla;
        private TextBox textBoxPrecio;
        private TextBox textBoxNombre;
        private DataGridView dataGridView1;
        private Label label6;
    }
}