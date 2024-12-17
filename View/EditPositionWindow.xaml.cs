﻿using ManageStaffDBApp.ViewModel;
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
using ManageStaffDBApp.Model;

using System.Text.RegularExpressions;


namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for EditPositionWindow.xaml
    /// </summary>
    public partial class EditPositionWindow : Window
    {
        public EditPositionWindow(Position positionToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedPosition = positionToEdit;
            DataManageVM.PositionName = positionToEdit.Name;
            DataManageVM.PositionMaxNumber = positionToEdit.MaxNumber;
            DataManageVM.PositionSalary = positionToEdit.Salary;
        }
    }
}
