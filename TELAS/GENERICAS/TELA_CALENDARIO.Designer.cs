
namespace MVSOUL.TELAS.GENERICAS
{
    partial class TELA_CALENDARIO
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
            this.CALENDARIO = new System.Windows.Forms.MonthCalendar();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_VOLTAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CALENDARIO
            // 
            this.CALENDARIO.Location = new System.Drawing.Point(-1, -1);
            this.CALENDARIO.Name = "CALENDARIO";
            this.CALENDARIO.TabIndex = 4;
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(138, 165);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 5;
            this.BTN_OK.Text = "Selecionar";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_VOLTAR
            // 
            this.BTN_VOLTAR.Location = new System.Drawing.Point(12, 165);
            this.BTN_VOLTAR.Name = "BTN_VOLTAR";
            this.BTN_VOLTAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_VOLTAR.TabIndex = 6;
            this.BTN_VOLTAR.TabStop = false;
            this.BTN_VOLTAR.Text = "Voltar";
            this.BTN_VOLTAR.UseVisualStyleBackColor = true;
            this.BTN_VOLTAR.Click += new System.EventHandler(this.BTN_VOLTAR_Click);
            // 
            // TELA_CALENDARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(225, 193);
            this.Controls.Add(this.BTN_VOLTAR);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.CALENDARIO);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TELA_CALENDARIO";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecione a Data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar CALENDARIO;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_VOLTAR;
    }
}