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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                return openAddNewEmployeeWnd ?? new RelayCommand(obj =>
                {
                    OpenAddEmployeeWindowMethod();
                }
                );
            }
        }

        public static string DepartmentName { get; set; }

        public static string PositionName { get; set; }
        public static decimal PositionSalary { get; set; }
        public static int PositionMaxNumber { get; set; }
        public Department PositionDepartment { get; set; }

        public static string EmployeeName { get; set; }
        public static string EmployeeSurName { get; set; }
        public static string EmployeePhone { get; set; }
        public static Position EmployeePosition { get; set; }




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

            //для пользователя
            EmployeeName = null;
            EmployeeSurName = null;
            EmployeePhone = null;
            EmployeePosition = null;
            //для позиции
            PositionName = null;
            PositionSalary = 0;
            PositionMaxNumber = 0;
            PositionDepartment = null;
            //для отдела
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

        private void OpenEditDepartmentWindowMethod(Department department)
        {
            var editDepartmentWindow = new EditDepartmentWindow(department);
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditPositionWindowMethod(Position position)
        {
            var editPositionWindow = new EditPositionWindow(position);
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEditEmployeeWindowMethod(Employee emp)
        {
            var editEmployeeWindow = new EditEmployeeWindow(emp);
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


        public TabItem SelectedTabItem { get; set; }
        public static Employee SelectedEmployee { get; set; }
        public static Position SelectedPosition { get; set; }
        public static Department SelectedDepartment { get; set; }


        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(odj =>
                {
                    string resultStr = "Нічого не обрано((";
                    if (SelectedTabItem.Name == "EmployeesTab" && SelectedEmployee != null)
                    {
                        resultStr = DataWorker.DeleteEmployee(SelectedEmployee);
                        UpdateAllDataView();
                    }
                    if (SelectedTabItem.Name == "PositionsTab" && SelectedPosition != null)
                    {
                        resultStr = DataWorker.DeletePosition(SelectedPosition);
                        UpdateAllDataView();
                    }
                    if (SelectedTabItem.Name == "DepartmentsTab" && SelectedDepartment != null)
                    {
                        resultStr = DataWorker.DeleteDepartment(SelectedDepartment);
                        UpdateAllDataView();
                    }

                    SetNullValueToProperties();
                    ShowMessageToUser(resultStr);

                }
                    );
            }
        }

        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(odj =>
                {
                    string resultStr = "Нічого не обрано((";
                    if (SelectedTabItem.Name == "EmployeesTab" && SelectedEmployee != null)
                    {
                        OpenEditEmployeeWindowMethod(SelectedEmployee);
                    }
                    if (SelectedTabItem.Name == "PositionsTab" && SelectedPosition != null)
                    {
                        OpenEditPositionWindowMethod(SelectedPosition);
                    }
                    if (SelectedTabItem.Name == "DepartmentsTab" && SelectedDepartment != null)
                    {
                        OpenEditDepartmentWindowMethod(SelectedDepartment);
                    }

                    SetNullValueToProperties();
                    ShowMessageToUser(resultStr);

                }
                    );
            }
        }




        private RelayCommand editEmployee;
        public RelayCommand EditEmployee
        {
            get
            {
                return editEmployee ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не обрано співробітника";
                    string noPos = "Не обрана нові посада";
                    if (SelectedEmployee != null)
                    {
                        if (EmployeePosition != null)
                        {
                            resultStr = DataWorker.EditEmployee(SelectedEmployee, EmployeeName, EmployeeSurName, EmployeePhone, EmployeePosition);
                            SetNullValueToProperties();
                            ShowMessageToUser(resultStr); ;
                            window.Close();

                        }
                        else ShowMessageToUser(noPos);
                    }
                    else ShowMessageToUser(resultStr);


                }
                    );
            }
        }

        private RelayCommand editPosition;
        public RelayCommand EditPosition
        {
            get
            {
                return editPosition ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрана позиция";
                    string noDepartmentStr = "Не выбран новый отдел";
                    if (SelectedPosition != null)
                    {
                        if (PositionDepartment != null)
                        {
                            resultStr = DataWorker.EditPosition(SelectedPosition, PositionName, PositionMaxNumber, PositionSalary, PositionDepartment);

                            UpdateAllDataView();
                            SetNullValueToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noDepartmentStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }

        private RelayCommand editDepartment;
        public RelayCommand EditDepartment
        {
            get
            {
                return editDepartment ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран отдел";
                    if (SelectedDepartment != null)
                    {
                        resultStr = DataWorker.EditDepartment(SelectedDepartment, DepartmentName);

                        UpdateAllDataView();
                        SetNullValueToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }








    }
}
