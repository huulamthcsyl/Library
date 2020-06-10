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
    public partial class fAddUser : Form
    {
        public fAddUser()
        {
            InitializeComponent();
        }

        void Clear()
        {
            txbAddress.Clear();
            txbName.Clear();
            txbPhoneNumber.Clear();
            nmAge.ResetText();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txbName.Text;
            int age = (int)nmAge.Value;
            string phoneNumber = txbPhoneNumber.Text;
            string address = txbAddress.Text;

            if (MessageBox.Show("Do you want to add this user?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                UserDAO.Instance.AddUser(name, age, phoneNumber, address);
                MessageBox.Show("Add user successful!");
                Clear();
            }
        }
    }
}
