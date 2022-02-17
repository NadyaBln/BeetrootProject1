using System;

namespace lesson_6_arrays_HW
{
    class Program
    {
        static void Main(string[] args)
        {
        //Homework arrays - 15 feb 2022
        //Implement 3 sort algorithms:

        //Selection
        //Bubble
        //Insertion

        //Extra:
        //Define enum SortAlgorithmType with all 3 algorithms types and create single function Sort that will accept array and SortAlgorithmType and use passed algorithm to sort array
        //Define enum OrderBy with 2 values: Asc and Desc and update Sort method with this parameter that will change sort order




        //1 - Bubble sort
            int[] mixedArrayOne = { 74, 2, 57, 42, 23, 98, 65, 8, 9, 876, 32, 0, 44, 22 };


            //show original array
            Console.WriteLine($"original array 1");

            foreach (int item in mixedArrayOne)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            //show Bubble sorted array
            Console.WriteLine($"Bubble sorted array");

            foreach (int item in BubbleSort(mixedArrayOne, OrderBy.Asc))
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();






        //2 - Insertion sort
            int[] mixedArrayTwo = { 32, 6, 21, 887, 8, 99, 12, 0, 18, 23, 255, 42, 50, 89 };

            //show original array
            Console.WriteLine($"original array 2");
            foreach (int item in mixedArrayTwo)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            //show Insertion sorted array
            Console.WriteLine($"Insertion sorted array");

            foreach (int item in InsertionSort(mixedArrayTwo, OrderBy.Asc))
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();



        //3 - Selection sort
            int[] mixedArrayThree = { 312, 6, 21, 88, 84, 19, 122, 10, 18, 23, 25, 42, 50, 59 };

            //show original array
            Console.WriteLine($"original array 3");
            foreach (int item in mixedArrayThree)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            //show Insertion sorted array
            Console.WriteLine($"Selection sorted array");

            foreach (int item in InsertionSort(mixedArrayThree, OrderBy.Desc))
            {
                Console.Write($"{item}, ");
            }

            Sort(mixedArrayThree, SortAlgorithmType.SelectionSort, OrderBy.Desc);



        }

        static int [] BubbleSort (int [] array, OrderBy type)
        {
            //кол-во проходов по циклу 
            for (int i = 0; i < array.Length; i++)
            {
                //среавнене каждой пары элементов
                for (int j = 0; j < array.Length - 1; j++)
                {
                    //сменяем элементы местами
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }


        static int [] InsertionSort (int [] array, OrderBy type)
        {
          //amount of loops
            for (int i = 0; i< array.Length; i++)
            {
                int V = array[i];
                int j = i;
                while ((j>0) && (array[j - 1] > V))
                {
                    //swap elements
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }
            return array;
        }


        static int [] SelectionSort (int [] array, OrderBy type, int currIndex = 0)
        {
            if (currIndex == array.Length)
                return array;

            int index = IndexOfMin(array, currIndex, type);
            if (index != currIndex)
            {
                int temp = array[index];
                array[index] = array[index];
                array[index] = temp;
            }
            return SelectionSort(array, type, currIndex + 1);
        }

        //search min element in array
        static int IndexOfMin (int [] array, int n, OrderBy type)
        {
            int result = n; 
            for (int i = n; i <array.Length; i++)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }
            return result;
        }




        //enum 

        enum SortAlgorithmType
        {
            InsertionSort,
            BubbleSort,
            SelectionSort
        }

        enum OrderBy
        {
            Asc,
            Desc
        }


        static void Sort (int [] array, SortAlgorithmType sort, OrderBy type)
        {
            switch (sort)
            {
                case SortAlgorithmType.InsertionSort:
                    InsertionSort(array, type);
                    break;

                case SortAlgorithmType.BubbleSort:
                    BubbleSort(array, type);
                    break;

                case SortAlgorithmType.SelectionSort:
                    SelectionSort(array, type);
                    break;
            }
        }
}
}
