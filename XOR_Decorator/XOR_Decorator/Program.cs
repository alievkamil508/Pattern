
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace XOR_Decorator
{
    class DynamicArray
    {



        protected int[] arraykey;
        protected int[] array;


        protected int counter1;
        protected int counter2;




        public DynamicArray(int size)
        {
            arraykey = new int[size];
            array = new int[size];

            counter1 = 0;
            counter2 = 0;
        }

        public void AddValue(int num)
        {
            if (counter1 >= array.Length)
            {
                Resize(counter1 + 10);
                AddValue(num);
            }

            array[counter1] = num;
            counter1++;
        }


        public void AddValueKey(int key)
        {
            if (counter2 >= arraykey.Length)
            {
                Resize(counter2 + 10);
                AddValue(key);
            }

            arraykey[counter2] = key;
            counter2++;
        }



        public void Resize(int newSize)
        {
            int[] arrayNew = new int[newSize];
            int[] arrayNew1 = new int[newSize];
            for (int i = 0; i < counter1; i++)
            {
                arrayNew[i] = array[i];
            }
            for (int i = 0; i < counter2; i++)
            {
                arrayNew1[i] = arraykey[i];
            }
            array = arrayNew;
            arraykey = arrayNew1;

        }

        public void EncryptShow()
        {
            for (int i = 0; i < counter1; i++)
            {

                Console.WriteLine(array[i] ^ arraykey[i]);
            }

        }


        public void DecryptShow()
        {
            for (int i = 0; i < counter1; i++)
            {

                Console.WriteLine((array[i] ^ arraykey[i]) ^ arraykey[i]);
            }

        }



    }
    class Program
    {
		
		static void Main(string[] args)
        {
            DynamicArray arr = new DynamicArray(5);

            arr.AddValue(10);
            arr.AddValue(20);
            arr.AddValue(30);
            arr.AddValue(40);
            arr.AddValue(50);


            arr.AddValueKey(1);
            arr.AddValueKey(3);
            arr.AddValueKey(5);
            arr.AddValueKey(2);
            arr.AddValueKey(0);

            arr.EncryptShow();

            Console.WriteLine("-------");

            arr.DecryptShow();

            arr.Resize(6);

            arr.AddValue(60);
            arr.AddValueKey(11);

            Console.WriteLine("-------");

            arr.EncryptShow();

            Console.WriteLine("-------");

            arr.DecryptShow();
        }
		
    }
}


