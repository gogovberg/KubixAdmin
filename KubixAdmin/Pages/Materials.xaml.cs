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
    /// Interaction logic for Materials.xaml
    /// </summary>
    public partial class Materials : Page
    {
        KubixDBEntities context;
        Style enable;
        Style disable;
        private static Action EmptyDelegate = delegate () { };
        public Materials()
        {
            InitializeComponent();
            context = new KubixDBEntities();
            context.Materials.Load();
            BitmapImage imgsrc = new BitmapImage(new Uri("/Images/icon_user_primary.png", UriKind.Relative));
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");


        }
    }
}
