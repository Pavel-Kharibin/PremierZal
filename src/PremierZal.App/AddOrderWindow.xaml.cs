using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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

        private void TxtTicketsCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckText(e.Text);
        }

        private void TxtTicketsCount_OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof (string)))
            {
                var text = (string) e.DataObject.GetData(typeof (string));
                if (!CheckText(text)) e.CancelCommand();
            }
            else e.CancelCommand();
        }

        private bool CheckText(string text)
        {
            var regex = new Regex("[0-9.-]+");
            return regex.IsMatch(text) && Convert.ToInt32(TxtTicketsCount.Text + text) > 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = DialogResult == true && !(CheckText(TxtTicketsCount.Text) && CmbSessions.SelectedValue != null);
        }
    }
}