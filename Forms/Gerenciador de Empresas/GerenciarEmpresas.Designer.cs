namespace ImportadorContaMovimentacao.Forms
{
    partial class GerenciarEmpresas
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
            empresasGV = new DataGridView();
            AdicionarBTTN = new Button();
            removerBTTN = new Button();
            ((System.ComponentModel.ISupportInitialize)empresasGV).BeginInit();
            SuspendLayout();
            // 
            // empresasGV
            // 
            empresasGV.AllowUserToAddRows = false;
            empresasGV.AllowUserToDeleteRows = false;
            empresasGV.AllowUserToResizeRows = false;
            empresasGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            empresasGV.Location = new Point(12, 12);
            empresasGV.MultiSelect = false;
            empresasGV.Name = "empresasGV";
            empresasGV.ReadOnly = true;
            empresasGV.RowHeadersVisible = false;
            empresasGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            empresasGV.Size = new Size(426, 522);
            empresasGV.TabIndex = 0;
            empresasGV.CellDoubleClick += empresasGV_CellDoubleClick;
            // 
            // AdicionarBTTN
            // 
            AdicionarBTTN.Location = new Point(279, 540);
            AdicionarBTTN.Name = "AdicionarBTTN";
            AdicionarBTTN.Size = new Size(75, 23);
            AdicionarBTTN.TabIndex = 1;
            AdicionarBTTN.Text = "Adicionar";
            AdicionarBTTN.UseVisualStyleBackColor = true;
            AdicionarBTTN.Click += AdicionarBTTN_Click;
            // 
            // removerBTTN
            // 
            removerBTTN.Location = new Point(363, 540);
            removerBTTN.Name = "removerBTTN";
            removerBTTN.Size = new Size(75, 23);
            removerBTTN.TabIndex = 2;
            removerBTTN.Text = "Remover";
            removerBTTN.UseVisualStyleBackColor = true;
            removerBTTN.Click += removerBTTN_Click;
            // 
            // GerenciarEmpresas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 572);
            Controls.Add(removerBTTN);
            Controls.Add(AdicionarBTTN);
            Controls.Add(empresasGV);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "GerenciarEmpresas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciar Empresas";
            FormClosing += GerenciarEmpresas_FormClosing;
            ((System.ComponentModel.ISupportInitialize)empresasGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView empresasGV;
        private Button AdicionarBTTN;
        private Button removerBTTN;
    }
}