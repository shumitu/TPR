using System;

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
            if (year < 0)
            {
                throw new Exception("Cannot create book with negative year");
            }

            if (bookId < 0)
            {
                throw new Exception("Cannot create book with negative id");
            }

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


        public override bool Equals(object obj)
        {
            Catalog other = (Catalog)obj;
            return this.bookId == other.bookId && this.Author == other.author && this.Title == other.title && this.Year == other.year;
        }
    }
}