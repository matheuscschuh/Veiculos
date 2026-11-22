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
            this.btnMarcas = new Button();
            btnVeiculos = new Button();
            SuspendLayout();
            // 
            // btnMarcas
            // 
            this.btnMarcas.Location = new Point(165, 148);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new Size(94, 29);
            this.btnMarcas.TabIndex = 0;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += this.btnMarcas_Click;
            // 
            // btnVeiculos
            // 
            btnVeiculos.Location = new Point(374, 148);
            btnVeiculos.Name = "btnVeiculos";
            btnVeiculos.Size = new Size(94, 29);
            btnVeiculos.TabIndex = 1;
            btnVeiculos.Text = "Veículos";
            btnVeiculos.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 326);
            Controls.Add(btnVeiculos);
            Controls.Add(this.btnMarcas);
            Name = "FormPrincipal";
            Text = "Gerenciamento de Veículos";
            Load += FormPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnMarcas;
        private Button btnVeiculos;
    }
}
