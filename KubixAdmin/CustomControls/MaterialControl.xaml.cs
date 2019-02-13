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
    /// Interaction logic for MaterialControl.xaml
    /// </summary>
    public partial class MaterialControl : UserControl
    {
        private DateTime downTime;
        private object downSender;
        public event EventHandler Control_Click;

        public int MaterialID { set; get; }

        public ImageSource MaterialLogoSource
        {
            get { return imgMaterialLogo.Source; }
            set { imgMaterialLogo.Source = value; }
        }
        public string MaterialName
        {
            get { return tblMaterialName.Text; }
            set { tblMaterialName.Text = value; }
        }
        public string MaterialDescription
        {
            get { return tblMaterialDescription.Text; }
            set { tblMaterialDescription.Text = value; }
        }
        public string MaterialType
        {
            get { return tblMaterialType.Text; }
            set { tblMaterialType.Text = value; }
        }
        public string MaterialUnitMeasurement
        {
            get { return tblMaterialUnitMeasurement.Text; }
            set { tblMaterialUnitMeasurement.Text = value; }
        }
        public string MaterialUnitPrice
        {
            get { return tblMaterialUnitPrice.Text; }
            set { tblMaterialUnitPrice.Text = value; }
        }

        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(MaterialControl), new PropertyMetadata(false));

        public MaterialControl()
        {
            InitializeComponent();
        }
        protected void MaterialBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
            }
        }

        protected void MaterialBorder_MouseUp(object sender, MouseButtonEventArgs e)
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
