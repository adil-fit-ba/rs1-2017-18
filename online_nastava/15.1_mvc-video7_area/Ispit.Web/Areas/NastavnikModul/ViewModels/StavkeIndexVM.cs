using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class StavkeIndexVM
    {
        public int OdjeljenjeId { get; set; }
        public List<Row> rows { get; set; }

        public class Row
        {
            public int BrojUDnevniku { get; set; }
            public int BrojZakljucihOcjena { get; set; }
            public string Ucenik { get; set; }
            public int OdjeljenjeStavkeId { get; set; }
        }
    }
}
