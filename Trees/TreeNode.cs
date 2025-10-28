
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;
            
        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class TreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> newTreeNode = new TreeNode<T>(value);
            Children.Add(newTreeNode);
            return newTreeNode;
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            int total = 1;

            if (Children.Get(0) == null)
            {
                return total;
            }
            else
            {
                foreach (TreeNode<T> children in Children)
                {
                    total += children.Count();
                }
            }
            return total;
            
        }

        
        public int Height()
        {
            int height = 0;
            //TODO #6: Return the height of this tree
            if (Children.Count() == 0)
            {
                return height;
            }
            else
            {
                height += 1;
                int heightASumar = 0;
                foreach (TreeNode<T> children in Children)
                {
                    foreach (TreeNode<T> children2 in Children) {
                        if (children.Height() > children2.Height())
                        {
                            heightASumar = children.Height();
                        }
                        else
                        {
                            heightASumar = children2.Height();
                        }
                    }
                }
                height += heightASumar;
            }
            return height;
        }




        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            int count = 1;
            foreach (TreeNode<T> children in Children)
            {
                while (!children.Value.Equals(value))
                {
                    count++;
                }
                if (children.Value.Equals(value))
                {
                    Children.Remove(count);
                    return;
                }
                else
                {
                    Remove(children);
                }
            }
            return;
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            
        }
    }
}