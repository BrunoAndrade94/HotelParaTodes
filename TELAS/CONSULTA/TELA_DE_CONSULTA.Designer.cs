
namespace MVSOUL.TELAS.TELA_CONSULTA
{
    partial class TELA_DE_CONSULTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TELA_DE_CONSULTA));
            this.LST_ITENS = new System.Windows.Forms.ListBox();
            this.TXT_CRITERIO = new System.Windows.Forms.TextBox();
            this.LBL_CRITERIO = new System.Windows.Forms.Label();
            this.BTN_FILTRAR = new System.Windows.Forms.Button();
            this.BTN_RECUAR = new System.Windows.Forms.Button();
            this.BTN_AVANCAR = new System.Windows.Forms.Button();
            this.LBL_N_PAGINAS = new System.Windows.Forms.Label();
            this.TXT_N_PAG = new System.Windows.Forms.TextBox();
            this.TXT_PAG_ATUAL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LST_ITENS
            // 
            this.LST_ITENS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LST_ITENS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_ITENS.FormattingEnabled = true;
            this.LST_ITENS.ItemHeight = 18;
            this.LST_ITENS.Location = new System.Drawing.Point(12, 49);
            this.LST_ITENS.Name = "LST_ITENS";
            this.LST_ITENS.Size = new System.Drawing.Size(467, 184);
            this.LST_ITENS.Sorted = true;
            this.LST_ITENS.TabIndex = 10;
            this.LST_ITENS.TabStop = false;
            this.LST_ITENS.SelectedIndexChanged += new System.EventHandler(this.LST_ITENS_SelectedIndexChanged);
            // 
            // TXT_CRITERIO
            // 
            this.TXT_CRITERIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_CRITERIO.Location = new System.Drawing.Point(57, 13);
            this.TXT_CRITERIO.Name = "TXT_CRITERIO";
            this.TXT_CRITERIO.Size = new System.Drawing.Size(369, 20);
            this.TXT_CRITERIO.TabIndex = 0;
            this.TXT_CRITERIO.TextChanged += new System.EventHandler(this.TXT_CRITERIO_TextChanged);
            // 
            // LBL_CRITERIO
            // 
            this.LBL_CRITERIO.AutoSize = true;
            this.LBL_CRITERIO.Location = new System.Drawing.Point(12, 19);
            this.LBL_CRITERIO.Name = "LBL_CRITERIO";
            this.LBL_CRITERIO.Size = new System.Drawing.Size(42, 13);
            this.LBL_CRITERIO.TabIndex = 2;
            this.LBL_CRITERIO.Text = "Critério:";
            // 
            // BTN_FILTRAR
            // 
            this.BTN_FILTRAR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTN_FILTRAR.Location = new System.Drawing.Point(432, 13);
            this.BTN_FILTRAR.Name = "BTN_FILTRAR";
            this.BTN_FILTRAR.Size = new System.Drawing.Size(47, 20);
            this.BTN_FILTRAR.TabIndex = 3;
            this.BTN_FILTRAR.Text = "Filtrar";
            this.BTN_FILTRAR.UseVisualStyleBackColor = true;
            this.BTN_FILTRAR.Click += new System.EventHandler(this.BTN_FILTRAR_Click);
            // 
            // BTN_RECUAR
            // 
            this.BTN_RECUAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_RECUAR.Location = new System.Drawing.Point(361, 241);
            this.BTN_RECUAR.Name = "BTN_RECUAR";
            this.BTN_RECUAR.Size = new System.Drawing.Size(56, 29);
            this.BTN_RECUAR.TabIndex = 5;
            this.BTN_RECUAR.Text = "&Recuar";
            this.BTN_RECUAR.UseVisualStyleBackColor = true;
            this.BTN_RECUAR.Click += new System.EventHandler(this.BTN_RECUAR_Click);
            // 
            // BTN_AVANCAR
            // 
            this.BTN_AVANCAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_AVANCAR.Location = new System.Drawing.Point(423, 241);
            this.BTN_AVANCAR.Name = "BTN_AVANCAR";
            this.BTN_AVANCAR.Size = new System.Drawing.Size(56, 29);
            this.BTN_AVANCAR.TabIndex = 6;
            this.BTN_AVANCAR.Text = "&Avançar";
            this.BTN_AVANCAR.UseVisualStyleBackColor = true;
            this.BTN_AVANCAR.Click += new System.EventHandler(this.BTN_AVANCAR_Click);
            // 
            // LBL_N_PAGINAS
            // 
            this.LBL_N_PAGINAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_N_PAGINAS.AutoSize = true;
            this.LBL_N_PAGINAS.BackColor = System.Drawing.Color.Transparent;
            this.LBL_N_PAGINAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_N_PAGINAS.Location = new System.Drawing.Point(212, 250);
            this.LBL_N_PAGINAS.Name = "LBL_N_PAGINAS";
            this.LBL_N_PAGINAS.Size = new System.Drawing.Size(50, 16);
            this.LBL_N_PAGINAS.TabIndex = 8;
            this.LBL_N_PAGINAS.Text = "página";
            // 
            // TXT_N_PAG
            // 
            this.TXT_N_PAG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_N_PAG.Enabled = false;
            this.TXT_N_PAG.HideSelection = false;
            this.TXT_N_PAG.Location = new System.Drawing.Point(328, 246);
            this.TXT_N_PAG.Name = "TXT_N_PAG";
            this.TXT_N_PAG.ReadOnly = true;
            this.TXT_N_PAG.Size = new System.Drawing.Size(24, 20);
            this.TXT_N_PAG.TabIndex = 0;
            this.TXT_N_PAG.WordWrap = false;
            // 
            // TXT_PAG_ATUAL
            // 
            this.TXT_PAG_ATUAL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_PAG_ATUAL.Enabled = false;
            this.TXT_PAG_ATUAL.HideSelection = false;
            this.TXT_PAG_ATUAL.Location = new System.Drawing.Point(268, 246);
            this.TXT_PAG_ATUAL.Name = "TXT_PAG_ATUAL";
            this.TXT_PAG_ATUAL.ReadOnly = true;
            this.TXT_PAG_ATUAL.Size = new System.Drawing.Size(24, 20);
            this.TXT_PAG_ATUAL.TabIndex = 11;
            this.TXT_PAG_ATUAL.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "de";
            // 
            // TELA_DE_CONSULTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_PAG_ATUAL);
            this.Controls.Add(this.TXT_N_PAG);
            this.Controls.Add(this.LBL_N_PAGINAS);
            this.Controls.Add(this.BTN_AVANCAR);
            this.Controls.Add(this.BTN_RECUAR);
            this.Controls.Add(this.BTN_FILTRAR);
            this.Controls.Add(this.LBL_CRITERIO);
            this.Controls.Add(this.TXT_CRITERIO);
            this.Controls.Add(this.LST_ITENS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TELA_DE_CONSULTA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.TELA_DE_CONSULTA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LST_ITENS;
        private System.Windows.Forms.TextBox TXT_CRITERIO;
        private System.Windows.Forms.Label LBL_CRITERIO;
        private System.Windows.Forms.Button BTN_FILTRAR;
        private System.Windows.Forms.Button BTN_RECUAR;
        private System.Windows.Forms.Button BTN_AVANCAR;
        private System.Windows.Forms.Label LBL_N_PAGINAS;
        private System.Windows.Forms.TextBox TXT_N_PAG;
        private System.Windows.Forms.TextBox TXT_PAG_ATUAL;
        private System.Windows.Forms.Label label1;
    }
}