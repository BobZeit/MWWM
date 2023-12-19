using Coffee.CustomersApp.Data;
using Coffee.CustomersApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _provider;
        private Customer? _selectedCustomer;
        private int _navigationColumn;

        public Customer? SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged(nameof(SelectedCustomer));
                }
            }
        }

        public CustomersViewModel(ICustomerDataProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
        public ObservableCollection<Model.Customer> Customers { get; } =
            new ObservableCollection<Model.Customer>();
        public int NavigationColumn
        {
            get
            {
                return _navigationColumn;
            }

            private set
            {
                _navigationColumn = value;
                RaisePropertyChanged(nameof(NavigationColumn));
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _provider.GetCustomerAsync();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }

        }

        internal void AddCustomer()
        {
            var customer = new Customer()
            {
                FirstName = "New",
                LastName = "Customer",
            };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        internal void MoveNavigation()
        {
            NavigationColumn = NavigationColumn == 0 ? 2 : 0;
        }

        //    pirvate void RaisePropertyChanged([CallerMemberName] string? propertyName)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }

    }
}
