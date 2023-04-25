namespace ListaDePessoas
{
    partial class TelaDeFuncionarios
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_cadastrar = new Button();
            lbl_titulo = new Label();
            btn_editar = new Button();
            btn_excluir = new Button();
            dataGrid_funcionarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGrid_funcionarios).BeginInit();
            SuspendLayout();
            // 
            // btn_cadastrar
            // 
            btn_cadastrar.Cursor = Cursors.Hand;
            btn_cadastrar.Location = new Point(58, 408);
            btn_cadastrar.Name = "btn_cadastrar";
            btn_cadastrar.Size = new Size(134, 48);
            btn_cadastrar.TabIndex = 0;
            btn_cadastrar.Text = "Cadatrar Funcionário";
            btn_cadastrar.UseVisualStyleBackColor = true;
            btn_cadastrar.Click += AoClicarEmCadastrar;
            // 
            // lbl_titulo
            // 
            lbl_titulo.AutoSize = true;
            lbl_titulo.Font = new Font("Cambria Math", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_titulo.Location = new Point(268, -26);
            lbl_titulo.Name = "lbl_titulo";
            lbl_titulo.Size = new Size(280, 117);
            lbl_titulo.TabIndex = 1;
            lbl_titulo.Text = "Cadastro de Funcionários";
            // 
            // btn_editar
            // 
            btn_editar.Cursor = Cursors.Hand;
            btn_editar.Location = new Point(343, 408);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(134, 48);
            btn_editar.TabIndex = 3;
            btn_editar.Text = "Editar Funcionário";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += AoClicarEmEditar;
            // 
            // btn_excluir
            // 
            btn_excluir.Cursor = Cursors.Hand;
            btn_excluir.Location = new Point(608, 408);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(134, 48);
            btn_excluir.TabIndex = 4;
            btn_excluir.Text = "Excluir Funcionário";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += AoClicarEmExcluir;
            // 
            // dataGrid_funcionarios
            // 
            dataGrid_funcionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_funcionarios.Location = new Point(58, 94);
            dataGrid_funcionarios.Name = "dataGrid_funcionarios";
            dataGrid_funcionarios.RowTemplate.Height = 25;
            dataGrid_funcionarios.Size = new Size(684, 260);
            dataGrid_funcionarios.TabIndex = 6;
            // 
            // Janela_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 483);
            Controls.Add(dataGrid_funcionarios);
            Controls.Add(btn_excluir);
            Controls.Add(btn_editar);
            Controls.Add(lbl_titulo);
            Controls.Add(btn_cadastrar);
            Name = "Janela_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Funcionários";
            ((System.ComponentModel.ISupportInitialize)dataGrid_funcionarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_cadastrar;
        private Label lbl_titulo;
        private Button btn_editar;
        private Button btn_excluir;
        private DataGridView dataGrid_funcionarios;
    }
}