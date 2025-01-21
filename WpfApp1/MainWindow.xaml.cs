﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //public partial class MainWindow : Window
    //{

    //    public MainWindow()
    //    {      

    //        InitializeComponent();
    //        DataContext = new MainViewModel(); 

    //    }

    //}
    public partial class MainWindow : Window
    {
        private readonly MainVM _viewModel;

        public MainWindow(MainVM viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            //Console.WriteLine($"DataContext set to: {viewModel}");
        }
    }

}