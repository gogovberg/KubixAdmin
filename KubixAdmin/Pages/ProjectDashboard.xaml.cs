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
    /// Interaction logic for ProjectDashboard.xaml
    /// </summary>
    public partial class ProjectDashboard : Page
    {
        private KubixAdmin.Customer _customer;
        private KubixAdmin.Project _project;
        public ProjectDashboard(KubixAdmin.Customer customer, KubixAdmin.Project project)
        {
            InitializeComponent();
            _customer = customer;
            _project = project;
            headerControl.CurrentCustomer = customer.Name + " " + customer.Surname;
            subheaderControl.ProjectName = project.Name;
            subheaderControl.ProjectLocation = project.Address;

            tblWelcomeUser.Text = "Please work on project " + project.Name + " for customer " + headerControl.CurrentCustomer;

            GlobalSettings.CurrentCustomer = customer;
            GlobalSettings.CurrentProject = project;
        }

        private void btnEditProject_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Project(_customer,_project);
        }
    }
}
