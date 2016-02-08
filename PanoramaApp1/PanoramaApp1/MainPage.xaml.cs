﻿using System;
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
        private BookShelf bookshelf;
        // Constructor
        public MainPage()
        {
            //calling constructor
            bookshelf = new BookShelf();
            InitializeComponent();

            //link for data to GUI
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
    }
}