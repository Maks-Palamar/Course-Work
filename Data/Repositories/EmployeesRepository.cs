using System.Collections.Generic;
using Newtonsoft.Json;
using Entities;
using System.IO;

namespace Data
{
    public class EmployeesRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\CourseWorkVar4\Data\DataBases\Employees.json";
        private static string json = File.ReadAllText(path);
        private List<Employee> _employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            json = File.ReadAllText(path);
            _employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            if (_employees == null)
            {
                _employees = new List<Employee>();
                employee.ID = 0;
            }
            else
            {
                employee.ID = _employees.Count;
            }

            _employees.Add(employee);

            File.WriteAllText(path, JsonConvert.SerializeObject(_employees, Formatting.Indented));
        }

        public void DeleteEmployee(Employee employee)
        {
            json = File.ReadAllText(path);
            _employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            _employees.RemoveAt(employee.ID);

            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].ID > employee.ID)
                {
                    _employees[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_employees, Formatting.Indented));
        }

        public List<Employee> GetEmployees()
        {
            json = File.ReadAllText(path);
            _employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            if (_employees == null)
                _employees = new List<Employee>();

            return _employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            json = File.ReadAllText(path);
            _employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            _employees[employee.ID] = employee;

            File.WriteAllText(path, JsonConvert.SerializeObject(_employees, Formatting.Indented));
        }
    }
}
