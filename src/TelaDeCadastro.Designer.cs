namespace ListaDePessoas
{
    partial class TelaDeCadastro
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
            campoDeNome = new MaskedTextBox();
            TituloFormularioDeCadastro = new Label();
            campoDeEndereco = new MaskedTextBox();
            lbl_campo_nome = new Label();
            lbl_campo_endereco = new Label();
            campoDeTelefone = new MaskedTextBox();
            lbl_campo_telefone = new Label();
            lbl_campo_data_nascimento = new Label();
            lbl_campo_data_admissao = new Label();
            btn_enviar_cadastro = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            campoDeDataDeNascimento = new DateTimePicker();
            campoDeDataDeAdmissao = new DateTimePicker();
            lbl_campo_cpf = new Label();
            campoDeCpf = new MaskedTextBox();
            btn_cancelar = new Button();
            SuspendLayout();
            // 
            // text_nome
            // 
            campoDeNome.Location = new Point(34, 89);
            campoDeNome.Name = "text_nome";
            campoDeNome.Size = new Size(328, 23);
            campoDeNome.TabIndex = 0;
            campoDeNome.KeyPress += AoDigitarNoCampoNome;
            // 
            // lbl_text_form_cadastro
            // 
            TituloFormularioDeCadastro.AutoSize = true;
            TituloFormularioDeCadastro.Font = new Font("Verdana", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            TituloFormularioDeCadastro.Location = new Point(76, 19);
            TituloFormularioDeCadastro.Name = "lbl_text_form_cadastro";
            TituloFormularioDeCadastro.Size = new Size(250, 20);
            TituloFormularioDeCadastro.TabIndex = 1;
            TituloFormularioDeCadastro.Text = "Cadastro de Funcionários";
            // 
            // text_endereco
            // 
            campoDeEndereco.Location = new Point(34, 225);
            campoDeEndereco.Name = "text_endereco";
            campoDeEndereco.Size = new Size(328, 23);
            campoDeEndereco.TabIndex = 2;
            // 
            // lbl_campo_nome
            // 
            lbl_campo_nome.AutoSize = true;
            lbl_campo_nome.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_nome.Location = new Point(34, 70);
            lbl_campo_nome.Name = "lbl_campo_nome";
            lbl_campo_nome.Size = new Size(115, 16);
            lbl_campo_nome.TabIndex = 1;
            lbl_campo_nome.Text = "Nome Completo:";
            // 
            // lbl_campo_endereco
            // 
            lbl_campo_endereco.AutoSize = true;
            lbl_campo_endereco.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_endereco.Location = new Point(34, 206);
            lbl_campo_endereco.Name = "lbl_campo_endereco";
            lbl_campo_endereco.Size = new Size(74, 16);
            lbl_campo_endereco.TabIndex = 1;
            lbl_campo_endereco.Text = "Endereço:";
            // 
            // mtb_telefone
            // 
            campoDeTelefone.Location = new Point(34, 290);
            campoDeTelefone.Mask = "(99) 0000-0000";
            campoDeTelefone.Name = "mtb_telefone";
            campoDeTelefone.Size = new Size(137, 23);
            campoDeTelefone.TabIndex = 3;
            // 
            // lbl_campo_telefone
            // 
            lbl_campo_telefone.AutoSize = true;
            lbl_campo_telefone.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_telefone.Location = new Point(34, 271);
            lbl_campo_telefone.Name = "lbl_campo_telefone";
            lbl_campo_telefone.Size = new Size(69, 16);
            lbl_campo_telefone.TabIndex = 1;
            lbl_campo_telefone.Text = "Telefone:";
            // 
            // lbl_campo_data_nascimento
            // 
            lbl_campo_data_nascimento.AutoSize = true;
            lbl_campo_data_nascimento.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_data_nascimento.Location = new Point(221, 140);
            lbl_campo_data_nascimento.Name = "lbl_campo_data_nascimento";
            lbl_campo_data_nascimento.Size = new Size(125, 16);
            lbl_campo_data_nascimento.TabIndex = 1;
            lbl_campo_data_nascimento.Text = "Data Nascimento:";
            // 
            // lbl_campo_data_admissao
            // 
            lbl_campo_data_admissao.AutoSize = true;
            lbl_campo_data_admissao.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_data_admissao.Location = new Point(225, 270);
            lbl_campo_data_admissao.Name = "lbl_campo_data_admissao";
            lbl_campo_data_admissao.Size = new Size(110, 16);
            lbl_campo_data_admissao.TabIndex = 1;
            lbl_campo_data_admissao.Text = "Data Admissão:";
            // 
            // btn_enviar_cadastro
            // 
            btn_enviar_cadastro.Cursor = Cursors.Hand;
            btn_enviar_cadastro.Location = new Point(45, 353);
            btn_enviar_cadastro.Name = "btn_enviar_cadastro";
            btn_enviar_cadastro.Size = new Size(115, 55);
            btn_enviar_cadastro.TabIndex = 7;
            btn_enviar_cadastro.Text = "Salvar";
            btn_enviar_cadastro.UseVisualStyleBackColor = true;
            btn_enviar_cadastro.Click += AoClicarEmEnviar;
            // 
            // mtb_dtNascimento
            // 
            campoDeDataDeNascimento.Format = DateTimePickerFormat.Short;
            campoDeDataDeNascimento.Location = new Point(221, 159);
            campoDeDataDeNascimento.MaxDate = new DateTime(2008, 1, 1, 0, 0, 0, 0);
            campoDeDataDeNascimento.MinDate = new DateTime(1963, 12, 1, 0, 0, 0, 0);
            campoDeDataDeNascimento.Name = "mtb_dtNascimento";
            campoDeDataDeNascimento.Size = new Size(141, 23);
            campoDeDataDeNascimento.TabIndex = 4;
            campoDeDataDeNascimento.Value = new DateTime(2008, 1, 1, 0, 0, 0, 0);
            // 
            // mtb_dtAdimissao
            // 
            campoDeDataDeAdmissao.Format = DateTimePickerFormat.Short;
            campoDeDataDeAdmissao.Location = new Point(225, 290);
            campoDeDataDeAdmissao.MaxDate = new DateTime(2023, 4, 24, 23, 59, 59, 0);
            campoDeDataDeAdmissao.Name = "mtb_dtAdimissao";
            campoDeDataDeAdmissao.Size = new Size(137, 23);
            campoDeDataDeAdmissao.TabIndex = 5;
            // 
            // lbl_campo_cpf
            // 
            lbl_campo_cpf.AutoSize = true;
            lbl_campo_cpf.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_cpf.Location = new Point(34, 140);
            lbl_campo_cpf.Name = "lbl_campo_cpf";
            lbl_campo_cpf.Size = new Size(38, 16);
            lbl_campo_cpf.TabIndex = 1;
            lbl_campo_cpf.Text = "CPF:";
            // 
            // mtb_cpf
            // 
            campoDeCpf.Location = new Point(34, 159);
            campoDeCpf.Mask = "000,000,000-00";
            campoDeCpf.Name = "mtb_cpf";
            campoDeCpf.Size = new Size(137, 23);
            campoDeCpf.TabIndex = 1;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Cursor = Cursors.Hand;
            btn_cancelar.Location = new Point(225, 353);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(121, 55);
            btn_cancelar.TabIndex = 8;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += AoClicarEmCancelar;
            // 
            // Form_Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 450);
            Controls.Add(btn_cancelar);
            Controls.Add(campoDeDataDeAdmissao);
            Controls.Add(campoDeDataDeNascimento);
            Controls.Add(btn_enviar_cadastro);
            Controls.Add(lbl_campo_data_admissao);
            Controls.Add(lbl_campo_data_nascimento);
            Controls.Add(lbl_campo_telefone);
            Controls.Add(lbl_campo_endereco);
            Controls.Add(lbl_campo_cpf);
            Controls.Add(lbl_campo_nome);
            Controls.Add(campoDeCpf);
            Controls.Add(campoDeTelefone);
            Controls.Add(TituloFormularioDeCadastro);
            Controls.Add(campoDeEndereco);
            Controls.Add(campoDeNome);
            Name = "Form_Cadastro";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox campoDeNome;
        private Label TituloFormularioDeCadastro;
        private MaskedTextBox campoDeEndereco;
        private Label lbl_campo_nome;
        private Label lbl_campo_endereco;
        private MaskedTextBox campoDeTelefone;
        private Label lbl_campo_telefone;
        private Label lbl_campo_data_nascimento;
        private Label lbl_campo_data_admissao;
        private Button btn_enviar_cadastro;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DateTimePicker campoDeDataDeAdmissao;
        public DateTimePicker campoDeDataDeNascimento;
        private Label lbl_campo_cpf;
        private MaskedTextBox campoDeCpf;
        private Button btn_cancelar;
    }
}