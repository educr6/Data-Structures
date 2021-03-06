﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    class BinaryTree<T> where T : IComparable
    {
        private TreeNode<T> root;

        public BinaryTree()
        {
            this.root = null;
        }

        public void Add(TreeNode<T> node)
        {
            
            if (this.root == null)
            {
                this.root = node;
                return;
            }

            var runner = this.root;
            while (runner != null)
            {
                if (node.CompareTo(runner) < 0)
                {
                    // Is lower so go to the left
                    if (runner.Left == null)
                    {
                        runner.Left = node;
                        break;
                    }
                    else
                    {
                        runner = runner.Left;
                    }
                }

                else if (node.CompareTo(runner) > 0)
                {
                    // Is bigger so go to the right
                    if (runner.Right == null)
                    {
                        runner.Right = node;
                        break;
                    }
                    else
                    {
                        runner = runner.Right;
                    }
                }
            }
        }

        public string InOrderTraversal()
        {
            var sb = new System.Text.StringBuilder();

            Stack<TreeNode<T>> nodes = new Stack<TreeNode<T>>();

            var current = this.root;
            while (current != null || nodes.Count > 0)
            {
                while (current != null)
                {
                    nodes.Push(current);
                    current = current.Left;
                }

                current = nodes.Pop();
                sb.Append(current.Value + " ");
                current = current.Right;
                
            }

            return sb.ToString();
        }

    }
}
