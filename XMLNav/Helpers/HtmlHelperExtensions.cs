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
            bool leaf = false;

             /* <li class="nav-header">
                List header
              </li>
              <li class="active">
                <a href="#">Home</a>
              </li>
              <li>
                <a href="#">Library</a>
              </li>*/

            if (parent.Children.Count == 0)
            {
                leaf = true;
            }

            // Create a TreeNode for this node.
            if (!leaf)
            {
                html += "<li class=\"nav-header\">" + parent.Name + "</li>\n";
            }
            else
            {
                html += "<li><a href=\"#\">" + parent.Name + "</a></li>\n";
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
