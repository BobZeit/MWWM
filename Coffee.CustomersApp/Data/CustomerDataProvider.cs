using Coffee.CustomersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.CustomersApp.Data
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>?> GetCustomerAsync()
        {
           await Task.Delay(100);
            var customers = new List<Customer>()
            {
                new Customer() { ID = 1, FirstName = "John", LastName = "Doe", IsDeveloper = true },
                new Customer() { ID = 2, FirstName = "Jane", LastName = "Doe", IsDeveloper = false },
                new Customer() { ID = 3, FirstName = "Max", LastName = "Mustermann", IsDeveloper = true },
                new Customer() { ID = 4, FirstName = "Erika", LastName = "Mustermann", IsDeveloper = false },
                new Customer() { ID = 5, FirstName = "Tom", LastName = "Ate", IsDeveloper = true },
                new Customer() { ID = 6, FirstName = "Anna", LastName = "Nass", IsDeveloper = false }
            };
            return customers;
        }
    }
}
