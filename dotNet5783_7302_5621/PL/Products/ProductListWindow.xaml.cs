//using BlApi;
//using BlImplementation;
using BO;
using DalApi;
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
        private BlApi.IBl? bl = BlApi.Factory.Get;

        public ProductListWindow()
        {
            InitializeComponent();
            ProductListView.ItemsSource = bl.Product.getProductList();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.category));
            ProductListView.ItemsSource = bl.Product.getProductList();
        }

        private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Enums.category myCategory = (BO.Enums.category)CategorySelector.SelectedItem;
            ProductListView.ItemsSource = bl.Product.getProductList(x=> x.category == myCategory);
            //maby there is a mistake here
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            ProductWindow pw = new ProductWindow();
            pw.ShowDialog();
            ProductListView.ItemsSource = bl!.Product.getProductList();
        }

        private void updateProductDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((ProductForList)ProductListView.SelectedItem).ID;
            new ProductWindow(id).ShowDialog();
            ProductListView.ItemsSource = bl.Product.getProductList();
        }
     
        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
