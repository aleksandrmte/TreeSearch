using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSearchLib;

namespace TreeSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var categories = new List<CategoryTree>();
            FillData(categories);
            Console.WriteLine("Build tree");
            Console.WriteLine();
            var treeBuilder = new TreeBuilder();
            //fill data
            var root = treeBuilder.FillData(categories);
            treeBuilder.ShowTree(root, "");
            Console.WriteLine();
            Console.WriteLine("Enter text for search...");
            var query = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Tree after search");
            Console.WriteLine();
            treeBuilder.Search(query);
            Console.ReadKey();
        }

        private static void FillData(List<CategoryTree> categories)
        {
            categories.Add(new CategoryTree
            {
                Id = 0,
                Name = "Справка",
                ParentId = null
            });
            categories.Add(new CategoryTree
            {
                Id = 1,
                Name = "Введение",
                ParentId = 0
            });
            categories.Add(new CategoryTree
            {
                Id = 2,
                Name = "Контент",
                ParentId = 0
            });
            categories.Add(new CategoryTree
            {
                Id = 3,
                Name = "Заключение",
                ParentId = 0
            });
            categories.Add(new CategoryTree
            {
                Id = 4,
                Name = "Отчёты",
                ParentId = 2
            });
            categories.Add(new CategoryTree
            {
                Id = 5,
                Name = "Администрирование",
                ParentId = 2
            });
            categories.Add(new CategoryTree
            {
                Id = 6,
                Name = "Настройка справки",
                ParentId = 5
            });
        }
    }
}
