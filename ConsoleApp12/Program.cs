using System;
using System.Collections.Generic;
using System.Linq;

class MenuItem
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public int CookingTime { get; set; } 

    public MenuItem(string name, List<string> ingredients, int cookingTime)
    {
        Name = name;
        Ingredients = ingredients;
        CookingTime = cookingTime;
    }
}

class Menu
{
    private List<MenuItem> items;

    public Menu()
    {
        items = new List<MenuItem>
        {
            new MenuItem("Салат", new List<string> { "овощи", "масло", "соль" }, 10),
            new MenuItem("Бургер", new List<string> { "булка", "котлета", "сыр" }, 15),
            new MenuItem("Пицца", new List<string> { "тесто", "сыр", "томат" }, 20),
            new MenuItem("Паста", new List<string> { "макароны", "сливки", "сыр" }, 25),
            new MenuItem("Суши", new List<string> { "рис", "рыба", "нори" }, 30),
            new MenuItem("Суп", new List<string> { "овощи", "мясо", "вода" }, 40)
        };
    }

    public void ShowMenu(List<MenuItem> menuItems)
    {
        Console.WriteLine("\nВарианты блюд:");
        Console.WriteLine("--------------------------------------------------");
        foreach (var item in menuItems)
        {
            Console.WriteLine($"Название: {item.Name}, Время готовки: {item.CookingTime} минут, Ингредиенты: {string.Join(", ", item.Ingredients)}");
        }
    }

    public void FilterByIngredientsAndTime(List<string> ingredients, int cookingTime)
    {
        var filteredItems = items.Where(item =>
            item.CookingTime <= cookingTime &&
            ingredients.All(ingredient => item.Ingredients.Contains(ingredient))).ToList();

        if (filteredItems.Any())
        {
            ShowMenu(filteredItems);
        }
        else
        {
            Console.WriteLine("Нет блюд, соответствующих вашим критериям.");
        }
    }
}

class Program
{
    static void Main()
    {
        Menu menu = new Menu();

        Console.WriteLine("Введите ингредиенты через запятую (например, 'овощи, масло, соль'):");
        string ingredientsInput = Console.ReadLine();
        var ingredients = ingredientsInput.Split(',').Select(i => i.Trim().ToLower()).ToList();

        int cookingTime;
        while (true)
        {
            Console.WriteLine("Введите время готовки (в минутах):");
            if (int.TryParse(Console.ReadLine(), out cookingTime))
            {
                break; 
            }
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
        }

        menu.FilterByIngredientsAndTime(ingredients, cookingTime);
    }
}
