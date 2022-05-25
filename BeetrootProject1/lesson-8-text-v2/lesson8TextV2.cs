using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lesson_8_text_v2
{
    class lesson8TextV2
    {
        static void Main(string[] args)
        {
            string filePath = "PhoneBook.csv";
            string[] content = File.ReadAllLines(filePath);

            //tuple 
            //(int a, int b) tuple;
            //tuple.a = 1;
            //tuple.b = 3;
            //int c = tuple.a + tuple.b;

            //print file content
            foreach (var item in content)
            {
                Console.WriteLine(item);
            }

            //print deserialized data
            foreach ((string name, int number) item in Deserialize(content))
            {
                Console.WriteLine($"Name is {item.name}, number is {item.number}");
            }

            var phoneBook = Deserialize(content);

            //change item after deserialization
            var newRecord = (name: "Zaz", number: 1212);
            //Add(ref phoneBook, newRecord);
            //Update(phoneBook, newRecord, 0);
            Delete(ref phoneBook, 0);

            //print serialized data (what we write to file)
            var serializedBook = Serialize(phoneBook);
            foreach (var item in serializedBook)
            {
                Console.WriteLine(item);
            }

            File.WriteAllLines(filePath, serializedBook);
        }
        private static void Add(ref (string name, int number)[] content, (string name, int number) newItem)
        {
            //реализация:
            //делаем десериалайз
            //создаем новый массив 
            //увеличиваем его на 1
            //добавляем туда новое значение
            //снова сериалайз 

            (string name, int number)[] newBook = new (string name, int number)[content.Length + 1];
            content.CopyTo(newBook, 0);                                                                  //copy from Content to New Book all items начиная from 0 item
            newBook[content.Length] = newItem;                                                           //присваиваем новое значение последнему элементу. 
                                                                                                         // получается имеем тот же массив тайплов с новым элементов в конце
        }

        private static void Update((string name, int number)[] content, (string name, int number) updatedItem, int index) //не передаем через Реф тк работем с контентом, а не со ссылкой на массив (контент)
        {
            content[index] = updatedItem;
        }

        private static void Delete(ref (string name, int number)[] content, int index)
        {
            var newBook = new (string name, int number)[content.Length - 1];        //выдeляем новый массив, но на 1 меньше
            int j = 0;                                                              //пока j не = индексу
            for (int i = 0; i < content.Length; i++)                                 //копируем данные из одного массива в другой, но без элемента по указанному индексу
            {
                if (i != index)
                {
                    newBook[j ++] = content[i];
                }
            }
            content = newBook;
        }
        private static string[] Serialize((string name, int number)[] content)
        {
            var strings = new string[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                strings[i] = $"{content[i].name};{content[i].number}";
            }
            return strings;
        }
        private static (string name, int number)[] Deserialize(string[] content)
        {
            var regexp = new Regex(@"^(\w+);(\d+)$");
            var book = new (string name, int number)[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                var item = content[i];
                var match = regexp.Match(item);

                if (match.Success)
                {
                    book[i].name = match.Groups[1].Value;
                    book[i].number = int.Parse(match.Groups[2].Value);
                }
            }
            return book;
        }
    }
}
