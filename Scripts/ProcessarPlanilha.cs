using ClosedXML.Excel;
using ImportadorContaMovimentacao.Forms;
using System.Text.RegularExpressions;

namespace ImportadorContaMovimentacao.Scripts
{
    public class ContaMatch
    {
        public int MatchQuantity { get; set; }
        public Conta? ContaSelecionada { get; set; }
    }
    public static class ProcessarPlanilha
    {
        public static string[] irrelevantes = [" com ", " prod ", " ind ", " de ", " e "];
        public static string Normalizar(string text)
        {
            string newText = text.ToLower();
            newText = newText.Replace(".", "").Replace("-", " ").Replace("/", "");
            foreach (string x in irrelevantes)
                newText = newText.Replace(x, " ");
            newText = Regex.Replace(newText, @"\s+", " ");
            return newText;
        }
        public static string[] GetTokens(string text) => text.Split(" ");
        public static Conta MatchFornecedor(string forn, List<Conta> contas)
        {
            string[] fornecedorTokens = GetTokens(Normalizar(forn));
            var contaMatch = contas.Select(conta =>
            {
                string norm = Normalizar(conta.nomeConta ?? "");
                string[] contaTokens = GetTokens(norm);

                int matches = contaTokens.Distinct(StringComparer.OrdinalIgnoreCase).Count(ct => fornecedorTokens.Contains(ct, StringComparer.OrdinalIgnoreCase));

                return new ContaMatch
                {
                    MatchQuantity = matches,
                    ContaSelecionada = conta
                };
            }).OrderByDescending(x => x.MatchQuantity).FirstOrDefault();

            return contaMatch?.MatchQuantity > 1 ? contaMatch.ContaSelecionada : contas.First(x => x.numConta == Program.contaFornecedoresDiversos);
        }


        public static List<Movimento> ProcessarMovimentos(string path)
        {
            //Colunas
            
            const string numNotaCol = "A";
            const string nomeFornecedorCol = "F";
            const string cnpjCol = "E";
            const string dataMovCol = "D";
            const string vlrMovCol = "Q";
            /*
            const string numNotaCol = "A";
            const string nomeFornecedorCol = "G";
            const string cnpjCol = "F";
            const string dataMovCol = "E";
            const string vlrMovCol = "N";
            */

            List<Movimento> movs = new();
            try
            {
                var wb = new XLWorkbook(path);
                var ws = wb.Worksheet(1);


                List<Conta> contas = DBConfig.GetContas().Where(x => x.contaAnalitica.StartsWith(Program.analiticoPassivos)).ToList();
                var rows = ws.RowsUsed().Skip(1).SkipLast(2);
                foreach (var row in rows)
                {
                    //Número da nota
                    string numNota = row.Cell(numNotaCol).Value.ToString();

                    //Busca de fornecedor
                    string fornecedorPlan = row.Cell(nomeFornecedorCol).Value.ToString();
                    Conta match = MatchFornecedor(fornecedorPlan, contas);
                    string cnpj = row.Cell(cnpjCol).Value.ToString();

                    string cnpjMatriz = rows?.FirstOrDefault(x =>
                    {
                        string cell = x.Cell("E").Value.ToString();
                        string cellStart = cell.Substring(0, 8);
                        string cellEnding = cell.Substring(8, 4);
                        return cellStart == cnpj.Substring(0, 8) && cellEnding == "0001";
                    })?.Cell("E").Value.ToString() ?? "";
                    if (!String.IsNullOrEmpty(cnpjMatriz))
                        cnpj = cnpjMatriz;
                    
                    var fornecedoresCadastrados = DBConfig.GetFornecedores().FirstOrDefault(x => x.cnpj.Equals(cnpj));
                    if (fornecedoresCadastrados != null && !String.IsNullOrEmpty(fornecedoresCadastrados.contaCredito))
                        match = DBConfig.GetContas().FirstOrDefault(x => x.numConta == fornecedoresCadastrados.contaCredito);

                    //Busca de Contas contábeis.
                    string contaCred = match.numConta;
                    string descricaoCred = match.nomeConta ?? " -** Não encontrada.";
                    string contaDeb = ""; //Ajustar conforme CFOP.
                    string descricaoDeb = contas?.FirstOrDefault(x => contaDeb.Equals(x.numConta))?.nomeConta ?? " -** Não encontrada.";

                    //Data de emissão
                    DateTime dataMov = DateTime.Parse(row.Cell(dataMovCol).Value.ToString());
                    //Valor do movimento
                    double vlrMov = (double)row.Cell(vlrMovCol).Value;
                    //Geração de histórico padrão
                    string historico = $"VLR. REF. NF {numNota} {fornecedorPlan}";
                    //Relação de código da empresa cadastrada.
                    string codEmpresa = GerenciarEmpresas.selected.Split(" - ")[0];

                    movs.Add(new Movimento()
                    {
                        dataMovimento = dataMov,
                        contaDebito = contaDeb,
                        descricaoDebito = descricaoDeb,
                        contaCredito = GerenciarEmpresas.selected.Split(" - ")[2] == "D" ? contaCred : Program.contaFornecedoresDiversos,
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
