using ImportadorContaMovimentacao.Forms.Gerenciador_de_Empresas;
using ImportadorContaMovimentacao.Scripts;

namespace ImportadorContaMovimentacao.Forms
{
    public partial class GerenciarEmpresas : Form
    {
        bool selecionouEmpresa = false;
        public static string selected = "";
        public GerenciarEmpresas()
        {
            InitializeComponent();
            ListarEmpresas();
        }
        private void ListarEmpresas()
        {
            List<EmpresasCadastradas> listaEmpresas = DBConfig.GetEmpresas();
            empresasGV.DataSource = null;
            empresasGV.DataSource = listaEmpresas;
            empresasGV.Columns["nomeEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            empresasGV.ClearSelection();
        }

        private void GerenciarEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !selecionouEmpresa)
                Application.Exit();
        }

        private void AdicionarBTTN_Click(object sender, EventArgs e)
        {
            AdicionarEmpresa adcEmp = new AdicionarEmpresa();
            adcEmp.ShowDialog();
            DBConfig.CriarTabela();
            ListarEmpresas();
        }

        private void removerBTTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (empresasGV.SelectedRows.Count > 0)
                {
                    var num = empresasGV.SelectedRows[0].Cells["numEmpresa"].Value.ToString();
                    var nome = empresasGV.SelectedRows[0].Cells["nomeEmpresa"].Value.ToString();
                    var erp = empresasGV.SelectedRows[0].Cells["erpSelecionado"].Value.ToString();

                    DBConfig.RemoverBanco(new EmpresasCadastradas
                    {
                        numEmpresa = num,
                        nomeEmpresa = nome,
                        erpSelecionado = char.Parse(erp ?? "")
                    });
                    ListarEmpresas();
                }
                else
                {
                    throw new Exception("Selecione a empresa que você deseja remover.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }

        }

        private void empresasGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (empresasGV.SelectedRows.Count > 0)
                {
                    var num = empresasGV.SelectedRows[0].Cells["numEmpresa"].Value.ToString();
                    var nome = empresasGV.SelectedRows[0].Cells["nomeEmpresa"].Value.ToString();
                    var erp = empresasGV.SelectedRows[0].Cells["erpSelecionado"].Value.ToString();
                    DBConfig.dbPath = Path.Combine(Program.dbPath, $"{num}_{nome}_{erp}.sqlite");
                    selecionouEmpresa = true;

                    selected = $"{num} - {nome} - {erp}";

                    var contas = DBConfig.GetContas().Count;
                    if (contas == 0)
                    {
                        var msgBox = MessageBox.Show("Banco de Dados não possuí cadastro do plano de contas. Deseja realizar uma importação via Planilha?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (msgBox == DialogResult.Yes)
                        {
                            ImportadorPlanContas form = new();
                            form.ShowDialog();
                        }
                    }

                    Program.AtualizarFornecedoresDiversos();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
