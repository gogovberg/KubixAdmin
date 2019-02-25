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

namespace KubixAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {
        public Administration()
        {
            InitializeComponent();
        }

        private void BtnMaterials_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Materials();
        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Services();
        }

        private void BtnOffers_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
