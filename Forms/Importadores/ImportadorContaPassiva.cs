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
    public partial class ImportadorContaPassiva : Form
    {
        string path = "";
        string selected = GerenciarEmpresas.selected;
        public ImportadorContaPassiva()
        {
            InitializeComponent();
            empresaLB.Text = selected;
        }

        private void selectPathBTTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Planilha de contas passívas. (*.xlsx) |*.xlsx";
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
                var wb = new XLWorkbook(path);
                var ws = wb.Worksheet(1);

                Cursor.Current = Cursors.WaitCursor;
                foreach(var row in ws.RowsUsed().Skip(1))
                {
                    if(row.Cell("Q").Value.ToString() == "A")
                    {
                        int num = (int)row.Cell("N").Value;
                        string nome = row.Cell("P").Value.ToString();
                        string contaAnalitica = row.Cell("O").Value.ToString();
                        ContaPassiva conta = new ContaPassiva
                        {
                            numConta = num,
                            nomeConta = nome,
                            contaAnalitica = !String.IsNullOrEmpty(contaAnalitica) ? contaAnalitica : ""
                        };
                        DBConfig.AddContas("ContasPassivas", conta);
                    }
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
