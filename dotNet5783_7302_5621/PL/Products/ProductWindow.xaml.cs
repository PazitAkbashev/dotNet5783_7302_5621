using BlApi;
using DalList;
using BO;
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
using System.Runtime;

namespace PL.Products
{
    public partial class ProductWindow : Window
    {
        BO.Product myProduct = new BO.Product();

        public ProductWindow()
        {
            InitializeComponent();
            category.ItemsSource = Enum.GetValues(typeof(BO.Enums.category));

        }

        public ProductWindow(int ID)
        {

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            myProduct.ID = int.Parse(id.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myProduct.category = (BO.Enums.category)category.SelectedItem;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            myProduct.Name = name.Text;
        }

        private void price_TextChanged(object sender, TextChangedEventArgs e)
        {
            myProduct.Price = double.Parse(price.Text);
        }

        private void in_stock_TextChanged(object sender, TextChangedEventArgs e)
        {
            myProduct.InStock = int.Parse(in_stock.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IBl blProduct = new Bl();
            blProduct.Product.addProduct(myProduct);
        }
    }
}
