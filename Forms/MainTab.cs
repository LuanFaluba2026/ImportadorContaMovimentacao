using ImportadorContaMovimentacao.Forms;
using ImportadorContaMovimentacao.Scripts;
using System.Diagnostics;

namespace ImportadorContaMovimentacao
{
    public partial class MainTab : Form
    {
        string sheetPath = "";
        public MainTab()
        {
            InitializeComponent();

            TrocarEmpresa();

        }

        private void selectEmpresa_Click(object sender, EventArgs e)
        {
            TrocarEmpresa();
        }
        private void TrocarEmpresa()
        {
            // Chama tela de seleção de empresa
            GerenciarEmpresas GEForm = new();
            GEForm.ShowDialog();

            if (GEForm.DialogResult == DialogResult.OK)
            {
                empresaLB.Text = GerenciarEmpresas.selected;
            }
        }

        private void selectPathBTTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Planilhas SIEG (*.xlsx) |*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sheetPath = ofd.FileName;
            }
        }
    }
}
