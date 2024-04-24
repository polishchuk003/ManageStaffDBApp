using ManageStaffDBApp.Model;
using ManageStaffDBApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManageStaffDBApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        private List<Department> allDepartments = DataWorker.GetAllDepartments();

        public List<Department> AllDepartments
        {
            get
            {
                return allDepartments;
            }
            private set
            {
                allDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        private List<Employee> allEmployees = DataWorker.GetAllEmployees();

        public List<Employee> AllEmployees
        {
            get
            {
                return allEmployees;
            }
            private set
            {
                allEmployees = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        private List<Position> allPositions = DataWorker.GetAllPositions();

        public List<Position> AllPositions
        {
            get
            {
                return allPositions;
            }
            private set
            {
                allPositions = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }


        private void OpenAddDepartmentWindowMethod()
        {
            var newDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }
        private void OpenAddPositionWindowMethod()
        {
            var newPositionWindow = new AddNewPositionWindow();
            SetCenterPositionAndOpen(newPositionWindow);
        }
        private void OpenAddEmployeeWindowMethod()
        {
            var newEmployeeWindow = new AddNewEmployeeWindow();
            SetCenterPositionAndOpen(newEmployeeWindow);
        }


        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
