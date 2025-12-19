using ImportadorContaMovimentacao.Forms;
using ImportadorContaMovimentacao.Forms.Consultas;
using ImportadorContaMovimentacao.Forms.Gerenciador_de_Empresas;

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
        public static int contaFornecedoresDiversos;

        public static void AtualizarFornecedoresDiversos()
        {

        }
        public static void GerenciarContas()
        {
            GerenciadorContas form = new();
            form.ShowDialog();
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