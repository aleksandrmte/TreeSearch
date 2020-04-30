using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSearchLib
{
    /// <summary>
    /// Build tree, show and search
    /// </summary>
    public class TreeBuilder
    {
        public CategoryTree CategoryTreeRoot { get; set; } = new CategoryTree();
        public List<CategoryTree> Categories { get; set; } = new List<CategoryTree>();

        public CategoryTree FillData(List<CategoryTree> dataList)
        {
            Categories.AddRange(dataList);
            BuildTree(CategoryTreeRoot, Categories);
            return CategoryTreeRoot;
        }

        public void BuildTree(CategoryTree rootCategoryTree, List<CategoryTree> categories)
        {
            var catsForRoot = categories.Where(x => x.ParentId == rootCategoryTree.Id).ToList();
            if (catsForRoot.Count > 0)
                rootCategoryTree.Childrens.AddRange(catsForRoot);
            foreach (var itemCategoryTree in catsForRoot)
            {
                BuildTree(itemCategoryTree, categories);
            }
        }

        /// <summary>
        /// Show tree in screen console
        /// </summary>
        /// <param name="rootCategoryTree">root CategoryTree</param>
        /// <param name="indent">indent for console showing</param>
        public void ShowTree(CategoryTree rootCategoryTree, string indent)
        {
            foreach (var item in rootCategoryTree.Childrens.Where(x => !x.IsHidden))
            {
                Console.Write(indent);
                Console.Write(item.Name);
                Console.Write("\n");
                var newIndent = indent + "\t";
                if (item.Childrens.Any(x => !x.IsHidden))
                    ShowTree(item, newIndent);
            }
        }

        /// <summary>
        /// Search in tree
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="isSensitiveCase">Sensitive case or not important</param>
        public void Search(string query, bool isSensitiveCase = false)
        {
            SearchInTree(CategoryTreeRoot, query, isSensitiveCase);
            ShowTree(CategoryTreeRoot, "");
        }

        private void SearchInTree(CategoryTree root, string query, bool isSensitiveCase = false)
        {
            foreach (var CategoryTreeRootChildren in root.Childrens)
            {
                if (CategoryTreeRootChildren.Childrens.Count != 0)
                {
                    SearchInTree(CategoryTreeRootChildren, query, isSensitiveCase);
                    if (CategoryTreeRootChildren.Childrens.All(x => x.IsHidden) && !(isSensitiveCase
                            ? CategoryTreeRootChildren.Name.Contains(query)
                            : CategoryTreeRootChildren.Name.ToLower().Contains(query.ToLower())))
                        CategoryTreeRootChildren.IsHidden = true;
                    continue;
                }
                var haveEqual = isSensitiveCase
                    ? CategoryTreeRootChildren.Name.Contains(query)
                    : CategoryTreeRootChildren.Name.ToLower().Contains(query.ToLower());
                if (!haveEqual)
                {
                    CategoryTreeRootChildren.IsHidden = true;
                }
            }
        }

    }
}
