using QuanLiQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return UserDAO.instance; }
            private set { UserDAO.instance = value; }
        }

        UserDAO() { }

        public DataTable GetListUser()
        {
            string query = "SELECT Name AS [Name], Age AS [Age], PhoneNumber AS [Phone number], Address AS [Address] FROM dbo.UserAcc";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public DataTable GetListUserByName(string name)
        {
            string query = "EXEC USP_SearchUser @name";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { name });
        }

        public void AddUser(string name, int age, string phoneNumber, string address)
        {
            string query = "EXEC USP_AddUser @name , @age , @phoneNumber , @address";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { name, age, phoneNumber, address });
        }
    }
}
