using LibraryManagement.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;
            if (AccountDAO.Instance.Login(username, password)) {
                fMain f = new fMain();
                this.Hide();
                f.ShowDialog();
                txbPassword.Clear();
                txbUsername.Clear();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Warning");
            }
        }
    }
}
