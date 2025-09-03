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
    public partial class Form1 : Form
    {
        private string username = "admin";
        private string password = "123";
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            masterkey_text.PasswordChar = '*';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            String name = name_text.Text;
            String masterkey = masterkey_text.Text;
            MessageBox.Show("Welcome " + name + "!");

            if (name == username && masterkey == password)
            {
                Form2 mainForm = new Form2();
                mainForm.Show();
                this.Hide();
            }

        }
    }
}
