namespace WinFormsApp1
{
    partial class FrmVentas
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
            label8 = new Label();
            label7 = new Label();
            textBoxFechaVenta = new TextBox();
            textBoxIDCliente = new TextBox();
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
            label5.Size = new Size(89, 32);
            label5.TabIndex = 28;
            label5.Text = "Ventas";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(674, 409);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 39;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(593, 409);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 38;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(512, 409);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 37;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(497, 287);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 35;
            label8.Text = "Fecha Venta:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(509, 230);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 34;
            label7.Text = "ID Cliente:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxFechaVenta
            // 
            textBoxFechaVenta.Location = new Point(585, 284);
            textBoxFechaVenta.Name = "textBoxFechaVenta";
            textBoxFechaVenta.Size = new Size(164, 23);
            textBoxFechaVenta.TabIndex = 32;
            textBoxFechaVenta.TextChanged += textBoxFechaVenta_TextChanged;
            // 
            // textBoxIDCliente
            // 
            textBoxIDCliente.Location = new Point(585, 227);
            textBoxIDCliente.Name = "textBoxIDCliente";
            textBoxIDCliente.Size = new Size(164, 23);
            textBoxIDCliente.TabIndex = 31;
            textBoxIDCliente.TextChanged += textBoxIDCliente_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 88);
            label6.Name = "label6";
            label6.Size = new Size(154, 15);
            label6.TabIndex = 29;
            label6.Text = "Gestión de ventas realizadas";
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(label5);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonActualizar);
            Controls.Add(buttonGuardar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxFechaVenta);
            Controls.Add(textBoxIDCliente);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmVentas";
            Text = "FrmVentas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button buttonEliminar;
        private Button buttonActualizar;
        private Button buttonGuardar;
        private Label label8;
        private Label label7;
        private TextBox textBoxFechaVenta;
        private TextBox textBoxIDCliente;
        private DataGridView dataGridView1;
        private Label label6;
    }
}