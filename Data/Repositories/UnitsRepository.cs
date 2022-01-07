using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Data.Repositories
{
    public class UnitsRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\CourseWorkVar4\Data\DataBases\Units.json";
        private static string json = File.ReadAllText(path);
        private List<Unit> _units = new List<Unit>();

        public void AddUnit(Unit unit)
        {
            json = File.ReadAllText(path);
            _units = JsonConvert.DeserializeObject<List<Unit>>(json);

            if (_units == null)
            {
                _units = new List<Unit>();
                unit.ID = 0;
            }
            else
            {
                unit.ID = _units.Count;
            }

            _units.Add(unit);

            File.WriteAllText(path, JsonConvert.SerializeObject(_units, Formatting.Indented));
        }

        public void DeleteUnit(Unit unit)
        {
            json = File.ReadAllText(path);
            _units = JsonConvert.DeserializeObject<List<Unit>>(json);

            _units.RemoveAt(unit.ID);

            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].ID > unit.ID)
                {
                    _units[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_units, Formatting.Indented));
        }

        public List<Unit> GetUnits()
        {
            json = File.ReadAllText(path);
            _units = JsonConvert.DeserializeObject<List<Unit>>(json);

            if (_units == null)
                _units = new List<Unit>();

            return _units;
        }

        public void UpdateUnit(Unit unit)
        {
            json = File.ReadAllText(path);
            _units = JsonConvert.DeserializeObject<List<Unit>>(json);

            _units[unit.ID] = unit;

            File.WriteAllText(path, JsonConvert.SerializeObject(_units, Formatting.Indented));
        }
    }
}
