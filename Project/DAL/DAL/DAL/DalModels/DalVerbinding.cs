using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DalModels
{
    public class DalVerbinding
    {
        public DalLand vertrekLand { get; set; }
        public DalLand aankomstLand { get; set; }
        public int verkeer { get; set; }

    }
}
