using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.IO;

namespace PanoramaApp1
{
    class BookShelf : ObservableCollection<Book>
    {
        IsolatedStorageFile tiedosto;
        // constructor
        public BookShelf()
        {
            tiedosto = IsolatedStorageFile.GetUserStoreForApplication();
            LataaTaskukirjat();

            //Test data will be in finnish
            //Add(new Book { BookNumber = "104", BookName = "Aku saa aikaan" });
            //Add(new Book { BookNumber = "13", BookName = "Ritari Peloton" });
            //testing method
            //addBook("412", "Akun Juhlavuosi");
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
        public void saveBooks(ObservableCollection<Book> kirjat)
        {
            IsolatedStorageFileStream kirjatiedosto;
            //onko olemassa
            if (!tiedosto.FileExists("akuankat.txt"))
            {
                kirjatiedosto = tiedosto.OpenFile("akuankat.txt", FileMode.Create, FileAccess.Write);
            }
            else
            {
                kirjatiedosto = tiedosto.OpenFile("akuankat.txt", FileMode.Open, FileAccess.Write);
            }
            using (StreamWriter writer = new StreamWriter(kirjatiedosto))
            {
                for (int i = 0; i < this.Count; i++)
                {
                    writer.WriteLine(this[i].BookNumber + ";" + this[i].BookName);
                }
                writer.Close();
            }
        }
        public void LataaTaskukirjat()
        {
            try
            {
                IsolatedStorageFileStream kirjatiedosto = tiedosto.OpenFile("akuankat.txt", FileMode.OpenOrCreate, FileAccess.Read);
                string rivit;
                string[] nroJaNimi = new string[2];
                this.Clear();
                using (StreamReader reader = new StreamReader(kirjatiedosto))
                {
                    while ((rivit = reader.ReadLine()) != null)
                    {
                        nroJaNimi = rivit.Split(';');
                        if (nroJaNimi.Length > 0)
                        {
                            try
                            {
                                Add(new Book { BookNumber = nroJaNimi[0], BookName = nroJaNimi[1] });
                            }
                            catch (IndexOutOfRangeException er)
                            {
                                System.Diagnostics.Debug.WriteLine("Virhe: sisalto__" + nroJaNimi[0] + "__");
                                tiedosto.DeleteFile("akuankat.txt");
                            }
                        }
                        else
                            System.Diagnostics.Debug.WriteLine("nroJaNimi - Pituus heittää");
                    }
                }
            }
            catch (IsolatedStorageException e)
            {
                System.Diagnostics.Debug.WriteLine("LataaTaskukirjat() -heitti virheen");
                e.ToString();
            }
        }    

    }
}
