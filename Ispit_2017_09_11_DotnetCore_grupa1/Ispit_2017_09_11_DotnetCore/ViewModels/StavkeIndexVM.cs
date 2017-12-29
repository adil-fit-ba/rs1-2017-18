using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class StavkeIndexVM
    {
        public class Row
        {
            public int OdjeljenjeStavkaID;
            public int BrojUDnevniku;
            public string Ucenik;
            public int BrojZakljucnihOcjena;
            
        }

        public int OdjeljenjeID;
        public List<Row> Rows;
    }
}
