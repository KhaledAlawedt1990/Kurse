using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml;

namespace AVL_Balanced_Tree
{
    class AVLNode
    {
        public int value { get; set; }
        public AVLNode left { get; set; }
        public AVLNode right { get; set; }
        public int height { get; set; }

        public AVLNode (int value) 
        {
            this.value = value;
            height = 1;
        }
    }

    class AVLTree
    {
        public AVLNode root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }
        private AVLNode Insert(AVLNode node, int value)
        {
            if (node == null)
                return new AVLNode(value);

            if (value < node.value)
                node.left = Insert(node.left, value);
            else if (value > node.value)
                node.right = Insert(node.right, value);
            else
                return node; // Duplicate Values are not allowed.

            UpdateHeight(node);
            //return node;

            return Balance(node);
        }

        public void DeleteNode(int value)
        {
            root = DeleteNode(root, value);
        }
        private AVLNode DeleteNode(AVLNode node, int value)
        {
            if (node == null)
                return node;

            if(value < node.value)
            {
                node.left = DeleteNode(node.left, value);
            }
            else if(value > node.value)
            {
                node.right = DeleteNode(node.right, value);
            }

            else
            {
                if (node.left == null)
                    return node.right;

                else if (node.right == null)
                    return node.left;


                AVLNode temp = MinValueNode(node.right);

                node.value = temp.value; 
                node.right = DeleteNode(node.right, temp.value);

            }

            UpdateHeight(node);
           return Balance(node);
        }

        private AVLNode MinValueNode(AVLNode node)
        {
            AVLNode current = node;
            while(current.left != null)
            {
                current = current.left;
            }
            return current;
        }

        public bool Exists(int value)
        {
            return Exists(root, value);
        }
        private bool Exists(AVLNode node, int value)
        {
            if (node == null)
                return false;

            if (value < node.value)
            {
                return Exists(node.left, value);
            }
            else if (value > node.value)
            {
                return Exists(node.right, value);
            }

            else
                return true;
        }

        public AVLNode Search(int value)
        {
            return Search(root, value);
        }
        private AVLNode Search(AVLNode node, int value)
        {
            if (node == null)
                return null;

            if(value < node.value)
            {
                return Search(node.left, value);
            }
            else if(value > node.value)
            {
                return Search(node.right, value);
            }
            else
                return node;
        }
        private void UpdateHeight(AVLNode node)
        {
            //this will add 1 to the max node and update the node height
            root.height = 1 + Math.Max(Height(node.left), Height(node.right));
        }

        private int Height(AVLNode node)
        {
            //this will get the height of node, incase the node is null it will return 0;
            return node != null ? node.height : 0;
        }

        private int GetBalanceFactore(AVLNode node)
        {
            return (node != null) ? Height(node.left) - Height(node.right) : 0;
        }
        private AVLNode RightRotate(AVLNode orginalRoot)
        {

            AVLNode newRoot = orginalRoot.left;
            AVLNode originalRightChild = newRoot.right;

            newRoot.left = orginalRoot;
            orginalRoot.left = originalRightChild;

            UpdateHeight(orginalRoot);
            UpdateHeight(newRoot);

            return newRoot;

        }

        private AVLNode LeftRotate(AVLNode originalRoot)
        {
            AVLNode newRoot = originalRoot.right;
            AVLNode originalChildRoot = newRoot.left;

            newRoot.left = originalRoot;
            originalRoot.right = originalChildRoot;

            UpdateHeight(originalRoot);
            UpdateHeight(newRoot);

            return newRoot;
        }
        private AVLNode Balance(AVLNode node)
        {
            int balanceFactore = GetBalanceFactore(node);

            //LL Case 
            if (balanceFactore > 1 && GetBalanceFactore(node.left) >= 0)
                return RightRotate(node);

            //RR Case
            if (balanceFactore < -1 && GetBalanceFactore(node.right) <= 0)
                return LeftRotate(node);


            if(balanceFactore > 1 && GetBalanceFactore(node.left) < 0)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            if(balanceFactore < -1 && GetBalanceFactore(node.right) > 0)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            return node;
        }

        public void printTree()
        {
            printTree(root, "", true);
        }
        private void printTree(AVLNode node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("R------");
                    indent += "      ";
                }
                else
                {
                    Console.Write("L-------");
                    indent += "|     ";
                }

                Console.WriteLine(node.value);
                printTree(node.left, indent, false);
                printTree(node.right, indent, true);
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                AVLTree tree = new AVLTree();
                int[] values = { 20, 30, 40, 10, 5,15,35,60,};

                foreach(int value in values)
                {
                    tree.Insert(value);
                }

                tree.printTree();

                bool found = tree.Exists(61);
                if (found)
                    Console.WriteLine("Founnd");
                else
                    Console.WriteLine("Not found");


                AVLNode node = tree.Search(100);
                Console.WriteLine($"Number for searching 100 " +  (node != null ?  $"is found" : "not found"));
                Console.ReadLine();
            }
        }
    }
}
