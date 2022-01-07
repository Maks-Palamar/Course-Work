using System.Collections.Generic;

namespace Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string IdentificationCode { get; set; }
        public int Experience { get; set; }
        public string SalaryAccountNumber { get; set; }
        public Unit Unit { get; set; }
        public Position Position { get; set; }
        public List<Project> Projects { get; set; }
        public int ProjectsBudgetSum { get; set; }
    }
}
