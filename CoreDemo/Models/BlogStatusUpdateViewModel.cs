using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class BlogStatusUpdateViewModel
    {
        public Blog Blog { get; set; }
        public int SelectedStatus { get; set; }
    }
}
