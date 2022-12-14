using BlApi;
using BlImplementation;
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
using System.Windows.Shapes;

namespace PL.Products
{
    /// <summary>
    /// Interaction logic for ViewProductList.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private IBl bl = new Bl();
        public ProductListWindow()
        {
            InitializeComponent();
            ProductListView.ItemsSource = bl.Product.getProductList(); //check this again
        }

        private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
