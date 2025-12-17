using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using ImportadorContaMovimentacao.Forms;
using SixLabors.Fonts;
using System.Security.Cryptography;

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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS ContasAtivas(numConta INTEGER NOT NULL, nomeConta TEXT NOT NULL, contaAnalitica TEXT, PRIMARY KEY(numConta, nomeConta))";
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static void AddContas(string tabela, ContaPassiva conta)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    if(!String.IsNullOrEmpty(tabela))
                    {
                        cmd.CommandText = $"INSERT OR IGNORE INTO {tabela}(numConta, nomeConta, contaAnalitica) VALUES (@NumConta, @NomeConta, @ContaAnalitica)";
                        cmd.Parameters.AddWithValue("@NumConta", conta.numConta);
                        cmd.Parameters.AddWithValue("@NomeConta", conta.nomeConta);
                        cmd.Parameters.AddWithValue("@ContaAnalitica", conta.contaAnalitica);
                        cmd.ExecuteNonQuery();
                    }
                }
            }catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public static void GerenciarCadastros()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    List<int> contas = new();
                    cmd.CommandText = "SELECT * From ContasPassivas";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            contas.Add(Convert.ToInt32(reader["numConta"]));
                        }
                    }
                    if (contas.Count == 0)
                        MostrarAviso("Banco não possuí nenhum cadastro das Contas Passivas. Deseja realizar uma importação?", 0);
                    /*
                    contas.Clear();
                    cmd.CommandText = "SELECT * From ContasAtivas";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contas.Add(Convert.ToInt32(reader["numConta"]));
                        }
                    }
                    if (contas.Count == 0)
                        MostrarAviso("Banco não possuí nenhum cadastro das Contas Ativas. Deseja realizar uma importação?", 1);*/

                }
            }catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        // 0 - Conta Passiva 1 - Conta Ativa
        static void MostrarAviso(string msg, int tipo)
        {
            var msgBox = MessageBox.Show(msg, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (msgBox == DialogResult.Yes && tipo == 0)
            {
                ImportadorContaPassiva form = new();
                form.ShowDialog();
            }else if(msgBox == DialogResult.Yes && tipo == 1)
            {
                ImportadorContaAtiva form = new();
                form.ShowDialog();
            }
            else
                return;
        }

        public static List<ContaPassiva> GetContasPassivas()
        {
            List<ContaPassiva> list = new();
            try
            {
                using(var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ContasPassivas";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ContaPassiva()
                            {
                                numConta = (long)reader["numConta"],
                                nomeConta = reader["nomeConta"].ToString(),
                                contaAnalitica = reader["contaAnalitica"].ToString()
                            });
                        }
                        return list;
                    }
                }
            }catch(Exception ex)
            {
                Program.ShowError(ex);
                throw new Exception(ex.Message);
            }
        }
        public static List<ContaPassiva> GetContasAtivas()
        {
            List<ContaPassiva> list = new();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ContasAtivas";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ContaPassiva()
                            {
                                numConta = (int)reader["numConta"],
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
