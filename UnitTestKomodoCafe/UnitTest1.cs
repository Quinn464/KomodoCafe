using MenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestKomodoCafe
{
    
    [TestClass]
    public class MenuItem_RepoTests
    {
        [TestMethod]
        public void AddToRepo_ShouldGetCorrectBool() //Create
        {
            //Arrange
            MenuItem item = new MenuItem();
            MenuItem_Repo menu = new MenuItem_Repo();
            //Act
            bool addResult = menu.AddMenuItem(item);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()//Read
        {
            //Arrange
            MenuItem item = new MenuItem();
            MenuItem_Repo menu = new MenuItem_Repo();
            menu.AddMenuItem(item);
            //Act
            List<MenuItem> menuItems = menu.GetMenu();
            bool menuHasItems = menuItems.Contains(item);

            //Assert
            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void GetMenuByMealNum_ShouldReturnCorrectMenuItem()//Read
        {
            //Arrange
            MenuItem_Repo menu = new MenuItem_Repo();
            MenuItem item = new MenuItem(01,
                "Big Mac® Combo Meal",
                "The one and only McDonald’s Big Mac® Combo Meal. Big Mac Ingredients include a classic sesame hamburger bun,\n" +
                " Big Mac Sauce, American cheese and sliced pickles. ",
                "Big Mac Bun, 100% Beef Patty, Shredded Lettuce, Big Mac Sauce, Pasteurized Process American Cheese",

                8);
            menu.AddMenuItem(item);
            int mealNum = 01;
            //Act
            MenuItem searchResult = menu.GetMenuItemByMealNum(mealNum);

            //Assert
            Assert.AreEqual(searchResult.MealNumber, mealNum);

        }

        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnTrue() //Update
        {
            //Arrange
            MenuItem_Repo menu = new MenuItem_Repo();
            MenuItem oldItem = new MenuItem(01,
                "Cheeseburger Combo Meal",
                "Cheeseburger, Coca-Cola (Medium), Medium French Fries",
               "Regular Bun, 100% Beef Patty, Pasteurized Process American Cheese, Ketchup",
                8);
            menu.AddMenuItem(oldItem);
            MenuItem newItem = new MenuItem(02,
                         "Crispy Chicken Sandwich Combo Meal",
                "Crispy Chicken Sandwich, Sprite (Medium), Medium French Fries 990 Cal.",
                "Crispy Chicken Fillet, Potato Roll, Crinkle Cut Pickle, Salted Butter",
                8);
            //Act
            bool updateResult = menu.UpdateExistingMenuItem(oldItem.MealNumber, newItem);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue() //Delete
        {
            //Arrange
            MenuItem_Repo menu = new MenuItem_Repo();
            MenuItem item = new MenuItem(01,
                "Burger and Fries",
                "Our delicious all beef burger and a medium fry",
                "Bun, Burger, Pickles, Onion, Lettuce, Tomato, Fries",
                8);
            menu.AddMenuItem(item);
            int mealNum = 01;

            //Act
            MenuItem oldItem = menu.GetMenuItemByMealNum(mealNum);
            bool removeResult = menu.DeleteMenuItem(oldItem);

            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}
