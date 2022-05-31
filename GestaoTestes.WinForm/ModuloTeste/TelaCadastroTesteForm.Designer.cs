namespace GestaoTestes.WinForm.ModuloTeste
{
    partial class TelaCadastroTesteForm
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
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDisciplinas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataCriacao = new System.Windows.Forms.DateTimePicker();
            this.checkProvaRecuperacao = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericQtdQuestoes = new System.Windows.Forms.NumericUpDown();
            this.listQuestoes = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericQtdQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMateria
            // 
            this.cmbMateria.DisplayMember = "NomeMateria";
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(157, 119);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(201, 28);
            this.cmbMateria.TabIndex = 25;
            this.cmbMateria.SelectedValueChanged += new System.EventHandler(this.cmbMateria_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Matéria:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(157, 18);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(84, 27);
            this.txtNumero.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Título:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nº:";
            // 
            // cmbDisciplinas
            // 
            this.cmbDisciplinas.DisplayMember = "NomeDisciplina";
            this.cmbDisciplinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplinas.FormattingEnabled = true;
            this.cmbDisciplinas.Location = new System.Drawing.Point(157, 85);
            this.cmbDisciplinas.Name = "cmbDisciplinas";
            this.cmbDisciplinas.Size = new System.Drawing.Size(201, 28);
            this.cmbDisciplinas.TabIndex = 27;
            this.cmbDisciplinas.SelectedValueChanged += new System.EventHandler(this.cmbDisciplina_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Disciplina:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(157, 52);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(201, 27);
            this.txtTitulo.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Data:";
            // 
            // dataCriacao
            // 
            this.dataCriacao.Enabled = false;
            this.dataCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataCriacao.Location = new System.Drawing.Point(427, 50);
            this.dataCriacao.MinDate = new System.DateTime(2022, 5, 16, 0, 0, 0, 0);
            this.dataCriacao.Name = "dataCriacao";
            this.dataCriacao.Size = new System.Drawing.Size(110, 27);
            this.dataCriacao.TabIndex = 30;
            this.dataCriacao.Value = new System.DateTime(2022, 5, 16, 0, 0, 0, 0);
            // 
            // checkProvaRecuperacao
            // 
            this.checkProvaRecuperacao.AutoSize = true;
            this.checkProvaRecuperacao.Location = new System.Drawing.Point(376, 87);
            this.checkProvaRecuperacao.Name = "checkProvaRecuperacao";
            this.checkProvaRecuperacao.Size = new System.Drawing.Size(182, 24);
            this.checkProvaRecuperacao.TabIndex = 31;
            this.checkProvaRecuperacao.Text = "Prova de recuperação?";
            this.checkProvaRecuperacao.UseVisualStyleBackColor = true;
            this.checkProvaRecuperacao.CheckedChanged += new System.EventHandler(this.checkProvaRecuperacao_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Nº de questões:";
            // 
            // numericQtdQuestoes
            // 
            this.numericQtdQuestoes.Enabled = false;
            this.numericQtdQuestoes.Location = new System.Drawing.Point(157, 153);
            this.numericQtdQuestoes.Name = "numericQtdQuestoes";
            this.numericQtdQuestoes.Size = new System.Drawing.Size(84, 27);
            this.numericQtdQuestoes.TabIndex = 33;
            this.numericQtdQuestoes.ClientSizeChanged += new System.EventHandler(this.qtdQuestoes_ClientSizeChanged);
            this.numericQtdQuestoes.Click += new System.EventHandler(this.numericQtdQuestoes_Click);
            // 
            // listQuestoes
            // 
            this.listQuestoes.DisplayMember = "Enunciado";
            this.listQuestoes.FormattingEnabled = true;
            this.listQuestoes.ItemHeight = 20;
            this.listQuestoes.Location = new System.Drawing.Point(29, 201);
            this.listQuestoes.Name = "listQuestoes";
            this.listQuestoes.Size = new System.Drawing.Size(529, 144);
            this.listQuestoes.TabIndex = 35;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(451, 402);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 41);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(338, 402);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(107, 41);
            this.btnGravar.TabIndex = 36;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // TelaCadastroTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 455);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.listQuestoes);
            this.Controls.Add(this.numericQtdQuestoes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkProvaRecuperacao);
            this.Controls.Add(this.dataCriacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.cmbDisciplinas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroTesteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Testes";
            this.Load += new System.EventHandler(this.TelaCadastroTesteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericQtdQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dataCriacao;
        private System.Windows.Forms.CheckBox checkProvaRecuperacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericQtdQuestoes;
        private System.Windows.Forms.ListBox listQuestoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
    }
}