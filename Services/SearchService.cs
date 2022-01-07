using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entities;

namespace Services
{
    public class SearchService
    {
        private EmployeesServices employeesServices = new EmployeesServices();

        public string FindEmployeesByKeyWord(string key)
        {
            try
            {
                List<Employee> employees = employeesServices.GetEmployeesList();
                List<Employee> resEmployees = employees.FindAll(employee => Regex.IsMatch(employee.Name, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.LastName, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.Age.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.IdentificationCode, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.Email, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.Experience.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.SalaryAccountNumber, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.Unit.Name, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(employee.Position.Name, key, RegexOptions.IgnoreCase));

                string res = "";
                foreach (var employee in resEmployees)
                {
                    if (res != "")
                        res += "\n-----------------------\n\n";

                    res += employeesServices.GetEmployeeInfo(employee.IdentificationCode);
                }

                return res;
            }
            catch (Exception e)
            {
                return "Нічого не знайено";
            }            
        }

        public string FindProjectsByKeyWord(string key)
        {
            List<Employee> employees = employeesServices.GetEmployeesList();

            List<Project> projects = new List<Project>();

            foreach(var employee in employees)
            {
                foreach(var proj in employee.Projects)
                {
                    projects.Add(proj);
                }
            }

            List<Project> resProjects = projects.FindAll(project => Regex.IsMatch(project.Name, key, RegexOptions.IgnoreCase) ||
                                                                    Regex.IsMatch(project.Status, key, RegexOptions.IgnoreCase) ||
                                                                    Regex.IsMatch(project.Budget.ToString(), key, RegexOptions.IgnoreCase));

            string res = "";

            foreach (var project in resProjects)
            {
                if (res != "")
                    res += "\n-----------------------\n\n";

                res += $"Назва проекту: {project.Name}\n" +
                       $"Статус проекту: {project.Status}\n" +
                       $"Бюджет проекту: {project.Budget}\n";
            }

            return res;
        }

        public string FindAllByKeyWord(string key)
        {
            string res = "";

            res += "Робітники: ";
            res += FindEmployeesByKeyWord(key);
            
            res += "Проекти: ";
            res += FindProjectsByKeyWord(key);

            return res;
        }

        public string FindEmployeesByParameters(string Name, string LastName, int Age, string Email, string IdentificationCode, int Experience, string SalaryAccountNumber, string UnitName, string PositionName)
        {
            List<Employee> employees = employeesServices.GetEmployeesList();
            int countParametrs = 0;
            int countOfCoincidence = 0;
            string res = "";

            if (Name != "")
                countParametrs++;
            if (LastName != "")
                countParametrs++;
            if (Age != 0)
                countParametrs++;
            if (IdentificationCode != "")
                countParametrs++;
            if (Experience != 0)
                countParametrs++;
            if (Email != "")
                countParametrs++;
            if (SalaryAccountNumber != "")
                countParametrs++;
            if (UnitName != "")
                countParametrs++;
            if (PositionName != "")
                countParametrs++;

            foreach (var employee in employees)
            {
                if (employee.Name == Name)
                    countOfCoincidence++;
                if (employee.LastName == LastName)
                    countOfCoincidence++;
                if (employee.Age == Age)
                    countOfCoincidence++;
                if (employee.IdentificationCode == IdentificationCode)
                    countOfCoincidence++;
                if (employee.Experience == Experience)
                    countOfCoincidence++;
                if (employee.Email == Email)
                    countOfCoincidence++;
                if (employee.SalaryAccountNumber == SalaryAccountNumber)
                    countOfCoincidence++;
                if (employee.Unit.Name == UnitName)
                    countOfCoincidence++;
                if (employee.Position.Name == PositionName)
                    countOfCoincidence++;

                if (countOfCoincidence == countParametrs)
                {
                    if (res != "")
                    {
                        res += "\n-----------------------\n\n";
                    }

                    res += employeesServices.GetEmployeeInfo(employee.IdentificationCode);
                }

                countOfCoincidence = 0;
            }

            return res;
        }
    }
}
