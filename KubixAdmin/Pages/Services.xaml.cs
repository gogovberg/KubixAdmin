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
    /// Interaction logic for Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        KubixDBEntities context = new KubixDBEntities();
        Style enable;
        Style disable;
        public Services()
        {
            InitializeComponent();
            context = new KubixDBEntities();
            context.Services.Load();
            BitmapImage imgsrc = new BitmapImage(new Uri("/Images/icon_user_primary.png", UriKind.Relative));
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");

            foreach (var cust in context.Services.Local)
            {
                CustomerControl cc = new CustomerControl();
                cc.CustomerName = cust.Name;
                cc.CustomerLocation = cust.Description;
                cc.CustomerCreatedDate = cust.WorkPrice.ToString();
                cc.CustomerCreatedLabel = cust.WorkTime.ToString();
                //cc.CustomerPhoneNumber = cust.PhoneNumber;
                cc.Control_Click += new EventHandler(Control_click);
                cc.CustomerLogoSource = imgsrc;
                cc.CustomerID = cust.ServiceID;
                rpsGridServices.Children.Add(cc);
            }
        }
        protected void Control_click(object sender, EventArgs e)
        {
            CustomerControl cc = (CustomerControl)sender;
            KubixAdmin.Service tempService = null;

            foreach (KubixAdmin.Service service in context.Services.Local)
            {
                if (service.ServiceID == cc.CustomerID)
                {
                    tempService = service;
                }
            }
            if (tempService != null)
            {
                Application.Current.MainWindow.Content = new Service(tempService);
            }

        }

        private void BtnCreateService_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Service(null);
        }


    }
}
