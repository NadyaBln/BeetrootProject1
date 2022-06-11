        //using Lesson_17_Collections_CW;
        using Lesson17.Collections;
        using System;
using System.Collections.Generic;
using System.Linq;

        //create Linked list
        var list = new LinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        //print it
        foreach (var item in list.GetAll())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-----------------------------");

        //print all values from Linked list
        for (int i= 0; i< list.Count; i++)
        {
            Console.WriteLine($" {list.GetByIndex(i)}");
        }

        Console.WriteLine("-----------------------------");

        //create array
        var array = Enumerable.Range(0, 10).ToArray();

        //print array 
        //replace this loop with below one
        for (int i = 0; i<array.Length; i++)
        {
            Console.WriteLine("from array");
            Console.WriteLine(array[i]);
        }
        Console.WriteLine("-----------------------------");

//create method print to unify array and list printing
//for it create commmon interface LinkedListIretator

//same 
//var iterator = new Iterator<int>(list);
//IIterator<int> iterator = list.GetIterator();

Console.WriteLine("-----------------------------");

void Print(IEnumerator<int> iterator)
{
    //put pointer to 0
    iterator.Reset();

    //replace loop top with this
    //while there is Next element -> print it
    while (iterator.HasNext())
    {
        Console.WriteLine(iterator.Current);
    }
}

Print(list.GetEnumerator());

var index = 2;
        Console.WriteLine($"{index} item of list is {list.GetByIndex(index)}");  //2 item of list is 3


        //use method Contains
        Console.WriteLine(list.Contains(2));            // true
        Console.WriteLine(list.Contains(100));          // false

        //create new linked list that saves strings
        var stringList = new LinkedList<string>
        {
            "sfsfd",
            "24234"
        };

        foreach (var item in stringList.GetAll())
        {
            Console.WriteLine(item);
        }

        var set = new Set<int>(100);
        set.Add(1);
        set.Add(2);
        set.Add(3);
        set.Add(33);

        Console.WriteLine(set.Contains(1));
        Console.WriteLine(set.Contains(3));
        Console.WriteLine(set.Contains(33));
        Console.WriteLine(set.Contains(45));

        // n - кількість, що не здали       100
        // m - загальна кількість           15000
        // O(m)                             15000
        // O(m*n)                           1500000


