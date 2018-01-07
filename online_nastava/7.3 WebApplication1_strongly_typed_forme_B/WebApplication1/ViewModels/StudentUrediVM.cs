using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using static WebApplication1.helper.G;

namespace WebApplication1.ViewModels
{
    public class StudentUrediVM
    {
        public Student student;
        public List<SelectListItem> gradovi;
        public List<SelectListItem> zanimanja;
    }
}
