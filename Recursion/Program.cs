using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main()
        {
            //Node root = new Node(10);
            //root.StoreValue(8);
            //root.StoreValue(5);
            //root.StoreValue(6);
            //root.StoreValue(11);
            //Console.WriteLine(root.SearchValue(5) != null);
            //Console.WriteLine(root.SearchValue(13) != null);
            //Console.ReadKey();

            Node root = null;
            Random random = new Random();
            int numberOfValues = 10000;
            HashSet<int> numbers = new HashSet<int>();
            for (int i= 0; i < numberOfValues; i++) 
            {
                int tempNumber = random.Next(1, numberOfValues * 2);
                numbers.Add(tempNumber);
                //System.Threading.Thread.Sleep(100);
            }
            foreach (int item in numbers)
            {
                if (root == null)
                {
                    root = new Node(item);
                }
                else
                {
                    root.StoreValue(item);
                }
            }


            int findValue = random.Next(1, numberOfValues *2);
            Console.WriteLine(findValue);
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Console.WriteLine(root.SearchValue(findValue) != null);
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            bool result = false;
            foreach (int currentValue in numbers)
            {
                if (currentValue == findValue) 
                {
                    result = true;
                    break;
                }
            }
            Console.WriteLine(result);
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            

            Console.ReadKey();
        }
    }
    public class Node
    {
        private int value;
        private Node left;
        private Node right;
        public Node(int value)
        {
            this.value = value;
        }
        public void SetLeft(Node node)
        {
            this.left = node;
        }
        public void SetRight(Node node)
        {
            this.right = node;
        }
        public void StoreValue(int value) 
        {
            if (value < this.value) 
            {
                if (left == null)
                {
                    this.left = new Node(value);
                }
                else 
                {
                    this.left.StoreValue(value);
                }
            }

            if (value > this.value) 
            {
                if (right == null)
                {
                    this.right = new Node(value);
                }
                else
                {
                    this.right.StoreValue(value);
                }
            }
        }

        public int? SearchValue(int value) 
        {
            if (this.value == value) 
            {
                return value;
            }
            if (this.value > value && this.left != null) 
            {
                return this.left.SearchValue(value);
            }
            if (this.value < value && this.right != null)
            {
                return this.right.SearchValue(value);
            }
            return null;
        }
    }
}
