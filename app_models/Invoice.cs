using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BillingManagement.Models
{
    public class Invoice : INotifyPropertyChanged
    {
        //INotify-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public int InvoiceId { get; private set; }

        static int nextId;

        private double subtotal;
        private double fedtax;
        private double provtax;
        private double total;

        public DateTime CreationDateTime { get; private set; }

        private Customer _customer;

        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        //gestion prix--------------------------------------------------------------------------------------------------------------------------------------------------------------

        public double SubTotal
        {
            get => subtotal;
            set
            {
                subtotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FedTax));
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(Total));
            } 
        }
        public double FedTax => SubTotal * 0.05;
        public double ProvTax => SubTotal * 0.09975;
        public double Total => SubTotal + FedTax + ProvTax;

        public string Info => $"{CreationDateTime} : {Total}";


        //Constructeur----------------------------------------------------------------------------
        public Invoice(Customer customer)
        {
            InvoiceId = Interlocked.Increment(ref nextId);

            CreationDateTime = DateTime.Now;
            Customer = customer;
        }

    }
}
