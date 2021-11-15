using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{

    //2. Реализуйте двоичное дерево и метод вывода его в консоль
    //Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска.
    //Дерево должно быть сбалансированным(это требование не обязательно).
    //Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.


    class Program
    {

        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node<T> Parent { get; set; }
        }


        static int cnt = 0;

        public static Node<int> Tree(int n)
        {
            Node<int> newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new Node<int>();
                newNode.Data = cnt++;
                newNode.Left = Tree(nl);
                newNode.Right = Tree(nr);
            }
            return newNode;
        }

        static void Main(string[] args)
        {

            
            var BSTree = new BinaryTree();
            BSTree.Add(20);
            BSTree.Add(40);
            BSTree.Add(10);
            BSTree.Add(30);
            BSTree.Add(80);
            BSTree.Add(29);
            BSTree.Add(31);
            BSTree.Add(32);
            BSTree.Add(70);
            BSTree.PreOrderTravers(BSTree, "  ");

            Console.ReadKey();
        }
    }
}
