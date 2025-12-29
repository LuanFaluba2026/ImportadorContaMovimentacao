using ImportadorContaMovimentacao.Forms;

namespace ImportadorContaMovimentacao.Scripts
{
    internal static class Program
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "DbContas");
        public static string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        public static void ShowError(Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message + " - " + ex.StackTrace, "Erro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        //Parametros
        public static string? contaFornecedoresDiversos;

        public static string analiticoPassivos = "21";
        public static string? analiticoDespesas;
        public static void AtualizarFornecedoresDiversos()
        {
            Conta contaFornDiversos = DBConfig.GetContas()?.FirstOrDefault(x => x.nomeConta.Equals("Fornecedores Diversos", StringComparison.OrdinalIgnoreCase) && x.tipo != "S") ?? new Conta();
            contaFornecedoresDiversos = contaFornDiversos.numConta;
            analiticoPassivos = contaFornDiversos.contaAnalitica.Substring(0, 6);
        }

        //Grids
        //parametors da grid de contas 
        public static void ContasGridViewConfig(DataGridView grid)
        {
            grid.AutoResizeColumns();
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.Columns["nomeConta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static void MovGridViewConfig(DataGridView grid)
        {
            grid.AutoResizeColumns();
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.Columns["historico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns["codigoEmpresa"].Visible = false;
            grid.Columns["fornecedor"].Visible = false;

            //Adiciona botão Conta Crédito
            DataGridViewButtonColumn btnContaCredito = new DataGridViewButtonColumn();
            btnContaCredito.Name = "btnContaCredito";
            btnContaCredito.HeaderText = "";
            btnContaCredito.Text = "...";
            btnContaCredito.FlatStyle = FlatStyle.Flat;
            btnContaCredito.UseColumnTextForButtonValue = true;
            btnContaCredito.Width = 24;

            int credIndex = grid.Columns["contaCredito"].Index;
            if (!grid.Columns.Contains("btnContaCredito"))
                grid.Columns.Insert(credIndex, btnContaCredito);

            //Adiciona botão Conta Débito.
            DataGridViewButtonColumn btnContaDebito = new DataGridViewButtonColumn();
            btnContaDebito.Name = "btnContaDebito";
            btnContaDebito.HeaderText = "";
            btnContaDebito.Text = "...";
            btnContaDebito.FlatStyle = FlatStyle.Flat;
            btnContaDebito.UseColumnTextForButtonValue = true;
            btnContaDebito.Width = 24;

            int debIndex = grid.Columns["contaDebito"].Index;
            if (!grid.Columns.Contains("btnContaDebito"))
                grid.Columns.Insert(debIndex, btnContaDebito);
        }


        public static bool Reiniciar = false;
        [STAThread]
        static void Main()
        {
            //Criar banco de dados, se não existente.
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }

            ApplicationConfiguration.Initialize();

            do
            {
                Reiniciar = false;
                Application.Run(new MainTab());
            }
            while (Reiniciar);
        }
    }
}