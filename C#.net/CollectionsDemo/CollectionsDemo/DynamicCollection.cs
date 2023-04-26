using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class DynamicCollection
    {
        static void Main()
        {
            //Dynamic Collections

            //Problems with static collections
            //1. If user wants to increase size that is not possible
            //2. User will have to specify a higher size to be on the safer side but if not used then waste of memory

            //Creating a dynamic collection of integer for user to insert n numbers
            DynamicArray<int> numbers = new DynamicArray<int>();
            for(int i = 1; i <= 100; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < numbers.Size; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }

            

            //Untyped collections -> System.Collections
            ArrayList xyz = new ArrayList();
            xyz.Add(10);
            xyz.Add(true);
            xyz.Add("Hello World!");

            //Typed collections -> System.Collections.Generic (Use in single threaded applications)
            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            Console.WriteLine($"Capacity: {arr.Capacity}");
            Console.WriteLine($"Count: {arr.Count}");
            //Typed collections -> System.Collections.Concurrent (Use in multi threaded applications)

            //Criteria for selecting data structure
            //1. What is the operation repeatedly done by the application

            //I. List -> Same features as array, random index read, dynamic ->IList interface
            //Initial size of list is 0 => memory not alloted until data stored
            //Capacity -> how much data can be held initially 4 (double the current size)
            //Initial capacity can be specified using => List<int> arr = new List<int>(15); [Not advised to be used]
            //TrimExcess to remove the unused space

            //II. Stack

            //III. Queue

            // IV. HashSet -> Stores only unique elements
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(2); //Ignores
            Console.WriteLine(set.Count); // Count = 2

            // V. SortedList -> Sorts on insertion -> Expensive

            // VI. Dictionary -> Key-Value pair; key always unique; key should be scalar
            Dictionary<int,string> dictionary = new Dictionary<int,string>();
            dictionary.Add(143, "First Class");
            dictionary.Add(234, "Second Class");
            dictionary.Add(249, "Passed");
            dictionary.Add(487, "Failed");

            //If requested key not present in dictionary, an exception is thrown

            foreach (int key in dictionary.Keys)
            {
                Console.WriteLine($"{key}->{dictionary[key]}");
            }
            Console.WriteLine(dictionary.ContainsKey(143));
            Console.WriteLine(dictionary.ContainsValue("Failed"));

            //Storing student details(rollno, name) semester-wise
            Dictionary<int, List<Dictionary<int, string>>> students = new Dictionary<int, List<Dictionary<int, string>>>();

            Console.ReadKey();

        }
    }
    //Creating dynamic array of any type -> Generic Collection
    class DynamicArray<datatype>
    {
        public int Size 
        {   get {
                return index;
            }
            internal set { }
        }
        //Internal data structure to store the data given by user
        private datatype[] numbers = new datatype[10];
        //Index for internal data structure
        private int index = 0;

        internal void Add(datatype v)
        {
            if (index < numbers.Length)
                numbers[index++] = v;
            else
            {
                datatype[] temp = new datatype[numbers.Length * 2];
                //for (int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}
                //To copy data from numbers to temp
                Array.Copy(numbers, temp, numbers.Length);
                //To resize array
                Array.Resize(ref numbers, numbers.Length * 2);
                numbers = temp;
                numbers[index++] = v;
            }
        }

        internal datatype Get(int i)
        {
            return numbers[i];
        }
    }

}
