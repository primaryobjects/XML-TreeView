using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLNav.Types;

namespace XMLNav.Managers
{
    public static class TreeManager
    {
        public static bool IsExists(TreeNode node, List<TreeNode> tree)
        {
            if (tree != null && tree.Count > 0)
            {
                foreach (TreeNode child in tree)
                {
                    bool exists = IsExists(node, child);
                    if (exists)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsExists(TreeNode node, TreeNode parent)
        {
            // Base-case. Does this node's name match our target?
            if (node.Name.ToLower() == parent.Name.ToLower())
            {
                return true;
            }

            // Recurse.
            if (parent.Children.Count > 0)
            {
                foreach (TreeNode child in parent.Children)
                {
                    // Parse child elements.
                    bool exists = IsExists(node, child);
                    if (exists)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
