using System;

namespace lesson_6_arrays_CW
{
    class Lesson_6_ArraysCW
    {
        static void Main(string[] args)
        {
            //Classwork 15 feb 2022

            //задали константу Н
            int N = 10;                                             //const N

            //инициализировали 3 массива разными способами 
            int[] array = new int[N];                               //var 1 of array inicializing
            int[] array1 = new[] { 1, 2, 3, 4, 5 };                 //var 2 of array inicializing
            int[] array2  = { 41, 24, 35, 554, 54 };                //var 3 of array inicializing

            //вынесли i отдельно и не инициализируем заново в каждом цикле
            int i = 0;

            Console.WriteLine($"----------------------------------");

            //перебрать все значения массива array и присвоить значения от 0 до 10
            for ( i = 0; i<N; i++)
            {
                int value = array[1];
                array[i] = i;
            }

            Console.WriteLine($"--1--------------------------------");


            //выведет все значения массива  array (с присвоенными значениями в прошлом цикле) - с пом конст N
            for ( i=0; i<N; i++)
            {
                Console.WriteLine($"{i} item of array is {array[i]}");
            }

            Console.WriteLine($"--2--------------------------------");


            //выведет все значения массива  array1 - c помощью .Length
            for ( i = 0; i < array1.Length; i++)
            {
                Console.WriteLine($"{i} item of array is {array1[i]}");
            }

            Console.WriteLine($"--3--------------------------------");


            //отобразить индексы всех элементов массива (немного не канонично)
            i = -1;
 
            foreach (int item in array2)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }


            Console.WriteLine($"--4--------------------------------");




            //call method MultipleByNumber

            int multiplier = 2;

            MultipleByNumber(array, multiplier);

            var copiedArray = Copy(array);


            i = -1;
            foreach (int item in array)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }

            Console.WriteLine($"multiplier {multiplier}");


            Console.WriteLine($"--5------copiedArray--------MultipleByNumber------------------");


            foreach (int item in copiedArray)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }


            i = -1;
            foreach (var item in InitiateArray(5, 12))
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }




            //сортировака массива 

            Console.WriteLine($"--6------сортировка before--------------------------");

            var random = new Random();
            int[] randomArray = new int[N];
            for (i = 0; i < N; i++)
            {

                randomArray[i] = random.Next(100);
            }

            i = -1;
            foreach (int item in randomArray)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }

            //smth not ok
            Console.WriteLine($"--7------сортировка after--------------------------");
            i = -1;
            foreach (var item in BubbleSort(randomArray))
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }


        }





        //method returns sorted array- Bubble sort
        static int [] BubbleSort (int[] array)
        {
            //кол-во проходов по циклу 
            for (int i = 0; i<array.Length; i++)
            {
                //среавнене каждой пары элементов
                for (int j = 0; j < array.Length-1 ; j++)
                {
                    //сменяем элементы местами
                    if (array[j]>array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }


        //этот метод не ок тк провоцирует сайд эффект (меняет значения вне массива)- лучше сделать хз как ??
        static int [] MultipleByNumber(int [] array, int multiplier)
        {
            //каджое значение элемента массива помножить на 2 и вывеси на экран
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= multiplier;
            }

            return array;
        }







        //copy of array to aviod side effect
        static int[] Copy(int[] array)
        {
            int[] copy = new int [array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }






        //метод возвращает массив у которого значение меджу а и б

        static int [] InitiateArray(int a , int b)
        {
            int[] InitArray = new int[b - a];

            Console.WriteLine($"array length is {InitArray.Length}");

            for (int i = 0; i<InitArray.Length; i++)
            {
                InitArray[i] = a++;
            }
            return InitArray;
        }




    }
}
