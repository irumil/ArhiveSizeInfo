namespace SssUser
{
    partial class SizeInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SizeInfoForm));
            this.serverInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.getSizeInfoButton = new System.Windows.Forms.Button();
            this.saveListButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.NeedCopy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IpAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // serverInfoDataGridView
            // 
            this.serverInfoDataGridView.AllowUserToAddRows = false;
            this.serverInfoDataGridView.AllowUserToDeleteRows = false;
            this.serverInfoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverInfoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.serverInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NeedCopy,
            this.IpAdress,
            this.Description,
            this.status});
            this.serverInfoDataGridView.Location = new System.Drawing.Point(5, 50);
            this.serverInfoDataGridView.Name = "serverInfoDataGridView";
            this.serverInfoDataGridView.RowHeadersWidth = 25;
            this.serverInfoDataGridView.Size = new System.Drawing.Size(629, 182);
            this.serverInfoDataGridView.TabIndex = 34;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logTextBox.Location = new System.Drawing.Point(5, 238);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(629, 388);
            this.logTextBox.TabIndex = 39;
            // 
            // copyButton
            // 
            this.copyButton.Image = global::SssUser.Properties.Resources.copy;
            this.copyButton.Location = new System.Drawing.Point(232, 4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(40, 40);
            this.copyButton.TabIndex = 41;
            this.toolTip1.SetToolTip(this.copyButton, "Копировать в буфер");
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // getSizeInfoButton
            // 
            this.getSizeInfoButton.Image = global::SssUser.Properties.Resources.clientSize;
            this.getSizeInfoButton.Location = new System.Drawing.Point(186, 4);
            this.getSizeInfoButton.Name = "getSizeInfoButton";
            this.getSizeInfoButton.Size = new System.Drawing.Size(40, 40);
            this.getSizeInfoButton.TabIndex = 40;
            this.toolTip1.SetToolTip(this.getSizeInfoButton, "Получить информацию от серверов");
            this.getSizeInfoButton.UseVisualStyleBackColor = true;
            this.getSizeInfoButton.Click += new System.EventHandler(this.getSizeInfoButton_Click);
            // 
            // saveListButton
            // 
            this.saveListButton.Image = global::SssUser.Properties.Resources.server_icon_save;
            this.saveListButton.Location = new System.Drawing.Point(89, 4);
            this.saveListButton.Name = "saveListButton";
            this.saveListButton.Size = new System.Drawing.Size(40, 40);
            this.saveListButton.TabIndex = 37;
            this.toolTip1.SetToolTip(this.saveListButton, "Сохранить список серверов");
            this.saveListButton.UseVisualStyleBackColor = true;
            this.saveListButton.Click += new System.EventHandler(this.saveListButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::SssUser.Properties.Resources.desable_server_icon;
            this.deleteButton.Location = new System.Drawing.Point(47, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(40, 40);
            this.deleteButton.TabIndex = 36;
            this.toolTip1.SetToolTip(this.deleteButton, "Удалить сервер");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::SssUser.Properties.Resources.add_server_icon__1_;
            this.addButton.Location = new System.Drawing.Point(5, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 40);
            this.addButton.TabIndex = 35;
            this.toolTip1.SetToolTip(this.addButton, "Добавть сервер");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // NeedCopy
            // 
            this.NeedCopy.DataPropertyName = "NeedSize";
            this.NeedCopy.HeaderText = "Инфо";
            this.NeedCopy.Name = "NeedCopy";
            this.NeedCopy.Width = 50;
            // 
            // IpAdress
            // 
            this.IpAdress.DataPropertyName = "IpAdress";
            this.IpAdress.HeaderText = "Ip Адрес";
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.Width = 80;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Описание";
            this.Description.Name = "Description";
            this.Description.Width = 120;
            // 
            // status
            // 
            this.status.DataPropertyName = "StatusInfo";
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 300;
            // 
            // SizeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 632);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.getSizeInfoButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.saveListButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.serverInfoDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SizeInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет объёма обмена информации АСУСТ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SizeInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.SizeInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveListButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView serverInfoDataGridView;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button getSizeInfoButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NeedCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}

