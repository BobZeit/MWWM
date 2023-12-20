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
        private CustomerViewModel? _selectedCustomer;
        private int _navigationColumn;

        public CustomerViewModel? SelectedCustomer
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
        public ObservableCollection<CustomerViewModel> Customers { get; } =
            new ObservableCollection<CustomerViewModel>();
        public int NavigationColumn
        {
            get
            {
                return _navigationColumn;
            }

            private set
            {
                if (_navigationColumn != value)
                {
                    _navigationColumn = value;
                    RaisePropertyChanged(nameof(NavigationColumn));
                }
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
                    var customerViewModel = new CustomerViewModel(customer);
                    Customers.Add(customerViewModel);
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
            var customerViewModel = new CustomerViewModel(customer);
            Customers.Add(customerViewModel);
            SelectedCustomer = customerViewModel;
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
