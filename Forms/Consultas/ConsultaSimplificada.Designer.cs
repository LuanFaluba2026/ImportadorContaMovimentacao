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
            textBox1 = new TextBox();
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
            dadosGridView.RowHeadersVisible = false;
            dadosGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dadosGridView.Size = new Size(424, 573);
            dadosGridView.TabIndex = 0;
            dadosGridView.CellDoubleClick += dadosGridView_CellDoubleClick;
            dadosGridView.CellFormatting += dadosGridView_CellFormatting;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 593);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 23);
            textBox1.TabIndex = 1;
            // 
            // ConsultaSimplificada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 628);
            Controls.Add(textBox1);
            Controls.Add(dadosGridView);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsultaSimplificada";
            Text = "Consulta Contas";
            Load += ConsultaSimplificada_Load;
            ((System.ComponentModel.ISupportInitialize)dadosGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dadosGridView;
        private TextBox textBox1;
    }
}