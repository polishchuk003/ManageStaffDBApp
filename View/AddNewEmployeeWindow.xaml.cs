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
using System.Windows.Shapes;
using ManageStaffDBApp.ViewModel;


namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeWindow.xaml
    /// </summary>
    public partial class AddNewEmployeeWindow : Window
    {
        public AddNewEmployeeWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
