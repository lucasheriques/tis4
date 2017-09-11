namespace APAC_TIS4
{
    partial class frmCadastrarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastrarCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtLocalidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.bntCadastrar = new System.Windows.Forms.Button();
            this.bntCancelar = new System.Windows.Forms.Button();
            this.bntSair = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insumoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.insumoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.receitaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exclusãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.insumoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.receitaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.insumoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.receitaToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.produçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lucrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.bancoDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome: ";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(120, 46);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(287, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtLocalidade
            // 
            this.txtLocalidade.Location = new System.Drawing.Point(120, 113);
            this.txtLocalidade.Multiline = true;
            this.txtLocalidade.Name = "txtLocalidade";
            this.txtLocalidade.Size = new System.Drawing.Size(287, 92);
            this.txtLocalidade.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Localidade: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo: ";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Pátio de Obras",
            "Escolas",
            "Casas de Acolhimento"});
            this.cmbTipo.Location = new System.Drawing.Point(120, 240);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(287, 21);
            this.cmbTipo.TabIndex = 5;
            // 
            // bntCadastrar
            // 
            this.bntCadastrar.Location = new System.Drawing.Point(48, 318);
            this.bntCadastrar.Name = "bntCadastrar";
            this.bntCadastrar.Size = new System.Drawing.Size(75, 23);
            this.bntCadastrar.TabIndex = 6;
            this.bntCadastrar.Text = "Cadastrar";
            this.bntCadastrar.UseVisualStyleBackColor = true;
            this.bntCadastrar.Click += new System.EventHandler(this.bntCadastrar_Click);
            // 
            // bntCancelar
            // 
            this.bntCancelar.Location = new System.Drawing.Point(186, 318);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(75, 23);
            this.bntCancelar.TabIndex = 7;
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.UseVisualStyleBackColor = true;
            this.bntCancelar.Click += new System.EventHandler(this.bntCancelar_Click);
            // 
            // bntSair
            // 
            this.bntSair.Location = new System.Drawing.Point(332, 318);
            this.bntSair.Name = "bntSair";
            this.bntSair.Size = new System.Drawing.Size(75, 23);
            this.bntSair.TabIndex = 8;
            this.bntSair.Text = "Sair";
            this.bntSair.UseVisualStyleBackColor = true;
            this.bntSair.Click += new System.EventHandler(this.bntSair_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1305, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.atualizaçãoToolStripMenuItem,
            this.exclusãoToolStripMenuItem,
            this.visualizaçãoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItem1.Text = "Gerência";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.insumoToolStripMenuItem,
            this.pedidoToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.receitaToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem3.Text = "Cadastro";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // insumoToolStripMenuItem
            // 
            this.insumoToolStripMenuItem.Name = "insumoToolStripMenuItem";
            this.insumoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.insumoToolStripMenuItem.Text = "Insumo";
            this.insumoToolStripMenuItem.Click += new System.EventHandler(this.insumoToolStripMenuItem_Click);
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            this.pedidoToolStripMenuItem.Click += new System.EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // receitaToolStripMenuItem
            // 
            this.receitaToolStripMenuItem.Name = "receitaToolStripMenuItem";
            this.receitaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.receitaToolStripMenuItem.Text = "Receita";
            this.receitaToolStripMenuItem.Click += new System.EventHandler(this.receitaToolStripMenuItem_Click);
            // 
            // atualizaçãoToolStripMenuItem
            // 
            this.atualizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem1,
            this.insumoToolStripMenuItem1,
            this.pedidoToolStripMenuItem1,
            this.produtoToolStripMenuItem1,
            this.receitaToolStripMenuItem1});
            this.atualizaçãoToolStripMenuItem.Name = "atualizaçãoToolStripMenuItem";
            this.atualizaçãoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.atualizaçãoToolStripMenuItem.Text = "Atualização";
            // 
            // clienteToolStripMenuItem1
            // 
            this.clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            this.clienteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.clienteToolStripMenuItem1.Text = "Cliente";
            this.clienteToolStripMenuItem1.Click += new System.EventHandler(this.clienteToolStripMenuItem1_Click);
            // 
            // insumoToolStripMenuItem1
            // 
            this.insumoToolStripMenuItem1.Name = "insumoToolStripMenuItem1";
            this.insumoToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.insumoToolStripMenuItem1.Text = "Insumo";
            this.insumoToolStripMenuItem1.Click += new System.EventHandler(this.insumoToolStripMenuItem1_Click);
            // 
            // pedidoToolStripMenuItem1
            // 
            this.pedidoToolStripMenuItem1.Name = "pedidoToolStripMenuItem1";
            this.pedidoToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.pedidoToolStripMenuItem1.Text = "Pedido";
            // 
            // produtoToolStripMenuItem1
            // 
            this.produtoToolStripMenuItem1.Name = "produtoToolStripMenuItem1";
            this.produtoToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.produtoToolStripMenuItem1.Text = "Produto";
            // 
            // receitaToolStripMenuItem1
            // 
            this.receitaToolStripMenuItem1.Name = "receitaToolStripMenuItem1";
            this.receitaToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.receitaToolStripMenuItem1.Text = "Receita";
            // 
            // exclusãoToolStripMenuItem
            // 
            this.exclusãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem2,
            this.insumoToolStripMenuItem2,
            this.pedidoToolStripMenuItem2,
            this.produtoToolStripMenuItem2,
            this.receitaToolStripMenuItem2});
            this.exclusãoToolStripMenuItem.Name = "exclusãoToolStripMenuItem";
            this.exclusãoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exclusãoToolStripMenuItem.Text = "Exclusão";
            // 
            // clienteToolStripMenuItem2
            // 
            this.clienteToolStripMenuItem2.Name = "clienteToolStripMenuItem2";
            this.clienteToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.clienteToolStripMenuItem2.Text = "Cliente";
            // 
            // insumoToolStripMenuItem2
            // 
            this.insumoToolStripMenuItem2.Name = "insumoToolStripMenuItem2";
            this.insumoToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.insumoToolStripMenuItem2.Text = "Insumo";
            // 
            // pedidoToolStripMenuItem2
            // 
            this.pedidoToolStripMenuItem2.Name = "pedidoToolStripMenuItem2";
            this.pedidoToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.pedidoToolStripMenuItem2.Text = "Pedido";
            // 
            // produtoToolStripMenuItem2
            // 
            this.produtoToolStripMenuItem2.Name = "produtoToolStripMenuItem2";
            this.produtoToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.produtoToolStripMenuItem2.Text = "Produto";
            // 
            // receitaToolStripMenuItem2
            // 
            this.receitaToolStripMenuItem2.Name = "receitaToolStripMenuItem2";
            this.receitaToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.receitaToolStripMenuItem2.Text = "Receita";
            // 
            // visualizaçãoToolStripMenuItem
            // 
            this.visualizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem3,
            this.insumoToolStripMenuItem3,
            this.pedidoToolStripMenuItem3,
            this.produtoToolStripMenuItem3,
            this.receitaToolStripMenuItem3});
            this.visualizaçãoToolStripMenuItem.Name = "visualizaçãoToolStripMenuItem";
            this.visualizaçãoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.visualizaçãoToolStripMenuItem.Text = "Visualização";
            // 
            // clienteToolStripMenuItem3
            // 
            this.clienteToolStripMenuItem3.Name = "clienteToolStripMenuItem3";
            this.clienteToolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.clienteToolStripMenuItem3.Text = "Cliente";
            this.clienteToolStripMenuItem3.Click += new System.EventHandler(this.clienteToolStripMenuItem3_Click);
            // 
            // insumoToolStripMenuItem3
            // 
            this.insumoToolStripMenuItem3.Name = "insumoToolStripMenuItem3";
            this.insumoToolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.insumoToolStripMenuItem3.Text = "Insumo";
            this.insumoToolStripMenuItem3.Click += new System.EventHandler(this.insumoToolStripMenuItem3_Click);
            // 
            // pedidoToolStripMenuItem3
            // 
            this.pedidoToolStripMenuItem3.Name = "pedidoToolStripMenuItem3";
            this.pedidoToolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.pedidoToolStripMenuItem3.Text = "Pedido";
            this.pedidoToolStripMenuItem3.Click += new System.EventHandler(this.pedidoToolStripMenuItem3_Click);
            // 
            // produtoToolStripMenuItem3
            // 
            this.produtoToolStripMenuItem3.Name = "produtoToolStripMenuItem3";
            this.produtoToolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.produtoToolStripMenuItem3.Text = "Produto";
            this.produtoToolStripMenuItem3.Click += new System.EventHandler(this.produtoToolStripMenuItem3_Click);
            // 
            // receitaToolStripMenuItem3
            // 
            this.receitaToolStripMenuItem3.Name = "receitaToolStripMenuItem3";
            this.receitaToolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.receitaToolStripMenuItem3.Text = "Receita";
            this.receitaToolStripMenuItem3.Click += new System.EventHandler(this.receitaToolStripMenuItem3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produçãoToolStripMenuItem,
            this.gastosToolStripMenuItem,
            this.lucrosToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem2.Text = "Relatório";
            // 
            // produçãoToolStripMenuItem
            // 
            this.produçãoToolStripMenuItem.Name = "produçãoToolStripMenuItem";
            this.produçãoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.produçãoToolStripMenuItem.Text = "Produção";
            // 
            // gastosToolStripMenuItem
            // 
            this.gastosToolStripMenuItem.Name = "gastosToolStripMenuItem";
            this.gastosToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.gastosToolStripMenuItem.Text = "Gastos";
            // 
            // lucrosToolStripMenuItem
            // 
            this.lucrosToolStripMenuItem.Name = "lucrosToolStripMenuItem";
            this.lucrosToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.lucrosToolStripMenuItem.Text = "Lucros";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bancoDeDadosToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(96, 20);
            this.toolStripMenuItem4.Text = "Configurações";
            // 
            // bancoDeDadosToolStripMenuItem
            // 
            this.bancoDeDadosToolStripMenuItem.Name = "bancoDeDadosToolStripMenuItem";
            this.bancoDeDadosToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bancoDeDadosToolStripMenuItem.Text = "Banco de Dados";
            this.bancoDeDadosToolStripMenuItem.Click += new System.EventHandler(this.bancoDeDadosToolStripMenuItem_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(27, 406);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(1256, 197);
            this.dgvClientes.TabIndex = 10;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtDescricao.Location = new System.Drawing.Point(539, 46);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(380, 210);
            this.txtDescricao.TabIndex = 11;
            this.txtDescricao.Text = "Nesta tela o responsável pela gerência da padaria cadastra os clientes que solici" +
    "tam a entrega dos produtos produzidos pela padaria da APAC.";
            // 
            // frmCadastrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1305, 615);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.bntSair);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.bntCadastrar);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocalidade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastrarCliente";
            this.Text = "Cadastrar Cliente";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtLocalidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button bntCadastrar;
        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.Button bntSair;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insumoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem insumoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem receitaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exclusãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem insumoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem receitaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem visualizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem insumoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem receitaToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem produçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gastosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lucrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ToolStripMenuItem bancoDeDadosToolStripMenuItem;
    }
}