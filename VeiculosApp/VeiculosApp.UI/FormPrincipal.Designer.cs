namespace VeiculosApp.UI
{
    partial class FormPrincipal
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
            btnMarcas = new Button();
            btnVeiculos = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnMarcas
            // 
            btnMarcas.Location = new Point(165, 148);
            btnMarcas.Name = "btnMarcas";
            btnMarcas.Size = new Size(94, 29);
            btnMarcas.TabIndex = 0;
            btnMarcas.Text = "Marcas";
            btnMarcas.UseVisualStyleBackColor = true;
            btnMarcas.Click += btnMarcas_Click;
            // 
            // btnVeiculos
            // 
            btnVeiculos.Location = new Point(374, 148);
            btnVeiculos.Name = "btnVeiculos";
            btnVeiculos.Size = new Size(94, 29);
            btnVeiculos.TabIndex = 1;
            btnVeiculos.Text = "Veículos";
            btnVeiculos.UseVisualStyleBackColor = true;
            btnVeiculos.Click += btnVeiculos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(222, 37);
            label1.Name = "label1";
            label1.Size = new Size(198, 20);
            label1.TabIndex = 2;
            label1.Text = "Gerenciamento de Veículos";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 326);
            Controls.Add(label1);
            Controls.Add(btnVeiculos);
            Controls.Add(btnMarcas);
            Name = "FormPrincipal";
            Text = "Gerenciamento de Veículos";
            Load += FormPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMarcas;
        private Button btnVeiculos;
        private Label label1;
    }
}
