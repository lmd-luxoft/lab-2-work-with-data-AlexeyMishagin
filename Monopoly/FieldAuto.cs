using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class FieldAuto : Field
    {
        public FieldAuto(string name, int player, bool sale) : base(name, player, sale)
        {
            base.setPrice(500);
            base.setRenta(250);
        }
    }
}
