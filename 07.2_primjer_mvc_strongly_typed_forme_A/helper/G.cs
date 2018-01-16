using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.helper
{
    public class G
    {
     
        public static string Kombobox(string ime, List<SelectListItem> podaci)
        {
            string x = "";
            x += "<select name='" + ime + "'>";
            foreach(var i in podaci)
            {
                x += "<option value='" + i.Value  + "'>" + i.Text + "</option>";
            }
            x += "</select>";
            return x;
        }
    }
}
