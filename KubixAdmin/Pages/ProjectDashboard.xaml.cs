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
    /// Interaction logic for ProjectDashboard.xaml
    /// </summary>
    public partial class ProjectDashboard : Page
    {
        private KubixAdmin.Customer _customer;
        private KubixAdmin.Project _project;
        KubixDBEntities context;

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

            context = new KubixDBEntities();
            context.Materials.Load();
            context.Services.Load();
            context.Projects.Load();
            context.ProjectServices.Load();
            context.ServiceMaterials.Load();


            var listProjectServices = (from p in context.Projects
                                                        join ps in context.ProjectServices on p.ProjectID equals ps.ProjectID
                                                        join s in context.Services on ps.ServiceID equals s.ServiceID
                                                        join u in context.Units on s.UnitID equals u.UnitUD
                                                        where p.ProjectID == project.ProjectID
                                                        select new { p.ProjectID, s.ServiceID, s.Name, s.WorkPrice, s.WorkTime,s.UnitID,s.IsIndependetPrice, u.UnitName,u.UnitDescription, ps.UnitsPerService}).ToList();

            DynamicGrid.RowDefinitions.Clear();
            DynamicGrid.ColumnDefinitions.Clear();

            ColumnDefinition serviceDesc = new ColumnDefinition();
            ColumnDefinition serviceUnit = new ColumnDefinition();
            ColumnDefinition servicePricePerUnit = new ColumnDefinition();
            ColumnDefinition materialAmount = new ColumnDefinition();
            ColumnDefinition totalPrice = new ColumnDefinition();

            DynamicGrid.ColumnDefinitions.Add(serviceDesc);
            DynamicGrid.ColumnDefinitions.Add(serviceUnit);
            DynamicGrid.ColumnDefinitions.Add(servicePricePerUnit);
            DynamicGrid.ColumnDefinitions.Add(materialAmount);
            DynamicGrid.ColumnDefinitions.Add(totalPrice);

            int rowNumber = 0;
            foreach(var projectService in listProjectServices)
            {
                rowNumber++;
               
                var listServiceMaterials = (from s in context.Services
                                            join sm in context.ServiceMaterials on s.ServiceID equals sm.ServiceID
                                            where s.ServiceID == projectService.ServiceID
                                            select sm).ToList();

                rowNumber = rowNumber + listServiceMaterials.Count();




            }

            int row = 0;
            while(row < rowNumber)
            {
                DynamicGrid.RowDefinitions.Add(new RowDefinition());
                row++;
            }

            int rowIndex = 0;
           
            foreach(var service in listProjectServices)
            {


                TextBlock name = new TextBlock();
                name.Text = service.Name;
                name.FontSize = 18;
                name.FontWeight = FontWeights.Bold;
                Grid.SetRow(name, rowIndex);
                Grid.SetColumn(name, 0);

                TextBlock unit = new TextBlock();
                unit.Text = service.UnitName;
                unit.FontSize = 18;
                unit.FontWeight = FontWeights.Bold;
                Grid.SetRow(unit, rowIndex);
                Grid.SetColumn(unit, 1);

                TextBlock price = new TextBlock();
                price.Text = service.WorkPrice.ToString();
                price.FontSize = 18;
                price.FontWeight = FontWeights.Bold;
                Grid.SetRow(price, rowIndex);
                Grid.SetColumn(price, 2);

                TextBlock amount = new TextBlock();
                amount.Text = service.UnitsPerService.ToString();
                amount.FontSize = 18;
                amount.FontWeight = FontWeights.Bold;
                Grid.SetRow(amount, rowIndex);
                Grid.SetColumn(amount, 3);

                TextBlock priceTotal = new TextBlock();
                priceTotal.Text = "0";
                priceTotal.FontSize = 18;
                priceTotal.FontWeight = FontWeights.Bold;
                Grid.SetRow(priceTotal, rowIndex);
                Grid.SetColumn(priceTotal, 4);

                DynamicGrid.Children.Add(name);
                DynamicGrid.Children.Add(unit);
                DynamicGrid.Children.Add(price);
                DynamicGrid.Children.Add(amount);
                DynamicGrid.Children.Add(priceTotal);

                var listServiceMaterials = (from s in context.Services
                                            join sm in context.ServiceMaterials on s.ServiceID equals sm.ServiceID
                                            join m in context.Materials on sm.MaterialID equals m.MaterialID
                                            where s.ServiceID == service.ServiceID
                                            select new { s.ServiceID, m.MaterialID, m.Name, m.UnitMeasurement, m.UnitPrice, m.Description, m.Type, sm.MaterialPerUnit }).ToList();

                rowIndex++;
                foreach (var material in listServiceMaterials)
                {
                    name = new TextBlock();
                    name.Text = material.Name;
                    name.FontSize = 14;
                    name.FontWeight = FontWeights.Medium;
                    Grid.SetRow(name, rowIndex);
                    Grid.SetColumn(name, 0);

                    unit = new TextBlock();
                    unit.Text = material.UnitMeasurement;
                    name.FontSize = 14;
                    name.FontWeight = FontWeights.Medium;
                    Grid.SetRow(unit, rowIndex);
                    Grid.SetColumn(unit, 1);

                    price = new TextBlock();
                    price.Text = material.UnitPrice.ToString();
                    name.FontSize = 14;
                    name.FontWeight = FontWeights.Medium;
                    Grid.SetRow(price, rowIndex);
                    Grid.SetColumn(price, 2);

                    amount = new TextBlock();
                    amount.Text = material.MaterialPerUnit.ToString();
                    name.FontSize = 14;
                    name.FontWeight = FontWeights.Medium;
                    Grid.SetRow(amount, rowIndex);
                    Grid.SetColumn(amount, 3);

                    priceTotal = new TextBlock();
                    priceTotal.Text = "0";
                    name.FontSize = 14;
                    name.FontWeight = FontWeights.Medium;
                    Grid.SetRow(priceTotal, rowIndex);
                    Grid.SetColumn(priceTotal, 4);

                    DynamicGrid.Children.Add(name);
                    DynamicGrid.Children.Add(unit);
                    DynamicGrid.Children.Add(price);
                    DynamicGrid.Children.Add(amount);
                    DynamicGrid.Children.Add(priceTotal);

                    rowIndex++;

                }


            }

        }

        private void btnEditProject_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Project(_customer,_project);
        }
    }
}
