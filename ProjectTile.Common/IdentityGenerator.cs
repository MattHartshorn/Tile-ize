using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTile.Common
{
    public static class IdentityGenerator
    {
        private static Dictionary<string, int> _items;


        static IdentityGenerator()
        {
            _items = new Dictionary<string, int>();
        }


        public static void AddIdentityObject(string key, int currentID)
        {
            if (_items.ContainsKey(key))
                throw new ArgumentException("The given key is already defined");

            _items.Add(key, currentID);
        }

        public static int GetNextID(string key)
        {
            if (!_items.ContainsKey(key))
                _items.Add(key, -1);

            _items[key] += 1 ;
            return _items[key];
        }

    }
}
