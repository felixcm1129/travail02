using BillingManagement.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BillingManagement.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        CustomerViewModel _vm;

        public CustomerView()
        {
            InitializeComponent();
        }

        private void CustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = _vm.Customers.IndexOf(_vm.SelectedCustomer);

            if (currentIndex > 0)
                currentIndex--;

            _vm.Customers.Remove(_vm.SelectedCustomer);

            lvCustomers.SelectedIndex = currentIndex;

        }
    }
}
