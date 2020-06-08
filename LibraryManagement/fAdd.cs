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
    public partial class fAdd : Form
    {
        public fAdd()
        {
            InitializeComponent();
        }

        void Clear()
        {
            txbAuthor.Clear();
            txbCategory.Clear();
            txbPublisher.Clear();
            txbTitle.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txbTitle.Text;
            string author = txbAuthor.Text;
            string category = txbCategory.Text;
            string publisher = txbPublisher.Text;
            DateTime releaseDate = dtpkReleaseDate.Value;

            if (title == "" || author == "" || category == "" || publisher == "")
            {
                MessageBox.Show("Please fill all informations");
            }
            else
            {
                BookDAO.Instance.AddBook(title, author, category, releaseDate, publisher);
                Clear();              
            }
        }
    }
}
