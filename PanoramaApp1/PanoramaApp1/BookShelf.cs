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
        }
    }
}
