using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace Emp_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetEmployee_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}