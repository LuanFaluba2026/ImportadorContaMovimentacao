namespace ImportadorContaMovimentacao.Forms.Consultas
{
    partial class GerenciadorContas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            contasGridView = new DataGridView();
            pesquisaTB = new TextBox();
            label1 = new Label();
            selecFiltroCMB = new ComboBox();
            grupoTB = new TextBox();
            filtrarGrupoCB = new CheckBox();
            consultaGrupoBTTN = new Button();
            addBTTN = new Button();
            removeBTTN = new Button();
            ((System.ComponentModel.ISupportInitialize)contasGridView).BeginInit();
            SuspendLayout();
            // 
            // contasGridView
            // 
            contasGridView.AllowUserToAddRows = false;
            contasGridView.AllowUserToDeleteRows = false;
            contasGridView.AllowUserToOrderColumns = true;
            contasGridView.AllowUserToResizeRows = false;
            contasGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            contasGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contasGridView.Location = new Point(271, 12);
            contasGridView.Name = "contasGridView";
            contasGridView.ReadOnly = true;
            contasGridView.RowHeadersVisible = false;
            contasGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contasGridView.Size = new Size(752, 468);
            contasGridView.TabIndex = 0;
            contasGridView.CellDoubleClick += contasGridView_CellDoubleClick;
            contasGridView.CellFormatting += contasGridView_CellFormatting;
            // 
            // pesquisaTB
            // 
            pesquisaTB.Location = new Point(12, 27);
            pesquisaTB.Name = "pesquisaTB";
            pesquisaTB.Size = new Size(152, 23);
            pesquisaTB.TabIndex = 1;
            pesquisaTB.TextChanged += pesquisaTB_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 2;
            label1.Text = "Pesquisa:";
            // 
            // selecFiltroCMB
            // 
            selecFiltroCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            selecFiltroCMB.FormattingEnabled = true;
            selecFiltroCMB.Items.AddRange(new object[] { "numConta", "nomeConta" });
            selecFiltroCMB.Location = new Point(170, 27);
            selecFiltroCMB.Name = "selecFiltroCMB";
            selecFiltroCMB.Size = new Size(95, 23);
            selecFiltroCMB.TabIndex = 3;
            // 
            // grupoTB
            // 
            grupoTB.Enabled = false;
            grupoTB.Location = new Point(110, 56);
            grupoTB.Name = "grupoTB";
            grupoTB.Size = new Size(122, 23);
            grupoTB.TabIndex = 1;
            grupoTB.TextChanged += grupoTB_TextChanged;
            // 
            // filtrarGrupoCB
            // 
            filtrarGrupoCB.AutoSize = true;
            filtrarGrupoCB.Location = new Point(12, 59);
            filtrarGrupoCB.Name = "filtrarGrupoCB";
            filtrarGrupoCB.Size = new Size(92, 19);
            filtrarGrupoCB.TabIndex = 4;
            filtrarGrupoCB.Text = "Filtrar Grupo";
            filtrarGrupoCB.UseVisualStyleBackColor = true;
            filtrarGrupoCB.CheckedChanged += filtrarGrupoCB_CheckedChanged;
            // 
            // consultaGrupoBTTN
            // 
            consultaGrupoBTTN.Enabled = false;
            consultaGrupoBTTN.Location = new Point(238, 56);
            consultaGrupoBTTN.Name = "consultaGrupoBTTN";
            consultaGrupoBTTN.Size = new Size(27, 23);
            consultaGrupoBTTN.TabIndex = 5;
            consultaGrupoBTTN.Text = "...";
            consultaGrupoBTTN.UseVisualStyleBackColor = true;
            // 
            // addBTTN
            // 
            addBTTN.Location = new Point(854, 484);
            addBTTN.Name = "addBTTN";
            addBTTN.Size = new Size(75, 23);
            addBTTN.TabIndex = 6;
            addBTTN.Text = "Adicionar";
            addBTTN.UseVisualStyleBackColor = true;
            addBTTN.Click += addBTTN_Click;
            // 
            // removeBTTN
            // 
            removeBTTN.Location = new Point(935, 484);
            removeBTTN.Name = "removeBTTN";
            removeBTTN.Size = new Size(75, 23);
            removeBTTN.TabIndex = 6;
            removeBTTN.Text = "Remover";
            removeBTTN.UseVisualStyleBackColor = true;
            // 
            // GerenciadorContas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 512);
            Controls.Add(removeBTTN);
            Controls.Add(addBTTN);
            Controls.Add(consultaGrupoBTTN);
            Controls.Add(filtrarGrupoCB);
            Controls.Add(selecFiltroCMB);
            Controls.Add(label1);
            Controls.Add(grupoTB);
            Controls.Add(pesquisaTB);
            Controls.Add(contasGridView);
            MaximumSize = new Size(1051, 10000);
            MinimumSize = new Size(1051, 0);
            Name = "GerenciadorContas";
            Text = "Gerenciador de Contas";
            ((System.ComponentModel.ISupportInitialize)contasGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView contasGridView;
        private TextBox pesquisaTB;
        private Label label1;
        private ComboBox selecFiltroCMB;
        private TextBox grupoTB;
        private CheckBox filtrarGrupoCB;
        private Button consultaGrupoBTTN;
        private Button addBTTN;
        private Button removeBTTN;
    }
}