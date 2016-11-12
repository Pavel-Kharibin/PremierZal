using System.Windows;
using PremierZal.App.Models;

namespace PremierZal.App
{
    public partial class AddOrderWindow
    {
        public AddOrderWindow()
        {
            InitializeComponent();
        }

        public AddOrderWindow(MakeOrderViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}