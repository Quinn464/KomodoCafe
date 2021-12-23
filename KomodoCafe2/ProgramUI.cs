using MenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe2
{
    public class ProgramUI
    {
        //Menu Repo
        private MenuItem_Repo _menu = new MenuItem_Repo();


        //Methods
        public void Run()
        {
            SeedItemMenu();
            MainMenu();
        }

        public void SeedItemMenu()
        {
            //Seed content for menu

            MenuItem meal1 = new MenuItem(01,
                "Big Mac® Combo Meal",
                "The one and only McDonald’s Big Mac® Combo Meal. Big Mac Ingredients include a classic sesame hamburger bun,\n" +
                " Big Mac Sauce, American cheese and sliced pickles. ",
                "Big Mac Bun, 100% Beef Patty, Shredded Lettuce, Big Mac Sauce, Pasteurized Process American Cheese",

                8);
            MenuItem meal2 = new MenuItem(02,
                "Cheeseburger Combo Meal",
                "Cheeseburger, Coca-Cola (Medium), Medium French Fries",
               "Regular Bun, 100% Beef Patty, Pasteurized Process American Cheese, Ketchup",
                8);
            MenuItem meal3 = new MenuItem(03,
                "Crispy Chicken Sandwich Combo Meal",
                "Crispy Chicken Sandwich, Sprite (Medium), Medium French Fries 990 Cal.",
                "Crispy Chicken Fillet, Potato Roll, Crinkle Cut Pickle, Salted Butter",
                8);

            _menu.AddMenuItem(meal1);
            _menu.AddMenuItem(meal2);
            _menu.AddMenuItem(meal3);
        }

        public void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                
               
                Console.WriteLine(" Menu");
                Console.WriteLine("1> View Menu ");
                Console.WriteLine("2> Add New  Menu Item");
                Console.WriteLine("3> Update Menu Item");
                Console.WriteLine("4> Delete Menu Item");
                Console.WriteLine("5> Exit");
                Console.WriteLine("Select an option");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        AddNewItem();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

       
        public void ShowMenu()
        {
            Console.Clear();
            
            
            List<MenuItem> menuItems = _menu.GetMenu();

            foreach (MenuItem item in menuItems)
            {
                Console.WriteLine("Meal number            " + item.MealNumber);
                Console.WriteLine("Meal Name        " + item.MealName);
                Console.WriteLine("Meal Description  " + item.Description);
                Console.WriteLine("Meal Ingredients  " + item.Ingredients);
                Console.WriteLine("Meal Price        $" + item.Price);


                Console.WriteLine("");
            }

            Console.WriteLine("Press Enter to return to go back");
            Console.ReadKey();
        }

        public void AddNewItem()
        {
            MenuItem newItem = new MenuItem();


            bool looper = true;

            while (looper)
            {

                Console.Clear();
            
                
               


                Console.WriteLine("Enter Meal number");
                newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Meal Name");
                newItem.MealName = Console.ReadLine();
                Console.WriteLine("Enter Meal Description");
                newItem.Description = Console.ReadLine();
                Console.WriteLine("Enter list of meal ingredients");
                newItem.Ingredients = Console.ReadLine();
                Console.WriteLine("Enter price of meal");
                newItem.Price = Convert.ToDouble(Console.ReadLine());
        



                Console.WriteLine("Meal number            " + newItem.MealNumber);
                Console.WriteLine("Meal Name         " + newItem.MealName);
                Console.WriteLine("Meal Description  " + newItem.Description);
                Console.WriteLine("Meal Ingredients  " + newItem.Ingredients);
                Console.WriteLine("Meal Price        $" + newItem.Price);
                Console.WriteLine("");
                Console.WriteLine("Do you want to save changes?" +
                    " \nEnter Y/N ");
                string isCorrect = Console.ReadLine();


                if (isCorrect.ToLower() == "y")
                {
                    looper = false;
                }
            }
            bool wasAdded = _menu.AddMenuItem(newItem);
            if (wasAdded == true)
            {
                Console.WriteLine("Menu Item added");
                Console.WriteLine("Press any key to go back");
            }
            else


            {
                Console.WriteLine("Failed try again later");
                Console.WriteLine("Press any key to go back");
            }

            Console.ReadKey();

        }

        public void UpdateMenuItem()



        {
            MenuItem oldItem = new MenuItem();
            Console.Clear();
            
           
            Console.WriteLine("-- Update Existing Menu Item --");
            Console.WriteLine("Enter the Meal # for the Menu Item you'd like to update:");
            int oldMenuNum = Convert.ToInt32(Console.ReadLine());
            oldItem = _menu.GetMenuItemByMealNum(oldMenuNum);
            bool looper = true;
            while (looper)



            {
                Console.Clear();
               
                Console.WriteLine("1> Meal number          " + oldItem.MealNumber);
                Console.WriteLine("2> Meal Name        " + oldItem.MealName);
                Console.WriteLine("3> Meal Description  " + oldItem.Description);
                Console.WriteLine("4> Meal Ingredients  " + oldItem.Ingredients);
                Console.WriteLine("5> Meal Price        $" + oldItem.Price);
                Console.WriteLine("6> Done Editing");



                Console.WriteLine("Please chose what you'd like to change");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        Console.WriteLine("Enter new Meal number");
                        oldItem.MealNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Enter new Name");
                        oldItem.MealName = Console.ReadLine();
                        break;
                    case "3":


                        Console.WriteLine("Enter new meal Description");
                        oldItem.Description = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter new Ingredients");
                        oldItem.Ingredients = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Enter new Price");
                        oldItem.Price = Convert.ToDouble(Console.ReadLine());
                        break;




                    case "6":
                        looper = false;
                        break;
                }
            }
            bool wasUpdate = _menu.UpdateExistingMenuItem(oldMenuNum, oldItem);
            if (wasUpdate == true)
            {
                Console.WriteLine("Menu Item updated. \nPress any key to return");
            }
            else


            {
                Console.WriteLine("Failed try again later");
            }

            Console.ReadKey();



        }

        public void DeleteItem()
        {
            MenuItem oldItem = new MenuItem();


            Console.Clear();
           
           
           
            Console.WriteLine("Enter the Meal number of the item you'd like to delete");
            int mealNum = Convert.ToInt32(Console.ReadLine());
            oldItem = _menu.GetMenuItemByMealNum(mealNum);
         
            Console.WriteLine("Meal number            " + oldItem.MealNumber);
            Console.WriteLine("Meal Name        " + oldItem.MealName);
            Console.WriteLine("Meal Description  " + oldItem.Description);
            Console.WriteLine("Meal Ingredients  " + oldItem.Ingredients);
            Console.WriteLine("Meal Price       $" + oldItem.Price);


            
            Console.WriteLine("Are you sure you want to delete this Y/N?");
           
            string deleteConfirm = Console.ReadLine();
            if (deleteConfirm.ToLower() == "y")
            {
                bool deleteResult = _menu.DeleteMenuItem(oldItem);
                if (deleteResult == true)
                {
                    Console.WriteLine("Item deleted");
                    Console.WriteLine("Press any key to return.");

                }
                else
                {
                    Console.WriteLine("Failed try again later");
                    Console.WriteLine("Press any key to go back.");

                }


            }
            else
            {
                Console.WriteLine("Canceled" +
                    " \nPress any Key to go back.");

            }


            Console.ReadKey();
        }
    }
}
