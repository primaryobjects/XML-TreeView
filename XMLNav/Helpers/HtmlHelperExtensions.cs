using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMLNav.Types;

namespace XMLNav.Helpers
{
    public static class Html
    {
        private static string RenderTreeNode(TreeNode parent)
        {
            string html = "";
            bool leaf = false;
            string spanClass = "folder";

            if (parent.Children.Count == 0)
            {
                leaf = true;
                spanClass = "file";
            }

            // Create a TreeNode for this node.
            html += "<li><span class='" + spanClass + "'>" + parent.Name;
            if (leaf)
            {
                html += ": " + parent.Value;
            }
            html += "</span>";

            if (!leaf)
            {
                html += "\n<ul>\n";

                foreach (TreeNode child in parent.Children)
                {

                    // Render child elements.
                    html += RenderTreeNode(child);
                }

                html += "</ul>\n";
            }

            html += "</li>\n";

            return html;
        }

        /// <summary>
        /// Renders a List of TreeNode into a jQuery TreeView (from http://jquery.bassistance.de/treeview/demo/?2)
        /// </summary>
        public static string RenderTree(this HtmlHelper helper, List<TreeNode> tree)
        {
            string html = "";

            foreach (TreeNode node in tree)
            {
                html += RenderTreeNode(node);
            }

            return html;
        }
    }
}
