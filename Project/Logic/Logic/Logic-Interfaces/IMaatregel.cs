using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface IMaatregel
    {
        public void MaatregelActiveren();
        public void MaatregelDeactiveren();
        public bool MoetMaatregelGeactiveerdWorden(decimal besmGr, decimal gerBesmGr, decimal SteGr);
    }
}
