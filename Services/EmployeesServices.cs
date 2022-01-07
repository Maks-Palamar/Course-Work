using Data;
using Data.Repositories;
using Entities;
using System;
using System.Collections.Generic;

namespace Services
{
    public class EmployeesServices
    {
        private static readonly EmployeesRepository employeesRepository = new EmployeesRepository();
        private List<Employee> employees = employeesRepository.GetEmployees();

        private static readonly UnitsServices unitsServices = new UnitsServices();
        private static readonly PositionsRepository positionsRepository = new PositionsRepository();

        public string GetEmployeeInfo(string employeeID)
        {
            Employee employee = GetEmployee(employeeID);

            if (employee == null)
            {
                return "Працівника за даним ідентифікаційним номером не знайдено";
            }

            string res = "";

            res += $"\nІм'я: {employee.Name}\n" +
                   $"Прізвище: {employee.LastName}\n" +
                   $"Вік: {employee.Age}\n" +
                   $"Електронна пошта: {employee.Email}\n" +
                   $"Ідентифікаційний номер: {employee.IdentificationCode}\n" +
                   $"Стаж: {employee.Experience} років\n" +
                   $"Підрозділ: {employee.Unit.Name}\n" +
                   $"Посада: {employee.Position.Name}\n" +
                   $"Заробітня плата: {employee.Position.Salary}\n" +
                   $"Кількість проектів: {employee.Projects.Count}\n";

            return res;
        }

        public string GetEmployeeProjectsInfo(string employeeID)
        {
            Employee employee = GetEmployee(employeeID);

            if (employee == null)
            {
                return "Працівника за даним ідентифікаційним номером не знайдено";
            }

            if(employee.Projects.Count == 0)
            {
                return "Працівник не був задієний в проектах";
            }

            string res = "";

            foreach(var project in employee.Projects)
            {
                res += $"Назва проекту: {project.Name}\tБюджет проекту: {project.Budget}\n";
            }

            return res;
        }

        public string GetSortedEmployeesInfo(string sortedType = "Name")
        {
            employees = GetEmployeesList();

            if (employees.Count == 0)
            {
                return "База даних працівників пуста";
            }

            if (sortedType == "Name")
            {
                employees.Sort((first, second) => first.Name.CompareTo(second.Name));
            }
            else if(sortedType == "LastName")
            {
                employees.Sort((first, second) => first.LastName.CompareTo(second.LastName));
            }
            else if (sortedType == "Salary")
            {
                employees.Sort((first, second) => first.Position.Salary.CompareTo(second.Position.Salary));
            }
            else
            {
                return "Тип сортування не вірний";
            }

            string res = "";

            foreach (var employee in employees)
            {
                if (res != "")
                    res += "\n------------------------\n\n";

                res += GetEmployeeInfo(employee.IdentificationCode);
            }

            return res;
        }

        public string GetEmployeesInfo()
        {
            employees = employeesRepository.GetEmployees();

            if (employees.Count == 0)
            {
                return "Список працівників пустий";
            }

            string res = "";

            foreach (var employee in employees)
            {
                if (res != "")
                    res += "\n------------------------\n\n";

                res += GetEmployeeInfo(employee.IdentificationCode);
            }

            return res;
        }

        public string AddOrUpdateEmployee(string Name, string LastName, int Age, string Email, string IdentificationCode, int Experience, string SalaryAccountNumber, string UnitName, string PositionName)
        {
            employees = GetEmployeesList();

            Employee employee = new Employee
            {
                Name = Name,
                LastName = LastName,
                Age = Age,
                Email = Email,
                IdentificationCode = IdentificationCode,
                Experience = Experience,
                SalaryAccountNumber = SalaryAccountNumber,
                Unit = new Unit(),
                Position = new Position(),
                Projects = new List<Project>()
            };

            List<Position> positions = positionsRepository.GetPositions();
            foreach (var position in positions)
            {
                if (position.Name == PositionName)
                {
                    employee.Position = position;
                    break;
                }
            }

            List<Unit> units = unitsServices.GetUnits();
                 
            foreach(var unit in units)
            {
                if(unit.Name == UnitName)
                {
                    employee.Unit = unit;
                    break;
                }
            }

            bool toUpdate = false;

            foreach (var DBEmployee in employees)
            {
                if (DBEmployee.IdentificationCode == employee.IdentificationCode)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
            {
                employeesRepository.UpdateEmployee(employee);
                return "Дані успішно оновлені";
            }
            else
            {
                employeesRepository.AddEmployee(employee);
                return "Дані успішно додані";
            }
        }
 
        public string DeleteEmployee(string employeeID)
        {
            try
            {
                employees = GetEmployeesList();

                Employee employeeToDelete = employees.Find(employee => employee.IdentificationCode == employeeID);

                if (employeeToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    employeesRepository.DeleteEmployee(employeeToDelete);
                    return "Дані працівника успішно видалено";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddProject(string IdentificationCode, string Name, string Status, int Budget)
        {
            try
            {
                employees = employeesRepository.GetEmployees();

                Project project = new Project()
                {
                    Name = Name,
                    Status = Status,
                    Budget = Budget
                };

                Employee employee = employees.Find(finded => finded.IdentificationCode == IdentificationCode);

                if(employee == null)
                {
                    return "Працівника за не знайдено";
                }

                employee.Projects.Add(project);

                int ProjectsBudgetSum = 0;

                foreach (var proj in employee.Projects)
                {
                    ProjectsBudgetSum += proj.Budget;
                }

                employee.ProjectsBudgetSum = ProjectsBudgetSum;

                employeesRepository.UpdateEmployee(employee);

                return "Проект успішно додано";
            }
            catch (Exception)
            {
                return "Щось пішло не так";
            }
        }

        public Employee GetEmployee(string employeeID)
        {
            try
            {
                employees = GetEmployeesList();

                Employee findedEmployee = employees.Find(employee => employee.IdentificationCode == employeeID);

                if (findedEmployee == null)
                    throw new Exception("Об'єкта не існує");
                else
                    return findedEmployee;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Employee> GetEmployeesList()
        {
            return employeesRepository.GetEmployees();
        }
    }
}
