using System.Collections.Generic;
using Data.Repositories;
using Entities;

namespace Services
{
    public class PositionsServices
    {
        public static PositionsRepository positionsRepository = new PositionsRepository();
        public static EmployeesServices employeesServices = new EmployeesServices();
        public static List<Position> positions = new List<Position>();

        public string AddOrUpdatePosition(string Name, int Salary, int WorkingHours)
        {
            positions = positionsRepository.GetPositions();

            Position position = new Position()
            {
                Name = Name,
                Salary = Salary,
                WorkingHours = WorkingHours,
                Ratio = Salary / WorkingHours
            };

            bool toUpdate = false;

            foreach (var DBPosition in positions)
            {
                if (DBPosition.Name == position.Name)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
            {
                positionsRepository.UpdatePosition(position);
                return "Дані успішно оновлені";
            }
            else
            {
                positionsRepository.AddPosition(position);
                return "Дані успішно додані";
            }
        }

        public string GetTopFivePosition()
        {
            positions = positionsRepository.GetPositions();
            positions.Sort((first, second) => second.Ratio.CompareTo(first.Ratio));

            string res = "";

            for(int i = 0, k = 1; i < positions.Count; i++, k++)
            {
                res += $"{k}. {positions[i].Name}\n";

                if (i == 5)
                    break;
            }

            if (res != "")
                return res;

            return "База посад пуста";
        }

        public string GetBestEmployee(string PositionName)
        {
            positions = positionsRepository.GetPositions();
            Position position = positions.Find(finded => finded.Name == PositionName);

            if (position == null || positions.Count == 0)
                return "Посаду не знайдено";

            List<Employee> employees = employeesServices.GetEmployeesList().FindAll(finded => finded.Position.Name == position.Name);

            if (employees.Count == 0 || employees == null)
                return "Працівників не знайдено";

            Employee employee = new Employee() { ProjectsBudgetSum = 0 };

            foreach(var DBEmployee in employees)
            {
                if (employee.ProjectsBudgetSum < DBEmployee.ProjectsBudgetSum)
                    employee = DBEmployee;
            }

            return employeesServices.GetEmployeeInfo(employee.IdentificationCode);
        }
    }
}
