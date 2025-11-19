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

namespace ImportadorContaMovimentacao.Forms.Gerenciador_de_Empresas
{
    public partial class AdicionarEmpresa : Form
    {
        public AdicionarEmpresa()
        {
            InitializeComponent();
        }

        private void dominioCB_CheckedChanged(object sender, EventArgs e)
        {
            if (dominioCB.Checked)
                seniorCB.Checked = false;
        }

        private void seniorCB_CheckedChanged(object sender, EventArgs e)
        {
            if (seniorCB.Checked)
                dominioCB.Checked = false;
        }
        private void adicionarBTTN_Click(object sender, EventArgs e)
        {
            CriarEmpresa(numTB.Text, nomeTB.Text, dominioCB.Checked ? 'D' : 'S');
        }
        private void numTB_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(numTB.Text, out parsedValue))
            {
                numTB.Text = "";
            }
        }
        private void cancelarBTTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CriarEmpresa(string num, string nome, char erpSelecionado)
        {
            try
            {
                if (String.IsNullOrEmpty(num) || String.IsNullOrEmpty(nome) || (!dominioCB.Checked && !seniorCB.Checked))
                    throw new Exception("Preencha os campos.");

                string dbPath = Path.Combine(Program.dbPath, $"{num}_{nome.Replace(" ", "-")}_{erpSelecionado}.sqlite");
                DBConfig.CriarBanco(dbPath);
                this.Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
    }
}
