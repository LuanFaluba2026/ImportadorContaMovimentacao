using DocumentFormat.OpenXml.Drawing;
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

namespace ImportadorContaMovimentacao.Forms.Consultas
{
    public partial class ConsultaSimplificada : Form
    {
        public string? filtroAnalitico { get; set; }
        public ConsultaSimplificada()
        {
            InitializeComponent();
        }
        private void ConsultaSimplificada_Load(object sender, EventArgs e)
        {
            MostrarDados(DBConfig.GetContas().Where(x => x.contaAnalitica.Contains(filtroAnalitico)).ToList());
        }

        private void MostrarDados<T>(List<T> source)
        {
            dadosGridView.DataSource = null;
            dadosGridView.DataSource = source;
            Program.ContasGridViewConfig(dadosGridView);
        }

        private void dadosGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dadosGridView.Rows[e.RowIndex].Cells["tipo"].Value?.ToString() == "S")
            {
                e.CellStyle.Font = new Font(dadosGridView.Font, FontStyle.Bold);
                e.CellStyle.BackColor = Color.LightGray;
            }
        }

        public bool isClickable;
        public Conta contaSelecionada { get; private set; }
        private void dadosGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clicked = dadosGridView.Rows[e.RowIndex].Cells["numConta"].Value.ToString();
            var tipo = dadosGridView.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
            if (!String.IsNullOrEmpty(clicked) && isClickable && tipo != "S")
            {
                contaSelecionada = DBConfig.GetContas().First(x => x.numConta.Equals(clicked));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
