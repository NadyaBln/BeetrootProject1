using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace lesson_22_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //get info about type class User 
            Type userType = typeof(User);
            Type dateTimeType = typeof(DateTime);

            Console.WriteLine($"{userType.Name} is {(userType.IsClass ? "class" : "other type")}");          //User is class
            Console.WriteLine($"{dateTimeType.Name} is {(dateTimeType.IsClass ? "class" : "other type")}");  //DateTime is other type

            //how many properies are in class User
            Console.WriteLine($"{userType.Name} consists of {userType.GetProperties().Length} properties");

            //get info about each property
            foreach (var propertyInfo in userType.GetProperties())
            {
                Console.WriteLine($"property {propertyInfo.Name} of type {propertyInfo.PropertyType.Name}");
            }

            //get info about all methods of type string
            foreach (var methodInfo in typeof(string).GetMethods())
            {
                Console.WriteLine($"Method {methodInfo.Name} with {methodInfo.GetParameters().Length} params, returns {methodInfo.ReturnType.Name}");
            }

            //get type of method from class User
            MethodInfo methodInformation = userType.GetMethod(nameof(User.Method));

            //get info about parameters from method in class user
            ParameterInfo parameter = methodInformation.GetParameters().First();

            //print defaul value of that method. here paramether is in data type Object
            object defaultValue = parameter.DefaultValue;
            Console.WriteLine(defaultValue);

            //if paramether is data type - int. convert it to int
            if (parameter.ParameterType == typeof(int))
            {
                int intValue = (int)defaultValue;
                Console.WriteLine(intValue);
            }

            //create class instance 
            //1st way
            object user1 = Activator.CreateInstance(typeof(User), "Den");

            //2nd way
            User user2 = Activator.CreateInstance<User>();

            var u = new User(default);

            //set name 
            user2.Name = "Alex";

            //get value
            var userName = userType.GetProperty(nameof(User.Name))!.GetValue(user2);
            Console.WriteLine(userType.GetProperty(nameof(User.Name))!.GetValue(user1));
            Console.WriteLine(userName);

            //set value - change to lex
            userType.GetProperty(nameof(User.Name)).SetValue(user2, "Lex");
            Console.WriteLine(user2.Name);

            Console.WriteLine(user2.Name);
            Console.WriteLine(user2.Age);                                                                        //0

            var agePropertyInfo = userType.GetProperty(nameof(User.Age));
            var attribute = agePropertyInfo!.GetCustomAttribute<DefaultValueAttribute>();
            Console.WriteLine(attribute.Value);
            agePropertyInfo.SetValue(user2, attribute.Value);

            Console.WriteLine($"{user2.Name}, {user2.Age} years old");

            Console.WriteLine(userType.Assembly.Location);
            foreach (Type exportedType in userType.Assembly.ExportedTypes)
            {
                Console.WriteLine(exportedType.FullName);
                //Activator.CreateInstance(exportedType);
            }

            //use our attribute
            //create user for it
            var user = new User
            {
                Name = "Serhii",
                Age = 10
            };

            Console.WriteLine($"User {user.Name} is {(Validate(user) ? "valid" : "invalid")}");
        }

        //validation method 
        private static bool Validate(User user)
        {
            var agePropertyInfo = user.GetType().GetProperty(nameof(User.Age));
            var attribute = agePropertyInfo!.GetCustomAttribute<MinValueAttribute>();

            var actualValue = (int)agePropertyInfo.GetValue(user)!;
            var requiredValue = attribute!.Value;

            return actualValue > requiredValue;
        }
    }
}



    [Flags]
    enum UserPermission
    {
        Read = 1,
        Append = 2,
        Change = Read | Append,
        All = Read | Append | Change
    }

    public class Customer<[MinValue(2)]T>
    {
    }

    [AttributeUsage(AttributeTargets.GenericParameter | AttributeTargets.Class | AttributeTargets.Delegate)]
    public class MinValueAttribute : Attribute
    {
        public MinValueAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class User
    {
        public User()
        {

        }

        public User(string name)
        {
            this.Name = name;
        }

        [MinLength(10)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [DefaultValue(50)]
        public int Age { get; set; }

        public void Method(int value = 10)
        {

        }
    }

