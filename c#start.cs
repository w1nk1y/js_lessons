using System.Linq;
//Абстрактный класс Животное
public abstract class Animal 
{
    public string Name { get; protected set; }// Имя 
    
    public Animal(string name) // Конструктор класса Животное
    {
        Name = name;
    }
    public abstract void action();//Чтобы действие делать
    public abstract void noise(); //Издание звука
}

// Травоядное
public class Herbivore : Animal
{
    protected Herbivore(string name) : base(name) { } // Конструктор класса 

    public override void action()
    {
       Console.WriteLine("Я не ем моих собратьев"); 
    }
    public override void noise() // Переопределение метода 
    {
        Console.WriteLine("Муу Чик-чирык");
    }
}

// Хищник
public class Carnivore : Animal
{
    protected Carnivore(string name) : base(name) { } 
    public override void action(Herbivore travoman, List<Animal> travomans)
    {
       Console.WriteLine($"{Name} съел {travoman.Name}");
       travomans.Remove(travoman);
    }
    public override void noise() 
    {
        Console.WriteLine("Ар гав ууу");
    }
}

// Всеядное
public class Omnivore : Animal
{
    protected Omnivore(string name) : base(name) { } 

    public override void action(Herbivore travoman, Carnivore miasoed, List<Animal> travomans,List<Animal> miasoeds)
    {
       Console.WriteLine($"{Name} съел {travoman.Name}");
       travomans.Remove(travoman);
       Console.WriteLine($"{Name} закусил {miasoed.Name}");
       miasoeds.Remove(miasoed);
    }
    public override void noise() 
    {
        Console.WriteLine("Всеядное издает звук");
    }
}


Omnivore cat = new Omnivore("Мурзик");
Herbivore belka = new Herbivore("Стрелка");
Carnivore tiger = new Carnivore("Амур");
Carnivore dog = new Carnivore("Бобик");     
Herbivore vorobei = new Herbivore("Джек"); 

List<Animal> miasoeds = new List<Animal> { tiger, dog };
List<Animal> travomans = new List<Animal> { belka, vorobei };
List<Animal> vseyadnie = new List<Animal> { cat };

//Хищник ест 
(Animal animal = miasoeds.OrderBy(a => Guid.NewGuid()).First()).action(Animal animal = travomans.OrderBy(a => Guid.NewGuid()).First(), travomans);
//Всеядное плотно хавает
(Animal animal = vseyadnie.OrderBy(a => Guid.NewGuid()).First()).action(Animal animal = travomans.OrderBy(a => Guid.NewGuid()).First(),Animal animal = vseyadnie.OrderBy(a => Guid.NewGuid()).First(), travomans, vseyadnie);

// Перебираем 
foreach (var animal in vseyadnie)
{
    Console.WriteLine($"{animal.Name} издает звук:");
    animal.noise();
}
foreach (var animal in travomans)
{
    Console.WriteLine($"{animal.Name} издает звук:");
    animal.noise();
}
foreach (var animal in miasoeds)
{
    Console.WriteLine($"{animal.Name} издает звук:");
    animal.noise();
}

