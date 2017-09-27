namespace APAC_TIS4
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gdfgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.clientsTab = new MetroFramework.Controls.MetroTabPage();
            this.btnUpdateClient = new MetroFramework.Controls.MetroButton();
            this.lblClientID = new MetroFramework.Controls.MetroLabel();
            this.txtClientId = new MetroFramework.Controls.MetroTextBox();
            this.lblReturnLabel = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnClientDelMenu = new MetroFramework.Controls.MetroButton();
            this.btnClientUpdateMenu = new MetroFramework.Controls.MetroButton();
            this.btnClientAddMenu = new MetroFramework.Controls.MetroButton();
            this.spiClientActions = new MetroFramework.Controls.MetroProgressSpinner();
            this.btnAddClient = new MetroFramework.Controls.MetroButton();
            this.cmdClientType = new MetroFramework.Controls.MetroComboBox();
            this.lblClientType = new MetroFramework.Controls.MetroLabel();
            this.lblClientAddress = new MetroFramework.Controls.MetroLabel();
            this.txtClientLocal = new MetroFramework.Controls.MetroTextBox();
            this.lblClientName = new MetroFramework.Controls.MetroLabel();
            this.txtClientName = new MetroFramework.Controls.MetroTextBox();
            this.dvgClientes = new MetroFramework.Controls.MetroGrid();
            this.entityTab = new MetroFramework.Controls.MetroTabControl();
            this.ItemsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip3.SuspendLayout();
            this.clientsTab.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgClientes)).BeginInit();
            this.entityTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gdfgToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(103, 26);
            // 
            // gdfgToolStripMenuItem
            // 
            this.gdfgToolStripMenuItem.Name = "gdfgToolStripMenuItem";
            this.gdfgToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.gdfgToolStripMenuItem.Text = "gdfg.";
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1297, 470);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "metroTabPage1";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // clientsTab
            // 
            this.clientsTab.Controls.Add(this.btnUpdateClient);
            this.clientsTab.Controls.Add(this.lblClientID);
            this.clientsTab.Controls.Add(this.txtClientId);
            this.clientsTab.Controls.Add(this.lblReturnLabel);
            this.clientsTab.Controls.Add(this.metroPanel1);
            this.clientsTab.Controls.Add(this.spiClientActions);
            this.clientsTab.Controls.Add(this.btnAddClient);
            this.clientsTab.Controls.Add(this.cmdClientType);
            this.clientsTab.Controls.Add(this.lblClientType);
            this.clientsTab.Controls.Add(this.lblClientAddress);
            this.clientsTab.Controls.Add(this.txtClientLocal);
            this.clientsTab.Controls.Add(this.lblClientName);
            this.clientsTab.Controls.Add(this.txtClientName);
            this.clientsTab.Controls.Add(this.dvgClientes);
            this.clientsTab.HorizontalScrollbarBarColor = true;
            this.clientsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.clientsTab.HorizontalScrollbarSize = 10;
            this.clientsTab.Location = new System.Drawing.Point(4, 38);
            this.clientsTab.Name = "clientsTab";
            this.clientsTab.Size = new System.Drawing.Size(1297, 467);
            this.clientsTab.TabIndex = 1;
            this.clientsTab.Text = "Clientes";
            this.clientsTab.Theme = MetroFramework.MetroThemeStyle.Light;
            this.clientsTab.VerticalScrollbarBarColor = true;
            this.clientsTab.VerticalScrollbarHighlightOnWheel = false;
            this.clientsTab.VerticalScrollbarSize = 10;
            this.clientsTab.Click += new System.EventHandler(this.clientsTab_Click);
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateClient.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateClient.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnUpdateClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateClient.Location = new System.Drawing.Point(966, 321);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(150, 31);
            this.btnUpdateClient.TabIndex = 16;
            this.btnUpdateClient.Text = "Atualizar cliente";
            this.btnUpdateClient.UseCustomBackColor = true;
            this.btnUpdateClient.UseCustomForeColor = true;
            this.btnUpdateClient.UseSelectable = true;
            this.btnUpdateClient.UseStyleColors = true;
            this.btnUpdateClient.Visible = false;
            this.btnUpdateClient.Click += new System.EventHandler(this.btnUpdateClient_Click);
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(0, 55);
            this.lblClientID.Margin = new System.Windows.Forms.Padding(0);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(21, 19);
            this.lblClientID.TabIndex = 15;
            this.lblClientID.Text = "ID";
            this.lblClientID.Visible = false;
            // 
            // txtClientId
            // 
            this.txtClientId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientId.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.txtClientId.CustomButton.Image = null;
            this.txtClientId.CustomButton.Location = new System.Drawing.Point(12, 1);
            this.txtClientId.CustomButton.Name = "";
            this.txtClientId.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtClientId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtClientId.CustomButton.TabIndex = 1;
            this.txtClientId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtClientId.CustomButton.UseSelectable = true;
            this.txtClientId.CustomButton.Visible = false;
            this.txtClientId.DisplayIcon = true;
            this.txtClientId.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtClientId.Lines = new string[0];
            this.txtClientId.Location = new System.Drawing.Point(0, 77);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(32, 3, 3, 32);
            this.txtClientId.MaxLength = 32767;
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.PasswordChar = '\0';
            this.txtClientId.ReadOnly = true;
            this.txtClientId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClientId.SelectedText = "";
            this.txtClientId.SelectionLength = 0;
            this.txtClientId.SelectionStart = 0;
            this.txtClientId.ShortcutsEnabled = true;
            this.txtClientId.Size = new System.Drawing.Size(46, 35);
            this.txtClientId.TabIndex = 14;
            this.txtClientId.UseCustomBackColor = true;
            this.txtClientId.UseCustomForeColor = true;
            this.txtClientId.UseSelectable = true;
            this.txtClientId.Visible = false;
            this.txtClientId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtClientId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblReturnLabel
            // 
            this.lblReturnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReturnLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblReturnLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblReturnLabel.Location = new System.Drawing.Point(929, 365);
            this.lblReturnLabel.Name = "lblReturnLabel";
            this.lblReturnLabel.Size = new System.Drawing.Size(366, 23);
            this.lblReturnLabel.TabIndex = 13;
            this.lblReturnLabel.Text = "Cliente adicionado com sucesso!";
            this.lblReturnLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblReturnLabel.Visible = false;
            this.lblReturnLabel.Click += new System.EventHandler(this.lblReturnLabel_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.metroPanel1.Controls.Add(this.btnClientDelMenu);
            this.metroPanel1.Controls.Add(this.btnClientUpdateMenu);
            this.metroPanel1.Controls.Add(this.btnClientAddMenu);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(-4, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1302, 42);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.White;
            this.metroPanel1.TabIndex = 12;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseCustomForeColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnClientDelMenu
            // 
            this.btnClientDelMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClientDelMenu.Location = new System.Drawing.Point(275, 3);
            this.btnClientDelMenu.Name = "btnClientDelMenu";
            this.btnClientDelMenu.Size = new System.Drawing.Size(128, 29);
            this.btnClientDelMenu.TabIndex = 4;
            this.btnClientDelMenu.Text = "Excluir";
            this.btnClientDelMenu.UseSelectable = true;
            // 
            // btnClientUpdateMenu
            // 
            this.btnClientUpdateMenu.Location = new System.Drawing.Point(141, 3);
            this.btnClientUpdateMenu.Name = "btnClientUpdateMenu";
            this.btnClientUpdateMenu.Size = new System.Drawing.Size(128, 29);
            this.btnClientUpdateMenu.TabIndex = 3;
            this.btnClientUpdateMenu.Text = "Atualizar";
            this.btnClientUpdateMenu.UseSelectable = true;
            this.btnClientUpdateMenu.Click += new System.EventHandler(this.btnClientUpdateMenu_Click);
            // 
            // btnClientAddMenu
            // 
            this.btnClientAddMenu.Location = new System.Drawing.Point(7, 3);
            this.btnClientAddMenu.Name = "btnClientAddMenu";
            this.btnClientAddMenu.Size = new System.Drawing.Size(128, 29);
            this.btnClientAddMenu.TabIndex = 2;
            this.btnClientAddMenu.Text = "Adicionar";
            this.btnClientAddMenu.UseSelectable = true;
            this.btnClientAddMenu.Click += new System.EventHandler(this.btnClientAddMenu_Click);
            // 
            // spiClientActions
            // 
            this.spiClientActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spiClientActions.Location = new System.Drawing.Point(1108, 321);
            this.spiClientActions.Maximum = 100;
            this.spiClientActions.Name = "spiClientActions";
            this.spiClientActions.Size = new System.Drawing.Size(27, 31);
            this.spiClientActions.TabIndex = 10;
            this.spiClientActions.UseSelectable = true;
            this.spiClientActions.Value = 20;
            this.spiClientActions.Visible = false;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddClient.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddClient.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAddClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddClient.Location = new System.Drawing.Point(1145, 321);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(150, 31);
            this.btnAddClient.TabIndex = 3;
            this.btnAddClient.Text = "Adicionar cliente";
            this.btnAddClient.UseCustomBackColor = true;
            this.btnAddClient.UseCustomForeColor = true;
            this.btnAddClient.UseSelectable = true;
            this.btnAddClient.UseStyleColors = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // cmdClientType
            // 
            this.cmdClientType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClientType.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.cmdClientType.FormattingEnabled = true;
            this.cmdClientType.ItemHeight = 29;
            this.cmdClientType.Items.AddRange(new object[] {
            "Pátio de Obras",
            "Escolas",
            "Casas de Acolhimento"});
            this.cmdClientType.Location = new System.Drawing.Point(969, 147);
            this.cmdClientType.Name = "cmdClientType";
            this.cmdClientType.Size = new System.Drawing.Size(325, 35);
            this.cmdClientType.TabIndex = 2;
            this.cmdClientType.UseSelectable = true;
            // 
            // lblClientType
            // 
            this.lblClientType.AutoSize = true;
            this.lblClientType.Location = new System.Drawing.Point(966, 125);
            this.lblClientType.Name = "lblClientType";
            this.lblClientType.Size = new System.Drawing.Size(35, 19);
            this.lblClientType.TabIndex = 8;
            this.lblClientType.Text = "Tipo";
            // 
            // lblClientAddress
            // 
            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.Location = new System.Drawing.Point(0, 195);
            this.lblClientAddress.Name = "lblClientAddress";
            this.lblClientAddress.Size = new System.Drawing.Size(72, 19);
            this.lblClientAddress.TabIndex = 6;
            this.lblClientAddress.Text = "Localidade";
            // 
            // txtClientLocal
            // 
            this.txtClientLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtClientLocal.CustomButton.Image = null;
            this.txtClientLocal.CustomButton.Location = new System.Drawing.Point(1226, 1);
            this.txtClientLocal.CustomButton.Name = "";
            this.txtClientLocal.CustomButton.Size = new System.Drawing.Size(67, 67);
            this.txtClientLocal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtClientLocal.CustomButton.TabIndex = 1;
            this.txtClientLocal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtClientLocal.CustomButton.UseSelectable = true;
            this.txtClientLocal.CustomButton.Visible = false;
            this.txtClientLocal.DisplayIcon = true;
            this.txtClientLocal.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtClientLocal.Lines = new string[0];
            this.txtClientLocal.Location = new System.Drawing.Point(0, 217);
            this.txtClientLocal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 32);
            this.txtClientLocal.MaxLength = 32767;
            this.txtClientLocal.Multiline = true;
            this.txtClientLocal.Name = "txtClientLocal";
            this.txtClientLocal.PasswordChar = '\0';
            this.txtClientLocal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClientLocal.SelectedText = "";
            this.txtClientLocal.SelectionLength = 0;
            this.txtClientLocal.SelectionStart = 0;
            this.txtClientLocal.ShortcutsEnabled = true;
            this.txtClientLocal.Size = new System.Drawing.Size(1294, 69);
            this.txtClientLocal.TabIndex = 1;
            this.txtClientLocal.UseSelectable = true;
            this.txtClientLocal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtClientLocal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(0, 125);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(0);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(46, 19);
            this.lblClientName.TabIndex = 4;
            this.lblClientName.Text = "Nome";
            // 
            // txtClientName
            // 
            this.txtClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtClientName.CustomButton.Image = null;
            this.txtClientName.CustomButton.Location = new System.Drawing.Point(577, 1);
            this.txtClientName.CustomButton.Name = "";
            this.txtClientName.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtClientName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtClientName.CustomButton.TabIndex = 1;
            this.txtClientName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtClientName.CustomButton.UseSelectable = true;
            this.txtClientName.CustomButton.Visible = false;
            this.txtClientName.DisplayIcon = true;
            this.txtClientName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtClientName.Lines = new string[0];
            this.txtClientName.Location = new System.Drawing.Point(0, 147);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(32, 3, 3, 32);
            this.txtClientName.MaxLength = 32767;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.PasswordChar = '\0';
            this.txtClientName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClientName.SelectedText = "";
            this.txtClientName.SelectionLength = 0;
            this.txtClientName.SelectionStart = 0;
            this.txtClientName.ShortcutsEnabled = true;
            this.txtClientName.Size = new System.Drawing.Size(611, 35);
            this.txtClientName.TabIndex = 0;
            this.txtClientName.UseSelectable = true;
            this.txtClientName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtClientName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dvgClientes
            // 
            this.dvgClientes.AllowUserToAddRows = false;
            this.dvgClientes.AllowUserToDeleteRows = false;
            this.dvgClientes.AllowUserToOrderColumns = true;
            this.dvgClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dvgClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dvgClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dvgClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemsSelected,
            this.Editar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dvgClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvgClientes.EnableHeadersVisualStyles = false;
            this.dvgClientes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dvgClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dvgClientes.Location = new System.Drawing.Point(0, 55);
            this.dvgClientes.Name = "dvgClientes";
            this.dvgClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dvgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgClientes.Size = new System.Drawing.Size(1297, 412);
            this.dvgClientes.Style = MetroFramework.MetroColorStyle.Green;
            this.dvgClientes.TabIndex = 2;
            this.dvgClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgClientes_CellContentClick);
            // 
            // entityTab
            // 
            this.entityTab.Controls.Add(this.clientsTab);
            this.entityTab.Controls.Add(this.metroTabPage1);
            this.entityTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityTab.Location = new System.Drawing.Point(0, 60);
            this.entityTab.Margin = new System.Windows.Forms.Padding(30, 32, 32, 3);
            this.entityTab.Name = "entityTab";
            this.entityTab.SelectedIndex = 0;
            this.entityTab.Size = new System.Drawing.Size(1305, 509);
            this.entityTab.Style = MetroFramework.MetroColorStyle.Green;
            this.entityTab.TabIndex = 3;
            this.entityTab.UseSelectable = true;
            // 
            // ItemsSelected
            // 
            this.ItemsSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemsSelected.FillWeight = 0.7868021F;
            this.ItemsSelected.HeaderText = "#";
            this.ItemsSelected.Name = "ItemsSelected";
            this.ItemsSelected.Width = 18;
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Editar.FillWeight = 30.2132F;
            this.Editar.HeaderText = "Atualizar";
            this.Editar.Name = "Editar";
            this.Editar.Width = 56;
            // 
            // frmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(1305, 569);
            this.Controls.Add(this.entityTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "Padaria APAC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip3.ResumeLayout(false);
            this.clientsTab.ResumeLayout(false);
            this.clientsTab.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgClientes)).EndInit();
            this.entityTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem gdfgToolStripMenuItem;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage clientsTab;
        private MetroFramework.Controls.MetroButton btnUpdateClient;
        private MetroFramework.Controls.MetroLabel lblClientID;
        private MetroFramework.Controls.MetroTextBox txtClientId;
        private MetroFramework.Controls.MetroLabel lblReturnLabel;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnClientDelMenu;
        private MetroFramework.Controls.MetroButton btnClientUpdateMenu;
        private MetroFramework.Controls.MetroButton btnClientAddMenu;
        private MetroFramework.Controls.MetroProgressSpinner spiClientActions;
        private MetroFramework.Controls.MetroButton btnAddClient;
        private MetroFramework.Controls.MetroComboBox cmdClientType;
        private MetroFramework.Controls.MetroLabel lblClientType;
        private MetroFramework.Controls.MetroLabel lblClientAddress;
        private MetroFramework.Controls.MetroTextBox txtClientLocal;
        private MetroFramework.Controls.MetroLabel lblClientName;
        private MetroFramework.Controls.MetroTextBox txtClientName;
        private MetroFramework.Controls.MetroGrid dvgClientes;
        private MetroFramework.Controls.MetroTabControl entityTab;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemsSelected;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
    }
}

