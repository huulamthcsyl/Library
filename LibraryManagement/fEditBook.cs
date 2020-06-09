using LibraryManagement.DAO;
using LibraryManagement.DTO;
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
    public partial class fEditBook : Form
    {

        Book book;
        int idBook;

        public fEditBook(Book bk)
        {
            InitializeComponent();

            book = bk;
            idBook = BookDAO.Instance.GetIDBook(book.Title, book.Author, book.ReleaseDate, book.Pubilsher);

            LoadForm();
        }

        void LoadForm()
        {
            txbTitle.Text = book.Title;
            txbAuthor.Text = book.Author;
            txbCategory.Text = book.Category;
            txbPublisher.Text = book.Pubilsher;
            dtpkReleaseDate.Value = book.ReleaseDate;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string newTitle = txbTitle.Text;
            string newAuthor = txbAuthor.Text;
            string newCategory = txbCategory.Text;
            string newPubilsher = txbPublisher.Text;
            DateTime newReleaseDate = dtpkReleaseDate.Value;

            if(MessageBox.Show("Do you want to edit this book?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BookDAO.Instance.EditBook(newTitle, newAuthor, newCategory, newReleaseDate, newPubilsher, idBook);
                MessageBox.Show("Edit book successful!","Information");
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this book?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BookDAO.Instance.DeleteBook(idBook);
                MessageBox.Show("Delete book successful!", "Information");
                this.Close();
            }
        }
    }
}
