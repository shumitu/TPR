using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task_1.Part_1
{
    [Serializable]
    public class Catalog : ICloneable, SerialInterface
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


        public Catalog() { }


        public Catalog(Catalog cat)
        {
            BookId = cat.bookId;
            Author = cat.author;
            Title = cat.title;
            Year = cat.year;
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


        public override string ToString()
        {
            return "Book id: " + BookId + " title: " + Title + ", author: " + Author + ", year: " + Year;
        }



        public override bool Equals(object obj)
        {
            Catalog other = (Catalog)obj;
            return bookId == other.bookId && Author == other.author && Title == other.title && Year == other.year;
        }


        public string Serialize(ObjectIDGenerator generator)
        {
            string data = "";
            data += this.GetType().FullName + "-";
            data += generator.GetId(this, out bool firstTime).ToString() + "-";
            data += this.BookId.ToString() + "-";
            data += this.Author + "-";
            data += this.Title + "-";
            data += this.Year + "-";
            return data;
        }


        public void Deserialize(string[] data, Dictionary<long, Object> deserialized)
        {
            this.BookId = int.Parse(data[2]);
            this.Author = data[3];
            this.Title = data[4];
            this.Year = int.Parse(data[5]);
        }


        public object Clone()
        {
            return new Catalog(this);
        }
    }
}