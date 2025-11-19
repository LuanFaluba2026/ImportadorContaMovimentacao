using ImportadorContaMovimentacao.Forms;
using ImportadorContaMovimentacao.Scripts;

namespace ImportadorContaMovimentacao
{
    public partial class MainTab : Form
    {
        public MainTab()
        {
            InitializeComponent();

            // Chama tela de seleção de empresa
            GerenciarEmpresas GEForm = new();
            GEForm.ShowDialog();
        }

        private void selectEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void MainTab_Load(object sender, EventArgs e)
        {

        }
    }
}
