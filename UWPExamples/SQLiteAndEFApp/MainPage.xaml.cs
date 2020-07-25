﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteAndEFApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.FirstOrDefault(x => x.Url == url.Text);
                if (blog != null)
                    db.Remove(blog);
                blogs.ItemsSource = db.Blogs.ToList();

            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Url = url.Text };
                db.Blogs.Add(blog);
                db.SaveChanges();
                blogs.ItemsSource = db.Blogs.ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                blogs.ItemsSource = db.Blogs.ToList();
            }
        }
    }
}
