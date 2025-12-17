namespace ImportadorContaMovimentacao.Forms
{
    partial class ImportadorContaPassiva
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
            pathTB = new TextBox();
            label1 = new Label();
            selectPathBTTN = new Button();
            importBTNN = new Button();
            label2 = new Label();
            empresaLB = new Label();
            SuspendLayout();
            // 
            // pathTB
            // 
            pathTB.Location = new Point(12, 48);
            pathTB.Name = "pathTB";
            pathTB.Size = new Size(316, 23);
            pathTB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 1;
            label1.Text = "Caminho Planilha de Contas:";
            // 
            // selectPathBTTN
            // 
            selectPathBTTN.Location = new Point(334, 48);
            selectPathBTTN.Name = "selectPathBTTN";
            selectPathBTTN.Size = new Size(29, 23);
            selectPathBTTN.TabIndex = 2;
            selectPathBTTN.Text = "...";
            selectPathBTTN.UseVisualStyleBackColor = true;
            selectPathBTTN.Click += selectPathBTTN_Click;
            // 
            // importBTNN
            // 
            importBTNN.Location = new Point(369, 45);
            importBTNN.Name = "importBTNN";
            importBTNN.Size = new Size(128, 29);
            importBTNN.TabIndex = 3;
            importBTNN.Text = "Importar";
            importBTNN.UseVisualStyleBackColor = true;
            importBTNN.Click += importBTNN_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Empresa:";
            // 
            // empresaLB
            // 
            empresaLB.AutoSize = true;
            empresaLB.Location = new Point(73, 9);
            empresaLB.Name = "empresaLB";
            empresaLB.Size = new Size(97, 15);
            empresaLB.TabIndex = 5;
            empresaLB.Text = "******************";
            // 
            // ImportadorContaPassiva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 82);
            Controls.Add(empresaLB);
            Controls.Add(label2);
            Controls.Add(importBTNN);
            Controls.Add(selectPathBTTN);
            Controls.Add(label1);
            Controls.Add(pathTB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ImportadorContaPassiva";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Importador Conta Passiva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pathTB;
        private Label label1;
        private Button selectPathBTTN;
        private Button importBTNN;
        private Label label2;
        private Label empresaLB;
    }
}