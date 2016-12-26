using System;
using System.Windows.Forms;
using ClientManager;


namespace SssUser
{
    public partial class SizeInfoForm : Form
    {
        public SizeInfoForm()
        {
            InitializeComponent();
        }
        

        private void addButton_Click(object sender, EventArgs e)
        {
            _serverInfoManager.AddServer();
        }

        private ServerInfoManager _serverInfoManager;

        private void AppendLogToListBox(string info)
        {
            logTextBox.AppendText(info+Environment.NewLine+Environment.NewLine);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(@"Удалить", @"Подтвердить",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if ((result == DialogResult.Yes) && (serverInfoDataGridView.CurrentRow != null))
                {
                    _serverInfoManager.DeleteServer(serverInfoDataGridView.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка " + ex.Message + ex.InnerException.Message);
            }
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            _serverInfoManager.SaveServerList();
        }

        private void getSizeInfoButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            getSizeInfoButton.Enabled = false;
            try
            {
                _serverInfoManager.StartGetSizeInfo(monthComboBox.SelectedIndex+1);
            }
            finally
            {
                Cursor = Cursors.Default;
                getSizeInfoButton.Enabled = true;
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
           if (logTextBox.Text != string.Empty) Clipboard.SetText(logTextBox.Text);
        }

        private void SizeInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_serverInfoManager.IsServerListChanged) return;

            var result = MessageBox.Show(@"Список серверов был изменен, сохранить изменения?", @"Подтвердить",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _serverInfoManager.SaveServerList();
            }

        }

        private void SizeInfoForm_Load(object sender, EventArgs e)
        {
            _serverInfoManager = new ServerInfoManager();
            _serverInfoManager.UpdateLog += AppendLogToListBox;
            serverInfoDataGridView.DataSource = _serverInfoManager.GetServerList();

            var nowdt = DateTime.Now;
            monthComboBox.SelectedIndex = nowdt.Month - 1;
        }
  
        
    }
}
