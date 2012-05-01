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
        #region RenderTree Bootstrap

        private static string RenderTreeNodeBootstrap(TreeNode parent)
        {
            string html = "";
            string name = parent.Name;

            for (int i = 0; i < parent.Depth; i++)
            {
                name = "&nbsp;&nbsp;" + name;
            }

            // Create a TreeNode for this node.
            if (parent.Children.Count > 0)
            {
                html += "<li class=\"nav-header\">" + name + "</li>\n";
            }
            else
            {
                html += "<li><a href=\"#\">" + name + "</a></li>\n";
            }

            foreach (TreeNode child in parent.Children)
            {
                // Render child elements.
                html += RenderTreeNodeBootstrap(child);
            }

            return html;
        }

        public static string RenderTreeBootstrap(this HtmlHelper helper, List<TreeNode> tree)
        {
            string html = "";

            foreach (TreeNode node in tree)
            {
                html += RenderTreeNodeBootstrap(node);
            }

            return html;
        }

        #endregion
    }
}
