using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.Part_1
{
    public class Catalog
    {
        private int bookId;
        private string author;
        private string title;
        private int year;


        public Catalog(int bookId, string author, string title, int year)
        {
            this.bookId = bookId;
            this.author = author;
            this.title = title;
            this.year = year;
        }


        public int BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
            }
        }


        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }


        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }


        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public string All
        {
            get
            {
                return bookId + " " + title + " " + author + " " + year;
            }
        }
    }
}