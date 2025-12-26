using ClosedXML.Excel;
using ImportadorContaMovimentacao.Forms;

namespace ImportadorContaMovimentacao.Scripts
{
    public static class GerarResultado
    {
        public static void ProcessarMovimentos(List<Movimento> movimentos)
        {
            string[] empresa = GerenciarEmpresas.selected.Split(" - ");
            char sistema = char.Parse(empresa[2]);

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Relatório Fornecedores");
            for (int i = 0; i < movimentos.Count; i++)
            {

                int x = i + 1;
                if (sistema == 'D')
                {
                    ws.Row(x).Cell("A").Value = movimentos[i].dataMovimento;
                    ws.Row(x).Cell("B").Value = movimentos[i].contaDebito;
                    ws.Row(x).Cell("C").Value = movimentos[i].contaCredito;
                    ws.Row(x).Cell("D").Value = movimentos[i].valorMovimento;
                    ws.Row(x).Cell("F").Value = movimentos[i].historico;
                    ws.Row(x).Cell("G").Value = "1";
                    ws.Row(x).Cell("H").Value = empresa[0];
                }
                else if (sistema == 'S')
                {
                    ws.Row(x).Cell("A").Value = movimentos[i].dataMovimento;
                    ws.Row(x).Cell("B").Value = movimentos[i].contaDebito;
                    ws.Row(x).Cell("C").Value = movimentos[i].contaCredito;
                    ws.Row(x).Cell("D").Value = movimentos[i].valorMovimento;
                    ws.Row(x).Cell("F").Value = movimentos[i].historico;
                    ws.Row(x).Cell("G").Value = "1";
                    ws.Row(x).Cell("H").Value = empresa[0];
                    ws.Row(x).Cell("I").Value = movimentos[i].cnpj;
                }

                //Ligação de Fornecedores:
                Fornecedor fornecedor = DBConfig.GetFornecedores().FirstOrDefault(x => x.nome.Equals(movimentos[i].fornecedor)) ?? new Fornecedor();
                
                var requisitoLigação = MessageBox.Show("Deseja ligar os fornecedores atuais com suas respectivas contas?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (requisitoLigação == DialogResult.Yes)
                {
                    DBConfig.UpdateFornecedor(new Fornecedor()
                    {
                        ID = fornecedor.ID,
                        contaDebito = null,
                        contaCredito = movimentos[i].contaCredito
                    });
                }
            }

            string path = Path.Combine(Program.downloadsPath, $"Importar-Fornecedores{DateTime.Now.ToString("dd-MM-yy_hh-mm-ss")}.xlsx");
            wb.SaveAs(path);
        }
    }
}
