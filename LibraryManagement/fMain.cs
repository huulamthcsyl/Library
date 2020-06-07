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
            string title = txbSearch.Text;
            dtgvBook.DataSource = BookDAO.Instance.GetListBookByTitle(title);
        }

        #endregion

        #region EVENTS

        private void fMain_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(pnlMain, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadListBookByTitle();
        }

        #endregion
    }
}
