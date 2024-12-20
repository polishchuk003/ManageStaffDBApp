﻿using ManageStaffDBApp.Model;
using ManageStaffDBApp.ViewModel;
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

namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow(Employee employeeToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedEmployee = employeeToEdit;
            DataManageVM.EmployeeName = employeeToEdit.Name;
            DataManageVM.EmployeeSurName = employeeToEdit.SurName;
            DataManageVM.EmployeePhone = employeeToEdit.Phone;
            //DataManageVM.UserPosition = userToEdit.Position;
        }
    }
}
