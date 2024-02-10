using System;
using System.Collections.Generic;

// Класс Счетчик
class Counter : IDisposable
{
    private int count;

    public Counter()
    {
        this.count = 0;
    }

    public void Add()
    {
        count++;
    }

    public int GetCount()
    {
        return count;
    }

    public void Dispose()
    {
        if (count > 0)
        {
            throw new InvalidOperationException("Counter resource was not properly managed.");
        }
    }
}

// Базовый класс Животное
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void ShowCommands()
    {
        Console.WriteLine("Животное не знает ни одной команды.");
    }

    public virtual void AddCommand(string command)
    {
        Console.WriteLine("Невозможно добавить команду. Животное не знает команд.");
    }
}

// Класс Собака, наследующий от Животное
public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {
    }
    
    public void ShowCommands()
    {
        // Метод для отображения списка команд
        Console.WriteLine($"{Name} знает команды сидеть и стоять.");
    }
    public void AddCommand(string command)
    {
        // Метод для добавления новой команды
        Console.WriteLine($"Добавлена новая команда для {Name}: {command}");
    }

}

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {
    }

    public override void ShowCommands()
    {
        Console.WriteLine($"{Name} может мяукать и охотиться.");
    }

    public override void AddCommand(string command)
    {
        Console.WriteLine($"Добавлена новая команда для {Name}: {command}");
    }
}

public class Hamster : Animal
{
    public Hamster(string name, int age) : base(name, age)
    {
    }

    public override void ShowCommands()
    {
        Console.WriteLine($"{Name} может бегать по колесу и есть семечки.");
    }

    public override void AddCommand(string command)
    {
        Console.WriteLine($"Добавлена новая команда для {Name}: {command}");
    }
}

public class Horse : Animal
{
    public Horse(string name, int age) : base(name, age)
    {
    }

    public override void ShowCommands()
    {
        Console.WriteLine($"{Name} может ржать и бегать.");
    }

    public override void AddCommand(string command)
    {
        Console.WriteLine($"Добавлена новая команда для {Name}: {command}");
    }
}

public class Donkey : Animal
{
    public Donkey(string name, int age) : base(name, age)
    {
    }

    public override void ShowCommands()
    {
        Console.WriteLine($"{Name} может издавать звуки и таскать грузы.");
    }

    public override void AddCommand(string command)
    {
        Console.WriteLine($"Добавлена новая команда для {Name}: {command}");
    }
}


class AnimalRegistry
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        using (Counter counter = new Counter())
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Завести новое животное");
                Console.WriteLine("2. Определить животное в правильный класс");
                Console.WriteLine("3. Увидеть список команд, которые выполняет животное");
                Console.WriteLine("4. Обучить животное новым командам");
                Console.WriteLine("5. Выход");

                string choice = Console.ReadLine()!;
                string name;
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите имя животного:");
                        name = Console.ReadLine()!;
                        Console.WriteLine("Введите возраст животного:");
                        int age = int.Parse(Console.ReadLine()!);
                        Console.WriteLine("Выберите тип животного (1 - Собака, 2 - Кошка, 3 - Хомяк, 4 - Лошадь, 5 - Осел):");
                        int type = int.Parse(Console.ReadLine()!);
                        Animal animal;
                        switch (type)
                        {
                            case 1:
                                animal = new Dog(name, age);
                                break;
                            case 2:
                                animal = new Cat(name, age);
                                break;
                            case 3:
                                animal = new Hamster(name, age);
                                break;
                            case 4:
                                animal = new Horse(name, age);
                                break;
                            case 5:
                                animal = new Donkey(name, age);
                                break;
                            default:
                                Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                                continue;
                        }
                        // Создание объекта животного и увеличение счетчика
                        counter.Add();
                        break;
                    case "2":
                        // Определение животного в правильный класс
                        Console.WriteLine("Выберите тип животного (Собака, Кошка, Хомяк, Лошадь, Осел):");
                        string type = Console.ReadLine()!;
                        Animal animal;
                        Console.WriteLine("Введите имя животного:");
                        name = Console.ReadLine()!;
                        switch (type.ToLower())
                        {
                            case "собака":
                                animal = new Dog(name);
                                break;
                            case "кошка":
                                animal = new Cat(name);
                                break;
                            case "хомяк":
                                animal = new Hamster(name);
                                break;
                            case "лошадь":
                                animal = new Horse(name);
                                break;
                            case "осел":
                                animal = new Donkey(name);
                                break;
                            default:
                                Console.WriteLine("Неверный тип животного.");
                                return;
                        }
                        break;
                    case "3":
                        // Отображение списка команд
                        Console.WriteLine("Введите имя животного:");
                        string animalName = Console.ReadLine()!;
                        Animal foundAnimal = animals.FirstOrDefault(a => a.Name == animalName);
                        if (foundAnimal != null)
                        {
                            foundAnimal.ShowCommands();
                        }
                        else
                        {
                            Console.WriteLine("Животное не найдено.");
                        }
                        break;
                    case "4":
                        // Обучение новым командам
                        Console.WriteLine("Введите имя животного:");
                        string animalNameForTraining = Console.ReadLine()!;
                        Animal animalForTraining = animals.FirstOrDefault(a => a.Name == animalNameForTraining);
                        if (animalForTraining != null)
                        {
                            Console.WriteLine("Введите новую команду:");
                            string newCommand = Console.ReadLine()!;
                            animalForTraining.AddCommand(newCommand);
                        }
                        else
                        {
                            Console.WriteLine("Животное не найдено.");
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }
    }
}
