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
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movGridView).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(movGridView, 0, 0);
            tableLayoutPanel1.Location = new Point(212, 45);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1235, 567);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // movGridView
            // 
            movGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movGridView.Location = new Point(3, 3);
            movGridView.Name = "movGridView";
            movGridView.Size = new Size(1229, 561);
            movGridView.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(215, 27);
            label1.Name = "label1";
            label1.Size = new Size(200, 15);
            label1.TabIndex = 1;
            label1.Text = "(F2) Preencher todos - (F3) Pesquisar";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 27);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 2;
            label2.Text = "Caminho Planilha:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pathTB
            // 
            pathTB.Location = new Point(12, 45);
            pathTB.Name = "pathTB";
            pathTB.Size = new Size(161, 23);
            pathTB.TabIndex = 3;
            // 
            // importarMovBTTN
            // 
            importarMovBTTN.Location = new Point(12, 74);
            importarMovBTTN.Name = "importarMovBTTN";
            importarMovBTTN.Size = new Size(194, 35);
            importarMovBTTN.TabIndex = 5;
            importarMovBTTN.Text = "Importar Movimentos";
            importarMovBTTN.UseVisualStyleBackColor = true;
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
            empresaLB.AutoSize = true;
            empresaLB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            empresaLB.Location = new Point(48, 592);
            empresaLB.Name = "empresaLB";
            empresaLB.Size = new Size(147, 15);
            empresaLB.TabIndex = 8;
            empresaLB.Text = "xxxxxxxxxxxxxxxxxxxx";
            empresaLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // selectPathBTTN
            // 
            selectPathBTTN.Location = new Point(179, 45);
            selectPathBTTN.Name = "selectPathBTTN";
            selectPathBTTN.Size = new Size(27, 23);
            selectPathBTTN.TabIndex = 9;
            selectPathBTTN.Text = "...";
            selectPathBTTN.UseVisualStyleBackColor = true;
            selectPathBTTN.Click += selectPathBTTN_Click;
            // 
            // MainTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 624);
            Controls.Add(selectPathBTTN);
            Controls.Add(empresaLB);
            Controls.Add(label3);
            Controls.Add(selectEmpresaBTTN);
            Controls.Add(importarMovBTTN);
            Controls.Add(pathTB);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            MinimumSize = new Size(800, 600);
            Name = "MainTab";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importador Contas e Movimentos";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movGridView).EndInit();
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
    }
}
