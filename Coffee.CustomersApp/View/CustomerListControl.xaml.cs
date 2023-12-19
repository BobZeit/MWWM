using Coffee.CustomersApp.Model;
using Coffee.CustomersApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coffee.CustomersApp.Controls
{
    /// <summary>
    /// Interaction logic for CustomerListControl.xaml
    /// </summary>
    public partial class CustomerListControl : UserControl
    {
        private CustomersViewModel _viewModel;
       

        public CustomerListControl()
        {
            InitializeComponent();
            _viewModel = new ViewModel.CustomersViewModel(new Data.CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomerListControl_Loaded;

        }

        private async void CustomerListControl_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveNavigation();
            //if(Grid.GetColumn(GridOne) == 0)
            //{
            //    Grid.SetColumn(GridOne, 2);
            //}
            //else
            //{
            //    Grid.SetColumn(GridOne, 0);
            //}

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCustomer();
        }
    }

}
