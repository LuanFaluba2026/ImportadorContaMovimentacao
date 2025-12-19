using ImportadorContaMovimentacao.Forms;
using ImportadorContaMovimentacao.Forms.Consultas;
using ImportadorContaMovimentacao.Forms.Gerenciador_de_Empresas;
using System.Runtime.CompilerServices;

namespace ImportadorContaMovimentacao.Scripts
{
    internal static class Program
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "DbContas");
        public static void ShowError(Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message, "Erro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        //Parametros
        public static string contaFornecedoresDiversos;

        public static void AtualizarFornecedoresDiversos()
        {
            contaFornecedoresDiversos = DBConfig.GetContas()?.FirstOrDefault(x => x.nomeConta.Contains("Fornecedores Diversos", StringComparison.OrdinalIgnoreCase) && x.tipo != "S")?.numConta ?? "";
        }
        public static void GerenciarContas()
        {
            GerenciadorContas form = new();
            form.ChamarFiltro("21101");
            form.ShowDialog();
        }

        //Grids
        //parametors da grid de contas 
        public static void ContasGridViewConfig(DataGridView grid)
        {
            grid.AutoResizeColumns();
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.Columns["nomeConta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        [STAThread]
        static void Main()
        {
            //Criar banco de dados, se não existente.
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainTab());
        }
    }
}