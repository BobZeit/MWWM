using Coffee.CustomersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.CustomersApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly Customer _customer;
        private int myProperty;

        public CustomerViewModel(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }
        public int ID
        {
            get
            {
                return _customer.ID;
            }
        }
        public string? FirstName
        {
            get
            {
                return _customer.FirstName;
            }
            set
            {
                if (_customer.FirstName != value)
                {
                    _customer.FirstName = value;
                    RaisePropertyChanged(nameof(FirstName));
                }
            }
        }
        public string? LastName
        {
            get
            {
                return _customer.LastName;
            }
            set
            {
                if (_customer.LastName != value)
                {
                    _customer.LastName = value;
                    RaisePropertyChanged(nameof(LastName));
                }
            }
        }
        public bool IsDeveloper
        {
            get
            {
                return _customer.IsDeveloper;
            }
            set
            {
                if (_customer.IsDeveloper != value)
                {
                    _customer.IsDeveloper = value;
                    RaisePropertyChanged(nameof(FirstName));
                }
            }
        }
    }
}
