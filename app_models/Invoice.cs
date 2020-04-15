using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BillingManagement.Models
{
    class Invoice : IDisposable, INotifyPropertyChanged
    {
        //INotify-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();

        private double subtotal;
        private double fedtax;
        private double provtax;
        private double total;

        private readonly DateTime CreationDateTime;

        Customer Customer;

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
        public double FedTax 
        { 
            get => fedtax; 
            set
            {
                fedtax = subtotal * 1.05;
            }
        }
        public double ProvTax 
        { 
            get => provtax; 
            set
            {
                provtax = subtotal * 1.09975;
            }
        }
        public double Total 
        { 
            get => total; 
            set
            {
                total = subtotal + fedtax + provtax;
            }
        }




        //Constructeur--------------------------------------------------------------------------------------------------------------------------------------------------------------

        public Invoice(Customer customer)
        {
            Customer = customer;
            CreationDateTime = DateTime.Now;
        }


        //gestion du ID-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public int InvoiceID { get; private set; }

        public Invoice()
        {

            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                InvoiceID = nextIndex;
                CreationDateTime = DateTime.Now;
            }
        }

        public void Dispose()
        {
            lock (Lock)
            {
                UsedCounter[InvoiceID] = false;
            }
        }


        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
