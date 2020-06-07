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
            string query = "SELECT Title AS [Tên sách], Author AS [Tác giả], Category AS [Thể loại], ReleaseDate AS [Ngày phát hành], Publisher AS [Nhà xuất bản] FROM dbo.Book";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data;
        }

        public DataTable GetListBookByTitle(string title)
        {
            string query = String.Format("SELECT Title AS [Tên sách], Author AS [Tác giả], Category AS [Thể loại], ReleaseDate AS [Ngày phát hành], Publisher AS [Nhà xuất bản] FROM dbo.Book WHERE dbo.GetUnsignString(Title) LIKE N'%' + dbo.GetUnsignString(N'{0}') + N'%'", title);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data;
        }
    }
}
