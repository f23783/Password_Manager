using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager_Frontend
{
    public partial class AddEntryForm : Form
    {
        public string EntryTitle { get; private set; }
        public string EntryUsername { get; private set; }
        public string EntryPassword { get; private set; }

        public AddEntryForm()
        {
            InitializeComponent();
        }

    private string GeneratePassword(int length, bool lower, bool upper, bool numbers, bool symbols)
    {
        string lowers = "abcdefghijklmnopqrstuvwxyz";
        string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string nums = "0123456789";
        string syms = "!@#$%&*()-_=+[]{};:<>?";

        StringBuilder pool = new StringBuilder();
        if (lower) pool.Append(lowers);
        if (upper) pool.Append(uppers);
        if (numbers) pool.Append(nums);
        if (symbols) pool.Append(syms);

        if (pool.Length == 0) return "";

        var result = new StringBuilder();
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] random = new byte[1];
            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(random);
                int idx = random[0] % pool.Length;
                result.Append(pool[idx]);
            }
        }

        return result.ToString();
    }

    private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddEntryForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntryTitle = txtTitle.Text;
            EntryUsername = txtUsername.Text;
            EntryPassword = txtPassword.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpGenerator_Enter(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text += GeneratePassword(Convert.ToInt32(numLength.Value), chkLower.Checked,chkUpper.Checked,chkNumbers.Checked,chkSymbols.Checked);
        }

        private void numLength_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkLower_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
