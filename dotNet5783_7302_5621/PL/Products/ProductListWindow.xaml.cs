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
            ProductListView.ItemsSource = bl.Product.getProductList();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.category));
            ProductListView.ItemsSource = bl.Product.getProductList(); //part 9.3

        }

        private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategorySelector.SelectedItem; //part8
           
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void adminButtonClick(object sender, RoutedEventArgs e)//9.1
        {

        }
        

    }
}
