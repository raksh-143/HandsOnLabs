using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class StaticCollection
    {
        static void Main(string[] args)
        {
            //Static Collections
            //It stores data in contiguous memory and hence the size cannot be increased when needed because the next location in
            //memory may or may not be available


            int a = 10; //Memory allocated = 4B; memory allocated in stack
            //int[] numbers; //Memory allocated = 4B; memory allocated in stack
            int[] numbers = new int[10]; //Memory allocated = 40B; Memory allocated in heap; By default all array values are 0;can initialize with variable (int[size])
            //To store
            numbers[0] = a;
            //To read
            a = numbers[0];
            //Initializing an array while declaring it
            int[] numbers2 = new int[5] { 1, 2, 3, 4, 5 }; //Should have 5 elements; cannot initialize with variable (int[size])
            int[] numbers3 = new int[] { 1, 2, 3, 4, 5 }; //May have more than 5 elements
            int[] numbers4 = { 1, 2, 3, 4, 5 };

            Item[] items = new Item[5];
            Item i1 = new Item { ItemID = 1, Name = "IPhone X", Cost = 75000 };
            items[0] = i1;

            //Use for read and write operations
            for (int i = 0; i < numbers2.Length; i++) //Don't use a number as length even if the length is known (For maintainability)
            {
                Console.WriteLine(numbers2[i]);
            }

            //Use foreach for readonly purposes
            foreach (int item in numbers2) //slower than for
            {
                Console.WriteLine(item);
            }


            //Operations on array
            int[] numbers9 = { 1, 2, 3, 4, 5 };
            int sum = numbers9.Sum();
            int min = numbers9.Min();
            int max = numbers9.Max();
            double avg = numbers9.Average();

            Array.Sort(numbers9);
            Array.Reverse(numbers9);

            //Array functionalities present as extension methods or in Array class
            //Create your own algorithm if in-built method for your need is not present

            Item[] items3 =
            {
                new Item{ItemID = 1,Name = "IPhone",Cost = 76000},
                new Item{ItemID = 2,Name = "Galaxy S22",Cost = 90000},
                new Item{ItemID = 3,Name = "MI 56",Cost = 5000}
            };

            //var -> when we don't want to specify the variable type

            Array.Sort(items3,new ItemNameComparer()); //Sorting based on Name
            Array.Sort(items3, new ItemCostComparer()); //Sorting based on Name
            for (int i = 0; i < items3.Length; i++)
            {
                Console.WriteLine(items3[i]);
            }

            //IComparer -> Interface present in System.Collections.Generic namespace used to sort an array based on a particular property of the objects
            //Takes in 2 objects
            //IComparer -> When you don't have full power on the class whose objects are to be sorted 

            //IComparable -> Interface present in System.Collections namespace used to sort an array based on a particular property of the objects
            //Takes in 1 object
            //IComparable -> When you have full power on the class whose objects are to be sorted; The class should implement the interface

        }
    }
    //IComparer
    class ItemCostComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return (x.Cost - y.Cost); //For numerical columns only; To sort name based create another algorithm
        }
    }
    class ItemNameComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Name.CompareTo(y.Name); //To equate the 2 strings and return the comparison
        }
    }

    //IComparable -> Non generic version
    class Item : IComparable<Item> //-> For generic implementation
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        //public int CompareTo(Object obj) //Automatically invoked by Sort method of Array class
        //{
        //    //Non-generic version of IComparable
        //    //Downcasting
        //    Item item = (Item)obj;
        //    //Logic to sort based on Cost
        //    if(this.Cost > item.Cost)
        //    {
        //        //Ascending
        //        return 1;
        //        //Descending
        //        //return -1;
        //    }
        //    else if(this.Cost < item.Cost)
        //    {
        //        //Ascending
        //        return -1;
        //        //Descending
        //        //return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public int CompareTo(Item item)
        {
            //Logic to sort based on Cost
            if (this.Cost > item.Cost)
            {
                //Ascending
                return 1;
                //Descending
                //return -1;
            }
            else if (this.Cost < item.Cost)
            {
                //Ascending
                return -1;
                //Descending
                //return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
