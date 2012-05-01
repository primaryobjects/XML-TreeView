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
        public static List<TreeNode> ParseXML(string filePath, bool removeDuplicates = false)
        {
            string xml = File.ReadAllText(filePath);

            XDocument document = XDocument.Parse(xml);

            // Parse the XML.
            return ParseElement(document.Root, 0, removeDuplicates);
        }

        private static List<TreeNode> ParseElement(XElement parent, int depth, bool removeDuplicates)
        {
            List<TreeNode> tree = new List<TreeNode>();

            // Create a TreeNode for this node.
            TreeNode node = new TreeNode(parent.Name.LocalName);

            // Recurse.
            if (parent.HasElements)
            {
                depth++;

                foreach (XElement child in parent.Elements())
                {
                    // Parse child elements.
                    List<TreeNode> nodeList = ParseElement(child, depth, removeDuplicates);

                    // Filter out duplicates.
                    foreach (TreeNode newNode in nodeList)
                    {
                        newNode.Depth = depth;

                        if ((removeDuplicates && !TreeManager.IsExists(newNode, node.Children)) || !removeDuplicates)
                        {
                            node.Children.Add(newNode);
                        }
                    }
                }

                depth--;
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
