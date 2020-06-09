using QuanLiQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAO
{
    public class BookDAO
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
            private set { BookDAO.instance = value; }
        }

        BookDAO() { }

        public DataTable GetListBook()
        {
            string query = "SELECT Title, Author, Category, ReleaseDate AS [Release Date], Publisher FROM dbo.Book";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data;
        }

        public DataTable GetListBookByTitle(string title)
        {
            string query = "EXEC USP_SearchBook @title";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] {title});

            return data;
        }

        public void AddBook(string title, string author, string category, DateTime releaseDate, string publisher)
        {
            string query = "EXEC USP_AddBook @title , @author , @category , @releaseDate , @publisher";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { title, author, category, releaseDate, publisher });
        }

        public int GetIDBook(string title, string author, DateTime releaseDate, string publisher)
        {
            string query = "EXEC USP_GetIDBook @title , @author , @releaseDate , @publisher";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { title, author, releaseDate, publisher });

            return (int)data.Rows[0][0];
        }

        public void EditBook(string title, string author, string category, DateTime releaseDate, string publisher, int id)
        {
            string query = "EXEC USP_EditBook @title , @author , @category , @releaseDate , @pubilsher , @id";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { title, author, category, releaseDate, publisher, id });
        }

        public void DeleteBook(int id)
        {
            string query = "DELETE dbo.Book WHERE ID = " + id;
            DataProvider.Instance.ExcuteNonQuery(query);
        }
    }
}
