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
        public CustomerListControl()
        {
            InitializeComponent();
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            if(Grid.GetColumn(GridOne) == 0)
            {
                Grid.SetColumn(GridOne, 2);
            }
            else
            {
                Grid.SetColumn(GridOne, 0);
            }

        }
    }

}
