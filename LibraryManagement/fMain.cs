using LibraryManagement.DAO;
using LibraryManagement.DTO;
using Microsoft.VisualBasic.ApplicationServices;
using QuanLiQuanCafe.DAO;
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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();

            LoadListBook();
        }

        #region METHODS

        void LoadListBook()
        {
            dtgvBook.DataSource = BookDAO.Instance.GetListBook();
        }

        void LoadListBookByTitle()
        {
            string title = txbSearchBook.Text;
            dtgvBook.DataSource = BookDAO.Instance.GetListBookByTitle(title);
        }

        void LoadAddBookForm()
        {
            fAddBook fAdd = new fAddBook();
            fAdd.ShowDialog();
            LoadListBook();
        }

        void LoadEditBookForm()
        {
            var row = (dtgvBook.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            Book book = new Book(row);

            fEditBook fEditBook = new fEditBook(book);
            fEditBook.ShowDialog();
            LoadListBook();
        }

        void LoadListUser()
        {
            dtgvUser.DataSource = UserDAO.Instance.GetListUser();
        }

        void LoadListUserByName()
        {
            string userName = txbSearchUser.Text;
            dtgvUser.DataSource = UserDAO.Instance.GetListUserByName(userName);
        }

        void LoadAddUserForm()
        {
            fAddUser fAddUser = new fAddUser();
            fAddUser.ShowDialog();
            LoadListUser();
        }

        #endregion

        #region EVENTS

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            LoadListBookByTitle();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            LoadAddBookForm();
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            LoadEditBookForm();
        }

        private void btnShowSearch_Click(object sender, EventArgs e)
        {
            pnlSearch.BringToFront();
            LoadListBook();
        }

        private void btnShowUser_Click(object sender, EventArgs e)
        {
            pnlUser.BringToFront();
            LoadListUser();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadListUserByName();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            LoadAddUserForm();
        }

        #endregion
    }
}
