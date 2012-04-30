using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLNav.Types
{
    public class TreeNode
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode()
        {
            Children = new List<TreeNode>();
        }

        public TreeNode(string name)
            : this()
        {
            Name = name;
        }

        public TreeNode(string name, string value)
            : this(name)
        {
            Value = value;
        }
    };
}
