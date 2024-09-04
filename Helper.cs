using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_003_30_08_2024
{
    internal class Helper
    {
        private const string _subMessage = "Enter";
        public static void WriteSuccessfulMessage(string messege)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(messege);
            Console.ForegroundColor = color;
        }
        public static void WriteErrorMessage(string messege)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error!: {messege}");
            Console.ForegroundColor = color;
        }
        public static int GetInt(string value)
        {
            int result = 0;
            Console.Write($"{_subMessage} {value}");
            while (!int.TryParse(Console.ReadLine(), out result));
            {
                Console.WriteLine();
            }
            return result;
        }
        public static string GetString(string value)
        {
            string result = String.Empty;
            Console.Write($"{_subMessage} {value}");
            while (String.IsNullOrWhiteSpace(result=Console.ReadLine()));
            {
                Console.WriteLine();
            }
            return result;
        }
        public static bool Check<T>(T obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            if (!Validator.TryValidateObject(obj,context,results,true))
            {
                foreach(var error in results)
                {
                    WriteErrorMessage(error.ErrorMessage);
                }
                return false;
            }
            return true;
        }
        public static void PrintMenu()
        {
            Console.WriteLine("1.Registration");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
        }
    }
}
