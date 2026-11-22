namespace VeiculosApp.UI
{
    partial class FormMarcas
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
            lblNome = new Label();
            txtNome = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnExcluir = new Button();
            dgvMarcas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(235, 72);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(53, 20);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(235, 114);
            txtNome.MaxLength = 50;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(257, 27);
            txtNome.TabIndex = 1;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(125, 184);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(94, 29);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(318, 184);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(533, 184);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(94, 29);
            btnExcluir.TabIndex = 4;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Location = new Point(125, 241);
            dgvMarcas.MultiSelect = false;
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.ReadOnly = true;
            dgvMarcas.RowHeadersWidth = 51;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(502, 188);
            dgvMarcas.TabIndex = 5;
            dgvMarcas.CellClick += dgvMarcas_CellClick;
            // 
            // FormMarcas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvMarcas);
            Controls.Add(btnExcluir);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Name = "FormMarcas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Marcas";
            Load += FormMarcas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox txtNome;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;
        private DataGridView dgvMarcas;
    }
}