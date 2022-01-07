using Data.Repositories;
using Entities;
using System.Collections.Generic;

namespace Services
{
    public class UnitsServices
    {
        private static readonly UnitsRepository unitsRepository = new UnitsRepository();
        private static List<Unit> units = unitsRepository.GetUnits();
        private static readonly EmployeesServices employeesServices = new EmployeesServices();
        private static List<Employee> employees = new List<Employee>();

        public string AddOrUpdateUnit(string UnitID, string Name)
        {
            units = unitsRepository.GetUnits();

            Unit unit = new Unit()
            {
                UnitID = UnitID,
                Name = Name,
            };

            bool toUpdate = false;

            foreach (var DBUnit in units)
            {
                if (DBUnit.UnitID == unit.UnitID)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
            {
                unitsRepository.UpdateUnit(unit);
                return "Дані успішно оновлені";
            }
            else
            {
                unitsRepository.AddUnit(unit);
                return "Дані успішно додані";
            }
        }

        public string GetUnitInfo(string UnitID)
        {
            units = unitsRepository.GetUnits();
            employees = employeesServices.GetEmployeesList();

            Unit findedUnit = units.Find(unit => unit.UnitID == UnitID);
            List<Employee> unitEmployees = employees.FindAll(finded => finded.Unit.UnitID == UnitID);

            if (units == null || units.Count == 0)
                return "База даних підрозділів пуста";

            string res = "";

            res += $"Ідентифікатор підрозділу: {findedUnit.UnitID}\n" +
                   $"Назва підрозділу: {findedUnit.Name}\n" +
                   $"Кількість працівників в підрозділі: {unitEmployees.Count}";

            return res;
        }

        public string GetSortedUnitsInfo(string UnitID, string sorting = "position")
        {
            units = unitsRepository.GetUnits();
            employees = employeesServices.GetEmployeesList();

            Unit findedUnit = units.Find(unit => unit.UnitID == UnitID);
            List<Employee> unitEmployees = employees.FindAll(finded => finded.Unit.UnitID == UnitID);

            if (findedUnit == null)
                return "Підрозділ не знайдено";

            if (unitEmployees.Count == 0 || unitEmployees == null)
                return "Працівників не знайдено";

            if (sorting == "position")
            {
                employees.Sort((first, second) => first.Position.Name.CompareTo(second.Position.Name));
            }
            else if (sorting == "budget")
            {
                employees.Sort((first, second) => first.ProjectsBudgetSum.CompareTo(second.ProjectsBudgetSum));
            }

            string res = "";

            foreach(var employee in employees)
            {
                res += employeesServices.GetEmployeeInfo(employee.IdentificationCode);
            }

            return res;
        }

        public List<Unit> GetUnits()
        {
            return unitsRepository.GetUnits();
        }
    }
}
