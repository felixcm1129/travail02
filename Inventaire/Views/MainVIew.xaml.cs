using app_models;
using BillingManagement.UI.ViewModels;
using Inventaire;
using System.Collections.Generic;
using System.Windows;

namespace BillingManagement.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        CustomerViewModel _vm;
        private IEnumerable<Customer> customerData;

        public MainView(CustomerViewModel vm)
        {
            InitializeComponent();

            _vm = vm;
            DataContext = _vm;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void CustomerNew_Click(object sender, RoutedEventArgs e)
        {
            Customer temp = new Customer() { Name = "Undefined", LastName = "Undefined" };
            _vm.Customers.Add(temp);
            _vm.SelectedCustomer = temp;
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CustomerViewModel();
        }

        private void Facture_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new InvoiceViewModel();
        }
    }
}
