using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19081901_02_queue
{
    class Queue
    {
        public int size;
        public int[] data;
        public int front;
        public int rear;

        public Queue()
        {
            size = 8; // defalut size: 8
            data = new int[size];
            front = rear = 0;
        }
        public Queue(int size)
        {
            this.size = size;
            data = new int[size];
            front = rear = 0;
        }

        private bool IsFull()
        {
            return ((rear + 1) % size == front);
        }
        private bool IsEmpty()
        {
            return (rear == front);
        }

        public void GetSize()
        {
            Console.WriteLine("Size: {0}", this.size);
        }

        public void Enqueue(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue Overflow");
                return;
            }

            rear = (rear + 1) % size;
            data[rear] = value;
            Console.WriteLine("{0} enqueued", data[rear]);
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue Underflow");
                return;
            }

            front = (front + 1) % size;
            Console.WriteLine("{0} dequeued", data[front]);
        }
    }

    class QueueProgram
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            queue.GetSize();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
        }
    }
}
