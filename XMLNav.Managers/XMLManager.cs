using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XMLNav.Types;

namespace XMLNav.Managers
{
    public static class XMLManager
    {
        public static List<TreeNode> ParseXML(string filePath)
        {
            string xml = File.ReadAllText(filePath);

            XDocument document = XDocument.Parse(xml);

            // Parse the XML.
            return ParseElement(document.Root);
        }
        
        private static List<TreeNode> ParseElement(XElement parent)
        {
            List<TreeNode> tree = new List<TreeNode>();

            // Create a TreeNode for this node.
            TreeNode node = new TreeNode(parent.Name.LocalName);

            // Recurse.
            if (parent.HasElements)
            {
                foreach (XElement child in parent.Elements())
                {
                    // Parse child elements.
                    node.Children.AddRange(ParseElement(child));
                }
            }
            else
            {
                // Leaf-node.
                node.Value = parent.Value;
            }

            // Add this node to the tree.
            tree.Add(node);

            return tree;
        }
    }
}
