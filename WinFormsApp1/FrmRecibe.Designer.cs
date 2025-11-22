namespace WinFormsApp1
{
    partial class FrmRecibe
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
            label1 = new Label();
            textBoxFecha = new TextBox();
            label5 = new Label();
            buttonEliminar = new Button();
            buttonActualizar = new Button();
            buttonGuardar = new Button();
            label8 = new Label();
            label7 = new Label();
            textBoxProveedor = new TextBox();
            textBoxProducto = new TextBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(529, 324);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 73;
            label1.Text = "Fecha:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(585, 321);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.Size = new Size(164, 23);
            textBoxFecha.TabIndex = 72;
            textBoxFecha.TextChanged += textBoxFecha_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 56);
            label5.Name = "label5";
            label5.Size = new Size(89, 32);
            label5.TabIndex = 62;
            label5.Text = "Recibe";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(674, 409);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 71;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(593, 409);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 70;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(512, 409);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 69;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(506, 266);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 68;
            label8.Text = "Proveedor:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(511, 209);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 67;
            label7.Text = "Producto:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxProveedor
            // 
            textBoxProveedor.Location = new Point(585, 263);
            textBoxProveedor.Name = "textBoxProveedor";
            textBoxProveedor.Size = new Size(164, 23);
            textBoxProveedor.TabIndex = 66;
            textBoxProveedor.TextChanged += textBoxProveedor_TextChanged;
            // 
            // textBoxProducto
            // 
            textBoxProducto.Location = new Point(585, 206);
            textBoxProducto.Name = "textBoxProducto";
            textBoxProducto.Size = new Size(164, 23);
            textBoxProducto.TabIndex = 65;
            textBoxProducto.TextChanged += textBoxProducto_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 64;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 88);
            label6.Name = "label6";
            label6.Size = new Size(174, 15);
            label6.TabIndex = 63;
            label6.Text = "Registro de productos recibidos";
            // 
            // FrmRecibe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(label1);
            Controls.Add(textBoxFecha);
            Controls.Add(label5);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonActualizar);
            Controls.Add(buttonGuardar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxProveedor);
            Controls.Add(textBoxProducto);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRecibe";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFecha;
        private Label label5;
        private Button buttonEliminar;
        private Button buttonActualizar;
        private Button buttonGuardar;
        private Label label8;
        private Label label7;
        private TextBox textBoxProveedor;
        private TextBox textBoxProducto;
        private DataGridView dataGridView1;
        private Label label6;
    }
}