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
            if (service != null)
            {

                tbxServiceName.Text = _service.Name;
                tbxDescription.Text = _service.Description;
                tbxWorkPrice.Text = _service.WorkPrice.ToString();
                tbxWorkTime.Text = _service.WorkTime.ToString();

                btnDeleteService.Style = enable;
            }
            else
            {
               
                btnDeleteService.Style = disable;
            }
        }

        private void BtnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            KubixAdmin.Service newService = context.Services.Find(_service.ServiceID);
            if (newService != null)
            {
                context.Services.Remove(newService);
                context.SaveChanges();
            }

            Application.Current.MainWindow.Content = new Services();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            KubixAdmin.Service newService;
            if(_service!=null)
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
            newService.WorkPrice = int.Parse(tbxWorkPrice.Text);
            newService.WorkTime = int.Parse(tbxWorkTime.Text);
            context.SaveChanges();
            Application.Current.MainWindow.Content = new Service(newService);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Services();
        }
    }
}
