using ImportadorContaMovimentacao.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportadorContaMovimentacao.Forms.Consultas
{
    public partial class GerenciadorContas : Form
    {
        public GerenciadorContas()
        {
            InitializeComponent();
            ShowData(DBConfig.GetContas());
            selecFiltroCMB.SelectedIndex = 1;
        }
        public void ChamarFiltro(string filtroConta)
        {
            grupoTB.Text = filtroConta;
        }
        private void ShowData(List<Conta> dataSource)
        {
            contasGridView.DataSource = null;
            contasGridView.DataSource = dataSource;
            Program.ContasGridViewConfig(contasGridView);
        }
        private void grupoTB_TextChanged(object sender, EventArgs e)
        {
            ShowData(DBConfig.GetContas().Where(x => x.contaAnalitica.StartsWith(grupoTB.Text)).ToList());
        }
        private void contasGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (contasGridView.Rows[e.RowIndex].Cells["tipo"].Value?.ToString() == "S")
            {
                e.CellStyle.Font = new Font(contasGridView.Font, FontStyle.Bold);
                e.CellStyle.BackColor = Color.LightGray;
            }
        }
        private void filtrarGrupoCB_CheckedChanged(object sender, EventArgs e)
        {
            if (filtrarGrupoCB.Checked)
            {
                grupoTB.Enabled = true;
                consultaGrupoBTTN.Enabled = true;
            }
            else
            {
                grupoTB.Enabled = false;
                grupoTB.Text = "";
                consultaGrupoBTTN.Enabled = false;
            }
        }

        private void pesquisaTB_TextChanged(object sender, EventArgs e)
        {
            if(filtrarGrupoCB.Checked)
            {
                switch(selecFiltroCMB.Text)
                {
                    case "numConta":
                        ShowData(DBConfig.GetContas().Where(x => x.numConta.StartsWith(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase)&& x.contaAnalitica.StartsWith(grupoTB.Text)).ToList());
                        break;
                    case "nomeConta":
                        ShowData(DBConfig.GetContas().Where(x => x.nomeConta.Contains(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase) && x.contaAnalitica.StartsWith(grupoTB.Text)).ToList());
                        break;
                }
            }
            else
            {
                switch(selecFiltroCMB.Text)
                { 
                    case "numConta":
                            ShowData(DBConfig.GetContas().Where(x => x.numConta.StartsWith(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;
                    case "nomeConta":
                        ShowData(DBConfig.GetContas().Where(x => x.nomeConta.Contains(pesquisaTB.Text, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;
                }
            }
        }
    }
}
