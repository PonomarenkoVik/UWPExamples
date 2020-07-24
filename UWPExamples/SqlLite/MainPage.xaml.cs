using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SqlLite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private string _path;
        private SQLiteConnection _connection;
        public MainPage()
        {
            this.InitializeComponent();
            _path = Path.Combine(ApplicationData.Current.LocalCacheFolder.Path, "db.sqlite");
            _connection = new SQLiteConnection(new SQLitePlatformWinRT(), _path);
            _connection.CreateTable<Customer>();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _ = _connection.Insert(new Customer()
            {
                Name = nameTextBox.Text,
                Age = ageTextBox.Text
            });
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            var customers = _connection.Table<Customer>().ToList();

            outPutGrid.ItemsSource = customers;
        }
    }
}
