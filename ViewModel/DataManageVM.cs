using ManageStaffDBApp.Model;
using ManageStaffDBApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

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
                NotifyPropertyChanged(nameof(AllDepartments));
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


        private RelayCommand openAddNewDepartmentWnd;
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get
            {
                return openAddNewDepartmentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddDepartmentWindowMethod();
                }
                );
            }
        }



        private RelayCommand openAddNewPositionWnd;
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewPositionWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPositionWindowMethod();
                }
                );
            }
        }



        private RelayCommand openAddNewEmployeeWnd;
        public RelayCommand OpenAddNewEmployeeWnd
        {
            get
            {
                return openAddNewDepartmentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddEmployeeWindowMethod();
                }
                );
            }
        }

        public string DepartmentName { get; set; }

        public string PositionName { get; set; }
        public decimal PositionSalary { get; set; }
        public int PositionMaxNumber { get; set; }
        public Department PositionDepartment { get; set; }

        public string EmployeeName { get; set; }
        public string EmployeeSurName { get; set; }
        public string EmployeePhone { get; set; }
        public Position EmployeePosition { get; set; }




        private RelayCommand addNewDepartment;
        public RelayCommand AddNewDepartment
        {
            get
            {
                return addNewDepartment ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateDepartment(DepartmentName);
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValueToProperties();
                        wnd.Close();
                    }

                }
                );
            }

        }


        private RelayCommand addNewPosition;
        public RelayCommand AddNewPosition
        {
            get
            {
                return addNewPosition ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (PositionName == null || PositionName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    if (PositionSalary == 0)
                    {
                        SetRedBlockControll(wnd, "SalaryBlock");
                    }
                    if (PositionMaxNumber == 0)
                    {
                        SetRedBlockControll(wnd, "MaxNumberBlock");
                    }
                    if (PositionDepartment == null)
                    {
                        MessageBox.Show("Виберіть відділ))");
                    }
                    else
                    {
                        resultStr = DataWorker.CreatePosition(PositionName, PositionSalary, PositionMaxNumber, PositionDepartment);
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValueToProperties();
                        wnd.Close();
                    }

                }
                );
            }

        }


        private RelayCommand addNewEmployee;
        public RelayCommand AddNewEmployee
        {
            get
            {
                return addNewEmployee ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (EmployeeName == null || EmployeeName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "EmployeeName");
                    }
                    if (EmployeeSurName == null)
                    {
                        SetRedBlockControll(wnd, "EmployeeSurName");
                    }
                    if (EmployeePhone == null)
                    {
                        SetRedBlockControll(wnd, "EmployeePhone");
                    }
                    if (EmployeePosition == null)
                    {
                        MessageBox.Show("Виберіть вакансію))");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateEmployee(EmployeeName, EmployeeSurName, EmployeePhone, EmployeePosition);
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValueToProperties();
                        wnd.Close();
                    }

                }
                );
            }

        }
        private void SetNullValueToProperties()
        {

            DepartmentName = null;
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

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #region update views

        private void UpdateAllDataView()
        {
            UpdateAllDepartmentsViews();
            UpdateAllPositionsViews();
            UpdateAllEmployeesViews();
        }

        private void UpdateAllDepartmentsViews()
        {
            allDepartments = DataWorker.GetAllDepartments();
            MainWindow.AllDepartmentsView.ItemsSource = null;
            MainWindow.AllDepartmentsView.ItemsSource = AllDepartments;
            MainWindow.AllDepartmentsView.Items.Refresh();
        }
        private void UpdateAllPositionsViews()
        {
            allPositions = DataWorker.GetAllPositions();
            MainWindow.AllPositionsView.ItemsSource = null;
            MainWindow.AllPositionsView.ItemsSource = allPositions;
            MainWindow.AllPositionsView.Items.Refresh();
        }
        private void UpdateAllEmployeesViews()
        {
            AllEmployees = DataWorker.GetAllEmployees();
            MainWindow.AllEmployeesView.ItemsSource = null;
            MainWindow.AllEmployeesView.ItemsSource = allEmployees;
            MainWindow.AllEmployeesView.Items.Refresh();
        }

        #endregion

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);

        }

        private void OpenEditDepartmentWindowMethod()
        {
            var editDepartmentWindow = new EditDepartmentWindow();
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditPositionWindowMethod()
        {
            var editPositionWindow = new EditPositionWindow();
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEditEmployeeWindowMethod()
        {
            var editEmployeeWindow = new EditEmployeeWindow();
            SetCenterPositionAndOpen(editEmployeeWindow);
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
