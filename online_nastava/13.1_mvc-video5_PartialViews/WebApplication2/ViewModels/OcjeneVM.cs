using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class OcjeneVM
    {
        public List<Row> rows;

        public class Row
        {
            public DateTime datum { get; set; }
            public int Ocjena { get; set; }
            public string OcjenaOpis { get; set; }
        }
    }
}
