using ImportadorContaMovimentacao.Forms.Gerenciador_de_Empresas;
using ImportadorContaMovimentacao.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportadorContaMovimentacao.Forms
{
    public partial class GerenciarEmpresas : Form
    {
        bool selecionouEmpresa = false;
        public static string selected = "";
        public GerenciarEmpresas()
        {
            InitializeComponent();
            ListarEmpresas();
        }
        private void ListarEmpresas()
        {
            List<EmpresasCadastradas> listaEmpresas = DBConfig.GetEmpresas();
            empresasGV.DataSource = null;
            empresasGV.DataSource = listaEmpresas;
            empresasGV.Columns["nomeEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            empresasGV.ClearSelection();
        }

        private void GerenciarEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing && !selecionouEmpresa)
                Application.Exit();
        }

        private void AdicionarBTTN_Click(object sender, EventArgs e)
        {
            AdicionarEmpresa adcEmp = new AdicionarEmpresa();
            adcEmp.ShowDialog();
            DBConfig.CriarTabela();
            ListarEmpresas();
        }

        private void removerBTTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (empresasGV.SelectedRows.Count > 0)
                {
                    var num = empresasGV.SelectedRows[0].Cells["numEmpresa"].Value.ToString();
                    var nome = empresasGV.SelectedRows[0].Cells["nomeEmpresa"].Value.ToString();
                    var erp = empresasGV.SelectedRows[0].Cells["erpSelecionado"].Value.ToString();

                    DBConfig.RemoverBanco(new EmpresasCadastradas
                    {
                        numEmpresa = num,
                        nomeEmpresa = nome,
                        erpSelecionado = char.Parse(erp ?? "")
                    });
                    ListarEmpresas();
                }
                else
                {
                    throw new Exception("Selecione a empresa que você deseja remover.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }

        }

        private void empresasGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (empresasGV.SelectedRows.Count > 0)
                {
                    var num = empresasGV.SelectedRows[0].Cells["numEmpresa"].Value.ToString();
                    var nome = empresasGV.SelectedRows[0].Cells["nomeEmpresa"].Value.ToString();
                    var erp = empresasGV.SelectedRows[0].Cells["erpSelecionado"].Value.ToString();
                    DBConfig.dbPath = Path.Combine(Program.dbPath, $"{num}_{nome}_{erp}.sqlite");
                    selecionouEmpresa = true;

                    selected = $"{num} - {nome} - {erp}";
                    if (selected.Length > 20)
                        selected = selected.Substring(0, 20).Insert(20, "...");

                    DBConfig.GerenciarCadastros();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
    }
}
