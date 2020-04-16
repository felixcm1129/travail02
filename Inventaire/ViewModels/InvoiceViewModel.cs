using app_models;
using BillingManagement.Business;
using BillingManagement.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice;

        IEnumerable<Customer> customerData;

        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }

        public InvoiceViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {
            /*InvoicesDataService ids = new InvoicesDataService(customerData);
            Invoices = new ObservableCollection<Invoice>(ids.GetAll().ToList());*/
        }

        public Invoice SelectedInvoice
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                OnPropertyChanged();
            }
        }
    }
}
