using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using ImportadorContaMovimentacao.Forms;
using ImportadorContaMovimentacao.Forms.Consultas;
using ImportadorContaMovimentacao.Scripts;
using System.Diagnostics;

namespace ImportadorContaMovimentacao
{
    public partial class MainTab : Form
    {
        public MainTab()
        {
            InitializeComponent();

            TrocarEmpresa();
            MostrarFornecedorDiv();
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

        private void BuscarContasPassivasBTTN_Click(object sender, EventArgs e)
        {
            GerenciadorContas form = new();
            form.isClickable = true;
            form.ChamarFiltro(Program.analiticoPassivos);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Program.contaFornecedoresDiversos = form.contaSelecionada;
                MostrarFornecedorDiv();
            }
        }
        private void MostrarFornecedorDiv()
        {
            contaDiversosTB.Text = Program.contaFornecedoresDiversos.ToString();
            contaDiversosLB.Text = DBConfig.GetContas()?.FirstOrDefault(x => x.numConta == Program.contaFornecedoresDiversos)?.nomeConta ?? "*-- Não Encontrada.";
        }

        private void contasCadastradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorContas form = new();
            form.ShowDialog();
        }
        private void selectPathBTTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Planilhas SIEG (*.xlsx) |*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathTB.Text = ofd.FileName;

            }
        }

        List<Movimento> movsProcessados;
        private void importarMovBTTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(pathTB.Text))
                    throw new Exception("Selecione um caminho válido.");

                movsProcessados = ProcessarPlanilha.ProcessarMovimentos(pathTB.Text);
                movGridView.DataSource = movsProcessados;
                Program.MovGridViewConfig(movGridView);
                MostrarElementosGrid();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        private void MostrarElementosGrid()
        {
            movGridView.Refresh();
        }

        private void movGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            movGridView.Columns["valorMovimento"].DefaultCellStyle.Format = "C2";
            if (movGridView.Rows[e.RowIndex].Cells["contaCredito"].Value.ToString() == Program.contaFornecedoresDiversos)
            {
                movGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                e.CellStyle.Font = new Font(movGridView.Font, FontStyle.Bold);
            }
        }

        private void movGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (movGridView.Columns[e.ColumnIndex].Name == "btnContaCredito")
            {
                using (var frm = new ConsultaSimplificada())
                {
                    frm.isClickable = true;
                    frm.filtroAnalitico = Program.analiticoPassivos;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        movsProcessados[e.RowIndex].contaCredito = frm.contaSelecionada.numConta;
                        movsProcessados[e.RowIndex].descricaoCredito = frm.contaSelecionada.nomeConta;
                        movGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        MostrarElementosGrid();
                    }
                }
            }
        }
    }
}
