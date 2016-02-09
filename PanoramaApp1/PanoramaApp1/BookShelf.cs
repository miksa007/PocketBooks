using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PanoramaApp1
{
    class BookShelf : ObservableCollection<Book>
    {
        // constructor
        public BookShelf()
        {
            //Test data will be in finnish
            Add(new Book { BookNumber = "104", BookName = "Aku saa aikaan" });
            Add(new Book { BookNumber = "13", BookName = "Ritari Peloton" });
            //testing method
            addBook("412", "Akun Juhlavuosi");
        }
        /**
         * addBook() -method for adding new book to collection
         * 
         * @param   bookNumber
         * @param   bookName
         **/
        public void addBook(string bookNumber, string bookName)
        {
            Add(new Book { BookNumber = bookNumber, BookName = bookName });
        }
    }
}
