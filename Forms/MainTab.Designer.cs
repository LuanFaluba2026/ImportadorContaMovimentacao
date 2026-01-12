namespace ImportadorContaMovimentacao
{
    partial class MainTab
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            movGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            pathTB = new TextBox();
            importarMovBTTN = new Button();
            selectEmpresaBTTN = new Button();
            label3 = new Label();
            empresaLB = new Label();
            selectPathBTTN = new Button();
            panel1 = new Panel();
            contaDiversosTB = new TextBox();
            BuscarContasPassivasBTTN = new Button();
            contaDiversosLB = new Label();
            label4 = new Label();
            label5 = new Label();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            contasCadastradasToolStripMenuItem = new ToolStripMenuItem();
            ProcessarBTTN = new Button();
            undoBTTN = new Button();
            label6 = new Label();
            xmlCheck = new CheckBox();
            planCheck = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(movGridView, 0, 0);
            tableLayoutPanel1.Location = new Point(215, 45);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1283, 567);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // movGridView
            // 
            movGridView.AllowUserToAddRows = false;
            movGridView.AllowUserToDeleteRows = false;
            movGridView.AllowUserToResizeRows = false;
            movGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movGridView.Location = new Point(3, 3);
            movGridView.MultiSelect = false;
            movGridView.Name = "movGridView";
            movGridView.RowHeadersVisible = false;
            movGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            movGridView.Size = new Size(1277, 561);
            movGridView.TabIndex = 0;
            movGridView.CellBeginEdit += movGridView_CellBeginEdit;
            movGridView.CellContentClick += movGridView_CellContentClick;
            movGridView.CellEndEdit += movGridView_CellEndEdit;
            movGridView.CellEnter += movGridView_CellEnter;
            movGridView.CellFormatting += movGridView_CellFormatting;
            movGridView.CellValidated += movGridView_CellValidated;
            movGridView.KeyDown += movGridView_KeyDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1300, 25);
            label1.Name = "label1";
            label1.Size = new Size(198, 15);
            label1.TabIndex = 1;
            label1.Text = "(F1) - Pesquisar (F2) - Aplicar Abaixo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 2;
            label2.Text = "Processar Planilha";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pathTB
            // 
            pathTB.Location = new Point(12, 63);
            pathTB.Name = "pathTB";
            pathTB.Size = new Size(161, 23);
            pathTB.TabIndex = 3;
            // 
            // importarMovBTTN
            // 
            importarMovBTTN.Location = new Point(9, 114);
            importarMovBTTN.Name = "importarMovBTTN";
            importarMovBTTN.Size = new Size(194, 35);
            importarMovBTTN.TabIndex = 5;
            importarMovBTTN.Text = "Importar Movimentos";
            importarMovBTTN.UseVisualStyleBackColor = true;
            importarMovBTTN.Click += importarMovBTTN_Click;
            // 
            // selectEmpresaBTTN
            // 
            selectEmpresaBTTN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            selectEmpresaBTTN.Location = new Point(12, 589);
            selectEmpresaBTTN.Name = "selectEmpresaBTTN";
            selectEmpresaBTTN.Size = new Size(30, 20);
            selectEmpresaBTTN.TabIndex = 6;
            selectEmpresaBTTN.Text = "...";
            selectEmpresaBTTN.UseVisualStyleBackColor = true;
            selectEmpresaBTTN.Click += selectEmpresa_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(12, 571);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 7;
            label3.Text = "Empresa Selecionada:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // empresaLB
            // 
            empresaLB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            empresaLB.AutoEllipsis = true;
            empresaLB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            empresaLB.Location = new Point(48, 592);
            empresaLB.Name = "empresaLB";
            empresaLB.Size = new Size(147, 15);
            empresaLB.TabIndex = 8;
            empresaLB.Text = "xxxxxxxxxxxxxxxxxxxx";
            empresaLB.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // selectPathBTTN
            // 
            selectPathBTTN.Location = new Point(176, 63);
            selectPathBTTN.Name = "selectPathBTTN";
            selectPathBTTN.Size = new Size(27, 23);
            selectPathBTTN.TabIndex = 9;
            selectPathBTTN.Text = "...";
            selectPathBTTN.UseVisualStyleBackColor = true;
            selectPathBTTN.Click += selectPathBTTN_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(4, 158);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 3);
            panel1.TabIndex = 10;
            // 
            // contaDiversosTB
            // 
            contaDiversosTB.Location = new Point(45, 214);
            contaDiversosTB.Name = "contaDiversosTB";
            contaDiversosTB.Size = new Size(44, 23);
            contaDiversosTB.TabIndex = 11;
            // 
            // BuscarContasPassivasBTTN
            // 
            BuscarContasPassivasBTTN.Location = new Point(12, 214);
            BuscarContasPassivasBTTN.Name = "BuscarContasPassivasBTTN";
            BuscarContasPassivasBTTN.Size = new Size(27, 23);
            BuscarContasPassivasBTTN.TabIndex = 12;
            BuscarContasPassivasBTTN.Text = "...";
            BuscarContasPassivasBTTN.UseVisualStyleBackColor = true;
            BuscarContasPassivasBTTN.Click += BuscarContasPassivasBTTN_Click;
            // 
            // contaDiversosLB
            // 
            contaDiversosLB.AutoEllipsis = true;
            contaDiversosLB.Location = new Point(95, 217);
            contaDiversosLB.Name = "contaDiversosLB";
            contaDiversosLB.Size = new Size(117, 15);
            contaDiversosLB.TabIndex = 13;
            contaDiversosLB.Text = "* Não Encontrado *";
            contaDiversosLB.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 196);
            label4.Name = "label4";
            label4.Size = new Size(173, 15);
            label4.TabIndex = 14;
            label4.Text = "Conta \"Fornecedores Diversos\":";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 170);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 15;
            label5.Text = "Parametros";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1510, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { contasCadastradasToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(94, 20);
            toolStripMenuItem1.Text = "Gerenciadores";
            // 
            // contasCadastradasToolStripMenuItem
            // 
            contasCadastradasToolStripMenuItem.Name = "contasCadastradasToolStripMenuItem";
            contasCadastradasToolStripMenuItem.Size = new Size(178, 22);
            contasCadastradasToolStripMenuItem.Text = "Contas Cadastradas";
            contasCadastradasToolStripMenuItem.Click += contasCadastradasToolStripMenuItem_Click;
            // 
            // ProcessarBTTN
            // 
            ProcessarBTTN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProcessarBTTN.Location = new Point(9, 533);
            ProcessarBTTN.Name = "ProcessarBTTN";
            ProcessarBTTN.Size = new Size(194, 35);
            ProcessarBTTN.TabIndex = 5;
            ProcessarBTTN.Text = "Processar";
            ProcessarBTTN.UseVisualStyleBackColor = true;
            ProcessarBTTN.Click += ProcessarBTTN_Click;
            // 
            // undoBTTN
            // 
            undoBTTN.Location = new Point(218, 20);
            undoBTTN.Name = "undoBTTN";
            undoBTTN.Size = new Size(24, 23);
            undoBTTN.TabIndex = 17;
            undoBTTN.Text = "<";
            undoBTTN.UseVisualStyleBackColor = true;
            undoBTTN.Click += undoBTTN_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(242, 25);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 18;
            label6.Text = "Desfazer";
            // 
            // xmlCheck
            // 
            xmlCheck.AutoSize = true;
            xmlCheck.Checked = true;
            xmlCheck.CheckState = CheckState.Checked;
            xmlCheck.Location = new Point(12, 92);
            xmlCheck.Name = "xmlCheck";
            xmlCheck.Size = new Size(50, 19);
            xmlCheck.TabIndex = 19;
            xmlCheck.Text = "XML";
            xmlCheck.UseVisualStyleBackColor = true;
            xmlCheck.CheckedChanged += xmlCheck_CheckedChanged;
            // 
            // planCheck
            // 
            planCheck.AutoSize = true;
            planCheck.Location = new Point(80, 92);
            planCheck.Name = "planCheck";
            planCheck.Size = new Size(93, 19);
            planCheck.TabIndex = 19;
            planCheck.Text = "Planilha Sieg";
            planCheck.UseVisualStyleBackColor = true;
            planCheck.CheckedChanged += planCheck_CheckedChanged;
            // 
            // MainTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 624);
            Controls.Add(planCheck);
            Controls.Add(xmlCheck);
            Controls.Add(label6);
            Controls.Add(undoBTTN);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(contaDiversosLB);
            Controls.Add(BuscarContasPassivasBTTN);
            Controls.Add(contaDiversosTB);
            Controls.Add(label2);
            Controls.Add(selectPathBTTN);
            Controls.Add(panel1);
            Controls.Add(pathTB);
            Controls.Add(empresaLB);
            Controls.Add(ProcessarBTTN);
            Controls.Add(importarMovBTTN);
            Controls.Add(label3);
            Controls.Add(selectEmpresaBTTN);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 600);
            Name = "MainTab";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importador Contas e Movimentos";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView movGridView;
        private Label label1;
        private Label label2;
        private TextBox pathTB;
        private Button selectPathBTTN;
        private Button importarMovBTTN;
        private Button selectEmpresaBTTN;
        private Label label3;
        private Label empresaLB;
        private Panel panel1;
        private TextBox contaDiversosTB;
        private Button BuscarContasPassivasBTTN;
        private Label contaDiversosLB;
        private Label label4;
        private Label label5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem contasCadastradasToolStripMenuItem;
        private Button ProcessarBTTN;
        private Button undoBTTN;
        private Label label6;
        private CheckBox xmlCheck;
        private CheckBox planCheck;
    }
}
