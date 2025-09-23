using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager_Frontend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddEntryToList(string title, string username, string password)
        {
            ListViewItem item = new ListViewItem(title);
            item.SubItems.Add(username);
            item.SubItems.Add(password);

            //mask the password with asterisks
            item.SubItems.Add(new string('*', password.Length));
            item.Tag = password;

            listView1.Items.Add(item);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblAccount_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void chkShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                string realPassword = item.Tag.ToString();

                if (chkShowPasswords.Checked)
                    item.SubItems[2].Text = realPassword;
                else
                    item.SubItems[2].Text = new string('*', realPassword.Length);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                string password = item.Tag.ToString(); // Real password stored in Tag
                Clipboard.SetText(password);
                MessageBox.Show("Password copied to clipboard!");
            }
            else
            {
                MessageBox.Show("Please select an entry first.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void chkLower_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void chkUpper_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chkNumbers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGenerated_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            AddEntryForm addForm = new AddEntryForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string title = addForm.EntryTitle;
                string username = addForm.EntryUsername;
                string password = addForm.EntryPassword;

                AddEntryToList(title, username, password);
            }
        }
    }
}
