using HW_003_30_08_2024;
using System.Collections.Generic;
using System.Reflection.Emit;

class Program
{
    static void Main()
    {

        using (ApplicationContext db = new ApplicationContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var userRegistration = new UserRegistration(db);
            int choice = 0;
            while (true)
            {
                Helper.PrintMenu();
                choice = Helper.GetInt("Choice ");
                switch (choice)
                {
                    case 1:
                        {
                            if (userRegistration.CreateUser())
                            {
                                Helper.WriteSuccessfulMessage("Successful!");
                            }
                            else
                            {
                                goto case 1;
                            }
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            string enterLogin = Helper.GetString("Enter Login ");
                            string enterPassword = Helper.GetString("Enter Password ");
                            User user = new User
                            {
                                UserLogin = enterLogin,
                                PasswordHash = enterPassword
                            };
                            if (Helper.Check(user))
                            {
                                if (userRegistration.AuthenticateUser(user))
                                {
                                    Helper.WriteSuccessfulMessage("You are good");
                                }
                                else
                                {
                                    Helper.WriteErrorMessage("Login failde!");
                                }
                            }
                            else
                            {
                                goto case 2;
                            }
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            return;
                        }
                    default:
                        {
                            Helper.WriteErrorMessage("Invalid option");
                            Console.Clear();
                            break;
                        }
                }
            }
        }
    }
}