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
using Microsoft.VisualBasic;

namespace PL.Products
{
    public partial class ProductWindow : Window
    {
        IBl blProduct = new Bl();
        BO.Product myProduct = new BO.Product();

        public ProductWindow()
        {
            InitializeComponent();
            act.Content = "Add";
            category.ItemsSource = Enum.GetValues(typeof(BO.Enums.category));
        }

        public ProductWindow(int ID)
        {
            InitializeComponent();
            act.Content = "Update";
            BO.Product myProduct2 = blProduct.Product.getProductDetailsD(ID);
            id.Text = myProduct2.ID.ToString();
            id.IsEnabled = false;
            name.Text = myProduct2.Name;
            in_stock.Text = myProduct2.InStock.ToString();
            price.Text = myProduct2.Price.ToString();
            category.ItemsSource = Enum.GetValues(typeof(BO.Enums.category));
            category.Text = myProduct2.category.ToString();
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

        private void act_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((string)act.Content == "Add")
                    blProduct.Product.addProduct(myProduct);
                else
                    blProduct.Product.updateProduct(myProduct);
                this.Close();
            }
            catch (BO.BoDoesNotExist b)
            {
                MessageBox.Show(b.Message);
            }
            catch (BO.BoAlreadyExist b)
            {
                MessageBox.Show(b.Message);
            }
            catch (BO.negativeNum b)
            {
                MessageBox.Show(b.Message);
            }
            catch (BO.negativeDNum b)
            {
                MessageBox.Show(b.Message);
            }
        }
    }
}
