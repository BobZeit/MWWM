using Coffee.CustomersApp.Data;
using Coffee.CustomersApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.CustomersApp.ViewModel
{
    public class CustomersViewModel
    {
        private readonly ICustomerDataProvider _provider;
        public Customer? selectedCustomer { get; set; }

        public CustomersViewModel(ICustomerDataProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
        public ObservableCollection<Model.Customer> Customers { get; } =
            new ObservableCollection<Model.Customer>();
        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _provider.GetCustomerAsync();
            if(customers != null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
            
        }

        internal void Add()
        {
            var customer = new Customer()
            {
                FirstName = "New",
                LastName = "Customer",
            };
            Customers.Add(customer);
            selectedCustomer = customer;
        }
    }
}
