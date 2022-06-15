using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M.Y.O.D.Models
{
    public class ViewModel
    {
        public IEnumerable<menu_item> Menu_Items { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}