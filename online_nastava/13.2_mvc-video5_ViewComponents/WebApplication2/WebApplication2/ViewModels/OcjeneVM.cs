using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class OcjeneVM
    {
        public class Row
        {
           public DateTime datum;
           public int ocjena;
           public string napomena;
        }

        public List<Row> Rows;
    }
}
