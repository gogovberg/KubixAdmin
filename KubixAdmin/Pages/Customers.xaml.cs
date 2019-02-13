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
using System.Windows.Threading;

namespace KubixAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        KubixDBEntities context;
        Style enable;
        Style disable;
        private static Action EmptyDelegate = delegate () { };
        public Customers()
        {
            InitializeComponent();
            context = new KubixDBEntities();
            context.Customers.Load();
            BitmapImage imgsrc = new BitmapImage(new Uri("/Images/icon_user_primary.png", UriKind.Relative));
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");
          
            foreach(var cust in context.Customers.Local)
            {
                CustomerControl cc = new CustomerControl();
                cc.CustomerName = cust.Name + " " +cust.Surname;
                cc.CustomerLocation = cust.Address;
                cc.CustomerCreatedDate = cust.CreationDate.ToShortDateString();
                cc.CustomerCreatedLabel = "CREATED ON";
                cc.CustomerPhoneNumber = cust.PhoneNumber;
                cc.Control_Click += new EventHandler(Control_click);
                cc.CustomerLogoSource = imgsrc;
                cc.CustomerID = cust.CustomerID;
                rpsGridCustomers.Children.Add(cc);
            }
        }
        protected void Control_click(object sender, EventArgs e)
        {
            CustomerControl cc = (CustomerControl)sender;
            KubixAdmin.Customer tempcustomer = null;

            foreach (KubixAdmin.Customer customer in context.Customers.Local)
            {
                if (customer.CustomerID == cc.CustomerID)
                {
                    tempcustomer = customer;
                }
            }
            if (tempcustomer != null)
            {
                Application.Current.MainWindow.Content = new Projects(tempcustomer);
            }

        }
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Customer(null);
        }

  
    }
}
