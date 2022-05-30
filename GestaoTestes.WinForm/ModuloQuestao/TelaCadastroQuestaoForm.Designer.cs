namespace GestaoTestes.WinForm.ModuloQuestao
{
    partial class TelaCadastroQuestaoForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEnunciado = new System.Windows.Forms.TextBox();
            this.cmbDisciplinas = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listAlternativas = new System.Windows.Forms.ListBox();
            this.checkAlternativaCorreta = new System.Windows.Forms.CheckBox();
            this.btnAddAlternativa = new System.Windows.Forms.Button();
            this.txtResposta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(397, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 41);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(284, 426);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(107, 41);
            this.btnGravar.TabIndex = 10;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(145, 27);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(84, 27);
            this.txtNumero.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Disciplinas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nº:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Matéria:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Enunciado:";
            // 
            // txtEnunciado
            // 
            this.txtEnunciado.Location = new System.Drawing.Point(145, 128);
            this.txtEnunciado.Name = "txtEnunciado";
            this.txtEnunciado.Size = new System.Drawing.Size(340, 27);
            this.txtEnunciado.TabIndex = 16;
            // 
            // cmbDisciplinas
            // 
            this.cmbDisciplinas.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDisciplinas.DisplayMember = "NomeDisciplina";
            this.cmbDisciplinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplinas.FormattingEnabled = true;
            this.cmbDisciplinas.Location = new System.Drawing.Point(145, 60);
            this.cmbDisciplinas.Name = "cmbDisciplinas";
            this.cmbDisciplinas.Size = new System.Drawing.Size(340, 28);
            this.cmbDisciplinas.TabIndex = 18;
            this.cmbDisciplinas.SelectedValueChanged += new System.EventHandler(this.cmbDisciplinas_SelectedValueChanged);
            // 
            // cmbMateria
            // 
            this.cmbMateria.DisplayMember = "NomeMateria";
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.Enabled = false;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(145, 94);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(340, 28);
            this.cmbMateria.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listAlternativas);
            this.groupBox1.Controls.Add(this.checkAlternativaCorreta);
            this.groupBox1.Controls.Add(this.btnAddAlternativa);
            this.groupBox1.Controls.Add(this.txtResposta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(42, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 247);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alternativas";
            // 
            // listAlternativas
            // 
            this.listAlternativas.DisplayMember = "VisualizarAlternativa";
            this.listAlternativas.FormattingEnabled = true;
            this.listAlternativas.ItemHeight = 20;
            this.listAlternativas.Location = new System.Drawing.Point(103, 105);
            this.listAlternativas.Name = "listAlternativas";
            this.listAlternativas.Size = new System.Drawing.Size(340, 104);
            this.listAlternativas.TabIndex = 25;
            // 
            // checkAlternativaCorreta
            // 
            this.checkAlternativaCorreta.AutoSize = true;
            this.checkAlternativaCorreta.Location = new System.Drawing.Point(103, 75);
            this.checkAlternativaCorreta.Name = "checkAlternativaCorreta";
            this.checkAlternativaCorreta.Size = new System.Drawing.Size(156, 24);
            this.checkAlternativaCorreta.TabIndex = 24;
            this.checkAlternativaCorreta.Text = "Alternativa Correta";
            this.checkAlternativaCorreta.UseVisualStyleBackColor = true;
            // 
            // btnAddAlternativa
            // 
            this.btnAddAlternativa.Location = new System.Drawing.Point(363, 35);
            this.btnAddAlternativa.Name = "btnAddAlternativa";
            this.btnAddAlternativa.Size = new System.Drawing.Size(80, 29);
            this.btnAddAlternativa.TabIndex = 23;
            this.btnAddAlternativa.Text = "Add";
            this.btnAddAlternativa.UseVisualStyleBackColor = true;
            this.btnAddAlternativa.Click += new System.EventHandler(this.btnAddAlternativa_Click);
            // 
            // txtResposta
            // 
            this.txtResposta.Location = new System.Drawing.Point(103, 36);
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.Size = new System.Drawing.Size(254, 27);
            this.txtResposta.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Resposta:";
            // 
            // TelaCadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbDisciplinas);
            this.Controls.Add(this.txtEnunciado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroQuestaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Questão";
            this.Load += new System.EventHandler(this.TelaCadastroQuestaoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtNomeDisciplina;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listAlternativas;
        private System.Windows.Forms.CheckBox checkAlternativaCorreta;
        private System.Windows.Forms.Button btnAddAlternativa;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemover;
    }
}