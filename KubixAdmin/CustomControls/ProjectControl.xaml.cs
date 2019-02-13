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
    /// Interaction logic for ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        private DateTime downTime;
        private object downSender;
        public event EventHandler Control_Click;

        public int ProjectID { set; get; }

        public ImageSource ProjectLogoSource
        {
            get { return imgProjectLogo.Source; }
            set { imgProjectLogo.Source = value; }
        }
        public string ProjectName
        {
            get { return tblProjectName.Text; }
            set { tblProjectName.Text = value; }
        }
        public string ProjectAddress
        {
            get { return tblProjectAddress.Text; }
            set { tblProjectAddress.Text = value; }
        }
        public string ProjectExpectedPrice
        {
            get { return tblProjectExpectedPrice.Text; }
            set { tblProjectExpectedPrice.Text = value; }
        }
        public string ProjectCreatedLabel
        {
            get { return tblCreatedLabel.Text; }
            set { tblCreatedLabel.Text = value; }
        }
        public string ProjectExpirationDate
        {
            get { return tblProjectExpirationDate.Text; }
            set { tblProjectExpirationDate.Text = value; }
        }

        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(ProjectControl), new PropertyMetadata(false));

        public ProjectControl()
        {
            InitializeComponent();
        }

        protected void ProjectBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
            }
        }

        protected void ProjectBorder_MouseUp(object sender, MouseButtonEventArgs e)
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
