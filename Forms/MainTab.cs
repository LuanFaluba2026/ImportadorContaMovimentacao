using ImportadorContaMovimentacao.Forms;
using ImportadorContaMovimentacao.Forms.Consultas;
using ImportadorContaMovimentacao.Scripts;

namespace ImportadorContaMovimentacao
{
    public partial class MainTab : Form
    {
        public MainTab()
        {
            InitializeComponent();
            if (TrocarEmpresa() != DialogResult.OK) return;

            this.KeyPreview = true;

            MostrarFornecedorDiv();
        }
        private void selectEmpresa_Click(object sender, EventArgs e)
        {
            TrocarEmpresa();
        }
        private DialogResult TrocarEmpresa()
        {
            // Chama tela de seleção de empresa
            GerenciarEmpresas GEForm = new();

            GEForm.ShowDialog();

            if (GEForm.DialogResult == DialogResult.OK)
            {
                empresaLB.Text = GerenciarEmpresas.selected;
                MostrarFornecedorDiv();
                return GEForm.DialogResult;
            }
            return DialogResult.Abort;
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
            contaDiversosTB.Text = Program.contaFornecedoresDiversos ?? "";
            contaDiversosLB.Text = DBConfig.GetContas()?.FirstOrDefault(x => x.numConta == Program.contaFornecedoresDiversos)?.nomeConta ?? "*-- Não Encontrada.";
        }

        private void contasCadastradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorContas form = new();
            form.ShowDialog();
        }
        private void selectPathBTTN_Click(object sender, EventArgs e)
        {

            if (planCheck.Checked)
            {
                OpenFileDialog ofd = new();
                ofd.Filter = "Planilhas SIEG (*.xlsx) |*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pathTB.Text = ofd.FileName;

                }
            }
            else if (xmlCheck.Checked)
            {
                FolderBrowserDialog fbd = new();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    fbd.ShowHiddenFiles = true;
                    pathTB.Text = fbd.SelectedPath;
                }
            }
            else
                throw new Exception("Selecione pelo menos uma entrada de dados.");

            
        }

        List<Movimento> movsProcessados;
        private void importarMovBTTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(pathTB.Text))
                    throw new Exception("Selecione um caminho válido.");

                if (planCheck.Checked)
                    movsProcessados = Processar.ProcessarPlanilha(pathTB.Text);
                else if (xmlCheck.Checked)
                    movsProcessados = Processar.ProcessarXML(pathTB.Text);
                else
                    throw new Exception("Selecione pelo menos uma entrada de dados.");

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
            movGridView.Columns["descricaoDebito"].ReadOnly = true;
            movGridView.Columns["descricaoCredito"].ReadOnly = true;
            movGridView.Columns["cnpj"].ReadOnly = true;

            movGridView.Columns["valorMovimento"].DefaultCellStyle.Format = "C2";
            if (movGridView.Rows[e.RowIndex].Cells["contaCredito"].Value.ToString() == Program.contaFornecedoresDiversos)
            {
                movGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                e.CellStyle.Font = new Font(movGridView.Font, FontStyle.Bold);
            }
            else
            {
                movGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = movGridView.DefaultCellStyle.BackColor;
                e.CellStyle.Font = new Font(movGridView.Font, FontStyle.Bold);
            }
            if (String.IsNullOrEmpty(movGridView.Rows[e.RowIndex].Cells["contaDebito"].Value.ToString()))
            {
                movGridView.Rows[e.RowIndex].Cells["contaDebito"].Style.BackColor = Color.LightSalmon;
                movGridView.Rows[e.RowIndex].Cells["descricaoDebito"].Style.BackColor = Color.LightSalmon;
            }

            if (movGridView.Columns[e.ColumnIndex].Name == "cnpj" && e.Value != null)
            {
                string cnpj = new string(e.Value.ToString().Where(char.IsDigit).ToArray());

                if (cnpj.Length == 14)
                {
                    e.Value = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
                    e.FormattingApplied = true;
                }
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
            else if (movGridView.Columns[e.ColumnIndex].Name == "btnContaDebito")
            {
                using (var frm = new ConsultaSimplificada())
                {
                    frm.isClickable = true;
                    frm.filtroAnalitico = Program.analiticoDespesas;
                    frm.filtroCB = 1;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        movsProcessados[e.RowIndex].contaDebito = frm.contaSelecionada.numConta;
                        movsProcessados[e.RowIndex].descricaoDebito = frm.contaSelecionada.nomeConta;
                        movGridView.Rows[e.RowIndex].Cells["contaDebito"].Style.BackColor = Color.Empty;
                        movGridView.Rows[e.RowIndex].Cells["descricaoDebito"].Style.BackColor = Color.Empty;
                        MostrarElementosGrid();
                    }
                }
            }
        }

        private void movGridView_KeyDown(object sender, KeyEventArgs e)
        {
            //f1 - puxa pesquisa simplificada das células
            if (e.KeyCode == Keys.F1)
            {
                var cell = movGridView.CurrentCell;

                if (movGridView.Columns[cell.ColumnIndex].Name == "contaCredito")
                {
                    using (var frm = new ConsultaSimplificada())
                    {
                        frm.isClickable = true;
                        frm.filtroAnalitico = Program.analiticoPassivos;
                        frm.filtroCB = 1;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            movsProcessados[cell.RowIndex].contaCredito = frm.contaSelecionada.numConta;
                            movsProcessados[cell.RowIndex].descricaoCredito = frm.contaSelecionada.nomeConta;
                            movGridView.Rows[cell.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            MostrarElementosGrid();
                        }
                    }
                }
                else if (movGridView.Columns[cell.ColumnIndex].Name == "contaDebito")
                {
                    using (var frm = new ConsultaSimplificada())
                    {
                        frm.isClickable = true;
                        frm.filtroAnalitico = Program.analiticoDespesas;
                        frm.filtroCB = 1;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            movsProcessados[cell.RowIndex].contaDebito = frm.contaSelecionada.numConta;
                            movsProcessados[cell.RowIndex].descricaoDebito = frm.contaSelecionada.nomeConta;
                            movGridView.Rows[cell.RowIndex].Cells["contaDebito"].Style.BackColor = Color.Empty;
                            movGridView.Rows[cell.RowIndex].Cells["descricaoDebito"].Style.BackColor = Color.Empty;
                            MostrarElementosGrid();
                        }
                    }
                }
            }
            //f3 - faz com que o conteúdo da celula selecionada se aplique para todas as outras de baixo
            if (e.KeyCode == Keys.F2)
            {
                var msgBox = MessageBox.Show("Deseja alterar todas as celulas abaixo?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgBox != DialogResult.Yes) return;

                e.SuppressKeyPress = true;
                var cell = movGridView.CurrentCell;
                int index = cell.RowIndex;
                foreach (DataGridViewRow row in movGridView.Rows)
                {
                    if (row.Index > index)
                    {
                        switch (movGridView.Columns[cell.ColumnIndex].Name)
                        {
                            case "dataMovimento":
                                movsProcessados[cell.RowIndex].dataMovimento = DateTime.Parse(cell.Value.ToString());
                                break;
                            case "contaDebito":
                                movsProcessados[cell.RowIndex].contaDebito = cell.Value.ToString();
                                movsProcessados[row.Index].descricaoDebito = DBConfig.GetContas()?.FirstOrDefault(x => x.numConta.Equals(cell.Value))?.nomeConta ?? " -** Não encontrada.";
                                movGridView.Rows[row.Index].Cells["contaDebito"].Style.BackColor = Color.Empty;
                                movGridView.Rows[row.Index].Cells["descricaoDebito"].Style.BackColor = Color.Empty;
                                break;
                            case "contaCredito":
                                movsProcessados[cell.RowIndex].contaCredito = cell.Value.ToString();
                                movsProcessados[row.Index].descricaoCredito = DBConfig.GetContas()?.FirstOrDefault(x => x.numConta.Equals(cell.Value))?.nomeConta ?? " -** Não encontrada.";
                                movGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
                                break;
                            case "valorMovimento":
                                movsProcessados[cell.RowIndex].valorMovimento = (double)cell.Value;
                                break;
                            case "historico":
                                movsProcessados[cell.RowIndex].historico = cell.Value.ToString();
                                break;
                        }

                        row.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                }
                MostrarElementosGrid();
            }
            if (e.Control && e.KeyCode == Keys.Z)
                Desfazer();
        }
        //Preencher descrição
        string? cellValue;
        private void movGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            cellValue = movGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void movGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var validatedCell = movGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cellValue == validatedCell.Value.ToString()) return;

            if (validatedCell.OwningColumn.Name == "contaDebito")
            {
                movsProcessados[validatedCell.RowIndex].descricaoDebito = DBConfig.GetContas()?.FirstOrDefault(x => x.numConta.Equals(validatedCell.Value))?.nomeConta ?? " -** Não encontrada.";
                movGridView.Rows[validatedCell.RowIndex].Cells["contaDebito"].Style.BackColor = Color.Empty;
                movGridView.Rows[validatedCell.RowIndex].Cells["descricaoDebito"].Style.BackColor = Color.Empty;
                MostrarElementosGrid();
            }
            else if (validatedCell.OwningColumn.Name == "contaCredito")
            {
                movsProcessados[validatedCell.RowIndex].descricaoCredito = DBConfig.GetContas()?.FirstOrDefault(x => x.numConta.Equals(validatedCell.Value))?.nomeConta ?? " -** Não encontrada.";
                movGridView.Rows[validatedCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
                MostrarElementosGrid();
            }
        }
        //Redefinir com ctrl + z
        object oldValue;
        Stack<CelulaAlterada> undoStack = new();
        private void Desfazer()
        {
            if (undoStack.Count == 0) return;

            var change = undoStack.Pop();
            movGridView.CurrentCell = movGridView[change.ColumnIndex, change.RowIndex];
            switch (change.ColumnName)
            {
                case "dataMovimento":
                    movsProcessados[change.RowIndex].dataMovimento = (DateTime)change.OldValue;
                    break;
                case "contaDebito":
                    movsProcessados[change.RowIndex].contaDebito = (string)change.OldValue;
                    break;
                case "contaCredito":
                    movsProcessados[change.RowIndex].contaCredito = (string)change.OldValue;
                    break;
                case "valorMovimento":
                    movsProcessados[change.RowIndex].valorMovimento = (double)change.OldValue;
                    break;
                case "historico":
                    movsProcessados[change.RowIndex].historico = (string)change.OldValue;
                    break;
            }
            MostrarElementosGrid();
        }
        private void movGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldValue = movGridView[e.ColumnIndex, e.RowIndex].Value;
        }
        private void movGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            undoStack.Push(new CelulaAlterada
            {
                RowIndex = e.RowIndex,
                ColumnIndex = e.ColumnIndex,
                ColumnName = movGridView.Columns[e.ColumnIndex].Name,
                OldValue = oldValue
            });
        }
        private void undoBTTN_Click(object sender, EventArgs e)
        {
            Desfazer();
        }
        //Iniciar Processamento -

        private void ProcessarBTTN_Click(object sender, EventArgs e)
        {
            var gr = new GerarResultado();
            gr.ProcessarMovimentos(movsProcessados);
        }

        private void xmlCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (xmlCheck.Checked)
                planCheck.Checked = false;
        }

        private void planCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (planCheck.Checked)
                xmlCheck.Checked = false;
        }
    }
    class CelulaAlterada
    {
        public int RowIndex;
        public int ColumnIndex;
        public string? ColumnName;
        public object? OldValue;
    }
}
