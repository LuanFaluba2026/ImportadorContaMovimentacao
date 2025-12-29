using ClosedXML.Excel;
using ImportadorContaMovimentacao.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ImportadorContaMovimentacao.Scripts
{
    public class ContaMatch
    {
        public int matchQuantity { get; set; }
        public Conta? ContaSelecionada { get; set; }
    }
    public static class ProcessarPlanilha
    {
        public static string Normalizar(string text) => text.ToLower().Replace(".", "");
        public static string[] GetTokens(string text) => text.Split(" ");
        public static Conta MatchFornecedor(string forn, List<Conta> contas)
        {
            Conta contaEscolhida = contas.First(x => x.numConta == Program.contaFornecedoresDiversos);

            List<ContaMatch> contasSelecionadas = new();

            foreach(Conta conta in contas)
            {
                string[] contaTokens = GetTokens(Normalizar(conta.nomeConta ?? ""));
                string[] fornecedorTokens = GetTokens(Normalizar(forn));
                int tokensQuantity = contaTokens.Count();
                foreach(string ct in contaTokens)
                {
                    int matchQuantity = fornecedorTokens.Where(x => x == ct).Count();
                    if (matchQuantity == tokensQuantity)
                    {
                        contasSelecionadas.Add(new ContaMatch()
                        {
                            matchQuantity = matchQuantity,
                            ContaSelecionada = contas.First(x => x.nomeConta == conta.nomeConta)
                        });
                    }
                    else if (matchQuantity < tokensQuantity)
                        tokensQuantity--;
                    else if (matchQuantity == 0)
                        break;
                }
            }
            foreach(var conta in contasSelecionadas)
            {
                if(conta.matchQuantity > 1)
                    Debug.WriteLine($"{conta.matchQuantity} - {conta.ContaSelecionada.nomeConta}");
            }
            return contaEscolhida;
        }
        public static List<Movimento> ProcessarMovimentos(string path)
        {
            List<Movimento> movs = new();
            try
            {
                var wb = new XLWorkbook(path);
                var ws = wb.Worksheet(1);


                List<Conta> contas = DBConfig.GetContas().Where(x => x.contaAnalitica.StartsWith(Program.analiticoPassivos)).ToList();
                foreach (var row in ws.RowsUsed().Skip(1).SkipLast(2))
                {
                    //distinção
                    string numNota = row.Cell("A").Value.ToString();

                    //TRIM FORNECEDOR.
                    string fornecedorPlan = row.Cell("F").Value.ToString();
                    Conta match = MatchFornecedor(fornecedorPlan, contas);
                    string cnpj = row.Cell("E").Value.ToString();

                    string contaCred = match.numConta;
                    string descricaoCred = match.nomeConta ?? " -** Não encontrada.";
                    string contaDeb = ""; //Ajustar conforme CFOP.
                    string descricaoDeb = contas?.FirstOrDefault(x => contaDeb.Equals(x.numConta))?.nomeConta ?? " -** Não encontrada.";

                    DateTime dataMov = DateTime.Parse(row.Cell("D").Value.ToString());
                    double vlrMov = (double)row.Cell("Q").Value;
                    string historico = $"VLR. REF. NF {numNota} {fornecedorPlan}";
                    string codEmpresa = GerenciarEmpresas.selected.Split(" - ")[0];

                    movs.Add(new Movimento()
                    {
                        dataMovimento = dataMov,
                        contaDebito = contaDeb,
                        descricaoDebito = descricaoDeb,
                        contaCredito = contaCred,
                        descricaoCredito = descricaoCred,
                        valorMovimento = vlrMov,
                        historico = historico,
                        codigoEmpresa = codEmpresa,
                        fornecedor = fornecedorPlan,
                        cnpj = cnpj
                    });

                    //Adicionar fornecedor ao banco:
                    DBConfig.InsertFornecedores(new Fornecedor()
                    {
                        cnpj = cnpj,
                        nome = fornecedorPlan
                    });
                }

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
            return movs;
        }
    }
}
