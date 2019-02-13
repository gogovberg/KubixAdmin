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
    /// Interaction logic for SubHeader.xaml
    /// </summary>
    public partial class SubHeader : UserControl
    {
        public SubHeader()
        {
            InitializeComponent();
        }
        public string ProjectName
        {
            get { return lblProjectName.Content.ToString(); }
            set { lblProjectName.Content = value; }
        }
        public string ProjectLocation
        {
            get { return lblProjectLocation.Content.ToString(); }
            set { lblProjectLocation.Content = value; }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.PreviousPageID = GlobalSettings.CurrentPageID;
            Application.Current.MainWindow.Content = new Projects(GlobalSettings.CurrentCustomer);
        }

        private void btnProjects_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.PreviousPageID = GlobalSettings.CurrentPageID;
            Application.Current.MainWindow.Content = new Projects(GlobalSettings.CurrentCustomer);
        }
    }
}
