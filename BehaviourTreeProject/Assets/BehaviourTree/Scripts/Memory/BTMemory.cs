using System.Collections.Generic;

namespace BTree
{
    public class BTMemory
    {
        private Dictionary<string, object> _data = new();

        public bool TryGetData(string key, out object data)
        {
            return _data.TryGetValue(key, out data);
        }

        public void AddOrEditData(string key, object data)
        {
            if (!_data.TryAdd(key, data))
            {
                _data[key] = data;
            }
        }
    }
}
