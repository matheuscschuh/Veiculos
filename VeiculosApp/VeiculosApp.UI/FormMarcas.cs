using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VeiculosApp.Core.Services;

namespace VeiculosApp.UI
{
    public partial class FormMarcas : Form
    {
        private readonly MarcaService _service;
        public FormMarcas(MarcaService service)
        {
            _service = service;
            InitializeComponent();
        }
    }
}
