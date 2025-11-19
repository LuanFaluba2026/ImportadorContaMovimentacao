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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            importarMov = new Button();
            selectEmpresa = new Button();
            label3 = new Label();
            empresaText = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Location = new Point(212, 45);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1235, 567);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1229, 561);
            dataGridView1.TabIndex = 0;
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(161, 23);
            textBox1.TabIndex = 3;
            // 
            // importarMov
            // 
            importarMov.Location = new Point(12, 74);
            importarMov.Name = "importarMov";
            importarMov.Size = new Size(194, 35);
            importarMov.TabIndex = 5;
            importarMov.Text = "Importar Movimentos";
            importarMov.UseVisualStyleBackColor = true;
            // 
            // selectEmpresa
            // 
            selectEmpresa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            selectEmpresa.Location = new Point(12, 589);
            selectEmpresa.Name = "selectEmpresa";
            selectEmpresa.Size = new Size(30, 20);
            selectEmpresa.TabIndex = 6;
            selectEmpresa.Text = "...";
            selectEmpresa.UseVisualStyleBackColor = true;
            selectEmpresa.Click += selectEmpresa_Click;
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
            // empresaText
            // 
            empresaText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            empresaText.AutoSize = true;
            empresaText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            empresaText.Location = new Point(48, 592);
            empresaText.Name = "empresaText";
            empresaText.Size = new Size(87, 15);
            empresaText.TabIndex = 8;
            empresaText.Text = "1072 - Plamev";
            empresaText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 624);
            Controls.Add(empresaText);
            Controls.Add(label3);
            Controls.Add(selectEmpresa);
            Controls.Add(importarMov);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            MinimumSize = new Size(800, 600);
            Name = "MainTab";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importador Contas e Movimentos";
            WindowState = FormWindowState.Maximized;
            Load += MainTab_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button importarMov;
        private Button selectEmpresa;
        private Label label3;
        private Label empresaText;
    }
}
