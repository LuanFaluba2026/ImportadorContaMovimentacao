using ClosedXML.Excel;
using ImportadorContaMovimentacao.Forms;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ImportadorContaMovimentacao.Scripts
{
    public static class ProcessarPlanilha
    {

        static readonly string[] irrelevantes = [
            "sa", "s a", "ltda", "me", "epp",
            "com", "comercio", "comercial",
            "filial", "loja", "de", "e", "s/a",
            "online", "alimentos", "distribuidora",
            "industria", "servicos", "eireli", "tecnologia",
            "distribuicao"
            ];

        static string Normalizar(string texto)
        {
            if (String.IsNullOrEmpty(texto))
                return string.Empty;

            texto = texto.ToLowerInvariant();

            texto = texto.Normalize(NormalizationForm.FormD);
            texto = new string(texto.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());
            texto = Regex.Replace(texto, @"[^\w\s]", "");
            texto = Regex.Replace(texto, @"\s+", " ").Trim();

            foreach (var w in irrelevantes)
                texto = Regex.Replace(texto, $@"\b{w}\b", "");

            return texto;
        }
        static string[] Tokens(string texto) => texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 4).ToArray();
        static List<Conta> MatchFornecedor(string nomePlanilha, List<Conta> contas)
        {
            var pTokens = Tokens(nomePlanilha);

            if (pTokens.Length == 0)
                return new List<Conta>();

            return contas.Where(c =>
            {
                var cTokens = Tokens(Normalizar(c.nomeConta));

                if (cTokens.Length == 0)
                    return false;

                return cTokens.Count(t => pTokens.Contains(t)) >= (pTokens.Count() > 1 ? pTokens.Count() / 2 : 1);
            }).ToList();
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
                    List<Conta> matchs = MatchFornecedor(Normalizar(fornecedorPlan), contas);

                    string contaCred = matchs?.FirstOrDefault()?.numConta ?? Program.contaFornecedoresDiversos;
                    string descricaoCred = contas?.FirstOrDefault(x => contaCred.Equals(x.numConta))?.nomeConta ?? " -** Não encontrada.";
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
                        codigoEmpresa = codEmpresa
                    });

                    //Adicionar fornecedor ao banco:
                    DBConfig.InsertFornecedores(new Fornecedores()
                    {
                        cnpj = row.Cell("E").Value.ToString(),
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
