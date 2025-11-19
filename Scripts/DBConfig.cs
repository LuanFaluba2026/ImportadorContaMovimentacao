using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;

namespace ImportadorContaMovimentacao.Scripts
{
    public class DBConfig
    {
        private static SQLiteConnection? sqliteConnection;

        public static string dbPath = "";
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection($"Data Source={dbPath}; Version=3");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static List<EmpresasCadastradas> GetEmpresas()
        {
            string path = Program.dbPath;
            string[] files = Directory.GetFiles(path, "*.sqlite");
            List<EmpresasCadastradas> empresas = new List<EmpresasCadastradas>();
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                string[] reg = fileName.Split('_'); 
                empresas.Add(new EmpresasCadastradas
                {
                    numEmpresa = reg[0],
                    nomeEmpresa = reg[1],
                    erpSelecionado = Convert.ToChar(reg[2])
                });
            }
            return empresas;
        }
        public static void CriarBanco(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    SQLiteConnection.CreateFile(path);
                    dbPath = path;
                }

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static void RemoverBanco(EmpresasCadastradas empresa)
        {
            try{
                string path = Path.Combine(Program.dbPath, $"{empresa.numEmpresa}_{empresa.nomeEmpresa}_{empresa.erpSelecionado}.sqlite");
                Debug.WriteLine(path);
                if (File.Exists(path))
                    File.Delete(path);
            }catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static void CriarTabela()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT  EXISTS ContasPassivas (numConta INTEGER NOT NULL, nomeConta TEXT NOT NULL, contaAnalitica TEXT, PRIMARY KEY(numConta, nomeConta))";
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
    }
}
