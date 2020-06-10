
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
    public partial class fAddBook : Form
    {
        public fAddBook()
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
                MessageBox.Show("Please fill all informations", "Warning");
            }
            else
            {
                if (MessageBox.Show("Do you want to add this book to library?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BookDAO.Instance.AddBook(title, author, category, releaseDate, publisher);
                    MessageBox.Show("Add book successful!", "Information");
                    Clear();
                }
            }
        }
    }
}