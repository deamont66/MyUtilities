using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSChanger
{
    class ComboItem
    {
        public string Name;
        public DNSHandler.Servers Value;

        public ComboItem(DNSHandler.Servers Value, string Name)
        {
            this.Value = Value;
            this.Name = Name;
        }

        public override string ToString() {
            return Name;
        }
    }
}
