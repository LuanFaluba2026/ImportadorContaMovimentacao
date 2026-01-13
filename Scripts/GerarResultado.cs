using ClosedXML.Excel;
using ImportadorContaMovimentacao.Forms;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ImportadorContaMovimentacao.Scripts
{
    public class FornecedorLigar
    {
        public long ID { get; set; }
        public string? contaCredito { get; set; }
        public string? contaDebito { get; set; }
        
    }
    public class GerarResultado
    {
        public void ProcessarMovimentos(List<Movimento> movimentos)
        {

            string[] empresa = GerenciarEmpresas.selected.Split(" - ");
            char sistema = char.Parse(empresa[2]);

            if (sistema == 'D')
            {
                GerarDominio(movimentos, empresa[0]);
            }
            else if (sistema == 'S')
            {
                GerarSenior(movimentos, empresa[0]);
            }
        }
        public void GerarDominio(List<Movimento> movimentos, string empresa)
        {
            try
            {
                if (movimentos == null || movimentos.Count == 0)
                    throw new Exception("Nenhum movimento selecionado.");

                List<FornecedorLigar> forn = new();
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Relatório Fornecedores");
                for (int i = 0; i < movimentos.Count; i++)
                {

                    int x = i + 1;
                    ws.Row(x).Cell("A").Value = movimentos[i].dataMovimento;
                    ws.Row(x).Cell("B").Value = movimentos[i].contaDebito;
                    ws.Row(x).Cell("C").Value = movimentos[i].contaCredito;
                    ws.Row(x).Cell("D").Value = movimentos[i].valorMovimento;
                    ws.Row(x).Cell("F").Value = movimentos[i].historico;
                    ws.Row(x).Cell("G").Value = "1";
                    ws.Row(x).Cell("H").Value = empresa;

                    //Ligação de Fornecedores:
                    Fornecedor fornecedor = DBConfig.GetFornecedores().FirstOrDefault(x => x.cnpj.Equals(movimentos[i].cnpj)) ?? new Fornecedor();
                    forn.Add(new FornecedorLigar()
                    {
                        ID = fornecedor.ID,
                        contaCredito = movimentos[i].contaCredito,
                        contaDebito = movimentos[i].contaDebito
                    });
                }

                var requisitoLigacao = MessageBox.Show("Deseja ligar os fornecedores atuais com suas respectivas contas?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (requisitoLigacao == DialogResult.Yes)
                { 
                    LigarFornecedores(forn);
                    MessageBox.Show("Vinculo Fornecedores X Contas Contábeis criado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FolderBrowserDialog fbd = new();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.Combine(fbd.SelectedPath, $"Importar-Fornecedores{DateTime.Now.ToString("dd-MM-yy_hh-mm-ss")}.xlsx");
                    wb.SaveAs(path);
                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Selecione uma pasta válida.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        public void GerarSenior(List<Movimento> movimentos, string empresa)
        {
            try
            {
                if (movimentos == null || movimentos.Count == 0)
                    throw new Exception("Nenhum movimento selecionado.");

                List<string> registros = new();
                List<FornecedorLigar> forn = new();
                foreach (Movimento mov in movimentos)
                {
                    registros.Add($"{empresa};1;{mov.dataMovimento.ToString("dd/MM/yyyy")};{mov.contaDebito};{mov.contaCredito};{mov.valorMovimento};;{mov.historico};{mov.cnpj}");

                    //Ligação de Fornecedores:
                    Fornecedor fornecedor = DBConfig.GetFornecedores().FirstOrDefault(x => x.cnpj.Equals(mov.cnpj)) ?? new Fornecedor();
                    forn.Add(new FornecedorLigar()
                    {
                        ID = fornecedor.ID,
                        contaCredito = mov.contaCredito,
                        contaDebito = mov.contaDebito
                    });
                }
                if (registros.Count == 0)
                    return;

                var requisitoLigacao = MessageBox.Show("Deseja ligar os fornecedores atuais com suas respectivas contas?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (requisitoLigacao == DialogResult.Yes)
                {
                    LigarFornecedores(forn);
                    MessageBox.Show("Vinculo Fornecedores X Contas Contábeis criado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FolderBrowserDialog fbd = new();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.Combine(fbd.SelectedPath, $"Importar-Fornecedores{DateTime.Now.ToString("dd-MM-yy_hh-mm-ss")}.csv");
                    File.WriteAllLines(path, registros);
                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Selecione uma pasta válida.");
                }
            }
            catch(Exception ex)
            {
                Program.ShowError(ex);
            }
            
        }
        private void LigarFornecedores(List<FornecedorLigar> forns)
        {
            foreach(FornecedorLigar forn in forns)
            {
                DBConfig.UpdateFornecedor(new Fornecedor()
                {
                    ID = forn.ID,
                    contaDebito = forn.contaDebito,
                    contaCredito = forn.contaCredito
                });
            }
        }
    }
}
