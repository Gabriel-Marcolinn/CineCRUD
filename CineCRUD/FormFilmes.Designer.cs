namespace CineCRUD
{
    partial class FormFilmes
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilmes));
            this.listaFilmes = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abreArqDialog = new System.Windows.Forms.OpenFileDialog();
            this.salvaArquivoDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listaFilmes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaFilmes
            // 
            this.listaFilmes.AllowUserToAddRows = false;
            this.listaFilmes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaFilmes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.listaFilmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaFilmes.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listaFilmes.Location = new System.Drawing.Point(0, 63);
            this.listaFilmes.Name = "listaFilmes";
            this.listaFilmes.ShowEditingIcon = false;
            this.listaFilmes.Size = new System.Drawing.Size(800, 387);
            this.listaFilmes.TabIndex = 0;
            this.listaFilmes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaFilmes_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.carregarToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // carregarToolStripMenuItem
            // 
            this.carregarToolStripMenuItem.Name = "carregarToolStripMenuItem";
            this.carregarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.carregarToolStripMenuItem.Text = "Carregar";
            this.carregarToolStripMenuItem.Click += new System.EventHandler(this.carregarToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // abreArqDialog
            // 
            this.abreArqDialog.FileName = "openFileDialog1";
            this.abreArqDialog.Filter = "Arquivos XML|*xml";
            // 
            // salvaArquivoDialog
            // 
            this.salvaArquivoDialog.Filter = "Arquivos XML|*xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista dos filmes cadastrados";
            // 
            // FormFilmes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaFilmes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormFilmes";
            this.Text = "Cine CRUD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFilmes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.listaFilmes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaFilmes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog abreArqDialog;
        private System.Windows.Forms.SaveFileDialog salvaArquivoDialog;
        private System.Windows.Forms.Label label1;
    }
}

