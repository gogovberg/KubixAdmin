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
using System.Text.RegularExpressions;
using System.Data.Entity;
using KubixAdmin.CustomControls;

namespace KubixAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Page
    {
        private KubixAdmin.Customer _customer;
        private KubixAdmin.Project _project;
        KubixDBEntities context = new KubixDBEntities();
        Style enable;
        Style disable;
        public Project(KubixAdmin.Customer customer, KubixAdmin.Project project)
        {
            InitializeComponent();
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");
            headerControl.CurrentCustomer = customer.Name + " " + customer.Surname;
            _customer = customer;
            _project = project;
            btnDeleteProject.Style = disable;
            int projectId = -1;
            if (project!=null)
            {
                projectId = project.ProjectID;
                tbxName.Text = project.Name;
                tbxAddress.Text = project.Address;
                tbxExpectedPrice.Text = project.ExpectedPrice.ToString();
                dtpExpirationDate.SelectedDate = project.ExpirationDate;
                tbxActualPrice.Text = project.ActualPrice.ToString();
                btnDeleteProject.Style = enable;
            }

            context = new KubixDBEntities();
            context.Projects.Load();
            context.ProjectServices.Load();
            context.Services.Load();
            List<ProjectService> listProjectServices = (from p in context.Projects
                                                          join ps in context.ProjectServices on p.ProjectID equals ps.ProjectID
                                                          where p.ProjectID == projectId
                                                        select ps).ToList();

            foreach (var serv in context.Services.Local)
            {
                CheckboxInputControl smc = new CheckboxInputControl();
                foreach (ProjectService ps in listProjectServices)
                {
                    if (serv.ServiceID == ps.ServiceID)
                    {
                        smc.cbIsMaterialChecked.IsChecked = true;
                        break;
                    }
                }

                smc.ChildID = serv.ServiceID;
                smc.ParentID = projectId;
                smc.cbIsMaterialChecked.Content = serv.Name;
                smc.tblMaterialUnit.Text = "m2";
                icServices.Children.Add(smc);
            }
        }
       
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            KubixAdmin.Project newProject;
            if (_project!=null)
            {
                newProject = context.Projects.Find(_customer.CustomerID, _project.ProjectID);
            }
            else
            {
                newProject = new KubixAdmin.Project();
                newProject.CustomerID = _customer.CustomerID;
                context.Projects.Add(newProject);
            }

            newProject.Name = tbxName.Text;
            newProject.Address = tbxAddress.Text;
            newProject.IsFinished = false;
            newProject.ExpirationDate = dtpExpirationDate.SelectedDate.Value.Date;
            newProject.ExpectedPrice = decimal.Parse(tbxExpectedPrice.Text);
            newProject.ActualPrice = decimal.Parse(tbxActualPrice.Text);

            context.SaveChanges();




            ProjectService projectSerivce;
            foreach(CheckboxInputControl ps in icServices.Children)
            {
                projectSerivce = context.ProjectServices.Find(ps.Parent, ps.ChildID);
                if(ps.cbIsMaterialChecked.IsChecked.Value)
                {
                    if(projectSerivce==null)
                    {
                        projectSerivce = new ProjectService();
                        projectSerivce.ServiceID = ps.ChildID;
                        projectSerivce.ProjectID = ps.ParentID;
                        context.ProjectServices.Add(projectSerivce);
                    }
                    projectSerivce.UnitsPerService = int.Parse(ps.tbMaterialPerUnit.Text);
                }
            }
            context.SaveChanges();


            Application.Current.MainWindow.Content = new ProjectDashboard(_customer, newProject);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Projects(_customer);
        }

        private void btnDeleteProject_Click(object sender, RoutedEventArgs e)
        {
            KubixAdmin.Customer newCustomer = context.Customers.Find(_customer.CustomerID);
            if (newCustomer != null)
            {
                context.Customers.Remove(newCustomer);
                context.SaveChanges();
            }
        }
    }
}
