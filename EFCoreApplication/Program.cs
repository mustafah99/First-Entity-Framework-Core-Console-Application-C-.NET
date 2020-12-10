using EFCoreApplication.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using static System.Console;

namespace EFCoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boolean mainMenu with the value True.
            bool mainMenu = true;

            // Declaring a do, while loop with the boolean mainMenu to keep it remaining inside a loop.
            do
            {
                CursorVisible = false;

                WriteLine("1. Categories");

                WriteLine("2. Articles [Ignore]");

                WriteLine("3. Exit Application");

                ConsoleKeyInfo mainMenuKeys = ReadKey();

                switch (mainMenuKeys.Key)
                {
                    case ConsoleKey.D1:
                        Clear();

                        bool subCategorieChoices = true;

                        do
                        {
                            WriteLine("1. Add New Category");

                            WriteLine("2. List Categories");

                            WriteLine("3. Add Product to Category");

                            WriteLine("4. Add Category to Category");

                            WriteLine(" ");

                            WriteLine("Press [X] To Return To Main Menu.");

                            ConsoleKeyInfo subMenuCategoryKeyInput = ReadKey();

                            if (subMenuCategoryKeyInput.Key == ConsoleKey.D1)
                            {
                                // Declaring the addingCategory boolean value and setting it to True.
                                bool addingCategory = true;

                                // Using the method we created to add a category to our table in our database.
                                AddCategory(addingCategory);

                            }
                            else if (subMenuCategoryKeyInput.Key == ConsoleKey.D2)
                            {
                                Clear();

                                WriteLine("Categories");

                                WriteLine("------------------------------------------------------------------");

                                // We want a code here using Entity Framework Core to list our table inside our Console Application.

                                // -

                                WriteLine("");

                                WriteLine("Press Any Key To Return");

                                ReadKey(true);

                                Clear();
                            }
                            else if (subMenuCategoryKeyInput.Key == ConsoleKey.D3)
                            {
                                Clear();

                                WriteLine("ID  Category                                       Total products");

                                WriteLine("------------------------------------------------------------------");

                                //ListTasks();

                                //ListTasksBySearch();

                                CursorVisible = false;

                                Clear();

                                // Input Code
                            }
                            else if (subMenuCategoryKeyInput.Key == ConsoleKey.D4)
                            {
                                Clear();

                                WriteLine("ID  Category                                       Total products");

                                WriteLine("------------------------------------------------------------------");

                                //ListTasks();

                                //ListTasksBySearchCategory();

                                CursorVisible = false;

                                Clear();

                                // Input Code
                            }
                            else if (subMenuCategoryKeyInput.Key == ConsoleKey.X)
                            {
                                subCategorieChoices = false;
                            }
                        } while (subCategorieChoices);

                        Clear();

                        break;
                    case ConsoleKey.D2:
                        Clear();

                        // No function is to be put here. This is just a placebo inside the application.

                        break;
                    case ConsoleKey.D3:
                        Clear();

                        Environment.Exit(0);

                        break;
                }
            } while (mainMenu);
        }

        private static void AddCategory(bool addingCategory)
        {
            // Declaring a do, while loop with the addingCategory boolean value set to true.
            do
            {
                // A clear method to clear the main menu while we are adding a new value to our table.
                Clear();

                // Cursor set to visible (true) for better user experience.
                CursorVisible = true;

                // Code block that accepts input from user to be stored in the corresponding table in our database.
                Write("Enter New Category Name: ");
                var newCategoryName = ReadLine();

                // Now we want to see if what the user input is what they intented or not.

                // Whitespace for better UX.
                WriteLine(" ");

                WriteLine("Is the given input correct? [Y]es | [N]o");

                // Now we set the CursorVisible to hidden (false) because we only want one out of two values from the user (Y or N keys) and not any strings.
                CursorVisible = false;

                ConsoleKeyInfo yesOrNoValidation = ReadKey(true);

                if (yesOrNoValidation.Key == ConsoleKey.Y)
                {
                    using (var context = new ProgramContext())
                    {
                        var ctg = new Categories()
                        {
                            CategoryName = newCategoryName
                        };

                        context.Category.Add(ctg);
                        context.SaveChanges();
                    };

                    // Whitespace in between the preceding WriteLine and the succeeding one for better user experience.
                    WriteLine(" ");

                    // Informs the user that their new category has been added successfully to the table in our SQL database.
                    WriteLine("New Category Added.");

                    // Wait for 1.5 seconds before intiating the code block succeeding this one.
                    Thread.Sleep(1500);

                    // Clear the method from the screen.
                    Clear();

                    // Set the boolean value of addingCategory to false to break out of the loop and return to the main menu..
                    addingCategory = false;
                }
                else if (yesOrNoValidation.Key == ConsoleKey.N)
                {
                    Clear();
                }
            } while (addingCategory);
        }
    }
}