using ManageStaffDBApp.ViewModel;
using System.Windows;
using ManageStaffDBApp.Model;


namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for EditDepartmentWindow.xaml
    /// </summary>
    public partial class EditDepartmentWindow : Window
    {
        public EditDepartmentWindow(Department departmentToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedDepartment = departmentToEdit;
            DataManageVM.DepartmentName = departmentToEdit.Name;
        }
    }
}
