using VeiculosApp.Core.Services;

namespace VeiculosApp.UI
{
    public partial class FormPrincipal : Form
    {
        private readonly MarcaService _serviceMarca;
        private readonly VeiculoService _serviceVeiculo;
        public FormPrincipal(MarcaService serviceMarca, VeiculoService serviceVeiculo)
        {
            _serviceMarca = serviceMarca;
            _serviceVeiculo = serviceVeiculo;
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            using var formMarcas = new FormMarcas(_serviceMarca);
            formMarcas.ShowDialog();
        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {
            using var formVeiculos = new FormVeiculos(_serviceMarca, _serviceVeiculo);
            formVeiculos.ShowDialog();
        }
    }
}
