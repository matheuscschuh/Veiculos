using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VeiculosApp.UI.Utils;
using VeiculosApp.Core.Services;
using VeiculosApp.Core.Entidades;
using VeiculosApp.Core.Exceptions;

namespace VeiculosApp.UI
{
    public partial class FormMarcas : Form
    {
        private readonly MarcaService _service;
        private int _codigoSelecionado = 0;
        public FormMarcas(MarcaService service)
        {
            _service = service;
            InitializeComponent();
        }

        private async Task CarregarGradeAsync()
        {
            try
            {
                var listaMarcas = await _service.ListarAsync();
                dgvMarcas.DataSource = listaMarcas;
                dgvMarcas.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger.Registrar(ex);
                MessageBox.Show("Não foi possível carregar as marcas. Tente novamente.");
            }
        }

        private void LimparFormulario()
        {
            txtNome.Text = "";
            _codigoSelecionado = 0;
            dgvMarcas.ClearSelection();
        }

        private async void FormMarcas_Load(object sender, EventArgs e)
        {
            await CarregarGradeAsync();
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMarcas.Rows[e.RowIndex].DataBoundItem is Marca marca)
            {
                _codigoSelecionado = marca.Codigo;
                txtNome.Text = marca.Nome;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_codigoSelecionado == 0)
                {
                    await _service.CriarAsync(txtNome.Text);
                    MessageBox.Show("Marca criada com sucesso");
                }
                else
                {
                    await _service.AtualizarAsync(new Marca(_codigoSelecionado, txtNome.Text));
                    MessageBox.Show("Marca atualizada com sucesso");
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_codigoSelecionado == 0)
            {
                MessageBox.Show("Selecione uma marca para excluir");
                return;
            }
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir essa marca?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado != DialogResult.Yes) return;
            
            try
            {
                await _service.DeletarAsync(_codigoSelecionado);
                MessageBox.Show("Marca excluída com sucesso");
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
