/**
 * Group 07
 * Assignment 08
 * Angileena Jacob
 * Vimal Anusha Sharon Jacob
 * Ismail Mohammed Hanif Shaikh
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JaggedArray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScoresVM svm;

        public MainWindow()
        {
            InitializeComponent();
            svm = new ScoresVM();
            DataContext = svm;
        }
    }
}
