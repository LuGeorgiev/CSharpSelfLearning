using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Pokemon
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Pokemon(string name, string type)
        {
            this.Type = type;
            this.Name = name;
        }

    }
}
