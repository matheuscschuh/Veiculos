using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Exceptions;
using VeiculosApp.Core.Services;
using VeiculosApp.UI.Utils;

namespace VeiculosApp.UI
{
    public partial class FormVeiculos : Form
    {
        private readonly MarcaService _serviceMarca;
        private readonly VeiculoService _serviceVeiculo;

        private int _codigoSelecionado = 0;
        public FormVeiculos(MarcaService serviceMarca, VeiculoService serviceVeiculo)
        {
            _serviceMarca = serviceMarca;
            _serviceVeiculo = serviceVeiculo;
            InitializeComponent();
        }

        private async Task CarregarGradeAsync()
        {
            try
            {
                dgvVeiculos.DataSource = await _serviceVeiculo.ListarAsync();
                dgvVeiculos.ClearSelection();

            }
            catch (Exception ex)
            {
                Logger.Registrar(ex);
                MessageBox.Show("Não foi possível carregar os veículos. Tente novamente.");
            }
        }

        private async Task CarregarMarcasAsync()
        {
            try
            {
                cboMarca.DataSource = await _serviceMarca.ListarAsync();
                cboMarca.DisplayMember = "Nome";
                cboMarca.ValueMember = "Codigo";
                cboMarca.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Logger.Registrar(ex);
                MessageBox.Show("Não foi possível carregar as Marcas. Tente novamente.");
            }
        }

        private void LimparFormulario()
        {
            txtPlaca.Text = "";
            txtModelo.Text = "";
            nudAno.Value = DateTime.Now.Year;
            cboMarca.SelectedIndex = -1;
            rdbCarro.Checked = true;
            rdbCarro.Enabled = true;
            rdbMoto.Enabled = true;
            chkArCondicionado.Checked = false;
            chkBau.Checked = false;
            _codigoSelecionado = 0;
            dgvVeiculos.ClearSelection();
        }


        private async void FormVeiculos_Load(object sender, EventArgs e)
        {
            int anoAtual = DateTime.Now.Year;
            nudAno.Maximum = anoAtual;
            nudAno.Value = anoAtual;

            await CarregarMarcasAsync();

            chkBau.Visible = false;

            await CarregarGradeAsync();
        }

        private void rdbCarro_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCarro.Checked)
            {
                chkArCondicionado.Visible = true;
                chkBau.Visible = false;
                chkBau.Checked = false;
            }
            else
            {
                chkBau.Visible = true;
                chkArCondicionado.Visible = false;
                chkArCondicionado.Checked = false;
            }

        }

        private void dgvVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvVeiculos.Rows[e.RowIndex].DataBoundItem is Veiculo veiculo)
            {
                _codigoSelecionado = veiculo.Codigo;
                txtPlaca.Text = veiculo.Placa;
                txtModelo.Text = veiculo.Modelo;
                nudAno.Value = veiculo.Ano;

                cboMarca.SelectedValue = veiculo.Marca.Codigo;

                if (veiculo is Carro carro)
                {
                    rdbCarro.Checked = true;
                    chkArCondicionado.Checked = carro.PossuiArCondicionado;
                }
                else if (veiculo is Moto moto)
                {
                    rdbMoto.Checked = true;
                    chkBau.Checked = moto.PossuiBau;
                }

                rdbCarro.Enabled = false;
                rdbMoto.Enabled = false;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            Marca? marcaSelecionada = cboMarca.SelectedItem as Marca;
            Veiculo veiculo;
            if (rdbCarro.Checked)
                veiculo = new Carro(_codigoSelecionado, txtPlaca.Text, (int)nudAno.Value, txtModelo.Text, marcaSelecionada, chkArCondicionado.Checked);
            else
                veiculo = new Moto(_codigoSelecionado, txtPlaca.Text, (int)nudAno.Value, txtModelo.Text, marcaSelecionada, chkBau.Checked);
            try
            {
                if (_codigoSelecionado == 0)
                {
                    await _serviceVeiculo.CriarAsync(veiculo);
                    MessageBox.Show("Veículo criado com sucesso");
                }
                else
                {
                    await _serviceVeiculo.AtualizarAsync(veiculo);
                    MessageBox.Show("Veículo atualizado com sucesso");
                }

                LimparFormulario();
                await CarregarGradeAsync();
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Registrar(ex);
                MessageBox.Show("Ocorreu um erro inesperado. Tente novamente");
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_codigoSelecionado == 0)
            {
                MessageBox.Show("Selecione um veículo para excluir");
                return;
            }
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir esse veículo?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado != DialogResult.Yes) return;

            try
            {
                await _serviceVeiculo.DeletarAsync(_codigoSelecionado);
                MessageBox.Show("Veículo excluído com sucesso");
                LimparFormulario();
                await CarregarGradeAsync();
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (Exception ex)
            {
                Logger.Registrar(ex);
                MessageBox.Show("Ocorreu um erro inesperado. Tente novamente");
            }
        }
    }
}
