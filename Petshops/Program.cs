namespace Petshop;

enum Gender { male, female }

class Food
{
    public string? name;
    public int quantity;
    public int price;

    public Food(string? name, int quantity, int price)
    {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }
}

class Toy
{
    public string? name;
    public int quantity;
    public int price;

    public Toy(string? name, int quantity, int price)
    {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }
}


class Animal
{
    public string? name;
    public int age;
    public Gender gender;
    public double price;
    public int energy;
    public int mealQuantity;

    public Animal()
    {

    }

    public Animal(string? name, int age, Gender gender, double price, int energy, int mealQuantity)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.price = price;
        this.energy = energy;
        this.mealQuantity = mealQuantity;
    }

    virtual public void Eat(Food food) { }

    virtual public void Sleep() { }

    virtual public void Play(Toy toy) { }

    virtual public void ShowData()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Energy: {energy}");
        Console.WriteLine($"MealQuantity: {mealQuantity}");
    }
}

class Cat : Animal
{
    // eat bar -- 80
    // sleep bar -- 100
    // energy bar -- 100


    public Cat() { }

    public Cat(string? name, int age, Gender gender, double price, int energy, int mealQuantity)
        : base(name, age, gender, price, energy, mealQuantity)
    { }

    public override void Eat(Food food)
    {
        if (mealQuantity == 80)
        {
            Console.WriteLine("Cat is not hungry!");
            return;
        }

        mealQuantity = mealQuantity + food.quantity == 80 ? 80 : mealQuantity + food.quantity;
        price += food.price + 40;
    }

    public override void Play(Toy toy)
    {
        if (energy <= 20)
        {
            Console.WriteLine("Cat tired! have to sleep!");
            return;
        }

        Console.WriteLine($"Cat playing with {toy.name}");
        while (energy != 19)
        {
            energy--;
            Thread.Sleep(200);
        }
        Console.WriteLine($"Current energy of cat: {energy}");
        price += 30;
    }

    public override void Sleep()
    {
        if (energy == 100)
        {
            Console.WriteLine("Cat's energy is full now");
            return;
        }

        Console.WriteLine("Keep quite!");
        while (energy != 101)
        {
            energy++;
            Thread.Sleep(200);
        }

        Console.WriteLine("Cat's energy is full now!");
        price += 35;
    }

}

class Dog : Animal
{
    // eat bar -- 150
    // sleep bar -- 100
    // energy bar -- 170



    public Dog(string? name, int age, Gender gender, double price, int energy, int mealQuantity)
        : base(name, age, gender, price, energy, mealQuantity)
    { }


    public override void Eat(Food food)
    {
        if (mealQuantity == 150)
        {
            Console.WriteLine("Dog is not hungry");
            return;
        }

        mealQuantity = mealQuantity + food.quantity == 150 ? 150 : mealQuantity + food.quantity;

        Console.WriteLine($"Dog eating now {food.name}");
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(1000);
        }
        Console.WriteLine($"Dog eated food {food.name}, current bar {mealQuantity}");
        price += 50;
    }


    public override void Sleep()
    {
        if (energy == 170)
        {
            Console.WriteLine("Cat's energy is full now");
            return;
        }

        Console.WriteLine("Keep quite!");
        while (energy != 171)
        {
            energy++;
            Thread.Sleep(200);
        }

        Console.WriteLine($"Current energy {energy}");
        price += 45;

    }


    public override void Play(Toy toy)
    {
        if (energy <= 40)
        {
            Console.WriteLine("Dog tired! have to sleep!");
            return;
        }

        Console.WriteLine($"Dog playing with {toy.name}");
        while (energy != 39)
        {
            energy--;
            Thread.Sleep(200);
        }
        Console.WriteLine($"Current energy of Do: {energy}");
        price += 80;
    }

}

class PetShop
{
    public string? name;
    public DateTime openDate;
    private string? data;

    public PetShop(string name)
    {
        this.name = name;
        openDate = DateTime.Now;
    }


    public Cat[] cats = new Cat[]
    {
        new Cat("Mestan", 1, Gender.female, 100, 100, 100),
        new Cat("Sari", 2, Gender.female, 100, 100, 100),
        new Cat("MirMovsum", 1, Gender.male, 10, 10, 100),
    };
    public Dog[] dogs = new Dog[]
    {
        new Dog("Toplan", 2, Gender.male, 0, 0, 0),
        new Dog("Toppus", 2, Gender.female, 0, 0, 0),
    };

    public void ShowData()
    {
        Console.WriteLine($"Petshop {name}");
        Console.WriteLine($"Open Date {openDate}");
        Console.WriteLine("---------------------------------------");


        for (int i = 0; i < cats.Length; i++)
        {
            cats[i].ShowData();
            Console.WriteLine("---------------------------------------");
        }

        for (int i = 0; i < dogs.Length; i++)
        {
            dogs[i].ShowData();
            Console.WriteLine("---------------------------------------");
        }
    }

    public void ControlAnimal(Animal animal)
    {
        while (true)
        {

            Console.Clear();
            Console.WriteLine($"Energy {animal.energy}");
            Console.WriteLine($"Hungry {animal.mealQuantity}");
            Console.WriteLine($"Price of Animal {animal.price}");

            Console.WriteLine("Eat -- > 1");
            Console.WriteLine("Sleep -- > 2");
            Console.WriteLine("Play -- > 3");
            data = Console.ReadLine();

            if (data == "1")
            {
                animal.Eat(new Food("KisKas", 70, 5));
            }
            else if (data == "2")
            {
                animal.Sleep();
            }
            else if (data == "3")
            {
                animal.Play(new Toy("Top", 30, 15));
            }
        }

    }

    public void SelectPet()
    {
        Console.Clear();


        Console.WriteLine("Cat -- > 1");
        Console.WriteLine("Dog -- > 2");
        data = Console.ReadLine();

        if (data == "1")
        {
            for (int i = 0; i < cats.Length; i++)
            {
                cats[i].ShowData();
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Enter name of cat");
            data = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < cats.Length; i++)
            {
                if (cats[i].name == data)
                {
                    cats[i].ShowData();
                    ControlAnimal(cats[i]);
                }
            }
            Console.WriteLine("Cat not found!");
        }
        else if (data == "2")
        {
            Console.Clear();

            for (int i = 0; i < dogs.Length; i++)
            {
                dogs[i].ShowData();
            }


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Enter name of dog");
            data = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < dogs.Length; i++)
            {
                if (dogs[i].name == data)
                {
                    dogs[i].ShowData();
                    ControlAnimal(dogs[i]);
                }
            }
            Console.WriteLine("Cat not found!");

        }
    }


}



class Program
{
    static void Main()
    {

        PetShop petshop = new PetShop("Kurdan Petshop");

        string? data;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to {petshop.name}");
            Console.WriteLine("Show Pets -- > 1");
            Console.WriteLine("Select Pet -- > 2");

            data = Console.ReadLine();

            if (data == "1")
            {
                petshop.ShowData();
                Thread.Sleep(3000);
            }
            else if (data == "2")
            {
                petshop.SelectPet();
            }
        }


    }


}

