using ImportadorContaMovimentacao.Scripts;
using System.Data;

namespace ImportadorContaMovimentacao.Forms.Consultas
{
    public partial class ConsultaSimplificada : Form
    {
        public string? filtroAnalitico { get; set; }
        public int filtroCB { get; set; }
        public ConsultaSimplificada()
        {
            InitializeComponent();
        }
        private void ConsultaSimplificada_Load(object sender, EventArgs e)
        {
            this.ActiveControl = pesquisaTB;
            this.KeyPreview = true;

            MostrarDados(DBConfig.GetContas().Where(x => x.contaAnalitica.Contains(filtroAnalitico ?? "")).ToList());
            selectColunaCB.Text = Program.analiticoDespesas;
            PreencherComboBox();
        }

        private void MostrarDados<T>(List<T> source)
        {
            dadosGridView.DataSource = null;
            dadosGridView.DataSource = source;
            Program.ContasGridViewConfig(dadosGridView);
        }

        private void dadosGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dadosGridView.Rows[e.RowIndex].Cells["tipo"].Value?.ToString() == "S")
            {
                e.CellStyle.Font = new Font(dadosGridView.Font, FontStyle.Bold);
                e.CellStyle.BackColor = Color.LightGray;
            }
            dadosGridView.Columns["tipo"].Visible = false;
        }

        public bool isClickable;
        public Conta contaSelecionada { get; private set; }
        private void dadosGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clicked = dadosGridView.Rows[e.RowIndex].Cells["numConta"].Value.ToString();
            var tipo = dadosGridView.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
            if (!String.IsNullOrEmpty(clicked) && isClickable && tipo != "S")
            {
                contaSelecionada = DBConfig.GetContas().First(x => x.numConta.Equals(clicked));
                Program.analiticoDespesas = contaSelecionada?.contaAnalitica?.Substring(0, 5);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        //SELEÇÃO E PESQUISA --*

        private void PreencherComboBox()
        {
            foreach (DataGridViewColumn column in dadosGridView.Columns)
            {
                if (column.Visible)
                    selectColunaCB.Items.Add(column.Name);
            }
            selectColunaCB.SelectedIndex = filtroCB;
        }

        private void pesquisaTB_TextChanged(object sender, EventArgs e)
        {
            List<Conta> dados = DBConfig.GetContas();
            if (!String.IsNullOrEmpty(pesquisaTB.Text))
            {
                switch (selectColunaCB.SelectedIndex)
                {
                    case 0:
                        MostrarDados(dados.Where(x => x.numConta.StartsWith(pesquisaTB.Text)).ToList());
                        break;
                    case 1:
                        MostrarDados(dados.Where(x => x.nomeConta.Contains(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;
                    case 2:
                        MostrarDados(dados.Where(x => x.contaAnalitica.StartsWith(pesquisaTB.Text)).ToList());
                        break;
                }
            }
            else
            {
                MostrarDados(dados);
            }
        }

        private void ConsultaSimplificada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
