
namespace HotelParaTodes
{
    partial class TELA_LOGIN
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
            this.components = new System.ComponentModel.Container();
            this.BTN_CONFIRMAR = new System.Windows.Forms.Button();
            this.BTN_VOLTAR = new System.Windows.Forms.Button();
            this.TXT_LOGIN = new System.Windows.Forms.TextBox();
            this.TXT_SENHA = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LBL_VER_SENHA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_CONFIRMAR
            // 
            this.BTN_CONFIRMAR.Location = new System.Drawing.Point(118, 141);
            this.BTN_CONFIRMAR.Name = "BTN_CONFIRMAR";
            this.BTN_CONFIRMAR.Size = new System.Drawing.Size(73, 41);
            this.BTN_CONFIRMAR.TabIndex = 4;
            this.BTN_CONFIRMAR.Text = "&Conectar";
            this.BTN_CONFIRMAR.UseVisualStyleBackColor = true;
            this.BTN_CONFIRMAR.Click += new System.EventHandler(this.BTN_CONECTAR_Click);
            // 
            // BTN_VOLTAR
            // 
            this.BTN_VOLTAR.Location = new System.Drawing.Point(12, 141);
            this.BTN_VOLTAR.Name = "BTN_VOLTAR";
            this.BTN_VOLTAR.Size = new System.Drawing.Size(73, 41);
            this.BTN_VOLTAR.TabIndex = 3;
            this.BTN_VOLTAR.Text = "C&ancelar";
            this.BTN_VOLTAR.UseVisualStyleBackColor = true;
            this.BTN_VOLTAR.Click += new System.EventHandler(this.BTN_VOLTAR_Click);
            // 
            // TXT_LOGIN
            // 
            this.TXT_LOGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_LOGIN.Location = new System.Drawing.Point(12, 46);
            this.TXT_LOGIN.Name = "TXT_LOGIN";
            this.TXT_LOGIN.Size = new System.Drawing.Size(179, 24);
            this.TXT_LOGIN.TabIndex = 1;
            this.TXT_LOGIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_LOGIN_KeyPress);
            // 
            // TXT_SENHA
            // 
            this.TXT_SENHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_SENHA.Location = new System.Drawing.Point(12, 93);
            this.TXT_SENHA.Name = "TXT_SENHA";
            this.TXT_SENHA.Size = new System.Drawing.Size(179, 24);
            this.TXT_SENHA.TabIndex = 2;
            this.TXT_SENHA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_SENHA_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hotel Para Todes";
            // 
            // LBL_VER_SENHA
            // 
            this.LBL_VER_SENHA.BackColor = System.Drawing.Color.Transparent;
            this.LBL_VER_SENHA.Location = new System.Drawing.Point(160, 94);
            this.LBL_VER_SENHA.Name = "LBL_VER_SENHA";
            this.LBL_VER_SENHA.Size = new System.Drawing.Size(30, 22);
            this.LBL_VER_SENHA.TabIndex = 7;
            this.LBL_VER_SENHA.Text = "VER";
            this.LBL_VER_SENHA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_VER_SENHA.MouseEnter += new System.EventHandler(this.LBL_VER_SENHA_MouseEnter);
            this.LBL_VER_SENHA.MouseLeave += new System.EventHandler(this.LBL_VER_SENHA_MouseLeave);
            // 
            // TELA_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 194);
            this.Controls.Add(this.LBL_VER_SENHA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_SENHA);
            this.Controls.Add(this.TXT_LOGIN);
            this.Controls.Add(this.BTN_VOLTAR);
            this.Controls.Add(this.BTN_CONFIRMAR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TELA_LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acesso ao Sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TELA_LOGIN_FormClosing);
            this.Load += new System.EventHandler(this.TELA_LOGIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_CONFIRMAR;
        private System.Windows.Forms.Button BTN_VOLTAR;
        private System.Windows.Forms.TextBox TXT_LOGIN;
        private System.Windows.Forms.MaskedTextBox TXT_SENHA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LBL_VER_SENHA;
    }
}