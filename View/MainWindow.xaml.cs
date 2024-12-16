using System.Windows.Controls;
using System.Windows;
using ManageStaffDBApp.ViewModel;

namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ListView AllDepartmentsView;
        public static ListView AllPositionsView;
        public static ListView AllEmployeesView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllDepartmentsView = ViewAllDepartments;
            AllPositionsView = ViewAllPositions;
            AllEmployeesView = ViewAllEmployees;

        }
    }
}
