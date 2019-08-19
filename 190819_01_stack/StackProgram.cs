using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _190819_01_stack
{
    class Stack
    {
        public int size;
        public int top;
        public int[] data;

        public Stack()
        {
            this.size = 8; // defalut size: 8
            this.top = -1;
            this.data = new int[this.size];
        }
        public Stack(int size)
        {
            this.size = size;
            this.top = -1;
            this.data = new int[size];
        }

        private bool IsFull()
        {
            return ((top + 1) == size);
        }
        private bool IsEmpty()
        {
            return (top == -1);
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            data[++top] = value;
        }
        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return;
            }

            Console.WriteLine("Pop : value {0} popped", data[top--]);
        }
    }

    class StackProgram
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            bool is_exit = false;
            int selected_menu = 0;

            while (!is_exit)
            {
                Console.Write("\nSelect Menu \n" +
                              "1. Push  2. Pop  3. Exit  >> ");
                selected_menu = int.Parse(Console.ReadLine());

                switch (selected_menu)
                {
                    case 1: // Push
                        Console.Write("Push : Input number >> ");
                        int push_num = int.Parse(Console.ReadLine());
                        stack.Push(push_num);
                        break;
                    case 2: // Pop
                        stack.Pop();
                        break;
                    case 3: // Exit
                        is_exit = true;
                        break;
                }
            }
        }
    }
}
