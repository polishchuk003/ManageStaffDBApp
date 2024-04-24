using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using ManageStaffDBApp.Data;

namespace ManageStaffDBApp.Model
{
    public static class DataWorker
    {

        public static List<Department> GetAllDepartments()
        {
            using (var db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }


        public static List<Position> GetAllPositions()
        {
            using (var db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        public static List<Employee> GetAllEmployees()
        {
            using (var db = new ApplicationContext())
            {
                var result = db.Employees.ToList();
                return result;
            }
        }





        // create department
        public static string CreateDepartment(string name)
        {
            string result = "Вже існує!!";
            using (var db = new ApplicationContext())
            {
                bool checkIsExist = db.Departments.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    var department = new Department { Name = name };
                    db.Departments.Add(department);
                    db.SaveChanges();
                    result = "Done!";
                }
                return result;
            }
        }
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Вже існує!!";
            using (var db = new ApplicationContext())
            {
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExist)
                {
                    var newPosition = new Position
                    {
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id
                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Done!";
                }
                return result;
            }
        }

        public static string CreateEmployee(string name, string surName, string phone, Position position)
        {
            string result = "Вже існує!!";
            using (var db = new ApplicationContext())
            {
                bool checkIsExist = db.Employees.Any(el => el.Name == name && el.SurName == surName && el.Position == position);
                if (!checkIsExist)
                {
                    var newEmployee = new Employee
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    result = "Done!";
                }
                return result;
            }
        }


        // delete 

        public static string DeleteDepartment(Department department)
        {
            string result = "Такого не існує!!";
            using (var db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = "Виконано!! Відділ" + department.Name + "видалено!";
            }
            return result;
        }

        public static string DeletePosition(Position position)
        {
            string result = "Такого не існує!!";
            using (var db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Виконано!! Посаду" + position.Name + "видалено!";
            }
            return result;
        }

        public static string DeleteEmployee(Employee employee)
        {
            string result = "Такого не існує!!";
            using (var db = new ApplicationContext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                result = "Виконано!! Працівника " + employee.Name + employee.SurName + " звільнено!";
            }
            return result;
        }


        //edit

        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого не існує!!";
            using (var db = new ApplicationContext())
            {
                var department = db.Departments.FirstOrDefault(el => el.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = "Виконано!! Відділ" + department.Name + " змінено !!";
            }
            return result;
        }


        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Такого не існує!!";
            using (var db = new ApplicationContext())
            {
                var position = db.Positions.FirstOrDefault(el => el.Id == oldPosition.Id);
                position.Name = newName;
                position.Salary = newSalary;
                position.DepartmentId = newDepartment.Id;
                position.MaxNumber = newMaxNumber;
                db.SaveChanges();
                result = "Виконано!! Посаду" + position.Name + " змінено !!";
            }
            return result;
        }


        public static string EditEmployee(Employee oldEmployee, string newName, string newSurname, string newPhone, Position newPosition)
        {
            string result = "Такого не існує!!";
            using (var db = new ApplicationContext())
            {
                var employee = db.Employees.FirstOrDefault(el => el.Id == oldEmployee.Id);
                employee.Name = newName;
                employee.SurName = newSurname;
                employee.Phone = newPhone;
                employee.PositionId = newPosition.Id;
                db.SaveChanges();
                result = "Виконано!! Співробітник" + employee.Name + " змінений !!";
            }
            return result;
        }


    }
}