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
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        KubixDBEntities context = new KubixDBEntities();
        private KubixAdmin.Service _service;
        Style enable;
        Style disable;
        public Service(KubixAdmin.Service service)
        {
            InitializeComponent();
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");
            _service = service;
            int serviceId = -1;
            if (service != null)
            {

                tbxServiceName.Text = _service.Name;
                tbxDescription.Text = _service.Description;
                tbxWorkPrice.Text = _service.WorkPrice.ToString();
                tbxWorkTime.Text = _service.WorkTime.ToString();

                btnDeleteService.Style = enable;
                serviceId = _service.ServiceID;
            }
            else
            {
               
                btnDeleteService.Style = disable;
            }
            context = new KubixDBEntities();
            context.Materials.Load();
            context.Services.Load();
            context.ServiceMaterials.Load();
        

             List<ServiceMaterial> listServiceMaterials = (from s in context.Services
                        join sm in context.ServiceMaterials on s.ServiceID equals sm.ServiceID
                        where s.ServiceID == serviceId
                        select sm).ToList();

            foreach (var matr in context.Materials.Local)
            {
                ServiceMaterialControl smc = new ServiceMaterialControl();
                foreach (ServiceMaterial sm in listServiceMaterials)
                {
                    if (matr.MaterialID == sm.MaterialID)
                    {
                        smc.cbIsMaterialChecked.IsChecked = true;
                        break;
                    }
                }
                
                smc.MaterialID = matr.MaterialID;
                smc.ServiceID = serviceId;
                smc.cbIsMaterialChecked.Content = matr.Name;
                smc.tblMaterialUnit.Text = matr.UnitMeasurement;
                icMaterials.Children.Add(smc);
            }
        }

        private void BtnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            if(_service!=null)
            {
                KubixAdmin.Service newService = context.Services.Find(_service.ServiceID);
                if (newService != null)
                {
                    context.Services.Remove(newService);
                    context.SaveChanges();
                }

                Application.Current.MainWindow.Content = new Services();
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            KubixAdmin.Service newService;
            if (_service != null)
            {
                newService = context.Services.Find(_service.ServiceID);
            }
            else
            {
                newService = new KubixAdmin.Service();
                context.Services.Add(newService);
            }
            newService.Name = tbxServiceName.Text;
            newService.Description = tbxDescription.Text;
            if (string.IsNullOrEmpty(tbxWorkPrice.Text))
            {
                tbxWorkPrice.Text = "0";
            }
            if (string.IsNullOrEmpty(tbxWorkTime.Text))
            {
                tbxWorkTime.Text = "0";
            }
            newService.WorkPrice = int.Parse(tbxWorkPrice.Text);
            newService.WorkTime = int.Parse(tbxWorkTime.Text);
            context.SaveChanges();

            ServiceMaterial serviceMaterial;

            foreach(ServiceMaterialControl smc in icMaterials.Children)
            {
                serviceMaterial = context.ServiceMaterials.Find(smc.ServiceID, smc.MaterialID);
                if(smc.cbIsMaterialChecked.IsChecked.Value)
                {
                    if(serviceMaterial==null)
                    {
                        serviceMaterial = new ServiceMaterial();
                        serviceMaterial.MaterialID = smc.MaterialID;
                        serviceMaterial.ServiceID = newService.ServiceID;
                        context.ServiceMaterials.Add(serviceMaterial);
                    }
                    serviceMaterial.MaterialPerUnit = int.Parse(smc.tbMaterialPerUnit.Text);
                }
            }
            context.SaveChanges();
            Application.Current.MainWindow.Content = new Service(newService);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Services();
        }
    }
}
