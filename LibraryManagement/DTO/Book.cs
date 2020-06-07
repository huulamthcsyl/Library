using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DTO
{
    public class Book
    {
        private string title;
        private string author;
        private DateTime? releaseDate;
        private string category;
        private string pubilsher;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public DateTime? ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string Category { get => category; set => category = value; }
        public string Pubilsher { get => pubilsher; set => pubilsher = value; }

        public Book(string title, string author, string category, DateTime? releaseDate, string pubilsher)
        {
            this.title = title;
            this.Author = author;
            this.Category = category;
            this.ReleaseDate = releaseDate;
            this.Pubilsher = pubilsher;
        }

        public Book(DataRow row)
        {
            this.Title = row["name"].ToString();
            this.Author = row["author"].ToString();
            this.Category = row["category"].ToString();
            var releaseDateTemp = row["releaseDate"];
            if(releaseDateTemp != null)
            {
                releaseDate = (DateTime?)releaseDateTemp;
            }
            this.Pubilsher = row["publisher"].ToString();
        }
    }
}
