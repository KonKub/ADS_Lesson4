using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public enum NodeSide
    {
        Left,
        Right
    }

    public class BinaryTree
    {

        public int? Data { get; private set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public BinaryTree Parent { get; set; }

        public void Add(int data)                                    // Добавить узел в дерево
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data > data)
            {
                if (Left == null) Left = new BinaryTree();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree();
                Insert(data, Right, this);
            }
        }

        // Вставляет значение в определённый узел дерева
        private void Insert(int data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }
        // Вставляет узел в определённый узел дерева
        private void Insert(BinaryTree data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data.Data)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }
            if (node.Data > data.Data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }
        // Определяет, в какой ветви для родительского лежит данный узел
        private NodeSide? MeForParent(BinaryTree node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return NodeSide.Left;
            if (node.Parent.Right == node) return NodeSide.Right;
            return null;
        }

        // Удаление узла
        public void Remove(BinaryTree node)
        {
            if (node == null) return;
            var me = MeForParent(node);
            if (node.Left == null && node.Right == null)             //у узла нет дочерних элементов
            {
                if (me == NodeSide.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }
            if (node.Left == null)                                   //нет левого узла. правый становится на место удаляемого
            {
                if (me == NodeSide.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }
            
            if (node.Right == null)                                  //нет правого дочернего. левый дочерний ставим на место удаляемого
            {
                if (me == NodeSide.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }
                node.Left.Parent = node.Parent;
                return;
            }
                                                                     //Если присутствуют оба дочерних узла, то правый ставим на место удаляемого, а левый вставляем в правый
            if (me == NodeSide.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (me == NodeSide.Right)
            {
                node.Parent.Right = node.Right;
            }
            if (me == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(bufLeft, node, node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right);
            }
        }
        // Удаление значения
        public void Remove(int data)
        {
            var removeNode = Find(data);
            if (removeNode != null)
            {
                Remove(removeNode);
            }
        }
        // Поиск узла
        public BinaryTree Find(int data)
        {
            if (Data == data) return this;
            if (Data > data)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }

        public BinaryTree Find(int data, BinaryTree node)
        {
            if (node == null) return null;

            if (node.Data == data) return node;
            if (node.Data > data)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }

        public void PreOrderTravers(BinaryTree node, string space = "")
        {
            if (node != null)
            {
                PreOrderTravers(node.Right, space + "   ");
                Console.WriteLine($"{space}{node.Data}");
                PreOrderTravers(node.Left, space + "   ");
            }
        }

    }
}
