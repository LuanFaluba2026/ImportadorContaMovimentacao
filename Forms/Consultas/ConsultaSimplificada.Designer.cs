namespace ImportadorContaMovimentacao.Forms.Consultas
{
    partial class ConsultaSimplificada
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
            dadosGridView = new DataGridView();
            pesquisaTB = new TextBox();
            selectColunaCB = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dadosGridView).BeginInit();
            SuspendLayout();
            // 
            // dadosGridView
            // 
            dadosGridView.AllowUserToAddRows = false;
            dadosGridView.AllowUserToDeleteRows = false;
            dadosGridView.AllowUserToResizeColumns = false;
            dadosGridView.AllowUserToResizeRows = false;
            dadosGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dadosGridView.Location = new Point(12, 12);
            dadosGridView.MultiSelect = false;
            dadosGridView.Name = "dadosGridView";
            dadosGridView.ReadOnly = true;
            dadosGridView.RowHeadersVisible = false;
            dadosGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dadosGridView.Size = new Size(424, 573);
            dadosGridView.TabIndex = 0;
            dadosGridView.CellDoubleClick += dadosGridView_CellDoubleClick;
            dadosGridView.CellFormatting += dadosGridView_CellFormatting;
            // 
            // pesquisaTB
            // 
            pesquisaTB.Location = new Point(12, 593);
            pesquisaTB.Name = "pesquisaTB";
            pesquisaTB.Size = new Size(296, 23);
            pesquisaTB.TabIndex = 1;
            pesquisaTB.TextChanged += pesquisaTB_TextChanged;
            // 
            // selectColunaCB
            // 
            selectColunaCB.DropDownStyle = ComboBoxStyle.DropDownList;
            selectColunaCB.FormattingEnabled = true;
            selectColunaCB.Location = new Point(314, 593);
            selectColunaCB.Name = "selectColunaCB";
            selectColunaCB.Size = new Size(121, 23);
            selectColunaCB.TabIndex = 2;
            // 
            // ConsultaSimplificada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 628);
            Controls.Add(selectColunaCB);
            Controls.Add(pesquisaTB);
            Controls.Add(dadosGridView);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsultaSimplificada";
            Text = "Consulta Contas";
            Load += ConsultaSimplificada_Load;
            KeyDown += ConsultaSimplificada_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dadosGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dadosGridView;
        private TextBox pesquisaTB;
        private ComboBox selectColunaCB;
    }
}