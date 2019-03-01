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
    /// Interaction logic for ServiceMaterialControl.xaml
    /// </summary>
    public partial class ServiceMaterialControl : UserControl
    {
        public int ServiceID { set; get; }
        public int MaterialID { set; get; }
        public ServiceMaterialControl()
        {
            InitializeComponent();
        }
    }
}
