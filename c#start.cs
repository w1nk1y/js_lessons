// Интерфейс Животное
public interface IAnimal
{
    string Name { get; } // Имя животного
    void noise(); // Метод для издания звука животным
}

//Абстрактный класс Животное
public abstract class Animal : IAnimal
{
    public string Name { get; protected set; } // Свойство для имени животного

    public Animal(string name) // Конструктор класса Животное
    {
        Name = name;
    }

    public abstract void noise(); // Абстрактный метод для издания звука
}

// Травоядное
public abstract class Herbivore : Animal
{
    protected Herbivore(string name) : base(name) { } // Конструктор класса 

    public override void noise() // Переопределение метода 
    {
        Console.WriteLine("Травоядное издает звук");
    }
}

// Хищник
public abstract class Carnivore : Animal
{
    protected Carnivore(string name) : base(name) { } 

    public override void noise() 
    {
        Console.WriteLine("Хищник издает звук");
    }
}

// Всеядное
public abstract class Omnivore : Animal
{
    protected Omnivore(string name) : base(name) { } 

    public override void noise() 
    {
        Console.WriteLine("Всеядное издает звук");
    }
}

//Белка
public class Squirrel : Herbivore
{
    public Squirrel() : base("Белка") { } 
}

//Кошка
public class Cat : Carnivore
{
    public Cat() : base("Кошка") { } 
}

//Тигр
public class Tiger : Carnivore
{
    public Tiger() : base("Тигр") { } 
}

//Собака
public class Dog : Omnivore
{
    public Dog() : base("Собака") { } 
}

//Воробей
public class Sparrow : Omnivore
{
    public Sparrow() : base("Воробей") { } 
}

// Создаем список животных
List<IAnimal> animals = new List<IAnimal>
{// Добавляем в список животных
    new Squirrel(), 
    new Cat(),     
    new Tiger(),   
    new Dog(),     
    new Sparrow()  
};

// Перебираем список
foreach (var animal in animals)
{
    // Выводим имя животного и звук, который оно издает
    Console.WriteLine($"{animal.Name} издает звук:");
    animal.noise();
}

