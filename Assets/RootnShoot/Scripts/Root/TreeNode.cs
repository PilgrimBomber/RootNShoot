using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.RootnShoot.Scripts.Root
{
    public class TreeNode
    {
        public Vector3 position;
        public LineRenderer line;
        public GameObject circle;
        public TreeNode parent;
        public List<TreeNode> children;

        public List<TreeNode> Siblings
        {
            get
            {
                List<TreeNode> ret = parent.children;
                ret.Remove(this);
                return ret;
            }
        }

        public TreeNode AddChild(Vector3 position, LineRenderer line, GameObject circle)
        {
            this.circle = circle;
            TreeNode child = new TreeNode(position, this);
            child.line = line;
            children.Add(child);
            return child;
        }
        public TreeNode AddChild(Vector3 position, LineRenderer line)
        {
            
            TreeNode child = new TreeNode(position, this);
            child.line = line;
            children.Add(child);
            return child;
        }

        public TreeNode Next
        {
            get
            {
                if (parent == null)
                    return this;
                List<TreeNode> ret = parent.children;
                int index = ret.IndexOf(this);
                if (index >= ret.Count - 1)
                    index = 0;
                else 
                    index++;
                return ret[index];
            }
        }

        public TreeNode Previous
        {
            get
            {
                if (parent == null)
                    return this;
                List<TreeNode> ret = parent.children;
                int index = ret.IndexOf(this);
                if (index == 0)
                    index = ret.Count - 1;
                else
                    index--;
                return ret[index];
            }
        }

        public TreeNode(Vector3 pos, TreeNode parent){
            position = pos;
            this.parent = parent;
            children = new List<TreeNode>();
        }
    }
}
