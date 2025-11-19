namespace ImportadorContaMovimentacao.Forms.Gerenciador_de_Empresas
{
    partial class AdicionarEmpresa
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
            numTB = new TextBox();
            nomeTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dominioCB = new CheckBox();
            seniorCB = new CheckBox();
            adicionarBTTN = new Button();
            cancelarBTTN = new Button();
            SuspendLayout();
            // 
            // numTB
            // 
            numTB.Location = new Point(72, 19);
            numTB.Name = "numTB";
            numTB.Size = new Size(86, 23);
            numTB.TabIndex = 0;
            numTB.TextChanged += numTB_TextChanged;
            // 
            // nomeTB
            // 
            nomeTB.Location = new Point(72, 78);
            nomeTB.Name = "nomeTB";
            nomeTB.Size = new Size(209, 23);
            nomeTB.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(72, 45);
            label1.Name = "label1";
            label1.Size = new Size(205, 30);
            label1.TabIndex = 2;
            label1.Text = "Certifique-se de que o numero seja o \r\nmesmo do sistema selecionado.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 22);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 3;
            label2.Text = "Numero:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 81);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "Nome:";
            // 
            // dominioCB
            // 
            dominioCB.AutoSize = true;
            dominioCB.Location = new Point(72, 107);
            dominioCB.Name = "dominioCB";
            dominioCB.Size = new Size(72, 19);
            dominioCB.TabIndex = 5;
            dominioCB.Text = "Domínio";
            dominioCB.UseVisualStyleBackColor = true;
            dominioCB.CheckedChanged += dominioCB_CheckedChanged;
            // 
            // seniorCB
            // 
            seniorCB.AutoSize = true;
            seniorCB.Location = new Point(222, 107);
            seniorCB.Name = "seniorCB";
            seniorCB.Size = new Size(59, 19);
            seniorCB.TabIndex = 6;
            seniorCB.Text = "Sênior";
            seniorCB.UseVisualStyleBackColor = true;
            seniorCB.CheckedChanged += seniorCB_CheckedChanged;
            // 
            // adicionarBTTN
            // 
            adicionarBTTN.Location = new Point(125, 141);
            adicionarBTTN.Name = "adicionarBTTN";
            adicionarBTTN.Size = new Size(91, 33);
            adicionarBTTN.TabIndex = 7;
            adicionarBTTN.Text = "Adicionar";
            adicionarBTTN.UseVisualStyleBackColor = true;
            adicionarBTTN.Click += adicionarBTTN_Click;
            // 
            // cancelarBTTN
            // 
            cancelarBTTN.Location = new Point(222, 141);
            cancelarBTTN.Name = "cancelarBTTN";
            cancelarBTTN.Size = new Size(91, 33);
            cancelarBTTN.TabIndex = 8;
            cancelarBTTN.Text = "Cancelar";
            cancelarBTTN.UseVisualStyleBackColor = true;
            cancelarBTTN.Click += cancelarBTTN_Click;
            // 
            // AdicionarEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 192);
            Controls.Add(cancelarBTTN);
            Controls.Add(adicionarBTTN);
            Controls.Add(seniorCB);
            Controls.Add(dominioCB);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nomeTB);
            Controls.Add(numTB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdicionarEmpresa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Empresa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numTB;
        private TextBox nomeTB;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox dominioCB;
        private CheckBox seniorCB;
        private Button adicionarBTTN;
        private Button cancelarBTTN;
    }
}