namespace ImportadorContaMovimentacao.Forms.Dialogs
{
    partial class AdicionarConta
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
            numeroTB = new TextBox();
            nomeTB = new TextBox();
            tipoCB = new ComboBox();
            analiticaTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            includeBTTN = new Button();
            cancelBTTN = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // numeroTB
            // 
            numeroTB.Location = new Point(72, 12);
            numeroTB.Name = "numeroTB";
            numeroTB.Size = new Size(75, 23);
            numeroTB.TabIndex = 0;
            // 
            // nomeTB
            // 
            nomeTB.Location = new Point(72, 70);
            nomeTB.Name = "nomeTB";
            nomeTB.Size = new Size(237, 23);
            nomeTB.TabIndex = 0;
            // 
            // tipoCB
            // 
            tipoCB.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoCB.FormattingEnabled = true;
            tipoCB.Items.AddRange(new object[] { "A", "S" });
            tipoCB.Location = new Point(72, 41);
            tipoCB.Name = "tipoCB";
            tipoCB.Size = new Size(40, 23);
            tipoCB.TabIndex = 1;
            // 
            // analiticaTB
            // 
            analiticaTB.Location = new Point(72, 99);
            analiticaTB.Name = "analiticaTB";
            analiticaTB.Size = new Size(184, 23);
            analiticaTB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Número:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 44);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 73);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Nome:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 102);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 2;
            label4.Text = "Analítica:";
            // 
            // includeBTTN
            // 
            includeBTTN.Location = new Point(181, 128);
            includeBTTN.Name = "includeBTTN";
            includeBTTN.Size = new Size(75, 23);
            includeBTTN.TabIndex = 3;
            includeBTTN.Text = "Incluir";
            includeBTTN.UseVisualStyleBackColor = true;
            includeBTTN.Click += includeBTTN_Click;
            // 
            // cancelBTTN
            // 
            cancelBTTN.Location = new Point(262, 128);
            cancelBTTN.Name = "cancelBTTN";
            cancelBTTN.Size = new Size(75, 23);
            cancelBTTN.TabIndex = 3;
            cancelBTTN.Text = "Cancelar";
            cancelBTTN.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(118, 44);
            label5.Name = "label5";
            label5.Size = new Size(137, 15);
            label5.TabIndex = 2;
            label5.Text = "A - Analítica S - Sintética";
            // 
            // AdicionarConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 163);
            Controls.Add(cancelBTTN);
            Controls.Add(includeBTTN);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tipoCB);
            Controls.Add(analiticaTB);
            Controls.Add(nomeTB);
            Controls.Add(numeroTB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AdicionarConta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Conta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numeroTB;
        private TextBox nomeTB;
        private ComboBox tipoCB;
        private TextBox analiticaTB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button includeBTTN;
        private Button cancelBTTN;
        private Label label5;
    }
}