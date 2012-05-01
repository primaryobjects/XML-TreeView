using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLNav.Types;

namespace XMLNav.Models
{
    public class HomeModel
    {
        public List<TreeNode> LeftTree { get; set; }
        public List<TreeNode> RightTree { get; set; }

        public HomeModel()
        {
            LeftTree = new List<TreeNode>();
            RightTree = new List<TreeNode>();
        }
    }
}