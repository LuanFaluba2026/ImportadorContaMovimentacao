using ImportadorContaMovimentacao.Forms.Dialogs;
using ImportadorContaMovimentacao.Scripts;
using System.Data;

namespace ImportadorContaMovimentacao.Forms.Consultas
{
    public partial class GerenciadorContas : Form
    {
        List<Conta> contas = DBConfig.GetContas();
        public GerenciadorContas()
        {
            InitializeComponent();
            ShowData(contas);
            selecFiltroCMB.SelectedIndex = 1;
        }
        public void ChamarFiltro(string filtroConta)
        {
            grupoTB.Text = filtroConta;
        }
        private void ShowData(List<Conta> dataSource)
        {
            contasGridView.DataSource = null;
            contasGridView.DataSource = dataSource;
            Program.ContasGridViewConfig(contasGridView);
        }
        private void grupoTB_TextChanged(object sender, EventArgs e)
        {
            ShowData(contas.Where(x => x.contaAnalitica.StartsWith(grupoTB.Text)).ToList());
        }
        private void contasGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (contasGridView.Rows[e.RowIndex].Cells["tipo"].Value?.ToString() == "S")
            {
                e.CellStyle.Font = new Font(contasGridView.Font, FontStyle.Bold);
                e.CellStyle.BackColor = Color.LightGray;
            }
        }
        private void filtrarGrupoCB_CheckedChanged(object sender, EventArgs e)
        {
            if (filtrarGrupoCB.Checked)
            {
                grupoTB.Enabled = true;
                consultaGrupoBTTN.Enabled = true;
            }
            else
            {
                grupoTB.Enabled = false;
                grupoTB.Text = "";
                consultaGrupoBTTN.Enabled = false;
            }
        }

        private void pesquisaTB_TextChanged(object sender, EventArgs e)
        {
            if (filtrarGrupoCB.Checked)
            {
                switch (selecFiltroCMB.Text)
                {
                    case "numConta":
                        ShowData(contas.Where(x => x.numConta.StartsWith(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase) && x.contaAnalitica.StartsWith(grupoTB.Text)).ToList());
                        break;
                    case "nomeConta":
                        ShowData(contas.Where(x => x.nomeConta.Contains(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase) && x.contaAnalitica.StartsWith(grupoTB.Text)).ToList());
                        break;
                }
            }
            else
            {
                switch (selecFiltroCMB.Text)
                {
                    case "numConta":
                        ShowData(contas.Where(x => x.numConta.StartsWith(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;
                    case "nomeConta":
                        ShowData(contas.Where(x => x.nomeConta.Contains(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;
                }
            }
        }

        public bool isClickable;
        public string contaSelecionada { get; private set; }
        private void contasGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clicked = contasGridView.Rows[e.RowIndex].Cells["numConta"].Value.ToString();
            var tipo = contasGridView.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
            if (!String.IsNullOrEmpty(clicked) && isClickable && tipo != "S")
            {
                contaSelecionada = clicked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void addBTTN_Click(object sender, EventArgs e)
        {
            AdicionarConta form = new();
            if(form.ShowDialog() == DialogResult.OK)
            {
                ShowData(contas);
                contasGridView.CurrentCell = contasGridView?.Rows?.Cast<DataGridViewRow>()?.FirstOrDefault(x => x.Equals(form.numConta))?.Cells["numConta"];
            }
        }
    }
}
