using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Data.Repositories
{
    public class PositionsRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\CourseWorkVar4\Data\DataBases\Positions.json";
        private static string json = File.ReadAllText(path);
        private List<Position> _positions = new List<Position>();

        public void AddPosition(Position position)
        {
            json = File.ReadAllText(path);
            _positions = JsonConvert.DeserializeObject<List<Position>>(json);

            if (_positions == null)
            {
                _positions = new List<Position>();
                position.ID = 0;
            }
            else
            {
                position.ID = _positions.Count;
            }

            _positions.Add(position);

            File.WriteAllText(path, JsonConvert.SerializeObject(_positions, Formatting.Indented));
        }

        public void DeletePosition(Position position)
        {
            json = File.ReadAllText(path);
            _positions = JsonConvert.DeserializeObject<List<Position>>(json);

            _positions.RemoveAt(position.ID);

            for (int i = 0; i < _positions.Count; i++)
            {
                if (_positions[i].ID > position.ID)
                {
                    _positions[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_positions, Formatting.Indented));
        }

        public List<Position> GetPositions()
        {
            json = File.ReadAllText(path);
            _positions = JsonConvert.DeserializeObject<List<Position>>(json);

            if (_positions == null)
                _positions = new List<Position>();

            return _positions;
        }

        public void UpdatePosition(Position position)
        {
            json = File.ReadAllText(path);
            _positions = JsonConvert.DeserializeObject<List<Position>>(json);

            _positions[position.ID] = position;

            File.WriteAllText(path, JsonConvert.SerializeObject(_positions, Formatting.Indented));
        }
    }
}
