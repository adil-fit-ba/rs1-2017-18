using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit.Web.Helper
{
    public class MyMvc
    {
        public static HtmlString dropdown(string name, IEnumerable<SelectListItem> items, int selectedValue, string clazz)
        {
            string x = string.Empty;

            x += "<select name='" + name + "' class='"+clazz +"'>";
            foreach (SelectListItem item in items)
            {
                if(item.Value == selectedValue.ToString())
                    x += "<option value='" + item.Value + "' selected>" + item.Text + "</option>";
                else
                    x += "<option value='" + item.Value + "'>" + item.Text + "</option>";
            }
            x += "</select >";

            return new HtmlString(x);
        }
    }
}
