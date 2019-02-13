using KubixAdmin.Pages;
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

namespace KubixAdmin.CustomControls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }
        public string CurrentCustomer
        {
            get { return LblCurrentCustomer.Content.ToString(); }
            set { LblCurrentCustomer.Content = value; }
        }
        
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //Helpers.SaveUserSettings(GlobalSettings.ApplicationSettings);
            Application.Current.MainWindow.Content = new Login();

        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            //Helpers.SaveUserSettings(GlobalSettings.ApplicationSettings);
            GlobalSettings.PreviousPageID = GlobalSettings.CurrentPageID;
            Application.Current.MainWindow.Content = new Customers();
        }

        private void ImgLogoMpWhite_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.PreviousPageID = GlobalSettings.CurrentPageID;
            Application.Current.MainWindow.Content = new Administration();
        }
    }
}
