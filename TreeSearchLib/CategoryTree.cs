using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSearchLib
{
    public class CategoryTree
    {
        public CategoryTree()
        {
            Childrens = new List<CategoryTree>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryTree> Childrens { get; set; }
    }
}
