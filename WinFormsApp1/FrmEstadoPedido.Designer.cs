namespace WinFormsApp1
{
    partial class FrmEstadoPedido
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
            label7 = new Label();
            textBoxDescripcion = new TextBox();
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
            label5.Size = new Size(176, 32);
            label5.TabIndex = 50;
            label5.Text = "Estado Pedido";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(674, 409);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 57;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(593, 409);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 56;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(512, 409);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 55;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(498, 267);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 54;
            label7.Text = "Descripción:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(585, 264);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(164, 23);
            textBoxDescripcion.TabIndex = 53;
            textBoxDescripcion.TextChanged += textBoxDescripcion_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 52;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 88);
            label6.Name = "label6";
            label6.Size = new Size(207, 15);
            label6.TabIndex = 51;
            label6.Text = "Descripción de los estados de pedidos";
            // 
            // FrmEstadoPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(label5);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonActualizar);
            Controls.Add(buttonGuardar);
            Controls.Add(label7);
            Controls.Add(textBoxDescripcion);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmEstadoPedido";
            Text = "FrmEstadoPedido";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button buttonEliminar;
        private Button buttonActualizar;
        private Button buttonGuardar;
        private Label label7;
        private TextBox textBoxDescripcion;
        private DataGridView dataGridView1;
        private Label label6;
    }
}