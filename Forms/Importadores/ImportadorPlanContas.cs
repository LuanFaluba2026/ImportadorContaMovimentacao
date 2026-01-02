using ClosedXML.Excel;
using ImportadorContaMovimentacao.Scripts;
using System.Diagnostics;

namespace ImportadorContaMovimentacao.Forms
{
    public partial class ImportadorPlanContas : Form
    {
        const string PreConfigDB = @"P:\Fiscal\Arquivos de Apoio\5 - Importador NF-e X Mov. Contas\PreConfig.DB\XXX_SeniorDataBase_S.sqlite";

        string path = "";
        string selected = GerenciarEmpresas.selected;
        public ImportadorPlanContas()
        {
            InitializeComponent();
            empresaLB.Text = selected;
        }

        private void selectPathBTTN_Click(object sender, EventArgs e)
        {
            if (!HasDataBase)
            { 
                OpenFileDialog ofd = new();
                ofd.Filter = "Planilha de Plano de Contas do Domínio. (*.xlsx) |*.xlsx| Planilha de Plano de Contas do Sênior. (*.csv) |*.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    pathTB.Text = path;
                }
            }
            else
            {
                OpenFileDialog ofd = new();
                ofd.Filter = "Arquivo SQLite. (*.sqlite) |*.sqlite";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    pathTB.Text = path;
                }
            }
        }
        private void importBTNN_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(path)) return;

            if(!HasDataBase)
            {
                string[] selectedSplit = selected.Split(" - ");
                if (!String.IsNullOrEmpty(path) && selectedSplit[2] == "D")
                    Importar("Q", "N", "P", "O");
                else if (!String.IsNullOrEmpty(path) && selectedSplit[2] == "S")
                    Importar("D", "B", "C", "A");

                MessageBox.Show("Importação concluída com sucesso.");
            }
            else
            {
                DBConfig.DuplicarBanco(path);
                MessageBox.Show("Duplicação concluída com sucesso.");
            }
        }
        private void Importar(string colTipo, string colNum, string colNome, string colClass)
        {
            try
            {
                /* 
                 * Relação Colunas:
                 * Coluna N = Numero da Conta;
                 * Coluna Q = Tipo da Conta;
                 * Coluna P = Nome da Conta;
                 * Coluna O = Classificação Analítica.
                 */

                var wb = new XLWorkbook(path);
                var ws = wb.Worksheet(1);

                Cursor.Current = Cursors.WaitCursor;
                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    string tipo = row.Cell(colTipo).Value.ToString();
                    if (String.IsNullOrEmpty(tipo))
                        continue;

                    string num = row.Cell(colNum).Value.ToString();
                    string nome = row.Cell(colNome).Value.ToString();
                    string contaAnalitica = row.Cell(colClass).Value.ToString();

                    Conta conta = new Conta
                    {
                        numConta = num,
                        tipo = tipo,
                        nomeConta = nome,
                        contaAnalitica = !String.IsNullOrEmpty(contaAnalitica) ? contaAnalitica : ""
                    };

                    DBConfig.InsertContas(conta);
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }


        private bool _hasDataBase = false;
        public bool HasDataBase
        {
            get => _hasDataBase;
            set
            {
                if (_hasDataBase == value) return;

                _hasDataBase = value;
                ChangeLayout();
            }
        }
        private void switchLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HasDataBase = !HasDataBase;
        }
        private void ChangeLayout()
        {
            if (!HasDataBase)
            {
                switchLBL.Text = "Clique aqui se você já possuí um banco de dados.";
                caminhoLBL.Text = "Caminho Planilha de Contas:";

                path = "";
                pathTB.Text = "";
            }
            else
            {
                switchLBL.Text = "Clique aqui se você não possuí um banco de dados.";
                caminhoLBL.Text = "Caminho Banco de Dados:";
                path = PreConfigDB;
                pathTB.Text = PreConfigDB;
            }
        }
    }
}
