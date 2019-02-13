using KubixAdmin.CustomControls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for Projects.xaml
    /// </summary>
    public partial class Projects : Page
    {
        private int _customerID;
        private KubixAdmin.Customer _customer;
        KubixDBEntities context;
        Style enable;
        Style disable;
        public Projects(KubixAdmin.Customer cc)
        { 
          
            InitializeComponent();
            _customerID = cc.CustomerID;
            _customer = cc;
            context = new KubixDBEntities();
            context.Projects.Load();
            BitmapImage imgsrc = new BitmapImage(new Uri("/Images/icon_event_primary.png", UriKind.Relative));
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");
           
            headerControl.CurrentCustomer = cc.Name + " " + cc.Surname;

            tblWelcomeUser.Text = "Add new project or work on existing projects for customer " + headerControl.CurrentCustomer;

            foreach (KubixAdmin.Project proj in context.Projects.Local)
            {
                if(proj.CustomerID == _customer.CustomerID)
                {
                    ProjectControl pj = new ProjectControl();
                    pj.ProjectID = proj.ProjectID;
                    pj.ProjectName = proj.Name;
                    pj.ProjectExpirationDate = proj.ExpirationDate.Value.ToShortDateString();
                    pj.ProjectAddress = proj.Address;
                    pj.ProjectCreatedLabel = "EXPIRES ON";
                    pj.ProjectExpectedPrice = proj.ExpectedPrice.ToString();
                    pj.ProjectLogoSource = imgsrc;
                    pj.Control_Click += new EventHandler(Control_click);
                    rpsGridProjects.Children.Add(pj);
                }
            }
        }

        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Project(_customer, null);
        }
        protected void Control_click(object sender, EventArgs e)
        {
            ProjectControl pj = (ProjectControl)sender;
            KubixAdmin.Project tempProject = null;

            foreach (KubixAdmin.Project project in context.Projects.Local)
            {
                if (project.CustomerID == _customer.CustomerID && project.ProjectID == pj.ProjectID)
                {
                    tempProject = project;
                }
            }
            if (tempProject != null)
            {
                Application.Current.MainWindow.Content = new ProjectDashboard(_customer, tempProject);
            }

        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Customer(_customer);
        }

    }
}
