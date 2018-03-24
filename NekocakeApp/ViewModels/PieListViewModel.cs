using NekocakeApp.Models;
using System.Collections.Generic;

namespace NekocakeApp.ViewModels
{
    public class PieListViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Pie> Pies { get; set; }
    }
}
