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

namespace ImportadorContaMovimentacao.Forms.Dialogs
{
    public partial class AdicionarConta : Form
    {
        public readonly string numConta;
        public AdicionarConta()
        {
            InitializeComponent();
            numConta = numeroTB.Text;
        }
        private bool Validacao() => String.IsNullOrEmpty(nomeTB.Text) || 
            String.IsNullOrEmpty(numeroTB.Text) || 
            String.IsNullOrEmpty(analiticaTB.Text) || 
            String.IsNullOrEmpty(tipoCB.Text);

        private void includeBTTN_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBConfig.InsertContas(new Conta
            {
                numConta = numeroTB.Text,
                tipo = tipoCB.Text,
                nomeConta = nomeTB.Text,
                contaAnalitica = analiticaTB.Text
            });
            MessageBox.Show("Conta adicionada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
