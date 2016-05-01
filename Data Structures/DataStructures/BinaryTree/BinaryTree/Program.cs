using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateBinaryFile(args);
            //int startUpValue = 2;
            //byte [] startValue = new byte[1];
            //startValue[0] = Convert.ToByte(startUpValue);
            //Console.WriteLine(Convert.ToBase64String(startValue, 0, 1));
            //Console.WriteLine("{0:x}",34);
            
        }

        private static void CreateBinaryFile(string[] args)
        {
            if (args.Length == 1)
            {
                Console.SetIn(System.IO.File.OpenText(args[0]));
            }

            Node CurrentNode = new Node {Value = 10};

            Add(CurrentNode, 15);
            Add(CurrentNode, 5);
            Add(CurrentNode, 20);

            Random r = new Random();

            for (int i = 0; i < 60; i++)
            {
                Add(CurrentNode, r.Next(0, 200));
            }

            Add(CurrentNode, 2);
            Add(CurrentNode, 3);
            Add(CurrentNode, 1);

            Print(CurrentNode);

            if (args.Length == 1)
            {
                int[] numbers = Array.ConvertAll(Console.ReadLine().Split(new char[] {' '}), Convert.ToInt32);
                foreach (int currentSearchNumber in numbers)
                {
                    bool result = IsFound(CurrentNode, currentSearchNumber);

                    Console.WriteLine("Looking for {0} result is {1}", currentSearchNumber, result);
                }
            }
            else
            {
                int number = 2;
                bool result = IsFound(CurrentNode, number);

                Console.WriteLine("Looking for {0} result is {1}", number, result);
            }
        }
        static bool IsFound(Node currentNode, int valueToFind)
        {
            if (currentNode != null && valueToFind == currentNode.Value)
            {
                return true;
            }
            if (currentNode != null)
            {
                if (valueToFind < currentNode.Value)
                    return IsFound(currentNode.Left, valueToFind);
                else
                    return IsFound(currentNode.Right, valueToFind);
            }
            return false;
        }


        static void Print(Node currentNode)
        {
            
            if (currentNode.Left != null)
            {
                Print(currentNode.Left);
            }
            Console.WriteLine(currentNode.Value);
            if (currentNode.Right != null)
            {
                Print(currentNode.Right);
            }
            
        }

        static void Add(Node currentNode, int value)
        {
            if (currentNode.Left == null && value < currentNode.Value)
            {
                currentNode.Left = new Node { Value = value };
                return;
            }

            if (currentNode.Right == null && value > currentNode.Value)
            {
                currentNode.Right = new Node { Value = value };
                return;
            }
            if (currentNode.Left != null && value < currentNode.Value)
            {
                Add(currentNode.Left, value);
            }
            if (currentNode.Right != null && value > currentNode.Value)
            {
                Add(currentNode.Right, value);
            }
        }
    }
    public class Node
    {

        public Node()
        {
            Left = null;
            Right = null;
        }
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
