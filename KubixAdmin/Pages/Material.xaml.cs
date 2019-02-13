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
    /// Interaction logic for Material.xaml
    /// </summary>
    public partial class Material : Page
    {
        KubixDBEntities context = new KubixDBEntities();
        private KubixAdmin.Material _material;
        Style enable;
        Style disable;

        public Material(KubixAdmin.Material mt)
        {
            
            InitializeComponent();
            enable = (Style)FindResource("ButtonPrimary");
            disable = (Style)FindResource("ButtonPrimaryDisabled");
            if (mt != null)
            {
                tbxName.Text = mt.Name;
                tbxDescription.Text = mt.Description;
                tbxUnitMeasurement.Text = mt.UnitMeasurement;
                tbxUnitPrice.Text = mt.UnitPrice.ToString();
                tbxType.Text = mt.Type;
            }
            else
            {
                btnDeleteCustomer.Style = disable;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            KubixAdmin.Material newMaterial;
            if(_material!=null)
            {
                newMaterial = context.Materials.Find(_material.MaterialID);
            }
            else
            {
                newMaterial = new KubixAdmin.Material();
                context.Materials.Add(newMaterial);
            }

            newMaterial.Name = tbxName.Text;
            newMaterial.Description = tbxDescription.Text;
            newMaterial.UnitMeasurement = tbxUnitMeasurement.Text;
            newMaterial.UnitPrice = int.Parse(tbxUnitPrice.Text);
            newMaterial.Type = tbxType.Text;

            context.SaveChanges();
            Application.Current.MainWindow.Content = new Materials();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Materials();
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            KubixAdmin.Material newMaterial = context.Materials.Find(_material.MaterialID);
            if (newMaterial != null)
            {
                context.Materials.Remove(newMaterial);
                context.SaveChanges();
            }
            Application.Current.MainWindow.Content = new Materials();
        }
    }
}
