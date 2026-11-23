namespace VeiculosApp.UI
{
    partial class FormVeiculos
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
            label2 = new Label();
            label3 = new Label();
            txtPlaca = new TextBox();
            txtModelo = new TextBox();
            nudAno = new NumericUpDown();
            cboMarca = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            rdbCarro = new RadioButton();
            rdbMoto = new RadioButton();
            chkArCondicionado = new CheckBox();
            chkBau = new CheckBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnExcluir = new Button();
            dgvVeiculos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudAno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVeiculos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 19);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 0;
            label1.Text = "Placa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 19);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 1;
            label2.Text = "Modelo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(577, 19);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "Ano:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(49, 61);
            txtPlaca.MaxLength = 15;
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(159, 27);
            txtPlaca.TabIndex = 3;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(314, 62);
            txtModelo.MaxLength = 30;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(167, 27);
            txtModelo.TabIndex = 4;
            // 
            // nudAno
            // 
            nudAno.Location = new Point(577, 62);
            nudAno.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudAno.Minimum = new decimal(new int[] { 1950, 0, 0, 0 });
            nudAno.Name = "nudAno";
            nudAno.Size = new Size(150, 27);
            nudAno.TabIndex = 5;
            nudAno.Value = new decimal(new int[] { 1950, 0, 0, 0 });
            // 
            // cboMarca
            // 
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(49, 148);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(159, 28);
            cboMarca.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 113);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 7;
            label4.Text = "Marca:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(314, 113);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 8;
            label5.Text = "Tipo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(577, 113);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 9;
            label6.Text = "Possui:";
            // 
            // rdbCarro
            // 
            rdbCarro.AutoSize = true;
            rdbCarro.Checked = true;
            rdbCarro.Location = new Point(312, 136);
            rdbCarro.Name = "rdbCarro";
            rdbCarro.Size = new Size(66, 24);
            rdbCarro.TabIndex = 10;
            rdbCarro.TabStop = true;
            rdbCarro.Text = "Carro";
            rdbCarro.UseVisualStyleBackColor = true;
            rdbCarro.CheckedChanged += rdbCarro_CheckedChanged;
            // 
            // rdbMoto
            // 
            rdbMoto.AutoSize = true;
            rdbMoto.Location = new Point(312, 166);
            rdbMoto.Name = "rdbMoto";
            rdbMoto.Size = new Size(66, 24);
            rdbMoto.TabIndex = 11;
            rdbMoto.TabStop = true;
            rdbMoto.Text = "Moto";
            rdbMoto.UseVisualStyleBackColor = true;
            // 
            // chkArCondicionado
            // 
            chkArCondicionado.AutoSize = true;
            chkArCondicionado.Location = new Point(577, 136);
            chkArCondicionado.Name = "chkArCondicionado";
            chkArCondicionado.Size = new Size(143, 24);
            chkArCondicionado.TabIndex = 12;
            chkArCondicionado.Text = "Ar-condicionado";
            chkArCondicionado.UseVisualStyleBackColor = true;
            // 
            // chkBau
            // 
            chkBau.AutoSize = true;
            chkBau.Location = new Point(577, 167);
            chkBau.Name = "chkBau";
            chkBau.Size = new Size(56, 24);
            chkBau.TabIndex = 13;
            chkBau.Text = "Baú";
            chkBau.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(160, 228);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(94, 29);
            btnNovo.TabIndex = 14;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(364, 228);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 15;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(587, 228);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(94, 29);
            btnExcluir.TabIndex = 16;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // dgvVeiculos
            // 
            dgvVeiculos.AllowUserToAddRows = false;
            dgvVeiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVeiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVeiculos.Location = new Point(86, 263);
            dgvVeiculos.MultiSelect = false;
            dgvVeiculos.Name = "dgvVeiculos";
            dgvVeiculos.ReadOnly = true;
            dgvVeiculos.RowHeadersWidth = 51;
            dgvVeiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVeiculos.Size = new Size(634, 188);
            dgvVeiculos.TabIndex = 17;
            dgvVeiculos.CellClick += dgvVeiculos_CellClick;
            // 
            // FormVeiculos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvVeiculos);
            Controls.Add(btnExcluir);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(chkBau);
            Controls.Add(chkArCondicionado);
            Controls.Add(rdbMoto);
            Controls.Add(rdbCarro);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cboMarca);
            Controls.Add(nudAno);
            Controls.Add(txtModelo);
            Controls.Add(txtPlaca);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormVeiculos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Veículos";
            Load += FormVeiculos_Load;
            ((System.ComponentModel.ISupportInitialize)nudAno).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVeiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPlaca;
        private TextBox txtModelo;
        private NumericUpDown nudAno;
        private ComboBox cboMarca;
        private Label label4;
        private Label label5;
        private Label label6;
        private RadioButton rdbCarro;
        private RadioButton rdbMoto;
        private CheckBox chkArCondicionado;
        private CheckBox chkBau;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;
        private DataGridView dgvVeiculos;
    }
}