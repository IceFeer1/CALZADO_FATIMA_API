namespace WinFormsApp1
{
    partial class FrmProveedores
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
            textBoxTelefono = new TextBox();
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
            label5.Size = new Size(157, 32);
            label5.TabIndex = 40;
            label5.Text = "Proveedores";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(674, 409);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 49;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonActualizar
            // 
            buttonActualizar.Location = new Point(593, 409);
            buttonActualizar.Name = "buttonActualizar";
            buttonActualizar.Size = new Size(75, 23);
            buttonActualizar.TabIndex = 48;
            buttonActualizar.Text = "Actualizar";
            buttonActualizar.UseVisualStyleBackColor = true;
            buttonActualizar.Click += buttonActualizar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(512, 409);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 47;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(514, 287);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 46;
            label8.Text = "Teléfono:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 230);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 45;
            label7.Text = "Nombre:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(585, 284);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(164, 23);
            textBoxTelefono.TabIndex = 44;
            textBoxTelefono.TextChanged += textBoxTelefono_TextChanged;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(585, 227);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(164, 23);
            textBoxNombre.TabIndex = 43;
            textBoxNombre.TextChanged += textBoxNombre_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 424);
            dataGridView1.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 88);
            label6.Name = "label6";
            label6.Size = new Size(149, 15);
            label6.TabIndex = 41;
            label6.Text = "Gestión de los proveedores";
            // 
            // FrmProveedores
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
            Controls.Add(textBoxTelefono);
            Controls.Add(textBoxNombre);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProveedores";
            Text = "FrmProveedor";
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
        private TextBox textBoxTelefono;
        private TextBox textBoxNombre;
        private DataGridView dataGridView1;
        private Label label6;
    }
}