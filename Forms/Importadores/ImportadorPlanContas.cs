using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using DocumentFormat.OpenXml.Spreadsheet;
using ImportadorContaMovimentacao.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportadorContaMovimentacao.Forms
{
    public partial class ImportadorPlanContas : Form
    {
        string path = "";
        string selected = GerenciarEmpresas.selected;
        public ImportadorPlanContas()
        {
            InitializeComponent();
            empresaLB.Text = selected;
        }

        private void selectPathBTTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Planilha de Plano de Contas do Domínio. (*.xlsx) |*.xlsx| Planilha de Plano de Contas do Sênior. (*.csv) |*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                pathTB.Text = path;
            }
        }

        private void importBTNN_Click(object sender, EventArgs e)
        {
            string[] selectedSplit = selected.Split(" - ");
            if (!String.IsNullOrEmpty(path) && selectedSplit[2] == "D")
                ImportarDominio();
            else if (!String.IsNullOrEmpty(path) && selectedSplit[2] == "S")
                ImportarSenior();

            MessageBox.Show("Importação concluída com sucesso.");
        }
        private void ImportarDominio()
        {
            try
            {
                /* 
                 * Relação Colunas:
                 * Coluna N = Numero da Conta;
                 * Coluna Q = Tipo da Conta;
                 * Coluna P = Nome da Conta;
                 * Coluna O = Classificação Analítica.
                 */

                var wb = new XLWorkbook(path);
                var ws = wb.Worksheet(1);

                Cursor.Current = Cursors.WaitCursor;
                foreach(var row in ws.RowsUsed().Skip(1))
                {
                    string tipo = row.Cell("Q").Value.ToString();
                    if (String.IsNullOrEmpty(tipo))
                        continue;

                    int num = (int)row.Cell("N").Value;
                    string nome = row.Cell("P").Value.ToString();
                    string contaAnalitica = row.Cell("O").Value.ToString();

                    Conta conta = new Conta
                    {
                        numConta = num,
                        tipo = tipo,
                        nomeConta = nome,
                        contaAnalitica = !String.IsNullOrEmpty(contaAnalitica) ? contaAnalitica : ""
                    };

                    DBConfig.InsertContas(conta);
                }
            }
            catch(Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        private void ImportarSenior()
        {

        }
    }
}
