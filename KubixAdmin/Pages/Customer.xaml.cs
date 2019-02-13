using hgi.Extensions;
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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        KubixDBEntities context = new KubixDBEntities();
        private KubixAdmin.Customer _customer;
        Style enable;
        Style disable;
        public Customer(KubixAdmin.Customer cc)
        {
            InitializeComponent();
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");
            _customer = cc;
            if (cc != null)
            {
                tbxName.Text = cc.Name;
                tbxSurname.Text = cc.Surname;
                tbxAddress.Text = cc.Address;
                tbxPhoneNumber.Text = cc.PhoneNumber;
                tbxEmail.Text = cc.Email;
                tbxCreationDate.Text = cc.CreationDate.ToSqlStringShort();
                btnDeleteCustomer.Style = enable;
            }
            else
            {
                tbxCreationDate.Text = DateTime.Now.ToSqlString();
                btnDeleteCustomer.Style = disable;
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            KubixAdmin.Customer newCustomer;

            if(_customer!=null)
            {
                newCustomer = context.Customers.Find(_customer.CustomerID);
            }
            else
            {
                newCustomer = new KubixAdmin.Customer();
                context.Customers.Add(newCustomer);
            }
            newCustomer.Name = tbxName.Text;
            newCustomer.Surname = tbxSurname.Text;
            newCustomer.Address = tbxAddress.Text;
            newCustomer.PhoneNumber = tbxPhoneNumber.Text;
            newCustomer.Email = tbxEmail.Text;
            newCustomer.CreationDate = DateTime.Parse(tbxCreationDate.Text);

            context.SaveChanges();
            Application.Current.MainWindow.Content = new Projects(newCustomer);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Customers();
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            KubixAdmin.Customer newCustomer = context.Customers.Find(_customer.CustomerID);
            if(newCustomer!=null)
            {
                context.Customers.Remove(newCustomer);
                context.SaveChanges();
            }

            Application.Current.MainWindow.Content = new Customers();
        }
    }
}
