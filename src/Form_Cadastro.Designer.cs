namespace ListaDePessoas
{
    partial class Form_Cadastro
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
            text_nome = new MaskedTextBox();
            lbl_text_form_cadastro = new Label();
            text_endereco = new MaskedTextBox();
            lbl_campo_nome = new Label();
            lbl_campo_endereco = new Label();
            mtb_telefone = new MaskedTextBox();
            lbl_campo_telefone = new Label();
            lbl_campo_data_nascimento = new Label();
            lbl_campo_data_admissao = new Label();
            btn_enviar_cadastro = new Button();
            mtb_sexo = new ComboBox();
            lbl_sexo = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            mtb_dtNascimento = new DateTimePicker();
            mtb_dtAdimissao = new DateTimePicker();
            lbl_campo_cpf = new Label();
            mtb_cpf = new MaskedTextBox();
            btn_cancelar = new Button();
            SuspendLayout();
            // 
            // text_nome
            // 
            text_nome.Location = new Point(34, 89);
            text_nome.Name = "text_nome";
            text_nome.Size = new Size(328, 23);
            text_nome.TabIndex = 0;
            // 
            // lbl_text_form_cadastro
            // 
            lbl_text_form_cadastro.AutoSize = true;
            lbl_text_form_cadastro.Font = new Font("Verdana", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_text_form_cadastro.Location = new Point(76, 19);
            lbl_text_form_cadastro.Name = "lbl_text_form_cadastro";
            lbl_text_form_cadastro.Size = new Size(250, 20);
            lbl_text_form_cadastro.TabIndex = 1;
            lbl_text_form_cadastro.Text = "Cadastro de Funcionários";
            // 
            // text_endereco
            // 
            text_endereco.Location = new Point(34, 193);
            text_endereco.Name = "text_endereco";
            text_endereco.Size = new Size(328, 23);
            text_endereco.TabIndex = 2;
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
            lbl_campo_endereco.Location = new Point(34, 174);
            lbl_campo_endereco.Name = "lbl_campo_endereco";
            lbl_campo_endereco.Size = new Size(74, 16);
            lbl_campo_endereco.TabIndex = 1;
            lbl_campo_endereco.Text = "Endereço:";
            // 
            // mtb_telefone
            // 
            mtb_telefone.Location = new Point(34, 248);
            mtb_telefone.Mask = "(99) 0000-0000";
            mtb_telefone.Name = "mtb_telefone";
            mtb_telefone.Size = new Size(137, 23);
            mtb_telefone.TabIndex = 3;
            // 
            // lbl_campo_telefone
            // 
            lbl_campo_telefone.AutoSize = true;
            lbl_campo_telefone.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_telefone.Location = new Point(34, 229);
            lbl_campo_telefone.Name = "lbl_campo_telefone";
            lbl_campo_telefone.Size = new Size(69, 16);
            lbl_campo_telefone.TabIndex = 1;
            lbl_campo_telefone.Text = "Telefone:";
            // 
            // lbl_campo_data_nascimento
            // 
            lbl_campo_data_nascimento.AutoSize = true;
            lbl_campo_data_nascimento.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_data_nascimento.Location = new Point(221, 229);
            lbl_campo_data_nascimento.Name = "lbl_campo_data_nascimento";
            lbl_campo_data_nascimento.Size = new Size(125, 16);
            lbl_campo_data_nascimento.TabIndex = 1;
            lbl_campo_data_nascimento.Text = "Data Nascimento:";
            // 
            // lbl_campo_data_admissao
            // 
            lbl_campo_data_admissao.AutoSize = true;
            lbl_campo_data_admissao.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_data_admissao.Location = new Point(34, 292);
            lbl_campo_data_admissao.Name = "lbl_campo_data_admissao";
            lbl_campo_data_admissao.Size = new Size(110, 16);
            lbl_campo_data_admissao.TabIndex = 1;
            lbl_campo_data_admissao.Text = "Data Admissão:";
            // 
            // btn_enviar_cadastro
            // 
            btn_enviar_cadastro.Cursor = Cursors.Hand;
            btn_enviar_cadastro.Location = new Point(54, 371);
            btn_enviar_cadastro.Name = "btn_enviar_cadastro";
            btn_enviar_cadastro.Size = new Size(95, 37);
            btn_enviar_cadastro.TabIndex = 7;
            btn_enviar_cadastro.Text = "Salvar";
            btn_enviar_cadastro.UseVisualStyleBackColor = true;
            btn_enviar_cadastro.Click += btn_enviar_cadastro_Click;
            // 
            // mtb_sexo
            // 
            mtb_sexo.FormattingEnabled = true;
            mtb_sexo.Items.AddRange(new object[] { "Feminino", "Masculino" });
            mtb_sexo.Location = new Point(221, 312);
            mtb_sexo.Name = "mtb_sexo";
            mtb_sexo.Size = new Size(141, 23);
            mtb_sexo.TabIndex = 6;
            // 
            // lbl_sexo
            // 
            lbl_sexo.AutoSize = true;
            lbl_sexo.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_sexo.Location = new Point(221, 292);
            lbl_sexo.Name = "lbl_sexo";
            lbl_sexo.Size = new Size(59, 16);
            lbl_sexo.TabIndex = 1;
            lbl_sexo.Text = "Gênero:";
            // 
            // mtb_dtNascimento
            // 
            mtb_dtNascimento.Format = DateTimePickerFormat.Short;
            mtb_dtNascimento.Location = new Point(221, 248);
            mtb_dtNascimento.Name = "mtb_dtNascimento";
            mtb_dtNascimento.Size = new Size(141, 23);
            mtb_dtNascimento.TabIndex = 4;
            // 
            // mtb_dtAdimissao
            // 
            mtb_dtAdimissao.Format = DateTimePickerFormat.Short;
            mtb_dtAdimissao.Location = new Point(34, 312);
            mtb_dtAdimissao.Name = "mtb_dtAdimissao";
            mtb_dtAdimissao.Size = new Size(137, 23);
            mtb_dtAdimissao.TabIndex = 5;
            // 
            // lbl_campo_cpf
            // 
            lbl_campo_cpf.AutoSize = true;
            lbl_campo_cpf.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_campo_cpf.Location = new Point(34, 122);
            lbl_campo_cpf.Name = "lbl_campo_cpf";
            lbl_campo_cpf.Size = new Size(38, 16);
            lbl_campo_cpf.TabIndex = 1;
            lbl_campo_cpf.Text = "CPF:";
            // 
            // mtb_cpf
            // 
            mtb_cpf.Location = new Point(34, 141);
            mtb_cpf.Mask = "000.000.000-00";
            mtb_cpf.Name = "mtb_cpf";
            mtb_cpf.Size = new Size(137, 23);
            mtb_cpf.TabIndex = 1;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Cursor = Cursors.Hand;
            btn_cancelar.Location = new Point(239, 371);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(95, 37);
            btn_cancelar.TabIndex = 8;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // Form_Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 450);
            Controls.Add(btn_cancelar);
            Controls.Add(mtb_dtAdimissao);
            Controls.Add(mtb_dtNascimento);
            Controls.Add(mtb_sexo);
            Controls.Add(btn_enviar_cadastro);
            Controls.Add(lbl_sexo);
            Controls.Add(lbl_campo_data_admissao);
            Controls.Add(lbl_campo_data_nascimento);
            Controls.Add(lbl_campo_telefone);
            Controls.Add(lbl_campo_endereco);
            Controls.Add(lbl_campo_cpf);
            Controls.Add(lbl_campo_nome);
            Controls.Add(mtb_cpf);
            Controls.Add(mtb_telefone);
            Controls.Add(lbl_text_form_cadastro);
            Controls.Add(text_endereco);
            Controls.Add(text_nome);
            Name = "Form_Cadastro";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox text_nome;
        private Label lbl_text_form_cadastro;
        private MaskedTextBox text_endereco;
        private Label lbl_campo_nome;
        private Label lbl_campo_endereco;
        private MaskedTextBox mtb_telefone;
        private Label lbl_campo_telefone;
        private Label lbl_campo_data_nascimento;
        private Label lbl_campo_data_admissao;
        private Button btn_enviar_cadastro;
        private ComboBox mtb_sexo;
        private Label lbl_sexo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DateTimePicker mtb_dtAdimissao;
        public DateTimePicker mtb_dtNascimento;
        private Label lbl_campo_cpf;
        private MaskedTextBox mtb_cpf;
        private Button btn_cancelar;
    }
}