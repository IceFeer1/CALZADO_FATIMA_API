namespace WinFormsApp1
{
    partial class FrmPedidos
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
            textBoxEstado = new TextBox();
            label5 = new Label();
            buttonEliminar = new Button();
            buttonActualizar = new Button();
            buttonGuardar = new Button();
            label8 = new Label();
            label7 = new Label();
            textBoxTipo = new TextBox();
            textBoxIDCliente = new TextBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            label2 = new Label();
            textBoxFecha = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(532, 297);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 63;
            label1.Text = "Estado:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxEstado
            // 
            textBoxEstado.Location = new Point(592, 294);
            textBoxEstado.Name = "textBoxEstado";
            textBoxEstado.Size = new Size(164, 23);
            textBoxEstado.TabIndex = 62;
            textBoxEstado.TextChanged += textBoxEstado_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(34, 56);
            label5.Name = "label5";
            label5.Size = new Size(104, 32);
            label5.TabIndex = 52;
            label5.Text = "Pedidos";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(673, 409);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 61;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(592, 409);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 60;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(511, 409);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 59;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(543, 239);
            label8.Name = "label8";
            label8.Size = new Size(34, 15);
            label8.TabIndex = 58;
            label8.Text = "Tipo:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 182);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 57;
            label7.Text = "ID Cliente:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTipo
            // 
            textBoxTipo.Location = new Point(592, 236);
            textBoxTipo.Name = "textBoxTipo";
            textBoxTipo.Size = new Size(164, 23);
            textBoxTipo.TabIndex = 56;
            textBoxTipo.TextChanged += textBoxTipo_TextChanged;
            // 
            // textBoxIDCliente
            // 
            textBoxIDCliente.Location = new Point(592, 179);
            textBoxIDCliente.Name = "textBoxIDCliente";
            textBoxIDCliente.Size = new Size(164, 23);
            textBoxIDCliente.TabIndex = 55;
            textBoxIDCliente.TextChanged += textBoxIDCliente_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 88);
            label6.Name = "label6";
            label6.Size = new Size(170, 15);
            label6.TabIndex = 53;
            label6.Text = "Gestión de pedidos del sistema";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(496, 347);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 65;
            label2.Text = "Fecha Pedido:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(592, 344);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.Size = new Size(164, 23);
            textBoxFecha.TabIndex = 64;
            textBoxFecha.TextChanged += textBoxFecha_TextChanged;
            // 
            // FrmPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(label2);
            Controls.Add(textBoxFecha);
            Controls.Add(label1);
            Controls.Add(textBoxEstado);
            Controls.Add(label5);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonActualizar);
            Controls.Add(buttonGuardar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxTipo);
            Controls.Add(textBoxIDCliente);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPedidos";
            Text = "FrmPedidos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxEstado;
        private Label label5;
        private Button buttonEliminar;
        private Button buttonActualizar;
        private Button buttonGuardar;
        private Label label8;
        private Label label7;
        private TextBox textBoxTipo;
        private TextBox textBoxIDCliente;
        private DataGridView dataGridView1;
        private Label label6;
        private Label label2;
        private TextBox textBoxFecha;
    }
}