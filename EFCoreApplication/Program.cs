using EFCoreApplication.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

                WriteLine("2. Articles [Placebo]");

                WriteLine("3. Exit Application");

                ConsoleKeyInfo mainMenuKeys = ReadKey();

                switch (mainMenuKeys.Key)
                {
                    case ConsoleKey.D1:
                        Clear();

                        ConsoleKeyInfo subMenuOptionsKey;

                        do
                        {
                            WriteLine("1. Add New Category");

                            WriteLine("2. List Categories");

                            WriteLine("3. Add Product to Category");

                            WriteLine("4. Add Category to Category");

                            WriteLine(" ");

                            WriteLine("Press [X] To Return To Main Menu.");

                            subMenuOptionsKey = ReadKey();

                            if (subMenuOptionsKey.Key == ConsoleKey.D1)
                            {
                                // Declaring the addingCategory boolean value and setting it to True.
                                bool addingCategory = true;

                                // Using the method we created to add a category to our table in our database.
                                AddCategory(addingCategory);

                            }
                            else if (subMenuOptionsKey.Key == ConsoleKey.D2)
                            {
                                Clear();

                                WriteLine("Categories");

                                WriteLine("------------------------------------------------------------------");

                                // We want a code here using Entity Framework Core to list our table inside our Console Application.
                                bool listingCategories = true;

                                ListCategories(listingCategories);

                                WriteLine("");

                                WriteLine("[Press Any Key To Return]");

                                ReadKey(true);

                                Clear();
                            }
                            else if (subMenuOptionsKey.Key == ConsoleKey.D3)
                            {
                                Clear();

                                WriteLine("Add Product To Category");

                                WriteLine("------------------------------------------------------------------");

                                // Now we want a method that lists all of our categories, allowing us to add a product to our specified category.
                                bool addingProductToCategory = true;

                                AddProductToCategory(addingProductToCategory);

                                CursorVisible = false;

                                Clear();
                            }
                            else if (subMenuOptionsKey.Key == ConsoleKey.D4)
                            {
                                Clear();

                                bool addingSubcategoryToCategory = true;

                                AddSubcategoryToCategory(addingSubcategoryToCategory);

                                // Here we want a method that lists all of our categories, allowing us to add a subcategory to the respective chosen category.

                                CursorVisible = false;

                                Clear();
                            }
                            else if (subMenuOptionsKey.Key == ConsoleKey.X)
                            {
                                Clear();
                            }
                            else
                            {
                                Clear();
                            }
                        } while (subMenuOptionsKey.Key != ConsoleKey.X);

                        break;
                    case ConsoleKey.D2:
                        Clear();

                        // No function is to be put here. This is just a placebo inside the application.

                        WriteLine("No function is to be put here. This is just a placebo inside the application.");

                        Thread.Sleep(1500);

                        Clear();

                        break;
                    case ConsoleKey.D3:
                        Clear();

                        Environment.Exit(0);

                        break;
                }
            } while (mainMenu);
        }

        // Method for adding a new category to the table Categories in our SQL Database.
        private static void AddCategory(bool addingCategory)
        {
            // Declaring a do, while loop with the addingCategory boolean value set to true.
            do
            {
                // A clear method to clear the main menu while we are adding a new value to our table.
                Clear();

                // Added title, whitespace and line for design purposes and user experience.
                WriteLine("Add New Category");
                WriteLine("------------------------------------------------------------------");

                WriteLine(" ");

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
                        var childCtg = new ChildCategories()
                        {
                            CategoryName = newCategoryName
                        };

                        context.Category.Add(ctg);
                        context.ChildCategories.Add(childCtg);
                        context.SaveChanges();
                    };

                    // After we've created a new category we want the console to clear then inform the user that the following procedure has been successful.
                    Clear();

                    // Informs the user that their new category has been added successfully to the table in our SQL database.
                    WriteLine("New Category Added.");

                    // Wait for 2 seconds before intiating the code block succeeding this one.
                    Thread.Sleep(2000);

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

        // Method for listing all existing values inside our Categories table in our SQL Database.
        // These methods are called queries which are written against the DbSet property of the entity. They're written using LINQ to Entities API.
        private static void ListCategories(bool listingCategories)
        {
            using (var dbRetrieve = new ProgramContext())
            {
                // Here we declare a list for our Categories class to retrieve the data from our table in the database.
                List<Categories> Categories = dbRetrieve.Category.ToList();

                // Foreach value found inside our Categories class which we retrieve from our table, we print it out to the console.
                foreach (Categories ctg in Categories)
                {
                    WriteLine($"Category ID: {ctg.CategoryId} | Category Name: {ctg.CategoryName}");
                }
            }
        }

        // Method for adding a product to our categories.
        private static void AddProductToCategory(bool addingProductToCategory)
        {
            // Here we use our preceding method inside this method for listing all of the categories.
            bool listingCategories = true;

            ListCategories(listingCategories);

            // Here we want the user to be able to specify which category to choose by ID and to be able to add a new product to that category.

            // Whitespace
            WriteLine(" ");

            // ReadLine for the user to input which ID will be chosen.
            Write("Specify Category By Entering Corresponding ID: ");

            // CursorVisible set to visible for better user experience.
            CursorVisible = true;

            // We convert the string input by the user to an integer which can be read by SQL through the query further below.
            int specifyById = int.Parse(ReadLine());

            // CursorVisible set to hidden after user has input which ID to be chosen.
            CursorVisible = false;

            // Declare a variable with a new ProgramContext so that we can list out the category by the specified ID input by the user.
            var context = new ProgramContext();

            // Save the selected category by ID through variable.
            var selectedCategory = context.Category.Find(specifyById);

            /* Here we create a List with the class Categories and search for the specific Category where the ID of that Category corresponds with the one input by the user 
            in the specifyById variable. */
            List<Categories> specifyCategoryById = context.Category
                .Where(c => c.CategoryId == specifyById)
                .ToList();

            Clear();

            // For User Experience.
            WriteLine("Add Product To Chosen Category");

            WriteLine("------------------------------------------------------------------");

            // We iterate over the list to print out the category name and ID on to the console.
            foreach (Categories ctg in specifyCategoryById)
            {
                WriteLine($"Category ID: {ctg.CategoryId} | Category Name: {ctg.CategoryName}");
            }

            // Here we want to give the user the option to exit from the process or to add a product to the category.
            WriteLine(" ");

            WriteLine("[A] Add Product [ESC] Return To Submenu");

            // Declaring a ConsoleKeyInfo outside of the do, while loop.
            ConsoleKeyInfo addProductOrReturnToSubMenu;

            do
            {
                /* Assigning a ReadKey(true) to the ConsoleKeyInfo declared outside of the do, while loop inside the do, while loop so that the code block won't loop or crash
                rather than if we'd assign it the instant we declared our ConsoleKeyInfo. */
                addProductOrReturnToSubMenu = ReadKey(true);

                if (addProductOrReturnToSubMenu.Key == ConsoleKey.A)
                {
                    // Whitespace
                    WriteLine(" ");

                    // Here we want the user to search for a product to add to the category through the name of the product.
                    Write("Search For Product By Name: ");

                    // CursorVisible set to visible for better user experience.
                    CursorVisible = true;

                    var findProductThroughName = ReadLine();

                    // Here we create a list with the class Products and search for any product or products matching the string input by the user through the findProductThroughName variable.
                    List<Products> findProductByName = context.Product
                        .Where(p => p.ProductName.StartsWith(findProductThroughName))
                        .ToList();

                    // Whitespace
                    WriteLine(" ");

                    // For User Experience.
                    WriteLine("Choose Product To Add To Chosen Category");

                    WriteLine("------------------------------------------------------------------");

                    // We iterate over the list to print out the product name and ID on to the console.
                    foreach (Products product in findProductByName)
                    {
                        WriteLine($"Product ID: {product.ProductId} | Product Name: {product.ProductName}");
                    }

                    // Whitespace
                    WriteLine(" ");

                    // For User Experience.
                    Write("Choose Product To Add By ID: ");

                    // For the user to specifiy which product to add through ID.
                    int selectProductById = int.Parse(Console.ReadLine());

                    // CursorVisible set to hidden after user has input which product name and ID to be specified and searched for.
                    CursorVisible = false;

                    // Adding the chosen product ID to the chosen category ID.
                    var selectedProduct = context.Product.Find(selectProductById);
                    selectedProduct.Category.Add(selectedCategory);

                    context.SaveChanges();

                    // Clear the console and inform the user that the product ID has been added to the category ID then clear the console after 2 seconds.
                    Clear();
                    
                    WriteLine("Product Added To Category.");

                    Thread.Sleep(2000);

                    Clear();

                    break;
                }
                else if (addProductOrReturnToSubMenu.Key == ConsoleKey.Escape)
                {
                    Clear();
                }
            } while (addProductOrReturnToSubMenu.Key != ConsoleKey.Escape);
        }

        private static void AddSubcategoryToCategory(bool addingSubcategoryToCategory)
        {
            // For User Experience.
            WriteLine("Add Subcategory To Category");

            WriteLine("------------------------------------------------------------------");

            // Here we use our preceding method inside this method for listing all of the categories.
            bool listingCategories = true;

            ListCategories(listingCategories);

            // Whitespace
            WriteLine(" ");

            // CursorVisible set to visible for better user experience.
            CursorVisible = true;

            // ReadLine for the user to input which IDs will be chosen.
            Write("Choose Parent Category ID: ");

            // We use parse an integer input by the user so that it can be read by SQL through the query.
            int parentalCategoryId = int.Parse(ReadLine());

            // Declare a variable with a new ProgramContext so that we can list out the category by the specified ID input by the user.
            var context = new ProgramContext();

            // Save the selected parent category by ID through variable.
            var selectedParentCategory = context.Category.Find(parentalCategoryId);

            WriteLine(" ");

            Write("Choose Child Category ID: ");

            int childCategoryId = int.Parse(ReadLine());

            // CursorVisible set to hidden after user has input which category IDs to be chosen.
            CursorVisible = false;

            // Adding the chosen parent category ID to the chosen children category ID.
            var selectedCategories = context.ChildCategories.Find(childCategoryId);
            selectedCategories.ParentCategory.Add(selectedParentCategory);

            context.SaveChanges();

            // After we've linked the two categories together we want the console to clear then inform the user that the following procedure has been successful.
            Clear();

            WriteLine("Category Added To Category");

            Thread.Sleep(2000);
        }
    }
}