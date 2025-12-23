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
            try
            {
                string path = Path.Combine(Program.dbPath, $"{empresa.numEmpresa}_{empresa.nomeEmpresa}_{empresa.erpSelecionado}.sqlite");
                Debug.WriteLine(path);
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Contas (id INTEGER PRIMARY KEY AUTOINCREMENT, numConta TEXT NOT NULL, tipo TEXT NOT NULL, nomeConta TEXT NOT NULL, contaAnalitica TEXT, UNIQUE(numConta, nomeConta))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Fornecedores (id INTEGER PRIMARY KEY AUTOINCREMENT, cnpj TEXT NOT NULL, nome TEXT NOT NULL, contaDebito TEXT, contaCredito TEXT, UNIQUE(cnpj))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static void InsertFornecedores(Fornecedores forn)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT OR IGNORE INTO Fornecedores (cnpj, nome, contaDebito, contaCredito) VALUES (@Cnpj, @Nome, @ContaDebito, @ContaCredito)";
                    cmd.Parameters.AddWithValue("@Cnpj", forn.cnpj);
                    cmd.Parameters.AddWithValue("@Nome", forn.nome);
                    cmd.Parameters.AddWithValue("@ContaDebito", forn.contaDebito);
                    cmd.Parameters.AddWithValue("@ContaCredito", forn.contaCredito);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static void InsertContas(Conta conta)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"INSERT OR IGNORE INTO Contas (numConta, tipo, nomeConta, contaAnalitica) VALUES (@NumConta, @Tipo, @NomeConta, @ContaAnalitica)";
                    cmd.Parameters.AddWithValue("@NumConta", conta.numConta);
                    cmd.Parameters.AddWithValue("@Tipo", conta.tipo);
                    cmd.Parameters.AddWithValue("@NomeConta", conta.nomeConta);
                    cmd.Parameters.AddWithValue("@ContaAnalitica", conta.contaAnalitica);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static List<Conta> GetContas()
        {
            List<Conta> list = new();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Contas";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Conta()
                            {
                                numConta = reader["numConta"].ToString(),
                                tipo = reader["tipo"].ToString(),
                                nomeConta = reader["nomeConta"].ToString(),
                                contaAnalitica = reader["contaAnalitica"].ToString()
                            });
                        }
                        return list;
                    }
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
