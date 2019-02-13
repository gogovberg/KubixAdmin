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
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        private DateTime downTime;
        private object downSender;
        public event EventHandler Control_Click;

        public int CustomerID { set; get; }

        public ImageSource CustomerLogoSource
        {
            get { return imgCustomerLogo.Source; }
            set { imgCustomerLogo.Source = value; }
        }
        public string CustomerName
        {
            get { return tblCustomerName.Text; }
            set { tblCustomerName.Text = value; }
        }
        public string CustomerPhoneNumber
        {
            get { return tblCustomerPhoneNumber.Text; }
            set { tblCustomerPhoneNumber.Text = value; }
        }
        public string CustomerLocation
        {
            get { return tblCustomerLocation.Text; }
            set { tblCustomerLocation.Text = value; }
        }
        public string CustomerCreatedLabel
        {
            get { return tblCreatedLabel.Text; }
            set { tblCreatedLabel.Text = value; }
        }
        public string CustomerCreatedDate
        {
            get { return tblCreatedDate.Text; }
            set { tblCreatedDate.Text = value; }
        }

        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(CustomerControl), new PropertyMetadata(false));


        public CustomerControl()
        {
            InitializeComponent();
        }
        protected void CustomerBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
            }
        }

        protected void CustomerBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Released && sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    if (this.Control_Click != null)
                    {
                        this.Control_Click(this, e);
                    }

                }
            }

        }
    }
}
