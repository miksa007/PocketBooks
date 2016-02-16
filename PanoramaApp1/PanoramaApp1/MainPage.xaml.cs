using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PanoramaApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Link to class
        BookShelf bookshelf;
        // Constructor
        public MainPage()
        {
            //calling constructor
            
            

            //link for data to GUI
            lataa();
            if (bookshelf == null)
            {
                System.Diagnostics.Debug.WriteLine("Nulli oli");
                bookshelf = new BookShelf();
            }
            InitializeComponent();
            listBox1.DataContext = bookshelf;
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            tallenna();
        }
        public void tallenna()
        {
            SerializeHelper.SaveData<BookShelf>("kaikkidata", bookshelf);
        }
        public void lataa()
        {
            try
            {
                bookshelf = (BookShelf)SerializeHelper.ReadData<BookShelf>("kaikkidata");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Not usable data");
                //throw;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            string number = numberField.Text;
            string name = nameField.Text;
            System.Diagnostics.Debug.WriteLine("Tietooo:"+number + " " + name);
            bookshelf.addBook(number, name);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Virhe: bookshelf");

            }

        }
    }
}