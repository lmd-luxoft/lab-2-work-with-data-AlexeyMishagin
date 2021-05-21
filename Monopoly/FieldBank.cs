using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class FieldBank : Field
    {
        public FieldBank(string name, int player, bool sale) : base(name, player, sale)
        {
            base.setRenta(700);
        }
    }
}
